using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDev.Producer
{
    public class Item
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string StashCode { get; set; }
    }
}
