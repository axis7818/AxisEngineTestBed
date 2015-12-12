using AxisEngine;
using TestBed.Content;
using AxisEngine.UserInput;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame.TestObjects
{
    public class InputMoveTestObject : WorldObject
    {
        // Components
        private InputManager Input;
        private Sprite Star;
        private Body Body;

        public InputMoveTestObject()
        {
            AddInput();
            AddRootStar();
            AddBody();
        }

        private void AddInput()
        {
            Input = new InputManager();
            Input.AddAxis("UpDown", Keys.S, Keys.W);
            Input.AddAxis("LeftRight", Keys.D, Keys.A);
            Input.Owner = this;
        }

        private void AddRootStar()
        {
            Star = new Sprite(ContentLoader.Content.Load<Texture2D>("ItemGlimer"))
            {
                Owner = this
            };
            Star.Center();
            Star.DrawOrder = 1;
        }

        private void AddBody()
        {
            Body = new Body() { Owner = this };
        }

        protected override void UpdateThis(GameTime t)
        {
            
        }
    }
}
