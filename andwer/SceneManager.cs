using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andwer
{
    class SceneManager
    {
        public static Scene ActiveScene { get; set; }

        public static void Run()
        {
            long lastRefrehTime = 0;
            double refreshRate = 20.0 / 20.0;

            Console.CursorVisible = false;
            while (true)
            {
                TimeSpan elapsedTime = Stopwatch.GetElapsedTime(lastRefrehTime);
            }
        }
    }
}
