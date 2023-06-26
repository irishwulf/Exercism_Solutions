=begin
Write your code for the 'Sieve' exercise in this file. Make the tests in
`sieve_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/sieve` directory.
=end
class Sieve
  attr_reader :primes

  def initialize up_to_int
    @candidates = up_to_int >= 2 ? (Array(2..up_to_int)) : ([])
    @primes = []
    until @candidates.empty? do
      prime = @candidates.shift
      @primes << prime
      (prime..up_to_int).step(prime).each do |multiple|
        @candidates.delete(multiple)
      end
    end
  end
end