<#
.Synopsis
Fetch current comic and metadata.\n
.Description
Fetch current comic and metadata.\n
.Link
https://docs.microsoft.com/en-us/powershell/module/xkcd/get-xkcdcomic
#>
function Get-XkcdComic {
[OutputType('Sample.API.Models.IComic')]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
[Sample.API.Description('Fetch current comic and metadata.\n')]
param(
    [Parameter(ParameterSetName='Get1', Mandatory, HelpMessage='HELP MESSAGE MISSING')]
    [Sample.API.Category('Path')]
    [System.Single]
    ${ComicId},

    [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
    [Sample.API.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Sample.API.Category('Runtime')]
    [Sample.API.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Sample.API.Category('Runtime')]
    [Sample.API.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
    [Sample.API.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [Sample.API.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
    [Sample.API.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PsCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Xkcd.private\Get-XkcdComic_Get';
            Get1 = 'Xkcd.private\Get-XkcdComic_Get1';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($myInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
