using FirstAPI.Models;
using FirstAPI.Repositery;

namespace FirstAPI.Service
{
    public class CourseService : ICourseService<Course>
    {
        private readonly ICourseRepo<Course> _repo;
        public void AddCourse(Course course)
        {
            _repo.AddCourse(course);
        }

        public List<Course> GetAll()
        {
            return _repo.GetAll();
        }

        public Course GetByCourseId(int courseId)
        {
            return  _repo.GetByCourseId(courseId);
        }

        public bool getLogic()
        {
            return true;
        }

        public void EditCourse(int id, Course course)
        {
            _repo.EditCourse(id,course);
        }
    }
}
