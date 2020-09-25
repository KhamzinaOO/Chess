using System;

namespace chess
{
    class Program
    {
        /*static int ChangeLetter (string str)
        {
            char a = str[0];
            int numericCoord = ((int)a) - 64; // for capital
            if (!(numericCoord >= 1 && numericCoord <= 26)) { 
                numericCoord = ((int)a) - 96; // for small
                if (!(numericCoord >= 1 && numericCoord <= 26)) {

                    Console.WriteLine("Таких координат нет на шахматной доске");
                }
            }
            return numericCoord;
        } */

        static int ChangeLetter(string str)
        {
            int numericCoord = str[0] - 64;
            if (!(numericCoord >= 1 && numericCoord <= 26))
            {
                numericCoord = str[0] - 96;
            }
            return numericCoord;
        }
        static bool KnightF(int firstLine, int secondLine, int firstColumn, int secondColumn)
        {
            return ((Math.Abs(firstLine - secondLine) == 2
                && Math.Abs(firstColumn - secondColumn) == 1)
                || (Math.Abs(firstLine - secondLine) == 1
                && Math.Abs(firstColumn - secondColumn) == 2));
        }

        static bool PawnF(int firstLine, int secondLine, int firstColumn, int secondColumn)
        {
            return ((firstColumn == secondColumn) 
                && ((firstLine == 2 && (secondLine - firstLine == 2 || secondLine - firstLine == 1)) 
                || (secondLine - firstLine == 1)));
        }

        static bool BishopF(int firstLine, int secondLine, int firstColumn, int secondColumn)
        {
            return Math.Abs(firstColumn - secondColumn) == Math.Abs(firstLine - secondLine);
        }

        static bool RookF(int firstLine, int secondLine, int firstColumn, int secondColumn)
        {
            return (firstColumn == secondColumn && firstLine != secondLine)
            || (firstLine == secondLine && firstColumn != secondColumn);
        }

        static bool QueenF(int firstLine, int secondLine, int firstColumn, int secondColumn)
        {
            return (Math.Abs(firstColumn - secondColumn) == Math.Abs(firstLine - secondLine)) 
                || ((firstColumn == secondColumn && firstLine != secondLine) 
                || (firstLine == secondLine && firstColumn != secondColumn));
        }

        static bool KingF(int firstLine, int secondLine, int firstColumn, int secondColumn)
        {
            return ((secondLine == firstLine - 1 && secondColumn == firstColumn - 1)
                || (secondLine == firstLine - 1 && secondColumn == firstColumn)
                || (secondLine == firstLine - 1 && secondColumn == firstColumn + 1)
                || (secondLine == firstLine && secondColumn == firstColumn - 1)
                || (secondLine == firstLine && secondColumn == firstColumn + 1)
                || (secondLine == firstLine + 1 && secondColumn == firstColumn - 1)
                || (secondLine == firstLine + 1 && secondColumn == firstColumn)
                || (secondLine == firstLine + 1 && secondColumn == firstColumn + 1));
        }

        static (int, int, int, int) readInput()
        {
            Console.WriteLine("Пожалуйста, используйте только латинские буквы A-H и цифры 1-8");
            Console.WriteLine("Введите начальные координаты фигуры:");
            string x = Console.ReadLine();
            Console.WriteLine("Введите конечные координаты фигуры:");
            string y = Console.ReadLine();
            int firstLine = int.Parse(x.Substring(1));
            int secondLine = int.Parse(y.Substring(1));
            var firstColumn = ChangeLetter(x.Substring(0, 1));
            var secondColumn = ChangeLetter(y.Substring(0, 1));
            return (firstColumn, secondColumn, firstLine, secondLine);
        }

        static void Main(string[] args)
        {
            (int firstColumn, int secondColumn, int firstLine, int secondLine) = readInput();
            if (firstLine < 1 || firstLine > 8 || firstColumn < 1 || firstColumn > 8)
            {
                Console.WriteLine("Таких координат нет на шахматной доске");
                (firstColumn, secondColumn, firstLine, secondLine) = readInput();
            }

            //Console.WriteLine(firstLine + " " + secondLine + " " + firstColumn + " " + secondColumn);

            var resultRook = RookF(firstLine, secondLine, firstColumn, secondColumn);
            var resultKnight = KnightF(firstLine, secondLine, firstColumn, secondColumn);
            var resultBishop = BishopF(firstLine, secondLine, firstColumn, secondColumn);
            var resultQueen = QueenF(firstLine, secondLine, firstColumn, secondColumn);
            var resultKing = KingF(firstLine, secondLine, firstColumn, secondColumn);
            var resultPawn = PawnF(firstLine, secondLine, firstColumn, secondColumn);

            Console.WriteLine("Ладья: " + (resultRook ? "Верно" : "Неверно"));
            Console.WriteLine("Конь: " + (resultKnight ? "Верно" : "Неверно"));
            Console.WriteLine("Слон: " + (resultBishop ? "Верно" : "Неверно"));
            Console.WriteLine("Ферзь: " + (resultQueen ? "Верно" : "Неверно"));
            Console.WriteLine("Король: " + (resultKing ? "Верно" : "Неверно"));
            Console.WriteLine("Пешка: " + (resultPawn ? "Верно" : "Неверно"));

        }
    }
}