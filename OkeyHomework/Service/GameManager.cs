using OkeyHomework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OkeyHomework.Service
{
    public class GameManager
    {
        GameTable gameTable = new GameTable();
        Random random = new Random();

        public void CreateTable(List<Player> players)
        {
            gameTable.Players = players;
            CreateStones();
        }

        public void DealStones()
        {
            string stoneCache = "";

            for (int i = 0; i < gameTable.Players.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    stoneCache = gameTable.GameStonesInTable[gameTable.GameStonesInTable.Count - 1];
                    gameTable.Players[i].GameStones.Add(stoneCache);
                    gameTable.GameStonesInTable.Remove(stoneCache);
                }
            }

            for (int i = 0; i < gameTable.Players.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    stoneCache = gameTable.GameStonesInTable[gameTable.GameStonesInTable.Count - 1];
                    gameTable.Players[i].GameStones.Add(stoneCache);
                    gameTable.GameStonesInTable.Remove(stoneCache);
                }
            }

            int n = gameTable.GameStonesInTable.Count;
            for (int u = 0; u < 17; u++)
            {
                for (int i = 0; i < gameTable.Players.Count; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        stoneCache = gameTable.GameStonesInTable[gameTable.GameStonesInTable.Count - 1];
                        gameTable.Players[i].GameStones.Add(stoneCache);
                        gameTable.GameStonesInTable.Remove(stoneCache);
                    }
                }
            }

            stoneCache = gameTable.GameStonesInTable[gameTable.GameStonesInTable.Count - 1];
            gameTable.Players[0].GameStones.Add(stoneCache);
            gameTable.GameStonesInTable.Remove(stoneCache);
            stoneCache = gameTable.GameStonesInTable[gameTable.GameStonesInTable.Count - 1];
            gameTable.Players[1].GameStones.Add(stoneCache);
            gameTable.GameStonesInTable.Remove(stoneCache);
        }

        public void CalculateScore()
        {
            List<string> cacheStones = new List<string>();
            bool perType = false;
            for (int i = 0; i < gameTable.Players.Count; i++)
            {
            loop: for (int j = 0; j < gameTable.Players[i].GameStones.Count; j++)
                {
                    if (cacheStones.Count == 0)
                    {
                        cacheStones.Add(gameTable.Players[i].GameStones[j]);
                        goto loop;
                    }
                    if (cacheStones[cacheStones.Count-1] == "*" && gameTable.Players[i].GameStones[j]=="*")
                    {

                    }
                    else
                    {
                        var cs = cacheStones[cacheStones.Count - 1].Split(" ");
                        var ts = gameTable.Players[i].GameStones[j].Split(" ");
                        if (cs[0] == ts[0])
                        {
                            if (Convert.ToInt32(cs[1]) == Convert.ToInt32(ts[1])+1)
                            {

                            }
                        }
                    }
                    
                }
            }
        }

        private void CreateStones()
        {
            string[] colors = { "Kırmızı ", "Sarı ", "Siyah ", "Mavi " };

            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    gameTable.GameStonesInTable.Add(colors[i] + j.ToString());
                    gameTable.GameStonesInTable.Add(colors[i] + j.ToString());
                }
            }
            gameTable.GameStonesInTable.Add("*");
            gameTable.GameStonesInTable.Add("*");

            int n = gameTable.GameStonesInTable.Count;
            string cache = "";
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                cache = gameTable.GameStonesInTable[k];
                gameTable.GameStonesInTable[k] = gameTable.GameStonesInTable[n];
                gameTable.GameStonesInTable[n] = cache;
            }
        }
    }
}
