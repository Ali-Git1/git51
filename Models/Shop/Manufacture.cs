using BigonWebUI.Models.Entities.Common;

namespace BigonWebUI.Models.Shop
{
    public class Manufacture:BaseEntity<int>
    {
        public string BrandOne { get; set; }
        public string BrandTwo { get; set; }
        public string BrandThree { get; set; }
        public string BrandFour { get; set; }
        public string BrandFive { get; set; }
    }
}
