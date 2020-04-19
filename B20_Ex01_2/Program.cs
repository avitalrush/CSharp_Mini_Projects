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

            ///////// VERSION 1: 1 return call /////////

            if (i_CurrentNumOfStars > i_OriginNumOfStars)
            {
                return;
            }

            printSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);    // PRINT LINE OF SPACES AND STARS

            // PREPARE THE PARAMETERS FOR THE NEXT REC CALL

            if (i_CurrentNumOfStars == 1)
            {
                i_CurrentNumOfStars += 2;
                i_IsAscending = true;
            }
            else
            {
                if(!i_IsAscending)
                {
                    i_CurrentNumOfStars -= 2;
                }
                else
                {
                    i_CurrentNumOfStars += 2;
                }
            }

            printStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars, i_IsAscending);    // REC CALL

            /*

            ///////// VERSION 2: 2 return calls && repetitive checking if i_CurrentNumOfStars == i_OriginNumOfStars  /////////

            printSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);    // PRINT LINE OF SPACES AND STARS

            // PREPARE THE PARAMETERS FOR THE NEXT REC CALL
                if (i_CurrentNumOfStars == 1)
            {
                if(i_OriginNumOfStars == 1)
                {
                    return;
                }
                else
                {
                    i_IsAscending = true;
                    i_CurrentNumOfStars += 2;
                }
            }
            else if (i_CurrentNumOfStars == i_OriginNumOfStars && i_IsAscending)
            {
                return;
            }
            else
            {
                if (i_IsAscending)
                {
                    i_CurrentNumOfStars += 2;
                }
                else
                {
                    i_CurrentNumOfStars -= 2;
                }
            }
            printStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars, i_IsAscending);    // REC CALL

            */
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