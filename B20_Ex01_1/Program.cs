namespace B20_Ex01_1
{
    public class Program
    {
        static void Main()
        {

        }
        static int convertFromBinaryToDecimal(string i_stringInput)
        {
            int m_decimalNum = 0;
            for (int i = 0; i <= (i_stringInput.Length) - 1; i++)
            {
                m_decimalNum *= 2;
                m_decimalNum += (int)(i_stringInput[i] - '0');
            }
            return m_decimalNum;
        }
    }
}
