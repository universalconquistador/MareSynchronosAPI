using MareSynchronos.API.Dto.CharaData;
using MessagePack;

namespace MareSynchronos.API.Dto.Group

{
    [MessagePackObject(keyAsPropertyName: true)]
    public record GroupZoneJoinDto(LocationInfo LocationInfo);
}