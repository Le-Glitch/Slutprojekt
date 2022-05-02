using System;
using Raylib_cs;
using System.Collections.Generic;

public class Game
{
    public static void PlayGame()
    {
        General.WindowSettings();

        Grid grid = new Grid();

        Preview preview = new Preview();

        List<Blocks> blocks = new List<Blocks>();
        blocks.Clear();
        Blocks currentBlock = new Blocks();
        Blocks previewBlock = new Blocks();

        // Create arrays due to them having a constant size
        Rectangle[,] playArea = grid.CreateGrid();

        // Loads in the texture for a single tile of a block
        Texture2D blockTexture = Raylib.LoadTexture("tetrisBlock.png");

        bool isOnFloor = true;
        bool startup = true;

        while (!Raylib.WindowShouldClose())
        {

            if (isOnFloor)
            {
                if (!startup)
                {
                    blocks.Add(currentBlock);

                    currentBlock = previewBlock;
                    previewBlock = new Blocks();
                }
                
                currentBlock.MoveBlockToPlayArea();


                startup = false;
                isOnFloor = false;
            }

            currentBlock.AutoMovement();

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);

            grid.Draw(playArea);
            preview.Draw(previewBlock, blockTexture);
            currentBlock.Draw(blockTexture);
            foreach (Blocks block in blocks)
            {
                block.Draw(blockTexture);
            }

            Raylib.EndDrawing();

            isOnFloor = currentBlock.HasReachedFloor(playArea);
        }
    }
}
