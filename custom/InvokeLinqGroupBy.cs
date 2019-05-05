using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Sample.API.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, @"LinqGroupBy")]
    [Alias("LinqGroupBy")]
    [OutputType(typeof(PSDeferredEnumerable))]
    [Description(@"Groups the elements of a sequence.")]
    public class InvokeLinqGroupBy : LinqCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "A script to test each element for a condition.")]
        [ValidateNotNull]
        public ScriptBlock KeySelector { get; set; }

        protected override void EndProcessing()
        {
            base.EndProcessing();

            DeferredEnumerable.Collection = DeferredEnumerable.Collection
                .GroupBy(e => (KeySelector.InvokeReturnAsIs(e) as PSObject)?.ImmediateBaseObject)
                .Select(g => new PSObject(new KeyValuePair<object, IEnumerable<PSObject>>(g.Key, g)));

            WriteObject(DeferredEnumerable);
        }
    }
}