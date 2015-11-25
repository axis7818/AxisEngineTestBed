using System;
using System.Collections.Generic;
using AxisEngine;
using AxisEngine.UserInput;
using AxisEngine.Visuals;
using AxisEngine.Physics;
using TestBed.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TestGame.TestObjects
{
    public class AnimTesObject : WorldObject
    {
        Body body = new Body(new BodyParams(1, false, 300, 1f));
        Texture2D sprite = ContentLoader.Content.Load<Texture2D>("ItemGlimer");
        Sprite rootSprite;
        Animator anim;
        InputManager input = new InputManager();

        float force = 15;

        public AnimTesObject()
        {
            List<Texture2D> sprites = new List<Texture2D>();
            sprites.Add(sprite);

            rootSprite = new Sprite(sprite)
            {
                Scale = new Vector2(0.1f, 0.1f),
                DrawOrder = 5
            };
            rootSprite.Center();

            BuildAnimation(sprites);            
            
            input.AddAxis("Horizontal", Keys.D, Keys.A);
            input.AddAxis("Vertical", Keys.S, Keys.W);

            AddComponent(body);
            AddComponent(rootSprite);
            AddComponent(input);
            AddComponent(anim);
        }

        private void BuildAnimation(List<Texture2D> sprites)
        {
            // initialize some values
            float length = 0.2f;
            anim = new Animator(sprites);
            AnimationFrame baseFrame = new AnimationFrame(0);

            // create the Idle animation
            Animation Idle = new Animation(length);
            Idle.Add(baseFrame);

            // create the Right animation
            Animation Right = new Animation(length);
            Right.Add(new AnimationFrame(0, Color.Red));
            Right.Add(new AnimationFrame(0, Color.Red, offset: new Vector2(10f, 0)));
            Right.Add(new AnimationFrame(0, Color.Red, offset: new Vector2(10f, 0), scale: new Vector2(1, 0.5f)));

            // create the left animation
            Animation Left = new Animation(length);
            Left.Add(new AnimationFrame(0, Color.Blue));
            Left.Add(new AnimationFrame(0, Color.Blue, offset: new Vector2(-10f, 0)));
            Left.Add(new AnimationFrame(0, Color.Blue, offset: new Vector2(-10f, 0), scale: new Vector2(1, 0.5f)));

            // create the up animation
            Animation Up = new Animation(length);
            Up.Add(new AnimationFrame(0, Color.Yellow));
            Up.Add(new AnimationFrame(0, Color.Yellow, offset: new Vector2(0, -10f)));
            Up.Add(new AnimationFrame(0, Color.Yellow, offset: new Vector2(0, -10f), scale: new Vector2(0.5f, 1)));

            // create the down animation
            Animation Down = new Animation(length);
            Down.Add(new AnimationFrame(0, Color.Green));
            Down.Add(new AnimationFrame(0, Color.Green, offset: new Vector2(0, 10f)));
            Down.Add(new AnimationFrame(0, Color.Green, offset: new Vector2(0, 10f), scale: new Vector2(0.5f, 1)));

            // add the animations to the animator
            anim.AddAnimation("Down", Down);
            anim.AddAnimation("Idle", Idle);            
            anim.AddAnimation("Up", Up);
            anim.AddAnimation("Left", Left);
            anim.AddAnimation("Right", Right);

            // set some initial values
            anim.Center = true;
            anim.DrawOrder = 1;
            anim.SetCurrentAnimation("Idle");
        }

        public override void UpdateThis(GameTime t)
        {
            float x = force * input.GetAxis("Horizontal");
            float y = force * input.GetAxis("Vertical");
            Vector2 inputForce = new Vector2(x, y);

            SetAnimation(inputForce);

            body.AddInternalForce(inputForce);

            base.UpdateThis(t);
        }

        private void SetAnimation(Vector2 inputForce)
        {
            if (inputForce == Vector2.Zero)
            {
                anim.SetCurrentAnimation("Idle");
                return;
            }

            if (Within45Degrees(Vector2.UnitX, inputForce))
            {
                anim.SetCurrentAnimation("Right");
            }
            else if (Within45Degrees(-Vector2.UnitY, inputForce))
            {
                anim.SetCurrentAnimation("Up");
            }
            else if (Within45Degrees(-Vector2.UnitX, inputForce))
            {
                anim.SetCurrentAnimation("Left");
            }
            else if(Within45Degrees(Vector2.UnitY, inputForce))
            {
                anim.SetCurrentAnimation("Down");
            }
        }

        private bool Within45Degrees(Vector2 A, Vector2 B)
        {
            float dot = DotProduct(A, B);
            double angle = Math.Acos(dot / (A.Length() * B.Length()));

            return angle <= Math.PI / 4;
        }

        private float DotProduct(Vector2 A, Vector2 B)
        {
            return A.X * B.X + A.Y * B.Y;
        }
    }
}
