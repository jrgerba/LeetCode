namespace LeetCode.TwoSum;

public class Solution
{
    public int[]? TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> sumPairs = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            if (sumPairs.ContainsKey(num))
                continue;

            sumPairs.Add(num, i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            int pair = target - num;

            if (sumPairs.ContainsKey(pair) && sumPairs[pair] != i)
                return new[] { i, sumPairs[pair] };
        }

        return null;
    }

    public static void Main(string[] args)
    {
        int[][] cases = {
            new[] { 2, 7, 11, 15 },
            new[] { 3, 2, 4 },
            new[] { 3, 3 }
        };
        int[][] expected =
        {
            new[] { 0, 1 },
            new[] { 1, 2 },
            new[] { 1, 0 },
        };
        int[] targets = { 9, 6, 6 };

        Solution solution = new();

        for (int i = 0; i < cases.Length; i++)
        {
            int[] @case = cases[i];
            int[] curExpected = expected[i];
            int target = targets[i];

            int[]? output = solution.TwoSum(@case, target);

            if (output is null)
            {
                Console.WriteLine($"Case {i} failed (output is null)");
                return;
            }

            Array.Sort(@case);
            Array.Sort(output);

            if (curExpected.Length == output.Length && curExpected.Intersect(output).Count() == curExpected.Length)
                Console.WriteLine($"Case {i} passed!");
            else
            {
                Console.WriteLine($"Case {i} failed");
                Console.WriteLine($"\texpected: {curExpected[0]}, {curExpected[1]}");
                Console.WriteLine($"\toutput: {output[0]}, {output[1]}");
            }
        }
    }
}