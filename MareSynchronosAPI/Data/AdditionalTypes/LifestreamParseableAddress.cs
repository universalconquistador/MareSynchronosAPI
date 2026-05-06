
namespace MareSynchronos.API.Data.AdditionalTypes;

public record LifestreamParseableAddress(AddressBookEntryDto AddressBookEntry);

public record AddressBookEntryDto(
    string Name,
    int World,
    int City,
    int Ward,
    int PropertyType,
    int Plot,
    int Apartment,
    bool ApartmentSubdivision,
    bool AliasEnabled,
    string Alias
    );