=begin
Write your code for the 'Luhn' exercise in this file. Make the tests in
`luhn_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/luhn` directory.
=end
module Luhn
  def self.valid? input
    input.gsub!(/\s+/,"") # Remove whitespace

    return false if input.match?(/[^0-9]/)
    return false if input.length < 2

    input.chars.map(&:to_i)
      .reverse
      .map.with_index { |d, i| i.odd? ? d * 2 : d }
      .map { |d| d > 9 ? (d-9) : d }
      .sum % 10 == 0
  end
end