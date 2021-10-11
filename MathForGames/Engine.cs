using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private static Icon[,] _buffer;

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
                Thread.Sleep(150);
            }

            End();
        }

        /// <summary>
        /// Initalizes important variables for the application.
        /// </summary>
        private void Start()
        {
            Scene scene = new Scene();
            Actor actor = new Actor('P', new Vector2 { X = 2, Y = 0 }, "Phil", ConsoleColor.Magenta);
            Actor actor2 = new Actor('W', new Vector2 { X = 3, Y = 3 }, "Phil", ConsoleColor.Cyan);

            scene.AddActor(actor);
            scene.AddActor(actor2);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();

            Console.CursorVisible = false;
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
            // Sets the buffer to the current size of the console. Also clears the screen from the last draw.
            _buffer = new Icon[Console.WindowWidth, Console.WindowHeight - 1];

            // Resets the cursor to the top so the screen is drawn over.
            Console.SetCursorPosition(0, 0);

            _scenes[_currentSceneIndex].Draw();

            // For each position in buffer, print out the symbol in its chosen color.
            for(int y = 0; y < _buffer.GetLength(1); y++)
            {
                for(int x = 0; x < _buffer.GetLength(0); x++)
                {
                    // If the symbol at [x, y] is \0...
                    if(_buffer[x, y].Symbol == '\0')
                    {
                        // ...set the symbol at that position to an empty space.
                        _buffer[x, y].Symbol = ' ';
                    }

                    Console.ForegroundColor = _buffer[x, y].Color;
                    Console.Write(_buffer[x, y].Symbol);
                }

                // Skip to the next line once the end of a row has been reached.
                Console.WriteLine();
            }
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

        /// <summary>
        /// Adds an icon to the buffer to print to the screen in the next draw call.
        /// </summary>
        /// <param name="icon"> The character being printed an its color. </param>
        /// <param name="position"> The position that the character is being added to. </param>
        /// <returns> Whether or not it could be added to the buffer. </returns>
        public static bool TryRender(Icon icon, Vector2 position)
        {
            // If the position is out of bounds...
            if(position.X < 0 || position.X >= _buffer.GetLength(0) || position.Y < 0 || 
                position.Y >= _buffer.GetLength(1))
            {
                // ...it returns false.
                return false;
            }

            // Set the spot at the position given in the buffer to the given icon.
            _buffer[(int)position.X, (int)position.Y] = icon;

            return true;
        }
    }
}
