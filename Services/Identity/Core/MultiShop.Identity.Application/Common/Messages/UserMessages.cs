

namespace MultiShop.Identity.Application.Common.Messages
{
    public static class UserMessages
    {
        public const string USERNAME_ALREADY_EXISTS = "Username is already taken";
        public const string EMAIL_ALREADY_EXISTS = "Email is already taken";

        public const string USERNAME_CAN_NOT_EMPTY = "Username can not be empty";
        public static readonly string EMAIL_CAN_NOT_EMPTY = "Email can not be empty";


        public const string FIRST_NAME_CAN_NOT_EMPTY = "Firstname can not be empty";
        public const string LAST_NAME_CAN_NOT_EMPTY = "Lastname can not be empty";

        public const string USERNAME_LENGTH = "Username's length can not be less ";
        public const string FIRSTNAME_LENGTH = "Firstname's length can not be less";
        public const string LASTNAME_LENGTH = "Lastname's length can not be less";


        public const string USER_VALIDATION_FAILED = "User validation failed";

    }
}
