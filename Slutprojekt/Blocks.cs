using System;
using Raylib_cs;

public class Blocks
{

    public (Rectangle[,], Color) chooseBlock()
    {
        Random generator = new Random();
        Color colour = new Color(0, 0, 0, 0);

        // Makes an array due to the pieces always consisting of 4 blocks
        Rectangle[,] upcomingBlock = new Rectangle[4, 4];

        int blockChoice = generator.Next(1, 8);

        int posX = 490;
        int posY = 50;

        switch (blockChoice)
        {
            //  Light Blue Block
            case (1):
                for (int x = 0; x < upcomingBlock.GetLength(0); x++)
                {
                    upcomingBlock[0, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }
                colour = new Color(0, 245, 241, 255);
                break;

            //  Purple Block
            case (2):
                for (int x = 0; x < 3; x++)
                {
                    upcomingBlock[0, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }
                posX = 520;
                posY = 80;

                upcomingBlock[1, 1] = new Rectangle(posX, posY, 30, 30);

                colour = new Color(158, 1, 240, 255);
                break;

            //  Blue Block
            case (3):
                upcomingBlock[0, 0] = new Rectangle(posX, posY, 30, 30);
                posY += 30;

                for (int x = 0; x < 3; x++)
                {
                    upcomingBlock[1, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }

                colour = new Color(0, 0, 244, 255);
                break;

            //  Orange Block
            case (4):
                for (int x = 0; x < 3; x++)
                {
                    upcomingBlock[1, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }

                upcomingBlock[0, 3] = new Rectangle(posX, posY, 30, 30);

                colour = new Color(243, 161, 0, 255);
                break;

            //  Yellow Block
            case (5):
                for (int y = 0; y < 2; y++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        upcomingBlock[y, x] = new Rectangle(posX, posY, 30, 30);

                        posX += 30;
                    }

                    posY += 30;
                    posX = 490;
                }

                colour = new Color(241, 242, 1, 255);
                break;

            //  Green Block
            case (6):
                posY = 80;

                for (int y = 1; y > -1; y--)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        upcomingBlock[y, x] = new Rectangle(posX, posY, 30, 30);

                        posX += 30;
                    }

                    posX -= 30;
                    posY -= 30;
                }

                colour = new Color(0, 244, 0, 255);
                break;

            //  Red Block
            case (7):
                for (int y = 0; y < 2; y++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        upcomingBlock[y, x] = new Rectangle(posX, posY, 30, 30);

                        posX += 30;
                    }

                    posX -= 30;
                    posY += 30;
                }

                colour = new Color(244, 0, 0, 255);
                break;
        }

        return (upcomingBlock, colour);
    }



    public Rectangle[,] MoveBlockToPlayArea(Rectangle[,] block)
    {
        for (int y = 0; y < block.GetLength(1); y++)
        {
            for (int x = 0; x < block.GetLength(0); x++)
            {
                Rectangle temp = block[x, y];

                temp.x -= 100;
                temp.y -= 20;

                block[x, y] = temp;
            }
        }

        return block;
    }
}