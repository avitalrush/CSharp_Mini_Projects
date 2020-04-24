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

            // VERSION WITH NO EXPLICIT RETURN CALL, ONLY 1 RETURN CALL AT THE END OF VOID METHOD:

            if (i_CurrentNumOfStars <= i_OriginNumOfStars)
            {
                PrintSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);    // PRINT LINE OF SPACES AND STARS

                // PREPARE THE PARAMETERS FOR THE NEXT REC CALL

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

                PrintStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars, i_IsAscending);    // REC CALL
            }

            /*
            // VERSION WITH 1 EXPLICIT RETURN CALL + 1 RETURN CALL AT THE END OF VOID METHOD:

            if (i_CurrentNumOfStars > i_OriginNumOfStars)
            {
                return;
            }

            PrintSpacesStars(numOfSpacesToPrint, numOfStarsToPrint);    // PRINT LINE OF SPACES AND STARS

            // PREPARE THE PARAMETERS FOR THE NEXT REC CALL

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

            PrintStarsHourglassRec(i_OriginNumOfStars, i_CurrentNumOfStars, i_IsAscending);    // REC CALL
            */
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
