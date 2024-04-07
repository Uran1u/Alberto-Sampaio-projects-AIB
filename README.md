# MenuDataBase
Este menu é um projeto da escola do 2º período de programação para C# é o codigo grande 
MAS tem outro porjeto que era do 1º periodo que é mais simples.

NAME
====

**MenuDataBase** - Utility for managing database of car production.

SYNOPSIS
========

**MenuDataBase**

DESCRIPTION
===========
**MenuDataBase 1ªperiodo** is a calculator simple as that. 
**MenuDataBase 2ªperiodo** is a database of car production. 
It allows inserting data of articles, listing article data, inserting produced quantities, listing produced quantities in the week, listing produced quantity on a specific day, 
presenting the maximum quantity produced in the week, searching for produced quantity, changing produced quantity, and clearing weekly production data.


Codigo 1º periodo
-------
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char op;
            Program programa = new Program();
            int banas = 0;


            do
            {
                Console.Clear();
                Console.WriteLine("------------------------MENU------------------------------");
                Console.WriteLine("----------------------------------------------------------\n");
                Console.WriteLine(" 1 - Calcular o Índice de Massa Corporal");
                Console.WriteLine(" 2 - Calcular Fatorial");
                Console.WriteLine(" 3 - Determinar se é Primo");
                Console.WriteLine(" S - Sair");
                Console.WriteLine("----------------------------------------------------------\n");
                Console.Write(" Escolha a opção [1, 2, 3 ou S]: ");

                op = char.ToUpper(Console.ReadKey().KeyChar);

                switch (op)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("############ 1 - Calcular o Índice de Massa Corporal ############");
                        Console.WriteLine("Escreva Altura : ");
                        double altura = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Escreva Peso : ");
                        int peso = Convert.ToInt32(Console.ReadLine());
                        double imc = peso / (Math.Pow(altura, 2));
                        
                        if (imc > 40)
                        {
                            Console.WriteLine($"{imc}, Você está com obesidade nível III.");
                        }
                        else if (imc > 35)
                        {
                            Console.WriteLine($"{imc}, Você está com obesidade nível II.");
                        }
                        else if (imc > 30)
                        {
                            Console.WriteLine($"{imc}, Você está com obesidade nível I.");
                        }
                        else if (imc > 25)
                        {
                            Console.WriteLine($"{imc}, Você está acima do seu peso (sobrepeso).");
                        }
                        else if (imc > 18.5)
                        {
                            Console.WriteLine($"{imc}, Parabéns! Você está com seu peso ideal.");
                        }
                        else
                        {
                            Console.WriteLine($"{imc} , Você está abaixo do peso ideal.");
                        }

                        Console.ReadKey();


                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("############ 2 - Calcular Fatorial ############");

                        Console.WriteLine("Digite o numero: ");
                        if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 0)
                        {
                            if (numero == 0 || numero == 1)
                            {
                                numero = 1;

                            }
                            int fatorial = numero;
                            for (int i = 1; i < numero; i++)
                            {


                                fatorial = fatorial * (numero - i);


                            }

                            Console.WriteLine($"{numero}! = {fatorial} ");
                            Console.WriteLine("Prima uma tecla para continuar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Numero invalido. !");
                        }


                        break;
                    case '3':
                        Console.Clear();
                        bool ehPrimo = true;
                        Console.WriteLine("############ 3 - Determinar se número é Primo #########");
                        Console.WriteLine("Digite um numero maior q zero: ");
                        if (int.TryParse(Console.ReadLine(), out int numero1) && numero1 > 0)
                        {
                            if (numero1 <= 1)
                            {
                                Console.WriteLine("numero nao é primo");
                            }
                            for (int i = 2; i <= Math.Sqrt(numero1); i++)
                            {
                                if (numero1 % i == 0)
                                {
                                    ehPrimo = false;
                                    break;
                                }
                            }
                            if (ehPrimo)
                            {
                                Console.WriteLine($"{numero1} é primo");
                            }
                            else
                            {
                                Console.WriteLine($"{numero1} não é primo");
                            }

                        }



                        Console.ReadKey();

                        break;
                    case 'S':
                        Console.WriteLine("Obrigado. Volte sempre!");
                        break;
                    default:
                        Console.WriteLine("Operação inválida! Insira uma das opções acima! Prima uma tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (op != 'S');
        }
    }

}

