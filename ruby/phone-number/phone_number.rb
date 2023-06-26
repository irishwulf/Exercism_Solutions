=begin
Write your code for the 'Phone Number' exercise in this file. Make the tests in
`phone_number_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/phone-number` directory.
=end
module PhoneNumber
  def self.clean(dirty_number)
    cleaned = dirty_number.chars
              .select{|d| d.match(/\d/)}
              .join

    if cleaned[0] == '1'
      cleaned = cleaned[1..-1]
    end

    return valid_number(cleaned) ? cleaned : nil
  end

  def self.valid_number(ten_digit_string)
    return ten_digit_string.match?(/^([2-9]\d\d){2}\d{4}$/)
  end
end