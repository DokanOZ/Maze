namespace Maze
{
    internal class Cipher
    {
        public static string CaesarEncoder(string input, int key)
        {
            string output = string.Empty;

            foreach (char c in input)
            {
                output += CipherCharacters(c, key);
            }
            return output;
        }

        public static string Decipher(string input, int key)
        {
            return CaesarEncoder(input, 26 - key);
        }

        private static char CipherCharacters(char c, int key)
        {
            if (!char.IsLetter(c))
            {

                return c;
            }

            char e = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + key) - e) % 26) + e);
        }
    }
}
