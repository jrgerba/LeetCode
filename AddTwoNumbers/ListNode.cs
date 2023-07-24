using System.Security.AccessControl;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace AddTwoNumbers;

 public class ListNode 
 {
    public int val;
    public ListNode next;

    public override string ToString()
    {
        StringBuilder sb = new();
        ListNode node = this;
        int fullVal = 0;
        int place = 1;

        sb.Append("{ ");

        while (node is not null)
        {
            fullVal += node.val * place;
            place *= 10;

            sb.Append(node.val);
            sb.Append(", ");

            node = node.next;
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Append(" } - ");
        sb.Append(fullVal);

        return sb.ToString();
    }

    public static bool operator ==(ListNode left, ListNode right)
    {
        while (left is not null && right is not null)
        {
            if (left.val != right.val)
                return false;

            left = left.next;
            right = right.next;
        }

        return !(left is null ^ right is null);
    }

    public static bool operator !=(ListNode left, ListNode right)
    {
        return !(left == right);
    }

    public int ToInt()
    {
        ListNode node = this;
        int fullVal = 0;

        while (node is not null)
        {
            fullVal = (fullVal * 10) + node.val;
            node = node.next;
        }

        return fullVal;
    }

    public static ListNode FromInt(int n)
    {
        ListNode first = null;
        ListNode node = null;
        while (n > 0)
        {
            int digit = n - ((n / 10) * 10);

            if (node is null)
            {
                node = new ListNode(digit);
                first = node;
            }
            else
            {
                ListNode newNode = new ListNode(digit);
                node.next = newNode;
                node = newNode;
            }

            n /= 10;
        }

        return first ?? new ListNode();
    }

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
 }