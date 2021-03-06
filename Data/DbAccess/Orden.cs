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
    
    public partial class Orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden()
        {
            this.OrdenesDetalles = new HashSet<OrdenDetalle>();
        }
    
        public int CodigoOrden { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoEmpleado { get; set; }
        public int CodigoSucursal { get; set; }
        public System.DateTime FechaHora { get; set; }
        public int CodigoEstado { get; set; }
        public bool Borrado { get; set; }
    
        public virtual Cliente Clientes { get; set; }
        public virtual Empleado Empleados { get; set; }
        public virtual Estado Estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenDetalle> OrdenesDetalles { get; set; }
        public virtual Sucursal Sucursales { get; set; }
    }
}
