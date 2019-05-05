<#
.Synopsis
Groups the elements of a sequence.
.Description
Groups the elements of a sequence.
.Link
https://docs.microsoft.com/en-us/powershell/module/xkcd/invoke-linqgroupby
#>
function Invoke-LinqGroupBy {
[Alias('LinqGroupBy')]
[OutputType('Sample.API.Cmdlets.PSDeferredEnumerable')]
[CmdletBinding(PositionalBinding=$false)]
[Sample.API.Description('Groups the elements of a sequence.')]
param(
    [Parameter(Position=0, Mandatory, HelpMessage='A script to test each element for a condition.')]
    [ValidateNotNull()]
    [Sample.API.Category('Body')]
    [System.Management.Automation.ScriptBlock]
    ${KeySelector},

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
            __AllParameterSets = 'Xkcd.private\Invoke-LinqGroupBy';
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
