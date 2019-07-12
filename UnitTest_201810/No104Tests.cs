using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using LCCommon;
using LC201810;

namespace UnitTestLC201810
{
    [TestFixture]
    public class No104Tests
    {
        private No104 _no104;

        private No104 GetInstance()
        {
            if (_no104 == null)
            {
                _no104 = new No104();
            }
            return _no104;
        }


         

        //[TestCase(_root, 2)]
        [Test]
        public void MaxDepth_DFS_VariousTree_Check(TreeNode root, int expected)
        {
            No104 no104 = GetInstance();

            int actual = no104.MaxDepth_DFS(TreeNode.InitRightTree());

            Assert.AreEqual(expected, actual);
        }
    }
}
