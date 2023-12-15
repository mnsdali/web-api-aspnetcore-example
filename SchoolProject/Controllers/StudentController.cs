using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models.Repositories;
using SchoolProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {

        readonly IStudentRepository studentRepository;
        readonly ISchoolRepository schoolRepository;

        //injection de dÃ©pendance
        public StudentController(IStudentRepository studentRepository, ISchoolRepository schoolRepository)
        {

            this.studentRepository = studentRepository;
            this.schoolRepository = schoolRepository;

        }
        // GET: StudentController
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            var students = studentRepository.GetAll();

            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
                studentRepository.Add(student);
                return RedirectToAction(nameof(Index));


            }
            catch
            {

                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
                studentRepository.Edit(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
                studentRepository.Delete(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string name, int? schoolid)

        {
            var result = studentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = studentRepository.FindByName(name);
            else
            if (schoolid != null)
                result = studentRepository.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
    }
}