using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerBase
{
    class Tactics
    {
        /// <summary>
        /// 手札と回数から何を変更するべきか決定するプログラムメソッド（これを作成する）
        /// </summary>
        /// <param name="hand">手札</param>
        /// <param name="times">回数</param>
        /// <returns>変更するカード番号を返す</returns>
        public int[] tactics(Poker.card[] hand, int times)
        {
            int jud;
            int[] pairstack = new int[20]; //ペア配列
            int stp=0;
            int[] changeAry = new int[6];
            int[] changeCard = new int[5];
            
            //配列
            pairstack = aryIni(pairstack, 5);
            changeAry = aryIni(changeAry, 0);


            if (times < 3)
            {
                //フラッシュの判定
                switch (flash(hand))
                {
                    case 0:
                        return new int[] { 0 };
                    case 1:
                        return new int[] { 1 };
                    case 2:
                        return new int[] { 2 };
                    case 3:
                        return new int[] { 3 };
                    case 4:
                        return new int[] { 4 };
                    case 5:
                        return new int[] { };
                    default:
                        break;
                }
            }

            //ペアがあるか判定
            //ペアの組は配列に格納
            for (int i = 0; i < hand.Length-1; i++) {
                for (int j = i + 1; j < hand.Length; j++) {

                    jud=pairJud(hand, i,j);

                    //ペアの時組を配列に格納
                    if (jud == 1) {
                        pairstack[stp] = i;
                        stp++;
                        pairstack[stp] = j;
                        stp++;
                    }
                }

            }

            //ペア配列を調べる
            for (int i = 0; i < pairstack.Length; i++) {

                switch (pairstack[i]) {
                    case 0:
                        changeAry[0]++;
                        break;
                    case 1:
                        changeAry[1]++;
                        break;
                    case 2:
                        changeAry[2]++;
                        break;
                    case 3:
                        changeAry[3]++;
                        break;
                    case 4:
                        changeAry[4]++;
                        break;
                    default:
                        changeAry[5]++;
                        break;
                }
            }

            //手札がブタなら1枚目のみ残してチェンジ
            if (changeAry[5] == 20) {
                return new int[] { 1, 2, 3, 4 };
            }

            int countnum=0;

            for (int i = 0; i < changeAry.Length - 1; i++) {
                if (changeAry[i] <= 0) {
                    //i番目のカードを交換したい
                    changeCard[countnum]=i;
                    countnum++;
                }
            }

            //変更手札用配列用意
            if (countnum == 0) {
                return new int[] { };
            }

            int[] reCard = new int[countnum];
            for (int i = 0; i < reCard.Length; i++) {
                reCard[i] = changeCard[i];
            }

            return reCard;

            /*//ダミープログラム（奇数回は奇数番，偶数回は偶数番を変更）
            if (times % 2 == 0)
            {
                return new int[] { 0, 2, 4 };
            }

            return new int[] {  };*/
        }

        //ペア判定
        //二つのカードがペアかどうか判定する
        //ペアで1,それ以外で0
        public int pairJud(Poker.card[] hand,int i,int j) {
            if (hand[i].num == hand[j].num)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //配列初期化
        public int[] aryIni(int[] ary, int x) {
            for (int i = 0; i < ary.Length; i++) {
                ary[i] = x;
            }
            return ary;
        }

        ///フラッシュができるかどうか判定する関数
        ///返し値は４枚か５枚揃ってる時に４枚の時は「４と変更する手札の番号」、
        ///５枚揃ってる時は「５と存在しない手札番号（５）」

        public int flash(Poker.card[] hand)
        {
            int count = 0;
            int maxc = 0;
            int hazure = 0;
            int i, j;

            for (i = 0; i < hand.Length-1; i++)　///揃ってるマーク数の最大値を探す
            {
                for (j = i+1; j < hand.Length; j++)

                {
                    if (hand[i].suit == hand[j].suit) count++;
                }
                if (maxc < count) {
                    maxc = count;
                    count = 0;
                }

            }
           // if (maxc < 4)
             //   return 6;///揃ってるマーク数が３以下の時フラッシュをやめるため[6]を返す

            /// 揃ってるマーク数が４の時変える１枚を探す
            if (maxc == 3)
            {
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        if (hand[i].suit != hand[j].suit) hazure = j;
                    }
                }
                return hazure; ///変える手札の配列番号を返す                     
            }

            if (maxc == 5)  ///揃ってる数が５の時フラッシュで手札を変えてはいけないので[5]
            {return 5; }

            return 6;
        }






    }
}
