// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        int[] starsX = new int[400]; //X co-ordinate of star
        int[] starsY = new int[400]; //Y co-ordinate of star

        //Player
        int playerX = 400;
        int playerY = 400;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Assignment 2 Drawing");
            Window.TargetFPS = 60;


            for (int i = 0; i < starsX.Length; i++)
            {
                starsX[i] = Random.Integer(800);
            }
            for (int i = 0; i < starsY.Length; i++)
            {
                starsY[i] = Random.Integer(600);
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            for (int i = 0; i < starsX.Length; i++)
            {
                Draw.FillColor = Color.White;
                Draw.Circle(starsX[i], starsY[i], 2);
                if (starsX[i] >= 400) { starsX[i]++; }
                else if (starsX[i] < 400) { starsX[i]--; }
                 if (starsY[i] < 300) { starsY[i]--; }
                else if (starsY[i] >= 300) { starsY[i]++; }

                resetStar(i);
                 
            }

            //Draw Player
            //If player is on right side of screen. Simulates perspective
            if (playerX > 400)
            {
                Draw.LineColor = Color.Gray;
                Draw.FillColor = Color.Gray;
                Draw.Circle(playerX, playerY, 10);
                Draw.FillColor = Color.Gray;
                Draw.Rectangle(playerX + 30, playerY, 30, 15);
            }
            //If player is on left side of screen
            else if (playerX <= 400)
            {
                Draw.LineColor = Color.Gray;
                Draw.FillColor = Color.Gray;
                Draw.Circle(playerX, playerY, 10);
                Draw.FillColor = Color.Gray;
                Draw.Rectangle(playerX - 30, playerY - 10, 30, 20);
            }


            playerInputs();
        }

        /// <summary>
        /// Checks if player is making an input
        /// </summary>
        public void playerInputs()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right) == true)
            {
                playerX += 2;
            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.Left) == true)
            {
                playerX -= 2;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Down) == true)
            {
                playerY += 2;
            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.Up) == true)
            {
                playerY -= 2;
            }
        }

        /// <summary>
        /// Resets the star position if offscreen
        /// </summary>
        /// <param name="i"></param>
        public void resetStar(int i){
            if ((starsX[i] < 0) || (starsX[i] > 800)) { starsX[i] = Random.Integer(800); }
            else if ((starsY[i] < 0) || (starsY[i] > 600)) { starsY[i] = Random.Integer(600); }
        }
    }

}
