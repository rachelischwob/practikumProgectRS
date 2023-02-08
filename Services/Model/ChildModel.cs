using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class ChildModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumberId { get; set; }
        public DateTime DOB { get; set; }
        public int ParentUserId { get; set; }
    }
}
