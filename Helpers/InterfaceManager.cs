using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Helpers
{
   public static  class InterfaceManager
    {

        //public static SpriteFont uiText;


       public static void Init()
       {
          // uiText = cManager.content.Load<SpriteFont>("Score");
          


       }

       public static void DrawUi()
       {
           //Renderer.DrawString(uiText, "Score : " + ScoreManager.Score, new Vector2(25, 25), Color.White);
           //Renderer.DrawString(uiText, "Time : " + (int)TimeManager.time, new Vector2(1000, 25), Color.White);

       }
       
    }
}
