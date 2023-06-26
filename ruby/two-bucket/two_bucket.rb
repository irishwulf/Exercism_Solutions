=begin
Write your code for the 'Two Bucket' exercise in this file. Make the tests in
`two_bucket_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/two-bucket` directory.
=end
class TwoBucket
  attr_reader :moves, :goal_bucket, :other_bucket

  def initialize(size_one, size_two, goal_volume, start_bucket)
    @moves = 1
    @sizes = [size_one, size_two]
    @buckets = [0,0]
    
    start = start_bucket == "one" ? 0 : 1
    fill(start)

    # Take care of this special case
    if @sizes[1-start] == goal_volume
      @moves += 1
      fill(1-start)
    end

    until @buckets.include? goal_volume do
      @moves += 1
      case @next_move
      when :FILL
        fill(@next_bucket)
      when :EMPTY
        empty(@next_bucket)
      when :TRANSFER_FROM
        transfer_from(@next_bucket)
      end
    end

    case goal_volume
    when @buckets[0]
      @goal_bucket = "one"
      @other_bucket = @buckets[1]
    else
      @goal_bucket = "two"
      @other_bucket = @buckets[0]
    end    
  end

  def fill(i)
    @buckets[i] = @sizes[i]
    @next_move = :TRANSFER_FROM
    @next_bucket = i
  end

  def empty(i)
    @buckets[i] = 0
    @next_move = :TRANSFER_FROM
    @next_bucket = 1-i
  end

  def transfer_from(i)
    total_volume = @buckets.sum
    if @sizes[1-i] >= total_volume
      @buckets[1-i] = total_volume
      @buckets[i] = 0
      @next_move = :FILL
      @next_bucket = i
    else
      @buckets[1-i] = @sizes[1-i]
      @buckets[i] = total_volume - @buckets[1-i]
      @next_move = :EMPTY
      @next_bucket = 1-i
    end
  end
end