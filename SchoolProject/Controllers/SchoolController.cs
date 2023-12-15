using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProject.Models.Repositories;
using SchoolProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolProject.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {

        readonly ISchoolRepository schoolRepository;

        //injection de dÃ©pendance
        public SchoolController(ISchoolRepository schoolRepository)
        {

            this.schoolRepository = schoolRepository;

        }
        [AllowAnonymous]
        // GET: SchoolController
        public ActionResult Index()
        {
            var schools = schoolRepository.GetAll();

            return View(schools);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School school)
        {
            try
            {
                schoolRepository.Add(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School school)
        {
            try
            {
                schoolRepository.Edit(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(School school)
        {
            try
            {
                schoolRepository.Delete(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

