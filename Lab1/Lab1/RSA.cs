using System.Numerics;

namespace Lab1;

public class RSA
{
    char[] alphabet = new char[]
    {
        'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 
        'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р',
        'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ',
        'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я', 'а', 'б', 'в',
        'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к',
        'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
        'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ',
        'э', 'ю', 'я', ',', '.', ' ', '?', '1', '2', '3',
        '4', '5', '6', '7', '8', '9', '0'
    };

    public void Encrypt()
    {
        const long p = 421;
        const long q = 431;
        var str = "";
        
        var streamReader = new StreamReader("input.txt");
        while (!streamReader.EndOfStream)
        {
            str += streamReader.ReadLine();
        }
        streamReader.Close();

        var n = p * q;
        var m = (p - 1) * (q - 1);
        var d = GiveD(m);
        var e = GiveE(d, m);
            
        List<string> result = RSA_Encrypt(str, e, n);
            
        StreamWriter streamWriter = new StreamWriter("output.txt");
        foreach (string item in result)
            streamWriter.WriteLine(item);
        streamWriter.Close();

        StreamWriter sw1 = new StreamWriter("keysDnN.txt");
        sw1.WriteLine(d);
        sw1.WriteLine(n);
        sw1.Close();
        
    }

    public void Encrypt(string s)
    {
        var streamWriter = new StreamWriter("input.txt");
        streamWriter.WriteLine(s);
        streamWriter.Close();
        
        Encrypt();
    }

    public void Decrypt(string fileNameWithOut = "output.txt", string fileNameWithDnN = "keysDnN.txt")
    {
        var streamReader = new StreamReader(fileNameWithDnN);
        
        var input = new List<string?>();
        var d = Convert.ToInt64(streamReader.ReadLine());
        var n = Convert.ToInt64(streamReader.ReadLine());
        
        streamReader.Close();

        var streamReader1 = new StreamReader(fileNameWithOut);
        while (!streamReader1.EndOfStream)
        {
            input.Add(streamReader1.ReadLine());
        }
        streamReader1.Close();
 
        string result = RSA_Dedoce(input, d, n);
        
        StreamWriter streamWriter = new StreamWriter("result.txt");
        streamWriter.WriteLine(result);
        streamWriter.Close();
    }
    
    private List<string> RSA_Encrypt(string s, long e, long n)
    {
        var result = new List<string>();

        for (int i = 0; i < s.Length; i++)
        {
            int index = Array.IndexOf(alphabet, s[i]);

            var bigInteger = new BigInteger(index);
            bigInteger = BigInteger.Pow(bigInteger, (int)e);
            
            bigInteger = bigInteger % n;

            result.Add(bigInteger.ToString());
        }

        return result;
    }
    
    private string RSA_Dedoce(List<string?> input, long d, long n)
    {
        var result = "";

        foreach (var item in input)
        {
            var bigInteger = new BigInteger(Convert.ToDouble(item));
            
            bigInteger = BigInteger.Pow(bigInteger, (int)d);
            bigInteger = bigInteger % n;

            var index = Convert.ToInt32(bigInteger.ToString());

            result += alphabet[index].ToString();
        }

        return result;
    }
    
    private bool IsSimpleNum(long n)
    {
        if (n < 2)
            return false;

        if (n == 2)
            return true;

        for (long i = 2; i < n; i++)
            if (n % i == 0)
                return false;

        return true;
    }

    private long GiveD(long m)
    {
        long d = m - 1;
        for (long i = 2; i <= m; i++)
            if ((m % i == 0) && (d % i == 0))
            {
                d--;
                i = 1;
            }

        return d;
    }

    private long GiveE(long d, long m)
    {
        long e = 10;
        while (true)
        {
            if ((e * d) % m == 1)
                break;
            else
                e++;
        }
 
        return e;
    }
}