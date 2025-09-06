using System;

namespace MareSynchronos.API.Dto.Pairing;

// Client -> Server request to pair with target
public sealed record PairRequestStartDto(string TargetUid);

// Server -> Client (recipient) send request to target
public sealed record PairRequestDto(Guid RequestId, string RequesterUid, string RequesterAlias, string TargetUid, DateTime ExpiresAtUtc);

// Client -> Server accept the request
public sealed record PairRequestResponseDto(Guid RequestId, bool Accepted);
