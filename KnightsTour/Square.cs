using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    class Square
    {
        public bool Visited { get; set; }
        public int Step { get; set; }

        public Square()
        {
            Visited = false;
            Step = -1;
        }
    }
}
