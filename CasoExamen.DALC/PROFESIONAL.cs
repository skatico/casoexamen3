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
    
    public partial class PROFESIONAL
    {
        public PROFESIONAL()
        {
            this.VISITA = new HashSet<VISITA>();
        }
    
        public decimal ID_PROF { get; set; }
        public string NOM_PROF { get; set; }
        public string APELL_PROF { get; set; }
        public string RUT { get; set; }
        public string CORREO { get; set; }
        public string PASSWORD { get; set; }
        public string NUM_TELEF { get; set; }
    
        public virtual ICollection<VISITA> VISITA { get; set; }
    }
}
