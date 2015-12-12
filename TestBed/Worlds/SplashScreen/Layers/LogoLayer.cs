using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using TestBed.Content;
using System;

namespace TestBed.Worlds.SplashScreen.Layers
{
    public class LogoLayer : Layer
    {
        public LogoBillboard Billboard;

        public LogoLayer(CollisionManager coll, DrawManager draw, TimeManager time, params WorldObject[] worldObjects) 
            : base(coll, draw, time, worldObjects)
        {
            Billboard = new LogoBillboard();
            Add(Billboard);
        }

        protected override void UpdateThis(GameTime t)
        {
            
        }
    }
}
