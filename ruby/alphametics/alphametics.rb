=begin
Write your code for the 'Alphametics' exercise in this file. Make the tests in
`alphametics_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/alphametics` directory.
=end
class Alphametics

  def self.solve puzzle_input
    new(puzzle_input).solve
  end

  attr_reader :words, :first_letters
  def initialize(puzzle_input)
    @words = puzzle_input.scan(/[A-Z]+/)
    @leading_letter = @words.max_by(&:length).chars.first
  end

  def solve
    (1..9).each { |n|
      ((0..9).to_a - [n]).permutation(linear_equation.count - 1) { |permutation|
        next unless permutation.unshift(n)
          .zip(equation_coefficients)
          .sum { |x, y| x * y }
          .zero?
        
        return equation_letters.zip(permutation).to_h
      }
    }

    return {}
  end

  def equation_coefficients
    @equation_coefficients ||= linear_equation.map(&:last)
  end

  def equation_letters
    @equation_letters ||= linear_equation.map(&:first)
  end

  def linear_equation
    @linear_equation ||= begin
      *operands, expected_sum = words

      result = Hash.new { |h, k| h[k] = 0 }

      operands.each { |coefficient|
        coefficient.reverse.chars.each_with_index {|c, power|
          result[c] += 10 ** power
        }
      }

      expected_sum.reverse.chars.each_with_index { |c, power|
        result[c] -= 10 ** power
      }

      result.sort_by { |(k,v)| @leading_letter == k ? -1 : 1 }
    end
  end
end