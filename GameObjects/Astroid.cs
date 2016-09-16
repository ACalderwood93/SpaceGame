using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame
{
    class Astroid : GameObject
    {
        Random rng = new Random();
        public const float rot = 0.5f;
        private bool _bounced;
        private float bounceCounter = 0;
        private int bounceTime = 1;
        public bool hit = false;
        public bool isFull = true;
        public Astroid(int x, int y, int width, int height)
            : base(x, y, width, height)
        {

        }

        public Astroid(int x, int y, Vector2 dir, string filename)
            : base(x, y)
        {
            this.tex = cManager.content.Load<Texture2D>("Enemies/Meteors/" + filename);
            this.velX = dir.X;
            this.velY = dir.Y;
            this.width = this.tex.Width;
            this.height = this.tex.Height;
            this.z = 0;
            this.Radius = this.width / 2;
            this.isFull = false;


        }

        public Astroid(int x, int y, Vector2 dir)
            : base(x, y)
        {

            this.tex = cManager.content.Load<Texture2D>("Enemies/Meteors/meteorBrown_big1.png");
            this.velX = dir.X;
            this.velY = dir.Y;
            this.width = this.tex.Width;
            this.height = this.tex.Height;
            this.z = 0;
            this.Radius = this.width / 2;
        }

        public override void Update(float deltaTime)
        {
            x += velX;
            y += velY;

            if (_bounced)
                bounceCounter++;

            if (bounceCounter * cManager.deltaTime > bounceTime)
            {
                _bounced = false;
                bounceCounter = 0;

            }
            this.rotation += rot * deltaTime;


        }

        public bool IsInBounds(GraphicsDeviceManager graphics)
        {

            if (x > graphics.PreferredBackBufferWidth + 50)
                return false;
            if (x < 0 - 50)
                return false;
            if (y < 0 - 50)
                return false;
            if (y > graphics.PreferredBackBufferWidth + 50)
                return false;


            return true;
        }

        public void Bounce()
        {
            if (!_bounced)
            {
                this.velX *= -1;
                _bounced = true;
            }

        }
    }
}
