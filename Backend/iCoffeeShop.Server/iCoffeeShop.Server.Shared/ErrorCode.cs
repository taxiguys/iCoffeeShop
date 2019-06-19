namespace iCoffeeShop.Server.Shared
{
    public enum ErrorCode
    {
        BAD_REQUEST = 9999,

        REGISTER_DUPLICATE_EMAIL = 1001,

        REGISTER_EMAIL_REQUIRED = 1002,

        REGISTER_NAME_REQUIRED = 1003,

        REGISTER_PASSWORD_REQUIRED = 1004
    }
}
