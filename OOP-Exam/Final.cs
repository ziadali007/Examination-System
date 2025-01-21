using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    internal class Final : Question, IExam
    {
        public int Headerr;

        public Subject Sub { get; set; }

        public int[] Marks { get; set; }

        public int[] CorrectAnswer;

        int Index=0;

        public Final(int numberOfQuestions)
        {

            Sub = new Subject();
            Marks = new int[numberOfQuestions];
            CorrectAnswer = new int[numberOfQuestions];

        }


        override public void Header()
        {
           
            bool Flag = false;

            do
            {
                Console.WriteLine("Please Enter The Type Of The Question (1 For MCQ | 2 For True Or False) ");
                Flag = int.TryParse(Console.ReadLine(), out Headerr);
            } while (!Flag || (Headerr != 1 && Headerr != 2));

            if(Headerr == 1)
            {
                MCQBody();
            }
            else
            {
                TFBody();
            }
        }

        public Answers[] answers=new Answers[6];       

        override public void MCQBody()
        {
            string Question;
            
            Console.WriteLine("Please Enter Question Body: " );

            Question=Console.ReadLine();
            answers[0] = new Answers { Answer_Text = Question, Answer_Id = 0 };

            bool Flag=false;
            int y = Mark;

            do
            {
                Console.WriteLine("Please Enter Question Mark: ");
                Flag = int.TryParse(Console.ReadLine(), out y);
            } while (!Flag || Mark<0);

            Marks[Index] = y;
            Index++;

            Console.WriteLine("Please Enter Choices Of The Question: ");

            for (int i = 1; i <= 4; i++) 
            {
                Console.WriteLine($"Please Enter Choice Number {i}: "); 
                string choice = Console.ReadLine();
                answers[i] = new Answers { Answer_Text = choice, Answer_Id = i}; 
            }

            bool Flag2 = false;
            int Ans_Id = 0,x=0;

            do
            {
                Console.WriteLine("Please Enter Answer Id: ");
                Flag2 = int.TryParse(Console.ReadLine(), out Ans_Id);
            } while (!Flag2 || Ans_Id < 1 || Ans_Id > 4);

            answers[5] = new Answers { Answer_Text = $"{Ans_Id}", Answer_Id = Ans_Id };

        }
        public Answers[] answers2 = new Answers[2];
        public override void TFBody()
        {
            string Question;
            
            Console.WriteLine("Please Enter Question Body: ");

            Question = Console.ReadLine();
            answers2[0] = new Answers { Answer_Text = Question, Answer_Id = 0 };



            bool Flag = false;
            int y = Mark;
            do
            {
                Console.WriteLine("Please Enter Question Mark: ");
                Flag = int.TryParse(Console.ReadLine(), out y);
            } while (!Flag || Mark < 0);

            Marks[Index] = y;
            Index++;

            bool Flag2 = false;
            int Ans_Id = 0,x=0;

            do
            {
                Console.WriteLine("Please Enter Answer Id (1 For True | 2 For False) ");
                Flag2 = int.TryParse(Console.ReadLine(), out Ans_Id); 
            } while (!Flag2 || (Ans_Id != 1 && Ans_Id != 2));

            answers2[1] = new Answers { Answer_Text = $"{Ans_Id}", Answer_Id = Ans_Id };


        }
   
        public void ShowExam() {


            for (int i = 0; i < Index; i++)
            {


                if (Headerr == 1)
                {
                    Console.WriteLine($"{answers[0].Answer_Text}          Mark: {Marks[i]} ");
                    for (int j = 1; j <= 4; j++)
                    {
                        Console.WriteLine($"{j}- {answers[j].Answer_Text}");
                    }

                }
                else
                {
                    Console.WriteLine($"{answers2[0].Answer_Text}          Mark: {Marks[i]} ");

                    Console.WriteLine("1- True");
                    Console.WriteLine("2- False");

                    Console.WriteLine("Please Enter 1 For True | 2 For False");

                }



            }

        
        }

        
    }
}
