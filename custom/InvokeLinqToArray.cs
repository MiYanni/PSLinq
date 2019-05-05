using System.Management.Automation;

namespace Sample.API.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, @"LinqToArray")]
    [Alias("LinqToArray")]
    [OutputType(typeof(PSObject[]))]
    [Description("Converts a " + nameof(PSDeferredEnumerable) + " to an array. This forces query evaluation.")]
    public class InvokeLinqToArray : LinqCmdlet
    {
        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(DeferredEnumerable.Collection, true);
        }
    }
}