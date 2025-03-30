using System.IO;
using Timberborn.Modding;
using Timberborn.PlatformUtilities;


namespace TimberbornCustomNameList.Configuration
{
    public static class FilePathService
    {
        public static readonly string TimberbornDataFilePath = $"{UserDataFolder.Folder}{Path.DirectorySeparatorChar}";
        public static readonly string CustomNameListModFilePath = GetCustomNameListModFilePath();
        public static readonly string BeaverNameArrayFile = $"{CustomNameListModFilePath}BeaverNameArray.txt";
        public static readonly string UserBeaverNameFile = $"{TimberbornDataFilePath}BeaverNames.txt";
        public static readonly string BotNameArrayFile = $"{CustomNameListModFilePath}BotNameArray.txt";
        public static readonly string UserBotNameFile = $"{TimberbornDataFilePath}BotNames.txt";

        public static string GetCustomNameListModFilePath()
        {
            string debugDirectory = $"{TimberbornDataFilePath}Mods{Path.DirectorySeparatorChar}1PuddleCustomNameList";

            if (Directory.Exists(debugDirectory))
                return debugDirectory;
            else
                return GetTimberbornGameFilepath();
        }

        private static string GetTimberbornGameFilepath()
        {
            return $"{UserFolderModsProvider.ModsDirectoryName}{Path.DirectorySeparatorChar}" +
                $"1PuddleCustomNameList{Path.DirectorySeparatorChar}";
        }
    }
}
