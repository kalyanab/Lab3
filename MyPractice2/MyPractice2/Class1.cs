namespace MyPractice3
{
    class SDArray1
    {
        static void Main()
        {
            Console.Clear();
            int x = 0;
            int[] arr = new int[6];

            //Accessing values of a SD Array by using for loop
            for (int i = 0; i < 6; i++)
                Console.Write(arr[i] + "  ");
            Console.WriteLine();

            //Assigning values of a SD Array by using for loop
            for (int i = 0; i < 6; i++)
            {
                x += 10;
                arr[i] = x;
            }

            //Accessing values of a SD Array by using foreach loop
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
