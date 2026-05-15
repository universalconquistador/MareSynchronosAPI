using MareSynchronos.API.Data;
using MareSynchronos.API.Data.Enum;
using MessagePack;

namespace MareSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaDataDto(UserData User, CharacterData CharaData, AddonPlugin? AddonPlugin = null) : UserDto(User);