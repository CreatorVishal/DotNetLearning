using System;
using System.Collections.Generic;
using System.Text;


namespace ReviseEFagain.Entity
{
    public class MovieDetail
    {
        public int Id { get; set; }

        public string Director { get; set; }

        public decimal Budget { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}

