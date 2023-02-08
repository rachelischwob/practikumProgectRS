﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public enum EGender
    {
        MALE, FEMALE
    }
    public class UserModel
    {
        public int  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberId { get; set; }
        public string HMO { get; set; }
        public EGender Gender { get; set; }
        public DateTime DBO { get; set; }
        public List<ChildModel>? Children { get; set; }
    }
}
