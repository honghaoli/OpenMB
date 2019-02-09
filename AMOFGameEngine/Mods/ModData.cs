﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMOFGameEngine.Game;
using AMOFGameEngine.Mods.XML;
using AMOFGameEngine.Sound;

namespace AMOFGameEngine.Mods
{
    public class ModData
    {
        private ModBaseInfo modBasicInfo;
        private List<ModCharacterDfnXML> characterInfos;
        private List<ModItemDfnXML> itemInfos;
        private List<ModTrackDfnXML> musicInfos;
        private List<ModSoundDfnXML> soundInfos;
        private List<ModSideDfnXML> sideInfos;
        private List<ModMapDfnXML> mapInfos;
        private List<ModRaceDfnXml> raceInfos;

        public ModBaseInfo BasicInfo
        {
            get { return modBasicInfo; }
            set { modBasicInfo = value; }
        }
        public List<ModMapDfnXML> MapInfos
        {
            get { return mapInfos; }
            set { mapInfos = value; }
        }
        public List<ModSideDfnXML> SideInfos
        {
            get { return sideInfos; }
            set { sideInfos = value; }
        }
        public List<ModTrackDfnXML> MusicInfos
        {
            get { return musicInfos; }
            set { musicInfos = value; }
        }
        public List<ModItemDfnXML> ItemInfos
        {
            get { return itemInfos; }
            set { itemInfos = value; }
        }
        public List<ModCharacterDfnXML> CharacterInfos
        {
            get { return characterInfos; }
            set { characterInfos = value; }
        }

        public List<ModSoundDfnXML> SoundInfos
        {
            get { return soundInfos; }
            set { soundInfos = value; }
        }

        public List<ModRaceDfnXml> RaceInfos
        {
            get { return raceInfos; }
            set { raceInfos = value; }
        }

        public ModData()
        {
            characterInfos = new List<ModCharacterDfnXML>();
            itemInfos = new List<ModItemDfnXML>();
            musicInfos = new List<ModTrackDfnXML>();
            sideInfos = new List<ModSideDfnXML>();
            mapInfos = new List<ModMapDfnXML>();
            soundInfos = new List<ModSoundDfnXML>();
            raceInfos = new List<ModRaceDfnXml>();
        }
    }
}
