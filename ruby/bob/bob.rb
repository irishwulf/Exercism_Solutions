=begin
Write your code for the 'Bob' exercise in this file. Make the tests in
`bob_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/bob` directory.
=end
module Bob
  Response = {
    silence: "Fine. Be that way!",
    asking: "Sure.",
    yelling: "Whoa, chill out!",
    scream_asking: "Calm down, I know what I'm doing!",
    default: "Whatever."
  }
  Silence      = ->(t) { t =~ /\A\s*\z/ }
  Asking       = ->(t) { t =~ /\?\z/ }
  Yelling      = ->(t) { t == t.upcase && t=~ /[[:alpha:]]/ }
  ScreamAsking = ->(t) { Asking[t] && Yelling[t] }

  def self.hey(remark)
    Response[remark_type(remark)]
  end

  def self.remark_type(remark)
    case remark.strip
    when Silence
      :silence
    when ScreamAsking
      :scream_asking
    when Asking
      :asking
    when Yelling
      :yelling
    else
      :default
    end
  end
end