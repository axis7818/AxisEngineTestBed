using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.UserInput;
using AxisEngine.Visuals;
using TestBed.Content;
using TestGame.TestObjects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestBed.TestObjects;

namespace TestBed.Worlds.FirstTest.Layers
{
    public class MainLayer : Layer
    {
        private const string PAUSE = "Pause";
        private const string TOGGLE_OFFSET = "ToggelOffset";

        private bool _spritesCentered = true;

        Sprite CenterMarker;
        Sprite ScreenSizeMarker;
        InputManager Input;
        SmileyWalkDude smiley;

        public MainLayer(CollisionManager collisionMgr, DrawManager drawMgr, TimeManager timeMgr, params WorldObject[] worldObjects) 
            : base(collisionMgr, drawMgr, timeMgr, worldObjects)
        {
            SetUpWorldObjects();
        }

        private void SetUpWorldObjects()
        {
            // get user input object
            Input = new InputManager();
            Input.AddBinding(PAUSE, Keys.Escape);
            Input.AddBinding(TOGGLE_OFFSET, Keys.T);

            // create the center marker
            CenterMarker = new Sprite(ContentLoader.Content.Load<Texture2D>("ItemGlimer"));
            CenterMarker.Center();
            CenterMarker.Scale = new Vector2(0.1f, 0.1f);
            CenterMarker.Position = DrawManager.ScreenCenter.ToVector2();
            CenterMarker.Color = Color.Red;

            // create the screen size marker
            ScreenSizeMarker = new Sprite(ContentLoader.Content.Load<Texture2D>("ItemGlimer"));
            ScreenSizeMarker.Center();
            ScreenSizeMarker.Scale = new Vector2(0.1f, 0.1f);
            ScreenSizeMarker.Position = DrawManager.ScreenSize.ToVector2();
            ScreenSizeMarker.Color = Color.Red;

            // create smiley
            smiley = new SmileyWalkDude();
            smiley.Position = DrawManager.ScreenCenter.ToVector2();

            // add world objects
            Add(Input);
            Add(CenterMarker);
            Add(ScreenSizeMarker);
            Add(smiley);
        }

        public override void UpdateThis(GameTime t)
        {
            if (Input.GetBindingDown(PAUSE))
            {
                TimeManager.TimeStopped = !TimeManager.TimeStopped;
            }

            if (Input.GetBindingDown(TOGGLE_OFFSET))
            {
                _spritesCentered = !_spritesCentered;
                if (_spritesCentered)
                {
                    ScreenSizeMarker.Center();
                    CenterMarker.Center();
                }
                else
                {
                    ScreenSizeMarker.Offset(Vector2.Zero);
                    CenterMarker.Offset(Vector2.Zero);
                }
            }
        }
    }
}
