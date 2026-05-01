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
        
        private string[] pairs = {"Standard", "Vinegar", "Ammonia"};
        private double[,] values = new double { {0.100, 25.00, 0.1, 24.85, 1, 1}, {0.8, 10.00, 0.500, 16.67, 0, 1}, {0.250, 32.10, 0.4, 20.00, 1, 0} };
    
    
    
}
