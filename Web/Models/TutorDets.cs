﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class TutorDets
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string profession { get; set; }
        public long phone_number { get; set; }
        public string gender { get; set; }

    }
}