using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimberbornCustomNameList.NameService
{
    public static class NameService
    {
        public static void LoadNames(string UserFilePath, string ModNameArrayFilePath)
        {
            List<string> names = GetNames(ModNameArrayFilePath);

            if (names.Count > 0)
                return;

            List<string> userFileContents = GetNames(UserFilePath);
            if (userFileContents.Count > 0)
            {
                names.AddRange(userFileContents);
                SaveNames(ModNameArrayFilePath, names);
            }
        }

        public static List<string> GetNames(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    return File.ReadAllLines(filePath).Select(e => e.Trim().Replace("\r", "")).Where(name => name.Length > 0).ToList();
                else
                    return new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        public static void SaveNames(string filePath, List<string> names)
        {
            File.WriteAllLines(filePath, names);
        }

        public static string GetRandomName(string modFilePath, List<string> names)
        {
            int index = UnityEngine.Random.Range(0, names.Count - 1);

            string name = names[index];

            names.Remove(name);
            SaveNames(modFilePath, names);

            return name;
        }
    }
}
