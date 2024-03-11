using Compacter.Service;

class Program
{
    private readonly IZipService _zipService;

    public Program(IZipService zipService)
    {
        _zipService = zipService;
    }

    static void Main(string[] args)
    {
        IZipService zipService = new ZipService();
        Program program = new Program(zipService);
        program.Run();
    }

    public void Run()
    {
        Console.WriteLine("Bem-vindo ao Compacter! \r\nVocê pode compactar e descompactar arquivos.\r\nDigite o comando 'compactar' ou 'descompactar' para começar.\r\nDigite 'sair' para sair.");

        string comando = Console.ReadLine();

        if (comando is not null)
        {
            if (comando == "compactar")
            {
                Console.WriteLine("Digite o caminho do arquivo que deseja compactar:");
                string sourceFile = Console.ReadLine();
                Console.WriteLine("Digite o caminho do arquivo compactado:");
                string destinationFile = Console.ReadLine();
                try
                {
                    _zipService.CompressFile(sourceFile, destinationFile);
                    Console.WriteLine("Arquivo compactado com sucesso!");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Erro ao compactar o arquivo: {e.Message}");
                }
            }
            else if (comando == "descompactar")
            {
                Console.WriteLine("Digite o caminho do arquivo que deseja descompactar:");
                string sourceFile = Console.ReadLine();
                Console.WriteLine("Digite o caminho do arquivo descompactado:");
                string destinationFile = Console.ReadLine();
                try
                {
                    _zipService.DecompressFile(sourceFile, destinationFile);
                    Console.WriteLine("Arquivo descompactado com sucesso!");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Erro ao descompactar o arquivo: {e.Message}");
                }
            }
            else if (comando == "sair")
            {
                Console.WriteLine("Até logo!");
            }
            else
            {
                Console.WriteLine("Comando inválido!");
            }
        }
    }
}
