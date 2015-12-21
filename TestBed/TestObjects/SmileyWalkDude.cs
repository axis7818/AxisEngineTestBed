using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using AxisEngine;
using AxisEngine.AxisDebug;
using AxisEngine.UserInput;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using TestBed.Content;

namespace TestBed.TestObjects
{
    public class SmileyWalkDude : WorldObject
    {
        // assets
        private Texture2D _smileyWalkTexture;

        // components
        private Animator anim;
        private Body body;
        private InputManager input;
        private BoxCollider collider;

        // parameters
        private float _walkSpeed = 10;

        public SmileyWalkDude() : base()
        {
            // get the animation texture
            _smileyWalkTexture = ContentLoader.Content.Load<Texture2D>(Assets.SMILEY_WALK);

            // make the animator
            Animation standing = new Animation(_smileyWalkTexture, 300, 4, 4, 2);
            Animation walking = new Animation(_smileyWalkTexture, 300, 4, 4, 16, true);
            anim = new Animator(standing);
            anim.AddAnimation(AnimationNames.WALKING, walking);
            AddComponent(anim);

            // make the body
            body = new Body();
            body.Resistance = 0.9f;
            AddComponent(body);

            // make the collider
            collider = new BoxCollider(new Point(anim.Width * 5, anim.Height * 5));
            collider.WireFrame = WireFrames.BoxWireFrame(collider.Bounds);
            AddComponent(collider);
            collider.CollisionStart += UpdateMessage;
            collider.CollisionEnd += UpdateMessage;

            // make the input
            input = new InputManager();
            input.AddAxis(InputNames.X_AXIS, Keys.D, Keys.A);
            input.AddAxis(InputNames.Y_AXIS, Keys.S, Keys.W);
            AddComponent(input);
        }

        public void Walk(Vector2 direction)
        {
            if(direction.LengthSquared() > 0)
            {
                direction.Normalize();
                body.Move(_walkSpeed * direction);
            }
        }

        protected override void UpdateThis(GameTime t)
        {
            Vector2 walk = new Vector2(input.GetAxis(InputNames.X_AXIS), 
                                       input.GetAxis(InputNames.Y_AXIS));

            Walk(walk);
            if (body.Velocity.LengthSquared() <= 0.1f)
                anim.SetCurrentAnimation(AnimationNames.STANDING);
            else
                anim.SetCurrentAnimation(AnimationNames.WALKING);
        }

        private void UpdateMessage(object sender, CollisionEventArgs args)
        {
            if (args.IsColliding)
            {
                Log.WriteLine("Colliding!");
            }
            else
            {
                Log.WriteLine("No Colliding!");
            }
        }

        private static class AnimationNames
        {
            public const string STANDING = Animator.DEFAULT;
            public const string WALKING = "WALKING";
        }

        private static class InputNames
        {
            public const string X_AXIS = "X_AXIS";
            public const string Y_AXIS = "Y_AXIS";
        }
    }
}
