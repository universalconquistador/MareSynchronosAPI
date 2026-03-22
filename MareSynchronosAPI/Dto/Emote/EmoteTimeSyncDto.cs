using MessagePack;

namespace MareSynchronos.API.Dto.Emote;

[MessagePackObject(keyAsPropertyName: true)]
public record ServerTimeRequestDto
{
    public Guid RequestId { get; init; }
    public long ClientSendUtcTicks { get; init; }
}

[MessagePackObject(keyAsPropertyName: true)]
public record ServerTimeResponseDto
{
    public Guid RequestId { get; init; }
    public long ClientSendUtcTicks { get; init; }
    public long ServerReceiveUtcTicks { get; init; }
    public long ServerSendUtcTicks { get; init; }
}

[MessagePackObject(keyAsPropertyName: true)]
public record ScheduledEmoteActionDto
{
    public Guid EventId { get; init; }
    public long ExecuteAtServerUtcTicks { get; init; }
}