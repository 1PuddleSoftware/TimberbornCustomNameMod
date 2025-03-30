using HarmonyLib;
using Timberborn.Bots;
using TimberbornCustomNameList.Configuration;

namespace TimberbornCustomNameList.TimberbornBotNameService
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(BotNameService), nameof(BotNameService.Load))]
    public class LoadPatch
    {
        private static readonly string BotNameArrayFile = FilePathService.BotNameArrayFile;
        private static readonly string UserBotNameFile = FilePathService.UserBotNameFile;

        public static void Prefix()
        {
            NameService.NameService.LoadNames(UserBotNameFile, BotNameArrayFile);
        }
    }
}
