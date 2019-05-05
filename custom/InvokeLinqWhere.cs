using System.Linq;
using System.Management.Automation;

namespace Sample.API.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, @"LinqWhere")]
    [Alias("LinqWhere")]
    [OutputType(typeof(PSDeferredEnumerable))]
    [Description(@"Filters a sequence of values based on a predicate.")]
    public class InvokeLinqWhere : LinqCmdlet
    {
        //[Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The collection to filter.")]
        //[ValidateNotNull]
        //public object[] Collection
        //{
        //    get => _elementsList.ToArray();
        //    set
        //    {
        //        WriteObject($"Call: {_counter++}");
        //        WriteObject(value.GetType());
        //        WriteObject($"Count: {value.Length}");
        //        //if (!_isSet && value is object[])
        //        //{
        //        //    _elements = value.Cast<object>();
        //        //    _isSet = true;
        //        //}
        //        //_elementsList.Add(value);
        //    }
        //}

        //private bool _isSet = false;
        //private IEnumerable<object> _elements = new List<object>();
        //private List<object> _elementsList = new List<object>();

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "A script to test each element for a condition.")]
        [ValidateNotNull]
        public ScriptBlock Predicate { get; set; }

        //private int _counter = 0;

        //[Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        //[ValidateNotNull]
        //[Category(ParameterCategory.Runtime)]
        //public Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        //[Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        //[ValidateNotNull]
        //[Category(ParameterCategory.Runtime)]
        //public Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        //[Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        //[Category(ParameterCategory.Runtime)]
        //public System.Uri Proxy { get; set; }

        //[Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        //[ValidateNotNull]
        //[Category(ParameterCategory.Runtime)]
        //public PSCredential ProxyCredential { get; set; }

        //[Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        //[Category(ParameterCategory.Runtime)]
        //public SwitchParameter ProxyUseDefaultCredentials { get; set; }

        //protected override void BeginProcessing()
        //{
        //    //var elements = InvokeCommand.InvokeScript(Predicate.ToString());
        //    //var elements = Collection.OfType<PSObject>().Where((e, i) => InvokeCommand.InvokeScript($"$_ = {e}; $_1 = {i}; {Predicate.ToString()}", e).OfType<bool>().First());
        //    //WriteObject(elements, true);
        //    //WriteObject(Collection == null);
        //}

        //protected override void ProcessRecord()
        //{
        //    //base.ProcessRecord();
        //    ////WriteObject(Predicate.InvokeReturnAsIs());
        //    //Predicate.InvokeReturnAsIs(ElementsList.Last());

        //    var collection = Collection.OfType<object>().ToArray();
        //    var element = collection.Last();
        //    var chars = collection.OfType<char>().ToArray();
        //    if (chars.Any())
        //    {
        //        element = new string(chars);
        //    }

        //    //var script = InvokeCommand.NewScriptBlock($"$_ = {element}; {Predicate.ToString()}");
        //    //WriteObject(script.InvokeReturnAsIs());
        //    WriteObject(Predicate.InvokeReturnAsIs(element));

        //    //WriteObject(InvokeCommand.InvokeScript($"$_ = {ElementsList.Last()}; {Predicate.ToString()}"), true);
        //    //WriteObject(InvokeCommand.InvokeScript($"$_ = {ElementsList.Last()}; {Predicate.ToString()}").LastOrDefault()?.ImmediateBaseObject as bool? ?? false);
        //}

        protected override void EndProcessing()
        {
            base.EndProcessing();

            //DeferredEnumerable.Collection = DeferredEnumerable.Collection.Where((e, i) =>
            //{
            //    var value = Predicate.InvokeReturnAsIs(e) as PSObject;
            //    return value?.ImmediateBaseObject as bool? ?? false;
            //});

            DeferredEnumerable.Collection = DeferredEnumerable.Collection.Where((e, i) => 
                (Predicate.InvokeReturnAsIs(e) as PSObject)?.ImmediateBaseObject as bool? ?? false);

            WriteObject(DeferredEnumerable);


            //WriteObject(ElementsList.Where((e, i) =>
            //{
            //    var value = Predicate.InvokeReturnAsIs(e) as PSObject;
            //    //return value.GetType() == typeof(bool) ? (bool)value : false;
            //    //return ((PSObject)value).ImmediateBaseObject.GetType();
            //    return value?.ImmediateBaseObject as bool? ?? false;
            //}), true);

            //WriteObject(ElementsList.Select((e, i) => Predicate.InvokeReturnAsIs(e)), true);
            //base.EndProcessing();


            //var elements = InvokeCommand.InvokeScript($"{_counter++}");
            //var elements = Collection.OfType<PSObject>().Where((e, i) => InvokeCommand.InvokeScript($"$_ = {e}; $_1 = {i}; {Predicate.ToString()}", e).OfType<bool>().First());
            //var elements = InvokeCommand.InvokeScript(Predicate.ToString());
            //WriteObject(elements, true);
            //WriteObject(Collection == null);
            //var elements = Collection.OfType<PSObject>().Where((e, i) => InvokeCommand.InvokeScript($"$_ = {e}; $_1 = {i}; {Predicate.ToString()}", e).OfType<bool>().First());
            //WriteObject(Collection, true);
            //WriteObject(_elements.ToArray().Length, true);
            //WriteObject(_elementsList.Count, true);

            //var elements = _elementsList
            //    .Where((e, i) => InvokeCommand.InvokeScript($"$_ = {e}; $_1 = {i}; {Predicate.ToString()}")
            //    .Select(po => po.BaseObject).OfType<bool>().LastOrDefault());

            //WriteObject(_elements);
            //var deferredEnumerable = ElementsList.AsPSDeferredEnumerable();


            //DeferredEnumerable.Collection = DeferredEnumerable.Collection.Where((e, i) =>
            //{
            //    var value = Predicate.InvokeReturnAsIs(e);
            //    return value.GetType() == typeof(bool) ? (bool)value : false;
            //});
            //WriteObject(DeferredEnumerable);


            //DeferredEnumerable.Collection = DeferredEnumerable.Collection.ToArray();
            //WriteObject(DeferredEnumerable.Collection as IList<object> != null);
        }

        //protected override void ProcessRecord()
        //{
        //    //var enumerator = Collection.GetEnumerator();
        //    //enumerator.MoveNext();
        //    //_elementsList.Add(enumerator.Current);



        //    //_elements = _elements.Append(enumerator.Current);
        //    //WriteObject(enumerator.Current);
        //    //WriteObject(InvokeCommand.InvokeScript($"$_ = {enumerator.Current}; {Predicate.ToString()}").Select(po => po.BaseObject).OfType<bool>().FirstOrDefault(), true);

        //    //WriteObject(_elements.Count, true);
        //    //_elements.Add(1);
        //    //_elements.Append(1);
        //    //WriteObject(Collection, true);
        //    //var enumerator = Collection.GetEnumerator();
        //    //enumerator.MoveNext();
        //    //_elements.Append(enumerator.Current);

        //    //var enumerator = Collection.GetEnumerator();
        //    //enumerator.MoveNext();
        //    //_elements.Add(enumerator.Current);

        //    //_elements.Append(Collection.Cast<object>().Single());
        //    //WriteObject(Collection.Cast<object>().Count(), true);

        //    //var elements = Predicate.Invoke(Collection);
        //    //var elements = Collection.Where((e, i) => InvokeCommand.InvokeScript(Predicate.ToString(), e).OfType<bool>().First());

        //    //var elements = Collection.OfType<PSObject>().Where((e, i) => InvokeCommand.InvokeScript($"$_ = {e}; {Predicate.ToString()}", e).OfType<bool>().First());
        //    //var elements = Collection.OfType<PSObject>().Where((e, i) => InvokeCommand.InvokeScript($"$LinqElement = {e}; $LinqIndex = {i}; {Predicate.ToString()}", e).OfType<bool>().First());
        //    //var elements = InvokeCommand.InvokeScript(Predicate.ToString());
        //    //var elements = InvokeCommand.InvokeScript($"$_ = 2; {Predicate.ToString()}");
        //    //var elements = PsHelpers.RunScript<PSObject>($"$_ = 2; {Predicate.ToString()}");
        //    //var elements = InvokeCommand.InvokeScript($"{++_counter}");
        //    //WriteObject(elements, true);

        //    //((Runtime.IEventListener)this).Signal(Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        //    //try
        //    //{
        //    //    // work
        //    //    using( var asyncCommandRuntime = new Runtime.PowerShell.AsyncCommandRuntime(this, ((Runtime.IEventListener)this).Token) )
        //    //    {
        //    //        asyncCommandRuntime.Wait( ProcessRecordAsync(),((Runtime.IEventListener)this).Token);
        //    //    }
        //    //}
        //    //catch (System.AggregateException aggregateException)
        //    //{
        //    //    // unroll the inner exceptions to get the root cause
        //    //    foreach( var innerException in aggregateException.Flatten().InnerExceptions )
        //    //    {
        //    //        ((Runtime.IEventListener)this).Signal(Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        //    //        // Write exception out to error channel.
        //    //        WriteError( new ErrorRecord(innerException,string.Empty, ErrorCategory.NotSpecified, null) );
        //    //    }
        //    //}
        //    //catch (System.Exception exception) when ((exception as PipelineStoppedException) != null && (exception as PipelineStoppedException).InnerException == null)
        //    //{
        //    //    ((Runtime.IEventListener)this).Signal(Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        //    //    ThrowTerminatingError( new ErrorRecord(exception,string.Empty, ErrorCategory.NotSpecified, null) );
        //    //}
        //    //catch (System.Exception exception)
        //    //{
        //    //    ((Runtime.IEventListener)this).Signal(Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        //    //    // Write exception out to error channel.
        //    //    WriteError( new ErrorRecord(exception,string.Empty, ErrorCategory.NotSpecified, null) );
        //    //}
        //    //finally
        //    //{
        //    //    ((Runtime.IEventListener)this).Signal(Runtime.Events.CmdletProcessRecordEnd).Wait();
        //    //}
        //}
    }
}