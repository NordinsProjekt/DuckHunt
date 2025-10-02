using System;
using System.Collections.Generic;
using System.Text;

namespace DuckHunt;

public class Duck(int hp = 1, string appearText = "Quack! Quack")
{
    private readonly string _appearText = appearText;
    private int startHp { get; set; } = hp;
    private int currentHp { get; set; } = hp;
    private int Score { get; set; } = 1;


    public string Speak()
    {
        return _appearText;
    }

    public int Hit()
    {
        return --currentHp;
    }

    public int GetScore()
    {
        return Score*startHp;
    }
}
