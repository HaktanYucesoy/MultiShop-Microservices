namespace MultiShop.Identity.Application.Common.Messages
{
    public static class UserMessages
    {
        public const string USERNAME_ALREADY_EXISTS = "Username is already taken";
        public const string USERNAME_CAN_NOT_EMPTY = "Username can not be empty";
        public const string USERNAME_IS_REQUIRED = "Username is required";
        public static string USERNAME_CHARACTER_LIMIT(int min, int max) => $"Username must be between {min} and {max} characters";

        public const string USERNAME_CAN_ONLY = "Username can only contain letters, numbers, and underscores";
        public const string USERNAME_LENGTH = "Username's length can not be less ";


        public const string EMAIL_CAN_NOT_EMPTY = "Email can not be empty";
        public const string EMAIL_ALREADY_EXISTS = "Email is already taken";
        public const string INVALID_EMAIL_FORMAT = "Invalid email format";
        public static string EMAIL_MAX_CHARACTER_LIMIT(int max) => $"Email  must not exceed {max} characters";

        public const string FIRST_NAME_CAN_NOT_EMPTY = "First name can not be empty";
        public const string LAST_NAME_CAN_NOT_EMPTY = "Last name can not be empty";       
        public const string FIRST_NAME_LENGTH = "First name's length can not be less";
        public const string LAST_NAME_LENGTH = "Last name's length can not be less";
        public const string FIRST_NAME_CAN_ONLY = "First name can only contain letters and spaces";
        public const string LAST_NAME_CAN_ONLY = "Last name can only contain letters and spaces";
        public static string NAME_CHARACTER_LIMIT(string namePropertyName, int min, int max) => $"{namePropertyName} must be between {min} and {max} characters";

        public const string PASSWORD_IS_REQUIRED = "Password is required";
        public static string PASSWORD_MIN_CHARACTER_LIMIT(int min) => $"Password must be at least {min} characters";
        public const string PASSWORD_CAN_ONLY = "Password must contain at least one uppercase letter, one lowercase letter, and one number";

        public const string IP_ADDRESS_REQUIRED = "Ip address is required";
        public const string INVALID_IP_ADDRESS = "Invalid Ip address format";

        public const string USER_VALIDATION_FAILED = "User validation failed";

    }
}
