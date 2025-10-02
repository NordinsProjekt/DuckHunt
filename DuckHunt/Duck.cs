using System;
using System.Collections.Generic;
using System.Text;

namespace DuckHunt;

public class Duck(int hp = 1, string appearText = "Quack! Quack")
{
    private readonly string _appearText = appearText;
    private int Hp { get; set; } = hp;


    public string Speak()
    {
        return _appearText;
    }

    public int Hit()
    {
        return --Hp;
    }
}
