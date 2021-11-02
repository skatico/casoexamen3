using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;
namespace CasoExamen.Negocio
{
    public class Profesional
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Numero { get; set; }

        CasoExamenEntities db = new CasoExamenEntities();

        public List<Profesional> ReadBox()
        {
            return this.db.PROFESIONAL.Select(p => new Profesional()
            {
                Id = p.ID_PROF,
                Rut = p.RUT
            }).ToList();
        }

        public List<Profesional> ReadAll()
        {
            return this.db.PROFESIONAL.Select(p => new Profesional()
            {
                Id = p.ID_PROF,
                Nombre = p.NOM_PROF,
                Apellido = p.APELL_PROF,
                Rut = p.RUT,
                Correo = p.CORREO,
                Password = p.PASSWORD,
                Numero = p.NUM_TELEF
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //llamado procedure
                db.SP_CREATE_PROFESIONAL(this.Nombre, this.Apellido, this.Rut, this.Correo, this.Numero);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Profesional Find(int id)
        {
            return this.db.PROFESIONAL.Select(p => new Profesional()
            {
                Id = p.ID_PROF,
                Nombre = p.NOM_PROF,
                Apellido = p.APELL_PROF,
                Rut = p.RUT,
                Correo = p.CORREO,
                Password = p.PASSWORD,
                Numero = p.NUM_TELEF

            }).Where(p => p.Id == id).FirstOrDefault();

        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_PROFESIONAL(this.Id, this.Nombre, this.Apellido, this.Rut, this.Correo, this.Password, this.Numero);
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
                db.SP_DELETE_PROFESIONAL(id);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
