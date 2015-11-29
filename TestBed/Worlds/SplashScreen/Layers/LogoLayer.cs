using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using TestBed.Content;

namespace TestBed.Worlds.SplashScreen.Layers
{
    public class LogoLayer : Layer
    {
        TextSprite logo;

        public LogoLayer(CollisionManager coll, DrawManager draw, TimeManager time, params WorldObject[] worldObjects) 
            : base(coll, draw, time, worldObjects)
        {
            SetUpWorldObjects();
        }

        private void SetUpWorldObjects()
        {
            // add the logo
            SpriteFont font = ContentLoader.Content.Load<SpriteFont>(Assets.TEST_SPRITEFONT);
            logo = new TextSprite(font, "AXIS ENGINE TEST GAME", new Color(51, 204, 51));
            logo.Position = new Vector2(100, 100);
            Add(logo);
        }
    }
}
