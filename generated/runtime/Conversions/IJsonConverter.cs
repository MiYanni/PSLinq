namespace Sample.API.Runtime.Json
{
    internal interface IJsonConverter
    {
        JsonNode ToJson(object value);

        object FromJson(JsonNode node);
    }
}