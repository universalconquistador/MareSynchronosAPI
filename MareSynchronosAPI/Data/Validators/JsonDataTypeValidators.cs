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
        if (string.IsNullOrWhiteSpace(payload.World))
            return false;

        if (!GameData.Worlds.Contains(payload.World))
            return false;

        bool hasDistrict = !string.IsNullOrWhiteSpace(payload.District);
        bool hasWard = !string.IsNullOrWhiteSpace(payload.Ward);
        bool hasPlot = !string.IsNullOrWhiteSpace(payload.Plot);

        if ((hasDistrict || hasWard || hasPlot) && !(hasDistrict && hasWard && hasPlot))
            return false;

        if (hasDistrict)
            if (!GameData.HousingDistricts.Contains(payload.District!))
                return false;

        if (hasWard)
        {
            if (!int.TryParse(payload.Ward, out int wardNumber))
                return false;

            if (wardNumber < 1 || wardNumber > 30)
                return false;
        }

        if (hasPlot)
        {
            if (!int.TryParse(payload.Plot, out int plotNumber))
                return false;

            if (plotNumber < 1 || plotNumber > 60)
                return false;
        }

        return true;
    }
}