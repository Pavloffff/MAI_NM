namespace WindowsFormsApp1
{
    partial class Lab4
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
            this.fLabel = new System.Windows.Forms.Label();
            this.x0Label = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.hLabel = new System.Windows.Forms.Label();
            this.exactLabel = new System.Windows.Forms.Label();
            this.hTextBox = new System.Windows.Forms.TextBox();
            this.x1Label = new System.Windows.Forms.Label();
            this.maxXTextBox = new System.Windows.Forms.TextBox();
            this.methodLabel = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.solveLabel = new System.Windows.Forms.Label();
            this.x0TextBox = new System.Windows.Forms.TextBox();
            this.exactTextBox = new System.Windows.Forms.TextBox();
            this.zTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.fTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLabel
            // 
            this.fLabel.AutoSize = true;
            this.fLabel.Location = new System.Drawing.Point(13, 13);
            this.fLabel.Name = "fLabel";
            this.fLabel.Size = new System.Drawing.Size(45, 13);
            this.fLabel.TabIndex = 0;
            this.fLabel.Text = "f(x, y, y\')";
            // 
            // x0Label
            // 
            this.x0Label.AutoSize = true;
            this.x0Label.Location = new System.Drawing.Point(16, 39);
            this.x0Label.Name = "x0Label";
            this.x0Label.Size = new System.Drawing.Size(18, 13);
            this.x0Label.TabIndex = 2;
            this.x0Label.Text = "x0";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(16, 64);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(29, 13);
            this.yLabel.TabIndex = 3;
            this.yLabel.Text = "y(x0)";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(16, 91);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(31, 13);
            this.zLabel.TabIndex = 4;
            this.zLabel.Text = "y\'(x0)";
            // 
            // hLabel
            // 
            this.hLabel.AutoSize = true;
            this.hLabel.Location = new System.Drawing.Point(16, 146);
            this.hLabel.Name = "hLabel";
            this.hLabel.Size = new System.Drawing.Size(13, 13);
            this.hLabel.TabIndex = 8;
            this.hLabel.Text = "h";
            // 
            // exactLabel
            // 
            this.exactLabel.AutoSize = true;
            this.exactLabel.Location = new System.Drawing.Point(16, 119);
            this.exactLabel.Name = "exactLabel";
            this.exactLabel.Size = new System.Drawing.Size(33, 13);
            this.exactLabel.TabIndex = 9;
            this.exactLabel.Text = "exact";
            // 
            // hTextBox
            // 
            this.hTextBox.Location = new System.Drawing.Point(64, 143);
            this.hTextBox.Name = "hTextBox";
            this.hTextBox.Size = new System.Drawing.Size(216, 20);
            this.hTextBox.TabIndex = 10;
            this.hTextBox.TextChanged += new System.EventHandler(this.hTextBox_TextChanged);
            // 
            // x1Label
            // 
            this.x1Label.AutoSize = true;
            this.x1Label.Location = new System.Drawing.Point(165, 39);
            this.x1Label.Name = "x1Label";
            this.x1Label.Size = new System.Drawing.Size(18, 13);
            this.x1Label.TabIndex = 14;
            this.x1Label.Text = "x1";
            // 
            // maxXTextBox
            // 
            this.maxXTextBox.Location = new System.Drawing.Point(204, 36);
            this.maxXTextBox.Name = "maxXTextBox";
            this.maxXTextBox.Size = new System.Drawing.Size(76, 20);
            this.maxXTextBox.TabIndex = 15;
            this.maxXTextBox.TextChanged += new System.EventHandler(this.maxXTextBox_TextChanged);
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(310, 13);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(31, 13);
            this.methodLabel.TabIndex = 16;
            this.methodLabel.Text = "Task";
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Location = new System.Drawing.Point(347, 9);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(89, 21);
            this.methodComboBox.TabIndex = 17;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(347, 84);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(89, 23);
            this.clearButton.TabIndex = 18;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(347, 113);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(89, 23);
            this.testButton.TabIndex = 19;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(347, 140);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(89, 23);
            this.solveButton.TabIndex = 20;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(347, 55);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(89, 23);
            this.exitButton.TabIndex = 21;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.solveLabel);
            this.panel1.Location = new System.Drawing.Point(16, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 534);
            this.panel1.TabIndex = 22;
            // 
            // solveLabel
            // 
            this.solveLabel.AutoSize = true;
            this.solveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solveLabel.Location = new System.Drawing.Point(7, 9);
            this.solveLabel.Name = "solveLabel";
            this.solveLabel.Size = new System.Drawing.Size(93, 15);
            this.solveLabel.TabIndex = 0;
            this.solveLabel.Text = "Solution here";
            // 
            // x0TextBox
            // 
            this.x0TextBox.Location = new System.Drawing.Point(64, 36);
            this.x0TextBox.Name = "x0TextBox";
            this.x0TextBox.Size = new System.Drawing.Size(76, 20);
            this.x0TextBox.TabIndex = 24;
            this.x0TextBox.TextChanged += new System.EventHandler(this.minXTextBox_TextChanged);
            // 
            // exactTextBox
            // 
            this.exactTextBox.Location = new System.Drawing.Point(64, 116);
            this.exactTextBox.Name = "exactTextBox";
            this.exactTextBox.Size = new System.Drawing.Size(216, 20);
            this.exactTextBox.TabIndex = 25;
            // 
            // zTextBox
            // 
            this.zTextBox.Location = new System.Drawing.Point(64, 88);
            this.zTextBox.Name = "zTextBox";
            this.zTextBox.Size = new System.Drawing.Size(216, 20);
            this.zTextBox.TabIndex = 26;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(64, 61);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(216, 20);
            this.yTextBox.TabIndex = 27;
            // 
            // fTextBox
            // 
            this.fTextBox.Location = new System.Drawing.Point(64, 9);
            this.fTextBox.Name = "fTextBox";
            this.fTextBox.Size = new System.Drawing.Size(216, 20);
            this.fTextBox.TabIndex = 28;
            // 
            // Lab4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 715);
            this.Controls.Add(this.fTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.zTextBox);
            this.Controls.Add(this.exactTextBox);
            this.Controls.Add(this.x0TextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.maxXTextBox);
            this.Controls.Add(this.x1Label);
            this.Controls.Add(this.hTextBox);
            this.Controls.Add(this.exactLabel);
            this.Controls.Add(this.hLabel);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.x0Label);
            this.Controls.Add(this.fLabel);
            this.Name = "Lab4";
            this.Text = "Lab4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fLabel;
        private System.Windows.Forms.Label x0Label;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Label hLabel;
        private System.Windows.Forms.Label exactLabel;
        private System.Windows.Forms.TextBox hTextBox;
        private System.Windows.Forms.Label x1Label;
        private System.Windows.Forms.TextBox maxXTextBox;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label solveLabel;
        private System.Windows.Forms.TextBox x0TextBox;
        private System.Windows.Forms.TextBox exactTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox fTextBox;
    }
}

