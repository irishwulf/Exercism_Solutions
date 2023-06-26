=begin
Write your code for the 'Raindrops' exercise in this file. Make the tests in
`raindrops_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/raindrops` directory.
=end
module Raindrops
  def self.convert(i)
    sound = ""
    sound += "Pling" if i % 3 == 0
    sound += "Plang" if i % 5 == 0
    sound += "Plong" if i % 7 == 0
    sound = i.to_s if sound == ""

    sound
  end
end