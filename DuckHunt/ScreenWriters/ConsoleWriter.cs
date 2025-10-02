using System;
using System.Collections.Generic;
using System.Text;

namespace DuckHunt.ScreenWriters;

public class ConsoleWriter
{
    public void StartMenu()
    {
        Console.WriteLine("..::DUCK HUNT::..");
        Console.WriteLine("To shoot a duck, type bang");
        Console.WriteLine("To reload your gun, type reload");
        Console.WriteLine("To quit, type quit\n\n");
        Console.WriteLine("Only shoot if a duck makes its presence known!");
        Console.WriteLine("Some ducks has more than 1 HP");
        Console.WriteLine("Reloading only when gun is empty, otherwise you will lose points!");
        Console.WriteLine("Good luck!\n\n");
    }

    public void GameOver()
    {
        ClearScreen();
        Console.WriteLine("Game Over!");
    }

    public void WrongCommand()
    {
        Console.WriteLine("The command is invalid");
    }

    public void ClearScreen()
    {
        Console.Clear();
    }

    public void DuckAppears(Duck duck)
    {
        Console.WriteLine(duck.Speak());
    }

    public void NoDucks()
    {
        Console.WriteLine("There are no ducks to shoot!");
    }
}
