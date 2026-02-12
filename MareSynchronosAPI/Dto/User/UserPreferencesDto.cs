using MessagePack;

namespace MareSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPreferencesDto()
{
    public bool IsEnablePairRequests { get; init; }
}