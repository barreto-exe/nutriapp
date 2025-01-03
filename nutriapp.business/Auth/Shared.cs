using System.Security.Cryptography;
using System.Text;

namespace nutriapp.business.Auth;

public static class Shared
{
    public static string EncodeString(this string input)
    {
        // Convert the input string to a byte array
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

        // Compute the hash of the input bytes
        byte[] hashBytes = SHA512.HashData(inputBytes);

        // Convert the hash bytes to a hexadecimal string
        StringBuilder hashString = new();
        foreach (byte b in hashBytes)
        {
            hashString.Append(b.ToString("x2"));
        }

        // Return the hash string
        return hashString.ToString();
    }
}