class BirdCount
  COUNT_LAST_WEEK = [0, 2, 5, 3, 7, 8, 4]
  BUSY_THRESHOLD = 5

  def self.last_week
    COUNT_LAST_WEEK
  end

  def initialize(birds_per_day)
    @count = birds_per_day
  end

  def yesterday
    @count[-2]
  end

  def total
    @count.sum()
  end

  def busy_days
    @count.count { |n| n >= BUSY_THRESHOLD }
  end

  def day_without_birds?
    @count.any? { |n| n == 0 }
  end
end
