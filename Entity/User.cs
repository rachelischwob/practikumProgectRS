using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string NumberId { get; set; }
        public String HMO { get; set; }    
        public int Gender { get; set; }
        public DateTime DBO { get; set; }   
    }
}
