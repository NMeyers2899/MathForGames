using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private Actor _actor;

        /// <summary>
        /// Called to begin the application.
        /// </summary>
        public void Run()
        {
            // Initalizes important variables for the application.
            Start();

            // Loop until the application is told to close.
            while (!_applicationShouldClose)
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
            _actor = new Actor('P', new MathLibrary.Vector2 { X = 0, Y = 0 });
            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called each time the game loops.
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();
        }

        /// <summary>
        /// Draws all necessary information to the screen.
        /// </summary>
        private void Draw()
        {
            _scenes[_currentSceneIndex].Draw();
        }

        /// <summary>
        /// Is called when the application is about to close.
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
        }

        /// <summary>
        /// Adds a new scene to the _scenes array.
        /// </summary>
        /// <param name="scene"> The new scene being added to the array. </param>
        /// <returns> The index that the new scene was added to. </returns>
        public int AddScene(Scene scene)
        {
            // Creates a temporary array.
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            // Copies all of the old values from the array and adds them to the new array.
            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            // Sets the last index to be a new scene.
            tempArray[_scenes.Length] = scene;

            // Set the old array to the new array.
            _scenes = tempArray;

            // Return the last index.
            return _scenes.Length - 1;
        }
    }
}
