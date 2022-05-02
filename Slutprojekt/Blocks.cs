using System;
using Raylib_cs;
using System.Numerics;

public class Blocks
{
    public Color colour;
    public Rectangle[,] position = new Rectangle[4, 4];

    int time = 0;
    int timePerDrop = 60;

    public Blocks()
    {
        Random generator = new Random();
        int blockChoice = generator.Next(1, 8);

        int posX = 490;
        int posY = 50;

        // Chooses the positions of the different blocks depending on what the random generator chooses
        switch (blockChoice)
        {
            //  Light Blue Block
            case (1):
                for (int x = 0; x < position.GetLength(0); x++)
                {
                    position[0, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }
                colour = new Color(0, 245, 241, 255);
                break;

            //  Purple Block
            case (2):
                for (int x = 0; x < 3; x++)
                {
                    position[0, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }
                posX = 520;
                posY = 80;

                position[1, 1] = new Rectangle(posX, posY, 30, 30);

                colour = new Color(158, 1, 240, 255);
                break;

            //  Blue Block
            case (3):
                position[0, 0] = new Rectangle(posX, posY, 30, 30);
                posY += 30;

                for (int x = 0; x < 3; x++)
                {
                    position[1, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }

                colour = new Color(0, 0, 244, 255);
                break;

            //  Orange Block
            case (4):
                posY += 30;

                for (int x = 0; x < 3; x++)
                {
                    position[1, x] = new Rectangle(posX, posY, 30, 30);
                    posX += 30;
                }
                posY -= 30;
                posX -= 30;

                position[0, 3] = new Rectangle(posX, posY, 30, 30);

                colour = new Color(243, 161, 0, 255);
                break;

            //  Yellow Block
            case (5):
                for (int y = 0; y < 2; y++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        position[y, x] = new Rectangle(posX, posY, 30, 30);

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
                        position[y, x] = new Rectangle(posX, posY, 30, 30);

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
                        position[y, x] = new Rectangle(posX, posY, 30, 30);

                        posX += 30;
                    }

                    posX -= 30;
                    posY += 30;
                }

                colour = new Color(244, 0, 0, 255);
                break;
        }
    }


    public void MoveBlockToPlayArea()
    {
        //  Moves blocks from the preview window to the play area
        for (int y = 0; y < position.GetLength(1); y++)
        {
            for (int x = 0; x < position.GetLength(0); x++)
            {
                Rectangle temp = position[x, y];

                temp.x -= 300;
                temp.y -= 20;

                position[x, y] = temp;
            }
        }
    }

    public void AutoMovement()
    {
        if (time >= timePerDrop)
        {
            for (int y = 0; y < position.GetLength(1); y++)
            {
                for (int x = 0; x < position.GetLength(0); x++)
                {
                    Rectangle tempRect = position[x, y];

                    tempRect.y += 30;

                    position[x, y] = tempRect;
                }
            }
            time = 0;
        }
        time++;
    }

    public bool HasReachedFloor(Rectangle[,] gridArray)
    {

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            foreach (Rectangle tile in position)
            {
                if (Raylib.CheckCollisionRecs(tile, gridArray[x, 19]))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Draw(Texture2D blockTexture)
    {
        // Draws the current block inside the grid
        foreach (Rectangle tile in position)
        {
            if (tile.width > 0)
            {
                Raylib.DrawTexture(blockTexture, (int)tile.x, (int)tile.y, colour);
            }
        }
    }
}