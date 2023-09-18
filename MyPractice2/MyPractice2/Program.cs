namespace MyPractice2
{
    class Table
    {
        static void Main()
        {

            Console.Write("Enter an un-signed integer value: ");
            bool Status = uint.TryParse(Console.ReadLine(), out uint x);

            if (Status == false)
            {
                Console.WriteLine("Please enter un-signed integer's only.");
                return;
            }
            if (x == 0 || x == 1)
            {
                Console.WriteLine("Please enter a number greater than 1.");
                return;
            }

            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{x} * {i} = {x * i}");
            }
        } 

    }
}