//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GubaidullinGlazki
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shop
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int AgentID { get; set; }
    
        public virtual Agent Agent { get; set; }
    }
}
