using RoShamBo5.Tiles;
using System;
using System.Collections.Generic;

namespace RoShamBo5
{
    internal class Program
    {
        private static Player Player1 = new Player();
        private static Player Player2 = new Player();
        private static int Ties = 0;

        public static void Main()
        {
            InitTiles();
            int turn = 1;
            bool winner = false;
            while (!winner)
            {
                Console.WriteLine($"Turn: {turn}");
                Player1Choose();
                Player2Choose();
                PlayTurn();

                if (CheckTie()) return;

                Console.WriteLine();
                turn++;
                winner = CheckWin();
            }
            if (Player1.Lost)
                Console.WriteLine("Player 2 Wins!");
            else
                Console.WriteLine("Player 1 Wins!");
        }

        public static bool CheckTie()
        {
            if (Ties >= 3)
            {
                if (Player1.Count() > Player2.Count())
                {
                    Player1.Lost = true;
                    Console.WriteLine("There have been too many consecutive ties. Player 2 Wins!");
                }
                else
                {
                    Player2.Lost = true;
                    Console.WriteLine("There have been too many consecutive ties. Player 1 Wins!");
                }
                return true;
            }
            return false;
        }

        private static bool CheckWin()
        {
            if (Player1.Count() <= 0)
            {
                Player1.Lost = true;
                return true;
            }

            if (Player2.Count() <= 0)
            {
                Player2.Lost = true;
                return true;
            }

            return false;
        }

        public static void InitTiles()
        {
            var temp = new List<Tile>();
            temp.Add(new Tile1() { Quantity = 2 });
            temp.Add(new Tile2() { Quantity = 2 });
            temp.Add(new Tile3() { Quantity = 2 });
            temp.Add(new Tile4() { Quantity = 2 });
            temp.Add(new Tile5() { Quantity = 2 });

            Player1.Hand = temp;

            temp = new List<Tile>();
            temp.Add(new Tile1() { Quantity = 2 });
            temp.Add(new Tile2() { Quantity = 2 });
            temp.Add(new Tile3() { Quantity = 2 });
            temp.Add(new Tile4() { Quantity = 2 });
            temp.Add(new Tile5() { Quantity = 2 });
            Player2.Hand = temp;
        }

        public static void PlayTurn()
        {
            if (Player1.Left.Equals(Player2.Left))
            {//left tie
                Console.WriteLine("Left Hand Tie");
                foreach (var tile in Player1.Hand)
                {
                    if (tile.Equals(Player1.Left))
                        tile.Quantity++;
                }

                foreach (var tile in Player2.Hand)
                {
                    if (tile.Equals(Player2.Left))
                        tile.Quantity++;
                }

                if (Player1.Right.Equals(Player2.Right))
                {//left and right tie
                    Console.WriteLine($"Left And Right Hand Tie {Ties + 1}/3 Consecutive Ties Used");
                    foreach (var tile in Player1.Hand)
                    {
                        if (tile.Equals(Player1.Right))
                            tile.Quantity++;
                    }

                    foreach (var tile in Player2.Hand)
                    {
                        if (tile.Equals(Player2.Right))
                            tile.Quantity++;
                    }

                    Ties++;
                    return;
                }
            }
            else
            {
                Ties = 0;
                if (Player1.Left.Win(Player2.Left))
                {//Player 1 wins left
                    Console.WriteLine("Player 1 wins the Left Hand");
                    foreach (var tile in Player1.Hand)
                    {
                        if (tile.Equals(Player1.Left))
                            tile.Quantity++;
                        if (tile.Equals(Player2.Left))
                            tile.Quantity++;
                    }
                }
                else
                {//Player 2 wins left
                    Console.WriteLine("Player 2 wins the Left Hand");
                    foreach (var tile in Player2.Hand)
                    {
                        if (tile.Equals(Player2.Left))
                            tile.Quantity++;
                        if (tile.Equals(Player1.Left))
                            tile.Quantity++;
                    }
                }
            }

            if (Player1.Right.Equals(Player2.Right))
            {//Right Tie
                Console.WriteLine("Right Hand Tie");
                foreach (var tile in Player1.Hand)
                {
                    if (tile.Equals(Player1.Right))
                        tile.Quantity++;
                }

                foreach (var tile in Player2.Hand)
                {
                    if (tile.Equals(Player2.Right))
                        tile.Quantity++;
                }
            }
            else if (Player1.Right.Win(Player2.Right))
            {//Player 1 wins Right
                Console.WriteLine("Player 1 wins the Right Hand");
                foreach (var tile in Player1.Hand)
                {
                    if (tile.Equals(Player1.Right))
                        tile.Quantity++;
                    if (tile.Equals(Player2.Right))
                        tile.Quantity++;
                }
            }
            else
            {//Player 2 Wins Right
                Console.WriteLine("Player 2 wins the Right Hand");
                foreach (var tile in Player2.Hand)
                {
                    if (tile.Equals(Player2.Right))
                        tile.Quantity++;
                    if (tile.Equals(Player1.Right))
                        tile.Quantity++;
                }
            }
        }

