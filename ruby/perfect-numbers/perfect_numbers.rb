=begin
Write your code for the 'Perfect Numbers' exercise in this file. Make the tests in
`perfect_numbers_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/perfect-numbers` directory.
=end
module PerfectNumber
  def self.classify n
    raise RuntimeError if !n.kind_of? Integer or n < 1

    factor_sum = 1.upto(n-1)
        .select { |i| n % i == 0}
        .sum

    if factor_sum < n then return 'deficient'
    elsif factor_sum == n then return 'perfect'
    elsif factor_sum > n then return 'abundant'
    end
    
  end
end