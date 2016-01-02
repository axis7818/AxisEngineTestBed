using System;
using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestBed.Worlds.SplashScreen.Layers;

namespace TestBed.Worlds.SplashScreen
{
    public class SplashScreen : World
    {
        private LogoLayer _logoLayer;

        private Lakitu cameraMan;

        public SplashScreen(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice)
            : base(WorldNames.SPLASH_SCREEN, graphics, graphicsDevice)
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
            _logoLayer = new LogoLayer(CollisionManagers[ManagerNames.COLLISION_MGR],
                                      DrawManagers[ManagerNames.DRAW_MGR],
                                      TimeManagers[ManagerNames.TIME_MGR]);
            _logoLayer.Billboard.Finished += HandleWorldEnd;
            AddLayer(_logoLayer);

            cameraMan = new Lakitu(DefaultCamera);
            _logoLayer.Add(cameraMan);
            cameraMan.PanCamera(Vector2.Zero, new Vector2(1920 / 2, 1080 / 2), 2000);
        }

        protected override void Load()
        {
            SetUpLayers();
        }

        protected override void Unload()
        {
            _logoLayer.Billboard.Finished -= HandleWorldEnd;
            _logoLayer = null;

            cameraMan = null;
        }

        protected override void UpdateThis(GameTime t)
        {
            
        }

        private void HandleWorldEnd(object sender, EventArgs args)
        {
            End(WorldNames.BODY_SPRITE_ANIM_TEST_WORLD);
        }

        private struct ManagerNames
        {
            public const string COLLISION_MGR = "CollisionMgr";
            public const string DRAW_MGR = "DrawMgr";
            public const string TIME_MGR = "TimeMgr";
        }
    }
}