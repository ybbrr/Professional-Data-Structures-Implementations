namespace CustomTypes
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public Student()
        {

        }

        public Student(int id, string name, double gpa)
        {
            Id = id;
            Name = name;
            GPA = gpa;
        }

        public override string ToString()
        {
            return $"{Id,-5} {Name,-5} {GPA,-5}";
        }
    }
}