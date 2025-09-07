using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MareSynchronos.API.Dto.Group;

/// <summary>
/// Information about a group that the player wants to broadcast.
/// </summary>
/// <param name="BroadcastGroupId">The group's ID (GID).</param>
[MessagePackObject(keyAsPropertyName: true)]
public record BroadcastSendDto(string BroadcastGroupId)
{

}
