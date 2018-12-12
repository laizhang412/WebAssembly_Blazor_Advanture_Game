using System;
using System.Collections.Generic;
using System.Text;

namespace Advanture_Game.Shared
{
    public class Step
    {
        public int x { get; set; }
        public int y { get; set; }
        public int remain { get; set; }
        public int difficulty { get; set; }
        public bool alive { get; set; }
    }
}
