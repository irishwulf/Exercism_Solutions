=begin
Write your code for the 'Grains' exercise in this file. Make the tests in
`grains_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/grains` directory.
=end
module Grains
  BOARD_SIZE = 64

  def self.square square_num
    raise ArgumentError if !(1..BOARD_SIZE).include? square_num

    return 2 ** (square_num - 1)
  end

  def self.total
    return (2 ** BOARD_SIZE) - 1
  end
end