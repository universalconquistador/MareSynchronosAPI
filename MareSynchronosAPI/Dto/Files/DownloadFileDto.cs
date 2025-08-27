using MessagePack;

namespace MareSynchronos.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record DownloadFileDto : ITransferFileDto
{
    public bool FileExists { get; set; } = true;
    public string Hash { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// A URL where this file can be directly downloaded from in compressed form.
    /// </summary>
    /// <remarks>
    /// Null or empty means that this file is not available for direct download and
    /// must be accessed through the legacy block file download mechanism.
    /// </remarks>
    public string? DirectDownloadUrl { get; set; } = null;

    public long Size { get; set; } = 0;
    public bool IsForbidden { get; set; } = false;
    public string ForbiddenBy { get; set; } = string.Empty;
    public long RawSize { get; set; } = 0;
}