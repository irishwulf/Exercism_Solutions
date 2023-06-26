=begin
Write your code for the 'Saddle Points' exercise in this file. Make the tests in
`saddle_points_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/saddle-points` directory.
=end
module Grid
  def self.saddle_points input
    column_mins = input.transpose.map(&:min)
    
    saddles = []
    input.each_with_index do |row,row_index|
      row_max = row.max
      row.each_with_index do |height, col_index|
        if (height == row_max && height == column_mins[col_index])
          saddles << { "row" => row_index+1, "column" => col_index+1 }
        end
      end
    end

    return saddles
  end
end