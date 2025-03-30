using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Timberborn.Beavers;
using TimberbornCustomNameList.Configuration;
using TimberbornCustomNameList.Models;

namespace TimberbornCustomNameList.TimberbornBeaverNameService
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(BeaverNameService), nameof(BeaverNameService.Load))]
    public class LoadPatch
    {
        private static readonly MultipleSaveModeSettings? Settings = MultipleSaveModeSettingsService.GetMultipleSaveModeSettings();
        private static readonly string BeaverNameArrayFile = FilePathService.BeaverNameArrayFile;
        private static readonly string UserBeaverNameFile = FilePathService.UserBeaverNameFile;

        public static void Prefix()
        {
            NameService.NameService.LoadNames(UserBeaverNameFile, BeaverNameArrayFile);
        }

        public static void Postfix(BeaverNameService __instance)
        {
            if (Settings is null || !Settings.MultipleSaveMode)
                return;

            if (Settings.RestoreDefaultNameList)
            {
                List<string> defaultNames = (List<string>)GetCompletedNamePoolField().GetValue(__instance);

                GetNamesField().SetValue(__instance, defaultNames);
            }
            else
                LoadModBeaverNames(__instance);
        }

        private static void LoadModBeaverNames(BeaverNameService beaverNameService)
        {
            List<string> _modCompleteNamePool = NameService.NameService.GetNames(UserBeaverNameFile);

            if (_modCompleteNamePool.Count == 0)
                return;

            GetCompletedNamePoolField().SetValue(beaverNameService, _modCompleteNamePool);

            var namesField = GetNamesField();

            List<string> names = (List<string>)namesField.GetValue(beaverNameService);

            if (names.Count() == 0 || (Settings != null && Settings.RefreshModNameList))
            {
                namesField.SetValue(beaverNameService, _modCompleteNamePool);
            }
            else
            {
                List<string> newNames = names.Intersect((IEnumerable<string>)_modCompleteNamePool).ToList() ?? new List<string>();
                namesField.SetValue(beaverNameService, newNames);
            }
        }

        private static FieldInfo GetCompletedNamePoolField()
        {
            return typeof(BeaverNameService).GetField("_completeNamePool",
                BindingFlags.Instance |
                BindingFlags.NonPublic);
        }

        private static FieldInfo GetNamesField()
        {
            return typeof(BeaverNameService).GetField("_names",
                BindingFlags.Instance |
                BindingFlags.NonPublic);
        }
    }
}