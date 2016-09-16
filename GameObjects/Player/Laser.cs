using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Framework;
using System;

namespace SpaceGame
{
    
    public class Laser : GameObject
    {
        Vector2 dir;
        
        float moveSpeed = 25.0f;
        public bool hit = false;
        public Laser(int x, int y, Vector2 dir) : base(x,y,dir)
        {
            this.x = x;
            this.y = y;
            this.dir = dir;
            this.velX = dir.X * moveSpeed;
            this.velY = dir.Y * moveSpeed;
            this.rotation = (float)Math.Atan2(dir.Y, dir.X);
            this.z = 0;
            this.Radius = 20;
           
        }



    }
}
