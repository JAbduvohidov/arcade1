using System;
using System.Collections.Generic;
using System.Drawing;

namespace Arcade1
{
    public class Avatar
    {
        private Point Position { get; set; }
        private ConsoleColor Color { get; init; }

        private Map Map { get; init; }

        private int Keys { get; set; }

        public Avatar(ref Map map)
        {
            Position = new Point(1, 1);
            Color = ConsoleColor.White;
            Map = map;
        }

        public void MoveLeft() => Move(Position.X - 1, Position.Y);

        public void MoveRight() => Move(Position.X + 1, Position.Y);

        public void MoveUp() => Move(Position.X, Position.Y - 1);

        public void MoveDown() => Move(Position.X, Position.Y + 1);

        private void Move(int x, int y)
        {
            if (x < 0 || y < 0) return;

            switch (Map.Shape[y][x])
            {
                case '▓':
                    Console.SetCursorPosition(x, y);
                    Map.Shape[y] = Map.Shape[y].Remove(x, 1);
                    Map.Shape[y] = Map.Shape[y].Insert(x, "▒");
                    Console.Write("▒");
                    return;
                case '▒':
                    Console.SetCursorPosition(x, y);
                    Map.Shape[y] = Map.Shape[y].Remove(x, 1);
                    Map.Shape[y] = Map.Shape[y].Insert(x, "t");
                    Console.Write("t");
                    return;
                case '░':
                    Console.SetCursorPosition(x, y);
                    Map.Shape[y] = Map.Shape[y].Remove(x, 1);
                    Map.Shape[y] = Map.Shape[y].Insert(x, " ");
                    Console.Write(" ");
                    return;
                case '▧':
                    Console.SetCursorPosition(x, y);
                    Map.Shape[y] = Map.Shape[y].Remove(x, 1);
                    Map.Shape[y] = Map.Shape[y].Insert(x, "k");
                    Console.Write("k");
                    return;
                case 'k':
                    Console.SetCursorPosition(x, y);
                    Map.Shape[y] = Map.Shape[y].Remove(x, 1);
                    Map.Shape[y] = Map.Shape[y].Insert(x, " ");
                    Console.Write(" ");
                    Keys++;
                    return;
            }

            if (y==5 && x == 26 && $"{Map.Shape[y][x]}{Map.Shape[y][x+1]}" == "🚪")
            {
                if (Keys <= 0) return;

                Console.Clear();
                Console.WriteLine("Game over! You won");
                return;
            }

            if (Map.Shape[y][x] == 't')
            {
                Console.Clear();
                Console.WriteLine("Game over! You are dead ☠️");
                return;
            }

            if (Map.Shape[y][x] != ' ') return;

            var oldPosition = Position;
            try
            {
                Clear();
                Position = new Point(x, y);
                Draw();
            }
            catch (Exception)
            {
                Clear();
                Position = oldPosition;
                Draw();
            }
        }

        private void Clear()
        {
            Console.ResetColor();
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(" ");
        }

        private void Draw()
        {
            Console.ResetColor();
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = Color;
            Console.Write("@");
        }
    }

    public class Map
    {
        public List<string> Shape { get; private set; }

        public Map()
        {
            Shape = new List<string>
            {
                "╭───┬┬────┬────────────────╮",
                "│   ││░░░░╰╮░░░░░░░░░░░░░░░│",
                "├─╮ ╰╯ ╭╮░░╰─╮░░░▓░░╭╭╭╭╮▓░│",
                "│▓│    │╰╮░▓╔╛  ▓   │▓▓░│▓▧│",
                "│░╰────╯ │ ╭╬╮ ╭─╮░▓│░▓▓╰──┤",
                "│  ▓░░░    ╰─╯ │░│▓▓│░░░░░🚪",
                "│        │     │░╰──╯░░░░░╭│",
                "│░░╭───╮ ╰─────╯░░░░░░░░░╭╯│",
                "│▓▓│░░░│░░░░░░░░░░▓▓▓▓░▓▓│░│",
                "╰──┴───┴─────────────────┴─╯",
            };
        }

        public void Draw()
        {
            Shape.ForEach(Console.WriteLine);
        }
    }
}