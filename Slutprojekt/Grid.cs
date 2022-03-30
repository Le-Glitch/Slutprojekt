using System;
using Raylib_cs;

public class Grid
{
    public static Rectangle[,] CreateGrid(int xLength, int yLength)
    {
        int xPos = 100, yPos = 30;
        Rectangle[,] grid = new Rectangle[10, 20];

        for (int i = 0; i < yLength; i++)
        {
            for (int j = 0; j < xLength; j++)
            {
                grid[j, i] = new Rectangle(xPos, yPos, 30, 30);

                xPos += 30;
            }
            xPos = 100;
            yPos += 30;
        }

        return grid;
    }

    public static void Draw(Rectangle[,] gridArray)
    {
        foreach (Rectangle box in gridArray)
        {
            Raylib.DrawRectangleRec(box, Color.BLACK);
            Raylib.DrawRectangleLinesEx(box, 0.5f, Color.WHITE);
        }
        Raylib.DrawRectangleRoundedLines(new Rectangle(100, 30, 300, 600), 0, 1, 0.5f, Color.WHITE);
    }
}
