using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TresDivas.Website.Models
{
    public class Twitter_UT_Filters
    {
        public string Product_Name { get; set; }

        public string Channel { get; set; }

        public string Goal_Or_Outcome { get; set; }

        public string Product_Hashtag { get; set; }

        public string Twitter_Account_Age { get; set; }

        public string Minimum_Followers { get; set; }

        public bool Filter_Out_Retweets { get; set; }
    }
}