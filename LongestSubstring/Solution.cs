public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length < 2)
            return s.Length;

        HashSet<char> charMap = new();
        int start = 0;
        int end = 1;
        int longest = 0;

        charMap.Add(s[0]);

        while (end < s.Length)
        {
            char eChar = s[end];

            if (charMap.Contains(eChar))
            {
                while (true)
                {
                    char sChar = s[start];
                    charMap.Remove(sChar);
                    start++;

                    if (sChar == eChar)
                        break;
                }
            }
            else
            {
                charMap.Add(eChar);

                end++;

                if (longest < end - start)
                    longest = end - start;
            }
        }

        return longest;
    }

    public static void Main(string[] args)
    {
        string[] inputs =
        {
            "abcabcbb",
            "bbbbb",
            "pwwkew",
            "au"
        };
        int[] expectedOut = { 3, 1, 3, 2 };
        Solution solution = new();

        for (int i = 0; i < inputs.Length; i++)
        {
            string input = inputs[i];
            int expected = expectedOut[i];
            int result = solution.LengthOfLongestSubstring(input);

            Console.WriteLine(expected == result
                ? $"Case {i} passed!"
                : $"Case {i} failed:\n\tResult: {result}\n\tExpected: {expected}");
        }
    }
}