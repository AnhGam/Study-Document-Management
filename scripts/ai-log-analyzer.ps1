# ai-log-analyzer.ps1
# Script to send build error logs to Gemini API for analysis

param(
    [string]$LogFile = "error.log",
    [string]$ApiKey
)

# Robust check for API Key before proceeding
if (-not $ApiKey -or $ApiKey -eq "" -or $ApiKey -eq "`"`"") {
    Write-Host "WARNING: GEMINI_API_KEY is missing or empty. Skipping AI analysis to avoid pipeline crash."
    exit 0
}

Write-Host "--- Sending error logs to Gemini Analyst (Flash Latest) ---"

# Ensure log file exists
if (-not (Test-Path $LogFile)) {
    # If no log file, create a dummy one for analysis context
    "No build error log found. The build might have failed in a step that did not generate a log file." | Out-File $LogFile
}

$logContent = Get-Content $LogFile -Tail 100 | Out-String
$prompt = @"
You are a DevOps expert. I encountered a build error in a WinForms (.NET 4.8) project.
Below are the last 100 lines of logs. Briefly explain the cause and suggest a fix (max 150 words, in English).

LOG:
$logContent
"@

$body = @{
    contents = @(
        @{
            parts = @(
                @{ text = $prompt }
            )
        }
    )
} | ConvertTo-Json -Depth 10

$apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent"
$headers = @{
    "x-goog-api-key" = $ApiKey
    "Content-Type"   = "application/json"
}

try {
    $response = Invoke-RestMethod -Uri $apiUrl -Method Post -Headers $headers -Body $body
    $analysis = $response.candidates[0].content.parts[0].text
    
    Write-Host "`nAI ANALYSIS:`n"
    Write-Host $analysis
    
    $analysis | Out-File "ai_analysis.md"
} catch {
    Write-Host "ERROR: Failed to call Gemini API: $_"
}
