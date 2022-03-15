
using System.Text;

namespace Lab1;

public class Main1
{
    private static void Main()
    {
        // Пример работы RSA шифровальщика/дешифровальщика:

        var rsa = new RSA();
        rsa.Encrypt();
        
        // Результат шифрования в файле "output.txt"
        // Дешифруем!
        
        rsa.Decrypt();
        
        // Результат дешифрования в "result.txt"
    }
}