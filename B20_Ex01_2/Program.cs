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
            bool isAscending = false;   //const v_IsAscending = true

            PrintStarsHourglassRec(i_OriginNumOfStars, i_OriginNumOfStars, isAscending);    //!v_IsAscending 
        }

        public static void PrintStarsHourglassRec(int i_OriginNumOfStars, int i_CurrentNumOfStars, bool i_IsAscending)
        {
            int numOfSpacesToPrint = (i_OriginNumOfStars - i_CurrentNumOfStars) / 2;
            int numOfStarsToPrint = i_CurrentNumOfStars;

            if (i_CurrentNumOfStars <= i_OriginNumOfStars)
            {
                PrintSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);
                if (i_CurrentNumOfStars == 1)
                {
                    i_CurrentNumOfStars += 2;
                    i_IsAscending = true;
                }
                else
                {
                    if (!i_IsAscending)
                    {
                        i_CurrentNumOfStars -= 2;
                    }
                    else
                    {
                        i_CurrentNumOfStars += 2;
                    }
                }

                PrintStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars, i_IsAscending);
            }
        }

        public static void PrintSpacesStars(int i_NumOfSpaces, int i_NumOfStars)    //naming: PrintSpacesAndStars
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
