using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andwer
{
    class MenuScene : Scene
    {

        private string[] _menuButtons = new[]{
    "Start",
    "About",
    "Setting",
    "Exit"
        };
        private int _boxSize = 32;
        private int _selectedButtonIndex = 1;
        private int _LastRefreshTime = 0;

        public MenuScene()
        {

        }

        public override void Render()
        {



            long lastRefrehTime = 0;
            double refreshRate = 20.0 / 20.0;


            _selectedButtonIndex = int.Clamp(_selectedButtonIndex, 0, _menuButtons.Length - 1);

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

            for (int i = 0; i < _menuButtons.Length; i++)
            {
                if (i == _selectedButtonIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    PrintSurroundedMessage("*", _menuButtons[i], "*", boxSize);
                    Console.ResetColor();
                }
                else
                {
                    PrintSurroundedMessage("", _menuButtons[i], "", boxSize);
                }
                Console.WriteLine();
            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        _selectedButtonIndex--;
                        break;

                    case ConsoleKey.S:
                        _selectedButtonIndex++;
                        break;

                    case ConsoleKey.Enter:
                        switch (_selectedButtonIndex)
                        {
                            case 0:
                                return GameScene;

                            case 1:
                                return AboutScene;
                        }
                        break;

                }
            }

            Console.WriteLine("Good bye");
            return null;
        }
    }
