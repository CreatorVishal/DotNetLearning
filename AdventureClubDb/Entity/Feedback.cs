using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureClubDb.Entity
{
    internal class Feedback
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating{ get; set; }
    }
}
