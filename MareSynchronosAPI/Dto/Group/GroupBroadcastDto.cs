using MareSynchronos.API.Data;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MareSynchronos.API.Dto.Group;

/// <summary>
/// Information about a broadcast that was recieved by the player.
/// </summary>
/// <param name="Group">The group that was broadcast.</param>
/// <param name="Owner">The owner of the group.</param>
/// <param name="Broadcasters">The players who send broadcasts to the player about the group.</param>
/// <param name="CurrentMemberCount">The total number of online and offline members of this group.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record GroupBroadcastDto(GroupData Group, UserData Owner, List<UserData> Broadcasters, ulong CurrentMemberCount, bool Passwordless, bool GuestModeEnabled)
{
    public string GroupAliasOrGID => Group.AliasOrGID;
    public string OwnerAliasOrGID => Owner.AliasOrUID;
}
