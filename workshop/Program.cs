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
            int dpoints = 0;
            int points = 2000;
            int card;
            Console.WriteLine("****BlackJack****");
            //vi tar flera spelare senare
            //Console.WriteLine("how many players?");
            //int answer = Convert.ToInt32(Console.ReadLine());
            while (points > 0)
            {
                card = Deck();
                Console.WriteLine(card);
                Console.WriteLine("How much do you want to deposit?");
                deposit = Convert.ToInt32(Console.ReadLine());
                points -= deposit;
                plScore = Player(card); //Add a method called Player later
                if (plScore <= 20)
                {

                    dScore = Dealer(plScore);
                    if (dScore < plScore)
                    {
                        Console.WriteLine("You won this round.");
                        points += deposit * 2;
                        continue;
                    }
                    Console.WriteLine("You lost this round.");
                    //Printa vad resultatet blev (deposit)
                }
                else if (plScore == 21){
                    Console.WriteLine("You won this round.");
                    points += deposit * 2;
                }
                else
                {
                    Console.WriteLine("You lost this round.");
                    //printa vad givaren fick
                    dpoints += deposit;
                }
                Console.WriteLine("Want to keep playing? Y/N");
                //can add a tryparse here later
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "N" || yesOrNo == "n")
                {
                    points = 0;
                } 


            }

        }
         static int Player(int card)
        {
            int card1 = card;
            int sum = card1;
            string more = "y";
            while (more == "y" || sum < 21)
            {
                //få ett kort
                int nextcard = Deck();
                sum += nextcard;
                Console.WriteLine(sum);
                Console.WriteLine("Want another card? Y/N");
                more = Console.ReadLine().ToLower();
            }
            return sum;

        }
        static int Deck()
        {
            //måste fixas så man inte kan ta mer än 4 av samma
            Random rnd = new Random();
            return rnd.Next(1, 14);
        }
    }
}
