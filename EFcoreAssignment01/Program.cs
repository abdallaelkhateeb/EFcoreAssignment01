using EFcoreAssignment01.Context;

namespace EFcoreAssignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ITIDbContext())
            {
                // Create
                var student = new Student { FName = "Ali", LName = "Ahmed", Age = 22, Address = "Cairo", Dep_Id = 1 };
                context.Students.Add(student);
                context.SaveChanges();

                // Read
                var students = context.Students.ToList();

                // Update
                var std = context.Students.First();
                std.Age = 25;
                context.SaveChanges();

                // Delete
                context.Students.Remove(std);
                context.SaveChanges();
            }

        }
    }
}
