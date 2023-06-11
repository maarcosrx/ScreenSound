//Screen Sound
using System.Runtime.CompilerServices;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

//List<string> listaDasBandas = new List<string> {"U2", "The Beatles", "Calypso"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 6, 8 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    //Verbatim Literal (coloca a string do jeito que ela aparece)
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═══    ══╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para excluir uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
        RegistrarBanda();
        break;
        case 2:
        MostrarBandasRegistradas();
        break;
        case 3:
        AvaliarBanda();
        break;
        case 4:
        MediaBanda();
        break;
        case 5:
        ExcluirBanda();
        break;
        case 0:
        Console.WriteLine($"Obrigado por usar o Screen Sound!");
        break;
        default:
        Console.WriteLine("Opção inválida");
        break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Console.WriteLine("\nPressione qualquer tecla...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo bandas registradas");
    /*for(int i = 0; i < listaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }*/
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressione qualquer tecla...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    // Digite qual banda deseja avaliar
    // Se a banda existir no dicionário >> atribuir nota
    // Se não existir, volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {

        Console.Write($"Qual nota a banda {nomeDaBanda} merece?: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Console.WriteLine($"Digite qualquer tecla para voltar...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Pressione qualquer tecla para voltar...");
        Console.ReadKey();
        Console.Clear();
        AvaliarBanda();
    }

}
void MediaBanda()
{
    //Perguntar qual o nome da banda a qual se quer ver a média
    //Verificar se a banda ta no dicionario
    //Se tiver realizar o calculo
    //Criar função - ok
    Console.Clear();
    ExibirTituloDaOpcao("Media das bandas");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
        Console.WriteLine("Pressione qualquer tecla para voltar...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não encontrada.");
        Console.WriteLine("Pressione qualquer tecla...");
        Console.ReadKey();
        Console.Clear();
        MediaBanda();
    }
}

void ExcluirBanda()
{
    //Perguntar qual o nome da banda a ser exlcuída
    //Verificar se a banda existe
    //Se existir, excluir a banda

    Console.Clear();
    ExibirTituloDaOpcao("Excluir banda(s)");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        bandasRegistradas.Remove(nomeDaBanda);
        Console.WriteLine($"A banda {nomeDaBanda} foi removida com sucesso!");
        Console.WriteLine("Pressione qualquer tecla...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine($"Pressione qualquer tecla para tentar novamente...");
        Console.ReadKey();
        Console.Clear();
        ExcluirBanda();
    }

}


ExibirOpcoesDoMenu();
