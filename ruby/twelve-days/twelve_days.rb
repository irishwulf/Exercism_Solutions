=begin
Write your code for the 'Twelve Days' exercise in this file. Make the tests in
`twelve_days_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/twelve-days` directory.
=end
module TwelveDays
  DAYS = [
    ["first","a Partridge in a Pear Tree"],
    ["second","two Turtle Doves"],
    ["third","three French Hens"],
    ["fourth","four Calling Birds"],
    ["fifth","five Gold Rings"],
    ["sixth","six Geese-a-Laying"],
    ["seventh","seven Swans-a-Swimming"],
    ["eighth","eight Maids-a-Milking"],
    ["ninth","nine Ladies Dancing"],
    ["tenth","ten Lords-a-Leaping"],
    ["eleventh","eleven Pipers Piping"],
    ["twelfth","twelve Drummers Drumming"]
  ]

  def self.song
    DAYS.map.with_index { |day,index|

      "On the #{day[0]} day of Christmas my true love gave to me: " +
      DAYS.slice(1,index).reverse.map { |day| day[1].to_s + ", " }.join +
      (index > 0 ? "and " : "") +
      DAYS[0][1] + "."
    }.join("\n\n") + "\n"
  end
end