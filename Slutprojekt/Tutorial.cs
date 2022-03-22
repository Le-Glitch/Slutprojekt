using Raylib_cs;

public class Tutorial
{
    public static void StartTutorial()
    {
        General.WindowSettings();

        while(!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Draw();

            Raylib.EndDrawing();
        }
    }

    static void Draw()
    {
        
    }
}
