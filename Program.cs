using System;

namespace sistema_de_notas
{
    class Program
    {
        static void Main(string[] args)
        {
            const int totalAlunos = 5;
            Aluno[] alunos = new Aluno[totalAlunos];
            int indiceAluno = 0;

            string opcao_usuario = "a";
            do
            {
                opcao_usuario = pegar_opcao_do_usuario();
                Console.WriteLine();

                switch (opcao_usuario)
                {
                    case "1":
                        if (indiceAluno < totalAlunos)
                        {
                            Aluno aluno = new Aluno();

                            Console.WriteLine("Digite o nome do aluno:");
                            aluno.Nome = Console.ReadLine();

                            Console.WriteLine("Digite a nota do aluno:");

                            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                            {
                                aluno.Nota = nota;
                            }
                            else
                            {
                                throw new ArgumentException("O valor da nota deve ser decimal!");
                            }

                            alunos[indiceAluno] = aluno;
                            indiceAluno++;
                        }
                        else
                        {
                            Console.WriteLine("O número total de alunos foi atingido!");
                        }

                        break;
                    case "2":
                        foreach (Aluno aluno_ in alunos)
                        {
                            if (!string.IsNullOrEmpty(aluno_.Nome))
                            {
                                Console.WriteLine($"Aluno: {aluno_.Nome} - Nota: {aluno_.Nota}.");
                            }
                        }
                        break;
                    case "3":
                        decimal soma = 0;
                        decimal alunos_com_notas = 0;

                        foreach (Aluno aluno in alunos)
                        {
                            if (!string.IsNullOrEmpty(aluno.Nome))
                            {
                                soma += aluno.Nota;
                                alunos_com_notas++;
                            }
                        }

                        decimal mediaGeral = soma / alunos_com_notas;
                        Conceito conceitoGeral = get_conceito_baseado_em_nota(mediaGeral);

                        Console.WriteLine($"A média do alunos foi {mediaGeral.ToString("F")}. Conceito: {conceitoGeral}");
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Você digitou uma opção inválida!");
                        break;
                }
                Console.WriteLine();

            } while (opcao_usuario != "0");

            static Conceito get_conceito_baseado_em_nota(decimal nota)
            {
                if (nota < 6)
                {
                    return Conceito.F;
                }
                else if (nota < 7)
                {
                    return Conceito.D;
                }
                else if (nota < 8)
                {
                    return Conceito.C;
                }
                else if (nota < 9)
                {
                    return Conceito.B;
                }
                else
                {
                    return Conceito.A;
                }
            }
        }

        private static string pegar_opcao_do_usuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("[1] - Inserir novo aluno");
            Console.WriteLine("[2] - Listar alunos");
            Console.WriteLine("[3] - Calcular média geral");
            Console.WriteLine("[0] - Sair do programa");
            Console.WriteLine();

            return Console.ReadLine();
        }
    }
}
