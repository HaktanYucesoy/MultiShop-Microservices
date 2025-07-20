namespace MultiShop.Identity.Application.Common.Regexs
{
    public static class UserPropertyRegexs
    {
        public const string UserNameContainRegex= "^[a-zA-Z0-9_]+$";
        public const string PasswordContainRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)";
        public const string FirstNameContainRegex = "^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$";
        public const string LastNameContainRegex = "^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$";


    }
}
