using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace SpaceGame
{
    public static class AudioManager
    {
         static ContentManager content;
         static Song Background;
         
        public static void Init()
        {

           
            Background = cManager.content.Load<Song>("Sounds/background");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Background);
        }

        


    }
}
