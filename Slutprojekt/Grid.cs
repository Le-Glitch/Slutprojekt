using System;
using Raylib_cs;
using System.Collections.Generic;

public class Grid
{
    public Rectangle[,] CreateGrid()
    {
        int xPos = 100, yPos = 30;
        Rectangle[,] grid = new Rectangle[10, 20];

        // Adds rectangles to an array to make a grid
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                grid[j, i] = new Rectangle(xPos, yPos, 30, 30);

                xPos += 30;
            }
            xPos = 100;
            yPos += 30;
        }

        return grid;
    }

    public void Draw(Rectangle[,] gridArray)
    {
        // Draws out the rectangles and outlines for them so that you can differentiate between them
        foreach (Rectangle box in gridArray)
        {
            Raylib.DrawRectangleRec(box, Color.BLACK);
            Raylib.DrawRectangleLinesEx(box, 0.5f, Color.WHITE);
        }

        // Outline for the outer part of the play area
        Raylib.DrawRectangleRoundedLines(new Rectangle(100, 30, 300, 600), 0, 1, 0.5f, Color.WHITE);
    }
}
