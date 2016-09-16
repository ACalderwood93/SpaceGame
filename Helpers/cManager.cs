using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame
{
    public static class cManager
    {
       public static ContentManager content;
       public static float deltaTime;

        public static void Init(ContentManager c)
        {
            content = c;
            
        }

        public static void GetTime(float d)
        {

            deltaTime = d;
        }

    }
}
