using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasoExamen.DALC;

namespace CasoExamen.Negocio
{
    public class Cliente
    {
        public decimal Id { get; set; }
        public string Rut { get; set; }
        public string NomEmpresa { get; set; }
        public string NomRepre { get; set; }
        public string ApeRepre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal RubroId { get; set; }

        public Rubro Rubro { get; set; }

        CasoExamenEntities db = new CasoExamenEntities();

        public List<Cliente> ReadAll()
        {
            return this.db.CLIENTE.Select(c => new Cliente()
            {

                Id = c.ID_EMP,
                Rut = c.RUT_EMP,
                NomEmpresa = c.NOM_EMP,
                NomRepre = c.NOM_REPRE,
                ApeRepre = c.APE_REPRE,
                Correo = c.CORREO,
                Password = c.PASSWORD,
                Direccion = c.DIREC_EMP,
                Telefono = c.NUM_TELEF,
                RubroId = (decimal)c.ID_RUBRO,
                Rubro = new Rubro()
                {
                    Id = (decimal)c.ID_RUBRO,
                    Nombre = c.RUBRO.NOMRUBRO
                }
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //llamado procedure
                db.SP_CREATE_CLIENTE(this.Rut, this.NomEmpresa, this.NomRepre, this.ApeRepre, this.Correo, 
                    this.Direccion, this.Telefono, this.RubroId);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Cliente Find(int id)
        {
            return this.db.CLIENTE.Select(c => new Cliente()
            {

                Id = c.ID_EMP,
                Rut = c.RUT_EMP,
                NomEmpresa = c.NOM_EMP,
                NomRepre = c.NOM_REPRE,
                ApeRepre = c.APE_REPRE,
                Correo = c.CORREO,
                Password = c.PASSWORD,
                Direccion = c.DIREC_EMP,
                Telefono = c.NUM_TELEF,
                RubroId = (decimal)c.ID_RUBRO,
                Rubro = new Rubro()
                {
                    Id = (decimal)c.ID_RUBRO,
                    Nombre = c.RUBRO.NOMRUBRO
                }
            }).Where(c => c.Id == id).FirstOrDefault();

        }
        public bool Update()
        {
            try
            {
                db.SP_UPDATE_CLIENTE(this.Id, this.Rut, this.NomEmpresa, this.NomRepre, this.ApeRepre, this.Correo, this.Password,
                    this.Direccion, this.Telefono, this.RubroId);
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
                db.SP_DELETE_CLIENTE(id);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
