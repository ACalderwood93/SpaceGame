using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceGame.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SpaceGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        GameObject Background;
        AsteroidSpawner aSpawner;
        KeyboardState oldState;
        Viewport v;
        float deltaTime;
        bool spaceDown = false;
        Player player;
        public Camera2D cam;
        public static Random RNG = new Random();
        Vector2 offset;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1200;
            Content.RootDirectory = "Content";
            cManager.Init(Content);
            

        }


        protected override void Initialize()
        {


            base.Initialize();
            TimeManager.stillPlaying = true;
            TimeManager.time = 0;
            Renderer.init(GraphicsDevice);
            oldState = Keyboard.GetState();
            ScoreManager.Score = -1;
            cam = new Camera2D(GraphicsDevice.Viewport, new Vector2(player.x, player.y));
            offset =  new Vector2(Background.x - player.x ,Background.y- player.y);

        }
        protected override void LoadContent()
        {
            Background = new GameObject(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, "Backgrounds/darkPurple.png");
            player = new Player(500, 200, 250, 200);
            aSpawner = new AsteroidSpawner(graphics, Content);

            InterfaceManager.Init();
            AudioManager.Init();
           // Background.BindToObject(player);


        }
        protected override void UnloadContent()
        {
            cManager.content.Unload();

        }
        protected override void Update(GameTime gameTime)
        {
            TimeManager.Update();
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            cManager.GetTime(deltaTime);
            player.Update(deltaTime);
            aSpawner.Update(deltaTime);
            aSpawner.UpdateAsteroids(deltaTime);
            cam.Update(gameTime);
            cam.Follow(player,0);
            Background.Update(cManager.deltaTime);
           
            updateInput();

            #region Loops
            for (int i = 0; i < aSpawner.asteroids.Count; i++)
            {
                if (CollisionDetector.CheckCollisionRange(player, aSpawner.asteroids[i]))
                {
                    aSpawner.asteroids[i].Bounce();
                    TimeManager.Stop();
                    Console.WriteLine("Game Over you Lasted" + TimeManager.time + "Seconds, \n Final Score : " + ScoreManager.Score);
                    Initialize();
                }

                foreach (Laser l in player.lasers)
                {

                    if (CollisionDetector.CheckCollisionRange(l, aSpawner.asteroids[i]))
                    {
                        aSpawner.asteroids[i].hit = true;
                        l.hit = true;
                        ScoreManager.IncrementScore(10);
                        

                    }

                }

            }
            #endregion


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            Renderer.BeginDraw(cam);
            Renderer.Draw(Background);
            Renderer.Draw(player);

            aSpawner.asteroids.ForEach(x => Renderer.Draw(x));
            InterfaceManager.DrawUi();
            Renderer.EndDraw();
            base.Draw(gameTime);
        }
        void updateInput()
        {


            if (oldState.IsKeyDown(Keys.A))
            {
                player.rotation -= 2.0f * deltaTime;

            }
            if (oldState.IsKeyUp(Keys.Space) && spaceDown)
            {

                player.ShootLaser(deltaTime);
                spaceDown = false;
            }

            if (oldState.IsKeyDown(Keys.Space))
            {
                spaceDown = true;
            }

            if (oldState.IsKeyDown(Keys.D))
            {

                player.rotation += 2.0f * deltaTime;
            }

            if (oldState.IsKeyDown(Keys.W))
            {
                player.MoveForward(5.0f * player.boosterMutlipier, deltaTime);

            }

            if (oldState.IsKeyDown(Keys.S))
            {

                player.MoveForward(-5.0f, deltaTime);
            }

            if (oldState.IsKeyDown(Keys.LeftShift))
            {

                player.boosterMutlipier = 2.0f;


            }
            else
            {
                player.boosterMutlipier = 1.0f;

            }


            oldState = Keyboard.GetState();
        }
        void _BackgroundFollowPlayer(Player p,GameObject Background)
        {
            
            Background.x = (p.x - p.width) + offset.X;
            Background.y = (p.y - p.height) + offset.Y;

        }
    }
}
