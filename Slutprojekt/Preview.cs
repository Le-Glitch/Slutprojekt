using System;
using Raylib_cs;

public class Preview
{
    public void Draw(Blocks block, Texture2D blockTexture)
    {
        Raylib.DrawRectangle(450, 30, 200, 100, Color.BLACK);
        Raylib.DrawRectangleLines(450, 30, 200, 100, Color.WHITE);

        foreach (Rectangle tile in block.position)
        {
            if((int) tile.width > 1)
            {
            Raylib.DrawTexture(blockTexture, (int) tile.x, (int) tile.y, block.colour);
            }
        }
    }

}
