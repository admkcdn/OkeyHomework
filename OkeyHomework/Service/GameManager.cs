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


            for (int i = 0; i < gameTable.Players.Count ; i++)
            {
                for (int j = 0; j < gameTable.Players[i].GameStones.Count-2; j++)
                {
                    if (gameTable.Players[i].GameStones[j] != "*")
                    {
                        var c1 = gameTable.Players[i].GameStones[j].Split(" ");
                        if (gameTable.Players[i].GameStones[j + 1] != "*")
                        {
                            var c2 = gameTable.Players[i].GameStones[j + 1].Split(" ");
                            if (gameTable.Players[i].GameStones[j + 2] != "*")
                            {
                                var c3 = gameTable.Players[i].GameStones[j + 2].Split(" ");
                                if (c1[0] == c2[0] && c1[0] == c3[0])
                                {
                                    if (Convert.ToInt32(c1[1]) + 1 == Convert.ToInt32(c2[1]) && Convert.ToInt32(c2[1]) + 1 == Convert.ToInt32(c3[1]))
                                    {
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j]);
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j + 1]);
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j + 2]);
                                        int total = Convert.ToInt32(c1[1]) + Convert.ToInt32(c2[1]) + Convert.ToInt32(c3[1]);
                                        gameTable.Players[i].Score += total;
                                    }
                                    else if (Convert.ToInt32(c1[1]) - 1 == Convert.ToInt32(c2[1]) && Convert.ToInt32(c2[1]) - 1 == Convert.ToInt32(c3[1]))
                                    {
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j]);
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j + 1]);
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j + 2]);
                                        int total = Convert.ToInt32(c1[1]) + Convert.ToInt32(c2[1]) + Convert.ToInt32(c3[1]);
                                        gameTable.Players[i].Score += total;
                                    }
                                }
                                else if (c1[0] != c2[0] && c2[0] != c3[0])
                                {
                                    if (Convert.ToInt32(c1[1]) == Convert.ToInt32(c2[1]) && Convert.ToInt32(c2[1]) == Convert.ToInt32(c3[1]))
                                    {
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j]);
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j + 1]);
                                        gameTable.Players[i].Per.Add(gameTable.Players[i].GameStones[j + 2]);
                                        int total = Convert.ToInt32(c1[1]) + Convert.ToInt32(c2[1]) + Convert.ToInt32(c3[1]);
                                        gameTable.Players[i].Score += total;
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine(gameTable.Players[i].Score);
                //Console.WriteLine(gameTable.Players[i].Per);
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
