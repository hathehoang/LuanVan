using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class dbItemListReward
    {

        public Nullable<int> ChanceToGet { get; set; }
        public Nullable<int> ChanceToRoll { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> TimeRemain { get; set; }
        public int quantity { get; set; }
    }
}