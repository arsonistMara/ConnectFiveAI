using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConnectFiveAI {

    public sealed class Solution {
        private string pathname;
        private int player, time;
        private Field field;

        public Solution(string _pathname, int _player, int _time) {
            pathname = _pathname;
            player = _player;
            time = _time;
            Solve();
        }

        public void Init(String pathname, int player) {
            int num = Directory.GetFiles(pathname).Length;
            for (int i = 1; i <= num / 2; i++) {
                int pos = Convert.ToInt32(File.ReadAllLines(pathname + 'X' + i + ".txt")[0]);
                field.Add(pos, 1);
                
                pos = Convert.ToInt32(File.ReadAllLines(pathname + 'O' + i + ".txt")[0]);
                field.Add(pos, 2);
            }
            if (num % 2 != 0) {
                int pos = Convert.ToInt32(File.ReadAllLines(pathname + 'X' + (num / 2 + 1) + ".txt")[0]);
                field.Add(pos, 1);
            }
        }

        private void Solve() {
            field = new Field();
            Init(pathname, player);
            LookForward(player, player == 1 ? 2 : 1);
        }

        private void LookForward(int player, int enemy) {
            Random r = new Random();
            List<int> l = new List<int>();
            int step = Directory.GetFiles(pathname).Length / 2 + 1;

            for (int i = 0; i < 10; i++) {
                if (field.body[0][i] == 0) {
                    field.Add(i, player);

                    if (field.IsWin(player)) {
                        File.WriteAllLines(pathname + (player == 1 ? 'X' : 'O') + step + ".txt", new String[]{ i.ToString()});
                        return;
                    }

                    bool flag = true;
                    if (field.IsWin(enemy)) {
                        field.Remove(i);
                        continue;
                    }

                    for (int j = 0; j < 10; j++) {
                        if (field.body[0][j] == 0) {
                            field.Add(j, enemy);
                            if (field.IsWin(enemy)) {
                                flag = false;
                                field.Remove(j);
                                break;
                            }
                            field.Remove(j);
                        }
                    }
                    if (flag)
                        l.Add(i);

                    field.Remove(i);
                }
            }

            if (l.Count != 0) {
                int pos = r.Next(l.Count);
                File.WriteAllLines(pathname + (player == 1 ? 'X' : 'O') + step + ".txt",
                    new String[] { l[pos].ToString() });
            }
            else {
                for (int i = 0; i < 10; i++) {
                    if (field.body[0][i] == 0) {
                        File.WriteAllLines(pathname + (player == 1 ? 'X' : 'O') + step + ".txt", 
                            new String[] { i.ToString() });
                        return;
                    }
                }
            }
          }
    }
}
