using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Call : ModelWithTracking
    {
        public Guid ContactId { get; set; }
        public string Purpose { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string  FollowUpAddress { get; set; }
        public byte Rating { get; set; }
        public byte Prospect { get; set; }
        public string Status { get; set; }
    }
}
