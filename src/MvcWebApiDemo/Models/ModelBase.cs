using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ModelBase
    {
        public Guid ID { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ModelBase()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
