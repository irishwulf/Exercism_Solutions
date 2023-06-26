=begin
Write your code for the 'Sum Of Multiples' exercise in this file. Make the tests in
`sum_of_multiples_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/sum-of-multiples` directory.
=end
class SumOfMultiples
  def initialize(*item_levels)
    @item_levels = *item_levels
  end

  def to(level)
    multiples = []
    @item_levels.each do |item|
      if (item != 0)
        multiples += (0...level).step(item).map(&:itself)
      end
    end

    multiples.uniq.sum
  end
end