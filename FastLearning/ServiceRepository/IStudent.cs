using FastLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearning.ServiceRepository
{
    public interface IStudent
    {
        IEnumerable<Student> Students { get; }
        public void AddStudent(Student student);

        Student Delete(int ID);

        Student GetStudent(int ID);

        void SaveStudent(Student employee);

        IQueryable<Student> Search(string surname);
    }
}
