using HarmonyLib;
using Timberborn.Beavers;
using TimberbornCustomNameList.Configuration;

namespace TimberbornCustomNameList.TimberbornBeaverNameService
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(BeaverNameService), nameof(BeaverNameService.RandomName))]
    public class RandomNamePatch
    {
        public static bool Prefix(ref string __result)
        {
            var settings = MultipleSaveModeSettingsService.GetMultipleSaveModeSettings();
            var beaverNameArrayFile = FilePathService.BeaverNameArrayFile;
            var userBeaverNameFile = FilePathService.UserBeaverNameFile;

            if (settings != null && settings.MultipleSaveMode)
                return true; //Go into normal Timberborn code path

            var nameList = NameService.NameService.GetNames(beaverNameArrayFile);
            if (nameList == null || nameList.Count == 0)
            {
                NameService.NameService.LoadNames(userBeaverNameFile, beaverNameArrayFile);
                nameList = NameService.NameService.GetNames(userBeaverNameFile);
            }

            if (nameList.Count == 0)
                return true; //Exit to main code since our files are having issues

            var name = NameService.NameService.GetRandomName(beaverNameArrayFile, nameList);

            __result = name;

            return false;
        }
    }
}
