using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Engine
    {
        private static bool applicationShouldClose = false;

        /// <summary>
        /// Called to begin the application.
        /// </summary>
        public void Run()
        {
            // Initalizes important variables for the application.
            Start();

            // Loop until the application is told to close.
            while (!applicationShouldClose)
            {
                Update();
                Draw();
            }

            End();
        }

        /// <summary>
        /// Initalizes important variables for the application.
        /// </summary>
        private void Start()
        {

        }

        /// <summary>
        /// Loop until the application is told to close.
        /// </summary>
        private void Update()
        {

        }

        private void Draw()
        {

        }

        private void End()
        {

        }
    }
}
