using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        /// <summary>
        ///  Array that contains all actors in the scene.
        /// </summary>
        private Actor[] _actors;

        public Scene()
        {
            _actors = new Actor[0];
        }

        public void Start()
        {
            // Loops through the _actors array and gets all actors in it to Start.
            for(int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void End()
        {

        }

        /// <summary>
        /// Appends a new actor to the scenes array of actors.
        /// </summary>
        /// <param name="actor"> The actor being added to the scene. </param>
        public void AddActor(Actor actor)
        {
            // Creates a temporary array.
            Actor[] tempArray = new Actor[_actors.Length + 1];

            // Copies all of the old values from the array and adds them to the new array.
            for (int i = 0; i < _actors.Length; i++)
            {
                tempArray[i] = _actors[i];
            }

            // Sets the last index to be a new scene.
            tempArray[_actors.Length] = actor;

            // Set the old array to the new array.
            _actors = tempArray;
        }

        /// <summary>
        /// Checks to see if a given actor can be removed from the array of actors.
        /// </summary>
        /// <param name="actor"> The actor being removed. </param>
        /// <returns> If the actor could be removed. </returns>
        public bool TryRemoveActor(Actor actor)
        {
            // Creates a variable that helps keep track of when an actor is removed from the _actors array.
            bool actorRemoved = false;

            // Creates a temporary array.
            Actor[] tempArray = new Actor[_actors.Length - 1];

            int j = 0;

            // Copies all of the old values from the array, except for the one being removed.
            for (int i = 0; i < _actors.Length; i++)
            {
                // If the current actor in _actors is not equal to actor...
                if(_actors[i] != actor)
                {
                    // ...set the tempArray at j to the actor at i in _actors and increment j.
                    tempArray[j] = _actors[i];
                    j++;
                }
                // If the current actor in _actors is equal to actor...
                else
                {
                    // ...set actorRemoved to true.
                    actorRemoved = true;
                }
            }

            // If an actor has been removed...
            if (actorRemoved)
            {
                // ...set the old array to the new array.
                _actors = tempArray;
            }

            return actorRemoved;
        }
    }
}
