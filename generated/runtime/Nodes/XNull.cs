namespace Sample.API.Runtime.Json
{
    internal sealed class XNull : JsonNode
    {
        internal static readonly XNull Instance = new XNull();

        private XNull() { }

        internal override JsonType Type => JsonType.Null;
    }
}