        public static void Player1Choose()
        {
            var p1Left = false;
            while (!p1Left)
            {
                Console.WriteLine("Player 1 Left Hand");
                var input = Console.ReadLine();

                try
                {
                    if (int.Parse(input) > 0 && int.Parse(input) < 6)
                    {
                        if (Player1.Hand[int.Parse(input) - 1].Quantity > 0)
                        {
                            Player1.Left = Player1.Hand[int.Parse(input) - 1];
                            Player1.Hand[int.Parse(input) - 1].Quantity--;
                            p1Left = true;
                        }
                        else Console.WriteLine("You don't have any of those, please choose something else.");
                    }
                    else Console.WriteLine("Must be a number between 1 and 5");
                }
                catch (FormatException) { Console.WriteLine("Must be a number between 1 and 5"); }
            }
            var p1Right = false;
            while (!p1Right)
            {
                Console.WriteLine("Player 1 Right Hand");
                var input = Console.ReadLine();

                try
                {
                    if (int.Parse(input) > 0 && int.Parse(input) < 6)
                    {
                        if (Player1.Hand[int.Parse(input) - 1].Quantity > 0)
                        {
                            Player1.Right = Player1.Hand[int.Parse(input) - 1];
                            Player1.Hand[int.Parse(input) - 1].Quantity--;
                            p1Right = true;
                        }
                        else Console.WriteLine("You don't have any of those, please choose something else.");
                    }
                    else Console.WriteLine("Must be a number between 1 and 5");
                }
                catch (FormatException) { Console.WriteLine("Must be a number between 1 and 5"); }
            }
        }

        public static void Player2Choose()
        {
            var p2Left = false;
            while (!p2Left)
            {
                Console.WriteLine("Player 2 Left Hand");
                var input = Console.ReadLine();

                try
                {
                    if (int.Parse(input) > 0 && int.Parse(input) < 6)
                    {
                        if (Player2.Hand[int.Parse(input) - 1].Quantity > 0)
                        {
                            Player2.Left = Player2.Hand[int.Parse(input) - 1];
                            Player2.Hand[int.Parse(input) - 1].Quantity--;
                            p2Left = true;
                        }
                        else Console.WriteLine("You don't have any of those, please choose something else.");
                    }
                    else
                        Console.WriteLine("Must be a number between 1 and 5");
                }
                catch (FormatException) { Console.WriteLine("Must be a number between 1 and 5"); }
            }
            var p2Right = false;
            while (!p2Right)
            {
                Console.WriteLine("Player 2 Right Hand");
                var input = Console.ReadLine();

                try
                {
                    if (int.Parse(input) > 0 && int.Parse(input) < 6)
                    {
                        if (Player2.Hand[int.Parse(input) - 1].Quantity > 0)
                        {
                            Player2.Right = Player2.Hand[int.Parse(input) - 1];
                            Player2.Hand[int.Parse(input) - 1].Quantity--;
                            p2Right = true;
                        }
                        else Console.WriteLine("You don't have any of those, please choose something else.");
                    }
                    else Console.WriteLine("Must be a number between 1 and 5");
                }
                catch (FormatException) { Console.WriteLine("Must be a number between 1 and 5"); }
            }
        }
    }
}