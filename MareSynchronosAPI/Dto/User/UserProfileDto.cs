using MareSynchronos.API.Data;
using MessagePack;
using System.Numerics;
using System.Text.Json.Serialization;

namespace MareSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileDto(UserData User, bool Disabled, bool? IsNSFW, string? ProfilePictureBase64, string? Description) : UserDto(User);

public sealed class ProfileV1
{
    public int Version { get; set; } = 1;
    public bool IsSupporter { get; set; } = false;
    public bool EnableSupporterElements { get; set; } = false;
    public string PreferredName { get; set; } = string.Empty;
    public string Pronouns { get; set; } = string.Empty;
    public ProfileStatus Status { get; set; } = ProfileStatus.NotShared;
    public List<string> Interests { get; set; } = new();
    public string AboutMe { get; set; } = string.Empty;
    public ProfileTheme Theme { get; set; } = new();
    public List<ProfileBadge> Badges { get; set; } = new();
}

public sealed class ProfileBadge
{
    public string Id { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Tooltip { get; set; } = string.Empty;
}

public enum ProfileStatus
{
    NotShared,
    NotInterested,
    Taken,
    Open,
    Looking,
    ItsComplicated,
    AskMe,
}

public sealed class ProfileTheme
{
    public float[] Primary { get; set; } = [0.04f, 0.18f, 0.24f, 0.92f];
    public float[] Secondary { get; set; } = [0.23f, 0.34f, 0.40f, 0.92f];
    public float[] Accent { get; set; } = [0.298f, 0.5608f, 0.647f, 0.92f];
    public float[] TextPrimary { get; set; } = [0.95f, 0.98f, 1.00f, 1f];

    [JsonIgnore]
    public Vector4 PrimaryV4
    {
        get => new(Primary[0], Primary[1], Primary[2], Primary[3]);
    }

    [JsonIgnore]
    public Vector4 SecondaryV4
    {
        get => new(Secondary[0], Secondary[1], Secondary[2], Secondary[3]);
    }

    [JsonIgnore]
    public Vector4 AccentV4
    {
        get => new(Accent[0], Accent[1], Accent[2], Accent[3]);
    }

    [JsonIgnore]
    public Vector4 TextPrimaryV4
    {
        get => new(TextPrimary[0], TextPrimary[1], TextPrimary[2], TextPrimary[3]);
    }
}