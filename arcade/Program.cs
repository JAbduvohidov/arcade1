using System;
using Arcade1;

namespace arcade
{
    internal static class Program
    {
        private static bool _isRunning = true;

        private static void Main()
        {
            var map = new Map();
            var avatar = new Avatar(ref map);
            Console.CursorVisible = false;
            Console.Clear();
            map.Draw();

            avatar.MoveRight();


            while (_isRunning)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W or ConsoleKey.UpArrow:
                    {
                        avatar.MoveUp();
                        break;
                    }
                    case ConsoleKey.S or ConsoleKey.DownArrow:
                    {
                        avatar.MoveDown();
                        break;
                    }
                    case ConsoleKey.A or ConsoleKey.LeftArrow:
                    {
                        avatar.MoveLeft();
                        break;
                    }
                    case ConsoleKey.D or ConsoleKey.RightArrow:
                    {
                        avatar.MoveRight();
                        break;
                    }
                    case ConsoleKey.Escape:
                    {
                        Console.Clear();
                        _isRunning = false;
                        return;
                    }
                }
            }
        }
    }
}