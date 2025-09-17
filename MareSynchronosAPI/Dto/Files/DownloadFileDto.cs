using MessagePack;

namespace MareSynchronos.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record DownloadFileDto : ITransferFileDto
{
    public bool FileExists { get; set; } = true;
    public string Hash { get; set; } = string.Empty;

    /// <summary>
    /// This used to be the URL of the file shard to get the file from.
    /// This has been removed, and now clients must use
    /// <see cref="DirectDownloadUrl"/> to download the file contents.
    /// </summary>
    [Obsolete]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// A URL where this file can be directly downloaded from in compressed form.
    /// </summary>
    /// <remarks>
    /// This should not be null or empty now that the legacy download system has been
    /// removed.
    /// </remarks>
    public string? DirectDownloadUrl { get; set; } = null;

    public long Size { get; set; } = 0;
    public bool IsForbidden { get; set; } = false;
    public string ForbiddenBy { get; set; } = string.Empty;
    public long RawSize { get; set; } = 0;
}