namespace Core.Models
{
    public class CouponPayload
    {
        public string DiscountCode { set; get; }
        public int RequestsNumber { get; set; }
        public DiscountType DiscountType { set; get; }
        public int DiscountValue { set; get; }
    }
}
