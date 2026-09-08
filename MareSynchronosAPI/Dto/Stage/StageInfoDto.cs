using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace MareSynchronos.API.Dto.Stage;

[MessagePackObject(keyAsPropertyName: true)]
public class StageInfoDto
{
    public string SID { get; set; } = "";
    public string UserOwnerUID { get; set; } = "";
    public string GroupOwnerGID { get; set; } = "";
    public DateTimeOffset CreationDateUtc { get; set; } = DateTimeOffset.MinValue;
}
