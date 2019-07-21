using System;

namespace StateTrackerProject
{
    class Program
    {
        public static StateTracker StateTracker { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Battleship");
            Console.Write("Ready to start game? (y/n): ");
            var keyPressed = Console.ReadKey().KeyChar;

            if (keyPressed != 'y')
                return;

            StateTracker = new StateTracker("John Doe");
            StateTracker.StartGame();

            AddShips();

            InitiateAttack();

            Console.WriteLine("All ships sunk. Game Over");
            Console.ReadKey();
        }

        static void InitiateAttack()
        {
            while (true)
            {
                Console.WriteLine("Time to attack");
                Console.WriteLine("Enter coordinate of current attack...");

                Console.Write("Enter initial x coordinate (a - j): ");
                var xCoordinate = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.Write("Enter initial y coordinate (1 - 10): ");
                var yCoordinate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                Console.WriteLine(StateTracker.AssessAttack(xCoordinate, yCoordinate) ? "You got a Hit\n" : "You missed\n");

                if (!StateTracker.HasGameEnded())
                    continue;

                break;
            }
        }

        static void AddShips()
        {
            bool addShip;
            Console.WriteLine("\n");
            Console.WriteLine("Add at least one ship");

            do
            {
                Console.WriteLine("Defining properties for Ship...");

                Console.Write("Enter initial x coordinate (a - j): ");
                var xCoordinate = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.Write("Enter initial y coordinate (1 - 10): ");
                var yCoordinate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Enter the length of the Ship: ");
                var length = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Enter the Ship Orientation (n/s/e/w): ");
                var orientation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (!StateTracker.AddShipToBoard(xCoordinate, yCoordinate, length, orientation))
                {
                    Console.WriteLine("Error adding Ship...");
                    addShip = true;
                    continue;
                }
                else
                    Console.WriteLine("Ship added successfully!");

                Console.Write("Add another ship? (y/n): ");
                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                addShip = key == 'y';
            } while (addShip);
        }
    }
}
