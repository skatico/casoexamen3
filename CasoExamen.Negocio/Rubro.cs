using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;

namespace CasoExamen.Negocio
{
    public class Rubro
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }

        CasoExamenEntities db = new CasoExamenEntities();

        public List<Rubro> ReadAll()
        {
            return db.RUBRO.Select(r => new Rubro()
            {
                Id = r.ID_RUBRO,
                Nombre = r.NOMRUBRO

            }).ToList();
        }
    }
}
