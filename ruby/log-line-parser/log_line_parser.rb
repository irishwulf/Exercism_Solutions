class LogLineParser
  def initialize(line)
    @line = line
    parse()
  end

  def parse
    m = @line.match(/\[(?<log_level>[^\]]*)\]: (?<message>.*)$/)
    @log_level = m['log_level'].downcase()
    @message = m['message'].strip()
  end

  def message
    @message
  end

  def log_level
    @log_level
  end

  def reformat
    "#{@message} (#{@log_level})"
  end
end
