using System.Xml.Serialization;

namespace TimberbornCustomNameList.Models
{
    [XmlRoot("Settings")]
    public class MultipleSaveModeSettings
    {
        [XmlElement("MultipleSaveMode")]
        public bool MultipleSaveMode { get; set; }

        [XmlElement("RestoreDefaultNameList")]
        public bool RestoreDefaultNameList { get; set; }

        [XmlElement("RefreshModNameList")]
        public bool RefreshModNameList { get; set; }
    }
}
