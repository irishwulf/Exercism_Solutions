class SimpleCalculator
  class UnsupportedOperation < StandardError
  end
  
  ALLOWED_OPERATIONS = ['+', '/', '*'].freeze

  def self.calculate(first_operand, second_operand, operation)
    if !ALLOWED_OPERATIONS.include?(operation)
      raise UnsupportedOperation.new("'#{operation}' is not a supported operation")
    end

    if !(first_operand.is_a?(Integer) && second_operand.is_a?(Integer))
      raise ArgumentError.new("Operands must be integers")
    end

    case operation
    when "+"
      result = first_operand + second_operand
    when "/"
      begin
        result = first_operand / second_operand
      rescue ZeroDivisionError
        return "Division by zero is not allowed."
      end
    when "*"
      result = first_operand * second_operand
    end

    "#{first_operand} #{operation} #{second_operand} = #{result.to_s}"
  end
end
