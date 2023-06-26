=begin
Write your code for the 'Isogram' exercise in this file. Make the tests in
`isogram_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/isogram` directory.
=end
module Isogram
  def self.isogram?(string)
    letter_count = {}
    string.downcase.scan(/\w/)
      .each do |char|
        if letter_count[char]
          letter_count[char] += 1
        else
          letter_count[char] = 1
        end
      end

    letter_count.values.none?{|count| count > 1}
  end
end