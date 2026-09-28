# CS CP2 — Calculadora de Notas

Aplicação de console em C# para cadastrar um aluno, lançar três notas e calcular sua média e situação.

## Executar

Requer o .NET SDK 8. Na pasta do projeto:

```bash
dotnet run
```

O menu permanece aberto até a opção `4 - Sair`. Cadastre o aluno antes de lançar as notas. Cada nota deve estar entre 0 e 10. Para notas decimais, use o separador da configuração regional do computador. Um novo cadastro desconsidera as notas do aluno anterior.

## Critérios

| Média | Situação |
| --- | --- |
| 7,0 ou maior | Aprovado |
| De 5,0 até menos de 7,0 | Recuperação |
| Menor que 5,0 | Reprovado |

## Casos verificados

- `7 / 7 / 7` → Aprovado
- `5 / 5 / 5` → Recuperação
- `4 / 3 / 2` → Reprovado
- Opção inválida, nome vazio, nota não numérica e notas fora de `0–10` → mensagem e nova solicitação
- Novo aluno → notas anteriores descartadas
