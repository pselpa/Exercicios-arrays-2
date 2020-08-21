using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercicios_arrays_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // MENU PRINCIPAL DOS EXERCÍCIOS

            var exercises = new List<Action>()
            {
                exercicio1,
                exercicio2,
                exercicio3,
                exercicio4,
                exercicio5,
                exercicio6,
                exercicio7,
                exercicio8,
                exercicio9,
            };

            Console.Write("Escolha entre os exercícios 1 a 9: ");
            
            var input = Int32.Parse(Console.ReadLine());
            exercises[input-1]();



                static void exercicio1()
                {
                    System.Console.WriteLine("1. Popule dois vetores com 10 valores cada. Após esta operação, troque o conteúdo dos vetores.");
                    var listA = new int[10];
                    var listB = new int[10];
                    var temp = new int[10];

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"Digite o {i+1}º número da lista A: ");
                        var inputA = Console.ReadLine();
                        Console.Write($"Digite o {i+1}º número da lista B: ");
                        var inputB = Console.ReadLine();

                        try
                        {
                            listA[i] = Int32.Parse(inputA);
                            listB[i] = Int32.Parse(inputB);
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Erro. Algum item inválido foi inserido. Insira um número inteiro.");
                            i--;
                        }
                    }

                    Console.Write($"\nLista A = ");
                    foreach (var item in listA)
                    {
                        Console.Write($"{item} ");
                    }
                    System.Console.WriteLine("");

                    Console.Write($"Lista B = ");
                    foreach (var item in listB)
                    {
                        Console.Write($"{item} ");
                    }
                    System.Console.WriteLine("");

                    for (int i = 0; i < 10; i++)
                    {
                        temp[i] = listA[i];
                        listA[i] = listB[i];
                        listB[i] = temp[i];
                    }
                    Console.Write($"\nLista A = ");
                    foreach (var item in listA)
                    {
                        Console.Write($"{item} ");
                    }
                    System.Console.WriteLine("");

                    Console.Write($"Lista B = ");
                    foreach (var item in listB)
                    {
                        Console.Write($"{item} ");
                    }
                    System.Console.WriteLine("\n");
                }



                static void exercicio2()
                {
                    System.Console.WriteLine("2. Dado um vetor qualquer com 10 números, faça um programa que informa se há ou não números repetidos nesse vetor.");
                    var list = new int[10];
                    var input = "";

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"Insira o {i+1}° número do vetor: ");
                        input = Console.ReadLine();
                        try
                        {
                            list[i] = Int32.Parse(input);
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Erro. Um item inválido foi inserido. Insira um número inteiro.");
                            i--;
                        }
                    }
                    
                    Array.Sort(list);
                    Console.Write("\nLista (em ordem) = ");
                    foreach (int item in list) 
                    {
                        Console.Write($"{item}  ");
                    }
                    System.Console.WriteLine("");

                    int previousNumber = Int32.MaxValue;  
                    foreach (int item in list)
                    {
                        if (item == previousNumber)
                        {
                            System.Console.WriteLine($"\nAo menos o número {item} se repete na lista.\n");
                            break;
                        }
                        previousNumber = item;
                    }
                }



                static void exercicio3()
                {
                    //Um certa empresa fez uma pesquisa para saber se as pessoas gostaram ou não de um novo produto lançado no mercado. Para isso, forneceu-se o sexo do entrevistado
                    //e a sua resposta (sim ou não). Sabendo-se que foram entrevistadas 10 pessoas, fazer um algoritmo que calcule e escreva:
                    //• O número de pessoas que responderam sim;
                    //• O número de pessoas que responderam não;
                    //• A percentagem de pessoas do sexo feminino que responderam sim;
                    //• A percentagem de pessoas do sexo masculino que responderam não;

                    System.Console.WriteLine("3. Pesquisa de produto com 10 pessoas. Informar quantos gostaram, não gostaram, quantas mulheres gostaram e quantos homens não gostaram.");
                    var research = new (string gender, string answer)[10];
                    double positiveAnswer = 0.0;
                    double negativeAanswer = 0.0;
                    double femalePositiveCount = 0.0;
                    double femaleTotalCount = 0.0;
                    double maleNegativeCount = 0.0;
                    double maleTotalCount = 0.0;
                    double femalePercent = 0.0;
                    double malePercent = 0.0;
                    var inputGender = "";
                    var inputAnswer = "";

                    for (int i = 0; i < 10; i++)
                    {                   
                        while (true)
                        {
                            Console.Write($"{i+1}/10 - Informe o seu gênero (F ou M): ");
                            inputGender = Console.ReadLine().ToUpper();

                            if (inputGender == "F" || inputGender == "M")
                            {
                                research[i].gender = inputGender;
                                break;
                            }
                        }

                        while (true)
                        {
                            Console.Write($"{i+1}/10 - Você gostou do produto testado (S ou N): ");
                            inputAnswer = Console.ReadLine().ToUpper();

                            if (inputAnswer == "S" || inputAnswer == "N")
                            {
                                research[i].answer = inputAnswer;
                                break;
                            }
                        }

                    }

                    foreach (var item in research)
                    {
                        if (item.answer == "S")
                        {
                            positiveAnswer++;
                            if (item.gender == "F")
                            {
                                femalePositiveCount++;
                                femaleTotalCount++;
                            }
                            else if (item.gender == "M")
                            {
                                maleTotalCount++;
                            }
                        }
                        else if (item.answer == "N")
                        {
                            negativeAanswer++;
                            if (item.gender == "M")
                            {
                                maleNegativeCount++;
                                maleTotalCount++;
                            }
                            else if (item.gender == "F")
                            {
                                femaleTotalCount++;
                            }
                        }
                    }

                    femalePercent = femalePositiveCount / femaleTotalCount * 100;
                    malePercent = maleNegativeCount / maleTotalCount * 100;

                    System.Console.WriteLine($"\n{positiveAnswer} pessoas gostaram do produto.");
                    System.Console.WriteLine($"{negativeAanswer} pessoas NÃO gostaram do produto.");
                    System.Console.WriteLine($"{femalePercent}% das mulheres gostaram do produto.");
                    System.Console.WriteLine($"{malePercent}% dos homens NÃO gostaram do produto.\n");
                }



                static void exercicio4()
                {
                    System.Console.WriteLine("4. Efetue a leitura de cinco elementos de uma matriz A do tipo vetor e Apresente a soma de todos os elementos que sejam impares.");
                    var a = new int[5];
                    int sumOddNumbers = 0;
                    var input = "";

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write($"Insira o número {i+1}/5: ");
                        input = Console.ReadLine();
                        try
                        {
                            a[i] = Int32.Parse(input);
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Erro. Um item inválido foi inserido. Insira um número inteiro.");
                            i--;
                        }
                        if (a[i] % 2 != 0)
                            {
                                sumOddNumbers += a[i];
                            }
                    }
                    System.Console.WriteLine($"\nA soma dos números ímpares do Vetor é {sumOddNumbers}.\n");
                }



                static void exercicio5()
                {
                    System.Console.WriteLine("5. Contar quantos valores de um vetor de 10 posições são positivos.");
                    var array = new int[10];
                    int evenNumbersCount = 0;
                    var input = "";

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"Insira o número {i+1}/10: ");
                        input = Console.ReadLine();
                        try
                        {
                            array[i] = Int32.Parse(input);
                            if (array[i] % 2 == 0 && array[i] > 0)
                            {
                                evenNumbersCount++;
                            }
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Erro. Um item inválido foi inserido. Insira um número inteiro.");
                            i--;
                        }
                    }
                    System.Console.WriteLine($"\nHá {evenNumbersCount} números pares no Vetor.\n");
                }



                static void exercicio6()
                {
                    System.Console.WriteLine("6. Ler um vetor de 10 números positivos. Escrever a seguir o valor do maior elemento e a respectiva posição que ele ocupa no vetor.");
                    var array = new double[10];
                    double biggestValue = 0;
                    int index = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write($"Insira um número positivo {i+1}/10 no vetor: ");
                        var input = Console.ReadLine();
                        try
                        {
                            double number = double.Parse(input);
                            if (number > 0)
                            {
                                array[i] = number;
                            }
                            else
                            {
                                System.Console.WriteLine("Erro: Insira um número positivo.");
                                i--;
                            }
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Erro. Um item inválido foi inserido. Insira um número inteiro positivo.");
                            i--;
                        }                                                
                    }

                    for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] > biggestValue)
                            {
                                biggestValue = array[i];
                                index = i;
                            }

                        }
                    System.Console.WriteLine($"\nO maior valor no vetor é {biggestValue}, com posição {index}\n");
                }



                static void exercicio7()
                {
                    System.Console.WriteLine("7. Popule um vetor A e imprima na tela o quantas vezes há um número residindo na mesma posição do vetor que seu valor numérico");
                    var arrayA = new int[10];
                    int indexCount = 0;
                    var input = "";

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"Insira o número {i+1}/10 no vetor: ");
                        input = Console.ReadLine();
                        try
                        {
                            arrayA[i] = Int32.Parse(input);
                            if (arrayA[i] == i)
                            {
                                indexCount++;
                            }
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Erro. Um item inválido foi inserido. Insira um número inteiro.");
                            i--;
                        }                        
                    }

                    System.Console.WriteLine($"\nHá {indexCount} ocorrências de números iguais ao seu índice, no vetor.\n");
                }



                static void exercicio8()
                {
                    System.Console.WriteLine("8. Crie um vetor de strings de 10 posições onde cada posição recebe uma letra do alfabeto. No final, imprima quantas destas são vogais.");
                    var arrayAlphabet = new string[10];
                    int vowelCount = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"Insira a letra {i+1}/10 no vetor: ");
                        arrayAlphabet[i] = Console.ReadLine().ToUpper();
                        if (arrayAlphabet[i] != "A" && arrayAlphabet[i] != "B" && arrayAlphabet[i] != "C" && arrayAlphabet[i] != "D" && arrayAlphabet[i] != "E" && arrayAlphabet[i] != "F" && arrayAlphabet[i] != "G" && arrayAlphabet[i] != "H" && arrayAlphabet[i] != "I" && arrayAlphabet[i] != "J" && arrayAlphabet[i] != "K" && arrayAlphabet[i] != "L" && arrayAlphabet[i] != "M" && arrayAlphabet[i] != "N" && arrayAlphabet[i] != "O" && arrayAlphabet[i] != "P" && arrayAlphabet[i] != "Q" && arrayAlphabet[i] != "R" && arrayAlphabet[i] != "S" && arrayAlphabet[i] != "T" && arrayAlphabet[i] != "U" && arrayAlphabet[i] != "V" && arrayAlphabet[i] != "W" && arrayAlphabet[i] != "X" && arrayAlphabet[i] != "Y" && arrayAlphabet[i] != "Z") 
                        {
                            System.Console.WriteLine("Erro. Insira apenas letras do alfabeto, uma por vez.");
                            i--;
                        }
                        else
                        {
                            if (arrayAlphabet[i] == "A" || arrayAlphabet[i] == "E" || arrayAlphabet[i] == "I" || arrayAlphabet[i] == "O" || arrayAlphabet[i] == "U")
                            {
                                vowelCount++;
                            }
                        }
                    }
                    System.Console.WriteLine($"\nHá {vowelCount} vogais no Vetor.");
                }



                static void exercicio9()
                {
                    System.Console.WriteLine("9. Crie um vetor de strings de 10 posições onde cada posição recebe uma letra do alfabeto. No final, imprima a string resultante da soma das strings que residem em índices pares");
                    var arrayAlphabet = new string[10];
                    string evenNuberIndexString = "";

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"Insira a letra {i+1}/10 no vetor: ");
                        arrayAlphabet[i] = Console.ReadLine().ToUpper();
                        if (arrayAlphabet[i] != "A" && arrayAlphabet[i] != "B" && arrayAlphabet[i] != "C" && arrayAlphabet[i] != "D" && arrayAlphabet[i] != "E" && arrayAlphabet[i] != "F" && arrayAlphabet[i] != "G" && arrayAlphabet[i] != "H" && arrayAlphabet[i] != "I" && arrayAlphabet[i] != "J" && arrayAlphabet[i] != "K" && arrayAlphabet[i] != "L" && arrayAlphabet[i] != "M" && arrayAlphabet[i] != "N" && arrayAlphabet[i] != "O" && arrayAlphabet[i] != "P" && arrayAlphabet[i] != "Q" && arrayAlphabet[i] != "R" && arrayAlphabet[i] != "S" && arrayAlphabet[i] != "T" && arrayAlphabet[i] != "U" && arrayAlphabet[i] != "V" && arrayAlphabet[i] != "W" && arrayAlphabet[i] != "X" && arrayAlphabet[i] != "Y" && arrayAlphabet[i] != "Z") 
                        {
                            System.Console.WriteLine("Erro. Insira apenas letras do alfabeto, uma por vez.");
                            i--;
                        }
                        else
                        {
                            if (i % 2 == 0 && i > 0)
                            {
                                evenNuberIndexString += arrayAlphabet[i];
                            }
                        }
                    }
                    
                    System.Console.WriteLine($"\nA string reultante de letras em índices pares é {evenNuberIndexString}.\n");
                }
            System.Console.WriteLine("*** APLICAÇÃO FINALIZADA ***\n");
        }
    }
}
