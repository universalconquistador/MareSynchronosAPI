using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MareSynchronos.API.Data.Enum;
using MessagePack;

namespace MareSynchronos.API.Dto.Stage;

[MessagePackObject(keyAsPropertyName: true)]
public class StageCustomizeDto
{
    public StageVisibility Visibility { get; set; } = StageVisibility.AllPairs;
    public string DisplayName { get; set; } = "";
    public string Version { get; set; } = "";
    public string Author { get; set; } = "";
    public string Description { get; set; } = "";
}
