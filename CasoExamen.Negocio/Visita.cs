using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;

namespace CasoExamen.Negocio
{
    public class Visita
    {
        public decimal Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal IdProf { get; set; }



        CasoExamenEntities db = new CasoExamenEntities();

        public List<Visita> ReadAll()
        {
            return this.db.VISITA.Select(v => new Visita()
            {

                Id = v.ID_VISITA,
                Fecha = v.FECHA,
                Descripcion = v.DESCRIPCION,
                IdProf = v.ID_PROF

            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //llamado procedure
                db.SP_CREATE_VISITA(this.Fecha, this.Descripcion, this.IdProf);
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
                db.SP_UPDATE_VISITA(this.Id, this.Fecha, this.Descripcion, this.IdProf);
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
                db.SP_DELETE_VISITA(id);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
