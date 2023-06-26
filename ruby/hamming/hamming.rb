=begin
Write your code for the 'Hamming' exercise in this file. Make the tests in
`hamming_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/hamming` directory.
=end
module Hamming
  def self.compute(str1, str2)
    raise ArgumentError if str1.size != str2.size

    str1.chars.each_with_index.count do |char, index|
      str2[index] != char
    end
  end
end