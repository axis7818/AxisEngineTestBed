using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestGame.Worlds.FirstTest.Layers;

namespace TestGame.Worlds.FirstTest
{
    /* 
    This world tests some of the earlier features of AxisEngine such as positioning, scaling, managers, draw order, etc. 
    */
    public class BodySpriteAnimTestWorld : World
    {
        Layer mainLayer;

        public BodySpriteAnimTestWorld(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, ContentManager content, params Layer[] layers) : base(graphics, graphicsDevice, content)
        {
            SetUpManagers(graphicsDevice);
            SetUpLayers();
        }

        private void SetUpManagers(GraphicsDevice graphicsDevice)
        {
            CollisionManagers["CollisionMgr"] = new CollisionManager();
            DrawManagers["DrawMgr"] = new DrawManager(graphicsDevice);
            TimeManagers["TimeMgr"] = new TimeManager();
        }

        private void SetUpLayers()
        {
            mainLayer = new MainLayer(CollisionManagers["CollisionMgr"], DrawManagers["DrawMgr"], TimeManagers["TimeMgr"]);
            AddLayer(mainLayer);
        }
    }
}