﻿namespace Sample.API.Runtime.Json
{
    public sealed class Int16Converter : JsonConverter<short>
    {
        internal override JsonNode ToJson(short value) => new JsonNumber(value);

        internal override short FromJson(JsonNode node) => (short)node;
    }
}