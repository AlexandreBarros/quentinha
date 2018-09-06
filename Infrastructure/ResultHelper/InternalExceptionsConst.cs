namespace Infrastructure.ResultHelper
{
    public class InternalExceptionsConst
    {
        public const int Status301MovedPermanently = 301;
        public const int Status302Found = 302;
        public const int Status303SeeOther = 303;
        public const int Status304NotModified = 304;
        public const int Status305UseProxy = 305;
        public const int Status306SwitchProxy = 306; // RFC 2616, removed
        public const int Status307TemporaryRedirect = 307;
        public const int Status308PermanentRedirect = 308;

        public const int Status400BadRequest = 400;
        public const int Status401Unauthorized = 401;
        public const int Status402PaymentRequired = 402;
        public const int Status403Forbidden = 403;
        public const int Status404NotFound = 404;
        public const int Status405MethodNotAllowed = 405;
        public const int Status406NotAcceptable = 406;
        public const int Status407ProxyAuthenticationRequired = 407;
        public const int Status408RequestTimeout = 408;
        public const int Status409Conflict = 409;
        public const int Status410Gone = 410;
        public const int Status411LengthRequired = 411;
        public const int Status412PreconditionFailed = 412;
        public const int Status413RequestEntityTooLarge = 413; // RFC 2616, renamed
        public const int Status413PayloadTooLarge = 413; // RFC 7231
        public const int Status414RequestUriTooLong = 414; // RFC 2616, renamed
        public const int Status414UriTooLong = 414; // RFC 7231
        public const int Status415UnsupportedMediaType = 415;
        public const int Status416RequestedRangeNotSatisfiable = 416; // RFC 2616, renamed
        public const int Status416RangeNotSatisfiable = 416; // RFC 7233
        public const int Status417ExpectationFailed = 417;
        public const int Status418ImATeapot = 418;
        public const int Status419AuthenticationTimeout = 419; // Not defined in any RFC
        public const int Status421MisdirectedRequest = 421;
        public const int Status422UnprocessableEntity = 422;
        public const int Status423Locked = 423;
        public const int Status424FailedDependency = 424;
        public const int Status426UpgradeRequired = 426;
        public const int Status428PreconditionRequired = 428;
        public const int Status429TooManyRequests = 429;
        public const int Status431RequestHeaderFieldsTooLarge = 431;
        public const int Status451UnavailableForLegalReasons = 451;
    }
}
