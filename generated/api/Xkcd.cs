namespace Sample.API
{
    using static Sample.API.Runtime.Extensions;
    /// <summary>
    /// Low-level API implementation for the XKCD service.
    /// </summary>
    public partial class Xkcd
    {

        /// <summary>
        /// Fetch comics and metadata by comic id.
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="eventListener">an <see cref="Sample.API.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Sample.API.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task XkcdGetComic(float comicId, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Sample.API.Models.IComic>, global::System.Threading.Tasks.Task> onOk, Sample.API.Runtime.IEventListener eventListener, Sample.API.Runtime.ISendAsync sender)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new global::System.Uri((
                        "http://xkcd.com/"
                        + (comicId.ToString())
                        + "/info.0.json"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Sample.API.Runtime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new global::System.Net.Http.HttpRequestMessage(Sample.API.Runtime.Method.Get, _url);
                await eventListener.Signal(Sample.API.Runtime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Sample.API.Runtime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.XkcdGetComic_Call(request,onOk,eventListener,sender);
            }
        }
        /// <summary>
        /// Fetch current comic and metadata.
        /// </summary>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="eventListener">an <see cref="Sample.API.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Sample.API.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task XkcdGetComicForToday(global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Sample.API.Models.IComic>, global::System.Threading.Tasks.Task> onOk, Sample.API.Runtime.IEventListener eventListener, Sample.API.Runtime.ISendAsync sender)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new global::System.Uri((
                        "http://xkcd.com/info.0.json"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Sample.API.Runtime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new global::System.Net.Http.HttpRequestMessage(Sample.API.Runtime.Method.Get, _url);
                await eventListener.Signal(Sample.API.Runtime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Sample.API.Runtime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.XkcdGetComicForToday_Call(request,onOk,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="XkcdGetComicForToday" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="eventListener">an <see cref="Sample.API.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Sample.API.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task XkcdGetComicForToday_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Sample.API.Models.IComic>, global::System.Threading.Tasks.Task> onOk, Sample.API.Runtime.IEventListener eventListener, Sample.API.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Sample.API.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Sample.API.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Sample.API.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Sample.API.Models.Comic.FromJson(Sample.API.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            throw new Sample.API.Runtime.UndeclaredResponseException(_response.StatusCode);
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Sample.API.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="XkcdGetComicForToday" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="eventListener">an <see cref="Sample.API.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task XkcdGetComicForToday_Validate(Sample.API.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
            }
        }
        /// <summary>Actual wire call for <see cref="XkcdGetComic" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="eventListener">an <see cref="Sample.API.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Sample.API.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task XkcdGetComic_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Sample.API.Models.IComic>, global::System.Threading.Tasks.Task> onOk, Sample.API.Runtime.IEventListener eventListener, Sample.API.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Sample.API.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Sample.API.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Sample.API.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Sample.API.Models.Comic.FromJson(Sample.API.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            throw new Sample.API.Runtime.UndeclaredResponseException(_response.StatusCode);
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Sample.API.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="XkcdGetComic" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="comicId"></param>
        /// <param name="eventListener">an <see cref="Sample.API.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task XkcdGetComic_Validate(float comicId, Sample.API.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
            }
        }
    }
}