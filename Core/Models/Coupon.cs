using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string DiscountCode { set; get; }
        public int OriginalRequestsNumber { get; set; }
        public int CurrentRequestsNumber { get; set; }
        public DiscountType DiscountType { set; get; }
        public int DiscountValue { set; get; }
        public DiscountCodeStatus DiscountCodeStatus { set; get; } = DiscountCodeStatus.ACTIVATED;
    }
}
