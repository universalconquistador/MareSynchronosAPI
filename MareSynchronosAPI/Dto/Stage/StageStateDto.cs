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
    public uint LocationWorldId { get; set; } = 0;
    public uint LocationTerritoryId { get; set; } = 0;
    public uint LocationWardId { get; set; } = 0;
    public uint LocationDivisionId { get; set; } = 0;
    public uint LocationHouseId { get; set; } = 0;
    public uint LocationRoomId { get; set; } = 0;

    // Transform
    public Vector3 Translation { get; set; } = Vector3.Zero;
    public Vector4 Rotation { get; set; } = Quaternion.Identity.AsVector4();
    public float UniformScale { get; set; } = 1.0f;
}
