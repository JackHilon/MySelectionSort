using System;

namespace MySelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter counter: ");
            var counter = EnterCounter();

            int[] myArray = new int[counter];

            int[] mySelection = new int[counter];

            string str;

            while (true)
            {
                StartMessage();
                str = Console.ReadLine();

                switch (str)
                {
                    case "0":
                        break;
                    case "1":
                        myArray = WorstArray(counter);
                        break;
                    case "2":
                        myArray = BestArray(counter);
                        break;
                    case "3":
                        myArray = NinesArray(counter);
                        break;
                    case "4":
                        Console.WriteLine("Please enter your array step-by-step");
                        myArray = EnterIntArray(counter);
                        break;
                    default:
                        continue;
                } // -- end of switch
                break;
            } // -- end of while loop

            Console.Write("Your array is.............: ");
            PrintArrayOneLine(myArray);

            Console.WriteLine(" ");
            mySelection = SelectionSort2(myArray);

            Console.Write("Selection sort result is..: ");
            PrintArrayOneLine(mySelection);
        }
        //
        private static int[] SelectionSort(int[] array) // n = nSwaps only
        {
            int[] arr = CopyArray(array);
            int n = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                n = n + BigSwap(arr, i);
            }
            Console.WriteLine($"Number of real swaps in Selection sort (Array-Length = {arr.Length}) = {n}");
            return arr;
        }
        private static int BigSwap(int[] array, int indx)
        {
            int maxIndx = IndexOfMax(array, indx);
            if (maxIndx != indx)
            {
                int temp = array[indx];
                array[indx] = array[maxIndx];
                array[maxIndx] = temp;
                return 1;
            }
            else return 0;
        }
        private static int IndexOfMax(int[] array, int limit)
        {
            int indx = array.Length; // illegal value!
            int max = int.MinValue;
            for (int i = limit; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    indx = i;
                }
            }
            return indx;
        }
        // =========================================================================================
        private static int[] SelectionSort2(int[] array) // (nSwaps + mComparasions)
        {
            int[] arr = CopyArray(array);
            int nSwaps = 0;
            int mComparasions = 0;
            int[] first = new int[2];
            for (int i = 0; i < arr.Length; i++)
            {
                first = BigSwap2(arr, i);
                nSwaps = nSwaps + first[0];
                mComparasions = mComparasions + first[1];
            }
            Console.WriteLine($"Number of real swaps in Selection sort (Array-Length = {arr.Length}) ...: {nSwaps}");
            Console.WriteLine($"Number of comparasions in Selection sort (Array-Length = {arr.Length}) .: {mComparasions}");
            return arr;
        }
        private static int[] BigSwap2(int[] array, int indx)
        {
            int[] maxArr= IndexOfMax2(array, indx);
            int maxIndx = maxArr[0];
            if (maxIndx != indx)
            {
                int temp = array[indx];
                array[indx] = array[maxIndx];
                array[maxIndx] = temp;
                return MakeArray2(1, maxArr[1]);
            }
            return MakeArray2(0, maxArr[1]);
        }
        private static int[] IndexOfMax2(int[] array, int limit)
        {
            int m = 0;
            int indx = array.Length; // illegal value!
            int max = int.MinValue;
            for (int i = limit; i < array.Length; i++)
            {
                m++;
                if (array[i] > max)
                {
                    max = array[i];
                    indx = i;
                }
            }
            return MakeArray2(indx, m);
        }
        private static int[] MakeArray2(int a, int b)
        {
            int[] res = new int[2];
            res[0] = a;
            res[1] = b;
            return res;
        }
        // *****************************************************************************************
        private static int[] EnterIntArray(int leng)
        {
            int[] res = new int[leng];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = EnterCounter();
            }
            return res;
        }
        private static int EnterCounter()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 20)
                    throw new ArgumentException();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a number 1 -> 20");
                return EnterCounter();
            }
            return a;
        }
        private static void PrintArrayOneLine(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine(" ");
        }
        private static int[] CopyArray(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
            return b;
        }
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static int[] WorstArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i + 1;
            }
            return a;
        }
        private static int[] BestArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = n - i;
            }
            return a;
        }
        private static int[] NinesArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 9;
            }
            return a;
        }
        private static void StartMessage()
        {
            Console.WriteLine(" ");
            Console.WriteLine("(0).....................Exit");
            Console.WriteLine("(1).....................Wrost array (unordered array) is entered");
            Console.WriteLine("(2).....................Best array (ordered array) is entered");
            Console.WriteLine("(3).....................All items are equal 9 in the array!");
            Console.WriteLine("(4).....................Enter your own array");
            Console.WriteLine("any other key...........Stay here!");
            Console.WriteLine(" ");
        }
    }
}