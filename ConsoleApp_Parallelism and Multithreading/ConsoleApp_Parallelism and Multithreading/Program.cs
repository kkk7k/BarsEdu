using ConsoleApp_Parallelism_and_Multithreading;



Console.WriteLine("Приложение запущено");
string? mes = null;

while (mes != "/exit")
{
    Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
    mes = Console.ReadLine();
    if (mes == "/exit")
        break;
    Console.WriteLine($"Будет послано сообщение '{mes}'");
    
    
    var argusList = new List<string>();
    Console.WriteLine("Введите аргументы сообщения. Если аргумент не нужны - введите /end");
    string newArg = Console.ReadLine();

    while (newArg != "/end")
    {
        argusList.Add(newArg);
        Console.WriteLine("Введите следующий аргумент сообщения. Для окончания добавления аргуметнов введите /end");
        newArg = Console.ReadLine();

    }
    string[] argusArray = argusList.ToArray();
    

    var thread = new Thread(MethodRequest);
    thread.Start();

    void MethodRequest()
    {
        var gui = Guid.NewGuid();
        try
        {
            Console.WriteLine($"Было отправлено сообщение '{mes}'. Присвоен идентификатор {gui}");
            DummyRequestHandler request = new DummyRequestHandler();
            string res = request.HandleRequest(mes, argusArray);
            Console.WriteLine($"Сообщение с идентификатором '{gui}'получило ответ - {res}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сообщение с идентификатором '{gui}' упало с ошибкой:{ex.Message}");
        }
    }
}
Console.WriteLine("Приложение завершает работу.");

