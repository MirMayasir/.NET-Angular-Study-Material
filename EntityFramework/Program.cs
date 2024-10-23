using EntityFramework.Models;

namespace EntityFramework
{
    internal class Program
    {
        public static  WiprongadbContext context = new WiprongadbContext();
        static void Main(string[] args)
        {
        

            Console.WriteLine("Enter Course id ");
            int courseid = Convert.ToInt32(Console.ReadLine());
            /*FindACourseById(courseid);*/
            /*AddCourses();
            GetCourses();*/
            Course updatedCourse = new Course
            {
                Cid = courseid,
                Cname = "Advanced C# Programming",
                Fees = 1500.00
            };

            UpdateCourse(courseid, updatedCourse);
        }

        private static void AddCourses()
        {
            Console.WriteLine("enter cid, cname, and fee");
            Course c = new Course();
            c.Cid = Convert.ToInt32(Console.ReadLine());
            c.Cname= Console.ReadLine();
            c.Fees = float.Parse(Console.ReadLine());
            context.Courses.Add(c);
            context.SaveChanges();
            Console.WriteLine("entry added successfully");
        }
        private static void GetCourses()
        {
            Console.WriteLine("the course details are");
            foreach (var item in context.Courses)
            {
                Console.WriteLine(item.Cid + " " + item.Cname + " " + item.Fees);
            }
        }
        private static void FindACourseById(int courseid)
        {

            // Use FirstOrDefault to get the first matching course or null if none found
            Course c = context.Courses.FirstOrDefault(x => x.Cid == courseid);

            if (c != null)
            {
                Console.WriteLine(c.Cid + " " + c.Cname + " " + c.Fees);
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        private static void DeleteCourse(int  courseid)
        {
            Course c = context.Courses.FirstOrDefault(x => x.Cid == courseid);
            context.Courses.Remove(c);
            context.SaveChanges();
            Console.WriteLine("course deleted");
        }
        /*private static void UpdateCourse(int id, Course c)
        {
            Course existingCourse = context.Courses.FirstOrDefault(x => x.Cid == id);

            if (existingCourse != null)
            {
                context.Courses.Remove(existingCourse);
                context.Courses.Add(c);
                context.SaveChanges();

                Console.WriteLine("Course updated successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }*/
        private static void UpdateCourse(int id, Course c)
        {
            Course existingCourse = context.Courses.FirstOrDefault(x => x.Cid == id);

            if (existingCourse != null)
            {
                // Truncate cname if necessary
                int maxCnameLength = 20; // Example length, replace with actual column length
                c.Cname = c.Cname.Length > maxCnameLength ? c.Cname.Substring(0, maxCnameLength) : c.Cname;

                existingCourse.Cname = c.Cname;
                existingCourse.Fees = c.Fees;

                context.SaveChanges();

                Console.WriteLine("Course updated successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

    }
}
