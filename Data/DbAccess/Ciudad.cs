//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.DbAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ciudad
    {
        public int CodigoCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public int CodigoProvincia { get; set; }
    
        public virtual Provincia Provincias { get; set; }
    }
}
