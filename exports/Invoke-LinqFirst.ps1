<#
.Synopsis
Returns the first element of a sequence.
.Description
Returns the first element of a sequence.
.Link
https://docs.microsoft.com/en-us/powershell/module/xkcd/invoke-linqfirst
#>
function Invoke-LinqFirst {
[Alias('LinqFirst')]
[OutputType('System.Management.Automation.PSObject')]
[CmdletBinding(PositionalBinding=$false)]
[Sample.API.Description('Returns the first element of a sequence.')]
param(
    [Parameter(Position=0, HelpMessage='A script to test each element for a condition.')]
    [ValidateNotNull()]
    [Sample.API.Category('Body')]
    [System.Management.Automation.ScriptBlock]
    ${Predicate},

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
            __AllParameterSets = 'Xkcd.private\Invoke-LinqFirst';
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
