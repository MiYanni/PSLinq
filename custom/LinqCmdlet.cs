using System.Collections.Generic;
using System.Management.Automation;

namespace Sample.API.Cmdlets
{
    public abstract class LinqCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The collection to process.")]
        [ValidateNotNull]
        public PSObject InputObject { get; set; }

        protected PSDeferredEnumerable DeferredEnumerable;

        private readonly List<PSObject> _elementsList = new List<PSObject>();

        protected override void ProcessRecord()
        {
            _elementsList.Add(InputObject);
        }

        protected override void EndProcessing()
        {
            DeferredEnumerable = _elementsList.AsPSDeferredEnumerable();
        }
    }
}