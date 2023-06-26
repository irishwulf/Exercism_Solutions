=begin
Write your code for the 'Triangle' exercise in this file. Make the tests in
`triangle_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/triangle` directory.
=end
class Triangle
  def initialize(sides)
    @sides = *sides
  end

  def valid?
    @sides.all?(&:positive?) &&
    @sides.none? { |s| s * 2 > @sides.sum }
  end

  def equilateral?
    valid? &&
    @sides.uniq.count == 1
  end

  def isosceles?
    valid? &&
    @sides.uniq.count <= 2
  end

  def scalene?
    valid? &&
    @sides.uniq.count == 3
  end
end