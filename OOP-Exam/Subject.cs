using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{

    internal class Subject : Exam
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Final[] FinalExams { get; set; } 
        public Practical[] PractExams { get; set; } 

        public new int NumberOfQuestions { get; set; }

        public int[] Answers { get; set; }

        public Subject() 
        {       
        
        }
        public Subject(int subId, string subName)
        {
            SubjectId = subId;
            SubjectName = subName;     
        }

        int x,y=0;
        public void CreateExam()
        {
            bool flag = false;
            int examType;

            do
            {
                Console.WriteLine("Please Enter The Type Of The Exam (1 For Practical | 2 For Final): ");
                flag = int.TryParse(Console.ReadLine(), out examType);
            } while (!flag || (examType != 1 && examType != 2));

            ExamDetails(); 

            Console.WriteLine("Enter The Number Of The Questions: ");

            bool Flag2 = false;
            
            do
            {
                Flag2 = int.TryParse(Console.ReadLine(), out x);
            } while (!Flag2);
            y = x;
            NumberOfQuestions = x;
            Answers= new int[NumberOfQuestions];
   

            if (examType == 1)
            {
                PractExams = new Practical[NumberOfQuestions]; 
                for (int i = 0; i < NumberOfQuestions; i++)
                {
                   
                    PractExams[i] = new Practical(NumberOfQuestions);
                    PractExams[i].Header();
                }
            }
            else
            {
                FinalExams = new Final[NumberOfQuestions]; 
                for (int i = 0; i < NumberOfQuestions; i++)
                {
                    
                    FinalExams[i] = new Final(NumberOfQuestions);
                    FinalExams[i].Header(); 
                }
            }

           
        }

        
       
        
        public void SubjectDetails()
        {
            Console.Clear();
            Console.WriteLine($"Subject Id: {SubjectId}");
            Console.WriteLine($"Subject Name: {SubjectName}");
            ShowExamDetails();

            Console.WriteLine($"The Number Of The Questions: {NumberOfQuestions}");

            if (FinalExams != null)
            {
                Console.WriteLine("Final Exam Details:");
                for (int i = 0; i < FinalExams.Length; i++)
                {
                    Console.WriteLine($"Question {i + 1}:");
                    FinalExams[i].ShowExam();
                    bool flag = false;
                    int answer;

                    if (FinalExams[i].Headerr == 1) 
                    {

                        do
                        {
                            Console.WriteLine("Please Enter The Correct Answer: ");
                            flag = int.TryParse(Console.ReadLine(), out answer);
                        } while (!flag || answer < 1 || answer > 4);
                        Answers[i] = answer;

                    }
                    else
                    {

                        do
                        {                           
                            flag = int.TryParse(Console.ReadLine(), out answer);
                        } while (!flag || (answer != 1 && answer != 2));
                        Answers[i] += answer;
                        Console.WriteLine();

                    }
                   
                }
                Console.WriteLine();
                Console.WriteLine(".........Best Wishes........");
                Console.WriteLine();
            }
            else if (PractExams != null)
            {
                Console.WriteLine("Practical Exam Details:");
                for (int i = 0; i < PractExams.Length; i++)
                {
                    Console.WriteLine($"Question {i + 1}:");
                    PractExams[i].ShowExam();

                    bool Flag = false;
                    int answer;
                    do
                    {
                        Console.WriteLine("Please Enter The Correct Answer: ");
                        Flag = int.TryParse(Console.ReadLine(), out answer);
                    } while (!Flag || answer < 1 || answer > 4);
                    Answers[i] += answer;
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine(".........Best Wishes........");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There Is No Exam.");
            }

            Console.WriteLine();
            Console.WriteLine("Show My Results (Y/N)");
            Console.WriteLine();
            String Press = Console.ReadLine();

            if (Press == "Y" || Press == "y")
            {
                ShowResults();
            }
            else if (Press == "N" || Press == "n")
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Please Enter Letter Y Or N");
            }
        }

        public void ShowResults()
        {

            Console.Clear();

            if (FinalExams != null)
            {

                for (int i = 0; i < FinalExams.Length; i++)
                {
                    if (FinalExams[i].Headerr == 1)
                    {
                        Console.WriteLine($"Question: {FinalExams[i].answers[0].Answer_Text}");
                        Console.WriteLine();
                        int userAnswerId = Answers[i];
                        string userAnswerText = FinalExams[i].answers[userAnswerId].Answer_Text;
                        Console.Write($"Your Answer: {userAnswerText}");
                        Console.WriteLine();
                        int correctAnswerId = FinalExams[i].answers[5].Answer_Id;
                        string correctAnswerText = FinalExams[i].answers[correctAnswerId].Answer_Text;
                        Console.WriteLine($"Right Answer: {correctAnswerText}");
                        Console.WriteLine();

                    }
                    else
                    {

                        Console.WriteLine($"Question: {FinalExams[i].answers2[0].Answer_Text}");
                        Console.WriteLine();
                        int userAnswerId = Answers[i];
                        string userAnswerText = (userAnswerId == 1) ? "True" : "False";
                        Console.Write($"Your Answer: {userAnswerText}");
                        Console.WriteLine();

                        int correctAnswerId = FinalExams[i].answers2[1].Answer_Id;
                        string correctAnswerText = (correctAnswerId == 1) ? "True" : "False";
                        Console.WriteLine($"Right Answer: {correctAnswerText}");
                        Console.WriteLine();

                    }

                }
                Console.WriteLine();
                Console.WriteLine("Thank You");

            }
            else if (PractExams != null)
            {
                for (int i = 0; i < PractExams.Length; i++)
                {
                    Console.WriteLine($"Question: {PractExams[i].answers3[0].Answer_Text}");
                    Console.WriteLine();
                    int userAnswerId = Answers[i];
                    string userAnswerText = PractExams[i].answers3[userAnswerId].Answer_Text;
                    Console.Write($"Your Answer: {userAnswerText}");
                    Console.WriteLine();
                    int correctAnswerId = PractExams[i].answers3[5].Answer_Id;
                    string correctAnswerText = PractExams[i].answers3[correctAnswerId].Answer_Text;
                    Console.WriteLine($"Right Answer: {correctAnswerText}");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Thank You");

            }
        }
    }
}
