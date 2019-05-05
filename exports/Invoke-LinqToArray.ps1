<#
.Synopsis
Converts a PSDeferredEnumerable to an array. This forces query evaluation.
.Description
Converts a PSDeferredEnumerable to an array. This forces query evaluation.
.Link
https://docs.microsoft.com/en-us/powershell/module/xkcd/invoke-linqtoarray
#>
function Invoke-LinqToArray {
[Alias('LinqToArray')]
[OutputType('System.Management.Automation.PSObject[]')]
[CmdletBinding(PositionalBinding=$false)]
[Sample.API.Description('Converts a PSDeferredEnumerable to an array. This forces query evaluation.')]
param(
    [Parameter(Mandatory, ValueFromPipeline, HelpMessage='The collection to process.')]
    [ValidateNotNull()]
    [Sample.API.Category('Body')]
    [System.Management.Automation.PSObject]
    ${InputObject}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PsCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Xkcd.private\Invoke-LinqToArray';
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
