﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Mogre;
using MOIS;
using AMOFGameEngine.Sound;
using Mogre.PhysX;
using org.critterai.nav;

namespace AMOFGameEngine.Game
{
    /// <summary>
    /// Specific Characer in Game
    /// </summary>
    public class Character : GameObject
    {
        //Unique Id
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //Name
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Team, usually used to identity whether is enemy
        private string teamId;

        //Controller
        private CharacterController controller;

        public CharacterController Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        //Hitpoint
        private int hitpoint;

        public int Hitpoint
        {
            get { return hitpoint; }
            set { hitpoint = value; }
        }

        //Weapons
        private Item[] weapons;

        public Item[] Weapons
        {
            get { return weapons; }
            set { weapons = value; }
        }

        //Clothes
        private Item[] clothes;

        public Item[] Clothes
        {
            get { return clothes; }
            set { clothes = value; }
        }

        //Backpack
        private Inventory backpack;

        public Inventory Backpack
        {
            get { return backpack; }
            set { backpack = value; }
        }

        public string TeamId
        {
            get
            {
                return teamId;
            }
        }

        //Environment
        private GameWorld mWorld;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="world">Environment</param>
        /// <param name="cam">Camera</param>
        /// <param name="id">Unique Id</param>
        /// <param name="teamId">Team Id</param>
        /// <param name="name">Name</param>
        /// <param name="meshName">Mesh Name</param>
        /// <param name="initPosition">Init Position</param>
        /// <param name="controlled">Is Bot or not</param>
        public Character(GameWorld world, 
                         Camera cam, 
                         int id,
                         string teamId,
                         string name,
                         string meshName,
                         Mogre.Vector3 initPosition,
                         bool controlled)
        {
            mWorld = world;
            Id = id;
            Name = string.Empty;
            Hitpoint = 100;
            Weapons = new Item[4];
            Clothes = new Item[4];
            Backpack = new Inventory(21, this);
            controller = new CharacterController(cam,world.NavmeshQuery,world.PhysicsScene, name + id.ToString(), meshName, controlled);//初始化控制器
            controller.Position = initPosition;
        }

        public void WearHat(Item item)
        {
            if (item != null && item.ItemType == ItemType.IT_HEAD_ARMOUR)
            {
                Clothes[0] = item;
                controller.AttachEntityToChara("head", item.ItemEnt);
            }
        }

        public void WearClothes(Item item)
        {
            if (item != null && item.ItemType == ItemType.IT_BODY_ARMOUR)
            {
                Clothes[1] = item;
                controller.AttachEntityToChara("back", item.ItemEnt);
            }
        }

        public void AddItemToBackpack(Item item)
        {
            Backpack.AddItemToInventory(item);
        }

        /// <summary>
        /// Find characters against this character
        /// </summary>
        /// <returns>Enemies</returns>
        public List<Character> FindEnemies()
        {
            List<Character> enemies = new List<Character>();
            List<string> enemyTeamsWithMe = new List<string>();
            var allEnemyTeams = mWorld.GetTeamRelationshipByCondition(o => o.Item3 == -1);
            foreach(var enemyTeam in allEnemyTeams)
            {
                if(enemyTeam.Item1 == teamId)
                {
                    if (!enemyTeamsWithMe.Contains(enemyTeam.Item2))
                    {
                        enemyTeamsWithMe.Add(enemyTeam.Item2);
                    }
                }
                else if(enemyTeam.Item2 == teamId)
                {
                    if (!enemyTeamsWithMe.Contains(enemyTeam.Item1))
                    {
                        enemyTeamsWithMe.Add(enemyTeam.Item1);
                    }
                }
            }
            foreach(var enemyTeamWithMe in enemyTeamsWithMe)
            {
                enemies.AddRange(mWorld.GetCharactersByCondition(o => o.TeamId == enemyTeamWithMe));
            }
            return enemies;
        }

        /// <summary>
        /// Change Character to a new team
        /// </summary>
        /// <param name="newTeamId">New Team Id</param>
        public void Turn(string newTeamId)
        {
            teamId = newTeamId;
        }

        public override void Update(float timeSinceLastFrame)
        {
            controller.addTime(timeSinceLastFrame);
        }
    }
}