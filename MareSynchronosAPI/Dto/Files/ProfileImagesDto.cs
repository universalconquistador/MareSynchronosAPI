using MessagePack;

namespace MareSynchronos.API.Dto.Files
{
    [MessagePackObject(keyAsPropertyName: true)]
    public record ProfileImagesDto
    {
        public string? ProfileProfileDownloadUrl { get; set; } = null;
        public string? ProfileBannerDownloadUrl { get; set; } = null;
        public string? ProfileBackgroundDownloadUrl { get; set; } = null;
    }
}
