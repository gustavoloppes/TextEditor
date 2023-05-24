Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que deseja fazer ?");
    Console.WriteLine("1- Abrir arquivo   2- Criar Arquivo   0- Sair");

    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1 : Open(); break;
        case 2 : Edite(); break;
        
        default: Menu(); break;
    }

}

static void Open()
{

    Console.Clear();
    Console.WriteLine("Qual caminho do arquivo");
    string path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }
    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void Edite()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;

    } while (Console.ReadKey().Key != ConsoleKey.Escape);

    Save(text);
}

static void Save(string text)
{
    Console.Clear();
    Console.WriteLine("Qual caminho voce vai salvar o arquivo");
    var path = Console.ReadLine();


    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"Arquivo salvo em {path} com sucesso");
    Console.ReadLine();
    Menu();
}