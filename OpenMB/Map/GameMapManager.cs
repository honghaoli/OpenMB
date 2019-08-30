﻿using OpenMB.Game;
using OpenMB.Mods;
using OpenMB.Trigger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMB.Map
{
    public class GameMapManager
    {
        private ModData modData;
        private static GameMapManager instance;
        public static GameMapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameMapManager();
                }
                return instance;
            }
        }

        public GameMapManager()
        {
            maps = new Queue<IGameMap>();
        }

        public void Init(ModData modData)
        {
            this.modData = modData;
        }

        private GameWorld world;
        private IGameMap currentMap;
        private Queue<IGameMap> maps;
        public void Load(string name, IGameMapLoader loader)
        {
            if (maps.Count > 0)
            {
                maps.Dequeue().Destroy();
            }
            GameMap map = new GameMap(world, loader);
            map.LoadMap(name);
            maps.Enqueue(map);
            map.LoadMapStarted += Map_LoadMapStarted;
            map.LoadMapFinished += Map_LoadMapFinished;
            currentMap = map;
            map.LoadAsync();
        }

        public void LoadWorldMap(string worldMapID, string file, IGameMapLoader loader)
        {
            if (maps.Count > 0)
            {
                maps.Dequeue().Destroy();
            }
            GameMap map = new GameMap(world, loader);
            map.LoadWorldMap(worldMapID, file);
            maps.Enqueue(map);
            map.LoadMapStarted += Map_LoadMapStarted;
            map.LoadMapFinished += Map_LoadMapFinished;
            currentMap = map;
        }

        private void Map_LoadMapFinished()
        {
        }

        private void Map_LoadMapStarted()
        {

        }

        public void Initization(GameWorld world)
        {
            this.world = world;
        }

        public void Dispose()
        {
            if (currentMap != null)
            {
                currentMap.Destroy();
            }
            maps.Clear();
        }

        public string GetCurrentMapName()
        {
            if (currentMap != null)
            {
                return currentMap.GetName();
            }
            else
            {
                return string.Empty;
            }
        }

        public GameMap GetCurrentMap()
        {
            return (GameMap)currentMap;
        }

        public void Update(float timeSinceLastFrame)
        {
            if (currentMap == null)
                return;
            currentMap.Update(timeSinceLastFrame);
        }

        public string FindPath(string file)
        {
            return modData.BasicInfo.InstallPath + "//" + modData.MapDir + "//" + file;
        }
    }
}
