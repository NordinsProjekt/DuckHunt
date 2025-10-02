using DuckHunt.ScreenWriters;

namespace DuckHunt;

public class Player(ConsoleWriter ConsoleWriter)
{
    private int Ammo { get; set; } = 2;
    private int Score { get; set; } = 0;

    public int Shoot(Duck duck)
    {
        if (Ammo > 0)
        {
            Ammo--;
            Console.WriteLine($"Bang! You have {Ammo} bullets left.");
            var hpLeft = duck.Hit();
            if (hpLeft <= 0)
            {
                Score += duck.GetScore();
                Console.WriteLine("You killed the duck!");
            }
            else
            {
                Console.WriteLine($"The duck has {hpLeft} HP left.");
                return hpLeft;
            }
        }
        else
        {
            Score--;
            Console.WriteLine("Click! You have no bullets left");
        }

        return -1;
    }

    public void Reload()
    {
        if (Ammo != 0)
        {
            Score--;
            Console.WriteLine($"You still have {Ammo} bullets left, you lose 1 point.");
            return;
        }

        Ammo = 2;
        Console.WriteLine("You reload the shotgun.");
    }

    public int GetScore()
    {
        return Score;
    }
}