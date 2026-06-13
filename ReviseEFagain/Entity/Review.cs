using System;
using System.Collections.Generic;
using System.Text;

namespace ReviseEFagain.Entity
{
    public class Review
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
