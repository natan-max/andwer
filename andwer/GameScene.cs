
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
            string[] options = { "Пiти через болото 1", "Пiти через метро 2" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Головний герой Скенсик iшов з друзями: Марко Севастiан Вiлям i Адольф i вам треба йти до площятки але ви не хотiли iти через головну дорогу чрез яку пiшки йти 2.5 годин є коротший шлях. от ви дiйши до того короткого шляху вибери дорiжку:");

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
                        Console.WriteLine("Ви пiшли через метро вас замiтив Охоронник i вас відправили у вiддiлення. Найгiрша кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    break;
                }
            }
        }

        static void SwampPath(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "Пройти через лiс 3", "Пiти без паспорта 4", "Дуже тихо пройти через блок пост5" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ви пройшли через болото i трохи забруднилися, але нiчого страшного.коли пройшли болото вам зустрiвся Попереду блок пост. Твої дiї:");

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
            string[] options = { "Попрощатись i повернутись додому 7", "Пiти через рiчку 8", "Проiгнорувати 9", "Продовжити" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви пройшли блок пост, Ви майже дiйшли до площятки, але вам дзвонить мама i каже 'ЩОБ ЗА 5 ХВИЛИН БУВ ДОМА Я ДУЖЕ ЗЛА'. Що робитимеш:");

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
                        Console.WriteLine("Вас пiдкалували за те, що ви мамин синок. Нейтральна кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви дойшли додому але запiзнилися на 10 хвилин. Мама сварить вас, але прощає. хороша кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("вам було весело але мама Вас вигнала з дому. Смертельна кiнцiвка.");
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
            string[] options = { "Кричати", "Оглянути пiдвал", "Пiти на гору i по пробувати вийти", "вийти через вiконце" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ви прокинулися, але є 1 нюанс,ви проснулися в пiдвалi. Ваші дiї: ");

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
            string[] options = { "Пiти туда.", "не iти туди", };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви ще бродили ??? часу, i найшли пилу але ви замiтили ще одну маленьку дверку . Вашi дiї: ");

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
                        Console.WriteLine("ви вiдчули дуже рiзки сморiд це були трупи i обригались i захснулися блювотино. тупа кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("ви не пiшли тай добре що не пiшли.");
                        continuePath3(ref isSecretEnding);
                    }
                    break;
                }
            }
        }
        static void continuePath3(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "Допомогти", "Тiкати", };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ви виломали але це почуло сутнiсть i вона почало iстошно кричати вашим голосом голосом друзiв родичiв ви почали сумніватися чи треба тiкати чи рятувати родичiв. Вашi дiї: ");

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
                        Console.WriteLine("Ви вибiгли але вас схопила сутнiсть далi вона вас кинула в казан i почала вас варити ви iстошно кричали а сутнiсть насолоджувалася потiм на полусмертi воно почало здирати з вас шкіру i вас одночасно регенувати i ви відчували цю адську бiль слава богу що ви померли вiд зупинки органiв. жутка кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ви згадали що всi родичи i друзi були не дома бо вони всi були далеко");
                        FinalChoiceRUN(ref isSecretEnding);
                    }
                    break;
                }
            }
        }
        static void FinalChoiceRUN(ref bool isSecretEnding)
        {
            int selectedIndex = 0;
            string[] options = { "Взяти", "Тiкати", };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Сутнiсть почало за вам бiгти але ви так були дуже ослабленнi, ви заховалися, ви побачили старий джавелiн з У-Р війні. Вашi дiї: ");

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
                        Console.WriteLine("сутнiсть вас наздогнали i відрубало всi кiнцiвки ви померли в сильних муках. погана кiнцiвка.");
                        EndGame(ref isSecretEnding);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("ви пiдбiгли до джавелiну але сутнiсть вас замiтила але вона не побачила джавелiн, ви напривли джавелiн на неї але немогли бульнути iз-за того що він старий ви рішили стрибнути в її рот воно вас зїло але через 1 хв ви зірвали в середині джавелін iз собою ви в тяжкому станi але вижили. Супер Кiнцiвка.");
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
                Console.WriteLine("Ви знайшли секретну кiнцiвку! ХАЙ ГIТЛЕР!");
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