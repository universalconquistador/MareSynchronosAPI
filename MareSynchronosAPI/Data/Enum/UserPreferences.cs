namespace MareSynchronos.API.Data.Enum
{
    // these are hex based bits, so 0x0, 0x1, 0x2, 0x4, 0x8, 0x10, 0x20
    [Flags]
    public enum UserPreferences
    {
        None = 0x0,
        EnablePairInvites = 0x1,
    }
}
