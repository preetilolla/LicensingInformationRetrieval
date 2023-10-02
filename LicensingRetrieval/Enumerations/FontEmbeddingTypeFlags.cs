namespace LicensingRetrieval.Enumerations
{
    public enum FontEmbeddingTypeFlags : ushort
    {
        InstallableEmbedding = 0,
        Disregard = 1,
        Restricted = 2,
        PreviewAndPrint = 4,
        Editable = 8,
        Others = 16
    }
}
