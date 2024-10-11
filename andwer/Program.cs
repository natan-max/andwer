using System;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

Scene sceneToRender = MenuScene();
while (sceneToRender != null)
{
    Console.Clear();
    sceneToRender = sceneToRender();
}

static Scene MenuScene()
{
    int boxSize = 32;
    string[] menuButtons = new string[]
    {
    "Start",
    "About",
    "Setting",
    "Exit"
    };
    int selectedButtonIndex = 1;
    bool isRunning = true;
    int LastRefreshTime = 0;
    long lastRefrehTime = 0;
    double refreshRate = 20.0 / 20.0;

    Console.CursorVisible = false;
    while (isRunning)
    {
        TimeSpan elapsedTime = Stopwatch.GetElapsedTime(LastRefreshTime);
        if (elapsedTime.TotalSeconds > refreshRate)
        {
            selectedButtonIndex = int.Clamp(selectedButtonIndex, 0, menuButtons.Length - 1);

            Console.SetCursorPosition(0, 0);
            PrintMessageNTimes("-", boxSize);
            Console.WriteLine();
            PrintSurroundedMessage("|", "An adwenture game", "|", boxSize);
            Console.WriteLine();
            PrintSurroundedMessage("|", "Version 0.2", "|", boxSize);
            Console.WriteLine();
            PrintSurroundedMessage("|", "Have Fun and Good Luck", "|", boxSize);
            Console.WriteLine();
            PrintMessageNTimes("-", boxSize);
            Console.WriteLine();

            for (int i = 0; i < menuButtons.Length; i++)
            {
                if (i == selectedButtonIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    PrintSurroundedMessage("*", menuButtons[i], "*", boxSize);
                    Console.ResetColor();
                }
                else
                {
                    PrintSurroundedMessage("", menuButtons[i], "", boxSize);
                }
                Console.WriteLine();
            }
        }
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedButtonIndex--;
                    break;

                case ConsoleKey.DownArrow:
                    selectedButtonIndex++;
                    break;

                case ConsoleKey.Enter:
                    switch (selectedButtonIndex)
                    {
                        case 0:
                            return GameScene;

                        case 1:
                            return AboutScene;

                        case 3:
                            isRunning = false;
                            Console.WriteLine("Exiting...");
                            break;
                    }
                    break;
            }
        }
    }
    Console.WriteLine("Good bye");
    return null;
}


