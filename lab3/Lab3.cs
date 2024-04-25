using app.Equation;
using app.L3;
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
    public partial class Lab3 : Form
    {
        public int n = 4;
        public double xStar = 0, h1 = 1, h2 = 1;

        public Lab3()
        {
            InitializeComponent();
            nUpDown.Value = n;
            solveLabel.Text = string.Empty;
            xGridView.ColumnCount = n;
            xGridView.RowCount = 2;
            xGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            xGridView.AutoResizeColumns();
            xGridView.AutoResizeRows();
            xGridView.Rows[0].HeaderCell.Value = "X";
            xGridView.Rows[1].HeaderCell.Value = "f";
            for (int i = 0; i < n; i++)
            {
                xGridView.Columns[i].Name = (i + 1).ToString();
            }
            foreach (DataGridViewRow row in xGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
            FxChart.Series.Clear();
            FxChart.ChartAreas[0].AxisX.Interval = 1;
            FxChart.Legends.Add(new Legend("Legend"));
            FxChart.Legends["Legend"].Docking = Docking.Bottom;
            methodComboBox.Items.Add("Interpolation");
            methodComboBox.Items.Add("Spline");
            methodComboBox.Items.Add("LSM");
            methodComboBox.Items.Add("Derivative");
            methodComboBox.Items.Add("Integrate");
        }

        private void Lab3_Load(object sender, EventArgs e)
        {

        }

        private void yLabel_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            solveLabel.Text = string.Empty;
            yTextBox.Text = string.Empty;
            xStarTextBox.Text = string.Empty;
            h1TextBox.Text = string.Empty;
            h2TextBox.Text = string.Empty;
            FxChart.Series.Clear();
            foreach (DataGridViewRow row in xGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            FxChart.Series.Clear();
            solveLabel.Text = string.Empty;
            if (methodComboBox.Text == "Interpolation")
            {
                n = 4;
                nUpDown.Value = n;
                yTextBox.Text = "exp(x) + x";
                List<double> x = new List<double>() {-2, -1, 0, 1};
                for (int i = 0; i < n; i++)
                {
                    xGridView.Rows[0].Cells[i].Value = x[i];
                }
                xStarTextBox.Text = (-0.5).ToString();
                xStar = -0.5;
                var t1 = new L3.Task1(yTextBox.Text, x, xStar);
                solveLabel.Text += t1.Run();
            }
            else if (methodComboBox.Text == "Spline")
            {
                n = 5;
                nUpDown.Value = n;
                List<double> x = new List<double>() {-2, -1, 0, 1, 2};
                List<double> y = new List<double>() {-1.8467, -0.63212, 1, 3.7183, 9.3891};
                for (int i = 0; i < n; i++)
                {
                    xGridView.Rows[0].Cells[i].Value = x[i];
                    xGridView.Rows[1].Cells[i].Value = y[i];
                }
                xStarTextBox.Text = (-0.5).ToString();
                xStar = -0.5;
                var t2 = new L3.Task2(x, y, xStar);
                var solve = t2.Run();
                solveLabel.Text += solve.Item1;
                FxChart.ChartAreas[0].AxisX.Minimum = x[0];
                FxChart.ChartAreas[0].AxisX.Maximum = x[n - 1];
                FxChart.Legends["Legend"].Docking = Docking.Bottom;
                var series1 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = solve.Item2.ToString(),
                };
                FxChart.Series.Add(series1);
                for (double i = x[0]; i <= x[n - 1]; i += 0.1)
                {
                    FxChart.Series[0].Points.AddXY(i, solve.Item2.Calculate(i));
                }
            }
            else if (methodComboBox.Text == "LSM")
            {
                n = 6;
                nUpDown.Value = n;
                List<double> x = new List<double>() { -3, -2, -1, 0, 1, 2 };
                List<double> y = new List<double>() { -2.9502, -1.8647, -0.63212, 1, 3.7183, 9.3891 };
                for (int i = 0; i < n; i++)
                {
                    xGridView.Rows[0].Cells[i].Value = x[i];
                    xGridView.Rows[1].Cells[i].Value = y[i];
                }
                var t3 = new L3.Task3(x, y);
                var solve1 = t3.Run(2);
                solveLabel.Text += solve1.Item1;
                var solve2 = t3.Run(3);
                solveLabel.Text += solve2.Item1;
                FxChart.ChartAreas[0].AxisX.Minimum = x[0] - 0.1;
                FxChart.ChartAreas[0].AxisX.Maximum = x[n - 1] + 0.1;
                FxChart.Legends["Legend"].Docking = Docking.Bottom;
                var series1 = new Series
                {
                    ChartType = SeriesChartType.Point,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = "f(x)",
                };
                var series2 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = solve1.Item2.ToString(),
                };
                var series3 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = solve2.Item2.ToString(),
                };
                FxChart.Series.Add(series1);
                FxChart.Series.Add(series2);
                FxChart.Series.Add(series3);
                for (int i = 0; i < y.Count; i++)
                {
                    FxChart.Series[0].Points.AddXY(x[i], y[i]);
                }
                for (double i = x[0]; i <= x[n - 1]; i += 0.1)
                {
                    FxChart.Series[1].Points.AddXY(i, solve1.Item2.Calculate(i));
                    FxChart.Series[2].Points.AddXY(i, solve2.Item2.Calculate(i));
                }
            }
            else if (methodComboBox.Text == "Derivative")
            {
                n = 5;
                nUpDown.Value = n;
                List<double> x = new List<double>() { -0.2, 0, 0.2, 0.4, 0.6 };
                List<double> y = new List<double>() { -0.40136, 0, 0.40136, 0.81152, 1.2435 };
                for (int i = 0; i < n; i++)
                {
                    xGridView.Rows[0].Cells[i].Value = x[i];
                    xGridView.Rows[1].Cells[i].Value = y[i];
                }
                xStarTextBox.Text = (0.2).ToString();
                xStar = 0.2;
                var t4 = new Task4(x, y, xStar);
                solveLabel.Text += t4.Run(1);
                solveLabel.Text += t4.Run(2);
            }
            else if (methodComboBox.Text == "Integrate")
            {
                n = 2;
                nUpDown.Value = n;
                yTextBox.Text = "x/((3*x+4)^2)";
                List<double> x = new List<double>() {-1, 1};
                for (int i = 0; i < n; i++)
                {
                    xGridView.Rows[0].Cells[i].Value = x[i];
                }
                h1 = 0.5;
                h1TextBox.Text = h1.ToString();
                h2 = 0.25;
                h2TextBox.Text = h2.ToString();
                Lexer lexer = new Lexer();
                Parser parser = new Parser();
                var fX = lexer.Run(yTextBox.Text);
                fX = parser.ToPostfix(fX);
                var t5 = new Task5(x, fX);
                solveLabel.Text += t5.Run(h1, h2);
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            FxChart.Series.Clear();
            solveLabel.Text = string.Empty;
            if (methodComboBox.Text == "Interpolation")
            {
                List<double> x = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    if (xGridView.Rows[0].Cells[i].Value != null)
                    {
                        x.Add(Convert.ToDouble(xGridView.Rows[0].Cells[i].Value));
                    }
                }
                var t1 = new L3.Task1(yTextBox.Text, x, xStar);
                solveLabel.Text += t1.Run();
            }
            else if (methodComboBox.Text == "Spline")
            {
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    if (xGridView.Rows[0].Cells[i].Value != null)
                    {
                        x.Add(Convert.ToDouble(xGridView.Rows[0].Cells[i].Value));
                        y.Add(Convert.ToDouble(xGridView.Rows[1].Cells[i].Value));
                    }
                }
                var t2 = new L3.Task2(x, y, xStar);
                var solve = t2.Run();
                solveLabel.Text += solve.Item1;
                FxChart.Legends["Legend"].Docking = Docking.Bottom;
                FxChart.ChartAreas[0].AxisX.Minimum = x[0];
                FxChart.ChartAreas[0].AxisX.Maximum = x[n - 1];
                var series1 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = solve.Item2.ToString(),
                };
                FxChart.Series.Add(series1);
                for (double i = x[0]; i <= x[n - 1]; i += 0.1)
                {
                    FxChart.Series[0].Points.AddXY(i, solve.Item2.Calculate(i));
                }
            }
            else if (methodComboBox.Text == "LSM")
            {
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    if (xGridView.Rows[0].Cells[i].Value != null)
                    {
                        x.Add(Convert.ToDouble(xGridView.Rows[0].Cells[i].Value));
                        y.Add(Convert.ToDouble(xGridView.Rows[1].Cells[i].Value));
                    }
                }
                var t3 = new L3.Task3(x, y);
                var solve1 = t3.Run(2);
                solveLabel.Text += solve1.Item1;
                var solve2 = t3.Run(3);
                solveLabel.Text += solve2.Item1;
                FxChart.ChartAreas[0].AxisX.Minimum = x[0] - 0.1;
                FxChart.ChartAreas[0].AxisX.Maximum = x[n - 1] + 0.1;
                FxChart.Legends["Legend"].Docking = Docking.Bottom;
                var series1 = new Series
                {
                    ChartType = SeriesChartType.Point,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = "f(x)",
                };
                var series2 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = solve1.Item2.ToString(),
                };
                var series3 = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Legend = "Legend",
                    LegendText = solve2.Item2.ToString(),
                };
                FxChart.Series.Add(series1);
                FxChart.Series.Add(series2);
                FxChart.Series.Add(series3);
                for (int i = 0; i < y.Count; i++)
                {
                    FxChart.Series[0].Points.AddXY(x[i], y[i]);
                }
                for (double i = x[0]; i <= x[n - 1]; i += 0.1)
                {
                    FxChart.Series[1].Points.AddXY(i, solve1.Item2.Calculate(i));
                    FxChart.Series[2].Points.AddXY(i, solve2.Item2.Calculate(i));
                }
            }
            else if (methodComboBox.Text == "Derivative")
            {
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    if (xGridView.Rows[0].Cells[i].Value != null)
                    {
                        x.Add(Convert.ToDouble(xGridView.Rows[0].Cells[i].Value));
                        y.Add(Convert.ToDouble(xGridView.Rows[1].Cells[i].Value));
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    xGridView.Rows[0].Cells[i].Value = x[i];
                    xGridView.Rows[1].Cells[i].Value = y[i];
                }
                xStarTextBox.Text = (0.2).ToString();
                xStar = 0.2;
                var t4 = new Task4(x, y, xStar);
                solveLabel.Text += t4.Run(1);
                solveLabel.Text += t4.Run(2);
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {

        }

        private void yTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void xStarTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(xStarTextBox.Text))
            {
                xStar = 0;
            }
            else if (!double.TryParse(xStarTextBox.Text, out xStar))
            {
            }
        }

        private void nUpDown_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(nUpDown.Value);
            if (n < 1)
            {
                n = 1;
            }
            nUpDown.Value = n;
            
            xGridView.ColumnCount = n;
            
            xGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            xGridView.AutoResizeColumns();
            xGridView.AutoResizeRows();

            for (int i = 0; i < n; i++)
            {
                xGridView.Columns[i].Name = (i + 1).ToString();
            }
        }

        private void h1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(h1TextBox.Text))
            {
                h1 = 1;
            }
            else if (!double.TryParse(h1TextBox.Text, out h1))
            {
            }
        }

        private void h2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(h2TextBox.Text))
            {
                h2 = 1;
            }
            else if (!double.TryParse(h2TextBox.Text, out h2))
            {
            }
        }
    }
}
