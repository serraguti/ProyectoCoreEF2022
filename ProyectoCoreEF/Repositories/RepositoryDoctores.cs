using ProyectoCoreEF.Data;
using ProyectoCoreEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCoreEF.Repositories
{
    public class RepositoryDoctores
    {
        private HospitalContext context;

        public RepositoryDoctores(HospitalContext context)
        {
            this.context = context;
        }

        public List<Doctor> GetDoctoresHospital(int idhospital)
        {
            var consulta = from datos in this.context.Doctores
                           where datos.IdHospital == idhospital
                           select datos;
            return consulta.ToList();
        }

        public Doctor FindDoctor(int iddoctor)
        {
            var consulta = from datos in this.context.Doctores
                           where datos.IdDoctor == iddoctor
                           select datos;
            //EN LUGAR DE PREGUNTAR SI EXISTE ALGUN DOCTOR
            //TENEMOS UN METODO QUE NOS DEVUELVE EL PRIMERO QUE ENCUENTRA
            //O NOS DEVUELVE UN NULL (Default)
            return consulta.FirstOrDefault();
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.context.Doctores
                           select datos;
            return consulta.ToList();
        }

        public List<Doctor> GetDoctoresSalario(int salario)
        {
            var consulta = from datos in this.context.Doctores
                           where datos.Salario >= salario
                           select datos;
            //COMPROBAMOS SI EXISTEN O NO DOCTORES
            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.ToList();
            }
        }
    }
}
