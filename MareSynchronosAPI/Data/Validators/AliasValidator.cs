
namespace MareSynchronos.API.Data.Validators
{
    public static class AliasValidator
    {
        public static bool IsValidAlias(string? alias)
        {
            if (string.IsNullOrWhiteSpace(alias)) return true;
            if (alias.Length < 5 || alias.Length > 15) return false;
            foreach (char chara in alias)
                if (!(char.IsLetterOrDigit(chara) || chara == '_' || chara == '-'))
                    return false;
            return true;
        }
    }
}