//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OneOff.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tour
    {
        public int Id { get; set; }
        public string GigId { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual Gig Gig { get; set; }
    }
}
