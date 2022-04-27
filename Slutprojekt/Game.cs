using System;
using Raylib_cs;
using System.Collections.Generic;

public class Game
{
    public static void PlayGame()
    {
        General.WindowSettings();

        Grid grid = new Grid();
        Blocks blockFunctions = new Blocks();
        Preview preview = new Preview();

        List<Blocks> blocks = new List<Blocks>();
        Blocks currentBlock = new Blocks();
        Blocks previewBlock = new Blocks();

        // Create arrays due to them having a constant size
        Rectangle[,] playArea = grid.CreateGrid();

        // Loads in the texture for a single tile of a block
        Texture2D blockTexture = Raylib.LoadTexture("tetrisBlock.png");

        bool isOnFloor = true;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);

            grid.Draw(playArea, currentBlock, blockTexture);
            preview.Draw(previewBlock, blockTexture);

            Raylib.EndDrawing();

            if(isOnFloor)
            {
                blocks.Add(currentBlock);
                currentBlock = blockFunctions.MoveBlockToPlayArea(currentBlock);

                isOnFloor = false;
            }
        }
    }
}
