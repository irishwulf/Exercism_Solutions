=begin
Write your code for the 'Tournament' exercise in this file. Make the tests in
`tournament_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/tournament` directory.
=end
module Tournament
  def self.format(array)
    sprintf("%-30s | %2s | %2s | %2s | %2s | %2s\n", *array)
  end

  def self.tally(input)
    results = Hash.new { |hash, key| hash[key] = {played: 0, wins: 0, draws: 0, losses: 0, points: 0}}
    output = format(["Team", "MP", "W", "D", "L", "P"])
    
    # Parse input to populate results hash
    input.split("\n").map(&:strip).each do |line|
      team1, team2, wld = line.split(";")

      # Update points, total matches, wins/draws/losses
      results[team1][:played] += 1
      results[team2][:played] += 1
      case wld.strip
      when "win"
        results[team1][:wins] += 1
        results[team2][:losses] += 1
        results[team1][:points] += 3
      when "draw"
        results[team1][:draws] += 1
        results[team2][:draws] += 1
        results[team1][:points] += 1
        results[team2][:points] += 1
      when "loss"
        results[team1][:losses] += 1
        results[team2][:wins] += 1
        results[team2][:points] += 3
      end
    end

    # Parse results hash to produce output
    output += results.sort_by {|key, value| [-value[:points], key]}
      .map { |k,v|
      arr = [ k, v[:played], v[:wins], v[:draws], v[:losses], v[:points]]
      format(arr)
    }.join
    
    output
  end
end