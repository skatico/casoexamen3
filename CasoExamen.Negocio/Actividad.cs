using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;

namespace CasoExamen.Negocio
{
    public class Actividad
    {
        public decimal Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }



        CasoExamenEntities db = new CasoExamenEntities();

        public List<Actividad> ReadAll()
        {
            return this.db.ACTIVIDAD.Select(a => new Actividad()
            {

                Id = a.ID_ACTIVIDAD,
                Fecha = a.FECHA,
                Descripcion = a.DESCRIPCION

            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //llamado procedure
                db.SP_CREATE_ACTIVIDAD(this.Fecha, this.Descripcion);
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
                db.SP_UPDATE_ACTIVIDAD(this.Id, this.Fecha, this.Descripcion);
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
                db.SP_DELETE_ACTIVIDAD(id);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
