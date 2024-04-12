using GBF_Never_Buddy.Classes;
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
using System.Xml.Linq;
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

        List<Tuple<string, RaidRow>> rows = new();

        public GWCalculator()
        {
            InitializeComponent();
        }

        private void GetCheckedValues() 
        {
            decimal target = numericUpDown5.Value;
            if(rows.Count > 0 )
            {   
                BST bst = new BST();
                foreach (var c in rows)
                {
                    RaidRow row = (RaidRow)c.Item2;
                    var rt = row.getTimes();
                    string raidType = c.Item1;
                    if(rt.Sum() > 1 )
                    {
                        switch (raidType)
                        {
                            case "NM90":
                                NM90 nM90 = (NM90)row.r;
                                nM90.worstTime = rt[0];
                                nM90.bestTime = rt[1];
                                nM90.target = Decimal.ToInt32(target);
                                bst.insert(nM90.EffDepthScoreP());                              
                                break;
                            case "NM95":
                                NM95 nM95 = (NM95)row.r;
                                nM95.worstTime = rt[0];
                                nM95.bestTime = rt[1];
                                nM95.target = Decimal.ToInt32(target);
                                bst.insert(nM95.EffDepthScoreP());
                                break;
                            case "NM100":
                                NM100 nM100 = (NM100)row.r;
                                nM100.worstTime = rt[0];
                                nM100.bestTime = rt[1];
                                nM100.target = Decimal.ToInt32(target);
                                bst.insert(nM100.EffDepthScoreP());
                                break;
                            case "NM150":
                                NM150 nM150 = (NM150)row.r;
                                nM150.worstTime = rt[0];
                                nM150.bestTime = rt[1];
                                nM150.target = Decimal.ToInt32(target);
                                bst.insert(nM150.EffDepthScoreP());
                                break;
                            case "NM200":
                                NM200 nM200 = (NM200)row.r;
                                nM200.worstTime = rt[0];
                                nM200.bestTime = rt[1];
                                nM200.target = Decimal.ToInt32(target);
                                bst.insert(nM200.EffDepthScoreP());
                                break;
                        }
                    }                  
                }
                Debug.WriteLine(bst.MaxValue());
            }
         
        }

        private void Calculate(object sender, EventArgs e)
        {
            GetCheckedValues();
            decimal bestTime = 9;
            decimal worstTime = 15;
            decimal target = numericUpDown5.Value;
            decimal current = numericUpDown3.Value;
            decimal targetHonours = (decimal)(target - current);
            int meat = (int)meatNumeric.Value;
            NM200 nM200 = new(false, bestTime, worstTime, targetHonours);
            if (meat > 0)
            {
                nM200.meatHeld = meat;
                Debug.WriteLine($"Meat: " + nM200.meatHeld);
            }
            switch (exPOtpnRB.Checked)
            {
                case true:
                    EXPlus exP = new();
                    nM200.SetMeatFarm(exP);
                    break;
                case false:
                    EX ex = new();
                    nM200.SetMeatFarm(ex);
                    break;
            }
            // int rate = nM200.EffScore();
   
        }
        public class GWRaids
        {
            public string name { get; set; }
            int halfPot = 75;
            int maxAP = 999;

            public int honours { get; set; }
            public double worstTime { get; set; }
            public double bestTime { get; set; }
            public long target;
            public int cost { get; set; }
            public long meatHeld { get; set; }
            public int farmOption = 1;
            public int meatUsage = 0;
            public long currentHonours = 0;
            public int token { get; set; }
            public void SetMeatFarm(EX raid)
            {
                farmOption = 0;
            }
            public void SetMeatFarm(EXPlus raid)
            {
                farmOption = 1;
            }
            public decimal MeatCost(decimal battle, long meat)
            {
                decimal cost = battle * meat;
                Debug.WriteLine($"Meat cost: {battle}*{meat}");
                return cost;
            }
            public long MeatCostF(decimal battle, long meat)
            {
                long b = Convert.ToInt64(battle);
                long cost = b * meat;
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

            public long HonoursEarnedF(long meat, int honours)
            {
                long maxValue = 0;
                long depth = meat;
                while (depth > 0)
                {
                    maxValue += honours;
                    depth = depth - cost;
                    meatHeld -= cost;
                }
                return maxValue;
            }

            public long HonoursEarned(long meat, long honours)
            {
                long maxValue = 0;
                long depth = meat;
                while (depth > 0)
                {
                    maxValue += honours;
                    depth = depth - cost;
                    meatHeld -= cost;
                }
                /**
                if (meat <= 0)
                {
                    return 0;
                }
                int maxValue = int.MinValue;
                int maxRuns = meat / cost;
                for (int i = 0; i < maxRuns; i++)
                {
                    var maxHon = honours + HonoursEarned(meat - cost, honours);
                    maxValue = Math.Max(maxValue, maxHon);


                }
                **/
                return maxValue;

            }

            int RunsMade(int honour)
            {
                return honour / this.honours;
            }
            public List<TimeSpan> timeSpansP(long runs)
            {
                List<TimeSpan> list = new();
                Random random = new Random();
                TimeSpan start = TimeSpan.FromMinutes(bestTime);
                TimeSpan end = TimeSpan.FromMinutes(worstTime);
                var degreeOfParallelism = Environment.ProcessorCount;
                int maxMinutes = (int)((end - start).TotalSeconds);
                Debug.WriteLine($"S:{start} E: {end} MaxMinutes:{maxMinutes}");
                Parallel.For(0, degreeOfParallelism, runs =>
                {
                    int seconds = random.Next(maxMinutes + 1);
                    TimeSpan t = start.Add(TimeSpan.FromSeconds(seconds));
                    Debug.WriteLine($"t:{t} seconds:{seconds}");
                    list.Add(t);
                });
             
                return list;
            }
            public List<TimeSpan> timeSpans(long runs)
            {
                List<TimeSpan> list = new();
                Random random = new Random();
                TimeSpan start = TimeSpan.FromMinutes(bestTime);
                TimeSpan end = TimeSpan.FromMinutes(worstTime);
                int maxMinutes = (int)((end - start).TotalSeconds);
                Debug.WriteLine($"S:{start} E: {end} MaxMinutes:{maxMinutes}");
                for (int i = 0; i < runs; i++)
                {
                    int seconds = random.Next(maxMinutes + 1);
                    TimeSpan t = start.Add(TimeSpan.FromSeconds(seconds));
                    Debug.WriteLine($"t:{t} seconds:{seconds}");
                    list.Add(t);
                }

                return list;
            }

            public long EffDepthScoreP()
            {
                long score = -1;
                Debug.WriteLine($"Calculating depth score with: {meatHeld} meat for target {Convert.ToInt64(target)}");
                long runs = 0;
                long honoursYields = 0;
                List<long> ac = new();
                if (currentHonours < target && target > 0)
                {
                    ac = AdditionalCosts();
                    var b = ac[3];
                    var l = GetHonoursDepth(b);
                    runs = b;
                    double wt = worstTime;
                    double bt = bestTime;
                    this.bestTime = bt;
                    this.worstTime = wt;
                    var tscores = timeSpansP(runs);
                    tscores.Sort();
                    honoursYields = l.Sum();
                    honoursYields += ac[1];
                    Debug.WriteLine(tscores.Count());
                    Debug.WriteLine($"Honours from {this.name}: {honoursYields}");
                    Debug.WriteLine($"Time Score from {name}: {tscores[tscores.Count / 2]}");
                    int totalMins = (int)tscores[tscores.Count / 2].TotalMinutes;
                    Debug.WriteLine($"HPM: {honoursYields / totalMins} totalMins: {totalMins} from {runs} battles");
                    if (ac.Count == 3 && ac[0] > 0)
                    {
                        totalMins += Convert.ToInt32(ac[0]);
                    }
                    long mins = totalMins;
                    score = honoursYields / mins;
                }
                return score;
            }

            private List<int> GetHonoursDepth(long battles)
            {
                var degreeOfParallelism = Environment.ProcessorCount;
                List<int> list = new();
                Parallel.For(0, degreeOfParallelism, battles =>
                {
                    list.Add(honours);
                });
                return list;
            }

            public float EffDepthScore()
            {

                float score = -1;
                Debug.WriteLine($"Calculating depth score with: {meatHeld} meat for target {Convert.ToInt64(target)}");
                long runs = 0;
                long honoursYields = 0;
                List<long> ac = new();
                Debug.WriteLine(Math.Max(target, Int32.MaxValue));
                Debug.WriteLine(target > Int32.MaxValue);
                if (currentHonours < target && target > 0)
                {
                    Debug.WriteLine("Phase 1");
                        while(currentHonours < target)
                        {
                            Debug.WriteLine($"Current meat: {meatHeld}");
                            if(meatHeld > cost)
                            {
                                runs = meatHeld / cost;
                                honoursYields = this.HonoursEarnedF(meatHeld, this.honours);
                                currentHonours = honoursYields;
                            }
                            else
                            {
                                float costs = target;
                                if(currentHonours > 0)
                                {
                                    costs = target - currentHonours;
                                }
                                Debug.WriteLine("Insufficient meat");
                                ac = AdditionalCosts();                             
                                honoursYields += ac[1];
                                long mr = Convert.ToInt64(ac[2]);
                                //int m = (int)Math.Round(ac[2]);
                                meatHeld += mr;

                            }
                        }
                        double wt = worstTime;
                        double bt = bestTime;
                        this.bestTime = bt;
                        this.worstTime = wt;
                        var tscores = timeSpans(runs);
                        tscores.Sort();
                        Debug.WriteLine(tscores.Count());
                        Debug.WriteLine($"Honours from {this.name}: {honoursYields}");
                        Debug.WriteLine($"Time Score from {name}: {tscores[tscores.Count / 2]}");
                        int totalMins = (int)tscores[tscores.Count / 2].TotalMinutes;
                        Debug.WriteLine($"HPM: {honoursYields / totalMins} totalMins: {totalMins}");
                        if (ac.Count == 3 && ac[0] > 0)
                        {
                            totalMins += Convert.ToInt32(ac[0]);
                        }
                        float mins = (float)totalMins;
                        score = honoursYields / mins;
                    }         
                return score;
            }

            public long EffScore()
            {
                Debug.WriteLine($"Calculating depth with: {meatHeld} meat");
                long runs = 0;
                long honoursYields = 0;
                runs = meatHeld / cost;
                honoursYields = this.HonoursEarned(meatHeld, this.honours);
                double wt = worstTime;
                double bt = bestTime; 
                this.bestTime = bt;
                this.worstTime = wt;
                var tscores = timeSpans(runs);
                tscores.Sort();
                Debug.WriteLine(tscores.Count());
                Debug.WriteLine($"Honours from {this.name}: {honoursYields}");
                Debug.WriteLine($"Time Score from {name}: {tscores[tscores.Count / 2]}");
                int totalMins = (int)tscores[tscores.Count / 2].TotalMinutes;
                Debug.WriteLine($"HPM: {honoursYields / totalMins} totalMins: {totalMins}");
                long score = honoursYields / totalMins;
                return score;
            }

            List<long> AdditionalCosts()
            {
                List<long> list = new();
                decimal requiredBattles = 0;
                long h = Convert.ToInt64(currentHonours);
                Debug.WriteLine($"Required Honours: {h}"); 
                if(currentHonours > 1)
                {
                    requiredBattles = Decimal.Divide((decimal)target, (decimal)currentHonours);
                }
                else
                {
                    requiredBattles = Decimal.Divide((decimal)target, (decimal)honours);

                }
                Debug.WriteLine($"ReqBattles: {requiredBattles}");
                long meat = MeatCostF(requiredBattles, cost);
                //Assume time is 30secs to 1
                float time = 1;
                time = (float)requiredBattles * time;
                long honoursMeat = MeatFarming((float)requiredBattles, new EXPlus());
                honoursMeat += currentHonours;
                list.Add(Convert.ToInt64(time));
                list.Add(Convert.ToInt64(honoursMeat));
                list.Add(meat);
                list.Add(Convert.ToInt64(requiredBattles));
                return list;
            }

            public void RequiredNumbers()
            {
                if (target > 0 && honours > 0)
                {
                    long meatHeld = this.meatHeld;
                    float rb = target / honours;
                    decimal requiredBattles = (decimal)Math.Round(rb);
                    decimal meat = MeatCost(requiredBattles, meatHeld);
                    List<decimal> list = new();
                    meat = (decimal)meat - meatHeld;
                    if (farmOption == 1)
                    {
                        EXPlus exP = new();

                    }
                    else
                    {
                        EX ex = new();

                    }
                }


            }

            long MeatFarming(float runs, EXPlus ex)
            {   
                long r =Convert.ToInt64(runs);
                long honours = r * ex.honours;
                return honours;

            }
            decimal MeatFarming(decimal runs, EX ex)
            {
                decimal honours = runs * ex.honours;
                return honours;

            }

            decimal MeatFarming(decimal runs, EXPlus ex)
            {
                decimal honours = runs * ex.honours;
                return honours;
            }

            decimal PotionCost(decimal battles, int cost)
            {
                decimal trueCost = battles * cost;
                decimal pots = Decimal.Divide(trueCost, halfPot);
                pots = Math.Round(pots, 1);
                Debug.WriteLine($"Cost per battle: {cost} x battles {battles} = {pots}");
                return pots;
            }

            Tuple<decimal, decimal> MeatPostCalc(decimal targetMeat, EX ex)
            {
                Tuple<decimal, decimal> tuple;
                if (meatHeld <= 0)
                {
                    decimal runs = Decimal.Divide(targetMeat, ex.meatCost);
                    decimal honours = MeatFarming(runs, ex);
                    decimal cost = runs * ex.meatCost;
                    tuple = Tuple.Create(cost, honours);
                    return tuple;
                }
                decimal a = 0;
                decimal b = 0;
                tuple = Tuple.Create(a, b);
                return tuple;
            }

            List<decimal> MeatPostCalc(decimal targetMeat, EXPlus ex)
            {
                List<decimal> list = new();
                if(meatHeld <= 0)
                {
                    decimal runs = Decimal.Divide(targetMeat, ex.meatCost);
                    decimal honours = MeatFarming(runs, ex);
                    decimal cost = runs * ex.meatCost;
                    decimal ap = runs * ex.hostCost.Item1;
                    cost = Math.Round(cost, 2);
                    honours = Math.Round(honours);
                    //Debug.WriteLine($"Meat needed = {cost}\n honours gained {honours}");
                    decimal tokens = runs * ex.token;
                    tokens = Math.Round(tokens);
                    decimal pots = PotionCost(runs, ex.hostCost.Item1);
                    pots = Math.Round(pots);
                    list.Add(ap);
                    list.Add(runs);
                    list.Add(honours);
                    list.Add(cost);
                    list.Add(tokens);
                    list.Add(pots);
                    return list;
                }
                return list;
            }


           void MeatPostCalculation(decimal targetMeat, EXPlus exPlus)
            {

            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        void BalanceTable()
        {

            foreach (RowStyle s in tableLayoutPanel1.RowStyles)
            {
                s.SizeType = SizeType.AutoSize;
            }
        }
        private void LoadPanels(object sender, EventArgs e)
        {
            rows.Clear();
            tableLayoutPanel1.Controls.Clear();
            BalanceTable();
            var checkList = levelSelectPanel.Controls.OfType<CheckBox>().Where(x => x.Checked).ToList();
            foreach (var c in checkList)
            {
                if (c.Tag != null)
                {
                    string type = c.Tag.ToString();
                    switch (type)
                    {
                        case "NM90":
                            RaidRow row = new(new NM90());
                            tableLayoutPanel1.Controls.Add(row);
                            Tuple<string, RaidRow> tuple = new(type, row);
                            rows.Add(tuple);
                            break;
                        case "NM95":
                            RaidRow r1 = new(new NM95());
                            tableLayoutPanel1.Controls.Add(r1);
                            Tuple<string, RaidRow> t1 = new(type, r1);
                            rows.Add(t1);
                            break;
                        case "NM100":
                            RaidRow r2 = new(new NM100());
                            tableLayoutPanel1.Controls.Add(r2);
                            Tuple<string, RaidRow> t2 = new(type, r2);
                            rows.Add(t2);
                            break;
                        case "NM150":
                            RaidRow r3 = new(new NM150());
                            tableLayoutPanel1.Controls.Add(r3);
                            Tuple<string, RaidRow> t3 = new(type, r3);
                            rows.Add(t3);
                            break;
                        case "NM200":
                            RaidRow r4 = new(new NM200());
                            tableLayoutPanel1.Controls.Add(r4);
                            Tuple<string, RaidRow> t4 = new(type, r4);
                            rows.Add(t4);
                            break;

                    }
                    BalanceTable();
                }
            }

        }

        private void exPOtpnRB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    public class EX : GWRaids
    {
        public int honours = 50000;
        public int token = 22;
        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 0);
        public int meatCost = 5;
    }

    public class EXPlus : GWRaids
    {

        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 0);
        public int meatCost = 6;
        public EXPlus()
        {
            this.token = 26;
            this.honours = 80800;
            this.name = "EX+";
        }
    }
    public class NM90 : GWRaids
    {

        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 5);
        public NM90()
        {
            this.token = 45;
            this.name = "NM 90";
            this.honours = 260000;
            this.cost = 5;

        }
    }

    public class NM95 : GWRaids
    {
 
        public Tuple<int, int> hostCost = new Tuple<int, int>(30, 5);
        public NM95()
        {
            this.token = 55;
            this.name = "NM 95";
            this.honours = 910000;
            this.cost = 5;
        }
    }

    public class NM100 : GWRaids
    {
  

        public Tuple<int, int> hostCost = new Tuple<int, int>(50, 10);
  
        public NM100()
        {
            this.token = 80;
            this.name = "NM 150";
            this.honours = 2650000;
            this.cost = 10;
        }
    }
    public class NM150 : GWRaids
    {
   
        public int token = 100;
        public Tuple<int, int> hostCost = new Tuple<int, int>(50, 20);
   
        public NM150()
        {
          this.token = 100;
          this.name = "NM 150";
          this.honours = 4100000;
          this.cost = 20;
        }
    }
    public class NM200 : GWRaids
    {
        public Tuple<int, int> hostCost = new Tuple<int, int>(50, 30);
        bool revive;
        int reviveCount = 0;
       
        public NM200(bool revive, decimal timeBest, decimal timeWorst, decimal target)
        {
            if (revive)
            {
                this.revive = true;
            }
            else
            {
                this.revive = false;
            }
            this.worstTime = Decimal.ToDouble(timeWorst);
            this.bestTime = Decimal.ToDouble(timeBest);     
            //this.target = target;
            this.cost = 30;
            this.name = "NM 200";
            this.honours = 10250000;
            this.token = 160;
    }
        public NM200()
        {
            this.token = 160;
            this.name = "NM 200";
            this.cost = 30;
            this.honours = 10250000;
        }
        /**
        public int EffScore()
        {
            Debug.WriteLine("Calculating depth with: " + meat);
            int score = 0;
            int honoursYields = this.HonoursEarned(meat, this.honours);
            double wt = Decimal.ToDouble(timeWorst);
            double bt = Decimal.ToDouble(timeBest);
            int runs = meat/cost;
            this.bestTime = bt;
            this.worstTime = wt;
            var tscores = timeSpans(runs);
            tscores.Sort();
            Debug.WriteLine(tscores.Count());
            Debug.WriteLine($"Honours from {this.name}: {honoursYields}");
            Debug.WriteLine($"Time Score from {name}: {tscores[tscores.Count / 2]}");
            int totalMins = (int)tscores[tscores.Count / 2].TotalMinutes;
            Debug.WriteLine($"HPM: {honoursYields / totalMins} totalMins: {totalMins}");
            return totalMins;
        }
        **/
    }

 }
