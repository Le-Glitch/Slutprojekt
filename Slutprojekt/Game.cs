using System;
using Raylib_cs;

public class Game
{
    public static void PlayGame()
    {
        General.WindowSettings();
        Rectangle[,] playArea = new Rectangle[10, 20];

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);

            playArea = Grid.CreateGrid(10, 20);

            Grid.Draw(playArea);

            Raylib.EndDrawing();
        }
    }
}
