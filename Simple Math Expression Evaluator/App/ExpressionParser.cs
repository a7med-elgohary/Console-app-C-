using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simple_Math_Expression_Evaluator.App
{
    internal class ExpressionParser
    {
        public static MathOperation MathOprationParse(string opration)
        {
            switch (opration.ToLower())
            {
                case "+":
                    return MathOperation.Addition;
                case "*":
                    return MathOperation.Multiplication;
                case "/":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "pow":
                case "^":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;
            }
        }



        private const string MathSymbols = "+/*%^";
        public static MathExpression parse(string input)
        {
            input = input.Trim();
            MathExpression expr = new MathExpression();
            string token = "";
            bool leftSideChek = false;
            for (int i = 0; i < input.Length; i++)
            {
                var inputChar = input[i];
                if (char.IsDigit(inputChar)) // add for token just numbers 
                {
                    token += inputChar;
                    if (i == input.Length-1 && leftSideChek )
                    {
                        expr.RightSideOperand = double.Parse(token);
                        break;
                    }
                    
                        
                }
                else if (MathSymbols.Contains(inputChar)) // sheck if the inputchar = mathesymbols
                {
                    if (!leftSideChek)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideChek = true;
                        
                    }
                    expr.Operation = MathOprationParse(token.ToString());
                    token = "";
                }
                else if (inputChar == '-' && i > 0)
                {
                    if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = MathOperation.Subtraction;
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideChek = true;
                        token = "";
                    }
                    else
                        token += inputChar;
                }
                else if (char.IsLetter(inputChar))
                {
                    
                    token += inputChar;
                    leftSideChek = true;

                }
                else if (inputChar == ' ')
                {
                    if (!leftSideChek )
                    {

                        try { 
                            expr.LeftSideOperand = double.Parse(token);
                            leftSideChek = true;
                            token = ""; 
                        } catch { continue; }
                    }
                    else if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = MathOprationParse(token);
                        token = "";
                    }else
                        token+= inputChar;
                }
                

            }


            return expr;
        }
    }
}
