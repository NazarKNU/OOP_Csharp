using System;
public class Program
{
    static void Main()
    {
        int action = 0;
        IntegerNumber integerNumber = new IntegerNumber();
        RealNumber realNumber = new RealNumber();
        while (action != 9)
        {
            Console.WriteLine("1. Показати цiле число\n" +
                   "2. Змiнити цiле число\n" +
                   "3. Знайти суму цифр цiлого числа\n" +
                   "4. Знайти кiлькiсть нулiв у цiлому числi\n" +
                   "5. Показати дiйсне число\n" +
                   "6. Змiнити дiйсне число\n" +
                   "7. Знайти суму цифр дiйсного числа\n" +
                   "8. Знайти кiлькiсть нулiв у дiйсному числi\n" +
                   "9. Завершити роботу\n" +
                   "Оберiть дiю: ");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine("Цiле число: " + integerNumber.number);
                    break;
                case 2:
                    Console.WriteLine("Введiть цiле число:");
                    integerNumber.number = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Сума цифр цiлого числа: " + integerNumber.SumOfDigits());
                    break;
                case 4:
                    Console.WriteLine("Кiлькiсть нулiв у цiлому числi: " + integerNumber.CountZeros());
                    break;
                case 5:
                    Console.WriteLine("Дiйсне число: " + realNumber.number);
                    break;
                case 6:
                    Console.WriteLine("Введiть дiйсне число:");
                    realNumber.number = Convert.ToDouble(Console.ReadLine());
                    break;
                case 7:
                    Console.WriteLine("Сума цифр дiйсного числа: " + realNumber.SumOfDigits());
                    break;
                case 8:
                    Console.WriteLine("Кiлькiсть нулiв у дiйсному числi: " + realNumber.CountZeros());
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("\nТакої дiї не iснує, спробуйте ще раз\n");
                    break;
            }
        }
    }

    public interface ISumAndZeros
    {
        int SumOfDigits();
        int CountZeros();
    }
    public class IntegerNumber : ISumAndZeros
    {
        public IntegerNumber()
        {
            Random random = new Random();
            this.number = random.Next(0, 20000);
        }
        public int number;
        public int SumOfDigits()
        {
            int numberTemp = this.number;
            int sum = 0;
            while (numberTemp != 0)
            {
                sum += numberTemp % 10;
                numberTemp /= 10;
            }
            return sum;
        }

        public int CountZeros()
        {
            int numberTemp = this.number;
            int count = 0;
            while (numberTemp != 0)
            {
                if (numberTemp % 10 == 0) count++;
                numberTemp /= 10;
            }
            return count;
        }
    }
    public class RealNumber : ISumAndZeros
    {
        public RealNumber()
        {
            Random random = new Random();
            this.number = random.NextSingle() + random.Next(0, 20000);
        }

        public double number;
        public int SumOfDigits()
        {
            double numberTemp = this.number;
            int sum = 0;
            string[] parts = numberTemp.ToString().Split(',');
            string text = parts[0] + parts[1];
            foreach (char digit in text)
            {
                sum += int.Parse(digit.ToString());
            }
            return sum;
        }

        public int CountZeros()
        {
            double numberTemp = this.number;
            int count = 0;
            string text = numberTemp.ToString();
            foreach (char c in text)
                if (c == '0') count++;
            return count;
        }

    }
}