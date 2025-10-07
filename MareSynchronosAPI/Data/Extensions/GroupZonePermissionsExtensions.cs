using MareSynchronos.API.Data.Enum;

namespace MareSynchronos.API.Data.Extensions;

public static class GroupZonePermissionsExtensions
{
    public static bool IsDisableSounds(this GroupZonePermissions perm)
    {
        return perm.HasFlag(GroupZonePermissions.PreferDisableSounds);
    }

    public static bool IsDisableVFX(this GroupZonePermissions perm)
    {
        return perm.HasFlag(GroupZonePermissions.PreferDisableVFX);
    }

    public static bool IsDisableAnimations(this GroupZonePermissions perm)
    {
        return perm.HasFlag(GroupZonePermissions.PreferDisableAnimations);
    }

    public static void SetDisableSounds(this ref GroupZonePermissions perm, bool set)
    {
        if (set) perm |= GroupZonePermissions.PreferDisableSounds;
        else perm &= ~GroupZonePermissions.PreferDisableSounds;
    }

    public static void SetDisableVFX(this ref GroupZonePermissions perm, bool set)
    {
        if (set) perm |= GroupZonePermissions.PreferDisableVFX;
        else perm &= ~GroupZonePermissions.PreferDisableVFX;
    }

    public static void SetDisableAnimations(this ref GroupZonePermissions perm, bool set)
    {
        if (set) perm |= GroupZonePermissions.PreferDisableAnimations;
        else perm &= ~GroupZonePermissions.PreferDisableAnimations;
    }
}