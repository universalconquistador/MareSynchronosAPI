using MessagePack;

namespace MareSynchronos.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record SystemInfoDto
{
    public int OnlineUsers { get; set; }
    public Version? ClientAssemblyVersion { get; set; } = new(0, 0, 0, 0);
}