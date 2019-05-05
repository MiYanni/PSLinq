namespace Sample.API.Models
{
    using static Sample.API.Runtime.Extensions;
    public partial class Comic
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        partial void AfterFromJson(Sample.API.Runtime.Json.JsonObject json);
        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Sample.API.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        partial void AfterToJson(ref Sample.API.Runtime.Json.JsonObject container);
        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>
        partial void BeforeFromJson(Sample.API.Runtime.Json.JsonObject json, ref bool returnNow);
        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>
        partial void BeforeToJson(ref Sample.API.Runtime.Json.JsonObject container, ref bool returnNow);
        /// <summary>
        /// Deserializes a Sample.API.Runtime.Json.JsonObject into a new instance of <see cref="Comic" />.
        /// </summary>
        /// <param name="json">A Sample.API.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Comic(Sample.API.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_alt = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("alt"), out var __jsonAlt) ? (string)__jsonAlt : (string)Alt;}
            {_day = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("day"), out var __jsonDay) ? (string)__jsonDay : (string)Day;}
            {_img = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("img"), out var __jsonImg) ? (string)__jsonImg : (string)Img;}
            {_link = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("link"), out var __jsonLink) ? (string)__jsonLink : (string)Link;}
            {_month = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("month"), out var __jsonMonth) ? (string)__jsonMonth : (string)Month;}
            {_news = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("news"), out var __jsonNews) ? (string)__jsonNews : (string)News;}
            {_num = If( json?.PropertyT<Sample.API.Runtime.Json.JsonNumber>("num"), out var __jsonNum) ? (float?)__jsonNum : Num;}
            {_safeTitle = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("safe_title"), out var __jsonSafeTitle) ? (string)__jsonSafeTitle : (string)SafeTitle;}
            {_title = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("title"), out var __jsonTitle) ? (string)__jsonTitle : (string)Title;}
            {_transcript = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("transcript"), out var __jsonTranscript) ? (string)__jsonTranscript : (string)Transcript;}
            {_year = If( json?.PropertyT<Sample.API.Runtime.Json.JsonString>("year"), out var __jsonYear) ? (string)__jsonYear : (string)Year;}
            AfterFromJson(json);
        }
        /// <summary>
        /// Deserializes a <see cref="Sample.API.Runtime.Json.JsonNode"/> into an instance of Sample.API.Models.IComic.
        /// </summary>
        /// <param name="node">a <see cref="Sample.API.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Sample.API.Models.IComic.</returns>
        public static Sample.API.Models.IComic FromJson(Sample.API.Runtime.Json.JsonNode node)
        {
            return node is Sample.API.Runtime.Json.JsonObject json ? new Comic(json) : null;
        }
        /// <summary>
        /// Serializes this instance of <see cref="Comic" /> into a <see cref="Sample.API.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Sample.API.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Sample.API.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Comic" /> as a <see cref="Sample.API.Runtime.Json.JsonNode" />.
        /// </returns>
        public Sample.API.Runtime.Json.JsonNode ToJson(Sample.API.Runtime.Json.JsonObject container, Sample.API.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Sample.API.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)Alt)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Alt.ToString()) : null, "alt" ,container.Add );
            AddIf( null != (((object)Day)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Day.ToString()) : null, "day" ,container.Add );
            AddIf( null != (((object)Img)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Img.ToString()) : null, "img" ,container.Add );
            AddIf( null != (((object)Link)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Link.ToString()) : null, "link" ,container.Add );
            AddIf( null != (((object)Month)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Month.ToString()) : null, "month" ,container.Add );
            AddIf( null != (((object)News)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(News.ToString()) : null, "news" ,container.Add );
            AddIf( null != Num ? (Sample.API.Runtime.Json.JsonNode)new Sample.API.Runtime.Json.JsonNumber((float)Num) : null, "num" ,container.Add );
            AddIf( null != (((object)SafeTitle)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(SafeTitle.ToString()) : null, "safe_title" ,container.Add );
            AddIf( null != (((object)Title)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Title.ToString()) : null, "title" ,container.Add );
            AddIf( null != (((object)Transcript)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Transcript.ToString()) : null, "transcript" ,container.Add );
            AddIf( null != (((object)Year)?.ToString()) ? (Sample.API.Runtime.Json.JsonNode) new Sample.API.Runtime.Json.JsonString(Year.ToString()) : null, "year" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}