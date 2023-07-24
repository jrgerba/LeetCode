using AddTwoNumbers;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        ListNode solution = new();
        ListNode l3 = null;
        int carry = 0;

        do
        {
            if (l3 is null)
                l3 = solution;
            else
            {
                l3.next = new ListNode();
                l3 = l3.next;
            }

            l3.val = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = l3.val / 10;
            l3.val -= carry * 10;

            l1= l1?.next;
            l2 = l2?.next;
        } while (l1 is not null || l2 is not null || carry != 0);

        return solution;
    }

    public static void Main(string[] args)
    {
        ListNode[][] inputs =
        {
            new[] { ListNode.FromInt(342), ListNode.FromInt(465) },
            new[] { ListNode.FromInt(0), ListNode.FromInt(0) },
            new[] { ListNode.FromInt(9999999), ListNode.FromInt(9999) }
        };
        ListNode[] expectedOutputs = { ListNode.FromInt(807), ListNode.FromInt(0), ListNode.FromInt(10009998) };
        Solution solution = new();

        for (int i = 0; i < inputs.Length; i++)
        {
            ListNode[] input = inputs[i];
            ListNode expected = expectedOutputs[i];
            ListNode output = solution.AddTwoNumbers(input[0], input[1]);

            if (expected == output)
                Console.WriteLine($"Case {i} passed");
            else
            {
                Console.WriteLine($"Case {i} Failed:");
                Console.WriteLine($"\tInput 1: {input[0]}");
                Console.WriteLine($"\tInput 2: {input[1]}");
                Console.WriteLine($"\tOutput: {output}");
                Console.WriteLine($"\tExpected output: {expected}");
            }
        }
    }
}