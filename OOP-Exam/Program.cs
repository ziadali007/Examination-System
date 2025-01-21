namespace OOP_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Flag = false;
            int SubjectId;
            do
            {
                Console.WriteLine("Please Enter Subject Id");
                Flag = int.TryParse(Console.ReadLine(), out SubjectId);
            } while (!Flag);

            Console.WriteLine("Please Enter Subject Name");
            string SubjectName = Console.ReadLine();

            Subject subject=new Subject(SubjectId, SubjectName);

            subject.CreateExam();

            subject.SubjectDetails();
        }
    }
}
