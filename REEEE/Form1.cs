using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REEEE {
    public partial class Form1 : Form {
        static int[] num_to_bits = new int[16] 
        { 0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4 };
        const int w = 60; //width of a cell
        const int m = 3; // m for margin
        ulong red;
        ulong blue;
        ulong board;
        bool hints = false;
        bool blueTurn;

        public Form1() {
            InitializeComponent();

            initBoard();
        }

        void initBoard() {
            blueTurn = true;
            board = 0;
            red = 0;
            red |= 1L << (3 * 8 + 3);
            red |= 1L << (4 * 8 + 4);
            blue = 0;
            blue |= 1L << (3 * 8 + 4);
            blue |= 1L << (4 * 8 + 3);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            int blueStones, redStones;
            e.Graphics.FillRectangle(Brushes.LightGray, 0, 0, w*8, w*8);

            blueStones = countSetBitsRec(blue);
            redStones = countSetBitsRec(red);

            //init possible moves and set label
            initTurn();

            drawRaster(e.Graphics);

            //if no possible moves, yield turn to other player
            if (board == 0L) {
                if (~(red | blue) == 0L) {
                    if(blueStones > redStones)
                        playerTurn.Text = "Game over: Blauw wint";
                    else if(blueStones != redStones)
                        playerTurn.Text = "Game over: Rood wint";
                    else
                        playerTurn.Text = "Game over: Gelijkspel";
                } else {
                    blueTurn = !blueTurn;
                    initTurn();
                }
            }

            num_blue.Text = "" + countSetBitsRec(blue);
            num_red.Text = "" + countSetBitsRec(red);

            for (int j = 0; j < 8; j++) {
                for (int i = 0; i < 8; i++) {
                    ulong bit = (ulong)1L << (j * 8 + i);
                    if ((red & bit) != 0)
                        e.Graphics.FillEllipse(Brushes.Red, i * w + m, j * w + m, w - 2*m, w - 2*m);
                    else if ((blue & bit) != 0)
                        e.Graphics.FillEllipse(Brushes.Blue, i * w + m, j * w + m, w - 2 * m, w - 2 * m);
                    else if (hints && (board & bit) != 0)
                        e.Graphics.FillRectangle(Brushes.Yellow, i * w + m, j * w + m, w - 2 * m, w - 2 * m);
                }
            }
        }

        void initTurn() {
            if (blueTurn) {
                initPoss(blue, red);
                playerTurn.Text = "Blauw aan beurt";
            } else {
                initPoss(red, blue);
                playerTurn.Text = "Rood aan beurt";
            }
        }

        void initPoss(ulong P, ulong O) {
            board = 0L;
            for (byte i = 0; i < 64; i++) {
                ulong bit = (ulong)1L << i;
                if ((P & bit) != 0)
                    board |= poss(P, O, i);
            }
        }

        ulong poss_dir(ulong P, ulong O, byte move, int dX, int dY) {
            ulong flips = 0;
            int i = (move % 8) + dX;
            int j = (move / 8) + dY;

            while ((i >= 0) && (i < 8) && (j >= 0) && (j < 8)) {
                ulong bit = (ulong)1L << (j * 8 + i);
                if ((O & bit) != 0)
                    flips |= bit;
                else if (flips != 0 && (P & bit) == 0)
                    return bit;
                else
                    return 0;
                i += dX;
                j += dY;
            }
            return 0;
        }
        ulong poss(ulong P, ulong O, byte move) {
            return move == 64 ? 0L :
                   poss_dir(P, O, move, -1, -1)
                 | poss_dir(P, O, move, -1, 0)
                 | poss_dir(P, O, move, -1, +1)
                 | poss_dir(P, O, move, 0, -1)
                 | poss_dir(P, O, move, 0, +1)
                 | poss_dir(P, O, move, +1, -1)
                 | poss_dir(P, O, move, +1, 0)
                 | poss_dir(P, O, move, +1, +1);
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e) {
            int x = 8 * e.X / 480;
            int y = 8 * e.Y / 480;
            ulong bit = (ulong)1L << (y * 8 + x);
            if ((board & bit) != 0) {
                if (blueTurn) {
                    bit |= flipColor(blue, red, x, y);
                    blue |= bit;
                    red &= ~bit;
                } else {
                    bit |= flipColor(red, blue, x, y);
                    red |= bit;
                    blue &= ~bit;
                }
                blueTurn = !blueTurn;
                panel1.Invalidate();
            }
        }

        // flips discs in one direction
        ulong flip_dir(ulong P, ulong O, byte move, int dX, int dY) {
            ulong flips = 0;
            int i = (move % 8) + dX;
            int j = (move / 8) + dY;

            while ((i >= 0) && (i < 8) && (j >= 0) && (j < 8))
            {
                ulong bit = (ulong)1L << (j * 8 + i);
                if ((O & bit) != 0)
                    flips |= bit;
                else if ((P & bit) != 0)
                    return flips; 
                else 
                    return 0;
                i += dX;
                j += dY;
            }
            return 0;
        }

        ulong flip(ulong P, ulong O, byte move) {
            return move == 64 ? 0L :
                   flip_dir(P, O, move, -1, -1)
                 | flip_dir(P, O, move, -1, 0)
                 | flip_dir(P, O, move, -1, +1)
                 | flip_dir(P, O, move, 0, -1)
                 | flip_dir(P, O, move, 0, +1)
                 | flip_dir(P, O, move, +1, -1)
                 | flip_dir(P, O, move, +1, 0)
                 | flip_dir(P, O, move, +1, +1);
        }

        

        ulong flipColor(ulong P, ulong O, int x, int y) {
            return flip(P, O, (byte)(y * 8 + x));
        }

        private void new_game_Click(object sender, EventArgs e) {
            initBoard();
            panel1.Invalidate();
        }

        private void help_button_Click(object sender, EventArgs e) {
            hints = !hints;
            panel1.Invalidate();
        }

        static int countSetBitsRec(ulong num) {
            int nibble = 0;
            if (0 == num)
                return num_to_bits[0];

            // Find last nibble 
            nibble = (int)(num & 0xf);

            return num_to_bits[nibble] + countSetBitsRec(num >> 4);
        }

        void drawRaster(Graphics g) {
            for(int i = 0; i <= 8; i++) {
                g.DrawLine(Pens.Black, 0, i * w, 8 * w, i * w);
            }
            for (int i = 0; i <= 8; i++) {
                g.DrawLine(Pens.Black, i * w, 0, i * w, 8 * w);
            }
        }
    }
}
