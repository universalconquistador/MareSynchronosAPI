using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MareSynchronos.API.Data.Enum;
using MessagePack;

namespace MareSynchronos.API.Dto.Stage;

[MessagePackObject(keyAsPropertyName: true)]
public class StageFullInfoDto
{
    public string SID => Info.SID;
    public StageSubscriptionFlags SubscriptionState { get; set; } = StageSubscriptionFlags.None;

    public StageInfoDto Info { get; set; }
    public StageContentsDto Contents { get; set; }
    public StageCustomizeDto Customize { get; set; }
    public StageStateDto State { get; set; }
}
