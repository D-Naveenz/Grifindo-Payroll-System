﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Data.Models
{
    public class JobTitle
    {
        public JobTitle()
        {
            Title = "";
            EditUserData = false;
            SeeEmpData = false;
            EditEmpData = false;
        }

        public string Title { get; set; }
        public bool EditUserData { get; set; }
        public bool SeeEmpData { get; set; }
        public bool EditEmpData { get; set; }
    }
}
