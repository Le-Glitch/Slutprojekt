using Raylib_cs;

public class Tutorial
{
    public static void StartTutorial()
    {
        General.WindowSettings();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);

            Draw();

            Raylib.EndDrawing();
        }
    }

    static void Draw()
    {
        Raylib.DrawRectangle(300, 30, 30, 30, Color.BLACK);
    }
}
