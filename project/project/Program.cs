using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using static Game;
class Player
{
    
    string name;
    public void SetName()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("Як тебе звати?");
        name = Console.ReadLine();
        Console.WriteLine("Натисни будь-яку клавішу, щоб продовжити");
        Console.ReadKey();
        Console.Clear();
    }
    public string GetName()
    {
        return name;
    }
    public void Print()
    {
        Console.WriteLine($"Привіт {name}");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Введіть 1 якщо хочеш почати гру та 2 якщо хочет подивитися інформацію по грі");
        string input = Console.ReadLine();
        int num = 0;
        int.TryParse(input, out num);
        Console.Clear();
        if (num == 1)
        {
            Start start = new Start();
            start.start();
        }
        else if (num == 2)
        {
            Money_Enemy money_Enemy = new Money_Enemy();
            money_Enemy.SetMoney_Enemy();
            money_Enemy.GetMoney_Enemy();

            Standart_Enemy standart_Enemy = new Standart_Enemy();
            standart_Enemy.SetStandart_Enemy();
            standart_Enemy.GetStandart_Enemy();

            Energy_Enemy energy_Enemy = new Energy_Enemy();
            energy_Enemy.SetEnergy_Enemy();
            energy_Enemy.GetEnergy_Enemy();

            Wall wall = new Wall();
            wall.SetWall();
            wall.GetWall();

            Coin coin = new Coin();
            coin.SetCoin();
            coin.GetCoin();

            Heart heart = new Heart();
            heart.SetHeart();
            heart.GetHeart();

            Console.ReadKey();
            Console.Clear();
            Start start = new Start();
            start.start();
        }
        else
        {
            Console.WriteLine("Ви ввели невірне число. Будь ласка, введіть 1 або 2.");

        }
    }
}
class Game
{

    //Штуки на карте
    public enum GameObject
    {
        HALL,
        WALL,
        COIN,
        ENEMY,
        HEALTH,
        ENERGY,
        ENERGY_ENEMY,
        MONEY_ENEMY
    };
    // Кнопки
    public enum Key
    {
        LEFT = 'a',
        RIGHT = 'd',
        UP = 'w',
        DOWN = 's',
    }
}
class Enemy
{

    public string name;
    public string skill;

    public void Getname()
    {
        Console.WriteLine(name);
    }
    public void Getskill()
    {
        Console.WriteLine(skill);
    }
}

class Standart_Enemy : Enemy
{
    public void SetStandart_Enemy()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("О");
        Console.ResetColor();
        name = "Ворог";
        skill = "Стандартний ворог який забирає 1 сердце.";
    }
    public void GetStandart_Enemy()
    {
        Console.WriteLine(name);
        Console.WriteLine(skill);
    }
}

class Money_Enemy : Enemy
{
    public void SetMoney_Enemy()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("О");
        Console.ResetColor();
        name = "Монетний ворог";
        skill = "Забирає з вашего кормана 10 монет якщо у вас буде меньш 10 то может попасти в борги.";

    }
    public void GetMoney_Enemy()
    {
        Console.WriteLine(name);
        Console.WriteLine(skill);
    }
}

class Energy_Enemy : Enemy
{
    public void SetEnergy_Enemy()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("О");
        Console.ResetColor();
        name = "Енергітичний ворог ";
        skill = "Забирає з вашего кормана 19 єнергії якщо у вас буде меньш 19 то ви програйте.";

    }
    public void GetEnergy_Enemy()
    {
        Console.WriteLine(name);
        Console.WriteLine(skill);
    }
}

class Object
{
    public string name;
    public string information;
}

class Wall : Object
{
    public void SetWall()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("█");
        Console.ResetColor();
        name = "Стіна ";
        information = "Просто стіна не дає проходу.";

    }
    public void GetWall()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}

class Energy : Object
{
    public void SetEnergy()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("О");
        Console.ResetColor();
        name = "Енергія ";
        information = "Дає 51 енергію.";

    }
    public void GetEnergy()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}
class Coin : Object
{
    public void SetCoin()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("О");
        Console.ResetColor();
        name = "Монета ";
        information = "Дає + 1 монету.";
    }
    public void GetCoin()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}
class Heart : Object
{
    public void SetHeart()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("О");
        Console.ResetColor();
        name = "Серце  ";
        information = "Дає + 1 серце.";
    }
    public void GetHeart()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}

public class DrawLabirint
{
    const int HEIGHT = 25;
    const int WIDTH = 65;
    public int[,] map = new int[HEIGHT, WIDTH];

    public DrawLabirint()
    {
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[y, x] = 1;
                else
                    map[y, x] = 0;
            }
        }
    }

    public void Draw()
    {
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                if (map[y, x] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
class Go
{
    public int X;
    public int Y;
    private int prevX;
    private int prevY;
    private int[,] map;


    public Go(int startX, int startY, int[,] mapRef)
    {
        X = prevX = startX;
        Y = prevY = startY;
        map = mapRef;
    }

    public void Move(Key key)
    {
        prevX = X;
        prevY = Y;

        int newX = X;
        int newY = Y;

        switch (key)
        {
            case Key.LEFT: newX--; break;
            case Key.RIGHT: newX++; break;
            case Key.UP: newY--; break;
            case Key.DOWN: newY++; break;
        }

        if (map[newY, newX] != 1)
        {
            X = newX;
            Y = newY;
        }
    }


    public void Draw()
    {
        Console.SetCursorPosition(prevX, prevY);
        Console.Write(' ');


        Console.SetCursorPosition(X, Y);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write('O');
        Console.ResetColor();
    }
}
class Start
{
    public void start()
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        DrawLabirint lab = new DrawLabirint();
        lab.Draw();

        Go player = new Go(2, 2, lab.map);

        while (true)
        {
            player.Draw();

            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                char c = char.ToLower(keyInfo.KeyChar);

                if (Enum.IsDefined(typeof(Key), (int)c))
                    player.Move((Key)c);
            }
        }

    }
}
class Program
{
    static void Main()
    {
        Player players = new Player();       
        players.SetName();
        players.Print();


    }
}

