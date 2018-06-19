using System;

namespace LizenzManager.Models
{
    public class License
    {
        public License()
        {
            
        }

        /// <summary>
        /// Constructor without Notes
        /// </summary>
        /// <param name="name">The Name assigned to the License</param>
        /// <param name="key">The Key assigned to the License</param>
        /// <param name="seat">The Seat assigned to the License</param>
        /// <param name="expirationDate">The date at which this License will expire</param>
        public License(string name, string key, Seat seat, DateTime expirationDate)
        {
            Name = name;
            Key = key;
            Seat = seat;
            ExpirationDate = expirationDate;
        }

        /// <summary>
        /// Constructor with Notes
        /// </summary>
        /// <param name="name">The Name assigned to the License</param>
        /// <param name="key">The Key assigned to the License</param>
        /// <param name="seat">The Seat assigned to the License</param>
        /// <param name="expirationDate">The date at which this License will expire</param>
        /// <param name="notes">The notes assigned to this License</param>
        public License(string name, string key, Seat seat, DateTime expirationDate, string notes)
        {
            Name = name;
            Key = key;
            Seat = seat;
            ExpirationDate = expirationDate;
            Notes = notes;
        }

        public string Name { get; set; }

        public string Key { get; set; }

        public Seat Seat { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }


        /// <summary>
        /// As of now, this field is not used.
        /// </summary>
        public int ID { get; set; }
    }
}