using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AxisEngine;
using AxisEngine.Visuals;
using TestBed.Content;

namespace TestBed.TestObjects
{
    public class SmileyWalkDude : WorldObject
    {
        Animator anim;
        Texture2D smileyWalkTexture;

        public SmileyWalkDude() : base()
        {
            // make the animator
            smileyWalkTexture = ContentLoader.Content.Load<Texture2D>(Assets.SMILEY_WALK);
            Animation defaultAnimation = new Animation(smileyWalkTexture, 500, 4, 4);
            anim = new Animator(defaultAnimation);
            AddComponent(anim);
        }
    }
}
