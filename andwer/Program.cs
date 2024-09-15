using System;

class AdventureGame
{
    static void Main()
    {
        bool isSecretEnding = false;
        ConsoleKey choice;

        while (true)
        {
            Console.Clear();
            int selectedIndex = 0; // індекс для підсвічування вибору
            string[] options = { "Старт", "Вихід" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Головне Меню ====");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Підсвічення зеленим кольором
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                ConsoleKey key = Console.ReadKey(true).Key;

                // Обробка клавіш для переміщення
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
                        // Почати гру
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
    }

    static void StartGame(ref bool isSecretEnding)
    {
        int selectedIndex = 0;
        string[] options = { "Піти через болото 1", "Піти через метро." };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Головний герой Скенсик ішов з друзями: Марко Севастіан Вілям і Адольф і вам треба іти до площятки но ви не хотіли іти через головну дорогу яка пішком іти 2.5 годин є коротший шлях. от ви дойши до того короткого шляху вибери доріжку:");

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
        string[] options = { "Пройти через ліс", "Піти без паспорта 4", "Дуже тихо пройти через блок пост" };

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
        string[] options = { "Попрощатись і повернутись додому", "Піти через річку 8", "Проігнорувати" };

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
}
