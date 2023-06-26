=begin
Write your code for the 'Anagram' exercise in this file. Make the tests in
`anagram_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/anagram` directory.
=end
class Anagram
  def initialize(target_word)
    @target_word = target_word.downcase
  end

  def match(array)
    array
      .select do |word|
        word.downcase != @target_word &&
        word.downcase.chars.sort == @target_word.chars.sort
      end
  end
end