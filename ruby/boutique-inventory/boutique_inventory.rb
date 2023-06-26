class BoutiqueInventory
  CHEAP_PRICE = 30

  def initialize(items)
    @items = items
  end

  def item_names
    @items.map { |item|
      item[:name]
    }.sort
  end

  def cheap
    @items.select { |item| item[:price] < CHEAP_PRICE }
  end

  def out_of_stock
    @items.select { |item| item[:quantity_by_size].empty? }
  end

  def stock_for_item(name)
    @items.select { |item|
      item[:name] == name
    }[0][:quantity_by_size]
  end

  def total_stock
    @items.map { |item|
      item[:quantity_by_size].values.sum
    }.sum
  end

  private
  attr_reader :items
end
