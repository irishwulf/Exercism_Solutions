=begin
Write your code for the 'Proverb' exercise in this file. Make the tests in
`proverb_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/proverb` directory.
=end
class Proverb
  def initialize(*chain, qualifier: nil)
    @chain = chain
    @qualifier = !qualifier.nil? ? (qualifier + " ") : ""
  end

  def to_s
    @chain.each_cons(2).map { |a,b|
      "For want of a #{a} the #{b} was lost.\n"
    }.join +
    "And all for the want of a #{@qualifier}#{@chain[0]}."
  end
end