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
                if (card == 1)
                {
                    Console.WriteLine("Do you want 1 or 14?");
                    card = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine($"Player: {card}");
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
                        points = points + (deposit * 2);
                        Console.WriteLine($"Player points: {points}");
                        Console.WriteLine($"Dealer points: {dpoints}");
                        continue;
                    }
                    Console.WriteLine("You lost this round.");
                    //Printa vad resultatet blev (deposit)
                    dpoints += deposit;
                    Console.WriteLine($"Player points: {points}");
                    Console.WriteLine($"Dealer points: {dpoints}");
                }
                else if (plScore == 21){
                    Console.WriteLine("You won this round.");
                    points = points + (deposit * 2);
                    Console.WriteLine($"Player points: {points}");
                    Console.WriteLine($"Dealer points: {dpoints}");
                }
                else
                {
                    Console.WriteLine("You lost this round.");
                    //printa vad givaren fick
                    dpoints += deposit;
                    Console.WriteLine($"Player points: {points}");
                    Console.WriteLine($"Dealer points: {dpoints}");
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
            while (more == "y" && sum < 21)
            {
                //få ett kort
                int nextcard = Deck();
                if (nextcard == 1)
                {
                    Console.WriteLine("Do you want 1 or 14?");
                    nextcard = Convert.ToInt32(Console.ReadLine());
                }
                sum += nextcard;
                Console.WriteLine($"Player: {sum}");
                Console.WriteLine("Want another card? Y/N");
                more = Console.ReadLine().ToLower();
            }
            return sum;

        }
        
        //måste fixas så man inte kan ta mer än 4 av samma            
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        static int Deck() {

            lock (syncLock)
            { // synchronize
                return random.Next(1, 14);
            }
        }
          
        static int Dealer(int plScore)
        {
            int card = Deck();
            int sum = card;
            Console.WriteLine($"Dealer: {sum}");
            while (sum < plScore)
            {
                int nextCard = Deck();
                if(nextCard == 1)
                {
                    if(sum <= 7)
                    {
                        nextCard = 14;
                    }                    
                }
                sum += nextCard;
                Console.WriteLine($"Dealer: {sum}");
            }
            if(sum > 21)
            {
                sum = 0;
            }
            return sum;
        }
    }
}
