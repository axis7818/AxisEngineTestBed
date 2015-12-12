using System;
using AxisEngine.Visuals;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TestBed.Content;

namespace TestBed.Worlds.SplashScreen
{
    public class LogoBillboard : TextSprite
    {
        private const string AXIS_ENGINE = "AxisEngine";
        private static readonly Color COLOR = new Color(0, 153, 0, 0);
        private static readonly SpriteFont FONT = ContentLoader.Content.Load<SpriteFont>(Assets.TEST_SPRITEFONT);

        private static readonly Vector2 POSITION = new Vector2(100, 100);
        private const float DURATION = 1000.0f; // the time for each animation section (in milliseconds)

        private float timer = 0.0f;
        private bool done = false;

        public LogoBillboard() 
            : base(FONT, AXIS_ENGINE, COLOR)
        {
            Position = POSITION;
        }

        public event EventHandler<EventArgs> Finished;

        protected override void UpdateThis(GameTime t)
        {
            base.UpdateThis(t);

            if (!done)
            {
                timer += t.ElapsedGameTime.Milliseconds;

                if (timer < DURATION)
                {
                    Color = new Color(COLOR.R, COLOR.G, (int)(timer * 255 / DURATION));
                }
                else if (timer < 2 * DURATION)
                {
                    Color = new Color(COLOR.R, COLOR.G, 225);
                }
                else if (timer < 3 * DURATION)
                {
                    Color = new Color(COLOR.R, COLOR.G, 225 - (int)((timer - 2 * DURATION) * 255 / DURATION));
                }
                else
                {
                    done = true;
                    if(Finished != null)
                    {
                        Finished(this, EventArgs.Empty);
                    }
                    Text = "DONE!";
                } 
            }
        }
    }
}
