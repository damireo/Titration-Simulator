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
/* * TITRATION PHASE VISUALS (Analyte Flask)
 * ---------------------------------------------------------
 * 1. TOO LITTLE (Before Equivalence Point)
 * State: pH is far from endpoint. Solution remains clear.
 */
        private static double[,] values =
{
    {0.100, 25.00, 0.1, 24.85, 1, 1}, {0.8, 10.00, 0.500, 16.67, 0, 1}, {0.250, 32.10, 0.4, 20.00, 1, 0}
};

    public static void startGame()
    {
        Console.WriteLine("Welcome to Titration Simulator!");
        Console.WriteLine("..............................");
        string type;
        Console.WriteLine("Type SS for Strong Acid, Strong base \n" +
                          " WS for Weak Acid, Strong base \n" +
                          " SW for Strong Acid, Weak base");
        type = Console.ReadLine();
        switch (type)
        {
            case "SS":
                Console.WriteLine("Find the molarity of Pool Acid");
                needed = (int)values[0, 3]; //should be able to randomize l8r
                
            case "WS":
                Console.WriteLine("Find the molarity of Acetic Acid in Household Vineger");
                needed = (int)values[1, 3];
            case "SW":
                Console.WriteLine("Find the molarity of Lemon Juice");
                needed = (int)values[2, 1];;
            default:
                Console.WriteLine("Invalid Input, please try again");
                break;
        }
    }

    public void titration(string type)
    {
        int titrant;
        
        Console.WriteLine("Enter amount of titrant of Pool Acid");
        titrant += (int)Convert.ToInt32(Console.ReadLine());
        
        while (titrant < needed)
        {
            printChanges(titrant, needed);
            Console.WriteLine("Too little titrant. Enter more");
            titrant += (int)Console.Read();

            if (titrant + 2 >= needed)
            {
                Console.WriteLine("So close....be more precise");
            }

            if (titrant == needed)
            {
                printChanges(titrant, needed);
                Console.WriteLine("Perfect titration!!! Thanks for playing");
                break;
            }

            if (titrant > needed)
            {
                printChanges(titrant, needed);
                Console.WriteLine("You added too much titrant. Time to start over!");
                break;
            }
            
        }

    }
    
    


    static void printChanges(int added, int needed)
    {
        Console.WriteLine(@"
         |       |
         |       |
        /         \
       /           \
      |~~~~~~~~~~~~~|  
      |_____________| ");  //original without anything added
        
        //Top Line
        System.Threading.Thread.Sleep(10);
        Console.SetCursorPosition(0, Console.CursorTop - 6);  //moves to line 52
        Console.Write("|   .   |");
 
        //Second Line
        System.Threading.Thread.Sleep(10);
        //Console.SetCursorPosition(0, Console.CursorTop - 1);  //keeps it on the same line
        Console.Write("|       |");  //this replaces what was previously done
        //Console.SetCursorPosition(0, Console.CursorTop - 1);  //keeps it on the same line
        Console.Write("|   .   |");

        //Third Line
        System.Threading.Thread.Sleep(10);
        //Console.SetCursorPosition(0, Console.CursorTop - 1);  //keeps it on the same line
        Console.Write("|       |");  //this replaces what was previously done
        //Console.SetCursorPosition(0, Console.CursorTop - 1);  //keeps it on the same line
        Console.Write("|   .   |");
        Console.SetCursorPosition(0, Console.CursorTop - 8);  //moves to line 52

        if (added < needed)
        {
            Console.WriteLine(@"
         |       |
         |       |
        /         \
       /           \
      |~~~~~~~~~~~~~|  
      |_____________| ");  //pH is far from endpoint. Solution remains clear.
        //Clear Liquid
        }
     
        else if (added == needed)
        {
            Console.WriteLine(@"
         |       |
         |       |
        /     *   \
       /  *  ~  +  \
      |.* .+ .+ ~* .| 
      |_____________| ");  //Exact stoichiometric balance. Very faint shading to show the pale pink or pale yellow.
        //Faint Tint (Endpoint)
        }
    
        else if (added > needed)
        {
            Console.WriteLine(@"
         |       |
         |       |
        /         \
       /###########\
      |#############|
      |#############| ");  //Past equivalence. pH has swung wildly
            //Dark/Opaque (Ruined)
        }
    }

static public void Main()
    {
        startGame();
    }
}
