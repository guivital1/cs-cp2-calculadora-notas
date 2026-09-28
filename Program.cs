using System.Globalization;

internal class Program
{
    private const int QUANTIDADE_NOTAS = 3;
    private const double NOTA_MINIMA = 0.0;
    private const double NOTA_MAXIMA = 10.0;
    private const double MEDIA_APROVACAO = 7.0;
    private const double MEDIA_RECUPERACAO = 5.0;

    private static string? nomeAluno;
    private static readonly double[] notas = new double[QUANTIDADE_NOTAS];
    private static bool notasLancadas;

    private static void Main()
    {
        while (true)
        {
            ExibirMenu();
            string? entrada = Console.ReadLine();

            if (entrada is null)
            {
                Console.WriteLine("Entrada encerrada. Até logo!");
                break;
            }

            if (!int.TryParse(entrada, out int opcao))
            {
                Console.WriteLine("Opção inválida. Digite um número de 1 a 4.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;
                case 2:
                    LancarNotas();
                    break;
                case 3:
                    if (nomeAluno is null || !notasLancadas)
                    {
                        Console.WriteLine("Cadastre um aluno e lance as três notas antes de calcular a média.");
                        break;
                    }

                    double media = CalcularMedia();
                    Console.WriteLine($"Aluno: {nomeAluno} | Média: {media:F2}");
                    ExibirSituacao(media);
                    break;
                case 4:
                    Console.WriteLine("Até logo!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Escolha de 1 a 4.");
                    break;
            }
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Calculadora de Notas ===");
        Console.WriteLine("1 - Cadastrar aluno");
        Console.WriteLine("2 - Lançar notas");
        Console.WriteLine("3 - Calcular média");
        Console.WriteLine("4 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    private static void CadastrarAluno()
    {
        while (true)
        {
            Console.Write("Nome do aluno: ");
            string? nomeInformado = Console.ReadLine();

            if (nomeInformado is null)
            {
                Console.WriteLine("Cadastro cancelado: entrada encerrada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(nomeInformado))
            {
                Console.WriteLine("Nome inválido. Digite um nome não vazio.");
                continue;
            }

            nomeAluno = nomeInformado.Trim();
            notasLancadas = false;
            Array.Clear(notas);
            Console.WriteLine($"Aluno {nomeAluno} cadastrado. Lance as três notas.");
            return;
        }
    }

    private static void LancarNotas()
    {
        if (nomeAluno is null)
        {
            Console.WriteLine("Cadastre um aluno antes de lançar as notas.");
            return;
        }

        double[] novasNotas = new double[QUANTIDADE_NOTAS];

        for (int indice = 0; indice < QUANTIDADE_NOTAS; indice++)
        {
            while (true)
            {
                Console.Write($"Nota {indice + 1} (0 a 10): ");
                string? entrada = Console.ReadLine();

                if (entrada is null)
                {
                    Console.WriteLine("Lançamento cancelado: entrada encerrada.");
                    return;
                }

                bool numeroValido = double.TryParse(entrada, NumberStyles.Float,
                    CultureInfo.CurrentCulture, out double nota);

                // Aceita também ponto decimal quando a cultura do computador usa vírgula.
                if (!numeroValido)
                {
                    numeroValido = double.TryParse(entrada, NumberStyles.Float,
                        CultureInfo.InvariantCulture, out nota);
                }

                if (!numeroValido || !double.IsFinite(nota) ||
                    nota < NOTA_MINIMA || nota > NOTA_MAXIMA)
                {
                    Console.WriteLine("Nota inválida. Digite um número de 0 a 10.");
                    continue;
                }

                novasNotas[indice] = nota;
                break;
            }
        }

        Array.Copy(novasNotas, notas, QUANTIDADE_NOTAS);
        notasLancadas = true;
        Console.WriteLine("As três notas foram registradas.");
    }

    private static double CalcularMedia()
    {
        double somaNotas = 0;

        foreach (double nota in notas)
        {
            somaNotas += nota;
        }

        return somaNotas / QUANTIDADE_NOTAS;
    }

    private static void ExibirSituacao(double media)
    {
        if (media >= MEDIA_APROVACAO)
        {
            Console.WriteLine("Situação: Aprovado");
        }
        else if (media >= MEDIA_RECUPERACAO)
        {
            Console.WriteLine("Situação: Recuperação");
        }
        else
        {
            Console.WriteLine("Situação: Reprovado");
        }
    }
}
