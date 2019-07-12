using System;
using LCCommon;

namespace LC201810
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] flowerbed = { 1, 0 };
            //int n = 1;

            //No103 no103 = new No103();
            //no103.ZigzagLevelOrder(TreeNode.Init());

            No104 no104 = new No104();
            int high = no104.MaxDepth_DFS(TreeNode.InitRightTree());

            //No107 no107 = new No107();
            //no107.LevelOrderBottom(TreeNode.Init());

            //No111 no111 = new No111();
            //no111.MinDepth_DFS(TreeNode.Init());

            //No605 no605 = new No605();
            //no605.CanPlaceFlowers(flowerbed, 2);

            //No637 no637 = new No637();
            //no637.AverageOfLevels(no637.Init());



            Console.ReadKey();
        }
    }
}
