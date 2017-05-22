using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PokerBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Tactics tact;
        Poker poker;

        /// <summary>
        /// 配るボタンを押したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //すべてのテキストボックスを初期化
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";

            //次のボタンを使えるようにして，このボタンを使えなくする．
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            
            //初期化処理を行って，カードを表示．
            poker = new Poker(); //カードを配ったりするためのクラス
            tact = new Tactics(); //戦略が実装されているクラス
            for (int i = 0; i < 5; i++ )
            {
                this.textBox1.Text += poker.hand[i].disp();
                //dispは手札の表示用に成形するメソッド
                if (i < 4)
                {
                    this.textBox1.Text += "\t";
                }
            }
        }

        /// <summary>
        /// １番目の交換ボタンを押したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //次のボタンを使えるようにして，このボタンを使えなくする．
            this.button2.Enabled = false;
            this.button3.Enabled = true;

            //カードを交換
            //tacticsメソッドに現在の手札と回数を渡して，交換するカード番号を受け取る
            Poker.card[] temp = new Poker.card[5];
            poker.hand.CopyTo(temp, 0);
            int[] changingCards = tact.tactics(temp, 1);
            poker.change(changingCards);//カードの交換処理をする

            //カードを表示
            for (int i = 0; i < 5; i++)
            {
                this.textBox2.Text += poker.hand[i].disp();
                if (i < 4)
                {
                    this.textBox2.Text += "\t";
                }
            }
        }

        /// <summary>
        /// ２番目の交換ボタンを押したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //次のボタンを使えるようにして，このボタンを使えなくする．
            this.button3.Enabled = false;
            this.button4.Enabled = true;

            //カードを交換
            //tacticsメソッドに現在の手札と回数を渡して，交換するカード番号を受け取る
            Poker.card[] temp = new Poker.card[5];
            poker.hand.CopyTo(temp, 0);
            int[] changingCards = tact.tactics(temp, 2);
            poker.change(changingCards);//カードの交換処理をする

            //カードを表示
            for (int i = 0; i < 5; i++)
            {
                this.textBox3.Text += poker.hand[i].disp();
                if (i < 4)
                {
                    this.textBox3.Text += "\t";
                }
            }
        }

        /// <summary>
        /// ３番目の交換ボタンを押したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //次のボタンを使えるようにして，このボタンを使えなくする．
            this.button4.Enabled = false;
            this.button5.Enabled = true;

            //カードを交換
            //tacticsメソッドに現在の手札と回数を渡して，交換するカード番号を受け取る
            Poker.card[] temp = new Poker.card[5];
            poker.hand.CopyTo(temp, 0);
            int[] changingCards = tact.tactics(temp, 3);
            poker.change(changingCards);//カードの交換処理をする

            //カードを表示
            for (int i = 0; i < 5; i++)
            {
                this.textBox4.Text += poker.hand[i].disp();
                if (i < 4)
                {
                    this.textBox4.Text += "\t";
                }
            }
        }

        /// <summary>
        /// ４番目の交換ボタンを押したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //次のボタンを使えるようにして，このボタンを使えなくする．
            this.button5.Enabled = false;
            this.button6.Enabled = true;

            //カードを交換
            //tacticsメソッドに現在の手札と回数を渡して，交換するカード番号を受け取る
            Poker.card[] temp = new Poker.card[5];
            poker.hand.CopyTo(temp, 0);
            int[] changingCards = tact.tactics(temp, 4);
            poker.change(changingCards);//カードの交換処理をする

            //カードを表示
            for (int i = 0; i < 5; i++)
            {
                this.textBox5.Text += poker.hand[i].disp();
                if (i < 4)
                {
                    this.textBox5.Text += "\t";
                }
            }
        }

        /// <summary>
        /// ５番目の交換ボタンを押したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //次のボタンを使えるようにして，このボタンを使えなくする．
            this.button6.Enabled = false;
            this.button1.Enabled = true;

            //カードを交換
            //tacticsメソッドに現在の手札と回数を渡して，交換するカード番号を受け取る
            Poker.card[] temp = new Poker.card[5];
            poker.hand.CopyTo(temp, 0);
            int[] changingCards = tact.tactics(temp, 5);
            poker.change(changingCards);//カードの交換処理をする

            //カードを表示
            for (int i = 0; i < 5; i++)
            {
                this.textBox6.Text += poker.hand[i].disp();
                if (i < 4)
                {
                    this.textBox6.Text += "\t";
                }
            }

        }
    }
}