```
Codigo 2º periodo
-------

```
using System;

//Made by uraniu
// este codigo não é perfeito, tem os seus erros este codigo foi feito para ser simples e sem complicaçoes, e é so este projeto foi feito em 2023
//eu dei upload no git hub so para ter o mue desempenho ao longo dos anos este projeto ira e tornar privado uma vez q sair da faculdade ( ou até antes)
class Program
{
    
    public struct Artigo
    {
        public string Design;
        public int VelocidadeMaxima;
        public int Autonomia;
        public int[,] QuantidadesProduzidas;
        
    }

    static Artigo[] modelos = new Artigo[2];
    static int[,] produtos = new int[5,2];




    static void ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("------------------------MENU------------------------------");
        Console.WriteLine(" 1 - Inserir dados de artigo\n");
        Console.WriteLine(" 2 - Listar dados de artigo\n");
        Console.WriteLine(" 3 - Inserir quantidades produzidas\n");
        Console.WriteLine(" 4 - Listar quantidades produzidas na semana\n");
        Console.WriteLine(" 5 - Listar quantidade produzida num determinado dia\n");
        Console.WriteLine(" 6 - Apresentar quantidade máxima produzida na semana\n");
        Console.WriteLine(" 7 - Procurar por quantidade produzida\n");
        Console.WriteLine(" 8 - Alterar quantidade produzida\n");
        Console.WriteLine(" 9 - Limpar dados da produção semanal\n");
        Console.WriteLine("10 - Sair...\n");
        Console.WriteLine("11 - Mudar Cor de Fundo\n");
        Console.WriteLine("----------------------------------------------------------\n");
        Console.Write(" Escolha a opção [1 a 11]: ");
    }
    //verificador 
    static bool intervalovalido(string input, out int valor, int min, int max)
    {

        if (int.TryParse(input, out valor))
        {

            if (valor >= min && valor <= max)
            {

                return true;
            }
            else
            {

                Console.WriteLine($"Por favor, Insira um número inteiro entre {min} e {max}!");

                return false;
            }
        }
        else
        {

            Console.WriteLine($"Por favor, Insira um número inteiro válido!");

            return false;
        }
    }

    //1
    static void InserirDadosArtigo()
    {
        for (int i = 0; i < modelos.Length; i++)
        {
            Console.Write($"\nDigite a designação do modelo {i + 1}: ");
            modelos[i].Design = Console.ReadLine();

            while (true)
            {
                Console.Write($"Digite a velocidade máxima do modelo {i + 1} (Km/h): ");
                string inputVelocidade = Console.ReadLine();

                if (intervalovalido(inputVelocidade, out modelos[i].VelocidadeMaxima, 0, int.MaxValue))
                {
                    break;
                }
                else
                {
                    // loop
                }
            }

            while (true)
            {
                Console.Write($"Digite a autonomia do modelo {i + 1} (kms): ");
                string inputAutonomia = Console.ReadLine();

                if (intervalovalido(inputAutonomia, out modelos[i].Autonomia, 0, int.MaxValue))
                {
                    break;
                }
                else
                {
                    // loop
                }
            }
        }
        Console.WriteLine("Carregue qualquer tecla para continuar...");
    }

    //2
    static void ListarDadosArtigo()
    {
        for (int i = 0; i < modelos.Length; i++)
        {
            Console.WriteLine($"\n\nModelo {i + 1}: {modelos[i].Design} \nVelocidade Máxima: {modelos[i].VelocidadeMaxima} Km/h \nAutonomia: {modelos[i].Autonomia} kms");
            Console.WriteLine("--------------***--------------");
        }
        Console.WriteLine("Carregue qualquer tecla para continuar...");
    }
    //3
    static void InserirQuantidadesProduzidas1()
    {
        for (int i = 0; i < modelos.Length; i++)
        {
            modelos[i].QuantidadesProduzidas = new int[5, 2];

            for (int j = 0; j < 5; j++)
            {
                Console.Write($"\nDigite a quantidade produzida para o modelo {i + 1} no dia {j + 1}: ");

                while (true)
                {
                    string inputQuantidade = Console.ReadLine();

                    if (intervalovalido(inputQuantidade, out modelos[i].QuantidadesProduzidas[j, i], 0, int.MaxValue))
                    {
                        break;
                    }
                    else
                    {
                        //loop
                    }
                }
            }
        }
        Console.WriteLine("Carregue qualquer tecla para continuar...");
    }
    //4
    static void ListarQuantidadesSemana()
    {


        
        
            for (int i = 0; i < modelos.Length; i++)
            {
                Console.WriteLine($"\n\nQuantidades produzidas para o modelo {i + 1}:");

                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"Dia {j + 1}: {modelos[i].QuantidadesProduzidas[j, i]} unidades");
                }
                Console.WriteLine("--------------***--------------");
            }
        
       

        Console.WriteLine("_____Carregue qualquer tecla para continuar...______");
        Console.ReadKey();
    }
    //5 
        static void InserirQuantidades()
    {
        for (int i = 0; i < modelos.Length; i++)
        {
            modelos[i].QuantidadesProduzidas = new int[5, 2];

            for (int j = 0; j < 5; j++)
            {
                Console.Write($"\nDigite a quantidade produzida para o modelo {i + 1} no dia {j + 1}: ");

                while (true)
                {
                    string inputQuantidade = Console.ReadLine();

                    if (intervalovalido(inputQuantidade, out modelos[i].QuantidadesProduzidas[j, i], 0, int.MaxValue))
                    {
                            produtos[j, i] = modelos[i].QuantidadesProduzidas[j, i];
                            break;
                    }
                    else
                    {
                        //loop
                    }
                }
            }
        }
        Console.WriteLine("_____Carregue qualquer tecla para continuar...______");
    }


    //6
    static void ListarQuantidadeDia()
    {
        while (true)
        {
            Console.Write("\nDigite o dia da semana (1 a 5): ");
            int dia;

            if (intervalovalido(Console.ReadLine(), out dia, 1, 5))
            {
                for (int i = 0; i < modelos.Length; i++)
                {
                    Console.WriteLine($"\nQuantidade produzida no dia {dia} para o modelo {i + 1}: {modelos[i].QuantidadesProduzidas[dia - 1, i]} unidades");
                }
                break; 
            }
            else
            {
                //loop
            }
        }
        Console.WriteLine("_____Carregue qualquer tecla para continuar...______");
    }

    //7
    static void ApresentarMaximoProduzido()
    {
        int maximo = 0;
        int diaMaximo = 0;
        int modeloMaximo = 0;

        for (int i = 0; i < modelos.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (modelos[i].QuantidadesProduzidas[j, i] > maximo)
                {
                    maximo = modelos[i].QuantidadesProduzidas[j, i];
                    diaMaximo = j + 1;
                    modeloMaximo = i + 1;
                }
            }
        }

        Console.WriteLine($"\nA quantidade máxima: {maximo} , no dia {diaMaximo}, para o modelo {modeloMaximo}");
        Console.WriteLine("_____Carregue qualquer tecla para continuar...______");
    }
    //8
    static void ProcurarPorQuantidadeProduzida()
    {
        int quantidade;

        while (true)
        {
            Console.Write("\nDigite a quantidade a procurar: ");
            string inputQuantidade = Console.ReadLine();

            if (intervalovalido(inputQuantidade, out quantidade, 0, int.MaxValue))
            {
                break; 
            }
            else
            {
                //loop
            }
        }

        bool encontrada = false;

        for (int i = 0; i < modelos.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (modelos[i].QuantidadesProduzidas[j, i] == quantidade)
                {
                    Console.WriteLine($"\nQuantidade {quantidade} encontrada no dia {j + 1} para o modelo {i + 1}");
                    encontrada = true;
                }
            }
        }

        if (!encontrada)
        {
            Console.WriteLine($"\nA quantidade {quantidade} não está registada (não existe).");
        }
        Console.WriteLine("_____Carregue qualquer tecla para continuar...______");
    }

    //9
    static void AlterarQuantidadeProduzida()
    {
        int dia;

        while (true)
        {
            Console.Write("\nDigite o dia da semana (1 a 5): ");
            if (intervalovalido(Console.ReadLine(), out dia, 1, 5))
            {
                break; 
            }
            else
            {
                //lloop
            }
        }

        int modelo;

        while (true)
        {
            Console.Write("\nDigite o modelo (1 ou 2): ");
            if (intervalovalido(Console.ReadLine(), out modelo, 1, 2))
            {
                break; 
            }
            else
            {
               // loop
            }
        }

        int novaQuantidade;

        while (true)
        {
            Console.Write("\nDigite a nova quantidade produzida: ");
            if (intervalovalido(Console.ReadLine(), out novaQuantidade, 0, int.MaxValue))
            {
                break; 
            }
            else
            {
                //loop
            }
        }

        modelos[modelo - 1].QuantidadesProduzidas[dia - 1, modelo - 1] = novaQuantidade;

        Console.WriteLine($"\nQuantidade alterada com sucesso para {novaQuantidade} unidades no dia {dia} para o modelo {modelo}");
        Console.WriteLine("_____Carregue qualquer tecla para continuar...______");
    }
    //10
    static void LimparDadosProducao()
    {
        while (true)
        {
            Console.Write("\nTem a certeza que deseja limpar todos os dados da produção semanal? (S/N): ");
            string resposta = Console.ReadLine();

            if (resposta.ToLower() == "s")
            {
                for (int i = 0; i < modelos.Length; i++)
                {
                    modelos[i].QuantidadesProduzidas = null;
                }

                Console.WriteLine("\nDados da produção semanal limpos com sucesso.");
                break; 
            }
            else if (resposta.ToLower() == "n")
            {
                Console.WriteLine("\nOperação cancelada.");
                break; 
            }
            else
            {
                
            }
        }
        Console.WriteLine("_____Carregue qualquer tecla para continuar...______");
    }
    static void MudarCorFundo()
    {
        Console.Clear();
        Console.WriteLine("Escolha a cor de fundo:");
        Console.WriteLine("1 - Preto");
        Console.WriteLine("2 - Branco");
        Console.WriteLine("3 - Amarelo");
        Console.WriteLine("4 - Rosa");
        Console.WriteLine("5 - Azul");
        Console.WriteLine("6 - Roxo");
        Console.WriteLine("7 - Laranja");

        int opcaoCor;
        while (!intervalovalido(Console.ReadLine(), out opcaoCor, 1, 7)) ;

        ConsoleColor corFundo;
        ConsoleColor Corfrente;

        switch (opcaoCor)
        {
            case 1:
                corFundo = ConsoleColor.Black;
                corFundo = ConsoleColor.White;
                Console.BackgroundColor = corFundo;
                Console.BackgroundColor = corFundo;
                Console.Clear();
                break;
            case 2:
                corFundo = ConsoleColor.White;
                Corfrente = ConsoleColor.Black;
                Console.ForegroundColor = Corfrente;
                Console.BackgroundColor = corFundo;
                
                Console.Clear();
                break;
            case 3:
                corFundo = ConsoleColor.Yellow;
                Corfrente = ConsoleColor.Black;
                Console.ForegroundColor = Corfrente;
                Console.BackgroundColor = corFundo;
                Console.Clear();
                break;
            case 4:
                corFundo = ConsoleColor.Magenta;
                Corfrente = ConsoleColor.White;
                Console.ForegroundColor = Corfrente;
                Console.BackgroundColor = corFundo;
                Console.Clear();
                break;
            case 5:
                corFundo = ConsoleColor.Blue;
                Corfrente = ConsoleColor.White;
                Console.ForegroundColor = Corfrente;
                Console.BackgroundColor = corFundo;
                Console.Clear();
                break;
            case 6:
                corFundo = ConsoleColor.DarkMagenta;
                Console.BackgroundColor = corFundo;
                Console.Clear();
                break;
            case 7:
                corFundo = ConsoleColor.DarkYellow;
                Console.BackgroundColor = corFundo;
                Console.Clear();
                break;
        }
    }
    static void Main(string[] args)
    {
        Console.Beep();
        //so para assustar a stora
        Console.Title = "Gestão de Produção de Trotinetes";
        int opcao;
        bool verificador1 = false;

        do
        {
            ApresentarMenu();
            while (!intervalovalido(Console.ReadLine(), out opcao, 1, 11)) ;

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    InserirDadosArtigo();
                    break;
                case 2:
                    Console.Clear();
                    ListarDadosArtigo();
                    break;
                case 3:
                    Console.Clear();

                    InserirQuantidadesProduzidas1();

                    verificador1 = true;

                    break;
                case 4:
                    Console.Clear();
                    //foi nessesario colocar este confirmador porque se n tivese nehum valor a consola so fechava
                    if (verificador1 == false)
                    {
                        Console.WriteLine("Não existe nehum valor na base de dados!!!");
                        Console.WriteLine("Quer inserir os valores ? S/N: ");
                        string resposta = Console.ReadLine();

                        if (resposta.ToLower() == "s")
                        {
                            Console.Clear();
                            InserirQuantidades();
                        }
                    }
                    else
                    {
                        ListarQuantidadesSemana();
                        break;

                    }
                    break;
                case 5:
                    Console.Clear();
                    if (verificador1 == false)
                    {
                        Console.WriteLine("Não existe nehum valor na base de dados!!!");
                        Console.WriteLine("Quer inserir os valores ? S/N: \"");
                        string resposta = Console.ReadLine();

                        if (resposta.ToLower() == "s")
                        {
                            Console.Clear();
                            verificador1 = true;
                            InserirQuantidades();
                        }
                    }
                    else
                    {
                        ListarQuantidadeDia();
                        break;

                    }
                    break;


                case 6:
                    Console.Clear(); Console.Clear();
                    if (verificador1 == false)
                    {
                        Console.WriteLine("Não existe nehum valor na base de dados!!!");
                        Console.WriteLine("Quer inserir os valores ? S/N: ");
                        string resposta = Console.ReadLine();

                        if (resposta.ToLower() == "s")
                        {
                            Console.Clear();
                            verificador1 = true;
                            InserirQuantidades();
                        }
                    }
                    else
                    {
                        ApresentarMaximoProduzido();
                        break;

                    }


                    break;
                case 7:
                    Console.Clear();
                    if (verificador1 == false)
                    {
                        Console.WriteLine("Não existe nehum valor na base de dados!!!");
                        Console.WriteLine("Deseja inserir valores agora? (S/N): ");
                        string resposta = Console.ReadLine();

                        if (resposta.ToLower() == "s")
                        {
                            Console.Clear();
                            verificador1 = true;
                            InserirQuantidades();
                        }
                    }
                    else
                    {
                        ProcurarPorQuantidadeProduzida();
                        break;

                    }

                    break;
                case 8:
                    Console.Clear();
                    if (verificador1 == false)
                    {
                        Console.WriteLine("Não existe nehum valor na base de dados!!!");
                        Console.WriteLine("Quer inserir os valores ? S/N: ");
                        string resposta = Console.ReadLine();

                        if (resposta.ToLower() == "s")
                        {
                            Console.Clear();
                            verificador1 = true;
                            InserirQuantidades();
                        }
                    }
                    else
                    {
                        AlterarQuantidadeProduzida();
                        break;

                    }

                    break;


                case 9:
                    Console.Clear();
                    if (verificador1 == false)
                    {
                        Console.WriteLine("Não inseriu nenhum valor para ser listado nesta semana.");
                        Console.WriteLine("Quer inserir os valores ? S/N: \"");
                        string resposta = Console.ReadLine();

                        if (resposta.ToLower() == "s")
                        {
                            Console.Clear();
                            verificador1 = true;
                            InserirQuantidades();
                        }
                    }
                    else
                    {
                        LimparDadosProducao();
                        break;

                    }

                    break;


                case 10:
                    Console.Clear();
                    Console.WriteLine("\nFechar...");
                    break;
                case 11:
                    MudarCorFundo();
                   
                    break;

            }

            Console.ReadKey();
        } while (opcao != 10);
    }
}


```
