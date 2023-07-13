using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace カレンダーネオ
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        //精神的疲労度用の疲労度を保存する配列
        public int[,] HApril4Fatigue = new int[30, 2];
        public int[,] HMay5Fatigue = new int[31, 2];
        public int[,] HJune6Fatigue = new int[30, 2];
        public int[,] HJuly7Fatigue = new int[31, 2];
        public int[,] HAugust8Fatigue = new int[31, 2];
        public int[,] HSeptember9Fatigue = new int[30, 2];
        public int[,] HOctober10Fatigue = new int[31, 2];
        public int[,] HNovember11Fatigue = new int[30, 2];
        public int[,] HDecember12Fatigue = new int[31, 2];
        public int[,] HJanuary1Fatigue = new int[31, 2];
        public int[,] HFebruary2Fatigue = new int[29, 2];
        public int[,] HMarch3Fatigue = new int[31, 2];

        //指定された月の日数を保存する配列
        public int HDayCount = 0;

        //指定された月の数を保存する配列
        public int monthCount = 0;

        //最初指定されていた月の数を保存しる配列
        public int BeforeMonthCount = 0;

        public string Year = "";
        public int YearCount = 0;

        public bool Uruu = false;

        ToolTip tool = new ToolTip();

        public Form2(int d, string c)  //例）b = 指定された月の数, c = 指定された年の数
        {
            InitializeComponent();

            tool.ToolTipIcon = ToolTipIcon.Info;
            tool.SetToolTip(pctChangeBody, "表示を肉体的疲労度に切り替えます");

            //指定していた月の数をそれぞれ保存
            monthCount = d;
            BeforeMonthCount = d;

            Year = c;

            YearCount = int.Parse(Year) - 2023;

            cmbYear2.SelectedIndex = YearCount;

            //保存した月の数から日数を計算
            MonthDayResearch(monthCount);

            //月のコンボボックスの初期値を最初指定していた月の数に
            cmbMonth2.SelectedIndex = BeforeMonthCount;

        }

        //閉じるボタンをクリックしたら
        public void button1_Click(object sender, EventArgs e)
        {
            //フォーム1の作成
            Form1 form1 = new Form1(monthCount, true);

            //このフォームを隠す
            this.Hide();

            //このフォームを閉じる
            this.Close();

            //フォーム1の表示
            form1.Show();
        }

        //肉の絵をクリックしたら
        public void pctChangeBody_Click(object sender, EventArgs e)
        {
            Year = cmbYear2.SelectedItem.ToString();

            //foam3を作成
            Form3 form3 = new Form3(monthCount, Year);

            //このフォームを閉じる
            this.Close();

            //foam3を表示する
            form3.Show();
        }

        //月のコンボボックスが変更されたら
        public void cmbMonth2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMonth2Changed();
        }

        public void cmbMonth2Changed()
        {
            Year = cmbYear2.SelectedItem.ToString();

            if (Year == null)
            {
                Year = "2023";
            }

            int YearCount = int.Parse(Year);

            //変換した数がうるう年のときTrueを変数に保存
            Uruu = DateTime.IsLeapYear(YearCount);

            //月のコンボボックスのアイテム値を変数に保存
            monthCount = cmbMonth2.SelectedIndex;

            //保存した月の数から日数を求めMonthCountに代入
            MonthDayResearch(monthCount);
        }

        //月から日を求める
        public void MonthDayResearch(int a)  //例）a = 指定された月の数
        {
            //月に対して日数が30日のとき
            if (a == 0 || a == 2 || a == 5 || a == 7)
            {
                HDayCount = 30;
            }
            else if (a == 10)  //28日のとき
            {
                if (Uruu == false)
                {
                    HDayCount = 28;
                }
                else if (Uruu == true)
                {
                    HDayCount = 29;
                }
            }
            else  //31日のとき
            {
                HDayCount = 31;
            }

            //グラフの設定
            CharFirst2();
        }

        //グラフの設定
        public void CharFirst2()
        {
            //グラフの初期化
            chrFatigue.Series.Clear();
            chrFatigue.Titles.Clear();
            chrFatigue.Legends.Clear();
            chrFatigue.ChartAreas.Clear();

            //タイトル
            Title titleFatigue = new Title("精神的疲労度グラフ", Docking.Top, new Font("Meiryo", 12, FontStyle.Bold), Color.DarkGray);
            chrFatigue.Titles.Add(titleFatigue);

            //グラフ
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Pink;
            series.SetCustomProperty("PointWidth", "0.8");
            chrFatigue.Series.Add(series);

            //凡例
            chrFatigue.ChartAreas.Add("");

            //X軸
            Axis axisX = new Axis();
            axisX.Title = "日";
            axisX.TitleForeColor = Color.Pink;
            axisX.Minimum = 1;
            axisX.Maximum = 30;
            //グラフの最大値を指定された月の日数に
            axisX.Maximum = HDayCount;
            axisX.Interval = 1;
            axisX.MinorTickMark.Enabled = false;
            axisX.MajorTickMark.Enabled = false;
            chrFatigue.ChartAreas[0].AxisX = axisX;

            //Y軸
            Axis axisY = new Axis();
            axisY.Title = "疲労度";
            axisY.TitleForeColor = Color.Pink;
            axisY.Minimum = 0;
            axisY.Maximum = 4;
            axisY.Interval = 5;
            axisY.MajorGrid.Interval = 2;
            axisY.MinorGrid.Interval = 1;
            axisY.MinorGrid.Enabled = true;
            axisY.MajorTickMark.Enabled = false;
            axisY.MinorTickMark.Enabled = false;
            axisY.MinorGrid.LineColor = Color.Pink;
            chrFatigue.ChartAreas[0].AxisY = axisY;

            //配列の初期化
            ArrayReset2();

            //DBからデータを取り出し配列に保存
            DBArrayChar2();

            //データ
            //指定された月の日数の数だけループするので i < a
            for (int i = 0; i < HDayCount; i++)
            {
                //指定された月が4月のとき
                if (monthCount == 0)
                {
                    //グラフの中に数値を入力
                    series.Points.AddXY(i + 1, HApril4Fatigue[i, 0]);
                }
                //5月のとき
                if (monthCount == 1)
                {
                    series.Points.AddXY(i + 1, HMay5Fatigue[i, 0]);
                }
                //6月のとき
                if (monthCount == 2)
                {
                    series.Points.AddXY(i + 1, HJune6Fatigue[i, 0]);
                }
                //7月のとき
                if (monthCount == 3)
                {
                    series.Points.AddXY(i + 1, HJuly7Fatigue[i, 0]);
                }
                //8月のとき
                if (monthCount == 4)
                {
                    series.Points.AddXY(i + 1, HAugust8Fatigue[i, 0]);
                }
                //9月のとき
                if (monthCount == 5)
                {
                    series.Points.AddXY(i + 1, HSeptember9Fatigue[i, 0]);
                }
                //10月のとき
                if (monthCount == 6)
                {
                    series.Points.AddXY(i + 1, HOctober10Fatigue[i, 0]);
                }
                //11月のとき
                if (monthCount == 7)
                {
                    series.Points.AddXY(i + 1, HNovember11Fatigue[i, 0]);
                }
                //12月のとき
                if (monthCount == 8)
                {
                    series.Points.AddXY(i + 1, HDecember12Fatigue[i, 0]);
                }
                //1月のとき
                if (monthCount == 9)
                {
                    series.Points.AddXY(i + 1, HJanuary1Fatigue[i, 0]);
                }
                //2月のとき
                if (monthCount == 10)
                {
                    series.Points.AddXY(i + 1, HFebruary2Fatigue[i, 0]);
                }
                //3月のとき
                if (monthCount == 11)
                {
                    series.Points.AddXY(i + 1, HMarch3Fatigue[i, 0]);
                }
            }
        }

        //DBからデータを取り出し配列に保存
        public void DBArrayChar2()
        {
            //フォームの作成
            Form1 form1 = new Form1(monthCount, true);

            //DBを使用するための変数を保存
            using (var context = new FatigueContext())
            {
                //DB全体のデータを配列に保存
                var IventInfo = context.Ivents.Where(x => x.IventYear == Year).ToArray();
                //保存した配列を上から順に
                foreach (var sInfo in IventInfo)
                {
                    //DBの指定されたデータの月が4月のとき
                    if (sInfo.IventMonth == 0)
                    {
                        //精神的疲労度の数値化して配列に保存
                        form1.HeartNumber(sInfo.IventHeart, HApril4Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //5月のとき
                    if (sInfo.IventMonth == 1)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HMay5Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //6月のとき
                    if (sInfo.IventMonth == 2)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HJune6Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //7月のとき
                    if (sInfo.IventMonth == 3)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HJuly7Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //8月のとき
                    if (sInfo.IventMonth == 4)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HAugust8Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //9月のとき
                    if (sInfo.IventMonth == 5)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HSeptember9Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //10月のとき
                    if (sInfo.IventMonth == 6)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HOctober10Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //11月のとき
                    if (sInfo.IventMonth == 7)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HNovember11Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //12月のとき
                    if (sInfo.IventMonth == 8)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HDecember12Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //1月のとき
                    if (sInfo.IventMonth == 9)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HJanuary1Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //2月のとき
                    if (sInfo.IventMonth == 10)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HFebruary2Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //3月のとき
                    if (sInfo.IventMonth == 11)
                    {
                        form1.HeartNumber(sInfo.IventHeart, HMarch3Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                }
            }
        }

        //配列の初期化
        public void ArrayReset2()
        {
            //精神的疲労度用の疲労度を保存する配列の初期化
            HApril4Fatigue = new int[30, 2];
            HMay5Fatigue = new int[31, 2];
            HJune6Fatigue = new int[30, 2];
            HJuly7Fatigue = new int[31, 2];
            HAugust8Fatigue = new int[31, 2];
            HSeptember9Fatigue = new int[30, 2];
            HOctober10Fatigue = new int[31, 2];
            HNovember11Fatigue = new int[30, 2];
            HDecember12Fatigue = new int[31, 2];
            HJanuary1Fatigue = new int[31, 2];
            HFebruary2Fatigue = new int[29, 2];
            HMarch3Fatigue = new int[31, 2];
        }

        private void pctChangeBody_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pctChangeBody_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbYear2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMonth2Changed();
        }
    }
}
