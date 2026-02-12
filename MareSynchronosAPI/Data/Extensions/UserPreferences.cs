using MareSynchronos.API.Data.Enum;

namespace MareSynchronos.API.Data.Extensions
{
    public static class UserPreferencesExtensions
    {
        public static bool IsEnablePairInvites(this UserPreferences perm)
        {
            return perm.HasFlag(UserPreferences.EnablePairInvites);
        }

        public static void SetEnablePairInvites(this ref UserPreferences perm, bool set)
        {
            if (set) perm |= UserPreferences.EnablePairInvites;
            else perm &= ~UserPreferences.EnablePairInvites;
        }
    }
}
