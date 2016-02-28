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
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFiveAI {
    class Start {
        /// <summary>
        /// Starts the game
        /// </summary>
        /// <param name="args">
        /// [0] path to the game folder 
        /// [1] player's symbol
        /// [2] allowed game turn duration (time limit) </param>
        static void Main(string[] args) {
            try {
                Solution game = new Solution(args[0], args[1] == "X" ? 1 : 2, Convert.ToInt32(args[2]));
            }
            catch(Exception e) {
                File.WriteAllLines("Exception.txt", new string[] { e.Message, e.StackTrace });
                throw;
            }
        }
    }
}
