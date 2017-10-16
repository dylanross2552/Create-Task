using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireEmblemAmateurEdition
{

    public partial class Form2 : Form
    {
        // the "b" and "w" and "bk" and wk" I use in many of my variables represent "black" "white" "black knight" "whiteknight" this is how I keep track of which knight I am using
        //how I detect if one of the knight has been clicked
        public static bool bk1Clicked = false;
        public static bool bk2Clicked = false;
        public static bool bk3Clicked = false;
        public static bool wk1Clicked = false;
        public static bool wk2Clicked = false;
        public static bool wk3Clicked = false;
        //the variable i created so I could refer to any knight with one variable based on the one I clicked, used in the "highlight" method
        public static bool knightClicked;   
        //this is the boolean that will define whether or not I can click and do something with them. how I do turns and make sure I can only move them once per turn
        public static bool bk1moveable = true;
        public static bool bk2moveable = true;
        public static bool bk3moveable = true;
        public static bool wk1moveable = false;
        public static bool wk2moveable = false;
        public static bool wk3moveable = false;
        public static bool bk1alive = true;
        public static bool bk2alive = true;
        public static bool bk3alive = true;
        public static bool wk1alive = true;
        public static bool wk2alive = true;
        public static bool wk3alive = true;
        public static Control knighthigh;
        // this is the variable that will tell the system which player's turn it is. I only need one since a boolean can have 2 values
        public static bool blackturn = true;
        //variables I reference in several other methods, I needed a universal variable across all of them so I put them here in the class
        public static Control knight;
        public static Control knightbattle;
        public static Control knighth;
        //this is the variable I assign to whatever label is clicked and then use that in the movement method
        public static Control nextspot;
        public static Control labelnum;


        public Form2()
        {
            InitializeComponent();
        }
// controls the movement of the knights after they have been clicked
        public void movement()
        {
            
            //nextspot is assigned when I click a label. when I click a knight it highlights all the squares it can move to 
            //in blue, so if a label is clicked, and is highlighted blue, then it goes through with the movement
            if (nextspot.BackColor == (Color.Blue))
            {
                // these if statements use the clicked function for each knight so I know which label I have to assign to my "knight" variable which I use later in the method
                //I set the moveable variable to false so that the player can't move the same unit again.
                if (bk1Clicked == true)
                {
                    knight = bk1;
                    bk1moveable = false;
                }
                if (bk2Clicked == true)
                {
                    knight = bk2;
                    bk2moveable = false;
                }
                if (bk3Clicked == true)
                {
                    knight = bk3;
                    bk3moveable = false;
                }
                if (wk1Clicked == true)
                {
                    knight = wk1;
                    wk1moveable = false;
                }
                if (wk2Clicked == true)
                {
                    knight = wk2;
                    wk2moveable = false;
                }
                if (wk3Clicked == true)
                {
                    knight = wk3;
                    wk3moveable = false;
                }
                // getting the coordinates of the selected "knight" and also getting the row and column coordinates of the selected "knight"
                var newpos = map.GetCellPosition(nextspot);
                var bpos = map.GetCellPosition(knight);
                var bposc = map.GetColumn(knight);
                var bposr = map.GetRow(knight);
                // I have to remove the label that is in the square where the knight will move to , if I don't the entire board will shift
                map.Controls.Remove(nextspot);
                //move the knight into new position
                map.SetCellPosition(knight, newpos);
                //adding the label back into the board where the knight used to be
                map.Controls.Add(nextspot, bposc, bposr);
                //reset it so that no knight is selected
                bk1Clicked = false;
                bk2Clicked = false;
                bk3Clicked = false;
                wk1Clicked = false;
                wk2Clicked = false;
                wk3Clicked = false;
                //sets the background color of the knight to gray so the play knows they can't move him again
                knight.BackColor = (Color.Gray);
                //clicks a button that is se up to deselect everything
                deselect.PerformClick();
                //another method that checks whether it is white's turn or black's turn
                turncheck();
            }
        }

        public void attack()
        {
            if (knightbattle == bk1)
            {
                bk1moveable = false;
                bk1alive = false;
            }
            if (knightbattle == bk2)
            {
                bk2moveable = false;
                bk2alive = false;
            }
            if (knightbattle == bk3)
            {
                bk3moveable = false;
                bk3alive = false;
            }
            if (knightbattle == wk1)
            {
                wk1moveable = false;
                wk1alive = false;
            }
            if (knightbattle == wk2)
            {
                wk2moveable = false;
                wk2alive = false;
            }
            if (knightbattle == wk3)
            {
                wk3moveable = false;
                wk3alive = false;
            }
            var col = map.GetColumn(knightbattle);
            var row = map.GetRow(knightbattle);
            map.Controls.Remove(knightbattle);
            map.Controls.Add(labelnum, col, row);
            if (knighthigh == bk1)
            {
                bk1moveable = false;
            }
            if (knighthigh == bk2)
            {
                bk2moveable = false;
            }
            if (knighthigh == bk3)
            {
                bk3moveable = false;
            }
            if (knighthigh == wk1)
            {
                wk1moveable = false;
            }
            if (knighthigh == wk2)
            {
                wk2moveable = false;
            }
            if (knighthigh == wk3)
            {
                wk3moveable = false;
            }
            turncheck();
            deselect.PerformClick();
        }
        public void turncheck()
        {
            //after all three black knight have moved, they should all be moveable = false, this checks that, then sets all the white knights to moveable to true, changes the turn variable to kep track, and changes the white background to white to let the player know
            if (bk1moveable == false && bk2moveable == false && bk3moveable == false && blackturn == true)
            {
                if (wk1alive == true)
                {
                    wk1moveable = true;
                }
                if (wk1alive == false)
                {
                    wk1moveable = false;
                }
                if (wk2alive == true)
                {
                    wk2moveable = true;
                }
                if (wk2alive == false)
                {
                    wk2moveable = false;
                }
                if (wk3alive == true)
                {
                    wk3moveable = true;
                }
                if (wk3alive == false)
                {
                    wk3moveable = false;
                }
                blackturn = false;
                wk1.BackColor = (Color.White);
                wk2.BackColor = (Color.White);
                wk3.BackColor = (Color.White);
            }
            //same but revers black and white
            else if (wk1moveable == false && wk2moveable == false && wk3moveable == false && blackturn == false)
            {
                if (bk1alive == true)
                {
                    bk1moveable = true;
                }
                if (bk1alive == false)
                {
                    bk1moveable = false;
                }
                if (bk2alive == true)
                {
                    bk2moveable = true;
                }
                if (bk2alive == false)
                {
                    bk2moveable = false;
                }
                if (bk3alive == true)
                {
                    bk3moveable = true;
                }
                if (bk3alive == false)
                {
                    bk3moveable = false;
                }
                blackturn = true;
                bk1.BackColor = (Color.White);
                bk2.BackColor = (Color.White);
                bk3.BackColor = (Color.White);
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void highlight()
        {
            //checks if each knight is clicked and then sets the two universal variables to that specific knight's corrosponding variable
            if (bk1Clicked == true)
            {
                knighth = bk1;
                knightClicked = bk1Clicked;
                knighthigh = bk1;
            }
            if (bk2Clicked == true)
            {
                knighth = bk2;
                knightClicked = bk2Clicked;
                knighthigh = bk2;
            }
            if (bk3Clicked == true)
            {
                knighth = bk3;
                knightClicked = bk3Clicked;
                knighthigh = bk3;
            }
            if (wk1Clicked == true)
            {
                knighth = wk1;
                knightClicked = wk1Clicked;
                knighthigh = wk1;
            }
            if (wk2Clicked == true)
            {
                knighth = wk2;
                knightClicked = wk2Clicked;
                knighthigh = wk2;
            }
            if (wk3Clicked == true)
            {
                knighth = wk3;
                knightClicked = wk3Clicked;
                knighthigh = wk3;
            }
            //gets the coordinates of the selected knight
            var k1p = map.GetCellPosition(knighth);
            var k1pc = map.GetColumn(knighth);
            var k1pr = map.GetRow(knighth);
            //changes the value of the knight coordinates to get the coordinates of the adjacent squares, and assigns each new row and column value to a different variable
            var Ac = k1pc + 1;
            var Ar = k1pr + 1;

            var Bc = k1pc + 0;
            var Br = k1pr + 1;

            var Cc = k1pc + 1;
            var Cr = k1pr + 0;

            var Dc = k1pc - 1;
            var Dr = k1pr - 1;

            var Ec = k1pc - 1;
            var Er = k1pr - 0;

            var Fc = k1pc - 0;
            var Fr = k1pr - 1;

            var Gc = k1pc + 1;
            var Gr = k1pr - 1;

            var Hc = k1pc - 1;
            var Hr = k1pr + 1;
            //sets the knights background color to gree so the player knows it has been selected
            knighth.BackColor = (Color.ForestGreen);

            //makes sure the column and row values aren't off the grid which would result in an error          
            if (Ac != -1 && Ar != -1 && Ac != 7 && Ar != 7)
            {
                //pulls whatever label is in the specified cell and assigns it to a variable like "A" so now whatever I do to "A" happens to the label in the specified cell
                var A = map.GetControlFromPosition(Ac, Ar);
                //sets the labels color to blue to indicate as a space the knight can move to
                A.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    A.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (A == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (A == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (A == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (A == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (A == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (A == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
            if (Bc != -1 && Br != -1 && Bc != 7 && Br != 7)
            {
                var B = map.GetControlFromPosition(Bc, Br);
                B.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    B.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (B == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (B == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (B == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (B == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (B == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (B == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
            if (Cc != -1 && Cr != -1 && Cc != 7 && Cr != 7)
            {
                var C = map.GetControlFromPosition(Cc, Cr);
                C.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    C.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (C == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (C == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (C == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (C == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (C == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (C == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
            if (Dc != -1 && Dr != -1 && Dc != 7 && Dr != 7)
            {
                var D = map.GetControlFromPosition(Dc, Dr);
                D.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    D.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (D == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (D == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (D == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (D == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (D == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (D == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
            if (Ec != -1 && Er != -1 && Ec != 7 && Er != 7)
            {
                var E = map.GetControlFromPosition(Ec, Er);
                E.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    E.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (E == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (E == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (E == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (E == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (E == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (E == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
            if (Fc != -1 && Fr != -1 && Fc != 7 && Fr != 7)
            {
                var F = map.GetControlFromPosition(Fc, Fr);
                F.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    F.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (F == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (F == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (F == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (F == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (F == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (F == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
            if (Gc != -1 && Gr != -1 && Gc != 7 && Gr != 7)
            {
                var G = map.GetControlFromPosition(Gc, Gr);
                G.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    G.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (G == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (G == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (G == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (G == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (G == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (G == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
            if (Hc != -1 && Hr != -1 && Hc != 7 && Hr != 7)
            {
                var H = map.GetControlFromPosition(Hc, Hr);
                H.BackColor = (Color.Blue);
                if (knightClicked == false)
                {
                    H.BackColor = (Color.White);
                }
                if (knighth == wk1 || knighth == wk2 || knighth == wk3)
                {
                    if (H == bk1)
                    {
                        bk1.BackColor = (Color.Red);
                    }
                    if (H == bk2)
                    {
                        bk2.BackColor = (Color.Red);
                    }
                    if (H == bk3)
                    {
                        bk3.BackColor = (Color.Red);
                    }
                }
                if (knighth == bk1 || knighth == bk2 || knighth == bk3)
                {
                    if (H == wk1)
                    {
                        wk1.BackColor = (Color.Red);
                    }
                    if (H == wk2)
                    {
                        wk2.BackColor = (Color.Red);
                    }
                    if (H == wk3)
                    {
                        wk3.BackColor = (Color.Red);
                    }
                }
            }
        }

        public void bk1_Click(object sender, EventArgs e)
        {
            //clicks the deselect button so that I can't have two knights are selected at one time as long as they aren't being attacked
            if (bk1.BackColor != (Color.Red))
            {
                deselect.PerformClick();
            }
            //tells the system the knight has been clicked
            bk1Clicked = true;
            if (bk1.BackColor == (Color.Red))
            {
                labelnum = label44;
                knightbattle = bk1;
                bk1moveable = false;
                attack();
            }
            //checks if the knight is moveable, if the knight has already moved this will be false and it won't select
            else if (bk1moveable == true)
            {
                //checks if it is selected then uses the highlight method to change all adjacent squares to blue
                if (bk1Clicked == true)
                {
                    highlight();
                }
            }
        }
        //same as bk1_click but for a different knight
        private void bk2_Click_1(object sender, EventArgs e)
        {
            if (bk2.BackColor != (Color.Red))
            {
                deselect.PerformClick();
            }
            bk2Clicked = true;
            if (bk2.BackColor == (Color.Red))
            {
                labelnum = label45;
                knightbattle = bk2;
                bk2moveable = false;
                attack();
            }
            if (bk2moveable == true)
            {
                if (bk2Clicked == true)
                {
                    highlight();
                }
            }
            else
            {
                bk2.BackColor = (Color.Gray);
            }
        }

        private void bk3_Click(object sender, EventArgs e)
        {
            if (bk3.BackColor != (Color.Red))
            {
                deselect.PerformClick();
            }
            bk3Clicked = true;
            if (bk3.BackColor == (Color.Red))
            {
                labelnum = label46;
                knightbattle = bk3;
                bk3moveable = false;
                attack();
            }
            if (bk3moveable == true)
            {
                if (bk3Clicked == true)
                {
                    highlight();
                }
            }
            else
            {
                bk3.BackColor = (Color.Gray);
            }
        }

        private void wk1_Click(object sender, EventArgs e)
        {
            if (wk1.BackColor != (Color.Red))
            {
                deselect.PerformClick();
            }
            wk1Clicked = true;
            if (wk1.BackColor == (Color.Red))
            {
                labelnum = label47;
                knightbattle = wk1;
                wk1moveable = false;
                attack();
            }
            if (wk1moveable == true)
            {
                if (wk1Clicked == true)
                {
                    highlight();
                }
            }
            else
            {
                wk1.BackColor = (Color.Gray);
            }
        }

        private void wk2_Click(object sender, EventArgs e)
        {
            if (wk2.BackColor != (Color.Red))
            {
                deselect.PerformClick();
            }
            wk2Clicked = true;
            if (wk2.BackColor == (Color.Red))
            {
                labelnum = label48;
                knightbattle = wk2;
                wk2moveable = false;
                attack();
            }
            if (wk2moveable == true)
            {
                if (wk2Clicked == true)
                {
                    highlight();
                }
            }
            else
            {
                wk2.BackColor = (Color.Gray);
            }
        }

        private void wk3_Click(object sender, EventArgs e)
        {
            if (wk3.BackColor != (Color.Red))
            {
                deselect.PerformClick();
            }
            wk3Clicked = true;
            if (wk3.BackColor == (Color.Red))
            {
                labelnum = label49;
                knightbattle = wk3;
                wk3moveable = false;
                attack();
            }
            if (wk3moveable == true)
            {
                if (wk3Clicked == true)
                {
                    highlight();
                }
            }
            else
            {
                wk3.BackColor = (Color.Gray);
            }
        }
        //these are all the labels, when a specific label is clicked it sets the variable nextspot it itself, and then does the movement function which will move the knight into the position the label is in if it is able
        private void label16_Click_1(object sender, EventArgs e)
        {
            nextspot = label16;
            movement();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            nextspot = label1;
            movement();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            nextspot = label20;
            movement();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            nextspot = label15;
            movement();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            nextspot = label12;
            movement();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            nextspot = label9;
            movement();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            nextspot = label6;
            movement();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            nextspot = label8;
            movement();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            nextspot = label5;
            movement();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            nextspot = label4;
            movement();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            nextspot = label3;
            movement();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            nextspot = label2;
            movement();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            nextspot = label13;
            movement();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            nextspot = label7;
            movement();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            nextspot = label18;
            movement();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            nextspot = label14;
            movement();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            nextspot = label11;
            movement();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            nextspot = label17;
            movement();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            nextspot = label26;
            movement();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            nextspot = label29;
            movement();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            nextspot = label27;
            movement();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            nextspot = label32;
            movement();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            nextspot = label10;
            movement();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            nextspot = label25;
            movement();
        }

        private void label21_Click_1(object sender, EventArgs e)
        {
            nextspot = label21;
            movement();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            nextspot = label30;
            movement();
        }

        private void label36_Click(object sender, EventArgs e)
        {
            nextspot = label36;
            movement();
        }

        private void label35_Click(object sender, EventArgs e)
        {
            nextspot = label35;
            movement();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            nextspot = label22;
            movement();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            nextspot = label23;
            movement();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            nextspot = label24;
            movement();
        }

        private void label34_Click(object sender, EventArgs e)
        {
            nextspot = label34;
            movement();
        }

        private void label43_Click(object sender, EventArgs e)
        {
            nextspot = label43;
            movement();
        }

        private void label42_Click(object sender, EventArgs e)
        {
            nextspot = label42;
            movement();
        }

        private void label41_Click(object sender, EventArgs e)
        {
            nextspot = label41;
            movement();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            nextspot = label19;
            movement();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            nextspot = label28;
            movement();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            nextspot = label31;
            movement();
        }

        private void label33_Click(object sender, EventArgs e)
        {
            nextspot = label33;
            movement();
        }

        private void label37_Click(object sender, EventArgs e)
        {
            nextspot = label37;
            movement();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            nextspot = label38;
            movement();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            nextspot = label39;
            movement();
        }

        private void label40_Click(object sender, EventArgs e)
        {
            nextspot = label40;
            movement();
        }
        private void label44_Click(object sender, EventArgs e)
        {
            nextspot = label44;
            movement();
        }
        private void label46_Click(object sender, EventArgs e)
        {
            nextspot = label46;
            movement();
        }
        private void label48_Click(object sender, EventArgs e)
        {
            nextspot = label48;
            movement();
        }
        private void label45_Click(object sender, EventArgs e)
        {
            nextspot = label45;
            movement();
        }
        private void label49_Click(object sender, EventArgs e)
        {
            nextspot = label49;
            movement();
        }
        private void label47_Click(object sender, EventArgs e)
        {
            nextspot = label47;
            movement();
        }
        //this is the deselect button
        private void deselect_Click(object sender, EventArgs e)
        {
            //these if statements set the background color of the knight to the default white, as long as it still can move, otherwise it sets the color to gray. the color is already gray from previous steps but this ensures that if the color somehow gets changes it'll reset to gray
            if (bk1moveable == true)
            {
                bk1.BackColor = (Color.White);
            }
            else
            {
                bk1.BackColor = (Color.Gray);
            }
            if (bk2moveable == true)
            {
                bk2.BackColor = (Color.White);
            }
            else
            {
                bk2.BackColor = (Color.Gray);
            }
            if (bk3moveable == true)
            {
                bk3.BackColor = (Color.White);
            }
            else
            {
                bk3.BackColor = (Color.Gray);
            }
            if (wk1moveable == true)
            {
                wk1.BackColor = (Color.White);
            }
            else
            {
                wk1.BackColor = (Color.Gray);
            }
            if (wk2moveable == true)
            {
                wk2.BackColor = (Color.White);
            }
            else
            {
                wk2.BackColor = (Color.Gray);
            }
            if (wk3moveable == true)
            {
                wk3.BackColor = (Color.White);
            }
            else
            {
                wk3.BackColor = (Color.Gray);
            }
            //sets all label colors to white so a knight has to be selected to move it into a new position
            label1.BackColor = (Color.White);
            label2.BackColor = (Color.White);
            label3.BackColor = (Color.White);
            label4.BackColor = (Color.White);
            label5.BackColor = (Color.White);
            label6.BackColor = (Color.White);
            label7.BackColor = (Color.White);
            label8.BackColor = (Color.White);
            label9.BackColor = (Color.White);
            label10.BackColor = (Color.White);
            label11.BackColor = (Color.White);
            label12.BackColor = (Color.White);
            label13.BackColor = (Color.White);
            label14.BackColor = (Color.White);
            label15.BackColor = (Color.White);
            label16.BackColor = (Color.White);
            label17.BackColor = (Color.White);
            label18.BackColor = (Color.White);
            label19.BackColor = (Color.White);
            label20.BackColor = (Color.White);
            label21.BackColor = (Color.White);
            label22.BackColor = (Color.White);
            label23.BackColor = (Color.White);
            label24.BackColor = (Color.White);
            label25.BackColor = (Color.White);
            label26.BackColor = (Color.White);
            label27.BackColor = (Color.White);
            label28.BackColor = (Color.White);
            label28.BackColor = (Color.White);
            label29.BackColor = (Color.White);
            label30.BackColor = (Color.White);
            label31.BackColor = (Color.White);
            label32.BackColor = (Color.White);
            label33.BackColor = (Color.White);
            label34.BackColor = (Color.White);
            label35.BackColor = (Color.White);
            label36.BackColor = (Color.White);
            label37.BackColor = (Color.White);
            label38.BackColor = (Color.White);
            label39.BackColor = (Color.White);
            label40.BackColor = (Color.White);
            label41.BackColor = (Color.White);
            label42.BackColor = (Color.White);
            label43.BackColor = (Color.White);
            label44.BackColor = (Color.White);
            label45.BackColor = (Color.White);
            label46.BackColor = (Color.White);
            label47.BackColor = (Color.White);
            label48.BackColor = (Color.White);
            label49.BackColor = (Color.White);
            //sets it so that none of knights are selected
            bk1Clicked = false;
            bk2Clicked = false;
            bk3Clicked = false;
            wk1Clicked = false;
            wk2Clicked = false;
            wk3Clicked = false;
        }
        //closes the game
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void endturn_Click(object sender, EventArgs e)
        {
            if (blackturn == true)
            {
                wk1moveable = true;
                wk2moveable = true;
                wk3moveable = true;
                bk1moveable = false;
                bk2moveable = false;
                bk3moveable = false;
                blackturn = false;
                bk1.BackColor = (Color.Gray);
                bk2.BackColor = (Color.Gray);
                bk3.BackColor = (Color.Gray);
                wk1.BackColor = (Color.White);
                wk2.BackColor = (Color.White);
                wk3.BackColor = (Color.White);
            }

            else if (blackturn == false)
            {
                bk1moveable = true;
                bk2moveable = true;
                bk3moveable = true;
                wk1moveable = false;
                wk2moveable = false;
                wk3moveable = false;
                blackturn = true;
                bk1.BackColor = (Color.White);
                bk2.BackColor = (Color.White);
                bk3.BackColor = (Color.White);
                wk1.BackColor = (Color.Gray);
                wk2.BackColor = (Color.Gray);
                wk3.BackColor = (Color.Gray);
            }
            deselect.PerformClick();
        }
    }
}