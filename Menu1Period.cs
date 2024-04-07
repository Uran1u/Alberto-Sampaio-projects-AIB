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