=begin
Write your code for the 'Pythagorean Triplet' exercise in this file. Make the tests in
`pythagorean_triplet_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/pythagorean-triplet` directory.
=end
module PythagoreanTriplet
  def self.triplets_with_sum sum
    (1..(sum/3)).each_with_object([]) do |a,triplets|
      b = (-sum ** 2 + 2 * sum * a) / ( -2 * sum + 2 * a )
      c = sum - a - b
      if (a < b) && (b < c) && (a**2 + b**2 == c**2)
        triplets << [a,b,c]
      end
    end
  end
end