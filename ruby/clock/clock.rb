=begin
Write your code for the 'Clock' exercise in this file. Make the tests in
`clock_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/clock` directory.
=end
class Clock
  attr_reader :hour, :minute

  def initialize(hour:0, minute:0)
    @hour = (hour + (minute/60).truncate) % 24
    @minute = minute % 60
  end

  def + clock2
    Clock.new(hour: (@hour + clock2.hour), minute: (@minute + clock2.minute))
  end

  def - clock2
    Clock.new(hour: (@hour - clock2.hour), minute: (@minute - clock2.minute))
  end

  def == clock2
    @hour == clock2.hour && @minute == clock2.minute
  end

  def to_s
    "%02d:%02d" % [@hour, @minute]
  end
end