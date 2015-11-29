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
        Layer mainLayer;

        public BodySpriteAnimTestWorld(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, params Layer[] layers) 
            : base(graphics, graphicsDevice)
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
        }

        protected override void Unload()
        {
            mainLayer = null;
            Layers.Clear();
        }
    }
}