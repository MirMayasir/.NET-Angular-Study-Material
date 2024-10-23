namespace FirstAPI.Service
{
    public interface ICourseService<Course>
    {
        List<Course> GetAll();
        Course GetByCourseId(int courseId);
        void AddCourse(Course course);
        void EditCourse(int id, Course course);
        bool getLogic();
    }
}
