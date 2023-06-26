# This is a custom exception that you can use in your code
class NotMovieClubMemberError < RuntimeError
end

class Moviegoer
  MINIMUM_AGE_SENIOR = 60
  MINIMUM_AGE_SCARY = 18
  REGULAR_PRICE = 15
  SENIOR_PRICE = 10

  def initialize(age, member: false)
    @age = age
    @member = member
  end

  def ticket_price
    @age >= MINIMUM_AGE_SENIOR ? SENIOR_PRICE : REGULAR_PRICE
  end

  def watch_scary_movie?
    @age >= MINIMUM_AGE_SCARY
  end

  # Popcorn is 🍿
  def claim_free_popcorn!
    @member ? "🍿" : (raise NotMovieClubMemberError.new())
  end
end
