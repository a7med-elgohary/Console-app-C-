using Simple_Math_Expression_Evaluator;
using Simple_Math_Expression_Evaluator.App;

internal class Program
{
    /*
            {Simple math expression evaluator}
        ==> Ask the user to enter math expression .
        ==> Evaluate the expression & print the result .        
     */
    private static void Main(string[] args)
    {
        
        while (true)
        {

            Console.Write("Enter math expression : ");
            var input = Console.ReadLine();
            var expr = ExpressionParser.parse(input);
            Console.WriteLine($"The lift Side : {expr.LeftSideOperand}\nThe Opration : {expr.Operation}\nThe right side : {expr.RightSideOperand}");
            Console.WriteLine($"{input} + {EvaluateExpression(expr)}");
        }
    }
    private static object EvaluateExpression(MathExpression expr)
    {
        if (expr.Operation == MathOperation.Addition)
            return expr.LeftSideOperand + expr.RightSideOperand;
        else if (expr.Operation == MathOperation.Subtraction)
            return expr.LeftSideOperand - expr.RightSideOperand;
        else if (expr.Operation == MathOperation.Multiplication)
            return expr.LeftSideOperand * expr.RightSideOperand;
        else if (expr.Operation == MathOperation.Division)
            return expr.LeftSideOperand / expr.RightSideOperand;
        else if (expr.Operation == MathOperation.Modulus)
            return expr.LeftSideOperand % expr.RightSideOperand;
        else if (expr.Operation == MathOperation.Power)
            return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);
        else if (expr.Operation == MathOperation.Sin)
            return Math.Sin(expr.RightSideOperand);
        else if (expr.Operation == MathOperation.Cos)
            return Math.Cos(expr.RightSideOperand);
        else if (expr.Operation == MathOperation.Tan)
            return Math.Tan(expr.RightSideOperand);
        else
            throw new InvalidOperationException("Unsupported operation");
    }

}