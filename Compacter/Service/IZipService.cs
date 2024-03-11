namespace Compacter.Service
{
    public interface IZipService
    {
        void CompressFile(string sourceFile, string destinationFile);
        void DecompressFile(string sourceFile, string destinationFile);
    }
}