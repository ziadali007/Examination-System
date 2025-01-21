using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    internal class Exam : IExam
    {
        public DateTime TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }

        public Exam(DateTime time,int NoQ) {
            
            TimeOfExam = time;

            NumberOfQuestions = NoQ;

        }

        public Exam() { }

        public void ShowExam() { }
        int Duration;
        int NoQuestion;
        public void ExamDetails() {
  
            
            bool Flag = false;
            

            do
            {
                Console.WriteLine("Please Enter The Time Of Exam From 30 Min To 180 Min");
                Flag = int.TryParse(Console.ReadLine(), out Duration);
            } while (!Flag || Duration < 30 || Duration > 180);

        }

        public void ShowExamDetails() {

            Console.WriteLine($"Time For The Exam: {Duration} ");
     
        
        
        }

        
    }
}
