using System;

public class MedianFinder
{
    // Массив для хранения чисел
    private int[] numbers;
    // Количество добавленных чисел
    private int count;     

    // Конструктор
    public MedianFinder()
    {
        // Максимальный размер массива
        numbers = new int[100];
        // Изначально пустой массив
        count = 0;              
    }

    // Добавляет число в массив
    public void AddNum(int num)
    {
        numbers[count] = num; 
        count++;              
        // любимый пузырек
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
    }

    // Вычисляет медиану
    public double FindMedian()
    {
        // Если чисел нет, возвращаем 0
        if (count == 0)
        {
            return 0;
        }
        // если колво чисел нечетное то медиана центральное число
        if (count % 2 == 1)
        {

            return numbers[count / 2];
        }
        // если колво чисел четное то медиана - это среднее двух центральных чисел
        else
        {
            
            return (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Создаем объект MedianFinder
        MedianFinder medianFinder = new MedianFinder();

        // выводим менюшку
        Console.WriteLine("Введите числа для добавления в список.");
        Console.WriteLine("После каждого числа нажимайте Enter.");
        Console.WriteLine("Когда хотите вычислить медиану, введите 'findMedian'.");
        Console.WriteLine("Чтобы завершить, введите 'exit'.");
        // цикл для беспрерывного ввода новых чисел в массив
        while (true)
        {
            // Чтение ввода пользователя
            string input = Console.ReadLine().Trim();

            // Если ввели 'exit', завершаем программу
            if (input.ToLower() == "exit")
            {
                break;
            }

            // Если ввели findMedian - вычисляем и показываем медиану
            if (input.ToLower() == "findmedian")
            {
                double median = medianFinder.FindMedian();
                Console.WriteLine($"Медиана: {median}");
            }
            else
            {
                // Пытаемся преобразовать ввод в число
                int num;
                bool isNumber = int.TryParse(input, out num);

                if (isNumber)
                {
                    // Если это число - добавляем его в список
                    medianFinder.AddNum(num);
                    Console.WriteLine($"Число {num} добавлено.");
                }
                else
                {
                    // Если не число и не команда выводим ошибку
                    Console.WriteLine("Пожалуйста, введите число или команду.");
                }
            }
        }
    }
}
