using System;
using Raylib_cs;

public class Game
{
    public static void PlayGame()
    {
        General.WindowSettings();

        // Create an array due it having a constant size
        Rectangle[,] playArea;

        Grid grid = new Grid();
        Blocks blocks = new Blocks();

        bool isOnFloor = true;

        while (!Raylib.WindowShouldClose())
        {
            if(isOnFloor)
            {
                (Rectangle[] nextBlock, int blockChoice) = blocks.chooseBlock();
                nextBlock = blocks.MoveBlockToPlayArea(nextBlock, blockChoice);
            }

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);

            playArea = grid.CreateGrid();

            grid.Draw(playArea);

            Raylib.EndDrawing();
        }
    }
}
