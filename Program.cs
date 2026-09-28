using System.Globalization;

internal class Program
{
    const int QUANTIDADE_NOTAS = 3;
    const double MEDIA_APROVACAO = 7.0;
    const double MEDIA_RECUPERACAO = 5.0;

    static string nomeAluno = "";
    static double[] notas = new double[QUANTIDADE_NOTAS];
    static bool notasLancadas = false;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1 - Cadastrar aluno");
            Console.WriteLine("2 - Lançar notas");
            Console.WriteLine("3 - Calcular média");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");

            string? entrada = Console.ReadLine();
            if (entrada == null) return;

            if (!int.TryParse(entrada, out int opcao))
            {
                Console.WriteLine("Opção inválida. Digite um número de 1 a 4.");
                continue;
            }

            switch (opcao)
            {
                case 1: CadastrarAluno(); break;
                case 2: LancarNotas(); break;
                case 3: CalcularMedia(); break;
                case 4: Console.WriteLine("Até logo!"); return;
                default: Console.WriteLine("Opção inválida. Escolha de 1 a 4."); break;
            }
        }
    }

    static void CadastrarAluno()
    {
        while (true)
        {
            Console.Write("Nome do aluno: ");
            string? nomeInformado = Console.ReadLine();
            if (nomeInformado == null) return;

            if (string.IsNullOrWhiteSpace(nomeInformado))
            {
                Console.WriteLine("Nome inválido. Digite um nome.");
                continue;
            }

            nomeAluno = nomeInformado.Trim();
            notasLancadas = false;
            Array.Clear(notas);
            Console.WriteLine($"Aluno {nomeAluno} cadastrado.");
            return;
        }
    }

    static void LancarNotas()
    {
        if (nomeAluno == "")
        {
            Console.WriteLine("Cadastre um aluno antes de lançar notas.");
            return;
        }

        notasLancadas = false;
        for (int indice = 0; indice < QUANTIDADE_NOTAS; indice++)
        {
            while (true)
            {
                Console.Write($"Nota {indice + 1} (0 a 10): ");
                string? entrada = Console.ReadLine();
                if (entrada == null) return;

                if (!double.TryParse(entrada.Replace(',', '.'), CultureInfo.InvariantCulture,
                    out double nota) || !double.IsFinite(nota) || nota < 0 || nota > 10)
                {
                    Console.WriteLine("Nota inválida. Digite um número de 0 a 10.");
                    continue;
                }

                notas[indice] = nota;
                break;
            }
        }

        notasLancadas = true;
        Console.WriteLine("Notas registradas.");
    }

    static void CalcularMedia()
    {
        if (nomeAluno == "" || !notasLancadas)
        {
            Console.WriteLine("Cadastre um aluno e lance as três notas primeiro.");
            return;
        }

        double media = (notas[0] + notas[1] + notas[2]) / QUANTIDADE_NOTAS;
        Console.WriteLine($"Aluno: {nomeAluno} | Média: {media:F2}");
        ExibirSituacao(media);
    }

    static void ExibirSituacao(double media)
    {
        if (media >= MEDIA_APROVACAO)
            Console.WriteLine("Situação: Aprovado");
        else if (media >= MEDIA_RECUPERACAO)
            Console.WriteLine("Situação: Recuperação");
        else
            Console.WriteLine("Situação: Reprovado");
    }
}
