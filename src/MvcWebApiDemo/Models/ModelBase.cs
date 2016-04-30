using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public abstract class ModelBase
    {
        [Key]
        public  Guid ID { get; set; }
        public ModelBase()
        {
            ID = Guid.NewGuid();
        }
    }

    public abstract class ModelWithTracking : ModelBase
    {
        [JsonIgnore]
        public DateTime AddedDate { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }
    }

    public abstract class ModelWithTrackingAndAudit : ModelWithTracking
    {
        [JsonIgnore]
        public string CreatedBy { get; set; }

        [JsonIgnore]
        public string LastModifiedBy { get; set; }
    }
}
