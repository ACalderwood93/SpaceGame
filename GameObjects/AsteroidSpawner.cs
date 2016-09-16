using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SpaceGame.Helpers;

namespace SpaceGame
{
    class AsteroidSpawner
    {
        Vector2 spawnLocatation;
        Random rng = new Random();
        public List<Astroid> asteroids = new List<Astroid>();
        GraphicsDeviceManager graphics;
        ContentManager content;
        float spawnTimer = 0.5f; // how many seconds between the spawn of asteroids
        float spawnCounter = 4;
        int isRight = 0;

        public AsteroidSpawner(GraphicsDeviceManager graphics, ContentManager content)
        {
            this.graphics = graphics;
            this.content = content;
        }

        public void SpawnAsteroid()
        {
            isRight = rng.Next(0, 2);
            Vector2 startingVel;
            if (isRight.Equals(1))
            {

                spawnLocatation.X = graphics.PreferredBackBufferWidth + 50;
                startingVel.X = rng.Next(-5, -2);

            }
            else
            {
                spawnLocatation.X = -50;
                startingVel.X = rng.Next(2, 5);


            }
            startingVel.Y = rng.Next(-2, 2);
            spawnLocatation.Y = rng.Next(0, graphics.PreferredBackBufferHeight);
            asteroids.Add(new Astroid((int)spawnLocatation.X, (int)spawnLocatation.Y, startingVel));

        }
        public void Update(float deltaTime)
        {
            spawnCounter++;

            if (spawnCounter * deltaTime > spawnTimer)
            {
                spawnCounter = 0;
                SpawnAsteroid();
            }

            _CheckIfinBounds();

        }

        private void _CheckIfinBounds()
        {

            for (int i = 0; i < asteroids.Count; i++)
            {
                if (!asteroids[i].IsInBounds(graphics))
                {
                    asteroids.Remove(asteroids[i]);
                    i--;
                }



            }


        }


        public void UpdateAsteroids(float deltaTime)
        {

            for (int i = 0; i < asteroids.Count; i++)
            {

                if (!asteroids[i].hit)
                {

                    if (!asteroids[i].textureLoaded)
                    {

                        asteroids[i].InitAnimation(8, 8, 25);
                        asteroids[i].textureLoaded = true;
                        asteroids[i].z = -10;
                    }

                    asteroids[i].Update(deltaTime);
                }
                else
                {
                    if (asteroids[i].isFull)
                        SpawnAsteroidsAfterDeath(new Vector2(asteroids[i].x, asteroids[i].y));

                    asteroids.Remove(asteroids[i]);
                    i--;
                }
            }


        }
        public void Destroy(Astroid a)
        {
            asteroids.Remove(a);


        }
        private void SpawnAsteroidsAfterDeath(Vector2 oldPos)
        {
            Vector2 test;
            Random rng = new Random();

            test.X = rng.Next(-100, 100);
            test.Y = rng.Next(-100, 100);
            test.Normalize();

            for (int i = 0; i < rng.Next(1, 4); i++)
            {
                asteroids.Add(new Astroid((int)oldPos.X, (int)oldPos.Y, test, "meteorBrown_small1.png"));
                test.X = rng.Next(-100, 100);
                test.Y = rng.Next(-100, 100);
                test.Normalize();
                asteroids.Add(new Astroid((int)oldPos.X, (int)oldPos.Y, test, "meteorBrown_med1.png"));
                test.X = rng.Next(-100, 100);
                test.Y = rng.Next(-100, 100);
                test.Normalize();
                asteroids.Add(new Astroid((int)oldPos.X, (int)oldPos.Y, test, "meteorBrown_tiny2.png"));
            }


        }
    }
}
