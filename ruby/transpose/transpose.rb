=begin
Write your code for the 'Transpose' exercise in this file. Make the tests in
`transpose_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/transpose` directory.
=end
module Transpose
  def self.transpose(lines)

    line_arr = lines.split("\n")
    max_line_length = line_arr.map(&:length).max
    return "" if max_line_length.nil?
    
    Array.new(max_line_length){ |i|
        new_line = line_arr.map{|e| e[i]}
        new_line.pop until !new_line.last.nil? || new_line.empty?
        new_line.map{|c| c.nil? ? " " : c}.join("")
      }.join("\n")
  end
end