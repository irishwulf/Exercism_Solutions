using System;
using System.Runtime.Serialization;

[Serializable]
public class CalculationException : Exception
{
    private Exception _innerException;

    public CalculationException() : base() {}
    public CalculationException(string message) : base(message) {}
    public CalculationException(string message, Exception inner) : base(message, inner) {}
    public CalculationException(SerializationInfo info, StreamingContext context) : base(info, context) {}

    public CalculationException(int operand1, int operand2, string message, Exception inner) : this(message, inner)
    {
        Operand1 = operand1;
        Operand2 = operand2;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try {
            Multiply(x, y);
            return "Multiply succeeded";
        } catch (CalculationException e) when (e.Operand1 < 0 && e.Operand2 < 0) {
            return $"Multiply failed for negative operands. {e.Message}";
        } catch (CalculationException e) {
            return $"Multiply failed for mixed or positive operands. {e.Message}";
        }
    }

    public void Multiply(int x, int y)
    {
        try {
            checked {
                int test = x * y;
            }
        } catch (OverflowException oe) {
            throw new CalculationException(x, y, oe.Message, oe);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
