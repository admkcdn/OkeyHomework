using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeyHomework.Entity
{
    public class Player
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<string> GameStones { get; set; } = new List<string>();
        public List<string> Per { get; set; } = new List<string>();
        public int Score { get; set; } = 0;
    }
}
