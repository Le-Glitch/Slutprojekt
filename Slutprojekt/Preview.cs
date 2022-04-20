using System;
using Raylib_cs;

public class Preview
{
    public void Draw(Rectangle[,] block, Color blockColour)
    {
        // Loads in the texture for a single tile of a block
        Texture2D blockTexture = Raylib.LoadTexture("tetrisBlock.png");

        Raylib.DrawRectangle(450, 30, 200, 100, Color.BLACK);
        Raylib.DrawRectangleLines(450, 30, 200, 100, Color.WHITE);

        foreach (Rectangle tile in block)
        {
            if((int) tile.width > 1)
            {
            Raylib.DrawTexture(blockTexture, (int) tile.x, (int) tile.y, blockColour);
            }
        }
    }

}
