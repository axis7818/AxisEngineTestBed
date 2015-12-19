using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxisEngine;
using AxisEngine.Physics;
using Microsoft.Xna.Framework;

namespace TestBed.TestObjects
{
    public class Corral : WorldObject
    {
        BoxCollider bounds;
        WorldObject subject;

        public Corral(Point size, WorldObject toTrack)
        {
            subject = toTrack;

            bounds = new BoxCollider(size);
            AddComponent(bounds);
            bounds.CollisionStart += TriggerEvents;
            bounds.CollisionEnd += TriggerEvents;
        }

        public event EventHandler<WorldObjectEventArgs> Entered;
        public event EventHandler<WorldObjectEventArgs> Exited;

        private void TriggerEvents(object sender, CollisionEventArgs args)
        {
            if (args.IsColliding && Entered != null)
            {
                Entered(this, new WorldObjectEventArgs(args.Other.RootObject));
            }
            else if(!args.IsColliding && Exited != null)
            {
                Exited(this, new WorldObjectEventArgs(args.Other.RootObject));
            }
        }

        protected override void UpdateThis(GameTime t)
        {
            
        }
    }
}
