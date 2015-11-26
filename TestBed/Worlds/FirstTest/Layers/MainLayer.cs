using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.UserInput;
using AxisEngine.Visuals;
using TestBed.Content;
using TestGame.TestObjects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TestGame.Worlds.FirstTest.Layers
{
    public class MainLayer : Layer
    {
        Sprite CenterMarker;
        InputManager Input;

        public MainLayer(CollisionManager collisionMgr, DrawManager drawMgr, TimeManager timeMgr, params WorldObject[] worldObjects) : base(collisionMgr, drawMgr, timeMgr, worldObjects)
        {
            SetUpWorldObjects();
        }

        private void SetUpWorldObjects()
        {
            // get user input object
            Input = new InputManager();
            Input.AddBinding("TimeUp", Keys.PageUp);
            Input.AddBinding("TimeDown", Keys.PageDown);
            Input.AddBinding("Pause", Keys.Escape);

            // create the center marker
            CenterMarker = new Sprite(ContentLoader.Content.Load<Texture2D>("ItemGlimer"));
            CenterMarker.Center();
            CenterMarker.Scale = new Vector2(0.1f, 0.1f);
            CenterMarker.Position = DrawManager.ScreenCenter.PointToVector2();
            CenterMarker.DrawOrder = 0;
            CenterMarker.Color = Color.Red;

            // add world objects
            Add(Input);
            Add(CenterMarker);
        }

        public override void UpdateThis(GameTime t)
        {
            if (Input.GetBindingDown("Pause"))
            {
                TimeManager.TimeStopped = !TimeManager.TimeStopped;
            }
        }
    }
}
