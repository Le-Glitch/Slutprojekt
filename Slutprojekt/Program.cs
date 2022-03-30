using System;

bool startTutorial = false;
bool startGame = true;

if (startTutorial == true)
{
    Tutorial.StartTutorial();
}

if(startGame == true)
{
    Game.PlayGame();
}