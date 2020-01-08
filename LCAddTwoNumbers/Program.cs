//attempt at stack solution that will fail. Neds to be able to handle much larger numbers & return a ListNode with the numbers at the end.

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {

        Stack<int> aStack = new Stack<int>();
        Stack<int> bStack = new Stack<int>();

        aStack.Push(l1.val);
        bStack.Push(l2.val);

        int a = 0;
        int b = 0;

        while (aStack.Count() > 0)
        {
            a = (a * 10) + aStack.Peek();
            aStack.Pop();
        }

        while (bStack.Count() > 0)
        {
            b = (b * 10) + bStack.Peek();
            bStack.Pop();
        }

        int addedSum = a + b;

        Stack<int> sumStack = new Stack<int>();

        while (addedSum != 0)
        {
            sumStack.Push(addedSum % 10);
            addedSum = addedSum / 10;
        }

        ListNode result;

        while (sumStack.Count() > 0)
        {
            result.Value = sumStack.Peek();
            sumStack.Pop();
        }
        return result;
    }
}



//borrowed solution to dig in to
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode response;

        var sum = l1.val + l2.val;

        if (sum > 9)
        {
            response = new ListNode(sum % 10);
            SumRecur(l1.next, l2.next, response, 1);
        }
        else
        {
            response = new ListNode(sum);
            SumRecur(l1.next, l2.next, response, 0);
        }

        return response;
    }

    public void SumRecur(ListNode l1, ListNode l2, ListNode response, int cof)
    {
        if (l1 != null || l2 != null || cof > 0)
        {
            var sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + cof;

            if (sum > 9)
            {
                sum = sum % 10;
                response.next = new ListNode(sum);
                SumRecur(l1?.next, l2?.next, response.next, 1);
            }
            else
            {
                response.next = new ListNode(sum);
                SumRecur(l1?.next, l2?.next, response.next, 0);
            }
        }
    }
}