class Program
{
    const int TOTAL_NOTAS = 3;
    const double MEDIA_APROVACAO = 7;
    const double MEDIA_RECUPERACAO = 5;
    static string nomeAluno = "";
    static double[] notas = new double[TOTAL_NOTAS];
    static bool notasLancadas;

    static void Main()
    {
        while (true)
        {
            Console.Write("\n1 - Cadastrar aluno\n2 - Lançar notas\n3 - Calcular média\n4 - Sair\nOpção: ");
            string? entrada = Console.ReadLine();
            if (entrada == null) return;
            int.TryParse(entrada, out int opcao);

            switch (opcao)
            {
                case 1: CadastrarAluno(); break;
                case 2: LancarNotas(); break;
                case 3: CalcularMedia(); break;
                case 4: return;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }
    }

    static void CadastrarAluno()
    {
        Console.Write("Nome do aluno: ");
        string? nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            return;
        }
        nomeAluno = nome.Trim();
        notasLancadas = false;
        Console.WriteLine("Aluno cadastrado.");
    }

    static void LancarNotas()
    {
        if (nomeAluno == "")
        {
            Console.WriteLine("Cadastre um aluno primeiro.");
            return;
        }
        notasLancadas = false;
        for (int indice = 0; indice < TOTAL_NOTAS; indice++)
        {
            while (true)
            {
                Console.Write($"Nota {indice + 1} (0 a 10): ");
                string? entrada = Console.ReadLine();
                if (entrada == null) return;
                if (double.TryParse(entrada, out double nota) && nota >= 0 && nota <= 10)
                {
                    notas[indice] = nota;
                    break;
                }
                Console.WriteLine("Nota inválida. Digite um número de 0 a 10.");
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
        double media = (notas[0] + notas[1] + notas[2]) / TOTAL_NOTAS;
        Console.WriteLine($"{nomeAluno} - Média: {media:F2}");
        ExibirSituacao(media);
    }

    static void ExibirSituacao(double media)
    {
        if (media >= MEDIA_APROVACAO) Console.WriteLine("Aprovado");
        else if (media >= MEDIA_RECUPERACAO) Console.WriteLine("Recuperação");
        else Console.WriteLine("Reprovado");
    }
}
