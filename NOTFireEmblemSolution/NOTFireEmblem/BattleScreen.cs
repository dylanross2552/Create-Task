using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOTFireEmblem
{
    public partial class BattleScreenTestArea : Form
    {
        string P1Name = Titlescreen.P1Name;
        string P2Name = Titlescreen.P2Name;
        public static bool wasClicked1 = false; //Introduced by Classmate 2
        public object unit1;
        public object unit2;
        string unit1Name;
        string unit2Name;
        public int resethealth;
        public int bk1Health;
        public int bk2Health;
        public int bk3Health;
        public int wk1Health;
        public int wk2Health;
        public int wk3Health;
        int bkTeamKOCount;
        int wkTeamKOCount;
        string placeholderstring; 
        int placeholderint;
        public static bool bk1Turn = true;
        public static bool bk2Turn = true;
        public static bool bk3Turn = true;
        public static bool wk1Turn = false;
        public static bool wk2Turn = false;
        public static bool wk3Turn = false;


        //=====================================================================UI Functions
        public void attack()
        {
            TestResultLabel.Text = (unit1Name + " Has dealt 5 points of damage to " + unit2Name + "!");
            damagecalculation();
            endturn();
            BattleActionsMenu.Enabled = false;
        }
        public void revive()
        {
            revivecheck();
            endturn();
            BattleActionsMenu.Enabled = false;
        }
        
        public void endturn()
        {
            if (unit1 == Bk1)
            {
                bk1Turn = false;
                bkturncheck();
            }
            if (unit1 == Bk2)
            {
                bk2Turn = false;
                bkturncheck();
            }
            if (unit1 == Bk3)
            {
                bk3Turn = false;
                bkturncheck();
            }
            if (unit1 == Wk1)
            {
                wk1Turn = false;
                wkturncheck();
            }
            if (unit1 == Wk2)
            {
                wk2Turn = false;
                wkturncheck();
            }
            if (unit1 == Wk3)
            {
                wk3Turn = false;
                wkturncheck();
            }
        }
        public void bkturncheck()
        {
            if ((bk1Turn == false) && (bk2Turn == false) && (bk3Turn == false))
            {
                TeamTurnLabel.Text = ("It's " + P2Name + "'s turn now!");
                wk1Turn = true;
                wk2Turn = true;
                wk3Turn = true;
                KOcheck();
            }

        }
        public void wkturncheck()
        {
            if ((wk1Turn == false) && (wk2Turn == false) && (wk3Turn == false))
            {
                TeamTurnLabel.Text = ("It's " + P1Name + "'s turn now!");
                bk1Turn = true;
                bk2Turn = true;
                bk3Turn = true;
                KOcheck();
            }
        }

        public void select()
        {
            if (wasClicked1 == true)
            {
                TestResultLabel.Text = (unit1Name + " has been selected");
                BattleActionsMenu.Enabled = false;

            }
            else
            {
                select2();
                BattleActionsMenu.Enabled = true;

            } 
        }
        public void select2()
        {
            TestResultLabel.Text = (unit1Name + " Is interacting with " + unit2Name);
        }

        //============================================================================ Logic Functions
        public void damagecalculation()
        {
            if (unit2 == Bk1)
            {
                bk1Health = Convert.ToInt32(bk1HealthLabel.Text);
                bk1Health = bk1Health - 5;
                string bk1Healthstring = Convert.ToString(bk1Health);
                bk1HealthLabel.Text = bk1Healthstring;
            }
            if (unit2 == Bk2)
            {
                bk2Health = Convert.ToInt32(bk2HealthLabel.Text);
                bk2Health = bk2Health - 5;
                string bk2Healthstring = Convert.ToString(bk2Health);
                bk2HealthLabel.Text = bk2Healthstring;
            }
            if (unit2 == Bk3)
            {
                bk3Health = Convert.ToInt32(bk3HealthLabel.Text);
                bk3Health = bk3Health - 5;
                string bk3Healthstring = Convert.ToString(bk3Health);
                bk3HealthLabel.Text = bk3Healthstring;
            }
            if (unit2 == Wk1)
            {
                wk1Health = Convert.ToInt32(wk1Healthlabel.Text);
                wk1Health = wk1Health - 5;
                string wk1Healthstring = Convert.ToString(wk1Health);
                wk1Healthlabel.Text = wk1Healthstring;
            }
            if (unit2 == Wk2)
            {
                wk2Health = Convert.ToInt32(wk2Healthlabel.Text);
                wk2Health = wk2Health - 5;
                string wk2Healthstring = Convert.ToString(wk2Health);
                wk2Healthlabel.Text = wk2Healthstring;
            }
            if (unit2 == Wk3)
            {
                wk3Health = Convert.ToInt32(wk3Healthlabel.Text);
                wk3Health = wk3Health - 5;
                string wk3Healthstring = Convert.ToString(wk3Health);
                wk3Healthlabel.Text = wk3Healthstring;
            }
        }

        public void revivecheck()
        {
            placeholderstring = ("Not Alive");
            if (unit2 == Bk1)
            {
                if (bk1Statuslabel.Text == placeholderstring)
                {
                    bk1Health = bk1Health + 10;
                    bk1HealthLabel.Text = Convert.ToString(bk1Health);
                    bk1Statuslabel.Text = ("Alive(?)");
                    TestResultLabel.Text = (unit1Name + " has resuscitated " + unit2Name + "!");
                }
                else
                {
                    TestResultLabel.Text = ("That unit isn't not alive!");
                }

            }
            if (unit2 == Bk2)
            {

                if (bk2Statuslabel.Text == placeholderstring)
                {
                    bk2Health = bk2Health + 10;
                    bk2HealthLabel.Text = Convert.ToString(bk2Health);
                    bk2Statuslabel.Text = ("Alive(?)");
                    TestResultLabel.Text = (unit1Name + " has resuscitated " + unit2Name + "!");
                }
                else
                {
                    TestResultLabel.Text = ("That unit isn't not alive!");
                }
            }

            if (unit2 == Bk3)
            {

                if (bk3Statuslabel.Text == placeholderstring)
                {
                    bk3Health = bk3Health + 10;
                    bk3HealthLabel.Text = Convert.ToString(bk3Health);
                    bk3Statuslabel.Text = ("Alive(?)");
                    TestResultLabel.Text = (unit1Name + " has resuscitated " + unit2Name + "!");
                }
                else
                {
                    TestResultLabel.Text = ("That unit isn't not alive!");
                }
            }
            if (unit2 == Wk1)
            {

                if (wk1Statuslabel.Text == placeholderstring)
                {
                    wk1Health = wk1Health + 10;
                    wk1Healthlabel.Text = Convert.ToString(wk1Health);
                    wk1Statuslabel.Text = ("Alive(?)");
                    TestResultLabel.Text = (unit1Name + " has resuscitated " + unit2Name + "!");
                }
                else
                {
                    TestResultLabel.Text = ("That unit isn't not alive!");
                }
            }

            if (unit2 == Wk2)
            {

                if (wk2Statuslabel.Text == placeholderstring)
                {
                    wk2Health = wk2Health + 10;
                    wk2Healthlabel.Text = Convert.ToString(wk2Health);
                    wk2Statuslabel.Text = ("Alive(?)");
                    TestResultLabel.Text = (unit1Name + " has resuscitated " + unit2Name + "!");
                }
                else
                {
                    TestResultLabel.Text = ("That unit isn't not alive!");
                }
            }
            if (unit2 == Wk3)
            {

                if (wk3Statuslabel.Text == placeholderstring)
                {
                    wk3Health = wk3Health + 10;
                    wk3Healthlabel.Text = Convert.ToString(wk3Health);
                    wk3Statuslabel.Text = ("Alive(?)");
                    TestResultLabel.Text = (unit1Name + " has resuscitated " + unit2Name + "!");
                }
                else
                {
                    TestResultLabel.Text = ("That unit isn't not alive!");
                }
            }
        }


        public void KOcheck()
        {
            bkTeamKOCount = 0;
            wkTeamKOCount = 0;
            bk1Health = Convert.ToInt32(bk1HealthLabel.Text);
            bk2Health = Convert.ToInt32(bk2HealthLabel.Text);
            bk3Health = Convert.ToInt32(bk3HealthLabel.Text);
            wk1Health = Convert.ToInt32(wk1Healthlabel.Text);
            wk2Health = Convert.ToInt32(wk2Healthlabel.Text);
            wk3Health = Convert.ToInt32(wk3Healthlabel.Text);

            if (bk1Health <= 0)
            {
                bk1Turn = false;
                bk1Statuslabel.Text = ("Not Alive");
                bkTeamKOCount = bkTeamKOCount + 1;
            }
            if (bk2Health <= 0)
            {
                bk2Turn = false;
                bk2Statuslabel.Text = ("Not Alive");
                bkTeamKOCount = bkTeamKOCount + 1;
            }
            if (bk3Health <= 0)
            {
                bk3Turn = false;
                bk3Statuslabel.Text = ("Not Alive");
                bkTeamKOCount = bkTeamKOCount + 1;
            }
            if (wk1Health <= 0)
            {
                wk1Turn = false;
                wk1Statuslabel.Text = ("Not Alive");
                wkTeamKOCount = wkTeamKOCount + 1;
            }
            if (wk2Health <= 0)
            {
                wk2Turn = false;
                wk2Statuslabel.Text = ("Not Alive");
                wkTeamKOCount = wkTeamKOCount + 1;
            }
            if (wk3Health <= 0)
            {
                wk3Turn = false;
                wk3Statuslabel.Text = ("Not Alive");
                wkTeamKOCount = wkTeamKOCount + 1;
            }
            wincheck();
        }

        public void wincheck()
        {
            if (bkTeamKOCount == 3)
            {
                if (P1Name == P2Name)
                {
                    TestResultLabel.Text = (P2Name + " is the winner! (Wait, which " + P2Name + "?)");
                    TeamTurnLabel.Visible = false;
                }
                else
                {
                    TestResultLabel.Text = (P2Name + " is the winner!");
                    TeamTurnLabel.Visible = false;
                }
                
            }
            if (wkTeamKOCount == 3)
            {
                if (P1Name == P2Name)
                {
                    TestResultLabel.Text = (P1Name + " is the winner! (Wait, which " + P1Name + "?)");
                    TeamTurnLabel.Visible = false;
                }
                else
                {
                    TestResultLabel.Text = (P1Name + " is the winner!");
                    TeamTurnLabel.Visible = false;
                }
                
            }
        }
        /* Probably not needed now that I think about it...
        public void reset()
        {
            bk1Health = resethealth;
            bk2Health = resethealth;
            bk3Health = resethealth;
            wk1Health = resethealth;
            wk2Health = resethealth;
            wk3Health = resethealth;
            bk1HealthLabel.Text = "20";
            bk2HealthLabel.Text = "20";
            bk3HealthLabel.Text = "20";
            wk1Healthlabel.Text = "20";
            wk2Healthlabel.Text = "20";
            wk3Healthlabel.Text = "20";
            bk1Statuslabel.Text = "Alive";
            bk2Statuslabel.Text = "Alive";
            bk3Statuslabel.Text = "Alive";
            wk1Statuslabel.Text = "Alive";
            wk2Statuslabel.Text = "Alive";
            wk3Statuslabel.Text = "Alive";
            TestResultLabel.Text = "Announcement: ";
            wk1Turn = false;
            wk2Turn = false;
            wk3Turn = false;
            bk1Turn = true;
            bk2Turn = true;
            bk3Turn = true;
            TeamTurnLabel.Text = ("It's " + P1Name + "'s turn now!");
        }
        */

        //======================================================================== UI Interaction
        public BattleScreenTestArea()
        {
            InitializeComponent();
            //Sets the starting values of the match
            int resethealth = Convert.ToInt32(ServerLabel.Text);
            bk1HealthLabel.Text = ServerLabel.Text;
            bk2HealthLabel.Text = ServerLabel.Text;
            bk3HealthLabel.Text = ServerLabel.Text;
            wk1Healthlabel.Text = ServerLabel.Text;
            wk2Healthlabel.Text = ServerLabel.Text;
                //makes unit2 a vanguard
                wk2Health = Convert.ToInt32(wk2Healthlabel.Text);
                wk2Health = wk2Health + 5;
                placeholderint = wk2Health;
                wk2Healthlabel.Text = Convert.ToString(placeholderint);
            wk3Healthlabel.Text = ServerLabel.Text;
            bk2Turn = false;
            TeamTurnLabel.Text = ("It's " + P1Name + "'s turn now!");
            TeamTurnLabel.Visible = true;
        }

        private void BattleScreen_Load(object sender, EventArgs e)
        {

            P1NameLabel.Text = (P1Name);
            P2NameLabel.Text = (P2Name);
            /*
            Not relevant anymore
            
            int Bk1Health = Health;
            int WK1Health = Health;
            int Bk2Health = Health;
            int Wk2Health = Health;
            int Bk3Health = Health;
            int Wk3Health = Health;
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Titlescreen frm1 = new Titlescreen();
            frm1.Visible = true;
            //reset();

        }

        private void TestingButton_Click(object sender, EventArgs e)
        {
            //Gotta test those things ;D
            //Bk1.Health = 90;

        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            attack();
        }

        private void ReviveButton_Click(object sender, EventArgs e)
        {
            revive();
        }


        //================================================================================= Knight clicks

        /* Commented out until needed
        private void Bk1_Click(object sender, EventArgs e)
        {
            if (wasClicked1 == true)
            {
                unit2 = Bk1;
                unit2Name = Bk1.Name;
                wasClicked1 = false;
                select();
            }
            else
            {
                if (bk1Turn == true)
                {
                    unit1 = Bk1;
                    unit1Name = Bk1.Name;
                    wasClicked1 = true;
                    select();
                }
                else
                {
                    TestResultLabel.Text = ("It is not that unit's turn yet!");
                }
            }
        }

        private void Wk1_Click(object sender, EventArgs e)
        {
            if (wasClicked1 == true)
            {
                unit2 = Wk1;
                unit2Name = Wk1.Name;
                wasClicked1 = false;
                select();
            }
            else
            {
                if (wk1Turn == true)
                {
                    unit1 = Wk1;
                    unit1Name = Wk1.Name;
                    wasClicked1 = true;
                    select();
                }
                else
                {
                    TestResultLabel.Text = ("It is not that unit's turn yet!");
                }
            }
        }

        private void Bk2_Click(object sender, EventArgs e)
        {
            if (wasClicked1 == true)
            {
                unit2 = Bk2;
                unit2Name = Bk2.Name;
                wasClicked1 = false;
                select();
            }
            else
            {
                if (bk2Turn == true)
                {
                    unit1 = Bk2;
                    unit1Name = Bk2.Name;
                    wasClicked1 = true;
                    select();
                }
                else
                {
                    TestResultLabel.Text = ("It is not that unit's turn yet!");
                }
            }
        }

        private void Wk2_Click(object sender, EventArgs e)
        {
            if (wasClicked1 == true)
            {
                unit2 = Wk2;
                unit2Name = Wk2.Name;
                wasClicked1 = false;
                select();
            }
            else
            {
                if (wk2Turn == true)
                {
                    unit1 = Wk2;
                    unit1Name = Wk2.Name;
                    wasClicked1 = true;
                    select();
                }
                else
                {
                    TestResultLabel.Text = ("It is not that unit's turn yet!");
                }
            }
        }

        private void Bk3_Click(object sender, EventArgs e)
        {
            if (wasClicked1 == true)
            {
                unit2 = Bk3;
                unit2Name = Bk3.Name;
                wasClicked1 = false;
                select();
            }
            else
            {
                if (bk3Turn == true)
                {
                    unit1 = Bk3;
                    unit1Name = Bk3.Name;
                    wasClicked1 = true;
                    select();
                }
                else
                {
                    TestResultLabel.Text = ("It is not that unit's turn yet!");
                }
            }
        }

        private void Wk3_Click(object sender, EventArgs e)
        {
            if (wasClicked1 == true)
            {
                unit2 = Wk3;
                unit2Name = Wk3.Name;
                wasClicked1 = false;
                select();
            }
            else
            {
                if (wk3Turn == true)
                {
                    unit1 = Wk3;
                    unit1Name = Wk3.Name;
                    wasClicked1 = true;
                    select();
                }
                else
                {
                    TestResultLabel.Text = ("It is not that unit's turn yet!");
                }
            }
        }
        */
    }
}