using System;
using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestBed.Worlds.FirstTest.Layers;

namespace TestBed.Worlds.FirstTest
{
    /* 
    This world tests some of the earlier features of AxisEngine such as positioning, scaling, managers, draw order, etc. 
    */
    public class BodySpriteAnimTestWorld : World
    {
        MainLayer mainLayer;

        public BodySpriteAnimTestWorld(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, params Layer[] layers) 
            : base(WorldNames.BODY_SPRITE_ANIM_TEST_WORLD, graphics, graphicsDevice)
        {

        }

        private void SetUpLayers()
        {
            mainLayer = new MainLayer(CollisionManagers["CollisionMgr"], DrawManagers["DrawMgr"], TimeManagers["TimeMgr"]);
            AddLayer(mainLayer);
        }

        protected override void SetUpManagers(GraphicsDevice graphicsDevice)
        {
            CollisionManagers["CollisionMgr"] = new CollisionManager();
            DrawManagers["DrawMgr"] = new DrawManager(graphicsDevice);
            TimeManagers["TimeMgr"] = new TimeManager();
        }

        protected override void Load()
        {
            SetUpLayers();
            mainLayer.OuterBounds.Exited += HandleWorldEnd;
        }
        
        protected override void Unload()
        {
            mainLayer.OuterBounds.Exited -= HandleWorldEnd;
            mainLayer = null;
            Layers.Clear();
        }

        private void HandleWorldEnd(object sender, EventArgs args)
        {
            Quit();
        }
    }
}