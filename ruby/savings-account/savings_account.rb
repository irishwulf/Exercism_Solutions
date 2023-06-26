module SavingsAccount
  def self.interest_rate(balance)
    case balance
    when 0...1000
      0.5
    when 1000...5000
      1.621
    when 5000..Float::INFINITY
      2.475
    when -Float::INFINITY...0
      3.213
    end
  end

  def self.annual_balance_update(balance)
    balance * (1 + interest_rate(balance) / 100)
  end

  def self.years_before_desired_balance(current_balance, desired_balance)
    num_years = 0
    while (current_balance < desired_balance)
      num_years += 1
      current_balance = annual_balance_update(current_balance)
    end
    num_years
  end
end
