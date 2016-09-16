using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.GameObjects {
    class EnemyShip : GameObject{

        public EnemyShip(int x,int y,Vector2 vel):base(x,y) {

            this.x = x;
            this.y = y;
            this.velX = vel.X;
            this.velY = vel.Y;

        
        }
        public void TrackPlayer(Player player) {
            // Get directional vector between enemy and player 

            Vector2 Dir = new Vector2(player.x - this.x, player.y - this.y);
            Dir.Normalize();

           


        }


    }
}
