using System;

namespace HelloCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

            // numbers
            // integers
            int x = 5;
            long y = 5;
            short z = 5;

            double speed = 55.5;
            float accel = 143.43f;

            //  characters
            string name = "devon";
            char d = 'd';
            char first = name[0];

            //bool
            bool isCool = true;
            bool isSame = name[0] == first;

            //collections
            int[] nums = new int[10];

          
            int[,] matrix = new int[10,5];
            matrix[1,0] = 5;

            int[] numbers = new int[]{1132,123,123,5,234,5234,523,1};


            int min = FindMin(numbers);

            Console.WriteLine("Hello World!");
        }
        static int FindMin(int[] nums)
        {
            // loop throuh array
            // define default "min" at onset
            int currMinumum = Int32.MaxValue;
            for(int i = 0; i<nums.Length; i++)
            {
                if(nums[i] < currMinumum)
                // make curr nums[i]
                    currMinumum = nums[i];
            }
            return currMinumum;
        }
    }
}