using System;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintStarsHourglass(5);    
        }

        public static void PrintStarsHourglass(int i_OriginNumOfStars)
        {
            bool isAscending = false;

            PrintStarsHourglassRec(i_OriginNumOfStars, i_OriginNumOfStars, isAscending);
        }

        public static void PrintStarsHourglassRec(int i_OriginNumOfStars, int i_CurrentNumOfStars, bool i_IsAscending)
        {
            int numOfSpacesToPrint = (i_OriginNumOfStars - i_CurrentNumOfStars) / 2;
            int numOfStarsToPrint = i_CurrentNumOfStars;

            if (i_CurrentNumOfStars == 1)
            {
                PrintSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);
                i_IsAscending = true;
                PrintStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars + 2, i_IsAscending);    // REC CALL
            }
            else if(i_CurrentNumOfStars == i_OriginNumOfStars && i_IsAscending)
            {
                PrintSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);
                return;
            }
            else
            {
                PrintSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);

                if (i_IsAscending)
                {
                    PrintStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars + 2, i_IsAscending);    // REC CALL
                }
                else
                {
                    PrintStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars - 2, i_IsAscending); // REC CALL
                }
            }
        }

        public static void PrintSpacesStars(int i_NumOfSpaces, int i_NumOfStars)
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