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
