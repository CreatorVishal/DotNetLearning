using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureClubDb.Entity
{
    internal class Guide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExperienceYears { get; set; } 
        public List<AdventureTrip> AdventureTrips { get; set; }
    }
}
