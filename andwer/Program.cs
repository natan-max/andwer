using System;
using System.Collections.Generic;
using System.Threading;

enum PlantType
{
    Sunflower,
    Peashooter,
    CherryBomb,
    PotatoMine,
    IcePeashooter,
    Chomper,
    NuclearMushroom
}

enum ZombieType
{
    Basic,
    Conehead,
    Buckethead,
    FastZombie
}

class Plant
{
    public PlantType Type { get; set; }
    public int Health { get; set; }
    public int RechargeTime { get; set; }
    public int Cost { get; set; }
    public DateTime LastPlaced { get; set; }

    public Plant(PlantType type, int health, int recharge, int cost)
    {
        Type = type;
        Health = health;
        RechargeTime = recharge;
        Cost = cost;
        LastPlaced = DateTime.Now;
    }

    public bool IsRechargeComplete()
    {
        return (DateTime.Now - LastPlaced).TotalSeconds >= RechargeTime;
    }
}

class Zombie
{
    public ZombieType Type { get; set; }
    public int Health { get; set; }
    public double Speed { get; set; }
    public bool IsSlowed { get; set; }

    public Zombie(ZombieType type, int health, double speed)
    {
        Type = type;
        Health = health;
        Speed = speed;
        IsSlowed = false;
    }

    public void ApplySlow(double factor)
    {
        if (!IsSlowed)
        {
            Speed *= factor;
            IsSlowed = true;
        }
    }
}

class Game
{
    private const int DefaultFPS = 30;
    private int _fps;
    private int _delay;
    private Timer _gameTimer;
    private int _cursorX;
    private int _cursorY;

    private const int GridWidth = 10;
    private const int GridHeight = 10;
    private Plant[,] _grid = new Plant[GridWidth, GridHeight];
    private List<Zombie> _zombies = new List<Zombie>();
    private int _sun;
    private Timer _waveTimer;
    private Random _random = new Random();

    public Game()
    {
        _fps = DefaultFPS;
        _delay = 1000 / _fps;
        _gameTimer = new Timer(UpdateGame, null, 0, _delay);
        _cursorX = 0;
        _cursorY = 0;
        _sun = 50;
    }

    public void Start()
    {
        _waveTimer = new Timer(SpawnWave, null, 0, 30000); // Spawn wave every 30 seconds
        MainMenu();
    }

    private void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Грати");
        Console.WriteLine("2. Налаштування");
        Console.WriteLine("3. Правила");
        Console.WriteLine("4. Хто створив");
        Console.WriteLine("5. Вихід");
        HandleMenuInput();
    }

    private void HandleMenuInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without displaying
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                PlayGame();
                break;
            case ConsoleKey.D2:
                Settings();
                break;
            case ConsoleKey.D3:
                Rules();
                break;
            case ConsoleKey.D4:
                Credits();
                break;
            case ConsoleKey.D5:
                Environment.Exit(0);
                break;
        }
    }

    private void PlayGame()
    {
        Console.Clear();
        Console.WriteLine("Гра розпочалася. Використовуйте WASD для переміщення курсору.");
        DrawField();
        // Start game loop
        while (true)
        {
            HandleInput();
            DrawField();
            Thread.Sleep(_delay); // Control the frame rate
        }
    }

    private void Settings()
    {
        Console.Clear();
        Console.WriteLine("1. Рівень складності");
        Console.WriteLine("2. FPS");
        Console.WriteLine("3. Назад");
        HandleSettingsInput();
    }
    private void HandleSettingsInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without displaying
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                DifficultySettings();
                break;
            case ConsoleKey.D2:
                FPSSettings();
                break;
            case ConsoleKey.D3:
                MainMenu();
                break;
        }
    }

    private void DifficultySettings()
    {
        Console.Clear();
        Console.WriteLine("Виберіть рівень складності (1-3):");
        // Input and process difficulty level
        Settings();
    }

    private void FPSSettings()
    {
        Console.Clear();
        Console.WriteLine("Введіть бажане значення FPS:");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int fps) && fps > 0)
        {
            _fps = fps;
            _delay = 1000 / _fps;
            _gameTimer.Change(0, _delay);
        }
        else
        {
            Console.WriteLine("Невірне значення FPS. Використовується стандартне значення 30 FPS.");
            _fps = DefaultFPS;
            _delay = 1000 / _fps;
            _gameTimer.Change(0, _delay);
        }
        Settings();
    }

    private void Rules()
    {
        Console.Clear();
        Console.WriteLine("Правила гри:");
        Console.WriteLine("1. Садіть рослини на поле");
        Console.WriteLine("2. Захищайте свій дім від зомбі");
        Console.WriteLine("3. Кожна рослина має свою вартість та характеристики");
        Console.WriteLine("4. Зомбі стають сильнішими з кожною хвилею");
        Console.WriteLine("Натисніть будь-яку клавішу для повернення");
        Console.ReadKey();
        MainMenu();
    }

    private void Credits()
    {
        Console.Clear();
        Console.WriteLine("Гру створив: Ваше ім'я");
        Console.WriteLine("Натисніть будь-яку клавішу для повернення");
        Console.ReadKey();
        MainMenu();
    }

    private void DrawField()
    {
        Console.Clear();
        for (int y = 0; y < GridHeight; y++)
        {
            for (int x = 0; x < GridWidth; x++)
            {
                if (x == _cursorX && y == _cursorY)
                {
                    Console.Write("[X]"); // Cursor display
                }
                else if (_grid[x, y] != null)
                {
                    Console.Write($"[{(int)_grid[x, y].Type}] "); // Display plants
                }
                else
                {
                    Console.Write("[ ] "); // Empty space
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine($"Сонце: {_sun}");
        Console.WriteLine($"Кількість зомбі: {_zombies.Count}");
    }

    private void HandleInput()
    {
        if (Console.KeyAvailable) // Check if any key is pressed
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without displaying
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    MoveCursor(0, -1);
                    break;
                case ConsoleKey.S:
                    MoveCursor(0, 1);
                    break;
                case ConsoleKey.A:
                    MoveCursor(-1, 0);
                    break;
                case ConsoleKey.D:
                    MoveCursor(1, 0);
                    break;
                case ConsoleKey.Spacebar:
                    PlacePlant(); // Place plant
                    break;
                case ConsoleKey.Delete:
                    RemovePlant(); // Remove plant
                    break;
            }
        }
    }

    private void MoveCursor(int deltaX, int deltaY)
    {
        _cursorX = Math.Max(0, Math.Min(_cursorX + deltaX, GridWidth - 1)); // Boundaries for X
        _cursorY = Math.Max(0, Math.Min(_cursorY + deltaY, GridHeight - 1)); // Boundaries for Y
    }

    private void PlacePlant()
    {
        // Logic for placing a plant
    }
    private void RemovePlant()
    {
        // Logic for removing a plant
    }

    private void SpawnWave(object state)
    {
        int numZombies = _random.Next(1, 5); // Example random number of zombies
        for (int i = 0; i < numZombies; i++)
        {
            ZombieType zombieType = (ZombieType)_random.Next(0, Enum.GetValues(typeof(ZombieType)).Length); // Random zombie type
            _zombies.Add(new Zombie(zombieType, 100, 1.0)); // Create new zombie
        }
    }

    private void UpdateGame(object state)
    {
        // Update game state
        HandleInput();
        DrawField();
    }
}

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}