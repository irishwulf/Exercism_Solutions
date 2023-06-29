using System;

public class CircularBuffer<T>
{
    private T[] buffer;
    private int nextWrite = 0;
    private int nextRead = 0;
    private int filledSlots = 0;

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];    
    }

    public T Read() {
        T result;

        if (filledSlots == 0) throw new InvalidOperationException("Cannot read from empty buffer.");
        result = buffer[nextRead];
        nextRead = (nextRead + 1) % buffer.Length;
        filledSlots--;

        return result;
    }

    public void Write(T value)
    {
        if (filledSlots == buffer.Length) throw new InvalidOperationException("Cannot write to full buffer.");
        buffer[nextWrite] = value;
        nextWrite = (nextWrite + 1) % buffer.Length;
        filledSlots++;
    }

    public void Overwrite(T value) {
        if (filledSlots == buffer.Length) Read();
        Write(value);
    }

    public void Clear() =>
        filledSlots = 0;
}