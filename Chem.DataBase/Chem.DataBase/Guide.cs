//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chem.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guide
    {
        public Guide()
        {
            this.Substance_Guide = new HashSet<Substance_Guide>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Type { get; set; }
    
        public virtual ICollection<Substance_Guide> Substance_Guide { get; set; }
    }
}
