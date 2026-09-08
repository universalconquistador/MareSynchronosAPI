using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MareSynchronos.API.Data.Enum;

[Flags]
public enum StageSubscriptionFlags : int
{
    /// <summary>
    /// The user is not subscribed to the Stage in any way.
    /// </summary>
    None = 0,
    /// <summary>
    /// The user is directly subscribed to the Stage.
    /// </summary>
    DirectlySubscribed = (1 << 0),
    /// <summary>
    /// The user is subscribed to the Stage by being subscribed to the owning user or group.
    /// </summary>
    OwnerFeedSubscribed = (1 << 1),
}
