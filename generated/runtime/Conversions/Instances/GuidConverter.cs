﻿using System;

namespace Sample.API.Runtime.Json
{
    public sealed class GuidConverter : JsonConverter<Guid>
    {
        internal override JsonNode ToJson(Guid value) => new JsonString(value.ToString());

        internal override Guid FromJson(JsonNode node) => (Guid)node;
    }
}