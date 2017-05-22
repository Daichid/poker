using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerBase
{
    class Poker
    {
        /// <summary>
        /// カードを表現するための構造体
        /// </summary>
        public struct card
        {
            public string suit; //スート: s, h, d, cの4種類
            public int num; //数字: 1-13

            /// <summary>
            /// 初期化処理，数字とスートを与える
            /// </summary>
            /// <param name="n">数字</param>
            /// <param name="s">スート</param>
            public card(int n, string s)
            {
                suit = s;
                num = n;
            }

            /// <summary>
            /// 表示のためにスートと数字を文字列化（例：d4）
            /// </summary>
            /// <returns>文字列化したカードを返す</returns>
            public string disp()
            {
                return suit + num.ToString(); 
            }
        }

        private List<card> deck; //山札（リスト型）
        private card[] Hand;
        public card[] hand
        {
            get { return Hand; }
        } //手札（配列）

        /// <summary>
        /// カードをシャッフルし，山札と初期手札をつくるコンストラクタ
        /// </summary>
        public Poker() //初期化
        {
            deck = new List<card>();
            Hand = new card[5];
            int count = 0;

            for (int i = 1; i <= 13; i++) //52枚のカードを作る
            {
                foreach (string s in new string[] { "s", "h", "d", "c" })
                {
                    card c = new card(i, s);
                    deck.Add(c);
                    count++;
                }
            }

            deck = deck.OrderBy(i => Guid.NewGuid()).ToList(); //カードをシャッフルする

            for (int i = 0; i < 5; i++) //先頭5枚を手札に入れてdeckから削除
            {
                Hand[i] = deck[0];
                deck.RemoveAt(0);
            }
        }

        /// <summary>
        /// 引数で与えられた番号の手札を交換するメソッド
        /// </summary>
        /// <param name="selectedCards">交換する番号が入った配列</param>
        public void change(int[] selectedCards)
        {
            foreach (int i in selectedCards) //選択されたカードのみ交換する
            {
                Hand[i] = deck[0];
                deck.RemoveAt(0);
            }
        }
    }
}
