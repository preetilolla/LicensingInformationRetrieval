using Aspose.Font.Sources;
using Aspose.Font.Ttf;
using Aspose.Font;
using System.Drawing.Text;
using LicensingRetrieval.Enumerations;

namespace LicensingRetrieval
{
    public static class Utility
    {
        public static string GetFontName(string fontFilePath)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontFilePath);
            if (pfc.Families.Length > 0)
            {
                return pfc.Families[0].Name;
            }
            return string.Empty;
        }

        public static FontEmbeddingTypeFlags GetFontLicenseEmbedding(string fontFilePath, FontType? fontType)
        {
            FileSystemStreamSource fontSource = new FileSystemStreamSource(fontFilePath);

            FontDefinition fontDefinition = new FontDefinition((FontType)fontType, fontSource);
            var font = (TtfFont)Font.Open(fontDefinition);

            LicenseFlags licenseFlags = null;

            if (font.TtfTables.Os2Table != null)
            {
                licenseFlags = font.TtfTables.Os2Table.GetLicenseFlags();
            }

            if (licenseFlags == null || licenseFlags.FSTypeAbsent)
            {
                return FontEmbeddingTypeFlags.Others;
            }
            else
            {
                if (licenseFlags.IsEditableEmbedding)
                {
                    return FontEmbeddingTypeFlags.Editable;
                }
                else if (licenseFlags.IsInstallableEmbedding)
                {
                    return FontEmbeddingTypeFlags.InstallableEmbedding;
                }
                else if (licenseFlags.IsPreviewAndPrintEmbedding)
                {
                    return FontEmbeddingTypeFlags.PreviewAndPrint;
                }
                else if (licenseFlags.IsRestrictedLicenseEmbedding)
                {
                    return FontEmbeddingTypeFlags.Restricted;
                }
            }

            return FontEmbeddingTypeFlags.Others;
        }

    }
}
