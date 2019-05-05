namespace Sample.API
{
    using static Sample.API.Runtime.Extensions;
    /// <summary>A class that contains the module-common code and data.</summary>
    public partial class Module
    {
        /// <summary>FIXME: Field _handler is MISSING DESCRIPTION</summary>
         public global::System.Net.Http.HttpClientHandler _handler = new global::System.Net.Http.HttpClientHandler();
        /// <summary>the ISendAsync pipeline instance</summary>
         private Sample.API.Runtime.HttpPipeline _pipeline;
        /// <summary>the ISendAsync pipeline instance (when proxy is enabled)</summary>
         private Sample.API.Runtime.HttpPipeline _pipelineWithProxy;
        /// <summary>FIXME: Field _webProxy is MISSING DESCRIPTION</summary>
         public global::System.Net.WebProxy _webProxy = new global::System.Net.WebProxy();
        /// <summary>The instance of the Client API</summary>
        public Sample.API.Xkcd ClientAPI { get; set; }
        /// <summary>Backing field for <see cref="Instance" /> property.</summary>
        private static Sample.API.Module _instance;

        /// <summary>the singleton of this module class</summary>
        public static Sample.API.Module Instance => Sample.API.Module._instance?? (Sample.API.Module._instance = new Sample.API.Module());
        /// <summary>The Name of this module</summary>
        public string Name => @"Xkcd";
        /// <summary>FIXME: Method AfterCreatePipeline is MISSING DESCRIPTION</summary>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="pipeline">The HttpPipeline for the request</param>
        partial void AfterCreatePipeline(System.Management.Automation.InvocationInfo invocationInfo, ref Sample.API.Runtime.HttpPipeline pipeline);
        /// <summary>FIXME: Method BeforeCreatePipeline is MISSING DESCRIPTION</summary>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="pipeline">The HttpPipeline for the request</param>
        partial void BeforeCreatePipeline(System.Management.Automation.InvocationInfo invocationInfo, ref Sample.API.Runtime.HttpPipeline pipeline);
        /// <summary>FIXME: Method CustomInit is MISSING DESCRIPTION</summary>

        partial void CustomInit();
        /// <summary>Creates an instance of the HttpPipeline for each call.</summary>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <returns>An instance of Sample.API.Runtime.HttpPipeline for the remote call.</returns>
        public Sample.API.Runtime.HttpPipeline CreatePipeline(System.Management.Automation.InvocationInfo invocationInfo)
        {
            Sample.API.Runtime.HttpPipeline pipeline = null;
            BeforeCreatePipeline(invocationInfo, ref pipeline);
            pipeline = (pipeline ?? (_handler.UseProxy ? _pipelineWithProxy : _pipeline)).Clone();
            AfterCreatePipeline(invocationInfo, ref pipeline);
            return pipeline;
        }
        /// <summary>Initialization steps performed after the module is loaded.</summary>

        public void Init()
        {
            // called at module init time...
            CustomInit();
        }
        /// <summary>Creates the module instance.</summary>
        private Module()
        {
            /// constructor
            ClientAPI = new Sample.API.Xkcd();
            _handler.Proxy = _webProxy;
            _pipeline = new Sample.API.Runtime.HttpPipeline(new Sample.API.Runtime.HttpClientFactory(new global::System.Net.Http.HttpClient()));
            _pipelineWithProxy = new Sample.API.Runtime.HttpPipeline(new Sample.API.Runtime.HttpClientFactory(new global::System.Net.Http.HttpClient(_handler)));
        }
        /// <summary>FIXME: Method SetProxyConfiguration is MISSING DESCRIPTION</summary>
        /// <param name="proxy">The HTTP Proxy to use.</param>
        /// <param name="proxyCredential">The HTTP Proxy Credentials</param>
        /// <param name="proxyUseDefaultCredentials">True if the proxy should use default credentials</param>
        public void SetProxyConfiguration(global::System.Uri proxy, System.Management.Automation.PSCredential proxyCredential, bool proxyUseDefaultCredentials)
        {
            // set the proxy configuration
            _webProxy.Address = proxy;
            _webProxy.BypassProxyOnLocal = false;
            _webProxy.Credentials = proxyCredential ?.GetNetworkCredential();
            _webProxy.UseDefaultCredentials = proxyUseDefaultCredentials;
            _handler.UseProxy = proxy != null;
        }
    }
}