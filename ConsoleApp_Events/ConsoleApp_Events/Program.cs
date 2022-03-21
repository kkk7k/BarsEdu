// See https://aka.ms/new-console-template for more information


Key key = new Key();
key.OnKeyPressed += PrintChar;
key.Run();

void PrintChar(object o, char ch)
{
    Console.WriteLine("\nEntered character: "+ch+"\n");
}
    
class Key
{
    public event EventHandler<char>? OnKeyPressed;
    public void Run()
    {
        while (true)
        {
            Console.Write("Enter a character: ");
            char sim = Console.ReadKey().KeyChar;
            if (sim != 'c')
            {
                OnKeyPressed?.Invoke(this, sim);
            }
            else
            {
                Console.WriteLine("\nShut down");
                break;
            }
        }
    }
}
