//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reward
    {
        public reward()
        {
            this.tickets = new HashSet<ticket>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ChanceToGet { get; set; }
        public Nullable<int> ChanceToRoll { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> TimeRemain { get; set; }
    
        public virtual ICollection<ticket> tickets { get; set; }
    }
}
