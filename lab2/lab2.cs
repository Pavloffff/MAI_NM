using Antlr.Runtime;
using app.Equation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace app
{
    public partial class lab2 : Form
    {
        public double a = 1.0;
        public double epsilon = 0.1;
        public string eq1 = String.Empty;
        public string eq2 = String.Empty;
        public double leftX = 0.0;
        public double rightX = 1.0;
        public double leftY = 0.0;
        public double rightY = 1.0;
        public int iterations = 100;

        public lab2()
        {
            InitializeComponent();
            comboBoxMethod.Items.Add("Newton");
            comboBoxMethod.Items.Add("Iterations");
            comboBoxTask.Items.Add("Equation 1");
            comboBoxTask.Items.Add("System");
            textBoxLeftRangeX.Text = leftX.ToString();
            textBoxRightRangeX.Text = rightX.ToString();
            textBoxLeftRangeY.Text = leftY.ToString();
            textBoxRightRangeY.Text = rightY.ToString();
            labelSolution.Text = string.Empty;
            textBoxConst.Text = a.ToString();
            textBoxEpsilon.Text = epsilon.ToString();
            textBoxIterations.Text = iterations.ToString();
            chartFx.Series.Clear();
            chartFx.ChartAreas[0].AxisX.Interval = 1;
            chartFx.Legends.Add(new Legend("Legend"));
            chartFx.Legends["Legend"].Docking = Docking.Bottom;
            numericUpDownMinX.Minimum = Int32.MinValue;
            numericUpDownMinX.Maximum = Int32.MaxValue;
            numericUpDownMaxX.Minimum = Int32.MinValue;
            numericUpDownMaxX.Maximum = Int32.MaxValue;
            numericUpDownMinY.Minimum = Int32.MinValue;
            numericUpDownMinY.Maximum = Int32.MaxValue;
            numericUpDownMaxY.Minimum = Int32.MinValue;
            numericUpDownMaxY.Maximum = Int32.MaxValue;
            numericUpDownMinX.Value = -3;
            numericUpDownMaxX.Value = 3;
            numericUpDownMinY.Value = -3;
            numericUpDownMaxY.Value = 3;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void lab2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEq2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelSolution.Text = string.Empty;
            eq1 = String.Empty;
            textBoxEq1.Text = eq1;
            eq2 = String.Empty;
            textBoxEq2.Text = eq2;
            epsilon = 0.1;
            textBoxEpsilon.Text = epsilon.ToString();
            iterations = 100;
            textBoxIterations.Text = iterations.ToString();
            a = 1;
            textBoxConst.Text = a.ToString();
            leftX = 0.0;
            rightX = 1.0;
            textBoxLeftRangeX.Text = leftX.ToString();
            textBoxRightRangeX.Text = rightX.ToString();
            leftY = 0.0;
            rightY = 1.0;
            textBoxLeftRangeY.Text = leftY.ToString();
            textBoxRightRangeY.Text = rightY.ToString();
            chartFx.Series.Clear();
            numericUpDownMinX.Value = -3;
            numericUpDownMaxX.Value = 3;
            numericUpDownMinY.Value = -3;
            numericUpDownMaxY.Value = 3;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            labelSolution.Text = string.Empty;
            string solve = string.Empty;
            if (comboBoxTask.Text == "Equation 1")
            {
                textBoxEq1.Text = "-5*x + 4^x - 2 = 0";
                textBoxLeftRangeX.Text = (-1).ToString();
                textBoxRightRangeX.Text = (0.9).ToString();
                leftX = -1;
                rightX = 0.9;
                var t1 = new L2.Task1(textBoxEq1.Text, leftX, rightX, a, epsilon, iterations);
                if (comboBoxMethod.Text == "Newton")
                {
                    solve = t1.Newton();
                }
                else if (comboBoxMethod.Text == "Iterations")
                {
                    solve = t1.Iterations();
                }
                labelSolution.Text += solve;
            }
            //0,1*x1^2+x1+0,2*x2^2-0,3=0
            //-0,7+0,2*x1^2+x2-0,1*x1*x2=0
            else if (comboBoxTask.Text == "System")
            {
                textBoxEq1.Text = "a * x1 - cos(x2) = 0";
                textBoxEq2.Text = "a * x2 - exp(x1) = 0";
                textBoxLeftRangeX.Text = (-0.1).ToString();
                textBoxRightRangeX.Text = (0.9).ToString();
                leftX = -0.1;
                rightX = 0.9;
                textBoxLeftRangeY.Text = (1).ToString();
                textBoxRightRangeY.Text = (2).ToString();
                leftY = 1;
                rightY = 2;
                var t2 = new L2.Task2(textBoxEq1.Text, textBoxEq2.Text, leftX, rightX, leftY, 
                    rightY, a, epsilon, iterations);
                solve = String.Empty;
                if (comboBoxMethod.Text == "Newton")
                {
                    solve = t2.Newton();
                }
                else if (comboBoxMethod.Text == "Iterations")
                {
                    solve = t2.Iterations();
                }
                labelSolution.Text += solve;
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            labelSolution.Text = string.Empty;
            string solve = String.Empty;
            if (comboBoxTask.Text == "Equation 1")
            {
                var t1 = new L2.Task1(textBoxEq1.Text, leftX, rightX, a, epsilon, iterations);
                if (comboBoxMethod.Text == "Newton")
                {
                    solve = t1.Newton();
                }
                else if (comboBoxMethod.Text == "Iterations")
                {
                    solve = t1.Iterations();
                }
                labelSolution.Text += solve;
            }
            else if (comboBoxTask.Text == "System")
            {
                var t2 = new L2.Task2(textBoxEq1.Text, textBoxEq2.Text, leftX, rightX, leftY, 
                    rightY, a, epsilon, iterations);
                if (comboBoxMethod.Text == "Newton")
                {
                    solve = t2.Newton();
                }
                else if (comboBoxMethod.Text == "Iterations")
                {
                    solve = t2.Iterations();
                }
                labelSolution.Text += solve;
            }
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            var solver = new Solver();
            if (comboBoxTask.Text == "Equation 1")
            {
                var lexer = new Equation.Lexer();
                List<Token> tokens = lexer.Run(textBoxEq1.Text);
                var parser = new Equation.Parser();
                tokens = parser.ToPostfix(tokens);
                var splited = parser.Split(tokens);

                chartFx.Series.Clear();
                chartFx.Legends["Legend"].Docking = Docking.Bottom;

                var series1 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = parser.ToInfix(splited.Item1)
                };

                var series2 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = parser.ToInfix(splited.Item2)
                };

                chartFx.Series.Add(series1);
                chartFx.Series.Add(series2);

                for (double x = Convert.ToInt32(numericUpDownMinX.Value); x <= Convert.ToInt32(numericUpDownMaxX.Value); x += 0.1)
                {
                    double y1 = solver.Solve(splited.Item1, x, 0, a);
                    chartFx.Series[0].Points.AddXY(x, y1);

                    double y2 = solver.Solve(splited.Item2, x, 0, a);
                    chartFx.Series[1].Points.AddXY(x, y2);
                }
            }
            else if (comboBoxTask.Text == "System")
            {
                var lexer = new Equation.Lexer();
                var parser = new Equation.Parser();
                List<Token> tokens1 = lexer.Run(textBoxEq1.Text);
                tokens1 = parser.ToPostfix(tokens1);
                tokens1.RemoveAt(tokens1.Count - 1);
                tokens1.RemoveAt(tokens1.Count - 1);
                List<Token> tokens2 = lexer.Run(textBoxEq2.Text);
                tokens2 = parser.ToPostfix(tokens2);
                tokens2.RemoveAt(tokens2.Count - 1);
                tokens2.RemoveAt(tokens2.Count - 1);
                chartFx.Series.Clear();
                chartFx.Legends["Legend"].Docking = Docking.Bottom;

                var series1 = new Series
                {
                    ChartType = SeriesChartType.Point,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = parser.ToInfix(tokens1)
                };

                var series2 = new Series
                {
                    ChartType = SeriesChartType.Point,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = parser.ToInfix(tokens2)
                };

                chartFx.Series.Add(series1);
                chartFx.Series.Add(series2);

                for (double x = Convert.ToInt32(numericUpDownMinX.Value); x <= Convert.ToInt32(numericUpDownMaxX.Value); x += 0.1)
                {
                    for (double y = Convert.ToInt32(numericUpDownMinY.Value); y <= Convert.ToInt32(numericUpDownMaxY.Value); y += 0.1)
                    {
                        double f1 = solver.Solve(tokens1, x, y, a);
                        if (Math.Abs(f1) < 0.1)
                        {
                            chartFx.Series[0].Points.AddXY(x, y);
                        }

                        double f2 = solver.Solve(tokens2, x, y, a);
                        if (Math.Abs(f2) < 0.1)
                        {
                            chartFx.Series[1].Points.AddXY(x, y);
                        }
                    }
                }
            }
        }

        private void textBoxLeftRange_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLeftRangeX.Text))
            {
                leftX = 0.0;
            }
            else if (!double.TryParse(textBoxLeftRangeX.Text, out leftX))
            {
            }
        }

        private void textBoxRightRange_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxRightRangeX.Text))
            {
                rightX = 1.0;
            }
            else if (!double.TryParse(textBoxRightRangeX.Text, out rightX))
            {
            }
        }

        private void textBoxConst_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxConst.Text))
            {
                a = 1.0;
            }
            else if (!double.TryParse(textBoxConst.Text, out a))
            {
            }
        }

        private void numericUpDownMinX_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownMaxX_ValueChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDownMinX_SelectedItemChanged(object sender, EventArgs e)
        {
        }

        private void domainUpDownMaxX_SelectedItemChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDownMaxX_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxEpsilon_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEpsilon.Text))
            {
                epsilon = 0.01;
            }
            else if (!double.TryParse(textBoxEpsilon.Text, out epsilon))
            {
            }
        }

        private void chartFx2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxIterations_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIterations.Text))
            {
                iterations = 100;
            }
            else if (!int.TryParse(textBoxIterations.Text, out iterations))
            {
            }
        }

        private void textBoxLeftRangeY_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLeftRangeY.Text))
            {
                leftY = 0.0;
            }
            else if (!double.TryParse(textBoxLeftRangeY.Text, out leftY))
            {
            }
        }

        private void textBoxRightRangeY_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxRightRangeY.Text))
            {
                rightY = 1.0;
            }
            else if (!double.TryParse(textBoxRightRangeY.Text, out rightY))
            {
            }
        }
    }
}
