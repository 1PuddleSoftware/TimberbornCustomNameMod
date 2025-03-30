using HarmonyLib;
using System.IO;
using Timberborn.ModManagerScene;
using TimberbornCustomNameList.Configuration;

namespace TimberbornCustomNameList
{
    public class CustomNameListModStarter: IModStarter
    {
        public void StartMod(IModEnvironment modEnvironment)
        {
            new Harmony(nameof(TimberbornCustomNameList)).PatchAll();

            if (!Directory.Exists(FilePathService.CustomNameListModFilePath))
                Directory.CreateDirectory(FilePathService.CustomNameListModFilePath);
        }
    }
}
