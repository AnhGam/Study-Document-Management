# pr-reviewer-github.ps1
# Script using GitHub Models (GPT-4o) for automated Pull Request reviews

param(
    [string]$DiffFile,
    [string]$Token
)

if (-not $Token) {
    Write-Host "WARNING: GITHUB_TOKEN is missing. Skipping PR Review."
    exit 0
}

Write-Host "--- Calling GitHub Models (GPT-4o) for Pull Request review ---"

$diffContent = Get-Content $DiffFile | Out-String
if ([string]::IsNullOrWhiteSpace($diffContent)) {
    Write-Host "SUCCESS: No changes to review."
    exit 0
}

# Limit diff size to avoid token overflow
if ($diffContent.Length -gt 15000) {
    $diffContent = $diffContent.Substring(0, 15000) + "... (Diff truncated by system)"
}

$prompt = @"
You are a Senior C# Developer. Review the following Pull Request changes (git diff).
Comment on code quality, potential bugs, and architectural improvements.
Keep it concise and focus on critical issues (in English).

DIFF:
$diffContent
"@

$body = @{
    model = "gpt-4o"
    messages = @(
        @{ role = "user"; content = $prompt }
    )
} | ConvertTo-Json

$apiUrl = "https://models.inference.ai.azure.com/chat/completions"

try {
    $response = Invoke-RestMethod -Uri $apiUrl `
        -Method Post -Headers @{ Authorization = "Bearer $Token"; "Content-Type" = "application/json" } `
        -Body $body
    
    $review = $response.choices[0].message.content
    
    Write-Host "`nAI REVIEW (GITHUB MODELS):`n"
    Write-Host $review
    
    # Save for summary
    $review | Out-File "pr_review_ai.md"
} catch {
    Write-Host "ERROR: Failed to call GitHub Models: $_"
}
