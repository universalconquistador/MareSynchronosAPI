using MessagePack;

namespace MareSynchronos.API.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupData(string GID, string? Alias = null)
{
    [IgnoreMember]
    public string AliasOrGID => string.IsNullOrWhiteSpace(Alias) ? GID : Alias;
}

[MessagePackObject(keyAsPropertyName: true)]
public record GroupPublicData(GroupProfile? GroupProfile = null, bool KnownPasswordless = false, bool GuestModeEnabled = false, bool IsZoneSync = false);

[MessagePackObject(keyAsPropertyName: true)]
public record GroupProfile(string Rules = "", string Description = "");