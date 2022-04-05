using Raylib_cs;


public class General
{
    // Method for window settings as it stays the same
    public static void WindowSettings()
    {
        Raylib.InitWindow(750, 750, "Tetris");
        Raylib.SetTargetFPS(60);
        Raylib.SetExitKey(0);
    }
}