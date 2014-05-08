using Assets.Models;
using Assets.Services;

namespace Assets.Managers
{
    public static class PlayerManager
    {
        public static string SaveGameFile = "savegame1.xml";

        public static void Save(PlayerModel player)
        {
            var manager = new XmlManager<PlayerModel>();
            manager.Save(SaveGameFile, player);
        }

        public static PlayerModel Load()
        {
            var manager = new XmlManager<PlayerModel>();
            return manager.Load(SaveGameFile);
        }
    }
}
