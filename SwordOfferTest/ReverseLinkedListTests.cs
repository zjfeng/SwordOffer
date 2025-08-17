using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwordOffer;
using SwordOffer.Structure;
using System;

namespace SwordOffer.Tests
{
    [TestClass()]
    public class ReverseLinkedListTests
    {
        [TestMethod()]
        public void ReverseTest()
        {
            var reverseLinkedList = new ReverseLinkedList();

            // 测试空链表
            ListNode head = null;
            var result = reverseLinkedList.Reverse(head);
            Assert.IsNull(result);

            // 测试单节点链表
            head = new ListNode(1);
            result = reverseLinkedList.Reverse(head);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.val);
            Assert.IsNull(result.next);

            // 测试多节点链表
            head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                }
            };
            result = reverseLinkedList.Reverse(head);

            // 断言反转后顺序为 3 -> 2 -> 1
            Assert.AreEqual(3, result.val);
            Assert.AreEqual(2, result.next.val);
            Assert.AreEqual(1, result.next.next.val);
            Assert.IsNull(result.next.next.next);
        }
    }
}