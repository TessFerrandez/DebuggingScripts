############################################################
# mini script to invoke a number of requests simultaneously
# the name is a nod to the old tool tinyget that no longer exists
# usage .\tinyget.ps1 -url https://localhost:44350/FeaturedProducts -numTimes 10

param ($url, $numTimes)

$maxConcurrentJobs = 10

Write-Host "Calling $url $numTimes times"

# Create a runspace pool where $maxConcurrentJobs is the
# maximum number of runspaces allowed to run concurrently
$Runspace = [runspacefactory]::CreateRunspacePool(1, $maxConcurrentJobs)

# Open the runspace pool (very important)
$Runspace.Open()

for ($i=0; $i-le $numTimes; $i++){
    # Create a new PowerShell instance and tell it to execute in our runspace pool
    $ps = [powershell]::Create()
    $ps.RunspacePool = $Runspace

    # Attach some code to it
    [void]$ps.AddCommand("Invoke-WebRequest").AddParameter("UseBasicParsing",$true).AddParameter("Uri",$url)

    # Begin execution asynchronously (returns immediately)
    [void]$ps.BeginInvoke()

    # Give feedback on how far we are
    Write-Host ("Initiated request for {0}" -f $url)
}