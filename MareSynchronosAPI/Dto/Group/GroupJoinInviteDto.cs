using MareSynchronos.API.Data;
using MessagePack;

namespace MareSynchronos.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupJoinInviteDto(string RequestId, GroupData Group, UserData? InvitingUser)
{
    public GroupData Group { get; set; } = Group;
    public string GID => Group.GID;
    public string? GroupAlias => Group.Alias;
    public string GroupAliasOrGID => Group.AliasOrGID;
}

[MessagePackObject(keyAsPropertyName: true)]
public record GroupJoinInvitesDto(List<GroupJoinInviteDto> GroupJoinInvites);