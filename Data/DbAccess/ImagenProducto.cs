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
    
    public partial class ImagenProducto
    {
        public int CodigoImagenProducto { get; set; }
        public byte[] Imagen { get; set; }
        public int CodigoProducto { get; set; }
        public bool Borrado { get; set; }
    
        public virtual Producto Productos { get; set; }
    }
}