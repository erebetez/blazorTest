using System.Text;
using System.Text.Json;
using System.Security.Cryptography;

public class SaveData
{
    public static async Task SaveTodoItems(List<TodoItem> todoItems)
    {
        Console.WriteLine("now in save func");

        string jsonString = JsonSerializer.Serialize(todoItems);

        Console.WriteLine(jsonString);

        using (SHA256 sha256Hash = SHA256.Create())
        {
            string hash = GetHash(sha256Hash, jsonString);

            Console.WriteLine(hash);

            await File.WriteAllTextAsync(hash + ".json", jsonString);
        }
    }

    private static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        var sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }


    // Verify a hash against a string.
    private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
    {
        // Hash the input.
        var hashOfInput = GetHash(hashAlgorithm, input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        return comparer.Compare(hashOfInput, hash) == 0;
    }
}