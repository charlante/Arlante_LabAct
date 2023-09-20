using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Arlante_LabAct.Models;

namespace sample.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano",  IsTenured = IsTenured.Permanent, Rank = Rank.Professor, HiringDate = DateTime.Parse("2022-08-26")
                },
                new Instructor()
                {
                    Id= 2,FirstName = "Zyx",LastName = "Montano", IsTenured = IsTenured.Probationary, Rank = Rank.AssistantProfessor, HiringDate = DateTime.Parse("2022-08-07")
                },
                new Instructor()
                {
                    Id= 3,FirstName = "Aerdriel",LastName = "Montano", IsTenured = IsTenured.Permanent, Rank = Rank.AssociateProfessor, HiringDate = DateTime.Parse("2020-01-25")
                }
            };
        public IActionResult Index()
        {

            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }

        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == instructorChanges.Id);

            if (instructor != null)
            {
                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.IsTenured = instructorChanges.IsTenured;
                instructor.Rank = instructorChanges.Rank;
                instructor.HiringDate = instructorChanges.HiringDate;
            }
            return View("Index", InstructorList);
        }
    }
}
