using System;
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
        BoxCollider centerCollider;
        Sprite ScreenSizeMarker;
        InputManager Input;
        SmileyWalkDude smiley;
        InstructionText instructions;
        Corral outerBounds;

        public MainLayer(CollisionManager collisionMgr, DrawManager drawMgr, TimeManager timeMgr, params WorldObject[] worldObjects) 
            : base(collisionMgr, drawMgr, timeMgr, worldObjects)
        {
            SetUpWorldObjects();
        }

        public Corral OuterBounds
        {
            get { return outerBounds; }
        }

        private void SetUpWorldObjects()
        {
            // get user input object
            Input = new InputManager();
            Input.AddBinding(PAUSE, Keys.Escape);
            Input.AddBinding(TOGGLE_OFFSET, Keys.T);
            Add(Input);

            // create the center marker
            CenterMarker = new Sprite(ContentLoader.Content.Load<Texture2D>("ItemGlimer"));
            CenterMarker.Center();
            CenterMarker.Scale = new Vector2(0.1f, 0.1f);
            CenterMarker.Position = DrawManager.ScreenCenter.ToVector2();
            CenterMarker.Color = Color.Red;
            Add(CenterMarker);

            // create the center collider
            centerCollider = new BoxCollider(new Point(20, 20));
            centerCollider.Position = DrawManager.ScreenCenter.ToVector2();
            centerCollider.Center();
            Add(centerCollider);

            // create the screen size marker
            ScreenSizeMarker = new Sprite(ContentLoader.Content.Load<Texture2D>("ItemGlimer"));
            ScreenSizeMarker.Center();
            ScreenSizeMarker.Scale = new Vector2(0.1f, 0.1f);
            ScreenSizeMarker.Position = DrawManager.ScreenSize.ToVector2();
            ScreenSizeMarker.Color = Color.Red;
            Add(ScreenSizeMarker);

            // create smiley
            smiley = new SmileyWalkDude();
            smiley.Position = DrawManager.ScreenCenter.ToVector2() / 2;
            Add(smiley);

            // create the instruction text
            instructions = new InstructionText("Move the Character off of the screen to continue.");
            instructions.Position = new Vector2(200, 50);
            instructions.DrawOrder = 1;
            Add(instructions);

            // create the outerBounds
            Point size = new Point(DrawManager.ScreenSize.X - 10, DrawManager.ScreenSize.Y - 10);
            outerBounds = new Corral(size, smiley);
            outerBounds.Position = new Vector2(5, 5);
            Add(outerBounds);
        }

        protected override void UpdateThis(GameTime t)
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
