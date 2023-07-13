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
    public partial class Form3 : System.Windows.Forms.Form
    {
        //精神的疲労度用の疲労度を保存する配列
        public int[,] BApril4Fatigue = new int[30, 2];
        public int[,] BMay5Fatigue = new int[31, 2];
        public int[,] BJune6Fatigue = new int[30, 2];
        public int[,] BJuly7Fatigue = new int[31, 2];
        public int[,] BAugust8Fatigue = new int[31, 2];
        public int[,] BSeptember9Fatigue = new int[30, 2];
        public int[,] BOctober10Fatigue = new int[31, 2];
        public int[,] BNovember11Fatigue = new int[30, 2];
        public int[,] BDecember12Fatigue = new int[31, 2];
        public int[,] BJanuary1Fatigue = new int[31, 2];
        public int[,] BFebruary2Fatigue = new int[28, 2];
        public int[,] BMarch3Fatigue = new int[31, 2];

        //指定された月の日数を保存する配列
        public int BDayCount = 0;

        //指定された月の数を保存する配列
        public int monthCount = 0;

        //最初指定されていた月の数を保存しる配列
        public int BeforeMonthCount = 0;

        public string Year = "";
        public int YearCount = 0;

        public bool Uruu = false;

        ToolTip tool = new ToolTip();

        public Form3(int d, string c)  //例) b = 指定された月の数, c = 指定された年の数
        {
            InitializeComponent();

            tool.ToolTipIcon = ToolTipIcon.Info;
            tool.SetToolTip(pctChangeHeart, "表示を精神的疲労度に切り替えます");

            //指定していた月の数をそれぞれ保存
            monthCount = d;
            BeforeMonthCount = d;

            Year = c;

            YearCount = int.Parse(Year) - 2023;

            cmbYear3.SelectedIndex = YearCount;

            //保存した月の数から日数を計算
            MonthDayResearch(monthCount);

            //月のコンボボックスの初期値を最初指定していた月の数に
            cmbMonth3.SelectedIndex = BeforeMonthCount;
        }

        //閉じるボタンをクリックしたら
        private void button1_Click(object sender, EventArgs e)
        {
            //フォーム1の作成
            Form1 form1 = new Form1(monthCount, false);
            
            //このフォームを閉じる
            this.Close();

            //フォーム1の表示
            form1.Show();
        }

        //ハートの絵をクリックしたら
        private void pctChangeHeart_Click(object sender, EventArgs e)
        {
            //foam2を作成
            Form2 form2 = new Form2(monthCount, Year);

            //このフォームを閉じる
            this.Close();

            //foam3を表示する
            form2.Show();
        }

        //月のコンボボックスが変更されたとき
        private void cmbMonth3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMonth3Changed();
        }

        public void cmbMonth3Changed()
        {
            Year = cmbYear3.SelectedItem.ToString();

            if (Year == null)
            {
                Year = "2023";
            }

            int YearCount = int.Parse(Year);

            //変換した数がうるう年のときTrueを変数に保存
            Uruu = DateTime.IsLeapYear(YearCount);

            //月のコンボボックスのアイテム値を変数に保存
            monthCount = cmbMonth3.SelectedIndex;

            //保存した月の数から日数を求めMonthCountに代入
            MonthDayResearch(monthCount);
        }

        //月から日を求める
        public void MonthDayResearch(int a)  //例）a = 指定された月の数
        {
            //月に対して日数が30日のとき
            if (a == 0 || a == 2 || a == 5 || a == 7)
            {
                BDayCount = 30;
            }
            else if (a == 10)  //28日のとき
            {
                if (Uruu == false)
                {
                    BDayCount = 28;
                }
                else if (Uruu == true)
                {
                    BDayCount = 29;
                }
            }
            else  //31日のとき
            {
                BDayCount = 31;
            }

            //グラフの設定
            CharFirst3();
        }

        //グラフの設定
        public void CharFirst3()
        {
            //グラフの初期化
            chrFatigueBody.Series.Clear();
            chrFatigueBody.Titles.Clear();
            chrFatigueBody.Legends.Clear();
            chrFatigueBody.ChartAreas.Clear();

            //タイトル
            Title titleFatigue = new Title("肉体的疲労度グラフ", Docking.Top, new Font("Meiryo", 12, FontStyle.Bold), Color.DarkGray);
            chrFatigueBody.Titles.Add(titleFatigue);

            //グラフ
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Pink;
            series.SetCustomProperty("PointWidth", "0.8");
            chrFatigueBody.Series.Add(series);

            //凡例
            chrFatigueBody.ChartAreas.Add("");

            //X軸
            Axis axisX = new Axis();
            axisX.Title = "日";
            axisX.TitleForeColor = Color.Pink;
            axisX.Minimum = 1;
            axisX.Maximum = 30;
            //グラフの最大値を指定された月の日数に
            axisX.Maximum = BDayCount;
            axisX.Interval = 1;
            axisX.MinorTickMark.Enabled = false;
            axisX.MajorTickMark.Enabled = false;
            chrFatigueBody.ChartAreas[0].AxisX = axisX;

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
            chrFatigueBody.ChartAreas[0].AxisY = axisY;

            //配列の初期化
            ArrayReset3();

            //DBからデータを取り出し配列に保存
            DBArrayChar3();

            //データ
            //指定された月の日数の数だけループするので i < a
            for (int i = 0; i < BDayCount; i++)
            {
                //指定された月が4月のとき
                if (monthCount == 0)
                {
                    //グラフの中に数値を入力
                    series.Points.AddXY(i + 1, BApril4Fatigue[i, 1]);
                }
                //5月のとき
                if (monthCount == 1)
                {
                    series.Points.AddXY(i + 1, BMay5Fatigue[i, 1]);
                }
                //6月のとき
                if (monthCount == 2)
                {
                    series.Points.AddXY(i + 1, BJune6Fatigue[i, 1]);
                }
                //7月のとき
                if (monthCount == 3)
                {
                    series.Points.AddXY(i + 1, BJuly7Fatigue[i, 1]);
                }
                //8月のとき
                if (monthCount == 4)
                {
                    series.Points.AddXY(i + 1, BAugust8Fatigue[i, 1]);
                }
                //9月のとき
                if (monthCount == 5)
                {
                    series.Points.AddXY(i + 1, BSeptember9Fatigue[i, 1]);
                }
                //10月のとき
                if (monthCount == 6)
                {
                    series.Points.AddXY(i + 1, BOctober10Fatigue[i, 1]);
                }
                //11月のとき
                if (monthCount == 7)
                {
                    series.Points.AddXY(i + 1, BNovember11Fatigue[i, 1]);
                }
                //12月のとき
                if (monthCount == 8)
                {
                    series.Points.AddXY(i + 1, BDecember12Fatigue[i, 1]);
                }
                //1月のとき
                if (monthCount == 9)
                {
                    series.Points.AddXY(i + 1, BJanuary1Fatigue[i, 1]);
                }
                //2月のとき
                if (monthCount == 10)
                {
                    series.Points.AddXY(i + 1, BFebruary2Fatigue[i, 1]);
                }
                //3月のとき
                if (monthCount == 11)
                {
                    series.Points.AddXY(i + 1, BMarch3Fatigue[i, 1]);
                }
            }
        }

        //DBからデータを取り出し配列に保存
        public void DBArrayChar3()
        {
            //フォームの作成
            Form1 form1 = new Form1(monthCount, false);

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
                        form1.BodyNumber(sInfo.IventBody, BApril4Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //5月のとき
                    if (sInfo.IventMonth == 1)
                    {
                        form1.BodyNumber(sInfo.IventBody, BMay5Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //6月のとき
                    if (sInfo.IventMonth == 2)
                    {
                        form1.BodyNumber(sInfo.IventBody, BJune6Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //7月のとき
                    if (sInfo.IventMonth == 3)
                    {
                        form1.BodyNumber(sInfo.IventBody, BJuly7Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //8月のとき
                    if (sInfo.IventMonth == 4)
                    {
                        form1.BodyNumber(sInfo.IventBody, BAugust8Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //9月のとき
                    if (sInfo.IventMonth == 5)
                    {
                        form1.BodyNumber(sInfo.IventBody, BSeptember9Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //10月のとき
                    if (sInfo.IventMonth == 6)
                    {
                        form1.BodyNumber(sInfo.IventBody, BOctober10Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //11月のとき
                    if (sInfo.IventMonth == 7)
                    {
                        form1.BodyNumber(sInfo.IventBody, BNovember11Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //12月のとき
                    if (sInfo.IventMonth == 8)
                    {
                        form1.BodyNumber(sInfo.IventBody, BDecember12Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //1月のとき
                    if (sInfo.IventMonth == 9)
                    {
                        form1.BodyNumber(sInfo.IventBody, BJanuary1Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //2月のとき
                    if (sInfo.IventMonth == 10)
                    {
                        form1.BodyNumber(sInfo.IventBody, BFebruary2Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                    //3月のとき
                    if (sInfo.IventMonth == 11)
                    {
                        form1.BodyNumber(sInfo.IventBody, BMarch3Fatigue, sInfo.IventDay, sInfo.IventMonth);
                    }
                }
            }
        }

        //配列の初期化
        public void ArrayReset3()
        {
            //精神的疲労度用の疲労度を保存する配列の初期化
            BApril4Fatigue = new int[30, 2];
            BMay5Fatigue = new int[31, 2];
            BJune6Fatigue = new int[30, 2];
            BJuly7Fatigue = new int[31, 2];
            BAugust8Fatigue = new int[31, 2];
            BSeptember9Fatigue = new int[30, 2];
            BOctober10Fatigue = new int[31, 2];
            BNovember11Fatigue = new int[30, 2];
            BDecember12Fatigue = new int[31, 2];
            BJanuary1Fatigue = new int[31, 2];
            BFebruary2Fatigue = new int[28, 2];
            BMarch3Fatigue = new int[31, 2];
        }

        private void pctChangeHeart_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pctChangeHeart_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cmbYear3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMonth3Changed();
        }
    }
}
