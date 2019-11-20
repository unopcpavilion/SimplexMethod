using Google.OrTools.LinearSolver;
using System;

public class SimpleLpProgram
{
    static void Main()
    {
        Solver solver = Solver.CreateSolver("SimpleLpProgram", "GLOP_LINEAR_PROGRAMMING");

        Variable x = solver.MakeNumVar(0.0, double.MaxValue, "x");
        Variable y = solver.MakeNumVar(0.0, double.MaxValue, "y");
        Variable z = solver.MakeNumVar(0.0, double.MaxValue, "z");

        Console.WriteLine("Number of variables = " + solver.NumVariables());

        Constraint ct1 = solver.MakeConstraint(1.9, 2.0, "ct1");
        ct1.SetCoefficient(x, 0.05);
        ct1.SetCoefficient(y, 0.0);
        ct1.SetCoefficient(z, 0.2);


        Constraint ct2 = solver.MakeConstraint(2.9, 3.0, "ct22");
        ct2.SetCoefficient(x, 0.1);
        ct2.SetCoefficient(y, 0.5);
        ct2.SetCoefficient(z, 0.3);

        Console.WriteLine("Number of constraints = " + solver.NumConstraints());

        Objective objective = solver.Objective();
        objective.SetCoefficient(x, 500);
        objective.SetCoefficient(y, 100);
        objective.SetCoefficient(z, 50);
        objective.SetMinimization();

        solver.Solve();

        Console.WriteLine("Solution:");
        Console.WriteLine("Objective value = " + solver.Objective().Value());
        Console.WriteLine("x = " + x.SolutionValue());
        Console.WriteLine("y = " + y.SolutionValue());
        Console.WriteLine("z = " + z.SolutionValue());
    }
}
