using System.IO.Compression;

namespace Compacter.Service
{
    public class ZipService : IZipService
    {
        public void CompressFile(string sourceFile, string destinationFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
            using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create))
            using (GZipStream compressionStream = new GZipStream(destinationStream, CompressionMode.Compress))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    compressionStream.Write(buffer, 0, bytesRead);
                    Console.Write($"\rProgresso: {sourceStream.Position * 100 / sourceStream.Length}%");
                }
            }
        }

        public void DecompressFile(string sourceFile, string destinationFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
            using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create))
            using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    decompressionStream.Write(buffer, 0, bytesRead);
                    Console.Write($"\rProgresso: {sourceStream.Position * 100 / sourceStream.Length}%");
                }
            }
        }
    }
}