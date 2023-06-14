using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedListWithErrors;
using System.Xml.Linq;


namespace Unit_Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()  //Adding value to Head
        {
            DLList lst = new DLList(); //Create list
            DLLNode p = new DLLNode(7); //Add value in node
            lst.addToHead(p); //Add value to head
            Assert.AreEqual(lst.head.num, 7); //Checks value
        }
        [TestMethod]
        public void TestMethod2()  //Adding value to tail
        {
            DLList lst = new DLList();
            DLLNode p = new DLLNode(21);    
            lst.addToTail(p);
            Assert.AreEqual(lst.tail.num, 21);
        }

        [TestMethod]
        public void TestMethod3()  //Test empty list
        {
            DLList lst = new DLList();
            Assert.IsNull(lst.head);
            Assert.IsNull(lst.tail);
            Assert.AreEqual(0,0);
        }

        [TestMethod]
        public void TestMethod4()  //Remove tail value
        {
            DLList lst = new DLList();
            DLLNode p = new DLLNode(20);
            lst.addToTail(p);
            lst.removeTail();
            Assert.IsNull(lst.tail);
        }

        [TestMethod]
        public void TestMethod5()  //Remove head value
        {
            DLList lst = new DLList();
            DLLNode p = new DLLNode(20);
            lst.addToHead(p);
            lst.removHead();
            Assert.IsNull(lst.head);
        }

        [TestMethod]
        public void TestMethod6()  //Checks if addToHead has next head
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(20);
            DLLNode b = new DLLNode(30);
            lst.addToHead(a);
            lst.addToHead(b);
            Assert.AreEqual(lst.head.next, a);
        }

        [TestMethod] //Checks if addToTail has previous tailnode
        public void TestMethod7()
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(20);
            DLLNode b = new DLLNode(30);
            lst.addToTail(a);
            lst.addToTail(b);
            Assert.AreEqual(lst.tail.previous, a);
        }

        [TestMethod]
        public void TestMethod8() //Search for specific number
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(30);
            DLLNode b = new DLLNode(20);
            DLLNode c = new DLLNode(50);
            lst.addToTail(a);
            lst.addToTail(b);
            lst.addToTail(c);
            DLLNode node2 = lst.search(20);
            Assert.AreEqual(node2.num, 20);
        }

        [TestMethod]
        public void TestMethod9() //Search for specific number that doesn't 'exist'
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(30);
            DLLNode b = new DLLNode(20);
            DLLNode c = new DLLNode(50);
            lst.addToTail(a);
            lst.addToTail(b);
            lst.addToTail(c);
            DLLNode node5 = lst.search(80);
            Assert.IsNull(node5);
        }

        [TestMethod]
        public void TestMethod10() //Search for specific node that has already been deleted
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(20);
            DLLNode b = new DLLNode(30);
            DLLNode c = new DLLNode(40);
            lst.addToHead(a);
            lst.addToHead(b);
            lst.addToHead(c);
            lst.removeNode(b);
            Assert.IsNull(lst.search(30));
        }
        public void TestMethod11() //Total list on one node
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(50);
            lst.addToHead(a);
            Assert.AreEqual(lst.total(), 50);
        }

        [TestMethod]
        public void TestMethod12() //Total with empty list
        {
            DLList lst = new DLList();
            Assert.AreEqual(lst.total(), 0);
        }

        [TestMethod]
        public void TestMethod13() //Total with multiple node
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(50);
            DLLNode b = new DLLNode(30);
            DLLNode c = new DLLNode(10);
            lst.addToHead(a);
            lst.addToHead(b);
            lst.addToHead(c);
            Assert.AreEqual(lst.total(), 90);
        }

        public void TestMethod14() //Total with multiple node when one node removed
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(50);
            DLLNode b = new DLLNode(30);
            DLLNode c = new DLLNode(10);
            lst.addToHead(a);
            lst.addToHead(b);
            lst.addToHead(c);
            lst.removeNode(b);
            Assert.AreEqual(lst.total(), 60);
        }
        public void TestMethod15() //Total with multiple node when one node removed
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(50);
            DLLNode b = new DLLNode(30);
            DLLNode c = new DLLNode(10);
            lst.addToHead(a);
            lst.addToHead(b);
            lst.addToHead(c);
            lst.removeNode(b);
            Assert.AreEqual(lst.total(), 60);
        }
        [TestMethod]
        public void TestMethod16()  //Check node added to position previous to head
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(20);
            DLLNode b = new DLLNode(10);
            lst.addToHead(a);
            //Adding b to previous head
            lst.head.previous = b;
            b.next = lst.head;
            lst.head = b;
            Assert.AreEqual(10, lst.head.num);
        }

        [TestMethod]
        public void TestMethod17()  //Check value is in previous node of tail
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(20);
            DLLNode b = new DLLNode(10);
            DLLNode c = new DLLNode(30);
            lst.addToHead(b);
            lst.addToHead(a);
            lst.addToTail(c);
            Assert.AreEqual(10, lst.tail.previous.num);
        }

        [TestMethod]
        public void TestMethod18() //Check value of node after tail
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(20);
            DLLNode b = new DLLNode(10);
            lst.addToTail(b);
            lst.addToTail(a);
            Assert.IsNull(lst.tail.next);
        }

        [TestMethod]
        public void TestMethod19() //Adding negative value to head
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(-20);
            lst.addToHead(a);
            Assert.AreEqual(-20, lst.head.num);
        }

        public void TestMethod20() //Adding negative value to tail
        {
            DLList lst = new DLList();
            DLLNode a = new DLLNode(-20);
            lst.addToTail(a);
            Assert.AreEqual(-20, lst.tail.num);
        }


    }

}