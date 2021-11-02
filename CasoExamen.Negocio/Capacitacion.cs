using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;

namespace CasoExamen.Negocio
{
    public class Capacitacion
    {
        public decimal Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Asistentes { get; set; }
        public string Descripcion { get; set; }

        CasoExamenEntities db = new CasoExamenEntities();

        public List<Capacitacion> ReadAll()
        {
            return this.db.CAPACITACION.Select(c => new Capacitacion()
            {

                Id = c.ID_CAP,
                Fecha = c.FECHA,
                Asistentes = c.ASISTENTES,
                Descripcion = c.DESCRIPCION

            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //llamado procedure
                db.SP_CREATE_CAPACITACION(this.Fecha, this.Asistentes, this.Descripcion);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool Update()
        {
            try
            {
                db.SP_UPDATE_ASESORIA(this.Id, this.Fecha, this.Descripcion);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.SP_DELETE_ASESORIA(id);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
