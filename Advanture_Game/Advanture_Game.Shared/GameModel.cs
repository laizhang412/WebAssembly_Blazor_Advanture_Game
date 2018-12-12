using System;
using System.Collections.Generic;
using System.Text;

namespace Advanture_Game.Shared
{
    public class GameModel
    {
        public int[] gridList { get; set; }
        public int difficulty { get; set; }
        public int initial { get; set; }
        //public List<Step> steps;
        //public Step curStep { get; set; }
        public GameModel()
        {
            Random r = new Random();
            this.difficulty = 10;
            this.gridList = new int[difficulty*difficulty];
            for (int i = 0; i < gridList.Length; i++) gridList[i] = r.Next(-10, 3);
            //this.initial = 10;
            //this.grid = new int[10];
            //this.grid = new int[difficulty, difficulty];
            //for (int i = 0; i < difficulty; i++) for (int j = 0; j < difficulty; j++) grid[i, j] = r.Next(-10, 3);
            this.initial = GetInitial(this.gridList);
            //this.steps = new List<Step>();
            //steps.Add(new Step());
            //this.curStep = new Step(0, 0, initial, true);
            //steps.Add(first);
        }

        private int GetInitial(int[] dungeonList)
        {
            int[,] dungeon = new int[difficulty, difficulty];
            for (int i = 0; i < difficulty; i++)
                for (int j = 0; j < difficulty; j++)
                    dungeon[i, j] = dungeonList[i * difficulty + j];
            int m = dungeon.GetLength(0);
            int n = dungeon.GetLength(1);
            int[,] health = new int[m, n];
            health[m - 1, n - 1] = Math.Max(1 - dungeon[m - 1, n - 1], 1);
            for (int i = m - 2; i >= 0; i--)
            {
                health[i, n - 1] = Math.Max(health[i + 1, n - 1] - dungeon[i, n - 1], 1);
            }
            for (int j = n - 2; j >= 0; j--)
            {
                health[m - 1, j] = Math.Max(health[m - 1, j + 1] - dungeon[m - 1, j], 1);
            }
            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    int down = Math.Max(health[i + 1, j] - dungeon[i, j], 1);
                    int right = Math.Max(health[i, j + 1] - dungeon[i, j], 1);
                    health[i, j] = Math.Min(right, down);
                }
            }
            return health[0, 0] + dungeon[0, 0];
        }

    }
}
