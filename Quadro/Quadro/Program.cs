using System;
using System.IO;

namespace GOS
{
    internal class Program
    {
        private static void Main(string[] args) => Mas_Met();

        private static int Get_Num()
        {
            Console.WriteLine("Input your number here 'N' \n\nValue must be positive and integer!\nThe value must be within '2 < N < 100'");
            try
            {
                int int32 = Convert.ToInt32(Console.ReadLine());
                return int32 >= 2 && int32 <= 100 ? int32 : throw new Exception("The value is not within '2 < N < 100");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }

        private static void Mas_Met()
        {
            int num = Get_Num();
            if (num <= 0)
                return;
            Console.WriteLine("\n\n\nResult:\n");
            int[,] array = new int[num, num];
            int val = 1;
            for (int i = 0; i < num; ++i)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < num; ++j)
                    {
                        array[i, j] = val;
                        ++val;
                    }
                }
                else
                {
                    for (int j = num - 1; j >= 0; --j)
                    {
                        array[i, j] = val;
                        ++val ;
                    }
                }
            }
            for (int i = 0; i < num; ++i)
            {
                for (int j = 0; j < num; ++j)
                    Console.Write(array[i, j].ToString() + " ");
                Console.Write("\n");
            }
            Console.Write("\n\n");
            Program.FileWrite(array, num);
            Program.Mas_Met();
        }

        private static void FileWrite(int[,] array, int n)
        {
            using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\Igor\\Desktop\\serpent.out.txt", false))
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                        streamWriter.Write(string.Format(Convert.ToString(array[i, j].ToString() + " ")));
                    streamWriter.WriteLine(string.Format(Convert.ToString("\n")));
                }
            }
        }
    }
}