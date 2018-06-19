using System;

namespace LizenzManager.Models
{
    public class Seat
    {
        public Seat()
        {
            
        }

        public Seat(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        //public DateTime ExpirationDate { get; set; }

        //public int ID { get; set; }
    }
}