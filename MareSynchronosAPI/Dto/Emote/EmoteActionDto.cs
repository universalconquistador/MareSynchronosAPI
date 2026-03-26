using MareSynchronos.API.Data;
using MareSynchronos.API.Data.Enum;
using MessagePack;

namespace MareSynchronos.API.Dto.Emote;

[MessagePackObject(keyAsPropertyName: true)]
public record EmoteActionDto
{
    public EmoteSyncAction EmoteSyncAction { get; init; }
    public List<UserData>? VisiblePartyMembers {  get; init; }
}