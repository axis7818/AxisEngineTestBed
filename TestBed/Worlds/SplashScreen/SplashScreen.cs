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
using TestBed.Worlds.SplashScreen.Layers;

namespace TestBed.Worlds.SplashScreen
{
    public class SplashScreen : World
    {
        Layer LogoLayer;

        public SplashScreen(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice)
            : base(graphics, graphicsDevice)
        {
            BackgroundColor = Color.Black;
        }

        protected override void SetUpManagers(GraphicsDevice graphicsDevice)
        {
            CollisionManagers[ManagerNames.COLLISION_MGR] = new CollisionManager();
            DrawManagers[ManagerNames.DRAW_MGR] = new DrawManager(graphicsDevice);
            TimeManagers[ManagerNames.TIME_MGR] = new TimeManager();
        }

        private void SetUpLayers()
        {
            LogoLayer = new LogoLayer(CollisionManagers[ManagerNames.COLLISION_MGR],
                                      DrawManagers[ManagerNames.DRAW_MGR],
                                      TimeManagers[ManagerNames.TIME_MGR]);
            AddLayer(LogoLayer);
        }

        protected override void Load()
        {
            SetUpLayers();
        }

        protected override void Unload()
        {
            LogoLayer = null;
            Layers.Clear();
        }

        private class ManagerNames
        {
            public const string COLLISION_MGR = "CollisionMgr";
            public const string DRAW_MGR = "DrawMgr";
            public const string TIME_MGR = "TimeMgr";
        }
    }
}
