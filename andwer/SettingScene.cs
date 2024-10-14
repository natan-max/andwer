using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using System.Drawing;

public class SettingsScene : Scene
{
    public SettingsScene()
    {
        Elements.Add(Box.DefaultBox(new Point(0, 0), new Size(32, 6), new Text()
        {
            Alignment = Alignment.Center,
            Value = "An adventure game \nVersion: 0.1 \n  \nPress E to go back...",
           
        }));
    }

    public override void Update()
    {
        while (Console.KeyAvailable)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.E)
            {
                CloseScene();
            }
        }
    }
}