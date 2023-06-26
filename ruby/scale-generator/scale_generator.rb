=begin
Write your code for the 'Scale Generator' exercise in this file. Make the tests in
`scale_generator_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/scale-generator` directory.
=end
class Scale
  CHROMATIC = {
    "sharp" => %w[A A# B C C# D D# E F F# G G#],
    "flat" => %w[A Bb B C Db D Eb E F Gb G Ab]
  }
  TONIC = {
    "sharp" => %w[C a G D A E B F# e b f# c# g# d#],
    "flat" => %w[F Bb Eb Ab Db Gb d g c f bb eb]
  }
  INTERVALS = {
    'm' => 1,
    'M' => 2,
    'A' => 3
  }

  attr_reader :chromatic
  def initialize tonic
    TONIC.each { |h,k|
      if k.include? tonic
        @chromatic = CHROMATIC[h].rotate(CHROMATIC[h].find_index(tonic.capitalize))
      end
    }
  end

  def interval intervals
    index = 0
    max_index = @chromatic.length
    intervals.chars.each_with_object([@chromatic[0]]) { |c, output|
      index += INTERVALS[c]
      index = index % max_index
      output << @chromatic[index]
    }
  end
end