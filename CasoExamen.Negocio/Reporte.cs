using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;

namespace CasoExamen.Negocio
{
    public class Reporte
    {
        public decimal Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        CasoExamenEntities db = new CasoExamenEntities();

        public List<Reporte> ReadAll()
        {
            return this.db.REPORTE.Select(r => new Reporte()
            {

                Id = r.ID_REPORTE,
                Fecha = r.FECHA,
                Descripcion = r.DESCRIPCION

            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //llamado procedure
                db.SP_CREATE_REPORTE(this.Fecha, this.Descripcion);
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
                db.SP_UPDATE_REPORTE(this.Id, this.Fecha, this.Descripcion);
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
                db.SP_DELETE_REPORTE(id);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
