using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    internal class Question
    {
        public int Mark { get; set; }


        public virtual void Header() { }


        public virtual void MCQBody() { }

        public virtual void TFBody() { }

    }
}
