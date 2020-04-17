using System;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            printStarsHourglass(5);    
        }

        private static void printStarsHourglass(int i_OriginNumOfStars)
        {
            bool isAscending = false;

            printStarsHourglassRec(i_OriginNumOfStars, i_OriginNumOfStars, isAscending);
        }

        private static void printStarsHourglassRec(int i_OriginNumOfStars, int i_CurrentNumOfStars, bool i_IsAscending)
        {
            int numOfSpacesToPrint = (i_OriginNumOfStars - i_CurrentNumOfStars) / 2;
            int numOfStarsToPrint = i_CurrentNumOfStars;

            if (i_CurrentNumOfStars == 1)
            {
                printSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);
                i_IsAscending = true;
                printStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars + 2, i_IsAscending);    // REC CALL
            }
            else if(i_CurrentNumOfStars == i_OriginNumOfStars && i_IsAscending)
            {
                printSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);
                return;
            }
            else
            {
                printSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);

                if (i_IsAscending)
                {
                    printStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars + 2, i_IsAscending);    // REC CALL
                }
                else
                    printStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars - 2, i_IsAscending);    // REC CALL
            }
        }

        private static void printSpacesStars(int i_NumOfSpaces, int i_NumOfStars)
        {
            System.Text.StringBuilder lineToPrint = new System.Text.StringBuilder();

            for (int i = 0; i < i_NumOfSpaces; i++)
            {
                lineToPrint.Append(' ');
            }

            for (int i = 0; i < i_NumOfStars; i++)
            {
                lineToPrint.Append('*');
            }

            Console.WriteLine(lineToPrint);
        }
    }
}