using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Homework_1
{
    class Square : Rectangle // Breaks SOLID principles
    {
        public Square(double side) : base(side, side)
        {
        }
    }
}
