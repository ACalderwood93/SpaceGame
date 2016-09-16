using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceGame.Helpers
{

    public static class Renderer
    {

        static SpriteBatch sb;

        public static void init(GraphicsDevice g)
        {

            sb = new SpriteBatch(g);

        }
        public static void BeginDraw(Camera2D cam)
        {
           // sb.Begin(SpriteSortMode.Deferred,null,null,null,null,null,new Matrix());
            sb.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, cam.Transform);
            //sb.Begin(0);
        }
        public static void EndDraw()
        {
            sb.End();

        }
        public static void DrawString(SpriteFont s,string mesage,Vector2 pos, Color colour)
        {
            sb.DrawString(s, mesage, pos, colour);

        }


        public static void Draw(GameObject obj)
        {

            sb.Draw(obj.tex, new Rectangle((int)obj.x, (int)obj.y, obj.width, obj.height), new Rectangle(0, 0, obj.width, obj.height), Color.White, obj.rotation, new Vector2(0, 0), SpriteEffects.None, 0);


        }
        public static void Draw(Player obj)
        {
            sb.Draw(obj.tex, new Rectangle((int)obj.x, (int)obj.y, obj.width / 2, obj.height / 2), new Rectangle(0, 0, obj.width, obj.height), Color.White, obj.rotation, new Vector2(obj.width / 2, obj.height / 2), SpriteEffects.None, obj.z);

            foreach (Laser l in obj.lasers)
            {
                try
                {
                    sb.Draw(l.tex, new Rectangle((int)l.x, (int)l.y, l.width, l.height), new Rectangle(0, 0, l.width, l.height), Color.White, l.rotation, new Vector2(0,l.height/2), SpriteEffects.None, l.z);
                    
                }
                catch (Exception)
                {


                }

            }

        }
        public static void Animate(GameObject obj, GameTime gameTime)
        {
            obj.timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (obj.timeSinceLastFrame > obj.millisecondsPerFrame)
            {
                obj.timeSinceLastFrame -= obj.millisecondsPerFrame;
                obj.currentFrame++;
            }

            if (obj.currentFrame == obj.totalFrames)
                obj.currentFrame = 0;

            int _width = obj.tex.Width / obj.columns;
            int _height = obj.tex.Height / obj.rows;
            int _row = (int)((float)obj.currentFrame / (float)obj.columns);
            int _column = obj.currentFrame % obj.columns;

            Rectangle sourceRectangle = new Rectangle(_width * _column, _height * _row, _width, _height);
            Rectangle destinationRectangle = new Rectangle((int)obj.x, (int)obj.y, _width, _height);

            sb.Draw(obj.tex, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
