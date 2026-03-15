using MareSynchronos.API.Data;
using MessagePack;

namespace MareSynchronos.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record AccountInfoDto
{
    public List<UserData> AccountUids {get; set;} = new();
    public List<GroupData> AccountGroups {get; set;} = new();
}