namespace calculator
{
    using MathMethod = System.Func<double, double, double>;
    class Program
    {
        static double getDoubleInput(int inputNumber)
        {
            while (true)
            {
                Console.WriteLine("Podaj liczbę nr " + inputNumber + " :") ;
                double returnDouble;
                if (!double.TryParse(Console.ReadLine(), out returnDouble)) {
                    Console.WriteLine("[ERROR] Niepoprawna liczba!");
                    continue;
                }
                return returnDouble;
            }
        }

        static void Main()
        {

            Dictionary<string, MathMethod> mathOperations = new Dictionary<string, MathMethod>
            {
                { "dodawanie", My_Math.add },
                { "odejmowanie", My_Math.subtract },
                { "mnożenie", My_Math.multiply },
                { "dzielenie", My_Math.divide },
                { "potęgowanie", My_Math.exponentiation }
            };

            while (true)
            {
                Console.WriteLine("=========================");
                int indexer = 1;
                foreach (string operationName in mathOperations.Keys)
                {
                    Console.WriteLine(indexer + " - " + operationName);
                    indexer++;
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine("0 - wyjście");
                Console.WriteLine("=========================");

                Console.WriteLine("Podaj numer opcji:");
                int optionNumber;
                if (!int.TryParse(Console.ReadLine(), out optionNumber)) {
                    Console.WriteLine("[ERROR] Niepoprawny numer opcji!");
                    continue;
                }
                if (optionNumber == 0) { return; }
                else if (optionNumber >= indexer)
                {
                    Console.WriteLine("[ERROR] Taka opcja nie istnieje!");
                    continue;
                }

                Console.WriteLine();
                double firstNumber = getDoubleInput(1);
                double secondNumber = getDoubleInput(2);

                MathMethod mathMethod = mathOperations.ElementAt(optionNumber-1).Value;
                Console.WriteLine("\n******WYNIK******");
                Console.WriteLine(mathMethod(firstNumber, secondNumber));
                Console.WriteLine("******WYNIK******\n");
                }

        }
    }
}