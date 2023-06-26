using System;
using System.Collections.Generic;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation) => operation switch {
        null => throw new ArgumentNullException(),
        "" => throw new ArgumentException(),
        "/" when operand2 == 0 => "Division by zero is not allowed.",
        var x when _valid_ops.ContainsKey(x)  =>
            $"{operand1} {operation} {operand2} = {_valid_ops[operation](operand1, operand2)}",
        _ => throw new ArgumentOutOfRangeException()
    };

    #region fixed values
    private static readonly Dictionary<string,Func<int,int,int>> _valid_ops = new(){
        ["+"] = SimpleOperation.Addition,
        ["*"] = SimpleOperation.Multiplication,
        ["/"] = SimpleOperation.Division
    };
    #endregion
}
