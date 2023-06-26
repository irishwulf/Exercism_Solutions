=begin
Write your code for the 'Word Count' exercise in this file. Make the tests in
`word_count_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/word-count` directory.
=end
class Phrase
  def initialize(text)
    @text = text.downcase
  end

  def word_count()
    @text.scan(/[\w]+(?:'[\w]+)?/).each_with_object(Hash.new) do |word,word_map|
      if word_map[word]
        word_map[word] += 1
      else
        word_map[word] = 1
      end
    end
  end
end