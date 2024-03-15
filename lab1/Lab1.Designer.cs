namespace app
{
    partial class Lab1
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
            this.nValue = new System.Windows.Forms.NumericUpDown();
            this.solveBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.nLabel = new System.Windows.Forms.Label();
            this.aLabel = new System.Windows.Forms.Label();
            this.bLabel = new System.Windows.Forms.Label();
            this.aGridView = new System.Windows.Forms.DataGridView();
            this.bGridView = new System.Windows.Forms.DataGridView();
            this.solvePanel = new System.Windows.Forms.Panel();
            this.solveLabel = new System.Windows.Forms.Label();
            this.methodLabel = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.epsilonLabel = new System.Windows.Forms.Label();
            this.epsilonTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bGridView)).BeginInit();
            this.solvePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nValue
            // 
            this.nValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nValue.Location = new System.Drawing.Point(109, 44);
            this.nValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nValue.Name = "nValue";
            this.nValue.Size = new System.Drawing.Size(67, 22);
            this.nValue.TabIndex = 0;
            this.nValue.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nValue.ValueChanged += new System.EventHandler(this.nValue_ValueChanged);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(896, 386);
            this.solveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(100, 28);
            this.solveBtn.TabIndex = 2;
            this.solveBtn.Text = "Solve";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(896, 458);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(100, 28);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(896, 494);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(100, 28);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // nLabel
            // 
            this.nLabel.AutoSize = true;
            this.nLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nLabel.Location = new System.Drawing.Point(72, 41);
            this.nLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(29, 25);
            this.nLabel.TabIndex = 5;
            this.nLabel.Text = "n:";
            this.nLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aLabel.Location = new System.Drawing.Point(72, 90);
            this.aLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(32, 25);
            this.aLabel.TabIndex = 6;
            this.aLabel.Text = "A:";
            this.aLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLabel.Location = new System.Drawing.Point(577, 90);
            this.bLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(31, 25);
            this.bLabel.TabIndex = 7;
            this.bLabel.Text = "B:";
            this.bLabel.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // aGridView
            // 
            this.aGridView.AllowUserToAddRows = false;
            this.aGridView.AllowUserToDeleteRows = false;
            this.aGridView.AllowUserToResizeColumns = false;
            this.aGridView.AllowUserToResizeRows = false;
            this.aGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.aGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aGridView.Location = new System.Drawing.Point(77, 137);
            this.aGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.aGridView.Name = "aGridView";
            this.aGridView.RowHeadersWidth = 51;
            this.aGridView.Size = new System.Drawing.Size(433, 260);
            this.aGridView.TabIndex = 8;
            this.aGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aGridView_CellContentClick);
            // 
            // bGridView
            // 
            this.bGridView.AllowUserToAddRows = false;
            this.bGridView.AllowUserToDeleteRows = false;
            this.bGridView.AllowUserToResizeColumns = false;
            this.bGridView.AllowUserToResizeRows = false;
            this.bGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.bGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bGridView.Location = new System.Drawing.Point(583, 137);
            this.bGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bGridView.Name = "bGridView";
            this.bGridView.RowHeadersWidth = 51;
            this.bGridView.Size = new System.Drawing.Size(179, 260);
            this.bGridView.TabIndex = 9;
            this.bGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bGridView_CellContentClick);
            // 
            // solvePanel
            // 
            this.solvePanel.AutoScroll = true;
            this.solvePanel.Controls.Add(this.solveLabel);
            this.solvePanel.Location = new System.Drawing.Point(77, 458);
            this.solvePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.solvePanel.Name = "solvePanel";
            this.solvePanel.Size = new System.Drawing.Size(765, 543);
            this.solvePanel.TabIndex = 10;
            // 
            // solveLabel
            // 
            this.solveLabel.AutoSize = true;
            this.solveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solveLabel.Location = new System.Drawing.Point(28, 12);
            this.solveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.solveLabel.Name = "solveLabel";
            this.solveLabel.Size = new System.Drawing.Size(0, 25);
            this.solveLabel.TabIndex = 0;
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.methodLabel.Location = new System.Drawing.Point(295, 44);
            this.methodLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(83, 25);
            this.methodLabel.TabIndex = 11;
            this.methodLabel.Text = "method:";
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Location = new System.Drawing.Point(409, 43);
            this.methodComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(160, 24);
            this.methodComboBox.TabIndex = 12;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(896, 422);
            this.testBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(100, 28);
            this.testBtn.TabIndex = 13;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // epsilonLabel
            // 
            this.epsilonLabel.AutoSize = true;
            this.epsilonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.epsilonLabel.Location = new System.Drawing.Point(711, 41);
            this.epsilonLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.epsilonLabel.Name = "epsilonLabel";
            this.epsilonLabel.Size = new System.Drawing.Size(29, 25);
            this.epsilonLabel.TabIndex = 15;
            this.epsilonLabel.Text = "ε:";
            // 
            // epsilonTextBox
            // 
            this.epsilonTextBox.Location = new System.Drawing.Point(748, 44);
            this.epsilonTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.epsilonTextBox.Name = "epsilonTextBox";
            this.epsilonTextBox.Size = new System.Drawing.Size(93, 22);
            this.epsilonTextBox.TabIndex = 16;
            this.epsilonTextBox.TextChanged += new System.EventHandler(this.epsilonTextBox_TextChanged);
            // 
            // Lab1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1050, 1055);
            this.Controls.Add(this.epsilonTextBox);
            this.Controls.Add(this.epsilonLabel);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.solvePanel);
            this.Controls.Add(this.bGridView);
            this.Controls.Add(this.aGridView);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.nLabel);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.nValue);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Lab1";
            this.Text = "Lab1";
            this.TransparencyKey = System.Drawing.Color.Green;
            this.Load += new System.EventHandler(this.Lab1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bGridView)).EndInit();
            this.solvePanel.ResumeLayout(false);
            this.solvePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nValue;
        private System.Windows.Forms.Button solveBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label nLabel;
        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.Label bLabel;
        private System.Windows.Forms.DataGridView aGridView;
        private System.Windows.Forms.DataGridView bGridView;
        private System.Windows.Forms.Panel solvePanel;
        private System.Windows.Forms.Label solveLabel;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Label epsilonLabel;
        private System.Windows.Forms.TextBox epsilonTextBox;
    }
}

