﻿using System;

namespace Sample.API.Runtime.Json
{
    public sealed class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        internal override JsonNode ToJson(TimeSpan value) => new JsonString(value.ToString());

        internal override TimeSpan FromJson(JsonNode node) => (TimeSpan)node;
    }
}