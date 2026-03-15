
namespace MareSynchronos.API.Data.Validators
{
    public static class AliasValidator
    {
        public static bool IsValidAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias)) return false;
            foreach (char chara in alias)
                if (!(char.IsLetterOrDigit(chara) || chara == '_' || chara == '-'))
                    return false;
            return true;
        }
    }
}