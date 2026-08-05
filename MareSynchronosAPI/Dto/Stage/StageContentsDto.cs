using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace MareSynchronos.API.Dto.Stage;

[MessagePackObject(keyAsPropertyName: true)]
public class StageContentsDto
{
    public DateTimeOffset RevisionDateUtc { get; set; } = DateTimeOffset.MinValue;
    public int Revision { get; set; } = 0;
    public string RevisionAuthorUid { get; set; } = "";
    public string StageFileHash { get; set; } = "";
    public List<StageModUsageDto> Mods { get; set; } = new();
}

[MessagePackObject(keyAsPropertyName: true)]
public class StageModUsageDto
{
    public string ModpackId { get; set; } = "";
    public string Hash { get; set; } = "";
}
