=begin
Write your code for the 'Matching Brackets' exercise in this file. Make the tests in
`matching_brackets_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/matching-brackets` directory.
=end
module Brackets
  BRACKETS = {
    '{' => '}',
    '[' => ']',
    '(' => ')'
  }
  OPEN_BRACKETS = BRACKETS.keys
  CLOSE_BRACKETS = BRACKETS.values

  def self.paired? pattern
    stack = []
    pattern.each_char {|c|
      if OPEN_BRACKETS.include? c
        stack.push c
      elsif CLOSE_BRACKETS.include? c
        return false unless c == BRACKETS[stack.pop]
      end
    }
    stack.empty?
  end
end