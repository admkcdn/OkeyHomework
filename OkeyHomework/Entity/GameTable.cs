using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeyHomework.Entity
{
    public class GameTable
    {
        public List<Player> Players { get; set; }
        public List<string> GameStonesInTable { get; set; } = new List<string>();
    }
}
