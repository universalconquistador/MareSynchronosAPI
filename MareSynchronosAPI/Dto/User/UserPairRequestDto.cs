using MareSynchronos.API.Data;
using MessagePack;

namespace MareSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairRequestDto(string RequestTargetIdent);

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairRequestFullDto(UserData Requestor, string RequestorIdent, UserData RequestTarget, string RequestTargetIdent);

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairRequestsDto(List<UserPairRequestFullDto> PairingRequests);