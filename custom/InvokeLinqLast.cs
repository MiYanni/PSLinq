using System.Linq;
using System.Management.Automation;
using Sample.API.Runtime.PowerShell;

namespace Sample.API.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, @"LinqLast")]
    [Alias("LinqLast")]
    [OutputType(typeof(PSDeferredEnumerable))]
    [Description(@"Returns the last element of a sequence.")]
    public class InvokeLinqLast : LinqCmdlet
    {
        [Parameter(Position = 0, HelpMessage = "A script to test each element for a condition.")]
        [ValidateNotNull]
        public ScriptBlock Predicate { get; set; }

        protected override void EndProcessing()
        {
            base.EndProcessing();

            var result = this.IsParameterBound(c => c.Predicate)
                ? DeferredEnumerable.Collection.LastOrDefault(e => (Predicate.InvokeReturnAsIs(e) as PSObject)?.ImmediateBaseObject as bool? ?? false)
                : DeferredEnumerable.Collection.LastOrDefault();

            WriteObject(result);
        }
    }
}