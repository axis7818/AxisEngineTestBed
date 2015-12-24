using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestBed.Content;
using TestBed.TestObjects;

namespace TestBed.Worlds.CameraTestWorld.Layers
{
    public class PlayerLayer : Layer
    {
        Sprite backdrop;
        SmileyWalkDude player;

        public PlayerLayer(CollisionManager collMgr, DrawManager drawMgr, TimeManager timeMgr) 
            : base(collMgr, drawMgr, timeMgr)
        {
            backdrop = new Sprite(ContentLoader.Content.Load<Texture2D>(Assets.TOP_DOWN_FIELD));
            backdrop.Scale = new Vector2(5, 5);
            Add(backdrop);

            player = new SmileyWalkDude();
            player.Position = new Vector2(300, 300);
            player.Scale = new Vector2(3, 3);
            Add(player);
        }

        protected override void UpdateThis(GameTime t)
        {
            
        }
    }
}
