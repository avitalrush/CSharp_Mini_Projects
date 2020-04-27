using System;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintHourglass(5);
        }

        public static void PrintHourglass(int i_OriginalNumOfStars)
        {
            bool ascending = true;

            PrintHourglassRec(i_OriginalNumOfStars, i_OriginalNumOfStars, !ascending);
        }

        public static void PrintHourglassRec(int i_OriginalNumOfStars, int i_CurrentNumOfStars, bool i_Ascending)
        {
            int numOfSpacesToPrint = (i_OriginalNumOfStars - i_CurrentNumOfStars) / 2;
            int numOfStarsToPrint = i_CurrentNumOfStars;

            if (i_CurrentNumOfStars <= i_OriginalNumOfStars)
            {
                PrintSpacesAndStars(numOfSpacesToPrint, numOfStarsToPrint);
                if (i_CurrentNumOfStars == 1)
                {
                    i_CurrentNumOfStars += 2;
                    i_Ascending = true;
                }
                else
                {
                    if (!i_Ascending)
                    {
                        i_CurrentNumOfStars -= 2;
                    }
                    else
                    {
                        i_CurrentNumOfStars += 2;
                    }
                }

                PrintHourglassRec(i_OriginalNumOfStars, i_CurrentNumOfStars, i_Ascending);
            }
        }

        public static void PrintSpacesAndStars(int i_NumOfSpaces, int i_NumOfStars)
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
