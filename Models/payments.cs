namespace Game_Store.Models
{
    internal class payments
    {

        public int payment_id { get; set; }
        public int user_id { get; set; }
        public string payment_type { get; set; }
        public int card_number { get; set; }
        public int valid { get; set; }
    }
}
