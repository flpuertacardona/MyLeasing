using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class Agent
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Property> Properties{ get; set; }
    }
}
