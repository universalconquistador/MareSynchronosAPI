using MareSynchronos.API.Data.AdditionalTypes;
using MareSynchronos.API.Data.Enum;
using System.Text.Json;

namespace MareSynchronos.API.Data.Validators;

public static class JsonDataTypeValidators
{
    private delegate bool JsonPayloadValidator(object payload);

    private sealed record JsonPayloadDefinition(Type PayloadType, JsonPayloadValidator Validator);

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static readonly IReadOnlyDictionary<JsonDataType, JsonPayloadDefinition> PayloadDefinitions = new Dictionary<JsonDataType, JsonPayloadDefinition>
    {
        [JsonDataType.LifestreamLocationInvite] = CreateDefinition<LifestreamParseableAddress>(ValidateLifestreamLocationInvite)
    };

    private static JsonPayloadDefinition CreateDefinition<TPayload>(Func<TPayload, bool> validator) where TPayload : class
    {
        return new JsonPayloadDefinition(typeof(TPayload), payload => validator((TPayload)payload));
    }

    public static bool TryValidate(JsonDataType dataType, string jsonData, out object? validatedPayload)
    {
        validatedPayload = null;

        if (string.IsNullOrWhiteSpace(jsonData))
            return false;

        if (!PayloadDefinitions.TryGetValue(dataType, out JsonPayloadDefinition? payloadDefinition))
            return false;

        try
        {
            object? deserializedPayload = JsonSerializer.Deserialize(jsonData, payloadDefinition.PayloadType, JsonSerializerOptions);
            if (deserializedPayload == null)
                return false;

            if (!payloadDefinition.Validator(deserializedPayload))
                return false;

            validatedPayload = deserializedPayload;
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    public static bool TryValidate<TPayload>(JsonDataType dataType, string jsonData, out TPayload? validatedPayload) where TPayload : class
    {
        validatedPayload = null;

        if (!TryValidate(dataType, jsonData, out object? deserializedPayload))
            return false;

        validatedPayload = deserializedPayload as TPayload;
        return validatedPayload != null;
    }

    private static bool ValidateLifestreamLocationInvite(LifestreamParseableAddress payload)
    {
        var addressBookEntry = payload.AddressBookEntry;

        if (addressBookEntry.Name == null) return false;
        if (addressBookEntry.Ward < 1 || addressBookEntry.Ward > 30) return false;
        if (addressBookEntry.Plot < 1 || addressBookEntry.Plot > 60) return false;
        if (addressBookEntry.Apartment < 1) return false;

        return true;
    }
}