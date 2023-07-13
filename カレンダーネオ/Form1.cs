using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace カレンダーネオ
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        //イベント数の総数を指す変数
        public static int number;
        
        //月ごとのイベント上限数を判定するための変数
        public static int April4number = 0;
        public static int May5number = 0;
        public static int June6number = 0;
        public static int July7number = 0;
        public static int August8number = 0;
        public static int September9number = 0;
        public static int October10number = 0;
        public static int November11number = 0;
        public static int December12number = 0;
        public static int January1number = 0;
        public static int February2number = 0;
        public static int March3number = 0;
        
        //cmbDayの数を数える変数
        public static int DayCount = 0;

        //cmbMonthの数を数える変数
        public static int MonthCount = 0;

        //cmbYearの数を数える変数
        public static int YearCount = 0;

        //前のcmbMonthを保存する変数
        public static int BeforeMonthCount = 0;

        //うるう年かどうかを保存する変数（初期値：False＝うるう年ではない）
        public static bool Uruu = false;

        //for文用の変数
        public static int num = 0;

        //疲労度をDBから保存するための配列
        public static int[,] April4Fatigue = new int[30, 2];
        public static int[,] May5Fatigue = new int[31, 2];
        public static int[,] June6Fatigue = new int[30, 2];
        public static int[,] July7Fatigue = new int[31, 2];
        public static int[,] August8Fatigue = new int[31, 2];
        public static int[,] September9Fatigue = new int[30, 2];
        public static int[,] October10Fatigue = new int[31, 2];
        public static int[,] November11Fatigue = new int[30, 2];
        public static int[,] December12Fatigue = new int[31, 2];
        public static int[,] January1Fatigue = new int[31, 2];
        public static int[,] February2Fatigue = new int[28, 2];
        public static int[,] March3Fatigue = new int[31, 2];

        //イベントのラベルをDBから保存するための配列
        public static string[,] April4Label = new string[10, 2];
        public static string[,] May5Label = new string[10, 2];
        public static string[,] June6Label = new string[10, 2];
        public static string[,] July7Label = new string[10, 2];
        public static string[,] August8Label = new string[10, 2];
        public static string[,] September9Label = new string[10, 2];
        public static string[,] October10Label = new string[10, 2];
        public static string[,] November11Label = new string[10, 2];
        public static string[,] December12Label = new string[10, 2];
        public static string[,] January1Label = new string[10, 2];
        public static string[,] February2Label = new string[10, 2];
        public static string[,] March3Label = new string[10, 2];

        //疲労度を切り替えるためのbool変数（初期値はtrue＝精神的疲労度）
        public static bool fatigue = true;

        //色の変数
        Color notuse = Color.Gray;      //非表示のカレンダーのパネル
        Color use = Color.Gainsboro;    //表示のカレンダーのパネル
        Color red = Color.Red;          //疲労度強のパネル
        Color yellow = Color.Yellow;    //疲労度中のパネル
        Color green = Color.Green;      //疲労度弱のパネル

        //ラベル用の変数
        Label KariLabel;

        //ラベルの存在を保存する配列
        Control[] C_LabelApril4 = new Control[10];
        Control[] C_LabelMay5 = new Control[10];
        Control[] C_LabelJune6 = new Control[10];
        Control[] C_LabelJuly7 = new Control[10];
        Control[] C_LabelAugust8 = new Control[10];
        Control[] C_LabelSeptember9 = new Control[10];
        Control[] C_LabelOctober10 = new Control[10];
        Control[] C_LabelNovember11 = new Control[10];
        Control[] C_LabelDecember12 = new Control[10];
        Control[] C_LabelJanuary1 = new Control[10];
        Control[] C_LabelFebruary2 = new Control[10];
        Control[] C_LabelMarch3 = new Control[10];

        ToolTip tool = new ToolTip();

        public Form1(int a, bool b)  //例）a = 指定された月の数, b = 疲労度の選択
        {
            InitializeComponent();

            //選択した月を変数に保存
            MonthCount = a;
            
            //疲労度を変数に保存
            fatigue = b;
        }

        public void Main(string[] args)
        {
        }

        //cmbMonthの数を返すためのメソッド
        public int GetMonthCount()
        {
            //MonthCount = 選択している月の数
            return MonthCount;
        }

        //グラフの画像をクリックしたら
        public void pctGraph_Click(object sender, EventArgs e)
        {
            //月のコンボボックスのアイテム値を変数に保存
            MonthCount = cmbMonth.SelectedIndex;
            string Year = cmbYear.SelectedItem.ToString();

            //精神的疲労度が選択されているとき
            if (fatigue == true)
            {
                //フォームの作成
                Form2 form2 = new Form2(MonthCount, Year);

                //フォーム２の表示
                form2.Show();

                //このフォームを隠す
                this.Hide();
            }

            //肉体的疲労度が選択されているとき
            if (fatigue == false)
            {
                //フォームの作成
                Form3 form3 = new Form3(MonthCount, Year);

                //フォーム２の表示
                form3.Show();

                //このフォームを隠す
                this.Hide();
            }
        }

        //DB作成ボタンを押したら
        private void button2_Click(object sender, EventArgs e)
        {
            //DB使用のための変数を設定
            var context = new FatigueContext();
            //クラスで設定しているDB内の項目を作成
            context.Ivents.Create();
            //作成したDBを保存
            context.SaveChanges();
            //作成した変数を削除
            context.Dispose();
        }

        //DBリセットボタンを押したら
        private void btnReset_Click(object sender, EventArgs e)
        {
            //パネルをリセット
            PanelReset();

            //DB使用のための変数を設定
            using (var context = new FatigueContext())
            {
                //DB全体を取り出し上から順に
                foreach (var IventInfo in context.Ivents)
                {
                    //削除
                    context.Ivents.Remove(IventInfo);
                }
                //DB変更を保存
                context.SaveChanges();
            }
        }

        //DB編集ボタンを押したら
        private void btnDBedit_Click(object sender, EventArgs e)
        {
            //フォームの作成
            Form4 form4 = new Form4(MonthCount, fatigue);

            //このフォームを隠す
            this.Hide();

            //フォームの表示
            form4.ShowDialog();
        }

        //パネルリセットボタンを押したら
        private void btnPanelReset_Click(object sender, EventArgs e)
        {
            //パネルをリセットする
            PanelReset();
        }

        //パネルをリセットする
        public void PanelReset()
        {
            //パネルの色の初期化
            PanelColor();

            //月の指定が4月のとき
            if (MonthCount == 0)
            {
                //動的に生成したラベルの消去
                IventLabelClear(April4Label, C_LabelApril4);
            }
            //5月のとき
            if (MonthCount == 1)
            {
                IventLabelClear(May5Label, C_LabelMay5);
            }
            //6月のとき
            if (MonthCount == 2)
            {
                IventLabelClear(June6Label, C_LabelJune6);
            }
            //7月のとき
            if (MonthCount == 3)
            {
                IventLabelClear(July7Label, C_LabelJuly7);
            }
            //8月のとき
            if (MonthCount == 4)
            {
                IventLabelClear(August8Label, C_LabelAugust8);
            }
            //9月のとき
            if (MonthCount == 5)
            {
                IventLabelClear(September9Label, C_LabelSeptember9);
            }
            //10月のとき
            if (MonthCount == 6)
            {
                IventLabelClear(October10Label, C_LabelOctober10);
            }
            //11月のとき
            if (MonthCount == 7)
            {
                IventLabelClear(November11Label, C_LabelNovember11);
            }
            //12月のとき
            if (MonthCount == 8)
            {
                IventLabelClear(December12Label, C_LabelDecember12);
            }
            //1月のとき
            if (MonthCount == 9)
            {
                IventLabelClear(January1Label, C_LabelJanuary1);
            }
            //2月のとき
            if (MonthCount == 10)
            {
                IventLabelClear(February2Label, C_LabelFebruary2);
            }
            //3月のとき
            if (MonthCount == 11)
            {
                IventLabelClear(March3Label, C_LabelMarch3);
            }

            //イベントの総数を初期化
            number = 0;
        }

        public void ArrayReset()
        {
            //月ごとの疲労度の配列を初期化
            April4Fatigue = new int[30, 2];
            May5Fatigue = new int[31, 2];
            June6Fatigue = new int[30, 2];
            July7Fatigue = new int[31, 2];
            August8Fatigue = new int[31, 2];
            September9Fatigue = new int[30, 2];
            October10Fatigue = new int[31, 2];
            November11Fatigue = new int[30, 2];
            December12Fatigue = new int[31, 2];
            January1Fatigue = new int[31, 2];
            February2Fatigue = new int[29, 2];
            March3Fatigue = new int[31, 2];

            //月ごとのイベントのラベルの配列を初期化
            April4Label = new string[10, 2];
            May5Label = new string[10, 2];
            June6Label = new string[10, 2];
            July7Label = new string[10, 2];
            August8Label = new string[10, 2];
            September9Label = new string[10, 2];
            October10Label = new string[10, 2];
            November11Label = new string[10, 2];
            December12Label = new string[10, 2];
            January1Label = new string[10, 2];
            February2Label = new string[10, 2];
            March3Label = new string[10, 2];

            //月ごとのイベント数を初期化
            April4number = 0;
            May5number = 0;
            June6number = 0;
            July7number = 0;
            August8number = 0;
            September9number = 0;
            October10number = 0;
            November11number = 0;
            December12number = 0;
            January1number = 0;
            February2number = 0;
            March3number = 0;
        }

        //復元ボタンが押されたら
        private void btnRestration_Click(object sender, EventArgs e)
        {
            //DBに入れた情報の全体を配列に保存
            //DBArrayKeepSingle();
            //月のコンボボックスが変更されたときと同じ方法で復元
            cmbMonthChanged();
        }

        //適応ボタンを押したら
        public void button1_Click(object sender, EventArgs e)
        {
            button1Click();
            //cmbMonthChanged();
        }

        public void button1Click()
        {
            string text = textBox1.Text;
            string Year = cmbYear.SelectedItem.ToString();
            string Month = cmbMonth.SelectedItem.ToString();
            string Day = cmbDay.SelectedItem.ToString();
            string Heart = cmbHeart.SelectedItem.ToString();
            string Body = cmbBody.SelectedItem.ToString();

            //Yes,Noメッセージボックスを表示→結果を変数に保存
            DialogResult result = MessageBox.Show("入力したデータを登録しますか？\n用事名称：" + text + "\n日程：" + Year + "/" + Month + "/" + Day + "\n精神的疲労度：" + Heart + "\n肉体的疲労度：" + Body, "確認", MessageBoxButtons.YesNoCancel);

            //いいえが押されたとき
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            //はいが押されたとき
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //イベントの保存が10より多くなったとき
                if ((April4number >= 10 && MonthCount == 0) || (May5number >= 10 && MonthCount == 1) || (June6number >= 10 && MonthCount == 2) || (July7number >= 10 && MonthCount == 3) || (August8number >= 10 && MonthCount == 4) || (September9number >= 10 && MonthCount == 5) || (October10number >= 10 && MonthCount == 6) || (November11number >= 10 && MonthCount == 7) || (December12number >= 10 && MonthCount == 8) || (January1number >= 10 && MonthCount == 9) || (February2number >= 10 && MonthCount == 10) || (March3number >= 10 && MonthCount == 11))
                {
                    //メッセージの表示
                    MessageBox.Show("これ以上イベントを登録できないよ！");
                    //メソッドの終了
                    return;
                }
                //イベントの保存が10以下のとき
                else
                {
                    //イベントの総数を数える
                    number = number + 1;

                    //ArrayReset();

                    MessageBox.Show(April4number.ToString());

                    //イベントの情報を保存
                    IventLabelKeep();

                    //DBの最新の情報（ついさっき入れられたデータ）を配列に保存
                    //DBArrayKeepSingle();

                    cmbMonthChanged();
                }
            }
        }

        //ハートをクリックしたら→精神的疲労度に変更、表示
        public void pctHeart_Click(object sender, EventArgs e)
        {
            //精神的疲労度を選択→bool変数をtrueに
            fatigue = true;
            //パネルの色をもとに戻す
            PanelColor();
            
            //月のコンボボックスが4月のとき
            if (cmbMonth.SelectedIndex == 0)
            {
                //月ごとの精神的疲労度の配列から色を指定する
                HeartColor(April4Fatigue);
            }
            //5月のとき
            if (cmbMonth.SelectedIndex == 1)
            {
                HeartColor(May5Fatigue);
            }
            //6月のとき
            if (cmbMonth.SelectedIndex == 2)
            {
                HeartColor(June6Fatigue);
            }
            //7月のとき
            if (cmbMonth.SelectedIndex == 3)
            {
                HeartColor(July7Fatigue);
            }
            //8月のとき
            if (cmbMonth.SelectedIndex == 4)
            {
                HeartColor(August8Fatigue);
            }
            //9月のとき
            if (cmbMonth.SelectedIndex == 5)
            {
                HeartColor(September9Fatigue);
            }
            //10月のとき
            if (cmbMonth.SelectedIndex == 6)
            {
                HeartColor(October10Fatigue);
            }
            //11月のとき
            if (cmbMonth.SelectedIndex == 7)
            {
                HeartColor(November11Fatigue);
            }
            //12月のとき
            if (cmbMonth.SelectedIndex == 8)
            {
                HeartColor(December12Fatigue);
            }
            //1月のとき
            if (cmbMonth.SelectedIndex == 9)
            {
                HeartColor(January1Fatigue);
            }
            //2月のとき
            if (cmbMonth.SelectedIndex == 10)
            {
                HeartColor(February2Fatigue);
            }
            //3月のとき
            if (cmbMonth.SelectedIndex == 11)
            {
                HeartColor(March3Fatigue);
            }
        }

        //肉をクリックしたら→肉体的疲労度に変更、表示
        public void pctBody_Click(object sender, EventArgs e)
        {
            //肉体的疲労度を選択→bool変数をfalseに
            fatigue = false;
            //パネルの色をもとに戻す
            PanelColor();

            //月のコンボボックスが4月のとき
            if (cmbMonth.SelectedIndex == 0)
            {
                //月ごとの肉体的疲労度の配列から色を指定する
                BodyColor(April4Fatigue);
            }
            //5月のとき
            if (cmbMonth.SelectedIndex == 1)
            {
                BodyColor(May5Fatigue);
            }
            //6月のとき
            if (cmbMonth.SelectedIndex == 2)
            {
                BodyColor(June6Fatigue);
            }
            //7月のとき
            if (cmbMonth.SelectedIndex == 3)
            {
                BodyColor(July7Fatigue);
            }
            //8月のとき
            if (cmbMonth.SelectedIndex == 4)
            {
                BodyColor(August8Fatigue);
            }
            //9月のとき
            if (cmbMonth.SelectedIndex == 5)
            {
                BodyColor(September9Fatigue);
            }
            //10月のとき
            if (cmbMonth.SelectedIndex == 6)
            {
                BodyColor(October10Fatigue);
            }
            //11月のとき
            if (cmbMonth.SelectedIndex == 7)
            {
                BodyColor(November11Fatigue);
            }
            //12月のとき
            if (cmbMonth.SelectedIndex == 8)
            {
                BodyColor(December12Fatigue);
            }
            //1月のとき
            if (cmbMonth.SelectedIndex == 9)
            {
                BodyColor(January1Fatigue);
            }
            //2月のとき
            if (cmbMonth.SelectedIndex == 10)
            {
                BodyColor(February2Fatigue);
            }
            //3月のとき
            if (cmbMonth.SelectedIndex == 11)
            {
                BodyColor(March3Fatigue);
            }
        }

        //フォームがロードされたとき
        public void Form1_Load(object sender, EventArgs e)
        {
            labelBefore.Text = "";

            tool.ToolTipIcon = ToolTipIcon.Info;

            tool.SetToolTip(pctGraph, "グラフを表示します");
            tool.SetToolTip(pctHeart, "表示を精神的疲労度に切り替えます");
            tool.SetToolTip(pctBody, "表示を肉体的疲労度に切り替えます");


            //月のコンボボックスの初期値を4に
            cmbMonth.SelectedIndex = MonthCount;

            //日のコンボボックスの初期値を1に
            cmbDay.SelectedIndex = 0;

            //年のコンボボックスの初期値を2023に
            cmbYear.SelectedIndex = 0;

            //精神的疲労度の初期値をなしに
            cmbHeart.SelectedIndex = 0;

            //肉体的疲労度の初期値をなしに
            cmbBody.SelectedIndex = 0;

            //パネルや配列を初期化する
            PanelReset();

            //DB全体の情報を配列に保存
            //DBArrayKeepSingle();

            //numberをIventNumberの最大値に
            DBNumberKeep();

            //月のコンボボックスが変更されたときと同じ方法で復元
            cmbMonthChanged();
        }

        //パネルの色を元に戻す
        public void PanelColor()
        {
            if (fatigue == true)
            {
                pctFatigue.Image = Properties.Resources._23094613;
            }
            if (fatigue == false)
            {
                pctFatigue.Image = Properties.Resources._23127739;
            }

            //31日分のパネルの色をuse（灰色）に
            panel1.BackColor = use;
            panel2.BackColor = use;
            panel3.BackColor = use;
            panel4.BackColor = use;
            panel5.BackColor = use;
            panel6.BackColor = use;
            panel7.BackColor = use;
            panel8.BackColor = use;
            panel9.BackColor = use;
            panel10.BackColor = use;
            panel11.BackColor = use;
            panel12.BackColor = use;
            panel13.BackColor = use;
            panel14.BackColor = use;
            panel15.BackColor = use;
            panel16.BackColor = use;
            panel17.BackColor = use;
            panel18.BackColor = use;
            panel19.BackColor = use;
            panel20.BackColor = use;
            panel21.BackColor = use;
            panel22.BackColor = use;
            panel23.BackColor = use;
            panel24.BackColor = use;
            panel25.BackColor = use;
            panel26.BackColor = use;
            panel27.BackColor = use;
            panel28.BackColor = use;
            panel29.BackColor = use;
            panel30.BackColor = use;
            panel31.BackColor = use;

            //29～31日の変更されることのあるラベルを改めて修正
            label31.Text = "31";
            label30.Text = "30";
            label29.Text = "29";

            //その月のコンボボックスのアイテム数が30のとき
            if (DayCount == 30)
            {
                //不要な31日を消去
                DayCount30();
            }

            //その月のコンボボックスのアイテム数が29のとき
            if (DayCount == 29)
            {
                DayCount29();
            }

            //その月のコンボボックスのアイテム数が28のとき
            if (DayCount == 28)
            {
                //不要な29～31日を消去
                DayCount28();
            }
        }

        //日のコンボボックスが変更されたら
        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //月のコンボボックスが変更されたら
        public void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //前に選択していた月が4～12月のとき
            if (BeforeMonthCount <= 8)
            {
                //次に選択していた月が1～3月なら
                if (cmbMonth.SelectedIndex >= 9)
                {
                    try
                    {
                        //年のコンボボックスを次に送る
                        cmbYear.SelectedIndex = cmbYear.SelectedIndex + 1;
                    }
                    catch  //最大値のときは
                    {
                        //年のコンボボックスを最大値にしておく
                        cmbYear.SelectedIndex = 9;
                    }
                }
            }

            //次に選択していた月が1～3月なら
            if (BeforeMonthCount >= 9)
            {
                //前に選択していた月が4～12月のとき
                if (cmbMonth.SelectedIndex <= 8)
                {
                    //最小値のときは
                    if (cmbYear.SelectedIndex == 0)
                    {
                        //年のコンボボックスを最小値にしておく
                        cmbYear.SelectedIndex = 0;
                    }
                    else
                    {
                        //年のコンボボックスを前に送る
                        cmbYear.SelectedIndex = cmbYear.SelectedIndex - 1;
                    }
                }
            }

            //その月の表示を復元する
            cmbMonthChanged();
        }

        //指定された月の表示の復元
        public void cmbMonthChanged()
        {
            //もしも年のコンボボックスのアイテムがないとき
            if (cmbYear.SelectedItem == null)
            {
                //年のコンボボックスの値を初期値に
                cmbYear.SelectedIndex = 0;
            }

            //一旦年のコンボボックスのアイテム名を変数に保存
            string Year = cmbYear.SelectedItem.ToString();

            //保存したデータをintに変換して変数に保存
            YearCount = int.Parse(Year);

            //変換した数がうるう年のときTrueを変数に保存
            Uruu = DateTime.IsLeapYear(YearCount);

            int month = cmbMonth.SelectedIndex;
            int year = cmbYear.SelectedIndex;

            if (month == 0 && year == 0)
            {
                labelBefore.Text = "";
                labelAfter.Text = ">>";
            }
            else if (month == 11 && year == 9)
            {
                labelBefore.Text = "<<";
                labelAfter.Text = "";
            }
            else
            {
                labelBefore.Text = "<<";
                labelAfter.Text = ">>";
            }

            //元々指定されていた日の値の取得
            int selectDay = cmbDay.SelectedIndex;

            //cmbMonthの数を代入
            MonthCount = cmbMonth.SelectedIndex;

            //コンボボックスの中身を消去
            cmbDay.Items.Clear();

            //前選択されていた月が4月なら
            if (BeforeMonthCount == 0)
            {
                //貼られていたラベルの消去
                IventLabelClear(April4Label, C_LabelApril4);
            }

            //5月なら
            if (BeforeMonthCount == 1)
            {
                IventLabelClear(May5Label, C_LabelMay5);
            }

            //6月なら
            if (BeforeMonthCount == 2)
            {
                IventLabelClear(June6Label, C_LabelJune6);
            }

            //7月なら
            if (BeforeMonthCount == 3)
            {
                IventLabelClear(July7Label, C_LabelJuly7);
            }

            //8月なら
            if (BeforeMonthCount == 4)
            {
                IventLabelClear(August8Label, C_LabelAugust8);
            }

            //9月なら
            if (BeforeMonthCount == 5)
            {
                IventLabelClear(September9Label, C_LabelSeptember9);
            }

            //10月なら
            if (BeforeMonthCount == 6)
            {
                IventLabelClear(October10Label, C_LabelOctober10);
            }

            //11月なら
            if (BeforeMonthCount == 7)
            {
                IventLabelClear(November11Label, C_LabelNovember11);
            }

            //12月なら
            if (BeforeMonthCount == 8)
            {
                IventLabelClear(December12Label, C_LabelDecember12);
            }

            //1月なら
            if (BeforeMonthCount == 9)
            {
                IventLabelClear(January1Label, C_LabelJanuary1);
            }

            //2月なら
            if (BeforeMonthCount == 10)
            {
                IventLabelClear(February2Label, C_LabelFebruary2);
            }

            //3月なら
            if (BeforeMonthCount == 11)
            {
                IventLabelClear(March3Label, C_LabelMarch3);
            }

            ArrayReset();
            DBArrayKeepSingle();

            //現在選択しているのが4月なら
            if (MonthCount == 0)
            {
                //日のパネルを設定する
                April4();
                //指定した月の日数を数える
                DayCount = cmbDay.Items.Count;
                //日のコンボボックスのアイテムをもとに戻す
                PanelColor();

                //月ごとのイベント上限数は10なのでi < 10
                for (int i = 0; i < 10; i++)
                {
                    //動的生成されたラベルの設定変更
                    CreateLabel(April4Label, i);
                    //動的生成されたラベルの位置決定
                    IventDayLabel(April4Label, i, C_LabelApril4);
                }

                //精神的疲労度が選択されているとき
                if (fatigue == true)
                {
                    //配列をもとに精神的疲労度の色付け
                    HeartColor(April4Fatigue);
                }
                //肉体的疲労度が選択されているとき
                if (fatigue == false)
                {
                    //配列をもとに肉体的疲労度の色付け
                    BodyColor(April4Fatigue);
                }
            }

            //5月なら
            if (MonthCount == 1)
            {
                May5();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(May5Label, i);
                    IventDayLabel(May5Label, i, C_LabelMay5);
                }

                if (fatigue == true)
                {
                    HeartColor(May5Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(May5Fatigue);
                }
            }

            //6月なら
            if (MonthCount == 2)
            {
                June6();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(June6Label, i);
                    IventDayLabel(June6Label, i, C_LabelJune6);
                }

                if (fatigue == true)
                {
                    HeartColor(June6Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(June6Fatigue);
                }
            }

            //7月なら
            if (MonthCount == 3)
            {
                July7();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(July7Label, i);
                    IventDayLabel(July7Label, i, C_LabelJuly7);
                }

                if (fatigue == true)
                {
                    HeartColor(July7Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(July7Fatigue);
                }
            }

            //8月なら
            if (MonthCount == 4)
            {
                August8();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(August8Label, i);
                    IventDayLabel(August8Label, i, C_LabelAugust8);
                }

                if (fatigue == true)
                {
                    HeartColor(August8Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(August8Fatigue);
                }
            }

            //9月なら
            if (MonthCount == 5)
            {
                September9();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(September9Label, i);
                    IventDayLabel(September9Label, i, C_LabelSeptember9);
                }

                if (fatigue == true)
                {
                    HeartColor(September9Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(September9Fatigue);
                }
            }

            //10月なら
            if (MonthCount == 6)
            {
                October10();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(October10Label, i);
                    IventDayLabel(October10Label, i, C_LabelOctober10);
                }

                if (fatigue == true)
                {
                    HeartColor(October10Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(October10Fatigue);
                }
            }

            //11月なら
            if (MonthCount == 7)
            {
                November11();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(November11Label, i);
                    IventDayLabel(November11Label, i, C_LabelNovember11);
                }

                if (fatigue == true)
                {
                    HeartColor(November11Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(November11Fatigue);
                }
            }

            //12月なら
            if (MonthCount == 8)
            {
                December12();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(December12Label, i);
                    IventDayLabel(December12Label, i, C_LabelDecember12);
                }

                if (fatigue == true)
                {
                    HeartColor(December12Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(December12Fatigue);
                }
            }

            //1月なら
            if (MonthCount == 9)
            {
                January1();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(January1Label, i);
                    IventDayLabel(January1Label, i, C_LabelJanuary1);
                }

                if (fatigue == true)
                {
                    HeartColor(January1Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(January1Fatigue);
                }
            }

            //2月なら
            if (MonthCount == 10)
            {
                //うるう年じゃないとき
                if (Uruu == false)
                {
                    February2();
                }
                //うるう年のとき
                if (Uruu == true)
                {
                    FebruaryUruu2();
                }
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(February2Label, i);
                    IventDayLabel(February2Label, i, C_LabelFebruary2);
                }

                if (fatigue == true)
                {
                    HeartColor(February2Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(February2Fatigue);
                }
            }

            //3月なら
            if (MonthCount == 11)
            {
                March3();
                DayCount = cmbDay.Items.Count;
                PanelColor();

                for (int i = 0; i < 10; i++)
                {
                    CreateLabel(March3Label, i);
                    IventDayLabel(March3Label, i, C_LabelMarch3);
                }

                if (fatigue == true)
                {
                    HeartColor(March3Fatigue);
                }
                if (fatigue == false)
                {
                    BodyColor(March3Fatigue);
                }
            }

            try
            {
                //前指定されていた日の値を日のコンボボックスの値に
                cmbDay.SelectedIndex = selectDay;
            }
            catch　　//もしも指定されていた日がなかったら
            {
                //日のコンボボックスの値を初期値に
                cmbDay.SelectedIndex = 0;
            }

            //IventLabelClearのために元々指定されていた月のコンボボックスの値を保存する
            BeforeMonthCount = cmbMonth.SelectedIndex;
        }

        //ラベルを生成するための変数作成
        public void CreateLabel(string[,] a, int b)  //例）a = 月ごとのイベントのラベル配列, b = 月ごとのイベント数
        {
            //ラベルの作成
            KariLabel = new Label();
            //ラベルの名前設定
            //KariLabel.Name = "KariLabel" + number;
            //ラベルのサイズ調整をオートに
            KariLabel.AutoSize = true;
            //ラベルの位置を設定
            KariLabel.Location = new Point(7, 27);
            //ラベルのテキストを配列に保存されているテキストに
            KariLabel.Text = a[b, 1];
            //ラベルのフォント設定
            KariLabel.Font = new Font("MS UI Gothic", 14, FontStyle.Bold);
            //ラベルを最前面に
            KariLabel.BringToFront();
        }

        //作成したラベルの情報をDBに保存
        public void IventLabelKeep()
        {
            //入力されたデータを変数に入れる
            var ivent = new Ivent()
            {
                //イベントの総数
                IventNumber = number,
                //イベントの月の数
                IventMonth = cmbMonth.SelectedIndex,
                //イベントの日数
                IventDay = cmbDay.SelectedIndex,
                //イベントの年数
                IventYear = cmbYear.SelectedItem.ToString(),
                //イベントの名称
                IventLabel = textBox1.Text,
                //イベントの精神的疲労度の値
                IventHeart = cmbHeart.SelectedIndex,
                //イベントの肉体的疲労度の値
                IventBody = cmbBody.SelectedIndex
            };

            //DB使用のための変数を設定
            var context = new FatigueContext();
            //データを入れた変数をDBに加える
            context.Ivents.Add(ivent);
            //追加されたDBを保存
            context.SaveChanges();
            //作成した変数の削除
            context.Dispose();
        }

        //DBに入れた最新のデータだけを配列に保存
        public void DBArrayKeepSingle()
        {
            string Year = cmbYear.SelectedItem.ToString();

            if (Year == null)
            {
                Year = "2023";
            }

            int YearCount = int.Parse(Year);

            //変換した数がうるう年のときTrueを変数に保存
            Uruu = DateTime.IsLeapYear(YearCount);
            //try
            //{
            //DB使用のための変数を設定
            using (var context = new FatigueContext())
            {
                //DB内の最新のデータを指す変数を作成
                var Infos = context.Ivents.Where(x => x.IventYear == Year).ToArray();

                foreach (var IventInfo in Infos)
                {
                    //DB内の最新のデータの月の数が4月のとき
                    if (IventInfo.IventMonth == 0)
                    {
                        //DB内の最新のデータをもとに精神的疲労度の計算
                        HeartNumber(IventInfo.IventHeart, April4Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        //DB内の最新のデータをもとに肉体的疲労度の計算
                        BodyNumber(IventInfo.IventBody, April4Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        //指定された月のラベルの配列の次の列にDB内の最新のデータの日数を代入
                        April4Label[April4number, 0] = IventInfo.IventDay.ToString();
                        //指定された月のラベルの配列の次の列にDB内の最新のデータのイベント名称を代入
                        April4Label[April4number, 1] = IventInfo.IventLabel;

                        April4number = April4number + 1;
                    }

                    //5月のとき
                    if (IventInfo.IventMonth == 1)
                    {
                        HeartNumber(IventInfo.IventHeart, May5Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, May5Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        May5Label[May5number, 0] = IventInfo.IventDay.ToString();
                        May5Label[May5number, 1] = IventInfo.IventLabel;

                        May5number = May5number + 1;
                    }

                    //6月のとき
                    if (IventInfo.IventMonth == 2)
                    {
                        HeartNumber(IventInfo.IventHeart, June6Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, June6Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        June6Label[June6number, 0] = IventInfo.IventDay.ToString();
                        June6Label[June6number, 1] = IventInfo.IventLabel;

                        June6number = June6number + 1;
                    }

                    //7月のとき
                    if (IventInfo.IventMonth == 3)
                    {
                        HeartNumber(IventInfo.IventHeart, July7Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, July7Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        July7Label[July7number, 0] = IventInfo.IventDay.ToString();
                        July7Label[July7number, 1] = IventInfo.IventLabel;

                        July7number = July7number + 1;
                    }

                    //8月のとき
                    if (IventInfo.IventMonth == 4)
                    {
                        HeartNumber(IventInfo.IventHeart, August8Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, August8Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        August8Label[August8number, 0] = IventInfo.IventDay.ToString();
                        August8Label[August8number, 1] = IventInfo.IventLabel;

                        August8number = August8number + 1;
                    }

                    //9月のとき
                    if (IventInfo.IventMonth == 5)
                    {
                        HeartNumber(IventInfo.IventHeart, September9Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, September9Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        September9Label[September9number, 0] = IventInfo.IventDay.ToString();
                        September9Label[September9number, 1] = IventInfo.IventLabel;

                        September9number = September9number + 1;
                    }

                    //10月のとき
                    if (IventInfo.IventMonth == 6)
                    {
                        HeartNumber(IventInfo.IventHeart, October10Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, October10Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        October10Label[October10number, 0] = IventInfo.IventDay.ToString();
                        October10Label[October10number, 1] = IventInfo.IventLabel;

                        October10number = October10number + 1;
                    }

                    //11月のとき
                    if (IventInfo.IventMonth == 7)
                    {
                        HeartNumber(IventInfo.IventHeart, November11Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, November11Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        November11Label[November11number, 0] = IventInfo.IventDay.ToString();
                        November11Label[November11number, 1] = IventInfo.IventLabel;

                        November11number = November11number + 1;
                    }

                    //12月のとき
                    if (IventInfo.IventMonth == 8)
                    {
                        HeartNumber(IventInfo.IventHeart, December12Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, December12Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        December12Label[December12number, 0] = IventInfo.IventDay.ToString();
                        December12Label[December12number, 1] = IventInfo.IventLabel;

                        December12number = December12number + 1;
                    }

                    //1月のとき
                    if (IventInfo.IventMonth == 9)
                    {
                        HeartNumber(IventInfo.IventHeart, January1Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, January1Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        January1Label[January1number, 0] = IventInfo.IventDay.ToString();
                        January1Label[January1number, 1] = IventInfo.IventLabel;

                        January1number = January1number + 1;
                    }

                    //2月のとき
                    if (IventInfo.IventMonth == 10)
                    {
                        HeartNumber(IventInfo.IventHeart, February2Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, February2Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        February2Label[February2number, 0] = IventInfo.IventDay.ToString();
                        February2Label[February2number, 1] = IventInfo.IventLabel;

                        February2number = February2number + 1;
                    }

                    //3月のとき
                    if (IventInfo.IventMonth == 11)
                    {
                        HeartNumber(IventInfo.IventHeart, March3Fatigue, IventInfo.IventDay, IventInfo.IventMonth);
                        BodyNumber(IventInfo.IventBody, March3Fatigue, IventInfo.IventDay, IventInfo.IventMonth);

                        March3Label[March3number, 0] = IventInfo.IventDay.ToString();
                        March3Label[March3number, 1] = IventInfo.IventLabel;

                        March3number = March3number + 1;
                    }
                }
            }
            //}
            //catch
            //{
                
            //}
        }

        //numberをIventNumberの最大値に
        public void DBNumberKeep()
        {
            //DB使用のための変数を設定
            using (var context = new FatigueContext())
            {
                //DB内のデータ全体を取り出し変数に入れる
                var sInfo = context.Ivents.OrderBy(x => x.IventNumber);
                //取り出したDB内のデータ全体を上から順に
                foreach (var IventsInfo in sInfo)
                {
                    //DB内のIventNumberの数をイベントの総数を指す変数に代入→現在あるイベントの総数が示される
                    number = IventsInfo.IventNumber;
                }
            }
        }

        //作成したラベルの消去
        public void IventLabelClear(string[,] a, Control[] b)  //例）a = イベントのラベルを保存する配列,b = イベントのラベルを保存するControl配列
        {
            //指定されたイベントの上限はは10なのでi > 10
            for (int i = 0; i < 10; i++)
            {
                //イベントのラベルを保存する配列に入っている日数が1のとき
                if (a[i, 0] == "0")
                {
                    //Control配列に保存された指定した日数のパネル内に生成されたラベルを削除
                    panel1.Controls.Remove(b[i]);
                }
                //2のとき
                if (a[i, 0] == "1")
                {
                    panel2.Controls.Remove(b[i]);
                }
                //3のとき
                if (a[i, 0] == "2")
                {
                    panel3.Controls.Remove(b[i]);
                }
                //4のとき
                if (a[i, 0] == "3")
                {
                    panel4.Controls.Remove(b[i]);
                }
                //5のとき
                if (a[i, 0] == "4")
                {
                    panel5.Controls.Remove(b[i]);
                }
                //6のとき
                if (a[i, 0] == "5")
                {
                    panel6.Controls.Remove(b[i]);
                }
                //7のとき
                if (a[i, 0] == "6")
                {
                    panel7.Controls.Remove(b[i]);
                }
                //8のとき
                if (a[i, 0] == "7")
                {
                    panel8.Controls.Remove(b[i]);
                }
                //9のとき
                if (a[i, 0] == "8")
                {
                    panel9.Controls.Remove(b[i]);
                }
                //10のとき
                if (a[i, 0] == "9")
                {
                    panel10.Controls.Remove(b[i]);
                }
                //11のとき
                if (a[i, 0] == "10")
                {
                    panel11.Controls.Remove(b[i]);
                }
                //12のとき
                if (a[i, 0] == "11")
                {
                    panel12.Controls.Remove(b[i]);
                }
                //13のとき
                if (a[i, 0] == "12")
                {
                    panel13.Controls.Remove(b[i]);
                }
                //14のとき
                if (a[i, 0] == "13")
                {
                    panel14.Controls.Remove(b[i]);
                }
                //15のとき
                if (a[i, 0] == "14")
                {
                    panel15.Controls.Remove(b[i]);
                }
                //16のとき
                if (a[i, 0] == "15")
                {
                    panel16.Controls.Remove(b[i]);
                }
                //17のとき
                if (a[i, 0] == "16")
                {
                    panel17.Controls.Remove(b[i]);
                }
                //18のとき
                if (a[i, 0] == "17")
                {
                    panel18.Controls.Remove(b[i]);
                }
                //19のとき
                if (a[i, 0] == "18")
                {
                    panel19.Controls.Remove(b[i]);
                }
                //20のとき
                if (a[i, 0] == "19")
                {
                    panel20.Controls.Remove(b[i]);
                }
                //21のとき
                if (a[i, 0] == "20")
                {
                    panel21.Controls.Remove(b[i]);
                }
                //22のとき
                if (a[i, 0] == "21")
                {
                    panel22.Controls.Remove(b[i]);
                }
                //23のとき
                if (a[i, 0] == "22")
                {
                    panel23.Controls.Remove(b[i]);
                }
                //24のとき
                if (a[i, 0] == "23")
                {
                    panel24.Controls.Remove(b[i]);
                }
                //25のとき
                if (a[i, 0] == "24")
                {
                    panel25.Controls.Remove(b[i]);
                }
                //26のとき
                if (a[i, 0] == "25")
                {
                    panel26.Controls.Remove(b[i]);
                }
                //27のとき
                if (a[i, 0] == "26")
                {
                    panel27.Controls.Remove(b[i]);
                }
                //28のとき
                if (a[i, 0] == "27")
                {
                    panel28.Controls.Remove(b[i]);
                }
                //29のとき
                if (a[i, 0] == "28")
                {
                    panel29.Controls.Remove(b[i]);
                }
                //30のとき
                if (a[i, 0] == "29")
                {
                    panel30.Controls.Remove(b[i]);
                }
                //31のとき
                if (a[i, 0] == "30")
                {
                    panel31.Controls.Remove(b[i]);
                }
            }
        }

        //日のコンボボックスが30日までのとき
        public void DayCount30()
        {
            //不要な31日のラベルを消去
            label31.Text = "";
            //31日のパネルをnotuse（濃い灰色）に
            panel31.BackColor = notuse;
        }

        //日のコンボボックスが29日までのとき
        public void DayCount29()
        {
            //不要な30～31日のラベルを消去
            label31.Text = "";
            label30.Text = "";
            //30～31日のパネルをnotuse（濃い灰色）に
            panel31.BackColor = notuse;
            panel30.BackColor = notuse;
        }

        //日のコンボボックスが28日までのとき
        public void DayCount28()
        {
            //不要な29～31日のラベルを消去
            label31.Text = "";
            label30.Text = "";
            label29.Text = "";
            //29～31日のパネルをnotuse（濃い灰色）に
            panel31.BackColor = notuse;
            panel30.BackColor = notuse;
            panel29.BackColor = notuse;
        }

        //4月のときの月のコンボボックスの操作
        public void April4()
        {
            //月のそれぞれの日数を一つずつ保存した配列を作成
            string[] April4Day = new string[30] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
            //作成した配列を日のコンボボックス内のアイテムにする
            cmbDay.Items.AddRange(April4Day);
        }

        //5月のときの月のコンボボックスの操作
        public void May5()
        {
            string[] May5Day = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            cmbDay.Items.AddRange(May5Day);
        }

        //6月のときの月のコンボボックスの操作
        public void June6()
        {
            string[] June6Day = new string[30] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
            cmbDay.Items.AddRange(June6Day);
        }

        //7月のときの月のコンボボックスの操作
        public void July7()
        {
            string[] July7Day = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            cmbDay.Items.AddRange(July7Day);
        }

        //8月のときの月のコンボボックスの操作
        public void August8()
        {
            string[] August8Day = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            cmbDay.Items.AddRange(August8Day);
        }

        //9月のときの月のコンボボックスの操作
        public void September9()
        {
            string[] September9Day = new string[30] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
            cmbDay.Items.AddRange(September9Day);
        }

        //10月のときの月のコンボボックスの操作
        public void October10()
        {
            string[] October10Day = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            cmbDay.Items.AddRange(October10Day);
        }

        //11月のときの月のコンボボックスの操作
        public void November11()
        {
            string[] November11Day = new string[30] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
            cmbDay.Items.AddRange(November11Day);
        }

        //12月のときの月のコンボボックスの操作
        public void December12()
        {
            string[] December12Day = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            cmbDay.Items.AddRange(December12Day);
        }

        //1月のときの月のコンボボックスの操作
        public void January1()
        {
            string[] January1Day = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            cmbDay.Items.AddRange(January1Day);
        }

        //2月のときの月のコンボボックスの操作
        public void February2()
        {
            string[] February2Day = new string[28] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };
            cmbDay.Items.AddRange(February2Day);
        }

        //うるう年の2月のときの月のコンボボックスの操作
        public void FebruaryUruu2()
        {
            string[] FebruaryUruu2Day = new string[29] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29" };
            cmbDay.Items.AddRange(FebruaryUruu2Day);
        }

        //3月のときの月のコンボボックスの操作
        public void March3()
        {
            string[] March3day = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            cmbDay.Items.AddRange(March3day);
        }

        //ラベルを作成する位置の判定
        public void IventDayLabel(string[,] a, int b, Control[] d)  //例）a = イベントのラベルを保存した配列, b = 指定された月のイベントの総数, d = イベントのラベルを保存したControl配列
        {
            //イベントのラベルを保存した配列の指定された列のデータの日数が1日のとき
            if (a[b, 0] == "0")
            {
                //指定された日数のパネルにラベルを作成
                panel1.Controls.Add(KariLabel);
            }
            //2日のとき
            if (a[b, 0] == "1")
            {
                panel2.Controls.Add(KariLabel);
            }
            //3日のとき
            if (a[b, 0] == "2")
            {
                panel3.Controls.Add(KariLabel);
            }
            //4日のとき
            if (a[b, 0] == "3")
            {
                panel4.Controls.Add(KariLabel);
            }
            //5日のとき
            if (a[b, 0] == "4")
            {
                panel5.Controls.Add(KariLabel);
            }
            //6日のとき
            if (a[b, 0] == "5")
            {
                panel6.Controls.Add(KariLabel);
            }
            //7日のとき
            if (a[b, 0] == "6")
            {
                panel7.Controls.Add(KariLabel);
            }
            //8日のとき
            if (a[b, 0] == "7")
            {
                panel8.Controls.Add(KariLabel);
            }
            //9日のとき
            if (a[b, 0] == "8")
            {
                panel9.Controls.Add(KariLabel);
            }
            //10日のとき
            if (a[b, 0] == "9")
            {
                panel10.Controls.Add(KariLabel);
            }
            //11日のとき
            if (a[b, 0] == "10")
            {
                panel11.Controls.Add(KariLabel);
            }
            //12日のとき
            if (a[b, 0] == "11")
            {
                panel12.Controls.Add(KariLabel);
            }
            //13日のとき
            if (a[b, 0] == "12")
            {
                panel13.Controls.Add(KariLabel);
            }
            //14日のとき
            if (a[b, 0] == "13")
            {
                panel14.Controls.Add(KariLabel);
            }
            //15日のとき
            if (a[b, 0] == "14")
            {
                panel15.Controls.Add(KariLabel);
            }
            //16日のとき
            if (a[b, 0] == "15")
            {
                panel16.Controls.Add(KariLabel);
            }
            //17日のとき
            if (a[b, 0] == "16")
            {
                panel17.Controls.Add(KariLabel);
            }
            //18日のとき
            if (a[b, 0] == "17")
            {
                panel18.Controls.Add(KariLabel);
            }
            //19日のとき
            if (a[b, 0] == "18")
            {
                panel19.Controls.Add(KariLabel);
            }
            //20日のとき
            if (a[b, 0] == "19")
            {
                panel20.Controls.Add(KariLabel);
            }
            //21日のとき
            if (a[b, 0] == "20")
            {
                panel21.Controls.Add(KariLabel);
            }
            //22日のとき
            if (a[b, 0] == "21")
            {
                panel22.Controls.Add(KariLabel);
            }
            //23日のとき
            if (a[b, 0] == "22")
            {
                panel23.Controls.Add(KariLabel);
            }
            //24日のとき
            if (a[b, 0] == "23")
            {
                panel24.Controls.Add(KariLabel);
            }
            //25日のとき
            if (a[b, 0] == "24")
            {
                panel25.Controls.Add(KariLabel);
            }
            //26日のとき
            if (a[b, 0] == "25")
            {
                panel26.Controls.Add(KariLabel);
            }
            //27日のとき
            if (a[b, 0] == "26")
            {
                panel27.Controls.Add(KariLabel);
            }
            //28日のとき
            if (a[b, 0] == "27")
            {
                panel28.Controls.Add(KariLabel);
            }
            //29日のとき
            if (a[b, 0] == "28")
            {
                panel29.Controls.Add(KariLabel);
            }
            //30日のとき
            if (a[b, 0] == "29")
            {
                panel30.Controls.Add(KariLabel);
            }
            //31日のとき
            if (a[b, 0] == "30")
            {
                panel31.Controls.Add(KariLabel);
            }
            
            //動的に生成したラベルをControl配列に保存
            d[b] = KariLabel;
        }

        //精神的疲労度の数値化
        public void HeartNumber(int a, int[,] b, int c, int d)  //例）a = 精神的疲労度の数値, b = 疲労度を保存する配列（1列目(0)＝精神的疲労度）, c = 指定されたイベントの日を指す数, d = 指定されたイベントの月を指す数
        {
            //日数を数える変数
            int Day = 0;

            //日数が30日のとき
            if (d == 0 || d == 2 || d == 5 || d == 7)
            {
                //日数を30に
                Day = 30;
            }
            else if (d == 10)  //28日のとき
            {
                if (Uruu == false)
                {
                    //日数を28に
                    Day = 28;
                }
                else if (Uruu == true)
                {
                    Day = 29;
                }
            }
            else  //31日のとき
            {
                //日数を31に
                Day = 31;
            }

            //弱の時
            if (a == 1)
            {
                //指定された列に疲労度弱（1）を代入
                b[c, 0] = b[c, 0] + a;
            }

            //中の時
            if (a == 2)
            {
                if (c == 0) //1日の時
                {
                    //指定された列に疲労度中（2）を代入
                    b[c, 0] = b[c, 0] + a;
                    b[c + 1, 0] = b[c + 1, 0] +a - 1;
                }
                else if (c == Day - 1) //最終日の時
                {
                    b[c - 1, 0] = b[c - 1, 0] + a - 1;
                    b[c, 0] = b[c, 0] + a;
                }
                else //それ以外の時
                {
                    b[c - 1, 0] = b[c - 1, 0] + a - 1;
                    b[c, 0] = b[c, 0] + a;
                    b[c + 1, 0] = b[c + 1, 0] + a - 1;
                }
            }

            //強の時
            if (a == 3)
            {
                if (c == 0) //1日の時
                {
                    //指定された列に疲労度強（3）を代入
                    b[c, 0] = b[c, 0] + a;
                    b[c + 1, 0] = b[c + 1, 0] + a - 1;
                    b[c + 2, 0] = b[c + 2, 0] + a - 2;
                }
                else if (c == 1) //2日の時
                {
                    b[c - 1, 0] = b[c - 1, 0] + a - 1;
                    b[c, 0] = b[c, 0] + a;
                    b[c + 1, 0] = b[c + 1, 0] + a - 1;
                    b[c + 2, 0] = b[c + 2, 0] + a - 2;
                }
                else if (c == Day - 2) //最終日の一日前の時
                {
                    b[c - 2, 0] = b[c - 2, 0] + a - 2;
                    b[c - 1, 0] = b[c - 1, 0] + a - 1;
                    b[c, 0] = b[c, 0] + a;
                    b[c + 1, 0] = b[c + 1, 0] + a - 1;
                }
                else if (c == Day - 1) //最終日の時
                {
                    b[c - 2, 0] = b[c - 2, 0] + a - 2;
                    b[c - 1, 0] = b[c - 1, 0] + a - 1;
                    b[c, 0] = b[c, 0] + a;
                }
                else //それ以外の時
                {
                    b[c - 2, 0] = b[c - 2, 0] + a - 2;
                    b[c - 1, 0] = b[c - 1, 0] + a - 1;
                    b[c, 0] = b[c, 0] + a;
                    b[c + 1, 0] = b[c + 1, 0] + a - 1;
                    b[c + 2, 0] = b[c + 2, 0] + a - 2;
                }
            }
        }

        //肉体的疲労度の数値化
        public void BodyNumber(int a, int[,] b, int c, int d)  //例）a = 肉体的疲労度の数値, b = 疲労度を保存する配列（2列目(1)＝肉体的疲労度）, c = 指定されたイベントを指す数, d = 指定されたイベントの月を指す数
        {
            //日数を数える変数
            int Day = 0;

            //日数が30日のとき
            if (d == 0 || d == 2 || d == 5 || d == 7)
            {
                //日数を30に
                Day = 30;
            }
            else if (d == 10)  //28日のとき
            {
                if (Uruu == false)
                {
                    //日数を28に
                    Day = 28;
                }
                else if (Uruu == true)
                {
                    Day = 29;
                }
            }
            else  //31日のとき
            {
                //日数を31に
                Day = 31;
            }

            //弱の時
            if (a == 1)
            {
                //指定された列に疲労度弱（1）を代入
                b[c, 1] = b[c, 1] + a;
            }

            //中の時
            if (a == 2)
            {
                if (c == Day - 1) //最終日の時
                {
                    //指定された列に疲労度中（2）を代入
                    b[c, 1] = b[c, 1] + a;
                }
                else //それ以外の時
                {
                    b[c, 1] = b[c, 1] + a;
                    b[c + 1, 1] = b[c + 1, 1] + a - 1;
                }
            }

            //強の時
            if (a == 3)
            {
                if (c == Day - 2) //最終日の一日前の時
                {
                    //指定された列に疲労度強（3）を代入
                    b[c, 1] = b[c, 1] + a;
                    b[c + 1, 1] = b[c + 1, 1] + a - 1;
                }
                else if (c == Day - 1) //最終日の時
                {
                    b[c, 1] = b[c, 1] + a;
                }
                else //それ以外の時
                {
                    b[c, 1] = b[c, 1] + a;
                    b[c + 1, 1] = b[c + 1, 1] + a - 1;
                    b[c + 2, 1] = b[c + 2, 1] + a - 2;
                }
            }
        }

        //精神的疲労度の配列から色を指定する
        public void HeartColor(int[,] a)  //例）a = 疲労度を保存した配列（1列目(0)＝精神的疲労度）
        {
            //指定された月の日数分ループする（使用するメソッド内でもループ内の変数を使用するためiではなくnum）
            for (num = 0; num < cmbDay.Items.Count; num++)
            {
                //疲労度の保存された配列の指定された列が1（疲労度弱）のとき
                if (a[num, 0] == 1)
                {
                    //色の指定→緑
                    PanelGreen();
                }
                //2（疲労度中）のとき
                if (a[num, 0] == 2)
                {
                    //色の指定→黄
                    PanelYellow();
                }
                //3（疲労度強）のとき
                if (a[num, 0] >= 3)
                {
                    //色の指定→赤
                    PanelRed();
                }
            }
        }

        //肉体的疲労度の配列から色を指定する
        public void BodyColor(int[,] a)  //例）a = 疲労度を保存した配列（2列目(1)＝肉体的疲労度）
        {
            //指定された月の日数分ループする（使用するメソッド内でもループ内の変数を使用するためiではなくnum）
            for (num = 0; num < cmbDay.Items.Count; num++)
            {
                //疲労度の保存された配列の指定された列が1（疲労度弱）のとき
                if (a[num, 1] == 1)
                {
                    //色の指定→緑
                    PanelGreen();
                }
                //2（疲労度中）のとき
                if (a[num, 1] == 2)
                {
                    //色の指定→黄
                    PanelYellow();
                }
                //3（疲労度強）のとき
                if (a[num, 1] >= 3)
                {
                    //色の指定→赤
                    PanelRed();
                }
            }
        }

        //パネルを弱のグリーンに色を変える
        public void PanelGreen()
        {
            //指定された日数が1日のとき
            if (num == 0)
            {
                //指定されたパネルの色を緑に
                panel1.BackColor = green;
            }
            //2日のとき
            if (num == 1)
            {
                panel2.BackColor = green;
            }
            //3日のとき
            if (num == 2)
            {
                panel3.BackColor = green;
            }
            //4日のとき
            if (num == 3)
            {
                panel4.BackColor = green;
            }
            //5日のとき
            if (num == 4)
            {
                panel5.BackColor = green;
            }
            //6日のとき
            if (num == 5)
            {
                panel6.BackColor = green;
            }
            //7日のとき
            if (num == 6)
            {
                panel7.BackColor = green;
            }
            //8日のとき
            if (num == 7)
            {
                panel8.BackColor = green;
            }
            //9日のとき
            if (num == 8)
            {
                panel9.BackColor = green;
            }
            //10日のとき
            if (num == 9)
            {
                panel10.BackColor = green;
            }
            //11日のとき
            if (num == 10)
            {
                panel11.BackColor = green;
            }
            //12日のとき
            if (num == 11)
            {
                panel12.BackColor = green;
            }
            //13日のとき
            if (num == 12)
            {
                panel13.BackColor = green;
            }
            //14日のとき
            if (num == 13)
            {
                panel14.BackColor = green;
            }
            //15日のとき
            if (num == 14)
            {
                panel15.BackColor = green;
            }
            //16日のとき
            if (num == 15)
            {
                panel16.BackColor = green;
            }
            //17日のとき
            if (num == 16)
            {
                panel17.BackColor = green;
            }
            //18日のとき
            if (num == 17)
            {
                panel18.BackColor = green;
            }
            //19日のとき
            if (num == 18)
            {
                panel19.BackColor = green;
            }
            //20日のとき
            if (num == 19)
            {
                panel20.BackColor = green;
            }
            //21日のとき
            if (num == 20)
            {
                panel21.BackColor = green;
            }
            //22日のとき
            if (num == 21)
            {
                panel22.BackColor = green;
            }
            //23日のとき
            if (num == 22)
            {
                panel23.BackColor = green;
            }
            //24日のとき
            if (num == 23)
            {
                panel24.BackColor = green;
            }
            //25日のとき
            if (num == 24)
            {
                panel25.BackColor = green;
            }
            //26日のとき
            if (num == 25)
            {
                panel26.BackColor = green;
            }
            //27日のとき
            if (num == 26)
            {
                panel27.BackColor = green;
            }
            //28日のとき
            if (num == 27)
            {
                panel28.BackColor = green;
            }
            //29日のとき
            if (num == 28)
            {
                panel29.BackColor = green;
            }
            //30日のとき
            if (num == 29)
            {
                panel30.BackColor = green;
            }
            //31日のとき
            if (num == 30)
            {
                panel31.BackColor = green;
            }
        }

        //パネルを中のイエローに色を変える
        public void PanelYellow()
        {
            //指定された日数が1日のとき
            if (num == 0)
            {
                //指定されたパネルの色を黄に
                panel1.BackColor = yellow;
            }
            //2日のとき
            if (num == 1)
            {
                panel2.BackColor = yellow;
            }
            //3日のとき
            if (num == 2)
            {
                panel3.BackColor = yellow;
            }
            //4日のとき
            if (num == 3)
            {
                panel4.BackColor = yellow;
            }
            //5日のとき
            if (num == 4)
            {
                panel5.BackColor = yellow;
            }
            //6日のとき
            if (num == 5)
            {
                panel6.BackColor = yellow;
            }
            //7日のとき
            if (num == 6)
            {
                panel7.BackColor = yellow;
            }
            //8日のとき
            if (num == 7)
            {
                panel8.BackColor = yellow;
            }
            //9日のとき
            if (num == 8)
            {
                panel9.BackColor = yellow;
            }
            //10日のとき
            if (num == 9)
            {
                panel10.BackColor = yellow;
            }
            //11日のとき
            if (num == 10)
            {
                panel11.BackColor = yellow;
            }
            //12日のとき
            if (num == 11)
            {
                panel12.BackColor = yellow;
            }
            //13日のとき
            if (num == 12)
            {
                panel13.BackColor = yellow;
            }
            //14日のとき
            if (num == 13)
            {
                panel14.BackColor = yellow;
            }
            //15日のとき
            if (num == 14)
            {
                panel15.BackColor = yellow;
            }
            //16日のとき
            if (num == 15)
            {
                panel16.BackColor = yellow;
            }
            //17日のとき
            if (num == 16)
            {
                panel17.BackColor = yellow;
            }
            //18日のとき
            if (num == 17)
            {
                panel18.BackColor = yellow;
            }
            //19日のとき
            if (num == 18)
            {
                panel19.BackColor = yellow;
            }
            //20日のとき
            if (num == 19)
            {
                panel20.BackColor = yellow;
            }
            //21日のとき
            if (num == 20)
            {
                panel21.BackColor = yellow;
            }
            //22日のとき
            if (num == 21)
            {
                panel22.BackColor = yellow;
            }
            //23日のとき
            if (num == 22)
            {
                panel23.BackColor = yellow;
            }
            //24日のとき
            if (num == 23)
            {
                panel24.BackColor = yellow;
            }
            //25日のとき
            if (num == 24)
            {
                panel25.BackColor = yellow;
            }
            //26日のとき
            if (num == 25)
            {
                panel26.BackColor = yellow;
            }
            //27日のとき
            if (num == 26)
            {
                panel27.BackColor = yellow;
            }
            //28日のとき
            if (num == 27)
            {
                panel28.BackColor = yellow;
            }
            //29日のとき
            if (num == 28)
            {
                panel29.BackColor = yellow;
            }
            //30日のとき
            if (num == 29)
            {
                panel30.BackColor = yellow;
            }
            //31日のとき
            if (num == 30)
            {
                panel31.BackColor = yellow;
            }
        }

        //パネルを強のレッドに変える
        public void PanelRed()
        {
            //指定された日数が1日のとき
            if (num == 0)
            {
                //指定されたパネルの色を赤に
                panel1.BackColor = red;
            }
            //2日のとき
            if (num == 1)
            {
                panel2.BackColor = red;
            }
            //3日のとき
            if (num == 2)
            {
                panel3.BackColor = red;
            }
            //4日のとき
            if (num == 3)
            {
                panel4.BackColor = red;
            }
            //5日のとき
            if (num == 4)
            {
                panel5.BackColor = red;
            }
            //6日のとき
            if (num == 5)
            {
                panel6.BackColor = red;
            }
            //7日のとき
            if (num == 6)
            {
                panel7.BackColor = red;
            }
            //8日のとき
            if (num == 7)
            {
                panel8.BackColor = red;
            }
            //9日のとき
            if (num == 8)
            {
                panel9.BackColor = red;
            }
            //10日のとき
            if (num == 9)
            {
                panel10.BackColor = red;
            }
            //11日のとき
            if (num == 10)
            {
                panel11.BackColor = red;
            }
            //12日のとき
            if (num == 11)
            {
                panel12.BackColor = red;
            }
            //13日のとき
            if (num == 12)
            {
                panel13.BackColor = red;
            }
            //14日のとき
            if (num == 13)
            {
                panel14.BackColor = red;
            }
            //15日のとき
            if (num == 14)
            {
                panel15.BackColor = red;
            }
            //16日のとき
            if (num == 15)
            {
                panel16.BackColor = red;
            }
            //17日のとき
            if (num == 16)
            {
                panel17.BackColor = red;
            }
            //18日のとき
            if (num == 17)
            {
                panel18.BackColor = red;
            }
            //19日のとき
            if (num == 18)
            {
                panel19.BackColor = red;
            }
            //20日のとき
            if (num == 19)
            {
                panel20.BackColor = red;
            }
            //21日のとき
            if (num == 20)
            {
                panel21.BackColor = red;
            }
            //22日のとき
            if (num == 21)
            {
                panel22.BackColor = red;
            }
            //23日のとき
            if (num == 22)
            {
                panel23.BackColor = red;
            }
            //24日のとき
            if (num == 23)
            {
                panel24.BackColor = red;
            }
            //25日のとき
            if (num == 24)
            {
                panel25.BackColor = red;
            }
            //26日のとき
            if (num == 25)
            {
                panel26.BackColor = red;
            }
            //27日のとき
            if (num == 26)
            {
                panel27.BackColor = red;
            }
            //28日のとき
            if (num == 27)
            {
                panel28.BackColor = red;
            }
            //29日のとき
            if (num == 28)
            {
                panel29.BackColor = red;
            }
            //30日のとき
            if (num == 29)
            {
                panel30.BackColor = red;
            }
            //31日のとき
            if (num == 30)
            {
                panel31.BackColor = red;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 0;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 1;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 2;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 3;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 4;
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 5;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 6;
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 7;
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 8;
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 9;
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 10;
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 11;
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 12;
        }

        private void panel14_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 13;
        }

        private void panel15_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 14;
        }

        private void panel16_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 15;
        }

        private void panel17_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 16;
        }

        private void panel18_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 17;
        }

        private void panel19_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 18;
        }

        private void panel20_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 19;
        }

        private void panel21_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 20;
        }

        private void panel22_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 21;
        }

        private void panel23_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 22;
        }

        private void panel24_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 23;
        }

        private void panel25_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 24;
        }

        private void panel26_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 25;
        }

        private void panel27_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 26;
        }

        private void panel28_Click(object sender, EventArgs e)
        {
            cmbDay.SelectedIndex = 27;
        }

        private void panel29_Click(object sender, EventArgs e)
        {
            if (cmbDay.Items.Count <= 28)
            {
                return;
            }

            cmbDay.SelectedIndex = 28;
        }

        private void panel30_Click(object sender, EventArgs e)
        {
            if (cmbDay.Items.Count <= 28)
            {
                return;
            }

            cmbDay.SelectedIndex = 29;
        }

        private void panel31_Click(object sender, EventArgs e)
        {
            if (cmbDay.Items.Count <= 30)
            {
                return;
            }

            cmbDay.SelectedIndex = 30;
        }

        private void pctGraph_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pctGraph_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pctHeart_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pctHeart_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pctBody_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pctBody_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void labelBefore_Click(object sender, EventArgs e)
        {
            int month = cmbMonth.SelectedIndex;
            int year = cmbYear.SelectedIndex;

            if (month == 0)
            {
                cmbYear.SelectedIndex = year;
                cmbMonth.SelectedIndex = 11;
            }
            else
            {
                cmbMonth.SelectedIndex = month - 1;
            }
        }

        private void labelAfter_Click(object sender, EventArgs e)
        {
            int month = cmbMonth.SelectedIndex;
            int year = cmbYear.SelectedIndex;

            if (month == 11)
            {
                cmbYear.SelectedIndex = year;
                cmbMonth.SelectedIndex = 0;
            }
            else
            {
                cmbMonth.SelectedIndex = month + 1;
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //月のパネルをリセット→復元
            cmbMonthChanged();
        }
    }
}
