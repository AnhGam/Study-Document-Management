# ai-log-analyzer.ps1
# Script to send build error logs to Gemini API for analysis

param(
    [string]$LogFile,
    [string]$ApiKey
)

if (-not $ApiKey) {
    Write-Host "WARNING: GEMINI_API_KEY is missing. Skipping AI analysis."
    exit 0
}

Write-Host "--- Sending error logs to Gemini 1.5 Pro for analysis ---"

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

# Using x-goog-api-key header for better stability
$apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent"
$headers = @{
    "x-goog-api-key" = $ApiKey
    "Content-Type"   = "application/json"
}

try {
    $response = Invoke-RestMethod -Uri $apiUrl -Method Post -Headers $headers -Body $body
    $analysis = $response.candidates[0].content.parts[0].text
    
    Write-Host "`nAI ANALYSIS (GEMINI 1.5 PRO):`n"
    Write-Host $analysis
    
    # Save to file for GitHub summary
    $analysis | Out-File "ai_analysis.md"
} catch {
    Write-Host "ERROR: Failed to call Gemini API: $_"
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        $errorBody = $reader.ReadToEnd()
        Write-Host "Details: $errorBody"
    }
}
