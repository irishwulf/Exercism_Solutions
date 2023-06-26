=begin
Write your code for the 'Matrix' exercise in this file. Make the tests in
`matrix_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/matrix` directory.
=end
class Matrix
  attr_reader :rows, :columns

  def initialize(matrix_string)
    @rows = matrix_string.each_line.map do |line|
      line.chomp.split(" ").map(&:to_i)
    end
    
    @columns = @rows.transpose
  end
end