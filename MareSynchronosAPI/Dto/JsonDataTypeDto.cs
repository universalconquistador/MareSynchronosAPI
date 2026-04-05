using MareSynchronos.API.Data;
using MareSynchronos.API.Data.Enum;
using MessagePack;

namespace MareSynchronos.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record JsonDataTypeDto(UserData UserData, JsonDataType JsonDataType, string JsonData);

[MessagePackObject(keyAsPropertyName: true)]
public record JsonDataResponseDto(bool WasSuccessful, string? ResponseMessage = null);