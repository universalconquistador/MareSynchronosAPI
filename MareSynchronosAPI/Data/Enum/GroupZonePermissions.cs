namespace MareSynchronos.API.Data.Enum;

[Flags]
public enum GroupZonePermissions
{
    NoneSet = 0x0,
    PreferDisableAnimations = 0x1,
    PreferDisableSounds = 0x2,
    PreferDisableVFX = 0x4,
}