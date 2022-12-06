using System;

namespace Game_Store.Models
{
    internal class Game
    {

        public int game_id { get; set; }
        public string name { get; set; }
        public int developer { get; set; }
        public int publisher { get; set; }
        public int store_id { get; set; }
        public string genre { get; set; }
        public int price { get; set; }
        public int review { get; set; }
        public int age_limit { get; set; }
        public DateTime release_date { get; set; }
        public string except_country { get; set; }
        public string description { get; set; }

        public bool isObtainble { get; set; }

    }
}







