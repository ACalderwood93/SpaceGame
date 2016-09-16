using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Helpers
{
    public static class CollisionDetector
    {

        public static bool CheckCollisionRange(Player g1, GameObject g2)
        {
            Vector2 obj1, obj2;
        
             obj1 = new Vector2(g1.x-g1.width/2, g1.y - g1.height/2);
            obj2 = new Vector2(g2.x, g2.y);
            double distance = Math.Abs(Vector2.Distance(obj1, obj2));
            return (distance < g1.Radius + g2.Radius);
        }
        public static bool CheckCollisionRange(GameObject g1, GameObject g2)
        {
            Vector2 obj1, obj2;

            obj1 = new Vector2(g1.x, g1.y);

            obj2 = new Vector2(g2.x, g2.y);
            double distance = Math.Abs(Vector2.Distance(obj1, obj2));
            return (distance < g1.Radius + g2.Radius && distance >0);
        }
        public static bool CheckCollisionRange(Laser g1, GameObject g2)
        {
            Vector2 obj1, obj2;

            obj1 = new Vector2(g1.x, g1.y - g1.height / 2);

            obj2 = new Vector2(g2.x, g2.y);
            double distance = Math.Abs(Vector2.Distance(obj1, obj2));
            return (distance < g1.Radius + g2.Radius);
        }
    }
}
