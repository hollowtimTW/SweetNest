namespace SweetNest.Web.Utility
{
    public class SD
    {
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public static string ProductAPIBase { get; set; }
        public static string ShoppingCartAPIBase { get; set; }
        public static string OrderAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public const string Status_Pending = "pending"; // 待處理
        public const string Status_Approved = "approved"; // 已批准
        public const string Status_ReadyForPickup = "readyforpickup"; // 可取貨
        public const string Status_Completed = "completed"; // 已完成
        public const string Status_Refunded = "refunded"; // 已退款
        public const string Status_Cancelled = "cancelled"; // 已取消

        public enum ContentType
        {
            Json,
            MultipartFormData
        }
    }
}
