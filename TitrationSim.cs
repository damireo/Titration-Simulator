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
    const TOO_LITTLE = `
         |       |
         |       |
        /         \\
       /           \\
      |~~~~~~~~~~~~~|  <-- Clear Liquid
      |_____________|
    `;

/* * 2. PERFECT (The Endpoint)
 * State: Exact stoichiometric balance. 
 * Visual: Very faint shading to show the "pale pink" or "pale yellow."
 */
    const PERFECT = `
         |       |
         |       |
        /         \\
       /  .  .  .  \\
      |.. .. .. .. .|  <-- Faint Tint (Endpoint)
      |_____________|
    `;

/* * 3. TOO MUCH (Over-titrated)
 * State: Past equivalence. pH has swung wildly.
 * Visual: Dense characters to show deep, dark color.
 */
    const TOO_MUCH = `
         |       |
         |       |
        /           \\
       /#############\\
      |###############| <-- Dark/Opaque (Ruined)
      |###############|
    `;

    public static void startGame()
    {
        Console.WriteLine("Welcome to Titration Simulator!");
        Console.WriteLine()"..............................");
        string type;
        Console.WriteLine("Type SS for Strong Acid, Strong base \n" +
                          " WS for Weak Acid, Strong base \n" +
                          " SW for Strong Acid, Weak base");
        type = Console.ReadLine();
        switch (type)
        {
            case "SS":
                Console.WriteLine("Find the molarity of Pool Acid");
                StrongStrong();
            case "WS":
                Console.WriteLine("Find the molarity of Acetic Acid in Household Vineger");
                WeakStrong();
            case "SW":
                Console.WriteLine("Find the molarity of Lemon Juice");
                StrongWeak();
            default:
                Console.WriteLine("Invalid Input, please try again");
                break;
        }
    }

        
        
    private string[] pairs = {"Standard", "Vinegar", "Ammonia"};
    private double[,] values = new double { {0.100, 25.00, 0.1, 24.85, 1, 1}, {0.8, 10.00, 0.500, 16.67, 0, 1}, {0.250, 32.10, 0.4, 20.00, 1, 0} };
    
    
    
}
