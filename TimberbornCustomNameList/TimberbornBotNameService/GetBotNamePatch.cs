using HarmonyLib;
using Timberborn.Bots;
using TimberbornCustomNameList.Configuration;

namespace TimberbornCustomNameList.TimberbornBotNameService
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(BotNameService), nameof(BotNameService.GetBotName))]
    public class GetBotNamePatch
    {
        private static readonly string BotNameArrayFile = FilePathService.BotNameArrayFile;
        private static readonly string UserBotNameFile = FilePathService.UserBotNameFile;

        public static bool Prefix(ref string __result)
        {
            var settings = MultipleSaveModeSettingsService.GetMultipleSaveModeSettings();

            if (settings != null && settings.MultipleSaveMode)
                return true; //Go into normal Timberborn code path

            var nameList = NameService.NameService.GetNames(BotNameArrayFile);
            if (nameList == null || nameList.Count == 0)
            {
                NameService.NameService.LoadNames(UserBotNameFile, BotNameArrayFile);
                nameList = NameService.NameService.GetNames(UserBotNameFile);
            }

            if (nameList.Count == 0)
                return true; //Exit to main code since our files are having issues

            var name = NameService.NameService.GetRandomName(BotNameArrayFile, nameList);

            __result = name;

            return false;
        }
    }
}
