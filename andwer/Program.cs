using FastConsole.Engine.Core;

class Program
{
    public static void Main()
    {
        Windows.ForceUpgradeToAnsi();

        SceneManager.OpenScene(new MenuScene());
        SceneManager.Run();
    }
}