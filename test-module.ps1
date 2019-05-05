param([switch]$Isolated)
$ErrorActionPreference = 'Stop'

if(-not $Isolated) {
  Write-Host -ForegroundColor Green 'Creating isolated process...'
  $pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
  & "$pwsh" -NonInteractive -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated
  return
}

$ProgressPreference = 'SilentlyContinue'
. (Join-Path $PSScriptRoot 'check-dependencies.ps1') -Isolated -Accounts:$false -Pester

$localModulesPath = Join-Path $PSScriptRoot 'generated\modules'
if(Test-Path -Path $localModulesPath) {
  $env:PSModulePath = "$localModulesPath$([IO.Path]::PathSeparator)$env:PSModulePath"
}

$modulePsd1 = Get-Item -Path (Join-Path $PSScriptRoot './Xkcd.psd1')
$modulePath = $modulePsd1.FullName
$moduleName = $modulePsd1.BaseName

Import-Module -Name Pester
Import-Module -Name $modulePath

$testFolder = Join-Path $PSScriptRoot 'test'
Invoke-Pester -Script @{ Path = $testFolder } -EnableExit -OutputFile (Join-Path $testFolder "$moduleName-TestResults.xml")