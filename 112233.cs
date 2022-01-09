using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarations of arrys and variables
            int score = 0;
            int[] random_numbers = new int[30];
            int[] first_line = new int[30];
            int[] second_line = new int[30];
            int[] third_line = new int[30];
            int cursorx = 15, cursory = 2;   // position of cursor
            ConsoleKeyInfo cki;               // required for readkey
            int moveNumber = 0;
            //Generating random numbers and assigning assigning them into array
            Random rd = new Random();
            for (int i = 0; i < 30; i++)
            {
                random_numbers[i] = rd.Next(1, 4);
            }

            //Printing game table 
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("+------------------------------+\n");

            //random sayılar arraylere yerleştiriliyor
            int var1 = 0; //loop var
            int random_column;
            int random_line;
            do
            {
                random_column = rd.Next(0, 30);
                random_line = rd.Next(1, 4);
                if (random_line == 1 && first_line[random_column] == 0)
                {
                    first_line[random_column] = random_numbers[var1];
                    var1++;
                }
                else if (random_line == 2 && second_line[random_column] == 0)
                {
                    second_line[random_column] = random_numbers[var1];
                    var1++;
                }
                else if (random_line == 3 && third_line[random_column] == 0)
                {
                    third_line[random_column] = random_numbers[var1];
                    var1++;
                }
                else
                    continue;

            } while (var1 < 30);

            //the loop that checks is "is there any sequential same number?". If there is deletes and creates 2 different number
            while (true)
            {
                for (int i = 0; i < 29; i++) //loop for first line
                {
                    if (first_line[i] != 0 && first_line[i] == first_line[i + 1])
                    {
                        //delete both number, increase score, create 2 new numbers and assigned them into arrays
                        first_line[i] = 0;
                        first_line[i + 1] = 0;
                        score += 10;
                        i = 0;

                        while (true)
                        {
                            int firstNewNumber = rd.Next(1, 4);
                            int secondNewNumber = rd.Next(1, 4);
                            int first_random_column = rd.Next(0, 30);
                            int second_random_column = rd.Next(0, 30);
                            if (first_line[first_random_column] == 0 && first_line[second_random_column] == 0)
                            {
                                first_line[first_random_column] = firstNewNumber;
                                first_line[second_random_column] = secondNewNumber;
                                break;
                            }

                        }

                    }
                }

                for (int i = 0; i < 29; i++) //loop for second line
                {
                    if (second_line[i] != 0 && second_line[i] == second_line[i + 1])
                    {
                        //delete both number, increase score, create 2 new numbers and assigned them into arrays
                        second_line[i] = 0;
                        second_line[i + 1] = 0;
                        score += 10;
                        i = 0;

                        while (true)
                        {
                            int firstNewNumber = rd.Next(1, 4);
                            int secondNewNumber = rd.Next(1, 4);
                            int first_random_column = rd.Next(0, 30);
                            int second_random_column = rd.Next(0, 30);
                            if (second_line[first_random_column] == 0 && second_line[second_random_column] == 0)
                            {
                                second_line[first_random_column] = firstNewNumber;
                                second_line[second_random_column] = secondNewNumber;
                                break;
                            }

                        }

                    }
                }

                for (int i = 0; i < 29; i++) //loop for third line
                {
                    if (third_line[i] != 0 && third_line[i] == third_line[i + 1])
                    {
                        //delete both number, increase score, create 2 new numbers and assigned them into arrays
                        third_line[i] = 0;
                        third_line[i + 1] = 0;
                        score += 10;
                        i = 0;

                        while (true)
                        {
                            int firstNewNumber = rd.Next(1, 4);
                            int secondNewNumber = rd.Next(1, 4);
                            int first_random_column = rd.Next(0, 30);
                            int second_random_column = rd.Next(0, 30);
                            if (third_line[first_random_column] == 0 && third_line[second_random_column] == 0)
                            {
                                third_line[first_random_column] = firstNewNumber;
                                third_line[second_random_column] = secondNewNumber;
                                break;
                            }

                        }

                    }
                }
                break;
            }

            //printing console and score
            Console.SetCursorPosition(37, 1);
            Console.WriteLine("SCORE:" + score);

            ///////////////////////////////////////////////////////////////GAME LOOP\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            while (true)
            {
                Console.SetCursorPosition(37, 1);
                Console.WriteLine("SCORE:" + score);
                Console.SetCursorPosition(37, 2);
                Console.WriteLine("Remaining Moves:" + (50-moveNumber));
                if (50-moveNumber<10)
                {
                    Console.SetCursorPosition(37, 2);
                    Console.WriteLine("Remaining Moves: " + (50 - moveNumber));
                }
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);       // true: do not write character 

                    Console.SetCursorPosition(1, 1);
                    for (int i = 0; i < 30; i++)
                    {

                        if (first_line[i] == 1 || first_line[i] == 2 || first_line[i] == 3)
                        {
                            Console.Write(first_line[i]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }

                    }
                    Console.SetCursorPosition(1, 2);
                    for (int i = 0; i < 30; i++)
                    {
                        if (second_line[i] == 1 || second_line[i] == 2 || second_line[i] == 3)
                        {
                            Console.Write(second_line[i]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.SetCursorPosition(1, 3);
                    for (int i = 0; i < 30; i++)
                    {
                        if (third_line[i] == 1 || third_line[i] == 2 || third_line[i] == 3)
                        {
                            Console.Write(third_line[i]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    //MOVEMENTS OF ARROW KEYS


                    if (cki.Key == ConsoleKey.RightArrow && cursorx < 30)    // key and boundary control  
                    {
                        cursorx++;// delete X (old position)
                    }
                    if (cki.Key == ConsoleKey.LeftArrow && cursorx > 1)
                    {
                        cursorx--;
                    }
                    if (cki.Key == ConsoleKey.UpArrow && cursory > 1)
                    {
                        cursory--;
                    }
                    if (cki.Key == ConsoleKey.DownArrow && cursory < 3)
                    {
                        cursory++;
                    }

                    //MOWEMENTS OF WASD KEYS
                    ///////////////////////////////////////////////////////////
                    if (cki.Key == ConsoleKey.W)
                    {

                        if (cursory == 2)
                        {
                            if (second_line[cursorx - 1] != 0 && first_line[cursorx - 1] == 0)
                            {
                                first_line[cursorx - 1] = second_line[cursorx - 1];
                                second_line[cursorx - 1] = 0;
                                moveNumber++;
                            }
                        }
                        if (cursory == 3)
                        {
                            if (third_line[cursorx - 1] != 0 && second_line[cursorx - 1] == 0)
                            {
                                second_line[cursorx - 1] = third_line[cursorx - 1];
                                third_line[cursorx - 1] = 0;
                                moveNumber++;
                            }
                        }

                    }
                    if (cki.Key == ConsoleKey.S)
                    {

                        if (cursory == 1)
                        {
                            if (first_line[cursorx - 1] != 0 && second_line[cursorx - 1] == 0)
                            {
                                second_line[cursorx - 1] = first_line[cursorx - 1];
                                first_line[cursorx - 1] = 0;
                                moveNumber++;
                            }
                        }
                        if (cursory == 2)
                        {
                            if (second_line[cursorx - 1] != 0 && third_line[cursorx - 1] == 0)
                            {
                                third_line[cursorx - 1] = second_line[cursorx - 1];
                                second_line[cursorx - 1] = 0;
                                moveNumber++;
                            }
                        }

                    }
                    if (cki.Key == ConsoleKey.A)
                    {

                        if (cursory == 1)
                        {
                            int current_position = cursorx - 1;
                            if (first_line[cursorx - 1] != 0)
                            {
                                moveNumber++;
                                while (current_position > 0 && first_line[current_position - 1] == 0)
                                {
                                    first_line[current_position - 1] = first_line[current_position];
                                    first_line[current_position] = 0;
                                    current_position--;

                                }
                            }
                        }
                        if (cursory == 2)
                        {
                            int current_position = cursorx - 1;
                            if (second_line[cursorx - 1] != 0)
                            {
                                moveNumber++;
                                while (current_position > 0 && second_line[current_position - 1] == 0)
                                {
                                    second_line[current_position - 1] = second_line[current_position];
                                    second_line[current_position] = 0;
                                    current_position--;

                                }
                            }
                        }
                        if (cursory == 3)
                        {
                            int current_position = cursorx - 1;
                            if (third_line[cursorx - 1] != 0)
                            {
                                moveNumber++;
                                while (current_position > 0 && third_line[current_position - 1] == 0)
                                {
                                    third_line[current_position - 1] = third_line[current_position];
                                    third_line[current_position] = 0;
                                    current_position--;

                                }
                            }
                        }


                    }
                    if (cki.Key == ConsoleKey.D)
                    {

                        if (cursory == 1)
                        {
                            int current_position = cursorx - 1;
                            if (first_line[cursorx - 1] != 0)
                            {
                                moveNumber++;
                                while (current_position < 29 && first_line[current_position + 1] == 0)
                                {
                                    first_line[current_position + 1] = first_line[current_position];
                                    first_line[current_position] = 0;
                                    current_position++;
                                }
                            }
                        }
                        if (cursory == 2)
                        {
                            int current_position = cursorx - 1;
                            if (second_line[cursorx - 1] != 0)
                            {
                                moveNumber++;
                                while (current_position < 29 && second_line[current_position + 1] == 0)
                                {
                                    second_line[current_position + 1] = second_line[current_position];
                                    second_line[current_position] = 0;
                                    current_position++;
                                }
                            }
                        }
                        if (cursory == 3)
                        {
                            int current_position = cursorx - 1;
                            if (third_line[cursorx - 1] != 0)
                            {
                                moveNumber++;
                                while (current_position < 29 && third_line[current_position + 1] == 0)
                                {
                                    third_line[current_position + 1] = third_line[current_position];
                                    third_line[current_position] = 0;
                                    current_position++;
                                }
                            }
                        }

                    }

                    if (cki.Key == ConsoleKey.Escape) break;
                }

                Console.SetCursorPosition(1, 1);
                for (int i = 0; i < 30; i++)
                {

                    if (first_line[i] == 1 || first_line[i] == 2 || first_line[i] == 3)
                    {
                        Console.Write(first_line[i]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.SetCursorPosition(1, 2);
                for (int i = 0; i < 30; i++)
                {
                    if (second_line[i] == 1 || second_line[i] == 2 || second_line[i] == 3)
                    {
                        Console.Write(second_line[i]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.SetCursorPosition(1, 3);
                for (int i = 0; i < 30; i++)
                {
                    if (third_line[i] == 1 || third_line[i] == 2 || third_line[i] == 3)
                    {
                        Console.Write(third_line[i]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }


                //the loops that checks is "is there any sequential same number?". If there is deletes and creates 2 different number
                while (true)
                {
                    int onlyOne = 0;
                    for (int i = 0; i < 29; i++) //loop for first line
                    {
                        if (first_line[i] != 0 && first_line[i] == first_line[i + 1])
                        {
                            //delete both number, increase score, create 2 new numbers and assigned them into arrays
                            first_line[i] = 0;
                            first_line[i + 1] = 0;
                            if (onlyOne == 0)
                            {
                                score += 10;
                            }
                            i = 0;

                            while (true)
                            {
                                int firstNewNumber = rd.Next(1, 4);
                                int secondNewNumber = rd.Next(1, 4);
                                int first_random_column = rd.Next(0, 30);
                                int second_random_column = rd.Next(0, 30);
                                if (first_line[first_random_column] == 0 && first_line[second_random_column] == 0)
                                {
                                    first_line[first_random_column] = firstNewNumber;
                                    first_line[second_random_column] = secondNewNumber;
                                    onlyOne++;
                                    break;
                                }

                            }

                        }
                    }

                    for (int i = 0; i < 29; i++) //loop for second line
                    {
                        if (second_line[i] != 0 && second_line[i] == second_line[i + 1])
                        {
                            //delete both number, increase score, create 2 new numbers and assigned them into arrays
                            second_line[i] = 0;
                            second_line[i + 1] = 0;
                            if (onlyOne == 0)
                            {
                                score += 10;
                            }
                            i = 0;

                            while (true)
                            {
                                int firstNewNumber = rd.Next(1, 4);
                                int secondNewNumber = rd.Next(1, 4);
                                int first_random_column = rd.Next(0, 30);
                                int second_random_column = rd.Next(0, 30);
                                if (second_line[first_random_column] == 0 && second_line[second_random_column] == 0)
                                {
                                    second_line[first_random_column] = firstNewNumber;
                                    second_line[second_random_column] = secondNewNumber;
                                    onlyOne++;
                                    break;
                                }
                            }

                        }
                    }

                    for (int i = 0; i < 29; i++) //loop for third line
                    {
                        if (third_line[i] != 0 && third_line[i] == third_line[i + 1])
                        {
                            //delete both number, increase score, create 2 new numbers and assigned them into arrays
                            third_line[i] = 0;
                            third_line[i + 1] = 0;
                            if (onlyOne == 0)
                            {
                                score += 10;

                            }
                            i = 0;

                            while (true)
                            {
                                int firstNewNumber = rd.Next(1, 4);
                                int secondNewNumber = rd.Next(1, 4);
                                int first_random_column = rd.Next(0, 30);
                                int second_random_column = rd.Next(0, 30);
                                if (third_line[first_random_column] == 0 && third_line[second_random_column] == 0)
                                {
                                    third_line[first_random_column] = firstNewNumber;
                                    third_line[second_random_column] = secondNewNumber;
                                    onlyOne++;
                                    break;
                                }
                            }

                        }
                    }
                    break;
                }


                Console.SetCursorPosition(cursorx, cursory);
                Thread.Sleep(50);
                if (moveNumber == 50)
                {
                    
                    Console.SetCursorPosition(37, 2);
                    Console.WriteLine("Remaining Moves=" + 50);
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            Console.WriteLine("███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀");
            Console.WriteLine("██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼");
            Console.WriteLine("██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀");
            Console.WriteLine("██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼");
            Console.WriteLine("███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄");
            Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            Console.WriteLine("███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼");
            Console.WriteLine("██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼");
            Console.WriteLine("██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼");
            Console.WriteLine("██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼");
            Console.WriteLine("███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄");
            Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            Console.WriteLine("┼┼┼┼┼┼  YOUR SCORE IS :" + score+ "  ┼┼┼┼┼┼┼┼┼┼");


        }
        


    }
}

