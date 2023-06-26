class AssemblyLine
  BASE_PRODUCTION_RATE = 221

  def initialize(speed)
    @speed = speed
  end

  def success_rate
    if @speed <= 4
      return 1
    elsif @speed <= 8
      return 0.9
    elsif @speed == 9
      return 0.8
    else
      return 0.77
    end
  end
  
  def production_rate_per_hour
    BASE_PRODUCTION_RATE * @speed * success_rate()
  end

  def working_items_per_minute
    (production_rate_per_hour / 60).floor
  end
end
