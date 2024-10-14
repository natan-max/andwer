using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using System.Drawing;

public class AboutScene : Scene
{
    public AboutScene()
    {
        Elements.Add(Box.DefaultBox(new Point(0, 0), new Size(32, 10), new Text()
        {
            Alignment = Alignment.Center,
            Size = new Size(50, 12),
            Value = "Game about danger forest trip \n \nVersion: 0.1 \n \nBy Nazx_xk and Nathan\n \nPress E to go back..."
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