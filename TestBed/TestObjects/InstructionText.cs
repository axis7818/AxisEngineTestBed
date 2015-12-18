using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AxisEngine.Visuals;
using TestBed.Content;

namespace TestBed.TestObjects
{
    class InstructionText : TextSprite
    {
        private static readonly Color color = Color.Black;
        private static SpriteFont font = ContentLoader.Content.Load<SpriteFont>(Assets.TEST_SPRITEFONT);

        public InstructionText(string text)
            : base(font, text, color)
        {

        }
    }
}
