using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureClubDb.Entity
{
    internal class AdventureTrip
    {
        public int Id { get; set; }
        public string TripName{ get; set; }
        public string Location { get; set; }
        public int Cost { get; set; }

    }
}
