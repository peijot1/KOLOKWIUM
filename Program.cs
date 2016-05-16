using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kolokwium_PJ
{
    class Program
    {
        public static List<int> AA = new List<int>();
        public static List<int> BB = new List<int>();

        static void Main(string[] args)
        {

        }
        
        //<summary>Search first fish moving upstream.</summary>
        //<param name = "A">Sizes of the fish</param>
        //<param name = "B">Directions of the fish</param>
        //<param name = "actually"> actually first up stream fish</param>
        //method returns int actually which is position of actually first up stream fish 
        
        public static int FirstUpStream(int[] A, int[] B, int actually)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (B[i] == 1)
                {
                    actually = i;
                    break;
                }
            }
            return actually;
        }

        public static void AliveFish(int[] A, int[] B)
        {
            int actually = 0;
            actually = FirstUpStream(A, B, actually);
            for (int i = 0; i < A.Length; i++)
            {
                while (i < actually)
                {
                    AA.Add(A[i]);
                    BB.Add(B[i]);
                    i++;
                }

                if (B[actually] != B[i])
                {
                    if (A[actually] < A[i])
                    {
                        actually = i;
                    }

                }

            }
            AA.Add(A[actually]);
            BB.Add(B[actually]);

        }
    }
    [TestClass]
    public class MyTestClass
    {
        int[] A = new int[] { 8, 6, 7, 4, 3, 2, 1, 5 };
        int[] B = new int[] { 0, 0, 0, 0, 1, 0, 0, 0 };

        [TestMethod]
        public void TestFirstUpStream()
        {
            Assert.AreEqual(Program.FirstUpStream(A, B, 0), 4);
        }

        [TestMethod]
        public void TestAliveFish()
        {
            Program.AliveFish(A, B);
            Assert.AreEqual((Program.AA).Count, 5);
        }
        [TestMethod]
        public void TestAliveFish2()
        {
            List<int> A1 = new List<int>();
            A1.Add(8); A1.Add(6); A1.Add(7); A1.Add(4); A1.Add(5);
            List<int> B1 = new List<int>();
            B1.Add(0); B1.Add(0); B1.Add(0); B1.Add(0); B1.Add(0);
            Program.AliveFish(A, B);
            for (int i = 0; i < A1.Count; i++)
            {
                Assert.AreEqual(((Program.AA)[i]), A1[i]);
                Assert.AreEqual((Program.BB)[i], B1[i]);
            }
        }
    }
}
