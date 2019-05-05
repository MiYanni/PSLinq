using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sample.API.Runtime.PowerShell;

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