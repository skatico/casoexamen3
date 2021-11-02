using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;

namespace CasoExamen.Negocio
{
    public class Admin
    {
        public decimal Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime UltimaConexion { get; set; }

        CasoExamenEntities db = new CasoExamenEntities();

        public bool Autenticar()
        {
            return db.ADMIN
                .Where(a => a.CORREO == this.Correo
                && a.PASSWORD == this.Password)
                .FirstOrDefault() != null;
        }
    }
}
