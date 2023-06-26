=begin
Write your code for the 'Scrabble Score' exercise in this file. Make the tests in
`scrabble_score_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/scrabble-score` directory.
=end
class Scrabble
  SCORES = {
    1 => %w[a e i o u l n r s t],
    2 => %w[d g],
    3 => %w[b c m p],
    4 => %w[f h v w y],
    5 => %w[k],
    8 => %w[j x],
    10 => %w[q z]
  }

  def initialize(word)
    @word = word.downcase
  end

  def score
    @word.chars.each.map { |char|
      SCORES.each.map { |k,v| v.include?(char) ? k : 0}.sum
    }.sum
  end
end