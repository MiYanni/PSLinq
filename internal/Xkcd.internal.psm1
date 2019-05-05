# region LoadScripts 

# endregion 

# region Initialization 

# endregion 

# region Generated 
  # Load the private module dll
  $null = Import-Module -PassThru -Name (Join-Path $PSScriptRoot '..\bin\Xkcd.private.dll')

  # Get the private module's instance
  $instance = [Sample.API.Module]::Instance

  # Export nothing to clear implicit exports
  Export-ModuleMember

  # Export proxy cmdlet scripts
  $exportsPath = $PSScriptRoot
  $directories = Get-ChildItem -Directory -Path $exportsPath
  $profileDirectory = $null
  if($instance.ProfileName) {
    if(($directories | ForEach-Object { $_.Name }) -contains $instance.ProfileName) {
      $profileDirectory = $directories | Where-Object { $_.Name -eq $instance.ProfileName }
    } else {
      # Don't export anything if the profile doesn't exist for the module
      $exportsPath = $null
      Write-Warning "Selected Azure profile '$($instance.ProfileName)' does not exist for module '$($instance.Name)'. No cmdlets were loaded."
    }
  } elseif(($directories | Measure-Object).Count -gt 0) {
    # Load the last folder if no profile is selected
    $profileDirectory = $directories | Select-Object -Last 1
  }

  if($profileDirectory) {
    Write-Information "Loaded Azure profile '$($profileDirectory.Name)' for module '$($instance.Name)'"
    $exportsPath = $profileDirectory.FullName
  }

  if($exportsPath) {
    Get-ChildItem -Path $exportsPath -Recurse -Filter '*.ps1' -File | ForEach-Object { . $_.FullName }
    Export-ModuleMember -Function (Get-ScriptCmdlet -ScriptFolder $exportsPath) -Alias (Get-ScriptCmdlet -ScriptFolder $exportsPath -AsAlias)
  }
# endregion
