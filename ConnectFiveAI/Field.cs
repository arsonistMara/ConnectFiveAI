/*
 *************************************************************************
 * AI for "Connect Five" game.                               	         *
 *                                                                   	 *
 * This program should be used for Connect Five Competition.          	 *
 * Connect Five is the game like Connect Four; for more information see  *
 * http://www.math.spbu.ru/user/chernishev/connectfive/connectfive.html  *
 *                                                                   	 *
 * Author: Ekaterina Balakina                                            *
 * Email: kato.balakina@gmail.com                         	             *
 * Year: 2015                                                        	 *
 * See the LICENSE file in the project root for more information.        *
 *************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFiveAI {

    /// <summary>
    /// A class to store the game field and to operate with changes that may happen to the field. Also has methods to check
    /// whether a particular player has a victory combination on the current state of the field.
    /// </summary>
    public class Field {
        const int FSIZE = 10, HOLE1 = 4, HOLE2 = 5, WINLINE = 5;

        public int[][] body = new int[FSIZE][];

        /// <summary>
        /// Creates an empty field 
        /// </summary>
        public Field() {
            for (int i = 0; i < FSIZE; i++)
                body[i] = new int[FSIZE];
        }

        /// <summary>
        /// Adds a particular symbol to the column.
        /// </summary>
        /// <param name="pos">The number of the column to be changed</param>
        /// <param name="player">1 for 'X, 2 for 'Y'</param>
        public void Add(int pos, int player) {
            for (int i = 0; i < ((pos != HOLE1 && pos != HOLE2) ? FSIZE - 1 : FSIZE - 2); i++)
                body[i][pos] = body[i + 1][pos];
            body[(pos != HOLE1 && pos != HOLE2) ? FSIZE - 1 : FSIZE - 2][pos] = player;
        }

        /// <summary>
        /// Deletes the last symbol in the column
        /// </summary>
        /// <param name="pos">The number of the column to be changed</param>
        public void Remove(int pos) {
            for (int i = (pos != HOLE1 && pos != HOLE2) ? FSIZE - 1 : FSIZE - 2; i > 0; i--) {
                body[i][pos] = body[i - 1][pos];
            }
            body[0][pos] = 0;
        }

        /// <summary>
        /// Checks if the player has he victory combination
        /// </summary>
        /// <param name="player">1 for 'X, 2 for 'Y'</param>
        public bool IsWin(int player) {
            if (CheckRow(player) || CheckCol(player) || CheckDiag(player))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the player has the victory combination in a row
        /// </summary>
        /// <param name="player">1 for 'X, 2 for 'Y'</param>
        public bool CheckRow(int player) {
            for(int i = 0; i < FSIZE; i++) {
                int cnt = 0;
                for (int j = 0; j < FSIZE; j++) {
                    if (body[i][j] == player) {
                        cnt++;
                        if (cnt == WINLINE)
                            return true;
                    }
                    else
                        cnt = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the player has the victory combination in a column
        /// </summary>
        /// <param name="player">1 for 'X, 2 for 'Y'</param>
        public bool CheckCol(int player) {
            for (int i = 0; i < 10; i++) {
                int cnt = 0;
                for (int j = 0; j < 10; j++) {
                    if (body[j][i] ==  player) { 
                        cnt++;
                        if (cnt == WINLINE)
                            return true;
                    }
                    else
                        cnt = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the player has the victory combination in a diagonal
        /// </summary>
        /// <param name="player">1 for 'X, 2 for 'Y'</param>
        public bool CheckDiag(int player) {
           
            for (int i = 0; i < 10; i++) {

                int cnt = 0;
                int j = 0;

                for (int k = i; k >= 0; k--) {
                    if (body[k][j] == player) {
                        cnt++;
                        if (cnt == 5)
                            return true;
                    }
                    else
                        cnt = 0;
                    j++;
                }

                cnt = 0;
                j = 0;

                for (int k = i; k < 10; k++) {
                    if (body[k][j] == player) {
                        cnt++;
                        if (cnt == WINLINE)
                            return true;
                    }
                    else
                        cnt = 0;
                    j++;
                }
            }

            for (int i = 0; i < 10; i++) {

                int cnt = 0;
                int j = 9;

                for (int k = i; k > 0; k--) {
                        if (body[k][j] == player) {
                            cnt++;
                            if (cnt == WINLINE)
                                return true;
                        }
                        else
                            cnt = 0;
                        j--;
                }

                cnt = 0;
                j = 9;

                for (int k = i; k < 10; k++) {
                    if (body[k][j] == player) {
                        cnt++;
                        if (cnt == WINLINE)
                            return true;
                    }
                    else
                        cnt = 0;
                    j--;
                }
            }
            return false;
        }
    }
}
