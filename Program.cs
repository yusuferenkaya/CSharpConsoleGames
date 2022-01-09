using System;
using System.Threading;

namespace _3rdProjectCheckers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Printing table.
            char[][] gameTable = new char[8][];
            Console.WriteLine("  12345678 ");
            Console.WriteLine(" +--------+");
            Console.WriteLine("1|        |");
            Console.WriteLine("2|        |");
            Console.WriteLine("3|        |");
            Console.WriteLine("4|        |");
            Console.WriteLine("5|        |");
            Console.WriteLine("6|        |");
            Console.WriteLine("7|        |");
            Console.WriteLine("8|        |");
            Console.WriteLine(" +--------+");

            //Filling the array which holds "o"s, "x"s and dots(".").
            for (short i = 0; i < 8; i++)
            {
                gameTable[i] = new char[8];
                for (short j = 0; j < 8; j++)
                {
                    if (i < 3)
                    {
                        if (j <= 2)
                            gameTable[i][j] = 'o';
                        else
                            gameTable[i][j] = '.';
                    }
                    else if (i >= 5)
                    {
                        if (j >= 5)
                            gameTable[i][j] = 'x';
                        else
                            gameTable[i][j] = '.';
                    }
                    else
                        gameTable[i][j] = '.';
                }
            }

            void gameExe(char[][] gameTable)
            {
                ConsoleKeyInfo cki;
                short cursorX = 7, cursorY = 7;
                bool placingActivated = false;
                short zPressedcursorX = 0, zPressedCursorY = 0;
                bool humanTurn = true;
                short roundCounter = 0;
                short win = 0;
                short jumpController = 0;
                while (humanTurn)
                {
                    humanTurn = true;
                    formTheGameTable(gameTable);

                    Console.SetCursorPosition(cursorX, cursorY);
                    if (Console.KeyAvailable)
                    {
                        //Cursor movement.
                        //Right side of "&&" is for boundary control.
                        cki = Console.ReadKey(true);
                        if (cki.Key == ConsoleKey.RightArrow && cursorX < 9)
                        {
                            cursorX++;
                        }
                        else if (cki.Key == ConsoleKey.LeftArrow && cursorX > 2)
                        {
                            cursorX--;
                        }
                        else if (cki.Key == ConsoleKey.UpArrow && cursorY > 2)
                        {
                            cursorY--;
                        }
                        else if (cki.Key == ConsoleKey.DownArrow && cursorY < 9)
                        {
                            cursorY++;
                        }

                        //Picking "x".
                        else if (cki.Key == ConsoleKey.Z && jumpController == 0)
                        {
                            if (gameTable[cursorY - 2][cursorX - 2].Equals('x'))
                            {
                                zPressedcursorX = cursorX;
                                zPressedCursorY = cursorY;
                                placingActivated = true;
                            }
                        }

                        //Replacing "x" to where player wants.
                        else if (cki.Key == ConsoleKey.X)
                        {
                            //Step operation for human.
                            if (jumpController == 0 && placingActivated == true && gameTable[cursorY - 2][cursorX - 2].Equals('.') && (Math.Abs(zPressedCursorY - cursorY)) <= 1 && (Math.Abs(zPressedcursorX - cursorX)) <= 1)
                            {
                                if ((Math.Abs(zPressedCursorY - cursorY)) == 1 && (Math.Abs(zPressedcursorX - cursorX)) == 1)
                                    continue;
                                gameTable[cursorY - 2][cursorX - 2] = 'x';
                                gameTable[zPressedCursorY - 2][zPressedcursorX - 2] = '.';
                                placingActivated = false;
                                humanTurn = false;
                            }

                            //Jump operation for human.
                            else if (placingActivated == true && gameTable[cursorY - 2][cursorX - 2].Equals('.'))
                            {
                                if (zPressedCursorY - cursorY == 2 && (gameTable[zPressedCursorY - 3][zPressedcursorX - 2].Equals('x') || gameTable[zPressedCursorY - 3][zPressedcursorX - 2].Equals('o')))
                                {
                                    gameTable[cursorY - 2][cursorX - 2] = 'x';
                                    gameTable[zPressedCursorY - 2][zPressedcursorX - 2] = '.';
                                    jumpController = 1;
                                    zPressedcursorX = cursorX;
                                    zPressedCursorY = cursorY;
                                }
                                else if (zPressedCursorY - cursorY == -2 && (gameTable[zPressedCursorY - 1][zPressedcursorX - 2].Equals('x') || gameTable[zPressedCursorY - 1][zPressedcursorX - 2].Equals('o')))
                                {
                                    gameTable[cursorY - 2][cursorX - 2] = 'x';
                                    gameTable[zPressedCursorY - 2][zPressedcursorX - 2] = '.';
                                    jumpController = 1;
                                    zPressedcursorX = cursorX;
                                    zPressedCursorY = cursorY;
                                }
                                else if (zPressedcursorX - cursorX == 2 && (gameTable[zPressedCursorY - 2][zPressedcursorX - 3].Equals('x') || gameTable[zPressedCursorY - 2][zPressedcursorX - 3].Equals('o')))
                                {
                                    gameTable[cursorY - 2][cursorX - 2] = 'x';
                                    gameTable[zPressedCursorY - 2][zPressedcursorX - 2] = '.';
                                    jumpController = 1;
                                    zPressedcursorX = cursorX;
                                    zPressedCursorY = cursorY;
                                }
                                else if (zPressedcursorX - cursorX == -2 && (gameTable[zPressedCursorY - 2][zPressedcursorX - 1].Equals('x') || gameTable[zPressedCursorY - 2][zPressedcursorX - 1].Equals('o')))
                                {
                                    gameTable[cursorY - 2][cursorX - 2] = 'x';
                                    gameTable[zPressedCursorY - 2][zPressedcursorX - 2] = '.';
                                    jumpController = 1;
                                    zPressedcursorX = cursorX;
                                    zPressedCursorY = cursorY;
                                }
                            }


                        }
                        //Finishing jump.
                        else if (cki.Key == ConsoleKey.C && placingActivated == true && jumpController == 1)
                        {
                            placingActivated = false;
                            humanTurn = false;
                            jumpController = 0;
                        }
                    }
                    Console.SetCursorPosition(cursorX, cursorY);
                    Thread.Sleep(50);
                    if (humanTurn == false)
                    {
                        //Checking if player wins or not.
                        win = winCheck(gameTable);
                        
                        if (win == 1 || win == 2)
                        {
                            String winner = "HUMAN";
                            if (win == 2)
                                winner = "COMPUTER";
                            
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
                            Console.WriteLine("┼┼┼┼┼┼  WINNER IS : " + winner + " ┼┼┼┼┼┼┼┼┼┼");
                            break;
                        }
                       

                        //If the player didn't win, it's the computer's turn.
                        else if (win == 0)
                        {
                            computerTurn(gameTable);
                            roundCounter++;
                            formTheGameTable(gameTable);
                            humanTurn = true;
                            Thread.Sleep(1000);
                        }
                    }
                }

                //Printing game table function.
                void formTheGameTable(char[][] gameTable)
                {

                    for (short i = 0; i < 8; i++)
                    {
                        Console.SetCursorPosition(2, i + 2);
                        for (short j = 0; j < 8; j++)
                            Console.Write(gameTable[i][j]);
                    }
                    Console.SetCursorPosition(13, 2);
                    Console.Write("Round : " + roundCounter);
                    Console.SetCursorPosition(13, 3);
                    if (humanTurn)
                        Console.Write("Turn : x");
                    else
                        Console.Write("Turn : o");
                }
            }

            //Controller function for which side win the game .
            static short winCheck(char[][] gameTable)
            {
                // 0 No Win, 1 Human Wins, 2 Computer Wins

                bool winAppearedForX = true;
                bool winAppearedForO = true;
                for (short i = 0; i < 3; i++)
                {
                    for (short j = 0; j < 3; j++)
                    {
                        char unit = gameTable[i][j];
                        if (!unit.Equals('x'))
                            winAppearedForX = false;
                    }
                }
                for (short i = 5; i < 8; i++)
                {
                    for (short j = 5; j < 8; j++)
                    {
                        char unit = gameTable[i][j];
                        if (!unit.Equals('o'))
                            winAppearedForO = false;
                    }
                }
                if (winAppearedForX)
                    return 1;
                else if (winAppearedForO)
                    return 2;
                else
                    return 0;

            }

            //Function for when it's computer's turn.
            void computerTurn(char[][] gameTable)
            {
                //Holder array for "o"s which can do step operation.
                Random rand = new Random();
                short[][] possibleRandomIndices = new short[9][];
                short possibleRandomIndicesIndex = 0;
                //Holder array for "o"s which can do jump operation.
                short[][] possibleRandomIndicesJump = new short[9][];
                short possibleRandomIndicesIndexJump = 0;
                //Holder array for "o"s which can do successive jump operation.
                short[][] possibleRandomIndicesMoreJump = new short[9][];
                short possibleRandomIndicesIndexMoreJump = 0;

                //Counting "o" pieces for future usage.
                short oCounteri7 = 0;
                short oCounterj7 = 0;
                short oCounteri6 = 0;
                short oCounterj6 = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (gameTable[7][i].Equals('o'))
                        oCounteri7++;
                }
                for (int i = 0; i < 8; i++)
                {
                    if (gameTable[i][7].Equals('o'))
                        oCounterj7++;
                }
                for (int i = 0; i < 8; i++)
                {
                    if (gameTable[6][i].Equals('o'))
                        oCounteri6++;
                }
                for (int i = 0; i < 8; i++)
                {
                    if (gameTable[i][6].Equals('o'))
                        oCounterj6++;
                }

                //Holding "o" pieces - which are available - in appropriate arrays
                for (short i = 0; i < 8; i++)
                {
                    for (short j = 0; j < 8; j++)
                    {
                        char unit = gameTable[i][j];
                        if (unit.Equals('o'))
                        {
                            short temp_i = i;
                            short temp_j = j;
                            bool doesItExist = false;
                            bool doesItExist2 = false;
                            if (!((j == 7 && i == 7) || (j == 6 && i == 6) || (j == 7 && i == 6) || (j == 6 && i == 7)))
                            {
                                if (j >= 6)
                                {
                                    if (canJumpDown(i, j, gameTable, oCounteri7, oCounteri6))
                                    {
                                        temp_i += 2;
                                        if (canJumpDown(temp_i, j, gameTable, oCounteri7, oCounteri6))
                                        {
                                            possibleRandomIndicesMoreJump[possibleRandomIndicesIndexMoreJump] = new short[2] { i, j };
                                            possibleRandomIndicesIndexMoreJump++;
                                        }
                                        else
                                        {
                                            possibleRandomIndicesJump[possibleRandomIndicesIndexJump] = new short[2] { i, j };
                                            possibleRandomIndicesIndexJump++;
                                        }

                                    }
                                }
                                else if (i >= 6)
                                {
                                    if (canJumpRight(i, j, gameTable, oCounterj7, oCounterj6))
                                    {
                                        temp_j += 2;
                                        if (canJumpRight(i, temp_j, gameTable, oCounteri7, oCounteri6))
                                        {
                                            possibleRandomIndicesMoreJump[possibleRandomIndicesIndexMoreJump] = new short[2] { i, j };
                                            possibleRandomIndicesIndexMoreJump++;
                                        }
                                        else
                                        {
                                            possibleRandomIndicesJump[possibleRandomIndicesIndexJump] = new short[2] { i, j };
                                            possibleRandomIndicesIndexJump++;
                                        }
                                    }
                                }

                                else
                                {
                                    if (canJumpRight(i, j, gameTable, oCounterj7, oCounterj6))
                                    {
                                        temp_j += 2;
                                        if (canJumpRight(i, temp_j, gameTable, oCounteri7, oCounteri6) || canJumpDown(i, temp_j, gameTable, oCounteri7, oCounteri6))
                                        {
                                            possibleRandomIndicesMoreJump[possibleRandomIndicesIndexMoreJump] = new short[2] { i, j };
                                            doesItExist = true;
                                            possibleRandomIndicesIndexMoreJump++;
                                        }
                                        else
                                        {
                                            possibleRandomIndicesJump[possibleRandomIndicesIndexJump] = new short[2] { i, j };
                                            doesItExist2 = true;
                                            possibleRandomIndicesIndexJump++;
                                        }
                                    }
                                    if (canJumpDown(i, j, gameTable, oCounterj7, oCounterj6))
                                    {
                                        temp_i += 2;
                                        if (doesItExist == false)
                                        {
                                            if (canJumpRight(temp_i, j, gameTable, oCounteri7, oCounteri6) || canJumpDown(temp_i, j, gameTable, oCounteri7, oCounteri6))
                                            {
                                                possibleRandomIndicesMoreJump[possibleRandomIndicesIndexMoreJump] = new short[2] { i, j };
                                                possibleRandomIndicesIndexMoreJump++;
                                            }

                                        }
                                        else if (doesItExist2 == false)
                                        {
                                            possibleRandomIndicesJump[possibleRandomIndicesIndexJump] = new short[2] { i, j };
                                            possibleRandomIndicesIndexJump++;
                                        }
                                    }
                                }
                            }

                        }


                    }
                }
                short jumpSuccesfull = 0;
                //If some "o" piece can do jump operation.
                if (possibleRandomIndicesIndexJump != 0 || possibleRandomIndicesIndexMoreJump != 0)
                {
                    while (jumpSuccesfull == 0)
                    {
                        short[] randomOposition = new short[9];
                        //If any of "o" pieces can do successive jump operation, use pieces of pieces which can do successive jump operation holder array.
                        if (possibleRandomIndicesIndexMoreJump != 0)
                        {
                            short randJumpIndex = (short)rand.Next(possibleRandomIndicesIndexMoreJump);
                            randomOposition = possibleRandomIndicesMoreJump[randJumpIndex];
                        }
                        //If none of "o" pieces can do successive jump operation but some can do jump operation, use pieces of pieces which can do jump operation holder array.
                        else if (possibleRandomIndicesIndexJump != 0)
                        {
                            short randJumpIndex = (short)rand.Next(possibleRandomIndicesIndexJump);
                            randomOposition = possibleRandomIndicesJump[randJumpIndex];
                        }
                        short x_i = randomOposition[0];
                        short x_j = randomOposition[1];

                        //Boundary, can jump right, can jump down control.
                        while (!((x_i == 7 && x_j == 7) || (x_i == 6 && x_j == 6) || (x_i == 6 && x_j == 7) || (x_i == 7 && x_j == 6)) && (canJumpRight(x_i, x_j, gameTable, oCounterj7, oCounterj6) || canJumpDown(x_i, x_j, gameTable, oCounteri7, oCounteri6)))
                        {
                            //If it can jump just right direction, there is no need to check if it can jump down or not.
                            if (x_i >= 6)
                            {
                                if (canJumpRight(x_i, x_j, gameTable, oCounterj7, oCounterj6))
                                {
                                    jumpRight(x_i, x_j, gameTable);
                                    x_j += 2;
                                    jumpSuccesfull = 1;
                                }
                            }

                            //If it can jump just down direction, there is no need to check if it can jump right or not.
                            else if (x_j >= 6)
                            {
                                if (canJumpDown(x_i, x_j, gameTable, oCounteri7, oCounteri6))
                                {
                                    jumpDown(x_i, x_j, gameTable);
                                    x_i += 2;
                                    jumpSuccesfull = 1;
                                }
                            }

                            else
                            {
                                //If it can jump right or down, choosing which way to go randomly.
                                short downOrRight;
                                Random rand2 = new Random();
                                downOrRight = Convert.ToInt16(rand2.Next(1, 3));
                                switch (downOrRight)
                                {
                                    case 1:

                                        if (canJumpDown(x_i, x_j, gameTable, oCounteri7, oCounteri6))
                                        {
                                            jumpDown(x_i, x_j, gameTable);
                                            x_i += 2;
                                            jumpSuccesfull = 1;
                                        }


                                        break;
                                    case 2:

                                        if (canJumpRight(x_i, x_j, gameTable, oCounterj7, oCounterj6))
                                        {
                                            jumpRight(x_i, x_j, gameTable);
                                            x_j += 2;
                                            jumpSuccesfull = 1;
                                        }


                                        break;
                                }
                            }
                            //This part is for successive jump operation. As a reminder, we counted "o" pieces above but if it can do successive jump operation...
                            //... code is not able to go above and count again because of while loop that it is in.
                            if (x_i == 7)
                            {
                                oCounteri7++;
                            }
                            else if (x_i == 6)
                            {
                                oCounteri6++;
                            }
                            else if (x_j == 7)
                            {
                                oCounterj7++;
                            }
                            else if (x_j == 6)
                            {
                                oCounterj6++;
                            }
                        }








                    }
                }

                //Holding "o" pieces - which are available - in appropriate arrays.
                for (short i = 0; i < 8; i++)
                {
                    for (short j = 0; j < 8; j++)
                    {
                        char unit = gameTable[i][j];
                        if (unit.Equals('o'))
                        {
                            if (j != 7 || i != 7)
                            {
                                if (j == 7)
                                {
                                    if (canMoveDown(i, j, gameTable))
                                    {
                                        possibleRandomIndices[possibleRandomIndicesIndex] = new short[2] { i, j };
                                        possibleRandomIndicesIndex++;
                                    }
                                }
                                else if (i == 7)
                                {
                                    if (canMoveRight(i, j, gameTable))
                                    {
                                        possibleRandomIndices[possibleRandomIndicesIndex] = new short[2] { i, j };
                                        possibleRandomIndicesIndex++;
                                    }
                                }
                                else
                                {
                                    if (canMoveRight(i, j, gameTable) || canMoveDown(i, j, gameTable))
                                    {
                                        possibleRandomIndices[possibleRandomIndicesIndex] = new short[2] { i, j };
                                        possibleRandomIndicesIndex++;
                                    }
                                }
                            }

                        }


                    }
                }

                //Doing step operation.
                short moveSuccesfull = 0;
                if (jumpSuccesfull == 0)
                {
                    while (moveSuccesfull == 0)
                    {
                        short randMoveIndex = (short)rand.Next(possibleRandomIndicesIndex);
                        short[] randomOposition = possibleRandomIndices[randMoveIndex];
                        short x_i = randomOposition[0];
                        short x_j = randomOposition[1];

                        //If it can step right or left, choosing where to go randomly.
                        short downOrRight;
                        Random rand2 = new Random();
                        downOrRight = Convert.ToInt16(rand2.Next(1, 3));
                        switch (downOrRight)
                        {
                            case 1:
                                if (x_i != 7)
                                {
                                    if (canMoveDown(x_i, x_j, gameTable))
                                    {
                                        if (x_i == 6)
                                        {
                                            if (oCounteri7 < 3)
                                            {
                                                moveDown(x_i, x_j, gameTable);
                                                moveSuccesfull = 1;
                                            }
                                        }
                                        else if (x_i == 5)
                                        {
                                            if (oCounteri6 < 4 && oCounteri7 < 3)
                                            {
                                                moveDown(x_i, x_j, gameTable);
                                                moveSuccesfull = 1;
                                            }
                                            else if (oCounteri7 == 3 && oCounteri6 < 3)
                                            {

                                                moveDown(x_i, x_j, gameTable);
                                                moveSuccesfull = 1;

                                            }
                                        }
                                        else
                                        {
                                            moveDown(x_i, x_j, gameTable);
                                            moveSuccesfull = 1;
                                        }


                                    }
                                }

                                break;
                            case 2:
                                if (x_j != 7)
                                {
                                    if (canMoveRight(x_i, x_j, gameTable))
                                    {

                                        if (x_j == 6)
                                        {
                                            if (oCounterj7 < 3)
                                            {
                                                moveRight(x_i, x_j, gameTable);
                                                moveSuccesfull = 1;
                                            }
                                        }
                                        else if (x_j == 5)
                                        {
                                            if (oCounterj6 < 4 && oCounterj7 < 3)
                                            {
                                                moveRight(x_i, x_j, gameTable);
                                                moveSuccesfull = 1;
                                            }
                                            else if (oCounterj7 == 3 && oCounterj6 < 3)
                                            {

                                                moveRight(x_i, x_j, gameTable);
                                                moveSuccesfull = 1;

                                            }
                                        }
                                        else
                                        {
                                            moveRight(x_i, x_j, gameTable);
                                            moveSuccesfull = 1;
                                        }
                                    }
                                }

                                break;
                        }

                    }
                }
            }

            //Step right function.
            void moveRight(short iCoordinate, short jCoordinate, char[][] gameTable)
            {
                gameTable[iCoordinate][jCoordinate + 1] = 'o';
                gameTable[iCoordinate][jCoordinate] = '.';
            }
            //Step down function.
            void moveDown(short iCoordinate, short jCoordinate, char[][] gameTable)
            {
                gameTable[iCoordinate + 1][jCoordinate] = 'o';
                gameTable[iCoordinate][jCoordinate] = '.';
            }
            //This function tells if selected piece can move right or not by returning boolean values True or False. 
            bool canMoveRight(short iCoordinate, short jCoordinate, char[][] gameTable)
            {
                return gameTable[iCoordinate][jCoordinate + 1].Equals('.');
            }
            //This function tells if selected piece can move down or not by returning boolean values True or False. 
            bool canMoveDown(short iCoordinate, short jCoordinate, char[][] gameTable)
            {
                return gameTable[iCoordinate + 1][jCoordinate].Equals('.');
            }

            //Jump right function.
            void jumpRight(short iCoordinate, short jCoordinate, char[][] gameTable)
            {
                gameTable[iCoordinate][jCoordinate + 2] = 'o';
                gameTable[iCoordinate][jCoordinate] = '.';
            }
            //Jump down function.
            void jumpDown(short iCoordinate, short jCoordinate, char[][] gameTable)
            {
                gameTable[iCoordinate + 2][jCoordinate] = 'o';
                gameTable[iCoordinate][jCoordinate] = '.';
            }
            //This function tells if selected piece can jump right or not by returning boolean values True or False. 
            bool canJumpRight(short iCoordinate, short jCoordinate, char[][] gameTable, short j7, short j6)
            {
                if ((jCoordinate < 6) && (gameTable[iCoordinate][jCoordinate + 1].Equals('x') || gameTable[iCoordinate][jCoordinate + 1].Equals('o')) && gameTable[iCoordinate][jCoordinate + 2].Equals('.'))
                {
                    if (jCoordinate == 4)
                    {
                        if (j6 < 4 && j7 < 3)
                        {
                            return true;
                        }
                        else if (j7 == 3 && j6 < 3)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }


                    else if (jCoordinate == 5)
                    {

                        if (j7 < 3 && j6 < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                    else
                    {

                        return true;

                    }
                }
                else
                {
                    return false;
                }
            }
            //This function tells if selected piece can jump down or not by returning boolean values True or False. 
            bool canJumpDown(short iCoordinate, short jCoordinate, char[][] gameTable, short i7, short i6)
            {
                if ((iCoordinate < 6) && (gameTable[iCoordinate + 1][jCoordinate].Equals('x') || gameTable[iCoordinate + 1][jCoordinate].Equals('o')) && gameTable[iCoordinate + 2][jCoordinate].Equals('.'))
                {
                    if (iCoordinate == 4)
                    {
                        if (i6 < 4 && i7 < 3)
                        {
                            return true;
                        }
                        else if (i7 == 3 && i6 < 3)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }


                    else if (iCoordinate == 5)
                    {

                        if (i7 < 3 && i6 < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                    else
                    {

                        return true;

                    }
                }
                else
                {
                    return false;
                }

            }

            gameExe(gameTable);


        }
    }
}