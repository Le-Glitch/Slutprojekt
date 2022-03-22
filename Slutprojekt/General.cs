using Raylib_cs;


public class General
{
    public static void WindowSettings()
    {
        Raylib.InitWindow(1000, 1000, "Tetris");
        Raylib.SetTargetFPS(60);
        Raylib.SetExitKey(0);
    }
}