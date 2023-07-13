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
    public partial class Form4 : Form
    {
        //日のコンボボックスのアイテムを入れる配列
        public string[] Day31 = new string[31] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        public string[] Day30 = new string[30] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
        public string[] Day29 = new string[29] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29" };
        public string[] Day28 = new string[28] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };

        //データグリッドビューのデータを保存する配列
        public string[] DBArray = new string[7];

        //Numberのコンボボックスに入れるアイテムを入れる配列
        public string[] NumberItem = new string[2];

        //選択されたデータグリッドビューの列を保存する変数
        public int countRow = 0;

        //DBの情報をいったん保存する変数
        public int Number = 0;
        public string YearCount = "";
        public int MonthCount = 0;
        public int DayCount = 0;
        public string LabelText = "";
        public int HeartCount = 0;
        public int BodyCount = 0;

        //追加したイベントの総数を数える変数
        public int countIvent = 0;

        //後に選択したNumberのコンボボックスのアイテム値を保存する変数
        public int numberAfter = 0;

        //以前に選択していたnumberコンボボックスのアイテム値を保存する変数
        public int numberBefore = 0;

        //Numberのコンボボックスのアイテムを保存する変数
        public string numberLabel = "";

        //フォーム1に送る疲労度を保存する変数
        public int Form1cmbMonth = 0;

        //フォーム1に送る疲労度を保存する変数
        public bool Form1Bool = true;

        public bool Uruu = false;

        //numberのコンボボックスのアイテムを数値型にしたものを保存する変数
        public int numberCount = 0;

        //Numberのコンボボックスのアイテムが変更されたときそのほかのフォーラムも変更するか判断するためのbool変数
        //初期値：true（Numberのコンボボックスのアイテムが変更されたとき他のフォーラムも変更できる状態）
        public bool changeYesNo = true;

        //追加するときか更新をするときか判別するためのbool変数
        //初期値：true（更新の状態）
        public bool AddOrUpdate = true;

        public Form4(int a, bool b)
        {
            InitializeComponent();

            Form1cmbMonth = a;

            Form1Bool = b;
        }

        //foam4が開かれたとき
        public void Form4_Load(object sender, EventArgs e)
        {
            //データグリッドビューの初期設定
            ColumnFirst();

            //DBの情報を変数に入れリストに表示する
            RistDBArrayKeep();

            //Numberのコンボボックスのアイテムを変更
            cmbNumberItem();

            //列をIDの昇順に
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

            //No.のコンボボックスアイテム初期値を1に
            cmbNumber.SelectedIndex = 0;
            //numberのコンボボックスのアイテム値に合わせてフォーラムの表示内容を変更
            DataNotNumber(1);
        }

        //新規作成ボタンが押されたとき
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Numberのコンボボックスのアイテムが変更されたとき他のフォーラムも変更されないようにする
            changeYesNo = false;

            //更新ではなく追加の状態にする
            AddOrUpdate = false;

            //もともと選択されていたセルをなくす
            dataGridView1.CurrentCell = null;

            //Yes,Noメッセージボックスを表示→結果を変数に保存
            DialogResult result = MessageBox.Show("今入力したデータを入力フォームに残した状態で新規作成しますか？", "確認", MessageBoxButtons.YesNoCancel);

            //いいえが押されたとき
            if (result == System.Windows.Forms.DialogResult.No)
            {
                //月のコンボボックスアイテム初期値を4に
                cmbMonth4.SelectedIndex = 0;
                //日のコンボボックスアイテム初期値を1に
                cmbDay4.SelectedIndex = 0;
                //テキストボックスの中身を空白に
                textBox1.Text = "";
                //精神的疲労度コンボボックスアイテム初期値をなしに
                cmbHeart4.SelectedIndex = 0;
                //肉体的疲労度コンボボックスアイテム初期値をなしに
                cmbBody4.SelectedIndex = 0;
            }

            //Numberのコンボボックスのアイテムを入れる配列を初期化（項目数を2に）
            NumberItem = new string[2];

            //イベントの総数の+1を得る変数
            int NewCountIvent = countIvent + 1;

            //配列に入れたいアイテムの名前を保存
            NumberItem[0] = "戻る";
            NumberItem[1] = NewCountIvent.ToString();

            //Numberのコンボボックスのアイテムを初期化
            cmbNumber.Items.Clear();
            //Numberのコンボボックスのアイテムに保存した配列を代入
            cmbNumber.Items.AddRange(NumberItem);

            //Numberのコンボボックスのアイテムの初期値を新規作成したnumberの値に
            cmbNumber.SelectedIndex = 1;
        }

        //更新ボタンが押されたとき
        public void btnAdd4_Click(object sender, EventArgs e)
        {
            //Numberのコンボボックスのアイテムを変数に保存する
            numberLabel = cmbNumber.SelectedItem.ToString();

            //Numberのコンボボックスのアイテムが戻るとき
            if (numberLabel == "戻る")
            {
                //IDに数字を入れてもらうようにメッセージ
                MessageBox.Show("No.は数字を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Numberのコンボボックスのアイテムを数字のアイテムに
                cmbNumber.SelectedIndex = 1;

                //メソッドを終了
                return;
            }

            if (numberLabel == "なし")
            {
                MessageBox.Show("イベントを新規作成してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Numberのコンボボックスのアイテムを数字のアイテムに
                cmbNumber.SelectedIndex = 0;

                //メソッドを終了
                return;
            }

            //保存したコンボボックスのアイテム値をintに変換して変数に保存
            numberCount = int.Parse(numberLabel);

            //更新のとき
            if (AddOrUpdate == true)
            {
                //DB使用のための変数を作成
                var context = new FatigueContext();

                //DBから取り出した情報を作成した変数に保存
                var IventInfo = context.Ivents.Single(x => x.IventNumber == numberCount);

                //フォーラムの情報をDBに保存する
                IventInfo.IventYear = cmbYear.SelectedItem.ToString();
                IventInfo.IventMonth = cmbMonth4.SelectedIndex;
                IventInfo.IventDay = cmbDay4.SelectedIndex;
                IventInfo.IventLabel = textBox1.Text;
                IventInfo.IventHeart = cmbHeart4.SelectedIndex;
                IventInfo.IventBody = cmbBody4.SelectedIndex;

                //変更したDBを保存
                context.SaveChanges();
                //使用した変数の削除
                context.Dispose();
            }

            //追加のとき
            if (AddOrUpdate == false)
            {
                //入力されたデータを変数に入れる
                var ivent = new Ivent()
                {
                    //イベントの総数
                    IventNumber = numberCount,
                    IventYear = cmbYear.SelectedItem.ToString(),
                    //イベントの月の数
                    IventMonth = cmbMonth4.SelectedIndex,
                    //イベントの日数
                    IventDay = cmbDay4.SelectedIndex,
                    //イベントの名称
                    IventLabel = textBox1.Text,
                    //イベントの精神的疲労度の値
                    IventHeart = cmbHeart4.SelectedIndex,
                    //イベントの肉体的疲労度の値
                    IventBody = cmbBody4.SelectedIndex
                };
                //DB使用のための変数を設定
                var context = new FatigueContext();
                //変数に保存したデータをDBに加える
                context.Ivents.Add(ivent);
                //加えたデータを保存する
                context.SaveChanges();
                //作成した変数の削除
                context.Dispose();

                //イベントの総数を+1
                countIvent = countIvent + 1;
            }

            //Numberのコンボボックスのアイテムを初期化
            cmbNumber.Items.Clear();

            //データグリッドビューの列と行の初期化
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            //データグリッドビューの初期設定
            ColumnFirst();

            //DBから情報を取り出してデータグリッドビューに表示させる
            RistDBArrayKeep();

            //Numberのコンボボックスのアイテムを変更
            cmbNumberItem();

            //numberのコンボボックスのアイテム値を0に
            cmbNumber.SelectedIndex = 0;

            //Numberのコンボボックスのアイテムが変更されたとき他のフォーラムが変更されるようにする
            changeYesNo = true;

            //追加ではなく更新の状態に変更する
            AddOrUpdate = true;
        }

        //削除ボタンが押されたとき
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Numberのコンボボックスのアイテムが何を選択されているか調べる
            numberLabel = cmbNumber.SelectedItem.ToString();

            if (numberLabel == "なし")
            {
                MessageBox.Show("削除するものがありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Numberのコンボボックスのアイテムを数字のアイテムに
                cmbNumber.SelectedIndex = 0;

                //メソッドを終了
                return;
            }

            //Yes,Noメッセージボックスを表示→結果を変数に保存
            DialogResult result = MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNoCancel);

            //いいえが押されたとき
            if (result == System.Windows.Forms.DialogResult.No)
            {
                //メソッドを終了
                return;
            }
            //はいが押されたとき
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //numberのコンボボックスのアイテムを数値型に変換する
                numberCount = int.Parse(numberLabel);

                //DB使用のための変数を作成
                using (var context = new FatigueContext())
                {
                    try
                    {
                        //DBの指定されたデータを変数に入れる
                        var IventInfo = context.Ivents.Single(x => x.IventNumber == numberCount);

                        //変数に入ったデータをDBから削除する
                        context.Ivents.Remove(IventInfo);
                        //DBの変更を保存する
                        context.SaveChanges();

                        //選択したNumberよりIventNumberが後のイベントの個数だけループ
                        for (int i = 1; i <= countIvent - numberCount; i++)
                        {
                            //指定されたNumberより後のイベントの情報を変数に保存
                            var sInfo = context.Ivents.Single(x => x.IventNumber == numberCount + i);

                            //指定されたNumberより後のイベントのIventNumberを-1
                            sInfo.IventNumber = sInfo.IventNumber - 1;

                            //変更したDBのデータを保存
                            context.SaveChanges();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("削除するものがありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        cmbNumberItem();

                        cmbNumber.SelectedIndex = 0;

                        return;
                    }
                }

                //イベントの総数を-1
                countIvent = countIvent - 1;

                //Numberのコンボボックスのアイテムを初期化
                cmbNumber.Items.Clear();

                //データグリッドビューの列と行の初期化
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                //データグリッドビューの初期設定
                ColumnFirst();

                //DBから情報を取り出してデータグリッドビューに表示させる
                RistDBArrayKeep();

                //Numberのコンボボックスのアイテムを変更
                cmbNumberItem();

                //numberのコンボボックスのアイテム値を0に
                cmbNumber.SelectedIndex = 0;
            }
        }

        //閉じるボタンが押されたとき
        private void btnClose_Click(object sender, EventArgs e)
        {
            //フォームの作成
            Form1 form1 = new Form1(Form1cmbMonth, Form1Bool);

            //フォームを隠す
            this.Hide();

            //フォームを閉じる
            this.Close();

            //フォームを表示させる
            form1.ShowDialog();
        }

        //月のコンボボックスのアイテムが変更されたとき
        public void cmbMonth4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMonth4Changed();
        }

        public void cmbMonth4Changed()
        {
            //月の数を入れる変数
            int Month = 0;

            //選択していた日の変数
            int Day = 0;

            YearCount = cmbYear.SelectedItem.ToString();
            int Year = int.Parse(YearCount);

            //変数に月のコンボボックスのアイテム値を入れる
            Month = cmbMonth4.SelectedIndex;
            Day = cmbDay4.SelectedIndex;

            //変換した数がうるう年のときTrueを変数に保存
            Uruu = DateTime.IsLeapYear(Year);

            //日のコンボボックスのアイテムをクリア
            cmbDay4.Items.Clear();

            //月に対して日数が30日のとき
            if (Month == 0 || Month == 2 || Month == 5 || Month == 7)
            {
                cmbDay4.Items.AddRange(Day30);
            }
            else if (Month == 10)  //28日のとき
            {
                if (Uruu == true)
                {
                    cmbDay4.Items.AddRange(Day29);
                }
                else if (Uruu == false)
                {
                    cmbDay4.Items.AddRange(Day28);
                }
            }
            else  //31日のとき
            {
                cmbDay4.Items.AddRange(Day31);
            }

            try
            {
                //最初選択していた日を選択する
                cmbDay4.SelectedIndex = Day;
            }
            catch
            {
                //選択していた日がなければ初期値の1に
                cmbDay4.SelectedIndex = 0;
            }
        }

        //データグリッドビューのセルがクリックされたとき
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //もしnumberのコンボボックスのアイテムが変更されているとき
            if (changeYesNo == false)
            {
                //データグリッドビューの選択をキャンセル
                dataGridView1.ClearSelection();
                //メソッド終了
                return;
            }

            //選択したデータグリッドビューの行の数を入れる変数
            countRow = dataGridView1.CurrentCell.RowIndex;

            //データグリッドビューのデータを入れる変数
            string NumberData = "";

            //数をintに変える変数
            int MathNumber = 0;

            //データグリッドビューのデータを変数に入れる
            NumberData = dataGridView1.Rows[countRow].Cells[0].Value.ToString();

            //データグリッドビューから取り出したデータをintに変換する
            MathNumber = int.Parse(NumberData) - 1;

            //データグリッドビューのデータを入れた変数をアイテムに入れる
            cmbNumber.SelectedIndex = MathNumber;

            //number以外のデータグリッドビューからのデータを保存し表示する
            DataNotNumber(MathNumber + 1);
        }

        //Numberのコンボボックスのアイテムが変更されたとき
        public void cmbNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //numberのコンボボックスのアイテム値を保存
            numberLabel = cmbNumber.SelectedItem.ToString();

            //Numberのコンボボックスのアイテム値が戻るのとき
            if (numberLabel == "戻る")
            {
                //Yes,Noメッセージボックスを表示→結果を変数に保存
                DialogResult result = MessageBox.Show("新規作成から戻りますか？", "確認", MessageBoxButtons.YesNoCancel);

                //はいが押されたとき
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Numberのコンボボックスのアイテムが変更されたとき他のフォーラムも変更されるようにする
                    changeYesNo = true;

                    //追加ではなく更新の状態にする
                    AddOrUpdate = true;

                    //Numberのコンボボックスのアイテムを変更
                    cmbNumberItem();

                    //numberのコンボボックスの初期値を1に
                    cmbNumber.SelectedIndex = 0;
                }
                //いいえが押されたとき
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    //Numberのコンボボックスのアイテム初期値をイベントの総数に
                    cmbNumber.SelectedIndex = 1;
                    //メソッドを終了
                    return;
                }
            }

            //Numberのコンボボックスのアイテムが変更されたときそのほかのフォーラムも変更するか判断するためのbool変数がtrueのとき
            //Numberのコンボボックスのアイテムが変更されたときそのほかのフォーラムも変更する
            if (changeYesNo == true)
            {
                //後に選択したNumberのコンボボックスのアイテム値を保存する
                numberAfter = cmbNumber.SelectedIndex + 1;

                //number以外のデータグリッドビューからのデータを保存し表示
                DataNotNumber(numberAfter);

                //以前選択していたNumberのコンボボックスのアイテム値を保存する
                numberBefore = cmbNumber.SelectedIndex + 1;
            }
        }

        //データグリッドビューの初期設定
        public void ColumnFirst()
        {
            //行単位で選択するようにする
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //行と列の高さを変更できないように
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            //セルの複数行選択をオフに
            dataGridView1.MultiSelect = false;
            //セルの編集ができないように
            dataGridView1.ReadOnly = true;

            //左端の項目列を削除
            dataGridView1.RowHeadersVisible = false;
            //行の自動追加をオフ
            dataGridView1.AllowUserToAddRows = false;
            //奇数業の背景色を変更
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            //選択した行の背景色を変更
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Pink;
            //列ヘッダーの背景色を変更
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;

            //カラム数を指定
            dataGridView1.ColumnCount = 7;
            //カラムの項目名を追加
            dataGridView1.Columns[0].HeaderText = "No.";
            dataGridView1.Columns[1].HeaderText = "年";
            dataGridView1.Columns[2].HeaderText = "月";
            dataGridView1.Columns[3].HeaderText = "日";
            dataGridView1.Columns[4].HeaderText = "用事の名称";
            dataGridView1.Columns[5].HeaderText = "精神的疲労度";
            dataGridView1.Columns[6].HeaderText = "肉体的疲労度";
            //カラムの横幅を設定
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;

            //項目名の文字列を中央揃えに
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //DBを配列に保存するデータグリッドビューに表示
        public void RistDBArrayKeep()
        {
            //疲労度コンボボックスのアイテム名を入れる変数
            string HeartLabel = "";
            string BodyLabel = "";

            //正しい月の数を入れる変数
            int MonthReal = 0;

            //DB使用のための変数を設定
            using (var context = new FatigueContext())
            {
                //DB全体からデータを取り出し変数に入れる
                var sInfo = context.Ivents.OrderBy(x => x.IventNumber);
                //取り出したデータの入った変数を上から順に
                foreach (var IventInfo in sInfo)
                {
                    //月の数を表示と同じに
                    if (IventInfo.IventMonth <= 8)
                    {
                        MonthReal = IventInfo.IventMonth + 4;
                    }
                    if (IventInfo.IventMonth >= 9)
                    {
                        MonthReal = IventInfo.IventMonth - 8;
                    }

                    //取り出したデータを一旦変数に保存
                    Number = IventInfo.IventNumber;
                    YearCount = IventInfo.IventYear;
                    DayCount = IventInfo.IventDay + 1;
                    HeartCount = IventInfo.IventHeart;
                    BodyCount = IventInfo.IventBody;

                    //DBに保存された精神的疲労度が0のとき
                    if (HeartCount == 0)
                    {
                        //精神的疲労度の表示をコンボボックスに合わせる
                        HeartLabel = "なし";
                    }
                    //1のとき
                    if (HeartCount == 1)
                    {
                        HeartLabel = "弱";
                    }
                    //2のとき
                    if (HeartCount == 2)
                    {
                        HeartLabel = "中";
                    }
                    //3のとき
                    if (HeartCount == 3)
                    {
                        HeartLabel = "強";
                    }

                    //DBに保存された肉体的疲労度が0のとき
                    if (BodyCount == 0)
                    {
                        //肉体的疲労度の表示をコンボボックスに合わせる
                        BodyLabel = "なし";
                    }
                    //1のとき
                    if (BodyCount == 1)
                    {
                        BodyLabel = "弱";
                    }
                    //2のとき
                    if (BodyCount == 2)
                    {
                        BodyLabel = "中";
                    }
                    //3のとき
                    if (BodyCount == 3)
                    {
                        BodyLabel = "強";
                    }

                    //配列に保存
                    DBArray[0] = Number.ToString();
                    DBArray[1] = YearCount;
                    DBArray[2] = MonthReal.ToString();
                    DBArray[3] = DayCount.ToString();
                    DBArray[4] = IventInfo.IventLabel;
                    DBArray[5] = HeartLabel;
                    DBArray[6] = BodyLabel;

                    //保存した配列をデータグリッドビューに挿入
                    dataGridView1.Rows.Add(DBArray);

                    //イベントの総数の+1を変数に保存
                    countIvent = IventInfo.IventNumber;
                }
            }
        }

        //number以外のデータグリッドビューからのデータを保存し表示
        public void DataNotNumber(int a)  //例）a = DBの取り出したいnumber
        {
            //DB使用のための変数を設定
            using (var context = new FatigueContext())
            {
                try
                {
                    //DBの指定したデータのみを抜き出して変数に保存する
                    var IventInfo = context.Ivents.Single(x => x.IventNumber == a);

                    //抜き出したデータをそれぞれの変数に代入する
                    YearCount = IventInfo.IventYear;
                    MonthCount = IventInfo.IventMonth;
                    DayCount = IventInfo.IventDay;
                    LabelText = IventInfo.IventLabel;
                    HeartCount = IventInfo.IventHeart;
                    BodyCount = IventInfo.IventBody;
                }
                catch
                {
                    return;
                }
            }

            int Year = int.Parse(YearCount);
            Year = Year - 2023;

            //変数の中に入ったデータをそれぞれのアイテムに代入する
            cmbYear.SelectedIndex = Year;
            cmbMonth4.SelectedIndex = MonthCount;
            cmbDay4.SelectedIndex = DayCount;
            textBox1.Text = LabelText;
            cmbHeart4.SelectedIndex = HeartCount;
            cmbBody4.SelectedIndex = BodyCount;
        }

        //numberのコンボボックスのアイテムを入れ替える
        public void cmbNumberItem()
        {
            //numberのコンボボックスのアイテムを初期化
            cmbNumber.Items.Clear();

            //cmbNumberに入れるアイテムを入れる配列を初期化（項目数はイベントの総数）
            NumberItem = new string[countIvent];

            //ループで数えた数を一時的に保存する配列
            int count = 0;

            //イベントの総数だけループ
            for (int i = 0; i < countIvent; i++)
            {
                //1からイベントの総数だけ配列に保存
                count = i + 1;
                NumberItem[i] = count.ToString();
            }

            //保存した配列をNumberのコンボボックスのアイテムに挿入
            cmbNumber.Items.AddRange(NumberItem);

            if (cmbNumber.Items.Count == 0)
            {
                cmbNumber.Items.Add("なし");

                cmbMonth4.SelectedIndex = 0;
                cmbDay4.SelectedIndex = 0;
                textBox1.Text = "";
                cmbHeart4.SelectedIndex = 0;
                cmbBody4.SelectedIndex = 0;
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMonth4Changed();
        }
    }
}
