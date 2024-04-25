namespace app
{
    partial class Lab3
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.xGridView = new System.Windows.Forms.DataGridView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.xStarLabel = new System.Windows.Forms.Label();
            this.xStarTextBox = new System.Windows.Forms.TextBox();
            this.h1TextBox = new System.Windows.Forms.TextBox();
            this.h2TextBox = new System.Windows.Forms.TextBox();
            this.h1Label = new System.Windows.Forms.Label();
            this.h2Label = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.FxChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.methodLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.solveLabel = new System.Windows.Forms.Label();
            this.nUpDown = new System.Windows.Forms.NumericUpDown();
            this.nLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FxChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // xGridView
            // 
            this.xGridView.AllowUserToAddRows = false;
            this.xGridView.AllowUserToDeleteRows = false;
            this.xGridView.AllowUserToResizeColumns = false;
            this.xGridView.AllowUserToResizeRows = false;
            this.xGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.xGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xGridView.EnableHeadersVisualStyles = false;
            this.xGridView.GridColor = System.Drawing.SystemColors.Control;
            this.xGridView.Location = new System.Drawing.Point(903, 28);
            this.xGridView.Name = "xGridView";
            this.xGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.xGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.xGridView.RowHeadersWidth = 51;
            this.xGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.xGridView.Size = new System.Drawing.Size(206, 72);
            this.xGridView.TabIndex = 0;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(927, 106);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(156, 20);
            this.yTextBox.TabIndex = 1;
            this.yTextBox.TextChanged += new System.EventHandler(this.yTextBox_TextChanged);
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yLabel.Location = new System.Drawing.Point(907, 106);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 16);
            this.yLabel.TabIndex = 2;
            this.yLabel.Text = "y";
            this.yLabel.Click += new System.EventHandler(this.yLabel_Click);
            // 
            // xStarLabel
            // 
            this.xStarLabel.AutoSize = true;
            this.xStarLabel.Location = new System.Drawing.Point(903, 141);
            this.xStarLabel.Name = "xStarLabel";
            this.xStarLabel.Size = new System.Drawing.Size(18, 13);
            this.xStarLabel.TabIndex = 3;
            this.xStarLabel.Text = "X*";
            // 
            // xStarTextBox
            // 
            this.xStarTextBox.Location = new System.Drawing.Point(927, 138);
            this.xStarTextBox.Name = "xStarTextBox";
            this.xStarTextBox.Size = new System.Drawing.Size(155, 20);
            this.xStarTextBox.TabIndex = 4;
            this.xStarTextBox.TextChanged += new System.EventHandler(this.xStarTextBox_TextChanged);
            // 
            // h1TextBox
            // 
            this.h1TextBox.Location = new System.Drawing.Point(927, 173);
            this.h1TextBox.Name = "h1TextBox";
            this.h1TextBox.Size = new System.Drawing.Size(50, 20);
            this.h1TextBox.TabIndex = 5;
            this.h1TextBox.TextChanged += new System.EventHandler(this.h1TextBox_TextChanged);
            // 
            // h2TextBox
            // 
            this.h2TextBox.Location = new System.Drawing.Point(1032, 173);
            this.h2TextBox.Name = "h2TextBox";
            this.h2TextBox.Size = new System.Drawing.Size(50, 20);
            this.h2TextBox.TabIndex = 6;
            this.h2TextBox.TextChanged += new System.EventHandler(this.h2TextBox_TextChanged);
            // 
            // h1Label
            // 
            this.h1Label.AutoSize = true;
            this.h1Label.Location = new System.Drawing.Point(902, 176);
            this.h1Label.Name = "h1Label";
            this.h1Label.Size = new System.Drawing.Size(19, 13);
            this.h1Label.TabIndex = 7;
            this.h1Label.Text = "h1";
            // 
            // h2Label
            // 
            this.h2Label.AutoSize = true;
            this.h2Label.Location = new System.Drawing.Point(1007, 176);
            this.h2Label.Name = "h2Label";
            this.h2Label.Size = new System.Drawing.Size(19, 13);
            this.h2Label.TabIndex = 8;
            this.h2Label.Text = "h2";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(1007, 246);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(926, 246);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(927, 275);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 11;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(1007, 275);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 23);
            this.solveButton.TabIndex = 12;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // FxChart
            // 
            chartArea1.Name = "ChartArea1";
            this.FxChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.FxChart.Legends.Add(legend1);
            this.FxChart.Location = new System.Drawing.Point(809, 336);
            this.FxChart.Name = "FxChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.FxChart.Series.Add(series1);
            this.FxChart.Size = new System.Drawing.Size(300, 358);
            this.FxChart.TabIndex = 13;
            this.FxChart.Text = "FxChart";
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Location = new System.Drawing.Point(961, 212);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 21);
            this.methodComboBox.TabIndex = 16;
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(902, 215);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(43, 13);
            this.methodLabel.TabIndex = 17;
            this.methodLabel.Text = "Method";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.solveLabel);
            this.panel1.Location = new System.Drawing.Point(19, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 664);
            this.panel1.TabIndex = 19;
            // 
            // solveLabel
            // 
            this.solveLabel.AutoSize = true;
            this.solveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solveLabel.Location = new System.Drawing.Point(3, 3);
            this.solveLabel.Name = "solveLabel";
            this.solveLabel.Size = new System.Drawing.Size(60, 24);
            this.solveLabel.TabIndex = 0;
            this.solveLabel.Text = "label1";
            // 
            // nUpDown
            // 
            this.nUpDown.Location = new System.Drawing.Point(835, 25);
            this.nUpDown.Name = "nUpDown";
            this.nUpDown.Size = new System.Drawing.Size(50, 20);
            this.nUpDown.TabIndex = 20;
            this.nUpDown.ValueChanged += new System.EventHandler(this.nUpDown_ValueChanged);
            // 
            // nLabel
            // 
            this.nLabel.AutoSize = true;
            this.nLabel.Location = new System.Drawing.Point(806, 28);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(16, 13);
            this.nLabel.TabIndex = 21;
            this.nLabel.Text = "n:";
            // 
            // Lab3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1135, 755);
            this.Controls.Add(this.nLabel);
            this.Controls.Add(this.nUpDown);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.FxChart);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.h2Label);
            this.Controls.Add(this.h1Label);
            this.Controls.Add(this.h2TextBox);
            this.Controls.Add(this.h1TextBox);
            this.Controls.Add(this.xStarTextBox);
            this.Controls.Add(this.xStarLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xGridView);
            this.Name = "Lab3";
            this.Text = "lab3";
            this.Load += new System.EventHandler(this.Lab3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FxChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView xGridView;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xStarLabel;
        private System.Windows.Forms.TextBox xStarTextBox;
        private System.Windows.Forms.TextBox h1TextBox;
        private System.Windows.Forms.TextBox h2TextBox;
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Label h2Label;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart FxChart;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label solveLabel;
        private System.Windows.Forms.NumericUpDown nUpDown;
        private System.Windows.Forms.Label nLabel;
    }
}

