using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Model
{
    public class Game
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public Platform Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Status Status { get; set; }
        public TimeSpan TimePlayed { get; set; }
        public ICollection<Achievement> Achivements { get; set; }
        public bool Remake { get; set; } 
    }

    public enum Status
    {
        Bought,
        Played,
        Finished,
        Completed
    }
}
