using FastLearning.Data;
using FastLearning.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearning.ServiceRepository
{
    public class StudentRepository : IStudent
    {
        private readonly DataContext context;

       
        public StudentRepository(DataContext ctx)
        {
            context = ctx;
        }

       

        public IEnumerable<Student> Students => context.Students;

        
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }



        public Student Delete(int ID)
        {
            Student student = context.Students.Find(ID);
            if (student != null)
            {
                context.Students.Remove(student);
                //After remove the employee then save changes to database
                context.SaveChanges();
            }
            return student;
        }

        public Student GetStudent(int ID)
        {
            return context.Students.Find(ID);
        }

        public void SaveStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IQueryable<Student> Search(string surname)
        {
            var stud = context.Students.Where(C => C.Surname == surname || C.Email == surname ||C.PhoneNo == surname);
            return stud;
        }
    }
}
