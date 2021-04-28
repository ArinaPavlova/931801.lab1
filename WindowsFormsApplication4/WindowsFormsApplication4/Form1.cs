using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        private int day = 0;
        private int money = 100;

        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
                field.Add(cb, new Cell());
            labMoney.Text = "Money: 100 rus";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (cb.Checked)
            {
                money -= 2;
                Plant(cb);
            }
            else
            {
                if ((field[cb].progress >= 100) && (field[cb].progress < 120))
                    money += 3;
                if ((field[cb].progress >= 120) && (field[cb].progress < 140))
                    money += 5;
                if (field[cb].progress >= 140)
                    money -= 1;
                Harvest(cb);
            }
            labMoney.Text = "Money: " + money + " rus";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (CheckBox cb in panel1.Controls)
                NextStep(cb);
            day++;
            labDay.Text = "Day: " + day;
        }

        private void Plant(CheckBox cb)
        {
            field[cb].Plant();
            UpdateBox(cb);
        }

        private void Harvest(CheckBox cb)
        {
            field[cb].Harvest();
            UpdateBox(cb);
        }

        private void NextStep(CheckBox cb)
        {
            field[cb].NextStep();
            UpdateBox(cb);
        }

        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;
            switch (field[cb].state)
            {
                case CellState.Planted: c = Color.Black;
                    break;
                case CellState.Green: c = Color.Green;
                    break;
                case CellState.Immature: c = Color.Yellow;
                    break;
                case CellState.Mature: c = Color.Red;
                    break;
                case CellState.Overgrown: c = Color.Brown;
                    break;
            }
            cb.BackColor = c;
        }

        private void but3slow_Click(object sender, EventArgs e)
        {
            timer1.Interval = 300;
        }

        private void but5slow_Click(object sender, EventArgs e)
        {
            timer1.Interval = 200;
        }

        private void butnorm_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void but2fast_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5;
        }

        private void but3fast_Click(object sender, EventArgs e)
        {
            timer1.Interval = 3;
        }
    }

    enum CellState
    {
        Empty,
        Planted,
        Green,
        Immature,
        Mature,
        Overgrown
    }

    class Cell
    {
        public CellState state = CellState.Empty;
        public int progress = 0;
        public int money = 0;

        private const int prPlanted = 20;
        private const int prGreen = 100;
        private const int prImmature = 120;
        private const int prMature = 140;

        public void Plant()
        {
            state = CellState.Planted;
            progress = 1;
            money -= 2;
        }

        public void Harvest()
        {
            state = CellState.Empty;
            progress = 0;
        }

        public void NextStep()
        {
            if ((state != CellState.Empty) && (state != CellState.Overgrown))
            {
                progress++;
                if (progress < prPlanted) state = CellState.Planted;
                else if (progress < prGreen) state = CellState.Green;
                else if (progress < prImmature) state = CellState.Immature;
                else if (progress < prMature) state = CellState.Mature;
                else state = CellState.Overgrown;
            }
        }
    }
}
