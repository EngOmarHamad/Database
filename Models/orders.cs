using System;

namespace Game_Store.Models
{
    internal class orders
    {

        public int order_id { get; set; }
        public int user_id { get; set; }
        public int game_id { get; set; }
        public int price { get; set; }
        public int payment_id { get; set; }
        public DateTime date { get; set; }
    }
}
