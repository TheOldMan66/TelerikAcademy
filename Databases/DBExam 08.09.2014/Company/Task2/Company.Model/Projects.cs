//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Company.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projects
    {
        public Projects()
        {
            this.EmployeesProjects = new HashSet<EmployeesProjects>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }
    }
}