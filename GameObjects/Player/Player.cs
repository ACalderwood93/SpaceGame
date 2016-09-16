using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SpaceGame
{
    public class Player : GameObject
    {
        
        
        public float boosterMutlipier { get; set; }
        public List<Laser> lasers = new List<Laser>();
        private SoundEffect laser;
        
        public Player(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            boosterMutlipier = 0;
            this.tex = cManager.content.Load<Texture2D>("Player/playerShip.png");
            this.width = tex.Width;
            this.height = tex.Height;
            this.Radius = 20;
            
            
            this.laser = cManager.content.Load<SoundEffect>("Sounds/Laser");
            
        }


        public void ShootLaser(float deltaTime)
        {
            SoundEffectInstance l = laser.CreateInstance();
            l.Volume = 0.2f;
            
            if (l.State == SoundState.Stopped)
            {
                lasers.Add(new Laser((int)x, (int)y, forward));
                l.Play();
            }

        }

        public override void Update(float deltaTime)
        {

            x += velX;
            y += velY;
            velX *= 0.99f;
            velY *= 0.99f;
            UpdateLasers(deltaTime);
            _forward = GetForward();
            

        }

        protected void UpdateLasers(float deltaTime)
        {
            for (int i = 0; i < lasers.Count; i++ )
            {
                if (!lasers[i].hit)
                {
                    if (!lasers[i].textureLoaded)
                    {
                        lasers[i].tex = cManager.content.Load<Texture2D>("Player/Lasers/laserBlue01.png");
                        lasers[i].textureLoaded = true;
                        lasers[i].width = lasers[i].tex.Width;
                        lasers[i].height = lasers[i].tex.Height;
                    }

                    lasers[i].Update(deltaTime);
                }
                else
                {
                    lasers.Remove(lasers[i]);
                    i--;

                }


            }

        }
        public void Brake(float deltaTime)
        {

            velX *= 0.95f;
            velY *= 0.95f;


        }
        public void MoveForward(float moveSpeed, float deltaTime)
        {
            Vector2 forward = GetForward();

            velX += (forward.X * moveSpeed) * deltaTime;
            velY += (forward.Y * moveSpeed) * deltaTime;


        }
        



    }
}