static Scene GameScene()
{
    bool isSecretEnding = false;
    ConsoleKey choice;

    while (true)
    {
        Console.Clear();
        int selectedIndex = 0;
        string[] options = { "Старт", "Вихід" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Головне Меню ====");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;


            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.W)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.S)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {

                    StartGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Environment.Exit(0);
                }
                break;
            }
        }

    }

    static void StartGame(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Піти через болото ", "Піти через метро " };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Головний герой Скенсик ішов з друзями: Марко Севастіан Вілям 1 Адольф і вам треба іти до площятки но ви не хотіли іти через головну дорогу яка пішком іти 2.5 годин є коротший шлях. от ви дойши до того короткого шляху вибери доріжку:");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    SwampPath(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ви пішли через метро вас замітив Охоронник і вас відправили у відділення. Найгірша кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }

    static void SwampPath(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Пройти через ліс ", "Піти без паспорта ", "Дуже тихо пройти через блок пост" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ви пройшли через болото і трохи забруднилися, але нічого страшного.коли пройшли болото вам зустрівся Попереду блок пост. Твої дії:");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вас замітили і розстріляли. Погана кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Слава Богу, знайомий Вільяма допоміг вам. Ви пройшли 8");
                    FinalChoice(ref isSecretEnding);
                }
                else if (selectedIndex == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ви пройшли але Марко пукнув, і вас замітили. Погана кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }

    static void FinalChoice(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Попрощатись і повернутись додому ", "Піти через річку ", "Проігнорувати " };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви пройшли блок пост, Ви майже дійшли до площятки, але вам дзвонить мама і каже 'ЩОБ ЗА 4 ХВИЛИН БУВ ДОМА Я ДУЖЕ ЗЛА'. Що робитимеш:");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вас підкалували за те, що ви мамин синок. Нейтральна кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ви дойшли додому але запізнилися на 10 хвилин. Мама сварить вас, але прощає. хороша кінцівка.");
                    FinalChoice2(ref isSecretEnding);
                }
                else if (selectedIndex == 2)
                {
                    Console.Clear();
                    Console.WriteLine("вам було весело але мама Вас вигнала з дому. Смертельна кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }

    static void FinalChoice2(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Продовжити", "закінчити" };
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ви дойшли додому але запізнилися на 10 хвилин. Мама сварить вас, але прощає. хороша кінцівка.");
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Продовжуємо)");
                    continuePath(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Виходимо(");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }

    }

    static void continuePath(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Кричати", "Оглянути підвал", "Піти на гору і по про8увати вийти", "вийти через віконце" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ви прокинулися, але є 1 нюанс,ви проснулися в підвалі. Ваші дії: ");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("сутність прийшло до вас і розрізала на 30 кусків. погана кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви найшли тільки чорний вихід але він був заколочинений.");
                    continuePath2(ref isSecretEnding);

                }
                else if (selectedIndex == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ви вийшли але за вами побігло сутність не людської подоби. ви померли. Погана кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Ви вийшли, і вижили. Найкраща кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }

    static void continuePath2(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "взяти пилу", "взяти болгарку", "взяти мініган", "піти до ЧВ"};

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви ще бродили ??? часу, і найшли пилу, болгарку, мініган . Ваші дії: ");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("ви взяли пилу. +пила");
                    continuePaths1(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви взяли болгарку. +болгарка");
                    continuePathsvse(ref isSecretEnding);
                }
                else if (selectedIndex == 2)
                {
                    Console.Clear();
                    Console.WriteLine("ви вибігли на сутність а у мініку не було патронів і вас з'їла сутність. розумно-тупа кінцівка. ");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 3)
                {
                    Console.Clear();
                    Console.WriteLine("ви пішли до ЧВ але там була сутність ви програли. погана кінцівка");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void continuePaths1(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "взяти 8олгарку", "взяти мініган", "піти до ЧВ"};

        while (true)
        {
            Console.Clear();
            Console.WriteLine("залишилися болгарка, мініган . Ваші дії: ");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("ви взяли болгарку. +болгарка");
                    continuePathsvse(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви вибігли на сутність а у мініку не було патронів і вас з'їла сутність. розумно-тупа кінцівка. ");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 2)
                {
                    Console.Clear();
                    Console.WriteLine("ви просто пішли з пилою");
                    continuePath6(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void continuePathsvse(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = {"взяти мініган", "піти до ЧВ" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("залишився мініган . Ваші дії: ");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("ви вибігли на сутність а у мініку не було патронів і вас з'їла сутність. розумно-тупа кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви просто пішли з пилою і болгаркою");
                    continuePath6(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void continuePath6(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "використати пилу", "використати болгарку", "вийти через віконце" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви вернулися до заколочиного чорного виходу. що ви використаєте. Ваші дії: ");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Ви використали пилу і це було безшумно");
                    PlayPuzzle(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ви використали болгарку і це було шумно сутність вас замітило і з'їло. Погана Кінцівка");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ви вийшли, і вижили. Найкраща кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void PlayPuzzle(ref bool isSecretEnding)
    {
        Console.Clear();
        Console.WriteLine("Ви спиляли чорний вихід і побачили древній механізм із загадкою. Вам потрібно вибрати правильний символ для активації.");

        // Опції для головоломки
        string[] options = { "(◕‿◕)", "🌊", "\\(★ω★)//", "💨" };
        int selectedOption = 0;

        while (true)
        {
            // Виводимо варіанти з підсвічуванням обраного
            Console.Clear();
            Console.WriteLine("Ви спиляли чорний вихід і побачили древній механізм із загадкою. Вам потрібно вибрати правильний символ для активації.\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-> " + options[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("   " + options[i]);
                }
            }

            // Обробка натискання клавіш
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                // Переміщаємось вгору по списку
                selectedOption--;
                if (selectedOption < 0)
                {
                    selectedOption = options.Length - 1;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                // Переміщаємось вниз по списку
                selectedOption++;
                if (selectedOption >= options.Length)
                {
                    selectedOption = 0;
                }
            }
            else if (key == ConsoleKey.Enter)
            {
                // Виконуємо дію на основі вибраного варіанту
                Console.Clear();
                switch (selectedOption)
                {
                    case 0:
                        Console.WriteLine("Вогонь активував пастку! Ви загинули.");
                        EndGame(ref isSecretEnding);
                        break;
                    case 1:
                        Console.WriteLine("Вода спокійно протекла, і механізм відкрився.");
                        FinalChoice1(ref isSecretEnding);
                        break;
                    case 2:
                        Console.WriteLine("На вас вибігли квадробери і вас перетворили в квадробера! Найгірша кінцівка.");
                        EndGame(ref isSecretEnding);
                        break;
                    case 3:
                        Console.WriteLine("Вітер здув пастку з такою силою, що вас здуло і придавило уламками! Погана кінцівка.");
                        EndGame(ref isSecretEnding);
                        break;
                }
                break;
            }
        }
    }

    static void FinalChoice1(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "піти в нього", "піти додому", };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви вийли і побачили старий дім. Ваші дії: ");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("ви пішли в той дім і замітили що там був танк Panzerkampfwagen VI Ausf B Tiger II з повнрю боєвою готовністю з екіпажем магічних скелетів німців під час WWII.");
                    FinalChoice4(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви пішли додому і у вас все добре...чи нє?. сумнівна Кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void FinalChoice4(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "нажати червону кнопку і стрильнути", "ДАВИТИ І СТРІЛЯТИ ПО ЛИЦЮ", };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви почали їхати на сторону тої хати і тут вибігає сутність. Ваші дії: ");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    Console.Clear();
                    Console.WriteLine("ви зірвали сутність в атоми але вас зачепило і відірвало руку. ви вижили. хороша кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви вбили сутність без постраждань. сумнівна Кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void EndGame(ref bool isSecretEnding)
    {
        Console.WriteLine("Для продовження натисніть будь-яку клавішу...");
        Console.ReadKey(true);

        Console.Clear();
        Console.WriteLine("Введіть код для секретної кінцівки або натисніть Enter для завершення:");
        string input = Console.ReadLine();

        if (input == "1488")
        {
            Console.WriteLine("Ви знайшли секретну кінцівку!");
            isSecretEnding = true;
            Console.ReadKey();
        }
        else
        {
            isSecretEnding = false;
        }

        Console.WriteLine("Гру закінчено.");
        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
        Console.ReadKey(true);
    }
    return null;
}

static Scene AboutScene()
{
    int boxSize = 32;
    bool isRunning = true;
    int LastRefreshTime = 0;
    long lastRefrehTime = 0;
    double refreshRate = 20.0 / 20.0;

    Console.CursorVisible = false;
    while (isRunning)
    {
        TimeSpan elapsedTime = Stopwatch.GetElapsedTime(LastRefreshTime);
        if (elapsedTime.TotalSeconds > refreshRate)
        {


            Console.SetCursorPosition(0, 0);
            PrintMessageNTimes("-", boxSize);
            Console.WriteLine();
            PrintSurroundedMessage("|", "Adwenture Game", "|", boxSize);
            Console.WriteLine();
            PrintSurroundedMessage("|", "Game about danger forest trip", "|", boxSize);
            Console.WriteLine();
            PrintSurroundedMessage("|", "by Nazx_xk and Nathan", "|", boxSize); // Допиши тут свій нік як того хто теж розробляв
            static Scene AboutScene()
            {
                int boxSize = 32;
                bool isRunning = true;
                int LastRefreshTime = 0;
                long lastRefrehTime = 0;
                double refreshRate = 20.0 / 20.0;

                Console.CursorVisible = false;
                while (isRunning)
                {
                    TimeSpan elapsedTime = Stopwatch.GetElapsedTime(LastRefreshTime);
                    if (elapsedTime.TotalSeconds > refreshRate)
                    {


                        Console.SetCursorPosition(0, 0);
                        PrintMessageNTimes("-", boxSize);
                        Console.WriteLine();
                        PrintSurroundedMessage("|", "Adwenture Game", "|", boxSize);
                        Console.WriteLine();
                        PrintSurroundedMessage("|", "Game about danger forest trip", "|", boxSize);
                        Console.WriteLine();
                        PrintSurroundedMessage("|", "by Nazx_xk and Nathan", "|", boxSize); // Допиши тут свій нік як того хто теж розробляв
                        Console.WriteLine();
                        PrintMessageNTimes("-", boxSize);
                        Console.WriteLine();
                        Console.WriteLine("Press Esc to return to menu");


                    }
                    while (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.Escape:
                                return MenuScene;
                        }
                    }
                }
                return null;
            }
            Console.WriteLine();
            PrintMessageNTimes("-", boxSize);
            Console.WriteLine();
            Console.WriteLine("Press Esc to return");


        }
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    return MenuScene;
            }
        }
    }
    return null;
}

static void PrintMessageNTimes(string message, int n)
{
    for (int i = 0; i < n; i++)
    {
        Console.Write(message);
    }
}


static void PrintSurroundedMessage(string before, string message, string after, int boxSize)
{
    Console.Write(before);
    boxSize = boxSize - (before.Length + after.Length);
    int start = (int)((boxSize - message.Length) * 0.5);
    PrintMessageNTimes(" ", start);
    Console.Write(message);
    PrintMessageNTimes(" ", boxSize - start - message.Length);

    Console.Write(after);
}                
 
delegate Scene Scene();
