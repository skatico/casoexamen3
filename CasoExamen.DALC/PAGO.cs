//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CasoExamen.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAGO
    {
        public decimal ID_PAGO { get; set; }
        public System.DateTime FECHA_PAGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string METODO_PAGO { get; set; }
        public decimal ID_EMP { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
    }
}