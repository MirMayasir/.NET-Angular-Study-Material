
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositery

{
    public class CourseRepo : ICourseRepo<Course>
    {
        private readonly WiprongadbContext _context;
        public CourseRepo(WiprongadbContext context)
        {
            _context = context;
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChangesAsync();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetByCourseId(int courseId)
        {
            var c = _context.Courses.Where(x => x.Cid == courseId).SingleOrDefault();
            return c;
        }


        public void EditCourse(int id, Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}
