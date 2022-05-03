using System;
using Raylib_cs;
using System.Collections.Generic;

public class Game
{
    public static void PlayGame()
    {
        Raylib.InitWindow(750, 750, "Tetris");
        Raylib.SetTargetFPS(60);
        Raylib.SetExitKey(0);

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

        bool hasLandedOnFloor = true;
        bool hasLandedOnBlock = true;
        bool startup = true;

        while (!Raylib.WindowShouldClose())
        {
            // Checks if the current block is on the ground or not
            if (hasLandedOnFloor || hasLandedOnBlock)
            {
                // Checks that this isn't the first run through of the code
                if (!startup)
                {
                    // Adds the current block to the larger array of tiles
                    blocks.Add(currentBlock);

                    // Sets the current block to the block in the preview window
                    currentBlock = previewBlock;

                    // Generates a new block in the preview window which will then be used as the next block
                    previewBlock = new Blocks();
                }

                // Moves the next chosen block to the playing grid
                currentBlock.MoveBlockToPlayArea();


                startup = false;
                hasLandedOnFloor = false;
                hasLandedOnBlock = false;
            }

            currentBlock.AutoMovement();

            currentBlock.HorizontalMovement(blocks);

            currentBlock.BlockRotation();

            currentBlock.IsInPlayArea();

            currentBlock.SoftDrop(playArea);

            (hasLandedOnFloor, hasLandedOnBlock) = currentBlock.HardDrop(playArea, blocks);


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

            // Sets a bool depending on whether or not the current block has reached the floor
            // If it has then you will lose control of that block and the next one will start falling
            hasLandedOnFloor = currentBlock.HasReachedFloor(playArea);

            hasLandedOnBlock = currentBlock.VerticleBlockCollision(blocks);
        }
    }
}
