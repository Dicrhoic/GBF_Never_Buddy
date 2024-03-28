using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GBF_Never_Buddy.Screens.GWCalculator;

namespace GBF_Never_Buddy.Screens
{
    public partial class GWCalculator : UserControl
    {
        enum Raids
        {
            NM90,
            NM95,
            NM100,
            NM150,
            NM200
        }

        enum Honours
        {
            EX = 51000,
            EXP = 80800,
            NM90 = 260000,
            NM95 = 910000,
            NM100 = 2650000,
            NM150 = 4100000,
            NM200 = 13350000,

        }


        int meatRaid = 0;

        public void UpdateMeatRaid()
        {
            switch (meatRaid)
            {
                case 0:
                    meatRaid = 1;
                    break;
                case 1:
                    meatRaid = 0;
                    break;
            }
        }


        public GWCalculator()
        {
            InitializeComponent();
        }

        internal class GWRaids
        {
            int halfPot = 75;
            int maxAP = 999;
            int honours { get; set; }
            double worstTime {  get; set; }
            double bestTime { get; set; }


            public int meat { get; set; }
            public int farmOption = 1;
            public void SetMeatFarm(EX raid)
            {
                farmOption = 0;
            }
            public void SetMeatFarm(EXPlus raid)
            {
                farmOption = 1;
            }
            public decimal MeatCost(decimal battle, int meat)
            {
                decimal cost = battle * meat;
                Debug.WriteLine($"Meat cost: {battle}*{meat}");
                return cost;
            }
            public decimal TokenYield(decimal battles, int token)
            {
                decimal yield = battles * token;
                Debug.WriteLine($"Token yield: {battles}*{token}");
                return yield;
            }
            public decimal HonourYield(decimal battles, int honours)
            {
                decimal yield = battles * honours;
                Debug.WriteLine($"Honour yield: {battles}*{honours}");
                return yield;
            }

            int HonoursEarned(int meat, int honours)
            {
                if (meat <= 0)
                {
                    return 0;
                }
                int maxValue = int.MinValue;
                for (int i = meat; i < 0; i--)
                {
                    var maxHon = honours + HonoursEarned(i, this.honours);
                    maxValue = Math.Max(maxValue, maxHon);
                }
                return maxValue;

            }

            int RunsMade(int honour)
            {
                return honour/this.honours;
            }

            List<TimeSpan> timeSpans (int runs)
            {
                List<TimeSpan> list = new();
                Random random = new Random();
                TimeSpan start = TimeSpan.FromMinutes(bestTime);
                TimeSpan end = TimeSpan.FromMinutes(worstTime);
                int maxMinutes = (int)((end - start).TotalSeconds);

                for (int i = 0; i < runs; i++)
                {
                    int minutes = random.Next(maxMinutes + 1);
                    TimeSpan t = start.Add(TimeSpan.FromMinutes(minutes));
                    list.Add(t);    
                }

                return list;
            }
        }
    }
    class EX : GWRaids
    {
        public int honours = 50000;
        public int token = 22;
        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 0);
        public int meatCost = 5;
    }

    class EXPlus : GWRaids
    {
        public int honours = 80800;
        public int token = 26;
        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 0);
        public int meatCost = 6;
        public string name = "EX+";
    }
    class NM90 : GWRaids
    {
        public int honours = 260000;
        public int token = 45;
        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 5);
        int timeBest;
        int timeWorst;
    }

    class NM95 : GWRaids
    {
        public int honours = 910000;
        public int token = 55;
        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 5);
        int timeBest;
        int timeWorst;
    }

    class NM100 : GWRaids
    {
        public int honours = 2650000;
        public int token = 80;
        public Tuple<int, int> hostCost = new Tuple<int, int>(50, 10);
        int timeBest;
        int timeWorst;
    }
    class NM150 : GWRaids
    {
        public int honours = 4100000;
        public int token = 100;
        public Tuple<int, int> hostCost = new Tuple<int, int>(50, 20);
        int timeBest;
        int timeWorst;
    }
    class NM200 : GWRaids
    {
        string name = "NM 200";
        public int honours = 10250000;
        public int token = 160;
        public Tuple<int, int> hostCost = new Tuple<int, int>(50, 30);
        decimal timeBest;
        decimal timeWorst;

        bool revive;
        int reviveCount = 0;
        decimal target;
    }

 }
