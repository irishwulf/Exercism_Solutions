=begin
Write your code for the 'Binary Search' exercise in this file. Make the tests in
`binary_search_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/binary-search` directory.
=end
class BinarySearch
  def initialize array
    @array = array
  end

  def search_for(elem, search_floor: 0, search_ceil: (@array.length-1))
    return nil if search_floor > search_ceil

    search_pos = ((search_floor + search_ceil) / 2).floor
    if elem == @array[search_pos]
      return search_pos
    elsif elem < @array[search_pos]
      search_for(elem, search_floor: search_floor, search_ceil: search_pos - 1)
    else
      search_for(elem, search_floor: search_pos + 1, search_ceil: search_ceil)
    end
  end
end