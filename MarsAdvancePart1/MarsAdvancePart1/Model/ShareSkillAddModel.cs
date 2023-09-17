﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Model
{
    public class ShareSkillAddModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }

        public string SubCatagory { get; set; }

        public string CatagoryTags { get; set;}

        public string ServiceType { get; set; }
        public string LocationType { get; set; }

        public string AvailableStartDate { get; set; }
        public string AvailableTime { get; set;}
        public string AvailableDays { get; set; }

       
        public string SkillTrade { get; set; }
        public string SkillExchange{ get; set;}

        public string Active { get; set; }  

    }
}
