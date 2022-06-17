using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPlusSport.API.Models
{
    public class Order
    {

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User user { get; set; }

        public virtual List<Product> products { get; set; }
    }
}
