using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwordOffer.Structure;

namespace SwordOffer.Tests
{
    [TestClass()]
    public class EntryNodeOfCycleTests
    {
        [TestMethod()]
        public void FindEntryTest()
        {
            var finder = new EntryNodeOfCycle();

            // 1. 无环链表
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            node1.next = node2;
            node2.next = node3;
            node3.next = null;
            Assert.IsNull(finder.FindEntry(node1));

            // 2. 有环，入口为头节点
            var head = new ListNode(10);
            var n2 = new ListNode(20);
            var n3 = new ListNode(30);
            head.next = n2;
            n2.next = n3;
            n3.next = head;
            Assert.AreEqual(head, finder.FindEntry(head));

            // 3. 有环，入口为中间节点
            var a = new ListNode(100);
            var b = new ListNode(200);
            var c = new ListNode(300);
            var d = new ListNode(400);
            a.next = b;
            b.next = c;
            c.next = d;
            d.next = b; // 环入口为 b
            Assert.AreEqual(b, finder.FindEntry(a));

            // 4. 头节点为空
            Assert.IsNull(finder.FindEntry(null));
        }
    }
}