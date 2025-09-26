using MareSynchronos.API.Data;
using MareSynchronos.API.Dto.CharaData;
using MessagePack;

namespace MareSynchronos.API.Dto.Group

{
    [MessagePackObject(keyAsPropertyName: true)]
    public record GroupZoneJoinDto(uint WorldId, LocationInfo LocationInfo);
}