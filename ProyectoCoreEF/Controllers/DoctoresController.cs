using Microsoft.AspNetCore.Mvc;
using ProyectoCoreEF.Models;
using ProyectoCoreEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCoreEF.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        //GET
        public IActionResult DoctoresSalario()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        //POST
        [HttpPost]
        public IActionResult DoctoresSalario(int salario)
        {
            List<Doctor> doctores = this.repo.GetDoctoresSalario(salario);
            //PUEDE SER QUE NO TENGAMOS DOCTORES, ES DECIR, 
            //EL REPO NOS DEVUELVE UN NULL
            //SI NOS DEVUELVE UN NULL, MOSTRAMOS UN MENSAJE EN LA VISTA
            //SINO, DEVOLVEMOS LOS DOCTORES
            if (doctores == null)
            {
                ViewData["MENSAJE"] = "No se han encontrado doctores con salario mayor a "
                    + salario;
                return View();
            }
            else
            {
                return View(doctores);
            }
        }



        public IActionResult Details(int iddoctor)
        {
            Doctor doctor = this.repo.FindDoctor(iddoctor);
            return View(doctor);
        }

        public IActionResult DoctoresHospital(int idhospital)
        {
            List<Doctor> doctores = this.repo.GetDoctoresHospital(idhospital);
            return View(doctores);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
