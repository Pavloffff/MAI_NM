using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.L4;

namespace WindowsFormsApp1
{
    public partial class Lab4 : Form
    {
        public double x0 = 0.0, x1 = 1.0, h = 0.1;

        public Lab4()
        {
            InitializeComponent();
            solveLabel.Text = string.Empty;
            methodComboBox.Items.Add("Cauchy");
            methodComboBox.Items.Add("Boundary value");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            solveLabel.Text = string.Empty;
            fTextBox.Text = string.Empty;
            yTextBox.Text = string.Empty;
            h = 0.1;
            hTextBox.Text = h.ToString();
            x0 = 0.0;
            x0TextBox.Text = x0.ToString();
            x1 = 1.0;
            maxXTextBox.Text = x1.ToString();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            solveLabel.Text = string.Empty;
            if (methodComboBox.Text == "Cauchy")
            {
                x0 = 1.0;
                x0TextBox.Text = x0.ToString();
                yTextBox.Text = "2 + exp(1)";
                zTextBox.Text = "1 + exp(1)";
                x0 = 1;
                x0TextBox.Text = x0.ToString();
                x1 = 2;
                maxXTextBox.Text = x1.ToString();
                h = 0.1;
                hTextBox.Text = h.ToString();
                fTextBox.Text = "((x + 1) * y' - y) / x";
                exactTextBox.Text = "x + 1 + exp(x)";
                var t1 = new Task1(
                    fTextBox.Text, x0, x1, yTextBox.Text, zTextBox.Text, exactTextBox.Text, h);
                solveLabel.Text += t1.Run();
            }
            else if (methodComboBox.Text == "Boundary value")
            {
                x0 = 0;
                x0TextBox.Text = x0.ToString();
                x1 = 1;
                maxXTextBox.Text = x1.ToString();
                h = 0.1;
                hTextBox.Text = h.ToString();
                fTextBox.Text = "(y - (x - 3) * y') / (x^2 - 1)";
                yTextBox.Text = "1 * y(0) = 0";
                zTextBox.Text = "1 * y'(1) + 1 * y(1) = -0,75";
                pTextBox.Text = "1 / (x^2 - 1)";
                qTextBox.Text = "-(x - 3) / (x^2 - 1)";
                exactTextBox.Text = "x - 3 + (1 / (x + 1))";
                var t2 = new Task2(fTextBox.Text, x0, x1, exactTextBox.Text, yTextBox.Text, zTextBox.Text, h, pTextBox.Text, qTextBox.Text);
                solveLabel.Text += t2.Run();
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            solveLabel.Text = string.Empty;
            if (methodComboBox.Text == "Cauchy")
            {
                var t1 = new Task1(
                    fTextBox.Text, x0, x1, yTextBox.Text, zTextBox.Text, exactTextBox.Text, h);
                solveLabel.Text += t1.Run();
            }
            else if (methodComboBox.Text == "Boundary value")
            {
                var t2 = new Task2(fTextBox.Text, x0, x1, exactTextBox.Text, yTextBox.Text, zTextBox.Text, h, pTextBox.Text, qTextBox.Text);
                solveLabel.Text += t2.Run();
            }
        }

        private void xTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(x0TextBox.Text))
            {
                x0 = 0;
            }
            else if (!double.TryParse(x0TextBox.Text, out x0))
            {
            }
        }

        private void hTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hTextBox.Text))
            {
                h = 0;
            }
            else if (!double.TryParse(hTextBox.Text, out h))
            {
            }
        }

        private void minXTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(x0TextBox.Text))
            {
                x0 = 0;
            }
            else if (!double.TryParse(x0TextBox.Text, out x0))
            {
            }
        }

        private void maxXTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maxXTextBox.Text))
            {
                x1 = 1;
            }
            else if (!double.TryParse(maxXTextBox.Text, out x1))
            {
            }
        }
    }
}
