using Raylib_cs;

// Includes a function for each block's specific rotation
public class Rotation
{
    public static int LightBlueRotate(Rectangle[,] tiles, int currentRotation)
    {
        switch (currentRotation)
        {
            case (0):
                tiles[0, 0].x += 30;
                tiles[0, 0].y += 30;

                tiles[0, 2].x -= 30;
                tiles[0, 2].y -= 30;

                tiles[0, 3].x -= 60;
                tiles[0, 3].y -= 60;

                currentRotation++;
                break;

            case (1):
                tiles[0, 0].x += 30;
                tiles[0, 0].y -= 30;

                tiles[0, 2].x -= 30;
                tiles[0, 2].y += 30;

                tiles[0, 3].x -= 60;
                tiles[0, 3].y += 60;

                currentRotation++;
                break;

            case (2):
                tiles[0, 0].x -= 30;
                tiles[0, 0].y -= 30;

                tiles[0, 2].x += 30;
                tiles[0, 2].y += 30;

                tiles[0, 3].x += 60;
                tiles[0, 3].y += 60;

                currentRotation++;
                break;

            case (3):
                tiles[0, 0].x -= 30;
                tiles[0, 0].y += 30;

                tiles[0, 2].x += 30;
                tiles[0, 2].y -= 30;

                tiles[0, 3].x += 60;
                tiles[0, 3].y -= 60;

                currentRotation = 0;
                break;
        }
        return currentRotation;
    }

    public static int PurpleRotate(Rectangle[,] tiles, int currentRotation)
    {
        switch (currentRotation)
        {
            case (0):
                tiles[0, 0].x += 30;
                tiles[0, 0].y += 30;

                tiles[0, 2].x -= 30;
                tiles[0, 2].y -= 30;

                tiles[1, 1].x += 30;
                tiles[1, 1].y -= 30;

                currentRotation++;
                break;

            case (1):
                tiles[0, 0].x += 30;
                tiles[0, 0].y -= 30;

                tiles[0, 2].x -= 30;
                tiles[0, 2].y += 30;

                tiles[1, 1].x -= 30;
                tiles[1, 1].y -= 30;

                currentRotation++;
                break;

            case (2):
                tiles[0, 0].x -= 30;
                tiles[0, 0].y -= 30;

                tiles[0, 2].x += 30;
                tiles[0, 2].y += 30;

                tiles[1, 1].x -= 30;
                tiles[1, 1].y += 30;

                currentRotation++;
                break;

            case (3):
                tiles[0, 0].x -= 30;
                tiles[0, 0].y += 30;

                tiles[0, 2].x += 30;
                tiles[0, 2].y -= 30;

                tiles[1, 1].x += 30;
                tiles[1, 1].y += 30;

                currentRotation = 0;
                break;
        }
        return currentRotation;
    }

    public static int BlueRotate(Rectangle[,] tiles, int currentRotation)
    {
        switch (currentRotation)
        {
            case (0):
                tiles[0, 0].x += 30;
                tiles[0, 0].y += 30;

                tiles[1, 0].x += 60;

                tiles[1, 1].x += 30;
                tiles[1, 1].y -= 30;

                tiles[1, 2].y -= 60;

                currentRotation++;
                break;

            case (1):
                tiles[0, 0].x += 30;
                tiles[0, 0].y -= 30;

                tiles[1, 0].y -= 60;

                tiles[1, 1].x -= 30;
                tiles[1, 1].y -= 30;

                tiles[1, 2].x -= 60;

                currentRotation++;
                break;

            case (2):
                tiles[0, 0].x -= 30;
                tiles[0, 0].y -= 30;

                tiles[1, 0].x -= 60;

                tiles[1, 1].x -= 30;
                tiles[1, 1].y += 30;

                tiles[1, 2].y += 60;

                currentRotation++;
                break;

            case (3):
                tiles[0, 0].x -= 30;
                tiles[0, 0].y += 30;

                tiles[1, 0].y += 60;

                tiles[1, 1].x += 30;
                tiles[1, 1].y += 30;

                tiles[1, 2].x += 60;

                currentRotation = 0;
                break;
        }
        return currentRotation;
    }

    public static int OrangeRotate(Rectangle[,] tiles, int currentRotation)
    {
        switch (currentRotation)
        {
            case (0):
                tiles[0, 3].x -= 30;
                tiles[0, 3].y -= 30;

                tiles[1, 0].x += 60;

                tiles[1, 1].x += 30;
                tiles[1, 1].y -= 30;

                tiles[1, 2].y -= 60;

                currentRotation++;
                break;

            case (1):
                tiles[0, 3].x -= 30;
                tiles[0, 3].y += 30;

                tiles[1, 0].y -= 60;

                tiles[1, 1].x -= 30;
                tiles[1, 1].y -= 30;

                tiles[1, 2].x -= 60;

                currentRotation++;
                break;

            case (2):
                tiles[0, 3].x += 30;
                tiles[0, 3].y += 30;

                tiles[1, 0].x -= 60;

                tiles[1, 1].x -= 30;
                tiles[1, 1].y += 30;

                tiles[1, 2].y += 60;

                currentRotation++;
                break;

            case (3):
                tiles[0, 3].x += 30;
                tiles[0, 3].y -= 30;

                tiles[1, 0].y += 60;

                tiles[1, 1].x += 30;
                tiles[1, 1].y += 30;

                tiles[1, 2].x += 60;

                currentRotation = 0;
                break;
        }
        return currentRotation;
    }

    public static int GreenRotate(Rectangle[,] tiles, int currentRotation)
    {
        switch (currentRotation)
        {
            case (0):
                tiles[0, 1].x -= 30;
                tiles[0, 1].y -= 30;

                tiles[1, 0].x += 60;

                tiles[1, 1].x += 30;
                tiles[1, 1].y -= 30;

                currentRotation++;
                break;

            case (1):
                tiles[0, 1].x += 30;
                tiles[0, 1].y += 30;

                tiles[1, 0].x -= 60;

                tiles[1, 1].x -= 30;
                tiles[1, 1].y += 30;

                currentRotation = 0;
                break;
        }
        return currentRotation;
    }

    public static int RedRotate(Rectangle[,] tiles, int currentRotation)
    {
        switch (currentRotation)
        {
            case (0):
                tiles[0, 0].x += 30;
                tiles[0, 0].y -= 30;

                tiles[1, 0].x -= 30;
                tiles[1, 0].y -= 30;

                tiles[1, 1].x -= 60;

                currentRotation++;
                break;

            case (1):
                tiles[0, 0].x -= 30;
                tiles[0, 0].y += 30;

                tiles[1, 0].x += 30;
                tiles[1, 0].y += 30;

                tiles[1, 1].x += 60;

                currentRotation = 0;
                break;
        }
        return currentRotation;
    }
}