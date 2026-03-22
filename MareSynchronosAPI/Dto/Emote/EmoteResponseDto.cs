using MareSynchronos.API.Data;
using MessagePack;

namespace MareSynchronos.API.Dto.Emote;

[MessagePackObject(keyAsPropertyName: true)]
public record EmoteResponseDto
{
    public required UserData EmoteLeadUser { get; init; }
    public required Dictionary<string, bool> EmoteGroupMembers { get; init; }
}