using OkeyHomework.Entity;
using OkeyHomework.Service;
using System;
using System.Collections.Generic;

namespace OkeyHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();
            Player player4 = new Player();
            List<Player> players = new List<Player>{ player1, player2, player3, player4 };
            gameManager.CreateTable(players);
            gameManager.DealStones();

            for (int i = 0; i < player1.GameStones.Count; i++)
            {
                Console.WriteLine(player1.GameStones[i]);
            }
            Console.WriteLine("player1 kart: " + player1.GameStones.Count);
            Console.WriteLine("player2 kart: " + player2.GameStones.Count);
            Console.WriteLine("player3 kart: " + player3.GameStones.Count);
            Console.WriteLine("player4 kart: " + player4.GameStones.Count);

        }
    }
}
