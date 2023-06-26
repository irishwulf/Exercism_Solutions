=begin
Write your code for the 'Series' exercise in this file. Make the tests in
`series_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/series` directory.
=end
class Series
  def initialize(str)
    @string = str
  end

  def slices(block_size)
    raise ArgumentError if block_size > @string.size

    @string.split("").each_cons(block_size).map(&:join)
  end
end