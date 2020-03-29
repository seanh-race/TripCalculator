using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripCalculator
{
    public partial class TripForm : Form
    {
        public TripForm()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = DoCalc(txtPerson1Name.Text, txtPerson2Name.Text, txtPerson3Name.Text, txtAmount1.Text, txtAmount2.Text, txtAmount3.Text);
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
        }

        public static string DoCalc(string name1, String name2, String name3, String amts1, String amts2, String amts3)
        {
            string ret = "";
            if (name1.Length == 0 || name2.Length == 0 || name3.Length == 0)
            {
                return ("Names Must Not Be Empty.");
            }

            try
            {
                //put names in array
                String[] names = new String[3];
                names[0] = (name1);
                names[1] = (name2);
                names[2] = (name3);

                //strip any dollar signs
                amts1 = amts1.Replace("$", "");
                amts2 = amts2.Replace("$", "");
                amts3 = amts3.Replace("$", "");

                //split amounts
                String[] sAmounts1 = amts1.Split(' ');
                String[] sAmounts2 = amts2.Split(' ');
                String[] sAmounts3 = amts3.Split(' ');

                //convert to numbers
                List<decimal> dAmounts1 = new List<decimal>();
                List<decimal> dAmounts2 = new List<decimal>();
                List<decimal> dAmounts3 = new List<decimal>();

                //total numbers (rounding to cents)
                for (int i = 0; i < sAmounts1.Length; i++)
                {
                    dAmounts1.Add(Math.Round((decimal.Parse(sAmounts1[i])), 2));
                }
                for (int i = 0; i < sAmounts2.Length; i++)
                {
                    dAmounts2.Add(Math.Round((decimal.Parse(sAmounts2[i])), 2));
                }
                for (int i = 0; i < sAmounts3.Length; i++)
                {
                    dAmounts3.Add(Math.Round((decimal.Parse(sAmounts3[i])), 2));
                }

                //calc totals for each person
                decimal[] total = new decimal[3];

                foreach (decimal d in dAmounts1)
                {
                    total[0] += d;
                }
                foreach (decimal d in dAmounts2)
                {
                    total[1] += d;
                }
                foreach (decimal d in dAmounts3)
                {
                    total[2] += d;
                }

                //calc total and average
                decimal dTotal = 0;
                foreach(decimal d in total)
                {
                    dTotal += d;
                }
                decimal dAvg = Math.Round(dTotal / 3, 2);

                //calc who owes who
                decimal[] avgDelta = new decimal[3];
                int iPersonOwed = 0;
                for (int i = 0; i < total.Length; i++)
                {
                    avgDelta[i] = total[i] - dAvg;
                    if (avgDelta[i] > 0)
                    {
                        iPersonOwed = i;
                    }
                }

                for (int i = 0; i < total.Length; i++)
                {
                    if (avgDelta[i] < 0)
                    {
                        ret += names[i] + " Owes " + names[iPersonOwed] + " $" + (Math.Abs(avgDelta[i])) + System.Environment.NewLine;
                    }
                }

            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }

            return (ret);
        }
    }
}
