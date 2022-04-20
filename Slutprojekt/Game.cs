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
        Preview preview = new Preview();

        (Rectangle[,] nextBlock, Color nextBlockColour) = blocks.chooseBlock();

        playArea = grid.CreateGrid();

        bool isOnFloor = true;

        while (!Raylib.WindowShouldClose())
        {
            if(isOnFloor)
            {   
                

                (nextBlock, nextBlockColour) = blocks.chooseBlock();


                isOnFloor = false;
            }

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);

            grid.Draw(playArea);
            preview.Draw(nextBlock, nextBlockColour);

            Raylib.EndDrawing();
        }
    }
}
