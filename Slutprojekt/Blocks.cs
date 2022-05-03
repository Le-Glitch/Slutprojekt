using System;
using Raylib_cs;
using System.Numerics;

public class Blocks
{
    public Color colour;
    public Rectangle[,] position = new Rectangle[4, 4];
    public int blockID;
    public int rotation = 0;

    int time = 0;
    int timePerDrop = 60;

    public Blocks()
    {
        Random generator = new Random();
        blockID = 7;//generator.Next(1, 8);

        int posX = 490;
        int posY = 50;

        // Chooses the positions of the different blocks depending on what the random generator chooses
        switch (blockID)
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
        timePerDrop = 60;
        // Delays the time between each drop so it doesn't go too fast in the beginning
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

    public void HorizontalMovement()
    {
        // Moves the block to the left
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
        {
            for (int y = 0; y < position.GetLength(1); y++)
            {
                for (int x = 0; x < position.GetLength(0); x++)
                {
                    Rectangle tempRect = position[x, y];

                    tempRect.x -= 30;

                    position[x, y] = tempRect;


                }
            }
        }

        // Moves the block to the right
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
        {
            for (int y = 0; y < position.GetLength(1); y++)
            {
                for (int x = 0; x < position.GetLength(0); x++)
                {
                    Rectangle tempRect = position[x, y];

                    tempRect.x += 30;

                    position[x, y] = tempRect;


                }
            }
        }
    }

    public void IsInPlayArea()
    {
        // Here the code first excludes any parts of the array that aren't part of the block
        // Then it checks whether any block is outside of the play area to either the right or left
        // Finally if there is then it moves back the entire block by one tile length
        for (int y = 0; y < position.GetLength(1); y++)
        {
            for (int x = 0; x < position.GetLength(0); x++)
            {
                if (position[x, y].width > 0)
                {
                    if (position[x, y].x < 100)
                    {
                        for (int yy = 0; yy < position.GetLength(1); yy++)
                        {
                            for (int xx = 0; xx < position.GetLength(0); xx++)
                            {
                                if (position[xx, yy].width > 0)
                                {
                                    Rectangle tempRect = position[xx, yy];

                                    tempRect.x += 30;

                                    position[xx, yy] = tempRect;
                                }
                            }
                        }
                    }

                    if (position[x, y].x > 370)
                    {
                        for (int yy = 0; yy < position.GetLength(1); yy++)
                        {
                            for (int xx = 0; xx < position.GetLength(0); xx++)
                            {
                                if (position[xx, yy].width > 0)
                                {
                                    Rectangle tempRect = position[xx, yy];

                                    tempRect.x -= 30;

                                    position[xx, yy] = tempRect;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public bool HasReachedFloor(Rectangle[,] gridArray)
    {
        // Checks if the block has reached the floor and returns that information
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

    public void BlockCollisions(Rectangle[,] placedBlocks)
    {
        for (int x = 0; x < placedBlocks.GetLength(0); x++)
        {
            foreach (Rectangle tile in position)
            {
                if (Raylib.CheckCollisionRecs(tile, placedBlocks[x, 19]))
                {
                    Console.WriteLine("yeet");
                }
            }
        }
    }

    public void BlockRotation()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
        {
            switch (blockID)
            {
                case (1):
                    rotation = Rotation.LightBlueRotate(position, rotation);

                    break;

                case (2):
                    rotation = Rotation.PurpleRotate(position, rotation);

                    break;

                case (3):
                    rotation = Rotation.BlueRotate(position, rotation);

                    break;

                case (4):
                    rotation = Rotation.OrangeRotate(position, rotation);

                    break;

                case (6):
                    rotation = Rotation.GreenRotate(position, rotation);

                    break;

                case (7):
                    rotation = Rotation.RedRotate(position, rotation);

                    break;
            }
        }
    }

    public void SoftDrop(Rectangle[,] gridArray)
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            timePerDrop = 3;
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
    }

    public bool HardDrop(Rectangle[,] gridArray)
    {
        bool isOnFloor = false;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            while (!isOnFloor)
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

                isOnFloor = HasReachedFloor(gridArray);
            }
            return isOnFloor;
        }
        return isOnFloor;
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