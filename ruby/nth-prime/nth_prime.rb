=begin
Write your code for the 'Nth Prime' exercise in this file. Make the tests in
`nth_prime_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/nth-prime` directory.
=end
module Prime
  def self.nth index
    raise ArgumentError, "No #{index}th prime." unless index > 0

    primes = [2,3]
    n = 5

    while primes.length < index
      primes << n if prime?(n,primes)
      n += 2
    end
        
    primes[index-1]
  end

  def self.prime?(n, existing_primes)
    !existing_primes.any? { |p|
      n % p == 0
    }
  end
end