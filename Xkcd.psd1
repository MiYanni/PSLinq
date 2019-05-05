@{
# region definition 
  RootModule = './Xkcd.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Xkcd.private.dll'
  FormatsToProcess = './Xkcd.format.ps1xml'
# endregion 

# region persistent data 
  GUID = '3e529007-8f9a-4b44-ce8e-baa198a3b21b'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = ''
      LicenseUri = ''
      ProjectUri = ''
      ReleaseNotes = ''
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Get-XkcdComic', 'Invoke-LinqGroupBy', 'Invoke-LinqToArray', 'Invoke-LinqWhere', '*'
  AliasesToExport = 'LinqGroupBy', 'LinqToArray', 'LinqWhere', '*'
# endregion

}