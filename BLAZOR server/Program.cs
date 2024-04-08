class Program
{
    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("~~~~~ Выберите режим ~~~~~:\n1. Калькулятор\n2. Список дел\n3. Выход");
            int mode = Convert.ToInt32(Console.ReadLine());

            if (mode == 1)
            {
                Console.WriteLine("Введите первое число:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите второе число:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Выберите операцию (+, -, *, /):");
                char operation = Convert.ToChar(Console.ReadLine());

                double result = 0;

                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("Деление на ноль недопустимо");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Неправильная операция");
                        return;
                }

                Console.WriteLine("Результат операции: " + result);
            }
            else if (mode == 2)
            {
                List<string> toDoList = new List<string>();

                await FillToDoListAsync(toDoList);

                Console.WriteLine("~~~~ Список дел: ~~~~");
                foreach (var task in toDoList)
                {
                    Console.WriteLine(task);
                }
            }
            else if (mode == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Неправильный режим, попробуйте снова.");
            }
        }
    }

    static async Task FillToDoListAsync(List<string> toDoList)
    {
        Console.WriteLine("Заполнение списка дел. Введите новое дело (или 'exit' для выхода):");

        while (true)
        {
            Console.WriteLine("Введите новое дело ('exit' - для выхода; 'list' - для вывода списка дел):");
            string newTask = Console.ReadLine();

            if (newTask.ToLower() == "exit")
            {
                break;
            }
            else if (newTask.ToLower() == "list")
            {
                Console.WriteLine(" ~~~~Список дел:~~~~ ");
                foreach (var task in toDoList)
                {
                    Console.WriteLine(task);
                }
            }
            else
            {
                toDoList.Add(newTask);
                Console.WriteLine("Дело успешно добавлено в список!");
            }
        }
        await Task.CompletedTask;
    }
}
