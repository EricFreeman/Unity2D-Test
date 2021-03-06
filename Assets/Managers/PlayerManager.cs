﻿using System.IO;
using Assets.Extensions;
using Assets.Models;
using Assets.Services;
using UnityEngine;

namespace Assets.Managers
{
    public static class PlayerManager
    {
        public static string SaveGameFile = 
            "{0}/savegame1.xml".ToFormat(Application.persistentDataPath);

        public static void Save(PlayerModel player)
        {
            var manager = new XmlManager<PlayerModel>();
            manager.Save(SaveGameFile, player);
        }

        public static PlayerModel Load()
        {
            var manager = new XmlManager<PlayerModel>();
            if (!File.Exists(SaveGameFile)) Reset();
            return manager.Load(SaveGameFile);
        }

        public static void Reset()
        {
            var player = new PlayerModel {Money = 100};
            Save(player);
        }
    }
}
