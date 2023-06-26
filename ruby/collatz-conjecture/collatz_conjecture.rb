=begin
Write your code for the 'Collatz Conjecture' exercise in this file. Make the tests in
`collatz_conjecture_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/collatz-conjecture` directory.
=end
module CollatzConjecture
  def self.steps myInt
    raise ArgumentError unless myInt.positive?
    steps = 0
    while myInt != 1 do
      myInt = myInt.even? ? (myInt / 2) : (myInt * 3 + 1)
      steps += 1
    end

    steps
  end
end