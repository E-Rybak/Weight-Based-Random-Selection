using System;
using System.Collections.Generic;

namespace DualUtilityReasoning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            double[] utilities = { 5.0, 3.0, 8.0 };
            double sumOfUtilities = 0.0;
            var probabilities = new List<double>();
            double sumOfProbabilities = 0.0;

            foreach (var utility in utilities)
            {
                sumOfUtilities += utility;
            }
            
            for (int i = 0; i < utilities.Length; i++)
            {
                double probability = utilities[i] / (sumOfUtilities - utilities[i]);
                probabilities.Add(probability);
            }
            
            int count = 0;
            foreach (var probability in probabilities)
            {
                count++;
                Console.WriteLine("Probability for utility {0} is {1} ", count, probability.ToString());
                sumOfProbabilities += probability;
            }
            Console.WriteLine("Sum of probabilities is = {0}", sumOfProbabilities);
            double randomNumber = GetRandomNumber(0.0, sumOfProbabilities);
            Console.WriteLine("Random number between 0 and sum of probablities is {0}", randomNumber);

            foreach (var probability in probabilities)
            {
                randomNumber -= probability;
                if(randomNumber <= 0)
                {
                    Console.WriteLine("Probability choosen = {0}", probability);
                    break;
                }
            }
        }

        //Generates a random double between range 
        public static double GetRandomNumber(double minimum, double maximum)
        {
            var random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
