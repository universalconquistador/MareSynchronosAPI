using MareSynchronos.API.Data.Enum;
using MessagePack;

namespace MareSynchronos.API.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record JsonDataTypeDto(UserData UserData, JsonDataType JsonDataType, string JsonData);

[MessagePackObject(keyAsPropertyName: true)]
public record JsonDataResponseDto(bool WasSuccessful, string? ResponseMessage = null);