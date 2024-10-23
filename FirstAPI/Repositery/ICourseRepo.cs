namespace FirstAPI.Repositery
{
    public interface ICourseRepo<Course>
    {

        List<Course> GetAll();
        Course GetByCourseId(int courseId); 
        void AddCourse(Course course);
        void EditCourse(int id, Course course);

    }
}
