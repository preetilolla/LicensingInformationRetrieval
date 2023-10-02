using LicensingRetrieval.Enumerations;

namespace LicensingRetrieval.Entities
{
    internal class FontFileDetail
    {
        public string FontName { get; set; }
        public string FontFileName { get; set; }
        public FontEmbeddingTypeFlags LicenseFlag { get; set; }

        public FontFileDetail()
        {
            FontName = string.Empty;
            FontFileName = string.Empty;
            LicenseFlag = FontEmbeddingTypeFlags.Others;
        }
    }
}
