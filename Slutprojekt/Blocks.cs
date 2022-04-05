using System;
using Raylib_cs;

public class Blocks
{
    // Loads in the texture for a single piece of a block
    Texture2D blockTexture = Raylib.LoadTexture("tetrisBlock.png");

    public (Rectangle[], int) chooseBlock()
    {
        Random generator = new Random();

        // Makes an array due to the pieces always consisting of 4 blocks
        Rectangle[] upcomingBlock = new Rectangle[4];

        int blockChoice = generator.Next(1, 8);

        switch (blockChoice)
        {
            case (1):


                break;
        }

        return (upcomingBlock, blockChoice);
    }

    public Rectangle[] MoveBlockToPlayArea(Rectangle[] nextBlock, int whatBlock)
    {
        int xPos = 190; 

        switch (whatBlock)
        {
            case (1):
                for(int i = 0; i < nextBlock.Length; i++)
                {
                    nextBlock[i].x = xPos;

                    xPos += 30;
                }
                
                break;
        }

        return nextBlock;
    }

    public void Draw()
    {
        
    }
}