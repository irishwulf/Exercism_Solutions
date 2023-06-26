=begin
Write your code for the 'Armstrong Numbers' exercise in this file. Make the tests in
`armstrong_numbers_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/armstrong-numbers` directory.
=end
module ArmstrongNumbers
  def self.include? test_number
    return test_number.to_s.chars.map { |c|
      c.to_i ** test_number.to_s.length
    }.sum == test_number
  end
end