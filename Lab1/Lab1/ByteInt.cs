
namespace Lab1;

public class ByteInt
{
    private byte[] bytesNumber;

    public ByteInt() => bytesNumber = new byte[4];

    public ByteInt(int number) => bytesNumber = BitConverter.GetBytes(number);

    ~ByteInt() => Console.WriteLine("ByteInt is died!");

    public int Convert2Int()
    {
        return BitConverter.ToInt32(this.bytesNumber);
    }

    public static ByteInt operator +(ByteInt a, ByteInt b)
    {
        ByteInt result = new ByteInt();
        
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);
        
        result.bytesNumber = BitConverter.GetBytes(nA + nB);

        return result;
    }

    public static ByteInt operator -(ByteInt a, ByteInt b)
    {
        ByteInt result = new ByteInt();
        
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        result.bytesNumber = BitConverter.GetBytes(nA - nB);

        return result;
    }

    public static ByteInt operator *(ByteInt a, ByteInt b)
    {
        ByteInt result = new ByteInt();
        
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        result.bytesNumber = BitConverter.GetBytes(nA * nB);

        return result;
    }
    
    public static ByteInt operator /(ByteInt a, ByteInt b)
    {
        ByteInt result = new ByteInt();
        
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        result.bytesNumber = BitConverter.GetBytes(nA / nB);

        return result;
    }
    
    public static ByteInt operator %(ByteInt a, ByteInt b)
    {
        ByteInt result = new ByteInt();
        
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        result.bytesNumber = BitConverter.GetBytes(nA % nB);

        return result;
    }
    
    public static bool operator ==(ByteInt a, ByteInt b)
    {
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        return nA == nB;
    }
    
    public static bool operator !=(ByteInt a, ByteInt b)
    {
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        return nA != nB;
    }
    
    public static bool operator >(ByteInt a, ByteInt b)
    {
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        return nA > nB;
    }
    
    public static bool operator <(ByteInt a, ByteInt b)
    {
        var nA = BitConverter.ToInt32(a.bytesNumber);
        var nB = BitConverter.ToInt32(b.bytesNumber);

        return nA < nB;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    protected bool Equals(ByteInt other)
    {
        return bytesNumber.Equals(other.bytesNumber);
    }

    public override int GetHashCode()
    {
        return bytesNumber.GetHashCode();
    }
}