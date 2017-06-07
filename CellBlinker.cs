/**
 * Author: Taha Uygun
 * Mail Control TicTacToe
 */

using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using TicTacToe.Forms;

namespace TicTacToe
{
    // Provides a blinking effect of <see cref="Cell"/>s.
    static class CellBlinker
    {
        private static Color restoreColor;
        private static Color blinkColor = Color.Yellow;
        private static Cell[] setToBlink;
        private static int time;
        private static readonly Timer timerBlink = new Timer();

        // Gets or sets whether the grid is currently blinking.
        public static bool IsBlinking { get; set; }

        // Occurs when the blinking sequence has ended.
        public static event EventHandler BlinkingEnded = delegate {};

        static CellBlinker()
        {
            timerBlink.Interval = 500;
            timerBlink.Tick += timerBlink_Tick;
        }

        // Blinks the specified cells with the specified color.
        public static void BlinkCells(Color blinkColor, Cell[] cellsToBlink)
        {
            IsBlinking = true;
            restoreColor = cellsToBlink[0].BackColor;
            CellBlinker.blinkColor = blinkColor;
            setToBlink = cellsToBlink;
            time = 0;
            timerBlink.Start();
        }

        // Gets whether a number is odd.
        private static bool IsNumberOdd(int number)
        {
            return (number & 1).Equals(0);
        }

        private static void timerBlink_Tick(object sender, EventArgs e)
        {
            if (time == 3)
            {
                timerBlink.Stop();
                ChangeBackColorOfCells(restoreColor);
                IsBlinking = false;
                BlinkingEnded(null, EventArgs.Empty);
            }
            else
            {
                Color color = IsNumberOdd(time) ? blinkColor : restoreColor;
                ChangeBackColorOfCells(color);
                time++;
            }
        }

        // Changes the background color of the current set range of cells.
        private static void ChangeBackColorOfCells(Color color)
        {
            foreach (Cell cell in setToBlink)
                cell.BackColor = color;
        }
    }
}
