using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MareSynchronos.API.Data.Enum;

/// <summary>
/// Which users are allowed to see and subscribe to a Stage.
/// </summary>
public enum StageVisibility : int
{
    /// <summary>
    /// The user (for user-owned Stages) or the owner and moderators of the group (for group-owned Stages)
    /// </summary>
    OwnersOnly,
    /// <summary>
    /// The user's direct pairs (for user-owned Stages) or all the members of the group (excluding guests) (for group-owned Stages)
    /// </summary>
    /// <remarks>
    /// Sync permissions and pause state do not impact whether a user-owned Stage is visible.
    /// </remarks>
    DirectPairs,
    /// <summary>
    /// The user's direct pairs and group pairs (excluding zone syncshells) (for user-owned Stages) or all the members of the group (including guests) (for group-owned Stages)
    /// </summary>
    /// <remarks>
    /// Sync permissions and pause state do not impact whether a user-owned Stage is visible.
    /// </remarks>
    AllPairs,
    /// <summary>
    /// Every user, even if they are not paired (for user-owned Stages) or members of the group (for group-owned Stages) in any way.
    /// </summary>
    /// <remarks>
    /// Sync permissions and pause state do not impact whether a user-owned Stage is visible.
    /// </remarks>
    Everyone,
}
