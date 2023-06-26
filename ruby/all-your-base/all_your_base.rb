=begin
Write your code for the 'All Your Base' exercise in this file. Make the tests in
`all_your_base_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/all-your-base` directory.
=end
module BaseConverter
  def self.convert(input_base, digits, output_base)
    raise ArgumentError if [input_base, output_base].any? { |d| d < 2}
    raise ArgumentError if [*digits, input_base, output_base].any?(&:negative?)

    value = digits.reverse.map.with_index { |d,i|
      raise ArgumentError if d >= input_base
      d * (input_base ** i)
    }.sum

    output = []
    while value > 0
      output << value % output_base
      value = (value / output_base).floor
    end
    if output.empty? then output << 0 end
    output.reverse
  end
end