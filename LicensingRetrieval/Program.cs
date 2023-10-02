using Aspose.Font;
using LicensingRetrieval;
using LicensingRetrieval.Entities;

// Setting license. For now, pointed to an existing source.
License license = new License();
string licenseFolder = string.Empty; // Use the right path whre the Aspose.Total.lic file is present.
license.SetLicense(licenseFolder);

var fontsFolderPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts);

// Form / retrieve a list of font file name [entire path], font name, license flag for all fonts

DirectoryInfo fontsFolder = new DirectoryInfo(fontsFolderPath);

var files = fontsFolder.GetFiles();

var fontFileMapping = new List<FontFileDetail>();

foreach (FileInfo file in files)
{
    var fontFileDetail = new FontFileDetail();
    if (file.Exists)
    {
        string extension = file.Name.Split('.')[1];
        FontType? fontType = null;
        switch (extension.ToUpper())
        {
            case "TTF":
                fontType = FontType.TTF;
                break;
            case "Type1":
                fontType = FontType.Type1;
                break;
            case "CFF":
                fontType = FontType.CFF;
                break;
            case "OTF":
                fontType = FontType.OTF;
                break;
        }

        if(!fontType.HasValue)
        {
            continue;
        }
        fontFileDetail.FontFileName = file.Name;
        fontFileDetail.FontName = Utility.GetFontName(file.FullName);
        fontFileDetail.LicenseFlag = Utility.GetFontLicenseEmbedding(file.FullName, fontType);

        fontFileMapping.Add(fontFileDetail);
    }
}

fontFileMapping.OrderBy(t => t.FontName);

Console.ReadKey();
