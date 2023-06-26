=begin
Write your code for the 'Resistor Color Trio' exercise in this file. Make the tests in
`resistor_color_trio_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/resistor-color-trio` directory.
=end
class ResistorColorTrio
  COLORS = %w[black brown red orange yellow green blue violet grey white]

  def initialize(bands)
    first, second, zeroes = bands.map {|b| COLORS.index(b)}
    @resistance = "#{first}#{second}#{'0'*zeroes}"
  end

  def label
    matches = @resistance.match(/(?<nonzero>^[1-9]*)(?<zero>0*$)/)
    return "Resistor value: #{matches[:nonzero]}#{to_ohms(matches[:zero].length)}"
  end

  def to_ohms(magnitude)
    return "0" * (magnitude % 3) +
      case (magnitude / 3).floor
      when 0
        " ohms"
      when 1
        " kiloohms"
      when 2
        " megaohms"
      when 3
        " gigaohms"
      end
  end
end