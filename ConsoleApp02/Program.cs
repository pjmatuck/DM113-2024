using System.Collections;

namespace ConsoleApp02;

class Program
{
    static void Main(string[] args)
    {
        Test test = new Test();
        test.Run();     
    }
}

class Test {

    public async void Run()
    {
        await SearchItems();
    }

    Task SearchItems()
    {
        Console.WriteLine("Task 1");
        Console.WriteLine("Task 2");
        Console.WriteLine("Task 3");

        return Task.Run( () => Console.WriteLine("Item found."));
    }
}

public class MyEnumerator : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
