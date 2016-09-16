
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;



namespace SpaceGame
{
    public class GameObject
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float velX { get; set; }
        public float velY { get; set; }
        public float rotation { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        protected float _radius;
        public float Radius { get { return _radius; } set { _radius = value; } }
        protected Vector2 _forward;
        public Vector2 forward
        {
            get
            {
                return _forward;

            }
            set
            {

                _forward = value;
            }

        }
        public float scale { get; set; }
        public bool textureLoaded = false;
        public Vector2 Position
        {
            get
            {
                return new Vector2(x, y);
            }
        }
        public Texture2D tex { get; set; }
        public bool isAnimated { get; set; }

        private bool isBound = false;
        private GameObject boundObj;
        private Vector2 offset;
        // Animation
        public int rows { get; set; }
        public int columns { get; set; }
        public int currentFrame { get; set; }
        public int totalFrames { get; set; }
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 50;
        public void InitAnimation(int rows, int columns, int milPerFrame)
        {
            this.rows = rows;
            this.columns = columns;
            this.millisecondsPerFrame = milPerFrame;
            currentFrame = 0;
            totalFrames = this.rows * this.columns;


        }

        // Constructors 
        public GameObject(int x, int y, int width, int height, string Filename)
        {
            this.tex = cManager.content.Load<Texture2D>(Filename);
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.velX = 0;
            this.velY = 0;
            this.scale = 0.5f;
        }
        public GameObject(int x, int y, int width, int height)
        {

            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.velX = 0;
            this.velY = 0;
            this.scale = 0.5f;
        }
        public GameObject(int x, int y, int width, int height, ContentManager content)
        {

            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.velX = 0;
            this.velY = 0;
            this.scale = 0.5f;
        }
        public GameObject(int x, int y, int width, int height, bool isAnimated)
        {

            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.velX = 0;
            this.velY = 0;
            this.scale = 0.5f;
            this.isAnimated = isAnimated;
        }
        public GameObject(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
        public GameObject(int x, int y, Vector2 dir)
        {


        }
        public virtual void Update(float deltaTime)
        {
            if (!isBound)
            {
                x += velX;
                y += velY;
            }
            else
            {
                x = (boundObj.x - boundObj.width) + offset.X;
                y = (boundObj.y - boundObj.height) + offset.Y;

            }


            velX *= 0.99f;
            velY *= 0.99f;
            _forward = GetForward();
        }
        public Vector2 GetForward()
        {
            Vector3 dir = Vector3.Right;
            double angle = System.Convert.ToDouble(rotation);
            double sin = Math.Sin(angle);

            double cos = Math.Cos(angle);
            float newX = (float)(dir.X * cos - dir.Y * sin);
            float newY = (float)(dir.X * sin + dir.Y * cos);
            forward = new Vector2(newX, newY);
            return forward;



        }
        public void BindToObject(GameObject obj)
        {
            boundObj = obj;
            isBound = true;
            offset = new Vector2(x - obj.x, y- obj.y);
        }


    }
}
