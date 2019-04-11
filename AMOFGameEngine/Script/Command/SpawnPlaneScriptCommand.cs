﻿using AMOFGameEngine.Game;
using Mogre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMOFGameEngine.Script.Command
{
    public class SpawnPlaneScriptCommand : ScriptCommand
    {
        private string[] commandArgs;
        public override string CommandName
        {
            get
            {
                return "spawn_plane";
            }
        }

        public override string[] CommandArgs
        {
            get
            {
                return commandArgs;
            }
        }

        public SpawnPlaneScriptCommand()
        {
            commandArgs = new string[]
            {
                "materialName",
                "rkNormal Vector",
                "constantis",
                "width",
                "height",
                "up Vector",
                "Position Vector",
            };
        }

        public override void Execute(params object[] executeArgs)
        {
            string materialName = getParamterValue(CommandArgs[0]);
            string rkNormalVectorName = getParamterValue(CommandArgs[1]);
            string consitantis = getParamterValue(CommandArgs[2]);
            string width = getParamterValue(CommandArgs[3]);
            string height = getParamterValue(CommandArgs[4]);
            string upVectorName = getParamterValue(CommandArgs[5]);
            string positionVectorName = getParamterValue(CommandArgs[6]);
            GameWorld world = executeArgs[0] as GameWorld;
            var rkNormalVector = world.GlobalValueTable.GetRecord(rkNormalVectorName);
            var upVector = world.GlobalValueTable.GetRecord(upVectorName);
            var positionVector = world.GlobalValueTable.GetRecord(positionVectorName);

            world.CreatePlane(
                materialName,
                new Vector3(
                    float.Parse(rkNormalVector.NextNodes[0].Value),
                    float.Parse(rkNormalVector.NextNodes[1].Value),
                    float.Parse(rkNormalVector.NextNodes[2].Value)),
                float.Parse(consitantis),
                int.Parse(width),
                int.Parse(height),
                10,
                10,
                0,
                10,
                10,
                new Vector3(
                    float.Parse(upVector.NextNodes[0].Value),
                    float.Parse(upVector.NextNodes[1].Value),
                    float.Parse(upVector.NextNodes[2].Value)),
                new Vector3(
                    float.Parse(positionVector.NextNodes[0].Value),
                    float.Parse(positionVector.NextNodes[1].Value),
                    float.Parse(positionVector.NextNodes[2].Value))
                );
        }
    }
}