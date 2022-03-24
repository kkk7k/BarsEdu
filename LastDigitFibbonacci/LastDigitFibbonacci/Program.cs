Console.WriteLine("Программа для вычисления последний цифры n-го числа Фибоначчи");
Console.WriteLine("Выход из программы клавиша Q\n");

ProgramStart();

void ProgramStart()
{
    Console.WriteLine("Для запуска программы нажмите на любую клавишу");
    char symStart = Console.ReadKey().KeyChar;
    if (symStart != 'q')
    {
        while (true)
        {
            char symContinue = Console.ReadKey().KeyChar;
            if (symContinue == 'q')
            {
                return;
            }
            else
            {
                int nEnter = EnterNumb();
                int result = (int)FibDigit(nEnter);

                Console.WriteLine($"Последняя цифра {nEnter}-го числа Фибоначчи: { result}\n");
                Console.WriteLine("Выход из программы клавиша Q");
            }
        }
    }
    else return;
}

int EnterNumb()
{
    Console.Write("\n\nВведите число:");
    while (true)
    {
        int intValue;
        if (int.TryParse(Console.ReadLine(), out intValue))
        {
            return intValue;
        }
        else
        {
            Console.WriteLine("Недопустимое значение");
            continue;
        }
    }
}

long FibDigit(int n) // Определение последний цифры n-ого числа Фиббонначи благодаря периоду Пизано
{
    long[] num60=new long[60];
    num60[1] = 1;

    for(long i=1; i<59; i++)
    {
        num60[i+1] = num60[i]+num60[i-1];
    }
    int m = n / 60;
    int ind = n - (m * 60);

    return num60[ind]%10;
}