namespace DefaultNamespace;

public class TitrationSim
{
    /* * TITRATION SIMULATION REFERENCE DATA
     * Formula: (n_acid * M_acid * V_acid) = (n_base * M_base * V_base)
     * ---------------------------------------------------------------------------
     * Scenario      | M_A (M) | V_A (mL) | M_B (M) | V_B (mL) | n_A | n_B | Type
     * ---------------------------------------------------------------------------
     * Standard      | 0.100   | 25.00    | ? (0.1) | 24.85    | 1   | 1   | Strong/Strong
     * Vinegar       | ? (0.8) | 10.00    | 0.500   | 16.67    | 1   | 1   | Weak/Strong
     * Ammonia       | 0.250   | 32.10    | ? (0.4) | 20.00    | 1   | 1   | Strong/Weak
     * Oxalic Acid   | 0.050   | 25.00    | 0.100   | 25.00    | 2   | 1   | Diprotic
     * ---------------------------------------------------------------------------
     * n_A = H+ ions per acid molecule (e.g., HCl = 1, H2C2O4 = 2)
     * n_B = OH- ions per base molecule (e.g., NaOH = 1, Ba(OH)2 = 2)
     */

    private static double[,] values =
    {
        {0.100, 25.00, 0.1, 24.85, 1, 1},
        {0.8, 10.00, 0.500, 16.67, 0, 1},
        {0.250, 32.10, 0.4, 20.00, 1, 0}
    };

    private static int needed = 0;

    public static void startGame()
    {
        Console.WriteLine("Welcome to Titration Simulator!");
        Console.WriteLine("..............................");
        Console.WriteLine("Type SS for Strong Acid, Strong base \n" +
                          " WS for Weak Acid, Strong base \n" +
                          " SW for Strong Acid, Weak base");
        string type = Console.ReadLine() ?? "";
        switch (type)
        {
            case "SS":
                Console.WriteLine("Find the molarity of Pool Acid");
                needed = (int)values[0, 3];
                break;
            case "WS":
                Console.WriteLine("Find the molarity of Acetic Acid in Household Vinegar");
                needed = (int)values[1, 3];
                break;
            case "SW":
                Console.WriteLine("Find the molarity of Lemon Juice");
                needed = (int)values[2, 1];
                break;
            default:
                Console.WriteLine("Invalid Input, please try again");
                startGame();
                return;
        }
        titration(type);
    }

    public static void titration(string type)
    {
        int titrant = 0;

        Console.WriteLine("Enter amount of titrant:");
        titrant += Convert.ToInt32(Console.ReadLine());

        while (titrant < needed)
        {
            printChanges(titrant, needed);
            Console.WriteLine("Too little titrant. Enter more:");
            int extra = Convert.ToInt32(Console.ReadLine());
            titrant += extra;

            if (titrant + 2 >= needed && titrant < needed)
            {
                Console.WriteLine("So close....be more precise");
            }

            if (titrant == needed)
            {
                printChanges(titrant, needed);
                Console.WriteLine("Perfect titration!!! Thanks for playing");
                return;
            }

            if (titrant > needed)
            {
                printChanges(titrant, needed);
                Console.WriteLine("You added too much titrant. Time to start over!");
                return;
            }
        }

        if (titrant == needed)
        {
            printChanges(titrant, needed);
            Console.WriteLine("Perfect titration!!! Thanks for playing");
        }
        else if (titrant > needed)
        {
            printChanges(titrant, needed);
            Console.WriteLine("You added too much titrant. Time to start over!");
        }
    }

    static void printChanges(int added, int needed)
    {
        if (added < needed)
        {
            Console.WriteLine(@"
         |       |
         |       |
        /         \
       /           \
      |~~~~~~~~~~~~~|  
      |_____________| ");
            Console.WriteLine("State: Clear (before equivalence point)");
        }
        else if (added == needed)
        {
            Console.WriteLine(@"
         |       |
         |       |
        /     *   \
       /  *  ~  +  \
      |.* .+ .+ ~* .| 
      |_____________| ");
            Console.WriteLine("State: Faint Tint (endpoint reached!)");
        }
        else if (added > needed)
        {
            Console.WriteLine(@"
         |       |
         |       |
        /         \
       /###########\
      |#############|
      |#############| ");
            Console.WriteLine("State: Dark/Opaque (past equivalence - ruined!)");
        }
    }

    public static void Main()
    {
        startGame();
    }
}
