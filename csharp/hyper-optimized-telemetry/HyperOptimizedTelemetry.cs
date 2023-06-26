using System;

public static class TelemetryBuffer
{
    private static readonly byte[] valid_sizes = {2,4,8};

    public static byte[] ToBuffer(long reading)
    {
        sbyte prefix = reading switch {
            >  UInt32.MaxValue and <= Int64.MaxValue  => -8,
            >  Int32.MaxValue  and <= UInt32.MaxValue =>  4,
            >  UInt16.MaxValue and <= Int32.MaxValue  => -4,
            >= 0               and <= UInt16.MaxValue =>  2,
            >= Int16.MinValue  and <= -1              => -2,
            >= Int32.MinValue  and <  Int16.MinValue  => -4,
            >= Int64.MinValue  and <  Int32.MinValue  => -8
        };

        byte[] output = new byte[9];
        output[0] = (byte)prefix;
        BitConverter.GetBytes(reading).CopyTo(output,1);

        for(int i = Math.Abs(prefix) + 1; i < 9; i++ ) {
            output[i] = 0;
        }

        return output;
    }

    public static long FromBuffer(byte[] buffer) =>
        (sbyte) buffer[0] switch {
            -8 => BitConverter.ToInt64(buffer,1),
            -4 => BitConverter.ToInt32(buffer,1),
            -2 => BitConverter.ToInt16(buffer,1),
             2 => BitConverter.ToUInt16(buffer,1),
             4 => BitConverter.ToUInt32(buffer,1),
            _    => 0
        };
}
