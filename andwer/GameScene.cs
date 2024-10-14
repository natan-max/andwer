
public class GameScene : Scene
{


    public GameScene()
    {

        while (true)
        {


            bool isSecretEnding = false;
            StartGame(ref isSecretEnding);


        }
        static void StartGame(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "Пiти через болото ", "Пiти через метро " };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Головний герой Скенсик йшов з друзями: Марко Севастiан Вiлям 1 Адольф i вам треба йти до площятки но ви не хотiли йти через головну дорогу яка пішком iти 2.5 годин є коротший шлях. от ви дойши до того короткого шляху вибери дорiжку:");

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
                        Console.WriteLine("Ви пiшли через метро вас замiтив Охоронник i вас вiдправили у вiддiлення. Найгiрша кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }

        static void SwampPath(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "Пройти через лiс ", "Пiти без паспорта ", "Дуже тихо пройти через блок пост" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ви пройшли через болото i трохи забруднилися, але нiчого страшного.коли пройшли болото вам зустрiвся Попереду блок пост. Твої дiї:");

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
                        Console.Clear();
                        Console.WriteLine("Вас замiтили i розстрiляли. Погана кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Слава Богу, знайомий Вiльяма допомiг вам. Ви пройшли 8");
                        FinalChoice(ref isSecretEnding);
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви пройшли але Марко пукнув, i вас замiтили. Погана кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }

        static void FinalChoice(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "Попрощатись i повернутись додому ", "Пiти через рiчку ", "Проiгнорувати " };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви пройшли блок пост, Ви майже дiйшли до площятки, але вам дзвонить мама i каже 'ЩОБ ЗА 4 ХВИЛИН БУВ ДОМА Я ДУЖЕ ЗЛА'. Що робитимеш:");

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
                        Console.Clear();
                        Console.WriteLine("Вас пiдкалували за те, що ви мамин синок. Нейтральна кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви дойшли додому але запiзнилися на 10 хвилин. Мама сварить вас, але прощає. хороша кiнцiвка.");
                        FinalChoice2(ref isSecretEnding);
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("вам було весело але мама Вас вигнала з дому. Смертельна кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }

        static void FinalChoice2(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "Продовжити", "закiнчити" };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ви дойшли додому але запiзнилися на 10 хвилин. Мама сварить вас, але прощає. хороша кiнцiвка.");
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
            string[] options = { "Кричати", "Оглянути пiдвал", "Пiти на гору i по про8увати вийти", "вийти через вiконце" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ви прокинулися, але є 1 нюанс,ви проснулися в пiдвалi. Ваші дiї: ");

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
                        Console.Clear();
                        Console.WriteLine("сутнiсть прийшло до вас i розрізала на 30 кускiв. погана кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("ви найшли тiльки чорний вихiд але вiн був заколочинений.");
                        continuePath2(ref isSecretEnding);

                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви вийшли але за вами побiгло сутнiсть не людської подоби. ви померли. Погана кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви вийшли, i вижили. Найкраща кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }

        static void continuePath2(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "взяти пилу", "взяти болгарку", "взяти мiнiган", "пiти до ЧВ" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви ще бродили ??? часу, i найшли пилу, болгарку, мiнiган . Вашi дiї: ");

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
                        Console.WriteLine("ви вибiгли на сутнiсть а у мiнiку не було патронiв i вас з'їла сутність. розумно-тупа кiнцiвка. ");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("ви пiшли до ЧВ але там була сутнiсть ви програли. погана кiнцiвка");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }
        static void continuePaths1(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "взяти 8олгарку", "взяти мiнiган", "пiти до ЧВ" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("залишилися болгарка, мiнiган . Вашi дiї: ");

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
            string[] options = { "взяти мiнiган", "пiти до ЧВ" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("залишився мiнiган . Вашi дiї: ");

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
                        Console.Clear();
                        Console.WriteLine("ви вибiгли на сутнiсть а у мiнiку не було патронiв i вас з'їла сутнiсть. розумно-тупа кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("ви просто пiшли з пилою i болгаркою");
                        continuePath6(ref isSecretEnding);
                    }
                    break;
                }
            }
        }
        static void continuePath6(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "використати пилу", "використати болгарку", "вийти через вiконце" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви вернулися до заколочиного чорного виходу. що ви використаєте. Вашi дiї: ");

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
                        Console.Clear();
                        Console.WriteLine("Ви використали пилу i це було безшумно");
                        PlayPuzzle(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви використали болгарку i це було шумно сутнiсть вас замiтило i з'їло. Погана Кiнцiвка");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви вийшли, i вижили. Найкраща кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }
        static void PlayPuzzle(ref bool isSecretEnding)
        {
            Console.Clear();
            Console.WriteLine("Ви спиляли чорний вихiд i побачили древнiй механізм iз загадкою. Вам потрiбно вибрати правильний символ для активацiї.");

            string[] options = { "вода", "вогонь", "квадробер", "свiтодiод" };
            int selectedOption = 0;

            while (true)
            { 
                Console.Clear();
                Console.WriteLine("Ви спиляли чорний вихiд i побачили древнiй механiзм iз загадкою. Вам потрiбно вибрати правильний символ для активацiї.ось пiдказка:\"Я завжди рухаюся, але не маю нiг.\r\nЯ не дихаю, але можу жити.\r\nМоє життя коротке, але я можу стати нескiнченним,\r\nЯкщо мене годувати. Хто я?\"");

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

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (selectedOption < 0)
                    {
                        selectedOption = options.Length - 1;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption >= options.Length)
                    {
                        selectedOption = 0;
                    }
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (selectedOption)
                    {
                        case 0:
                            Console.WriteLine("Вогонь активував пастку! Ви загинули.");
                            EndGame(ref isSecretEnding);
                            break;
                        case 1:
                            Console.WriteLine("Вода спокiйно протекла, i механiзм вiдкрився.");
                            FinalChoice1(ref isSecretEnding);
                            break;
                        case 2:
                            Console.WriteLine("На вас вибiгли квадробери i вас перетворили в квадробера! Найгiрша кiнцiвка.");
                            EndGame(ref isSecretEnding);
                            break;
                        case 3:
                            Console.WriteLine("Вiтер здув пастку з такою силою, що вас здуло i придавило уламками! Погана кiнцiвка.");
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
            string[] options = { "пiти в нього", "пiти додому", };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви вийли i побачили старий дiм. Вашi дiї: ");

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
                        Console.Clear();
                        Console.WriteLine("ви пiшли в той дiм i замiтили що там був танк Panzerkampfwagen VI Ausf B Tiger II з повнрю боєвою готовнiстю з екiпажем магiчних скелетiв нiмцiв пiд час WWII.");
                        FinalChoice4(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("ви пiшли додому i у вас все добре...чи нє?. сумнiвна Кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }
        static void FinalChoice4(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "нажати червону кнопку i стрильнути", "ДАВИТИ I СТРІЛЯТИ ПО ЛИЦЮ", };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви почали їхати на сторону тої хати i тут вибiгає сутнiсть. Вашi дiї: ");

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
                        Console.Clear();
                        Console.WriteLine("ви зiрвали сутнiсть в атоми але вас зачепило i відірвало руку. ви вижили. хороша кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("ви вбили сутнiсть без постраждань. сумнiвна Кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }
        static void EndGame(ref bool isSecretEnding)
        {
            Console.WriteLine("Для продовження натиснiть будь-яку клавiшу...");
            Console.ReadKey(true);

            Console.Clear();
            Console.WriteLine("Введiть код для секретної кiнцiвки або натиснiть Enter для завершення:");
            string input = Console.ReadLine();

            if (input == "1488")
            {
                Console.WriteLine("Ви знайшли секретну кiнцiвку!");
                isSecretEnding = true;
                Console.ReadKey();
            }
            else
            {
                isSecretEnding = false;
            }

            Console.WriteLine("Гру закiнчено.");
            Console.WriteLine("Натиснiть будь-яку клавiшу, щоб повернутися в меню...");
            Console.ReadKey(true);
        }

    }


    public override void Update()
    {

    }
}