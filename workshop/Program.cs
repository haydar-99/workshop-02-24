using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int plScore, dScore;
            int deposit;
            int points = 2000;
            while (points > 0)
            {
                Console.WriteLine("****BlackJack****");
                //Console.WriteLine("how many players?");
                //int answer = Convert.ToInt32(Console.ReadLine());                
                Console.WriteLine("How much do you want to deposit?");
                deposit = Convert.ToInt32(Console.ReadLine());
                points -= deposit;
                plScore = Player(); //Add a method called Player later
                if (plScore <= 20)
                {
                    dScore = Dealer();
                    if (dScore < plScore)
                    {
                        Console.WriteLine("You won this round.");
                        points += deposit * 2;
                        continue;
                    }
                    Console.WriteLine("You lost this round.");
                    //Printa vad resultatet blev (deposit)
                }
                



            }

        }
    }
}
