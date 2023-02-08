using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Child
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string NumberId { get; set; }
        public DateTime DOB { get; set; }
        public User ParentUser { get; set; }
    }
}
