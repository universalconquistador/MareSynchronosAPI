
namespace MareSynchronos.API.Data.AdditionalTypes;

public record LifestreamParseableAddress((string Name, int World, int City, int Ward, int PropertyType, int Plot, int Apartment, bool ApartmentSubdivision, bool AliasEnabled, string Alias) AddressBookEntry);