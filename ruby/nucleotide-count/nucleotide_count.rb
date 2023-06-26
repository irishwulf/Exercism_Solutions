=begin
Write your code for the 'Nucleotide Count' exercise in this file. Make the tests in
`nucleotide_count_test.rb` pass.

To get started with TDD, see the `README.md` file in your
`ruby/nucleotide-count` directory.
=end
class Nucleotide
  VALID_NUCLEOTIDES = %w[A C G T]
  attr_reader :histogram

  def initialize dna
    @histogram = VALID_NUCLEOTIDES.each_with_object({}) {|c,counts| counts[c] = 0}
    
    dna.chars.each do |dna_char|
      raise ArgumentError unless VALID_NUCLEOTIDES.include? dna_char
      @histogram[dna_char] += 1
    end

  end

  def self.from_dna dna
    Nucleotide.new(dna)
  end

  def count nucleotide
    @histogram[nucleotide]
  end
end