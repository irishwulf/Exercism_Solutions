class LocomotiveEngineer
  def self.generate_list_of_wagons(*arguments)
    arguments
  end

  def self.fix_list_of_wagons(each_wagons_id, missing_wagons)
    # Move first two wagons to the end, and insert missing wagons
    first, second, locomotive, *last = each_wagons_id

    [locomotive, *missing_wagons, *last, first, second]
  end

  def self.add_missing_stops(route_hash, **keyword_arguments)
    *stop_array = keyword_arguments.values

    {**route_hash, stops: stop_array}
  end

  def self.extend_route_information(route, more_route_information)
    {**route, **more_route_information}
  end
end
