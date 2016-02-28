using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFiveAI {
    public class Field {
        public int[][] body = new int[10][];

        public Field() {
            for (int i = 0; i < 10; i++)
                body[i] = new int[10];
        }

        public void Add(int pos, int player) {
            for (int i = 0; i < ((pos != 4 && pos != 5) ? 9 : 8); i++)
                body[i][pos] = body[i + 1][pos];
            body[(pos != 4 && pos != 5) ? 9 : 8][pos] = player;
        }

        public void Remove(int pos) {
            for (int i = (pos != 4 && pos != 5) ? 9 : 8; i > 0; i--) {
                body[i][pos] = body[i - 1][pos];
            }
            body[0][pos] = 0;
        }

        public bool IsWin(int player) {
            if (CheckRow(player) || CheckCol(player) || CheckDiag(player))
                return true;
            else
                return false;
        }

        public bool CheckRow(int player) {
            for(int i = 0; i < 10; i++) {
                int cnt = 0;
                for (int j = 0; j < 10; j++) {
                    if (body[i][j] == player) {
                        cnt++;
                        if (cnt == 5)
                            return true;
                    }
                    else
                        cnt = 0;
                }
            }
            return false;
        }
        
        public bool CheckCol(int player) {
            for (int i = 0; i < 10; i++) {
                int cnt = 0;
                for (int j = 0; j < 10; j++) {
                    if (body[j][i] ==  player) { 
                        cnt++;
                        if (cnt == 5)
                            return true;
                    }
                    else
                        cnt = 0;
                }
            }
            return false;
        }

    
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
                        if (cnt == 5)
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
                            if (cnt == 5)
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
                        if (cnt == 5)
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
