using Raylib_cs;


public class General
{
    public static void WindowSettings()
    {
        Raylib.InitWindow(750, 750, "Tetris");
        Raylib.SetTargetFPS(60);
        Raylib.SetExitKey(0);
    }

    public Rectangle[,] GridSquare()
    {
        Rectangle[,] squares = new Rectangle[10, 20];

        return squares;
    }


}