using System.IO;
using System.Xml.Serialization;
using TimberbornCustomNameList.Models;

namespace TimberbornCustomNameList.Configuration
{
    public static class MultipleSaveModeSettingsService
    {
        private static readonly MultipleSaveModeSettings? Settings = ReadModSettingsFromFile();

        public static MultipleSaveModeSettings? GetMultipleSaveModeSettings() { return Settings; }

        private static MultipleSaveModeSettings? ReadModSettingsFromFile()
        {
            string _modFilePath = $"{FilePathService.CustomNameListModFilePath}MultipleSaveModeSettings.xml";

            var serializer = new XmlSerializer(typeof(MultipleSaveModeSettings));

            try
            {
                using var reader = new StreamReader(_modFilePath);
                return (MultipleSaveModeSettings)serializer.Deserialize(reader);
            }
            catch
            {
                return null;
            }
        }
    }
}
