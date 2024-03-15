using app.L1.Task1;
using app.L1.Task2;
using app.L1.Task3;
using app.L1.Task4;
using app.L1.Task5;
using app.Linal.Matrix;
using app.Linal.Vector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class Lab1 : Form
    {
        public int n = 4;
        public double epsilon = 0.001;

        public Lab1()
        {
            InitializeComponent();
            this.epsilonTextBox.KeyPress += new KeyPressEventHandler(epsilonTextBox_KeyPress);

            aGridView.RowHeadersVisible = false;
            bGridView.RowHeadersVisible = false;
            aGridView.ColumnCount = n;
            aGridView.RowCount = n;
            aGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            bGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            aGridView.AutoResizeColumns();
            aGridView.AutoResizeRows();
            bGridView.AutoResizeColumns();
            bGridView.AutoResizeRows();
            bGridView.ColumnCount = 1;
            bGridView.RowCount = n;
            for (int i = 0; i < n; i++)
            {
                aGridView.Columns[i].Name = "A" + (i + 1);
            }
            bGridView.Columns[0].Name = "b";
            foreach (DataGridViewRow row in aGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
            foreach (DataGridViewRow row in bGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
            epsilonTextBox.Text = epsilon.ToString();

            methodComboBox.Items.Add("LU-decomposition");
            methodComboBox.Items.Add("TMA");
            methodComboBox.Items.Add("Iteration method");
            methodComboBox.Items.Add("Seidel method");
            methodComboBox.Items.Add("Rotation method");
            methodComboBox.Items.Add("QR-algorithm");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void nValue_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(nValue.Value);
            if (n < 1)
            {
                n = 1;
            }
            nValue.Value = n;
            
            aGridView.ColumnCount = n;
            aGridView.RowCount = n;
            bGridView.RowCount = n;

            aGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            bGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            aGridView.AutoResizeColumns();
            aGridView.AutoResizeRows();

            for (int i = 0; i < n; i++)
            {
                aGridView.Columns[i].Name = "A" + (i + 1);
            }
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            Matrix A = new Matrix(n);
            Vector b = new Vector(n);
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                for (int j = 0; j < aGridView.Columns.Count; j++)
                {
                    if (aGridView.Rows[i].Cells[j].Value != null)
                    {
                        A[i, j] = Convert.ToDouble(aGridView.Rows[i].Cells[j].Value);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (bGridView.Rows[i].Cells[0].Value != null)
                {
                    b[i] = Convert.ToDouble(bGridView.Rows[i].Cells[0].Value);
                }
            }
            string res = string.Empty;
            if (methodComboBox.Text == "LU-decomposition")
            {
                LU solver = new LU(A, b);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "TMA")
            {
                if (A.Cols >= 3)
                {
                    TMA solver = new TMA(A, b);
                    res = solver.Run();
                } 
                else
                {
                    res = "Invalid Matrix\n";
                }
            }
            else if (methodComboBox.Text == "Iteration method")
            {
                Iteration solver = new Iteration(A, b, epsilon);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "Seidel method")
            {
                Seidel solver = new Seidel(A, b, epsilon);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "Rotation method")
            {
                Rotation solver = new Rotation(A, epsilon);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "QR-algorithm")
            {
                QR solver = new QR(A, epsilon);
                res = solver.Run();
            }
            solveLabel.Text = res;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            n = 4;
            nValue.Value = n;
            
            aGridView.ColumnCount = n;
            aGridView.RowCount = n;
            bGridView.RowCount = n;

            aGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            bGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            aGridView.AutoResizeColumns();
            aGridView.AutoResizeRows();

            for (int i = 0; i < n; i++)
            {
                aGridView.Columns[i].Name = "A" + (i + 1);
            }

            foreach (DataGridViewRow row in aGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
            foreach (DataGridViewRow row in bGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }

            solveLabel.Text = string.Empty;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {

            List<List<double>> testA = new List<List<double>>();
            double[] testB = new double[n];
            
            if (methodComboBox.Text == "LU-decomposition")
            {
                testA = new List<List<double>>()
                {
                    new List<double>() { 7, -5, 6, 7 },
                    new List<double>() { 8, -1, -9, 1 },
                    new List<double>() { -3, 8, 8, 8 },
                    new List<double>() { 2, -3, 6, -4 }
                };
                testB = new double[] { 120, 31, 6, 25 };
            }
            else if (methodComboBox.Text == "TMA")
            {
                testA = new List<List<double>>()
                {
                    new List<double>() { -6, 5, 0, 0, 0},
                    new List<double>() { -1, 13, 6, 0, 0},
                    new List<double>() { 0, -9, -15, -4, 0},
                    new List<double>() { 0, 0, -1, -7, 1},
                    new List<double>() { 0, 0, 0, 9, -18}
                };
                testB = new double[] { 51, 100, -12, 47, -90 };
            }
            else if (methodComboBox.Text == "Iteration method" || 
                     methodComboBox.Text == "Seidel method")
            {
                testA = new List<List<double>>()
                {
                    new List<double>() { -19, 2, -1, -8 },
                    new List<double>() { 2, 14, 0, -4 },
                    new List<double>() { 6, -5, -20, -6 },
                    new List<double>() { -6, 4, -2, 15 }
                };
                testB = new double[] { 38, 20, 52, 43 };
            }
            else if (methodComboBox.Text == "Rotation method")
            {
                testA = new List<List<double>>()
                {
                    new List<double>() { 5, -3, -4 },
                    new List<double>() { -3, -3, 4 },
                    new List<double>() { -4, 4, 0 }
                };
                testB = new double[] { 0, 0, 0 };
            }
            else if (methodComboBox.Text == "QR-algorithm")
            {
                testA = new List<List<double>>()
                {
                    new List<double>() { 1, 3, 1 },
                    new List<double>() { 1, 1, 4 },
                    new List<double>() { 4, 3, 1 }
                };
                testB = new double[] { 0, 0, 0 };
            }
            else
            {
                return;
            }
            n = testA.Count;
            Matrix A = new Matrix(n);
            Vector b = new Vector(n);
            
            nValue.Value = n;
            
            aGridView.ColumnCount = n;
            aGridView.RowCount = n;
            bGridView.RowCount = n;

            aGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            bGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            aGridView.AutoResizeColumns();
            aGridView.AutoResizeRows();

            for (int i = 0; i < n; i++)
            {
                b[i] = testB[i];
                aGridView.Columns[i].Name = "A" + (i + 1);
                bGridView.Rows[i].Cells[0].Value = testB[i];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = testA[i][j];
                    aGridView.Rows[i].Cells[j].Value = testA[i][j];
                }
            }
            string res = string.Empty;
            if (methodComboBox.Text == "LU-decomposition")
            {
                LU solver = new LU(A, b);
                res = solver.Run();
            } 
            else if (methodComboBox.Text == "TMA")
            {
                TMA solver = new TMA(A, b);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "Iteration method")
            {
                Iteration solver = new Iteration(A, b, epsilon);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "Seidel method")
            {
                Seidel solver = new Seidel(A, b, epsilon);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "Rotation method")
            {
                Rotation solver = new Rotation(A, epsilon);
                res = solver.Run();
            }
            else if (methodComboBox.Text == "QR-algorithm")
            {
                QR solver = new QR(A, epsilon);
                res = solver.Run();
            }
            solveLabel.Text = res;
        }

        private void aGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Lab1_Load(object sender, EventArgs e)
        {

        }

        private void epsilonTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(epsilonTextBox.Text))
            {
                epsilon = 0.001;
            }
            else if (!double.TryParse(epsilonTextBox.Text, out epsilon))
            {
            }
        }

        private void epsilonTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
