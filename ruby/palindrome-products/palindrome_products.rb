=begin
Write your code for the 'Palindrome Products' exercise in this file. Make the tests in
`palindrome_products_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/palindrome-products` directory.
=end
class Palindromes
  attr_reader :smallest, :largest

  def initialize(min_factor: 1, max_factor: nil)
    @smallest = Palindrome.new(nil, [])
    @largest = Palindrome.new(nil, [])
    @min_factor = min_factor
    @max_factor = max_factor
  end

  def generate
    @min_factor.upto(@max_factor).each { |i|
      @min_factor.upto(@max_factor).each { |j|
        product = i*j
        break if !@smallest.value.nil? && product > @smallest.value

        if palindrome?(product) then
          if @smallest.value.nil? || product < @smallest.value then
            @smallest.value = product
            @smallest.factors = [[i,j].sort]
          elsif !@smallest.factors.include? [i,j].sort then
            @smallest.factors << [i,j].sort
          end
        end
      }
    }
    @max_factor.downto(@min_factor).each { |i|
      @max_factor.downto(@min_factor).each { |j|
        product = i*j
        break if !@largest.value.nil? && product < @largest.value

        if palindrome?(product) then
          if @largest.value.nil? || product > @largest.value then 
            @largest.value = product
            @largest.factors = [[i,j].sort]
          elsif !@largest.factors.include? [i,j].sort then
            @largest.factors << [i,j].sort
          end
        end
      }
    }
  end

  def palindrome? n
    return n.to_s.reverse == n.to_s
  end
end

class Palindrome
  attr_accessor :value, :factors

  def initialize(value, factors)
    @value = value
    @factors = factors
  end
end