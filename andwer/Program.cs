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
                case ConsoleKey.W:
                    selectedButtonIndex--;
                    break;

                case ConsoleKey.S:
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
        string[] options = { "Піти через болото 1", "Піти через метро 2" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Головний герой Скенсик ішов з друзями: Марко Севастіан Вілям і Адольф і вам треба іти до площятки но ви не хотіли іти через головну дорогу яка пішком іти 2.5 годин є коротший шлях. от ви дойши до того короткого шляху вибери доріжку:");

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
        string[] options = { "Пройти через ліс 3", "Піти без паспорта 4", "Дуже тихо пройти через блок пост5" };

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
        string[] options = { "Попрощатись і повернутись додому 7", "Піти через річку 8", "Проігнорувати 9", "Продовжити"};

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви пройшли блок пост, Ви майже дійшли до площятки, але вам дзвонить мама і каже 'ЩОБ ЗА 5 ХВИЛИН БУВ ДОМА Я ДУЖЕ ЗЛА'. Що робитимеш:");

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
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 2)
                {
                    Console.Clear();
                    Console.WriteLine("вам було весело але мама Вас вигнала з дому. Смертельна кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Continue?...");
                    continuePath(ref isSecretEnding);
                }
                break;
            }
        }
    }

    static void continuePath(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Кричати", "Оглянути підвал", "Піти на гору і по пробувати вийти", "вийти через віконце" };

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
        string[] options = { "Піти туда.", "не іти туди", };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви ще бродили ??? часу, і найшли пилу але ви замітили ще одну маленьку дверку . Ваші дії: ");

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
                    Console.WriteLine("ви відчули дуже різки сморід це були трупи і обригались і захснулися блювотино. тупа кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви не пішли тай добре що не пішли.");
                    continuePath3(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void continuePath3(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Допомогти", "Тікати", };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ви виломали але це почуло сутність і вона почало істошно кричати вашим голосом голом друзів родичів ви почали сумніватися чи треба тікати чи рятувати родичів. Ваші дії: ");

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
                    Console.WriteLine("Ви вибігли але вас схопила сутність далі вона вас кинула в казан і почала вас варити ви істошно кричали а сутність насолоджувалася потім на полусмерті воно почало здирати з вас шкіру і вас одночасно регенувати і ви відчували цю адську біль слава богу що ви померли від зупинки органів. жутка кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ви згадали що всі родичи і друзі були не дома бо вони всі були далеко");
                    FinalChoiceRUN(ref isSecretEnding);
                }
                break;
            }
        }
    }
    static void FinalChoiceRUN(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Взяти", "Тікати", };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Сутність почало за вам бігти але ви так були дуже ослабленні, ви заховалися, ви побачили старий джавелін з У-Р війні. Ваші дії: ");

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
                    Console.WriteLine("сутність вас наздогнали і відрубало всі кінцівки ви померли в сильних муках. погана кінцівка.");
                    EndGame(ref isSecretEnding);
                }
                else if (selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine("ви підбігли до джавеліну але сутністю вас замітила але вона не побачила джавелін, ви напривли джавелін на неї але немогли бульнути із-за того що він старий ви рішили стрибнути в її рот воно вас зїло але через 1 хв ви зірвали в середині джавелін із собою ви в тяжкому стані але вижили. Супер Кінцівка.");
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
            Console.WriteLine("Ви знайшли секретну кінцівку! ХАЙ ГІТЛЕР!");
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
