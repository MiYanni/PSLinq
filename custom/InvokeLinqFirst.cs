using System.Linq;
using System.Management.Automation;
using Sample.API.Runtime.PowerShell;

namespace Sample.API.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, @"LinqFirst")]
    [Alias("LinqFirst")]
    [OutputType(typeof(PSObject))]
    [Description(@"Returns the first element of a sequence.")]
    public class InvokeLinqFirst : LinqCmdlet
    {
        [Parameter(Position = 0, HelpMessage = "A script to test each element for a condition.")]
        [ValidateNotNull]
        public ScriptBlock Predicate { get; set; }

        protected override void EndProcessing()
        {
            base.EndProcessing();

            var result = this.IsParameterBound(c => c.Predicate)
                ? DeferredEnumerable.Collection.FirstOrDefault(e => (Predicate.InvokeReturnAsIs(e) as PSObject)?.ImmediateBaseObject as bool? ?? false)
                : DeferredEnumerable.Collection.FirstOrDefault();

            WriteObject(result);
        }
    }
}