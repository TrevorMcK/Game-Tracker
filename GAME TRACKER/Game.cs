using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME_TRACKER
{
    public class Game
    {
        public int gameId { get; set; }
        public string name { get; set; }
        public string system { get; set; }
        public int year { get; set; }

        public Game(int GameId, string Name, string System, int Year)
        {
            gameId = GameId;
            name = Name;
            system = System;
            year = Year;
        }
    }
}
