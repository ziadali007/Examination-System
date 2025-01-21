using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    internal class Practical : Question, IExam
    {
        public Subject Sub { get; set; }

        public int[] Marks { get; set; }

        public int[] CorrectAnswer;


        public int Index1 = 0,Index2=0;
        public Practical(int numberOfQuestions)
        {

            Sub = new Subject();
            Marks = new int[numberOfQuestions];
            CorrectAnswer = new int[numberOfQuestions]; 
           

        }

        override public void Header()
        {
            MCQBody();
        }


        public Answers[] answers3 = new Answers[6];
 
        override public void MCQBody()
        {
             
            string Question;

            Console.WriteLine("Please Enter Question Body: ");

            Question = Console.ReadLine();
            answers3[0] = new Answers { Answer_Text = Question, Answer_Id = 0 };

            bool Flag = false;
            int y = Mark;
            do
            {
                Console.WriteLine("Please Enter Question Mark: ");
                Flag = int.TryParse(Console.ReadLine(), out y);
            } while (!Flag || y < 0);

            Marks[Index1] = y;
            Index1++;

            Console.WriteLine("Please Enter Choices Of The Question: ");

            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"Please Enter Choice Number {i}: ");
                string choice = Console.ReadLine();
                answers3[i] = new Answers { Answer_Text = choice, Answer_Id = i };
            }

            bool Flag2 = false;
            int Ans_Id=0;

            do
            {
                Console.WriteLine("Please Enter Answer Id: ");
                Flag2 = int.TryParse(Console.ReadLine(), out Ans_Id);
            } while (!Flag2 || Ans_Id < 1 || Ans_Id > 4);

            answers3[5] = new Answers { Answer_Text = $"Correct Answer: {Ans_Id}", Answer_Id = Ans_Id };

        }

        
        public void ShowExam()
        {
            for (int i = 0; i < Index1; i++) 
            {
                
                Console.WriteLine($"{answers3[0].Answer_Text}    Mark: {Marks[i]} ");

                
                for (int j = 1; j <= 4; j++)
                {
                    Console.WriteLine($"{j}- {answers3[j].Answer_Text}");
                }

                Console.WriteLine(); 
            }
        }
    }
}
