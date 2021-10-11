using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Player(char icon, float x, float y, float speed, string name = "Player", 
            ConsoleColor color = ConsoleColor.White) : base(icon, x, y, name, color)
        {
            _speed = speed;
        }

        public override void Update()
        {
            Vector2 moveDirection = new Vector2();

            ConsoleKey keyPress = Engine.GetNextKey();

            if(keyPress == ConsoleKey.A)
                moveDirection = new Vector2 { X = -1 };
            if (keyPress == ConsoleKey.D)
                moveDirection = new Vector2 { X = 1 };
            if (keyPress == ConsoleKey.W)
                moveDirection = new Vector2 { Y = -1 };
            if (keyPress == ConsoleKey.S)
                moveDirection = new Vector2 { Y = 1 };
            if (keyPress == ConsoleKey.LeftArrow)
                moveDirection = new Vector2 { X = -1 };
            if (keyPress == ConsoleKey.RightArrow)
                moveDirection = new Vector2 { X = 1 };
            if (keyPress == ConsoleKey.UpArrow)
                moveDirection = new Vector2 { Y = -1 };
            if (keyPress == ConsoleKey.DownArrow)
                moveDirection = new Vector2 { Y = 1 };

            moveDirection.X *= Speed;
            moveDirection.Y *= Speed;

            Velocity = moveDirection;

            Position = new Vector2 { X = Position.X + Velocity.X, Y = Position.Y + Velocity.Y };
        }
    }
}
