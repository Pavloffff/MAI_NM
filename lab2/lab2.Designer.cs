namespace app
{
    partial class lab2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lab2));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBoxEq1 = new System.Windows.Forms.TextBox();
            this.labelEq1 = new System.Windows.Forms.Label();
            this.labelEq2 = new System.Windows.Forms.Label();
            this.textBoxEq2 = new System.Windows.Forms.TextBox();
            this.chartFx = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.labelMethod = new System.Windows.Forms.Label();
            this.labelRange = new System.Windows.Forms.Label();
            this.textBoxLeftRangeX = new System.Windows.Forms.TextBox();
            this.textBoxRightRangeX = new System.Windows.Forms.TextBox();
            this.labelLeftRange = new System.Windows.Forms.Label();
            this.labelRightRange = new System.Windows.Forms.Label();
            this.textBoxConst = new System.Windows.Forms.TextBox();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.labelTask = new System.Windows.Forms.Label();
            this.labelConst = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSolution = new System.Windows.Forms.Label();
            this.textBoxEpsilon = new System.Windows.Forms.TextBox();
            this.labelEpsilon = new System.Windows.Forms.Label();
            this.labelMinX = new System.Windows.Forms.Label();
            this.labelMaxX = new System.Windows.Forms.Label();
            this.numericUpDownMinX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxX = new System.Windows.Forms.NumericUpDown();
            this.textBoxIterations = new System.Windows.Forms.TextBox();
            this.labelIterations = new System.Windows.Forms.Label();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.numericUpDownMaxY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinY = new System.Windows.Forms.NumericUpDown();
            this.labelMaxY = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRightRangeY = new System.Windows.Forms.TextBox();
            this.textBoxLeftRangeY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartFx)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinY)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEq1
            // 
            resources.ApplyResources(this.textBoxEq1, "textBoxEq1");
            this.textBoxEq1.Name = "textBoxEq1";
            this.textBoxEq1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelEq1
            // 
            resources.ApplyResources(this.labelEq1, "labelEq1");
            this.labelEq1.Name = "labelEq1";
            // 
            // labelEq2
            // 
            resources.ApplyResources(this.labelEq2, "labelEq2");
            this.labelEq2.Name = "labelEq2";
            // 
            // textBoxEq2
            // 
            resources.ApplyResources(this.textBoxEq2, "textBoxEq2");
            this.textBoxEq2.Name = "textBoxEq2";
            this.textBoxEq2.TextChanged += new System.EventHandler(this.textBoxEq2_TextChanged);
            // 
            // chartFx
            // 
            chartArea2.Name = "ChartArea1";
            this.chartFx.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartFx.Legends.Add(legend2);
            resources.ApplyResources(this.chartFx, "chartFx");
            this.chartFx.Name = "chartFx";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartFx.Series.Add(series2);
            this.chartFx.Click += new System.EventHandler(this.chart1_Click);
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxMethod, "comboBoxMethod");
            this.comboBoxMethod.Name = "comboBoxMethod";
            // 
            // labelMethod
            // 
            resources.ApplyResources(this.labelMethod, "labelMethod");
            this.labelMethod.Name = "labelMethod";
            // 
            // labelRange
            // 
            resources.ApplyResources(this.labelRange, "labelRange");
            this.labelRange.Name = "labelRange";
            // 
            // textBoxLeftRangeX
            // 
            resources.ApplyResources(this.textBoxLeftRangeX, "textBoxLeftRangeX");
            this.textBoxLeftRangeX.Name = "textBoxLeftRangeX";
            this.textBoxLeftRangeX.TextChanged += new System.EventHandler(this.textBoxLeftRange_TextChanged);
            // 
            // textBoxRightRangeX
            // 
            resources.ApplyResources(this.textBoxRightRangeX, "textBoxRightRangeX");
            this.textBoxRightRangeX.Name = "textBoxRightRangeX";
            this.textBoxRightRangeX.TextChanged += new System.EventHandler(this.textBoxRightRange_TextChanged);
            // 
            // labelLeftRange
            // 
            resources.ApplyResources(this.labelLeftRange, "labelLeftRange");
            this.labelLeftRange.Name = "labelLeftRange";
            // 
            // labelRightRange
            // 
            resources.ApplyResources(this.labelRightRange, "labelRightRange");
            this.labelRightRange.Name = "labelRightRange";
            // 
            // textBoxConst
            // 
            resources.ApplyResources(this.textBoxConst, "textBoxConst");
            this.textBoxConst.Name = "textBoxConst";
            this.textBoxConst.TextChanged += new System.EventHandler(this.textBoxConst_TextChanged);
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxTask, "comboBoxTask");
            this.comboBoxTask.Name = "comboBoxTask";
            // 
            // labelTask
            // 
            resources.ApplyResources(this.labelTask, "labelTask");
            this.labelTask.Name = "labelTask";
            // 
            // labelConst
            // 
            resources.ApplyResources(this.labelConst, "labelConst");
            this.labelConst.Name = "labelConst";
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonClear
            // 
            resources.ApplyResources(this.buttonClear, "buttonClear");
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSolve
            // 
            resources.ApplyResources(this.buttonSolve, "buttonSolve");
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonTest
            // 
            resources.ApplyResources(this.buttonTest, "buttonTest");
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.labelSolution);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelSolution
            // 
            resources.ApplyResources(this.labelSolution, "labelSolution");
            this.labelSolution.Name = "labelSolution";
            // 
            // textBoxEpsilon
            // 
            resources.ApplyResources(this.textBoxEpsilon, "textBoxEpsilon");
            this.textBoxEpsilon.Name = "textBoxEpsilon";
            this.textBoxEpsilon.TextChanged += new System.EventHandler(this.textBoxEpsilon_TextChanged);
            // 
            // labelEpsilon
            // 
            resources.ApplyResources(this.labelEpsilon, "labelEpsilon");
            this.labelEpsilon.Name = "labelEpsilon";
            // 
            // labelMinX
            // 
            resources.ApplyResources(this.labelMinX, "labelMinX");
            this.labelMinX.Name = "labelMinX";
            // 
            // labelMaxX
            // 
            resources.ApplyResources(this.labelMaxX, "labelMaxX");
            this.labelMaxX.Name = "labelMaxX";
            // 
            // numericUpDownMinX
            // 
            resources.ApplyResources(this.numericUpDownMinX, "numericUpDownMinX");
            this.numericUpDownMinX.Name = "numericUpDownMinX";
            // 
            // numericUpDownMaxX
            // 
            resources.ApplyResources(this.numericUpDownMaxX, "numericUpDownMaxX");
            this.numericUpDownMaxX.Name = "numericUpDownMaxX";
            this.numericUpDownMaxX.ValueChanged += new System.EventHandler(this.numericUpDownMaxX_ValueChanged_1);
            // 
            // textBoxIterations
            // 
            resources.ApplyResources(this.textBoxIterations, "textBoxIterations");
            this.textBoxIterations.Name = "textBoxIterations";
            this.textBoxIterations.TextChanged += new System.EventHandler(this.textBoxIterations_TextChanged);
            // 
            // labelIterations
            // 
            resources.ApplyResources(this.labelIterations, "labelIterations");
            this.labelIterations.Name = "labelIterations";
            // 
            // buttonDraw
            // 
            resources.ApplyResources(this.buttonDraw, "buttonDraw");
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // numericUpDownMaxY
            // 
            resources.ApplyResources(this.numericUpDownMaxY, "numericUpDownMaxY");
            this.numericUpDownMaxY.Name = "numericUpDownMaxY";
            // 
            // numericUpDownMinY
            // 
            resources.ApplyResources(this.numericUpDownMinY, "numericUpDownMinY");
            this.numericUpDownMinY.Name = "numericUpDownMinY";
            // 
            // labelMaxY
            // 
            resources.ApplyResources(this.labelMaxY, "labelMaxY");
            this.labelMaxY.Name = "labelMaxY";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBoxRightRangeY
            // 
            resources.ApplyResources(this.textBoxRightRangeY, "textBoxRightRangeY");
            this.textBoxRightRangeY.Name = "textBoxRightRangeY";
            this.textBoxRightRangeY.TextChanged += new System.EventHandler(this.textBoxRightRangeY_TextChanged);
            // 
            // textBoxLeftRangeY
            // 
            resources.ApplyResources(this.textBoxLeftRangeY, "textBoxLeftRangeY");
            this.textBoxLeftRangeY.Name = "textBoxLeftRangeY";
            this.textBoxLeftRangeY.TextChanged += new System.EventHandler(this.textBoxLeftRangeY_TextChanged);
            // 
            // lab2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRightRangeY);
            this.Controls.Add(this.textBoxLeftRangeY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownMaxY);
            this.Controls.Add(this.numericUpDownMinY);
            this.Controls.Add(this.labelMaxY);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.labelIterations);
            this.Controls.Add(this.textBoxIterations);
            this.Controls.Add(this.numericUpDownMaxX);
            this.Controls.Add(this.numericUpDownMinX);
            this.Controls.Add(this.labelMaxX);
            this.Controls.Add(this.labelMinX);
            this.Controls.Add(this.labelEpsilon);
            this.Controls.Add(this.textBoxEpsilon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelConst);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.comboBoxTask);
            this.Controls.Add(this.textBoxConst);
            this.Controls.Add(this.labelRightRange);
            this.Controls.Add(this.labelLeftRange);
            this.Controls.Add(this.textBoxRightRangeX);
            this.Controls.Add(this.textBoxLeftRangeX);
            this.Controls.Add(this.labelRange);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.chartFx);
            this.Controls.Add(this.textBoxEq2);
            this.Controls.Add(this.labelEq2);
            this.Controls.Add(this.labelEq1);
            this.Controls.Add(this.textBoxEq1);
            this.Name = "lab2";
            this.Load += new System.EventHandler(this.lab2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartFx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEq1;
        private System.Windows.Forms.Label labelEq1;
        private System.Windows.Forms.Label labelEq2;
        private System.Windows.Forms.TextBox textBoxEq2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFx;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.TextBox textBoxLeftRangeX;
        private System.Windows.Forms.TextBox textBoxRightRangeX;
        private System.Windows.Forms.Label labelLeftRange;
        private System.Windows.Forms.Label labelRightRange;
        private System.Windows.Forms.TextBox textBoxConst;
        private System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.Label labelConst;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSolution;
        private System.Windows.Forms.TextBox textBoxEpsilon;
        private System.Windows.Forms.Label labelEpsilon;
        private System.Windows.Forms.Label labelMinX;
        private System.Windows.Forms.Label labelMaxX;
        private System.Windows.Forms.NumericUpDown numericUpDownMinX;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxX;
        private System.Windows.Forms.TextBox textBoxIterations;
        private System.Windows.Forms.Label labelIterations;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxY;
        private System.Windows.Forms.NumericUpDown numericUpDownMinY;
        private System.Windows.Forms.Label labelMaxY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRightRangeY;
        private System.Windows.Forms.TextBox textBoxLeftRangeY;
    }
}

