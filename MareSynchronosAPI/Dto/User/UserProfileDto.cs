using MareSynchronos.API.Data;
using MessagePack;
using System.Runtime.Serialization;

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
    [EnumMember(Value = "Not Shared")]
    NotShared,

    [EnumMember(Value = "Not Interested")]
    NotInterested,

    [EnumMember(Value = "Taken")]
    Taken,

    [EnumMember(Value = "Open")]
    Open,

    [EnumMember(Value = "Looking")]
    Looking,

    [EnumMember(Value = "It's Complicated")]
    ItsComplicated,

    [EnumMember(Value = "Ask Me")]
    AskMe,
}

//public sealed class SocialIds
//{
//    public string? Discord { get; set; }
//    public string? TwitterX { get; set; }
//    public string? Bluesky { get; set; }
//    public string? Instagram { get; set; }
//    public string? Facebook { get; set; }
//    public string? Twitch { get; set; }
//}

public sealed class ProfileTheme
{
    public float[] Primary { get; set; } = [0.04f, 0.18f, 0.24f, 0.92f];     // #0A2D3C
    public float[] Secondary { get; set; } = [0.23f, 0.34f, 0.40f, 0.92f];   // #3A5666
    public float[] Accent { get; set; } = [0.29803923f, 0.56078434f, 0.64705884f, 0.92f];      // #62C6E8
    public float[] TextPrimary { get; set; } = [0.95f, 0.98f, 1.00f, 1f]; // #F2FBFF
}