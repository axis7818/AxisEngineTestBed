﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxisEngine;
using AxisEngine.Physics;
using AxisEngine.Visuals;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TestBed.Worlds.CameraTestWorld.Layers;

namespace TestBed.Worlds.CameraTestWorld
{
    /*
    A world for testing the functionality of the camera
    */
    class CameraTestWorld : World
    {
        PlayerLayer playerLayer;
        
        Camera[,] splitScreenGrid;
        private int splitScreenRows = 3;
        private int splitScreenColumns = 3;
        private int borderWidth = 10;

        public CameraTestWorld(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice) 
            : base(WorldNames.CAMERA_TEST_WORLD, graphics, graphicsDevice)
        {
            
        }

        protected override void Load()
        {
            playerLayer = new PlayerLayer(CollisionManagers[ManagerNames.COLLISION_MANAGER], DrawManagers[ManagerNames.DRAW_MANAGER], TimeManagers[ManagerNames.TIME_MANAGER]);
            AddLayer(playerLayer);
            
            splitScreenGrid = this.SetSplitScreenGrid(splitScreenRows, splitScreenColumns, borderWidth);

            Lakitu camera11 = new Lakitu(splitScreenGrid[1, 1]);
            camera11.ZoomCamera(1, 0.5f, 3000);
            playerLayer.Add(camera11);
        }

        protected override void SetUpManagers(GraphicsDevice graphicsDevice)
        {
            CollisionManagers[ManagerNames.COLLISION_MANAGER] = new CollisionManager();
            DrawManagers[ManagerNames.DRAW_MANAGER] = new DrawManager(GraphicsDevice);
            TimeManagers[ManagerNames.TIME_MANAGER] = new TimeManager();
        }

        protected override void Unload()
        {
            playerLayer = null;
        }

        protected override void UpdateThis(GameTime t)
        {
            foreach(Camera c in splitScreenGrid)
            {
                c.Position = playerLayer.Player.CenterPosition;
            }
        }

        private struct ManagerNames
        {
            public const string COLLISION_MANAGER = "CollisionManager";
            public const string DRAW_MANAGER = "DrawManager";
            public const string TIME_MANAGER = "TimeManager";
        }
    }
}
