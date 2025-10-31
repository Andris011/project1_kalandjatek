namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        List<List<int>> matrix = 
        [
            [1,2,3,4,5,6], 
            [7,8,9,10,11]
        ];
        
        var ertek = matrix[0][2];

        Console.WriteLine(ertek);
    }
}