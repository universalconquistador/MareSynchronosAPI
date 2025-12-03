using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MareSynchronos.API.Dto.Files;

public class CompressionTaskDto
{
    public string Hash { get; set; } = string.Empty;
    public string FilenameExtension { get; set; } = string.Empty;
    public string DownloadUrl { get; set; } = string.Empty;
}
