using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

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
        blockID = generator.Next(1, 8);

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

    // Checks if the current block collides with any block while falling and makes it go back above and returns that the block has landed
    public bool VerticleBlockCollision(List<Blocks> placedBlocks)
    {
        bool hasLanded = false;
        for (int y = 0; y < position.GetLength(1); y++)
        {
            for (int x = 0; x < position.GetLength(0); x++)
            {
                foreach (Blocks block in placedBlocks)
                {
                    foreach (Rectangle tile in block.position)
                    {
                        if (Raylib.CheckCollisionRecs(position[x, y], tile))
                        {
                            for (int yy = 0; yy < position.GetLength(1); yy++)
                            {
                                for (int xx = 0; xx < position.GetLength(0); xx++)
                                {
                                    Rectangle tempRect = position[xx, yy];

                                    tempRect.y -= 30;

                                    position[xx, yy] = tempRect;
                                }
                            }
                            hasLanded = true;
                            return hasLanded;
                        }
                    }
                }
            }
        }
        return hasLanded;
    }

    public void HorizontalMovement(List<Blocks> blocks)
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

                    HorizontalCollision(blocks, "Left");
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

                    HorizontalCollision(blocks, "Right");
                }
            }
        }
    }

    // Checks whether the block is inside of another block after it has moved and gets moved the opposite direction of which it was going
    public void HorizontalCollision(List<Blocks> blocks, string direction)
    {
        for (int y = 0; y < position.GetLength(1); y++)
        {
            for (int x = 0; x < position.GetLength(0); x++)
            {
                foreach (Blocks block in blocks)
                {
                    foreach (Rectangle tile in block.position)
                    {
                        if (Raylib.CheckCollisionRecs(position[x, y], tile))
                        {
                            for (int yy = 0; yy < position.GetLength(1); yy++)
                            {
                                for (int xx = 0; xx < position.GetLength(0); xx++)
                                {
                                    Rectangle tempRect = position[xx, yy];

                                    if (direction == "Right")
                                    {
                                        tempRect.x -= 30;
                                    }
                                    if (direction == "Left")
                                    {
                                        tempRect.x += 30;
                                    }

                                    position[xx, yy] = tempRect;
                                }
                            }
                        }
                    }
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

    // Checks if the block has reached the floor and returns that information
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

    // Checks collisions between the falling block and already placed blocks
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

    // Rotates the current block by 90 degrees
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

    // Accelerates the speed at which the current block falls
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

    // Instantly makes the current block fall as far as possible
    // Returns two values because checking between block collision and floor collision is done seperately
    public (bool, bool) HardDrop(Rectangle[,] gridArray, List<Blocks> blocks)
    {
        bool hasLandedOnFloor = false;
        bool hasLandedOnBlock = false;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            while (!hasLandedOnFloor && !hasLandedOnBlock)
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

                hasLandedOnBlock = VerticleBlockCollision(blocks);
                hasLandedOnFloor = HasReachedFloor(gridArray);
            }
            return (hasLandedOnFloor, hasLandedOnBlock);
        }
        return (hasLandedOnFloor, hasLandedOnBlock);
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