//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SummerOlympiads.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SummerOlympiad
    {
        public SummerOlympiad()
        {
            this.Events = new HashSet<Event>();
        }
    
        public int SummerOlympiadId { get; set; }
        public int Year { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual City City { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}