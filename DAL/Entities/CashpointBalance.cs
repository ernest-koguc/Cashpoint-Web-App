namespace DAL.Entities
{
    public class CashpointBalance : Entity
    {
        public int Id { get; set; }
        public int TwoHundredBillsCount { get; set; }
        public int OneHundredBillsCount { get; set; }
        public int FiftyBillsCount { get; set; }
        public int TwentyBillsCount { get; set; }
        public int TenBillsCount { get; set; }
        public int TotalBalance => TwoHundredBillsCount * 200 + OneHundredBillsCount * 100 + FiftyBillsCount * 50 + TwentyBillsCount * 20 + TenBillsCount * 10;
    }
}
