using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace MareSynchronos.API.Dto.Stage;

[MessagePackObject(keyAsPropertyName: true)]
public class StageStateDto
{
    // Location
    public int LocationWorldId { get; set; } = 0;
    public int LocationTerritoryId { get; set; } = 0;
    public int LocationWardId { get; set; } = 0;
    public int LocationDivisionId { get; set; } = 0;
    public int LocationHouseId { get; set; } = 0;
    public int LocationRoomId { get; set; } = 0;

    // Transform
    public Vector3 Translation { get; set; } = Vector3.Zero;
    public Vector4 Rotation { get; set; } = Quaternion.Identity.AsVector4();
    public float UniformScale { get; set; } = 1.0f;
}
