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

        // variables
        private float force = 10.0f;

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
            BodyParams parameters = new BodyParams(1, false, 300, 0.5f);
            Body = new Body(parameters) { Owner = this };
        }

        public override void UpdateThis(GameTime t)
        {
            Body.AddInternalForce(new Vector2(force * Input.GetAxis("LeftRight"), force * Input.GetAxis("UpDown")));

            base.UpdateThis(t);
        }
    }
}
