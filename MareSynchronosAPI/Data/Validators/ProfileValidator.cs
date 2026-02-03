using MareSynchronos.API.Dto.User;

namespace MareSynchronos.API.Data.Validators
{
    public static class ProfileValidator
    {
        public const int MaxPronounsLen = 40;
        public const int MaxAboutMeLen = 200;
        public const int MaxSocialLen = 64;

        public static bool TryValidate(ProfileV1 doc, out List<string> errors)
        {
            errors = new List<string>();

            if (doc == null)
            {
                errors.Add("Profile is empty.");
                return false;
            }

            if (!string.IsNullOrEmpty(doc.Pronouns) && doc.Pronouns.Length > MaxPronounsLen)
                errors.Add($"Pronouns must be {MaxPronounsLen} characters or fewer.");

            if (!string.IsNullOrEmpty(doc.AboutMe) && doc.AboutMe.Length > MaxAboutMeLen)
                errors.Add($"About Me must be {MaxAboutMeLen} characters or fewer.");

            return errors.Count == 0;
        }
    }
}
