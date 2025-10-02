using DuckHunt.ScreenWriters;
using DuckHunt.Validators;

namespace DuckHunt;

public class Game
{
    private readonly int _minimumSeconds;
    private readonly int _maximumSeconds;
    private readonly HashSet<string> _validInputs = ["bang", "reload", "quit"];
    private Stack<Duck> _ducks = new();
    private Timer? Timer { get; set; }
    private InputValidator InputValidator { get; }
    private Player Player { get; }
    private readonly ConsoleWriter _consoleWriter = new();
    private Random _rnd = new();

    public Game(int minimumSeconds = 20, int maximumSeconds = 120)
    {
        _minimumSeconds = minimumSeconds * 1000;
        _maximumSeconds = maximumSeconds * 1000;
        InputValidator = new InputValidator(_validInputs);
        Player = new Player(_consoleWriter);
    }

    public void Start()
    {
        _consoleWriter.StartMenu();
        SpawnDuck(null);
        while (PlayerInput(Console.ReadLine())) ;
    }

    private bool PlayerInput(string? input)
    {
        if (InputValidator.ValidateInput(input))
        {
            switch (input)
            {
                case "bang":
                    ShootDuck();
                    break;
                case "reload":
                    PlayerReload();
                    break;
                case "quit":
                    PlayerQuits();
                    return false;
                default: throw new NotImplementedException();
            }
        }
        else
        {
            _consoleWriter.WrongCommand();
        }

        return true;
    }

    private void ShootDuck()
    {
        if (_ducks.Count == 0)
        {
            _consoleWriter.NoDucks();
            return;
        }

        var duck = _ducks.Pop();
        var hpLeft = Player.Shoot(duck);

        if (hpLeft > 0)
        {
            _ducks.Push(duck);
        }
    }

    private void PlayerReload() => Player.Reload();

    private void PlayerQuits()
    {
        _consoleWriter.GameOver();
    }

    private void SpawnDuck(object? state)
    {
        if (Timer is null)
        {
            CreateTimer();
            return;
        }

        var duckHp = _rnd.Next(0, 2) + 1;
        var duck = new Duck(duckHp);
        _ducks.Push(duck);
        _consoleWriter.DuckAppears(duck);
        CreateTimer();
    }

    private void CreateTimer()
    {
        var timeValue = _rnd.Next(_minimumSeconds, _maximumSeconds);
        Timer = new Timer(SpawnDuck, null, timeValue, 0);
    }
}
