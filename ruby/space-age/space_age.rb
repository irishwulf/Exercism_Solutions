=begin
Write your code for the 'Space Age' exercise in this file. Make the tests in
`space_age_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/space-age` directory.
=end
class SpaceAge
  SECONDS_PER_EARTH_YEAR = 60 * 60 * 24 * 365.25
  
  def initialize(age_in_seconds)
    @age = age_in_seconds / SECONDS_PER_EARTH_YEAR
  end

  { :mercury => 0.2408467,
    :venus   => 0.61519726,
    :earth   => 1,
    :mars    => 1.8808158,
    :jupiter => 11.862615,
    :saturn  => 29.447498,
    :uranus  => 84.016846,
    :neptune => 164.79132
  }.each do |planet,earth_years|
      define_method :"on_#{planet}" do
        @age / earth_years
      end
    end
end