namespace TaxCalculatorMain2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            loadToolStripMenuItem = new ToolStripMenuItem();
            taxScheduleToolStripMenuItem = new ToolStripMenuItem();
            employeeIncomeToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            currentTaxScheduleToolStripMenuItem = new ToolStripMenuItem();
            employeeTaxesToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveEmployeeTaxesToFileToolStripMenuItem = new ToolStripMenuItem();
            lblTaxableIncome = new Label();
            lblTaxOwed = new Label();
            txbTaxableIncome = new TextBox();
            txbTaxOwed = new TextBox();
            btnCalc = new Button();
            btnExit = new Button();
            menuStrip2 = new MenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadToolStripMenuItem, showToolStripMenuItem, saveToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(294, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { taxScheduleToolStripMenuItem, employeeIncomeToolStripMenuItem });
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(48, 20);
            loadToolStripMenuItem.Text = "Load:";
            // 
            // taxScheduleToolStripMenuItem
            // 
            taxScheduleToolStripMenuItem.Name = "taxScheduleToolStripMenuItem";
            taxScheduleToolStripMenuItem.Size = new Size(181, 22);
            taxScheduleToolStripMenuItem.Text = "Tax Schedule ...";
            taxScheduleToolStripMenuItem.Click += taxScheduleToolStripMenuItem_Click;
            // 
            // employeeIncomeToolStripMenuItem
            // 
            employeeIncomeToolStripMenuItem.Name = "employeeIncomeToolStripMenuItem";
            employeeIncomeToolStripMenuItem.Size = new Size(181, 22);
            employeeIncomeToolStripMenuItem.Text = "Employee Income ...";
            employeeIncomeToolStripMenuItem.Click += employeeIncomeToolStripMenuItem_Click_2;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { currentTaxScheduleToolStripMenuItem, employeeTaxesToolStripMenuItem });
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(51, 20);
            showToolStripMenuItem.Text = "Show:";
            // 
            // currentTaxScheduleToolStripMenuItem
            // 
            currentTaxScheduleToolStripMenuItem.Name = "currentTaxScheduleToolStripMenuItem";
            currentTaxScheduleToolStripMenuItem.Size = new Size(185, 22);
            currentTaxScheduleToolStripMenuItem.Text = "Current Tax Schedule";
            currentTaxScheduleToolStripMenuItem.Click += currentTaxScheduleToolStripMenuItem_Click;
            // 
            // employeeTaxesToolStripMenuItem
            // 
            employeeTaxesToolStripMenuItem.Name = "employeeTaxesToolStripMenuItem";
            employeeTaxesToolStripMenuItem.Size = new Size(185, 22);
            employeeTaxesToolStripMenuItem.Text = "Employee Taxes";
            employeeTaxesToolStripMenuItem.Click += employeeTaxesToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveEmployeeTaxesToFileToolStripMenuItem });
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(46, 20);
            saveToolStripMenuItem.Text = "Save:";
            // 
            // saveEmployeeTaxesToFileToolStripMenuItem
            // 
            saveEmployeeTaxesToFileToolStripMenuItem.Name = "saveEmployeeTaxesToFileToolStripMenuItem";
            saveEmployeeTaxesToFileToolStripMenuItem.Size = new Size(231, 22);
            saveEmployeeTaxesToFileToolStripMenuItem.Text = "Save Employee Taxes to File ...";
            // 
            // lblTaxableIncome
            // 
            lblTaxableIncome.AutoSize = true;
            lblTaxableIncome.Location = new Point(29, 49);
            lblTaxableIncome.Name = "lblTaxableIncome";
            lblTaxableIncome.Size = new Size(92, 15);
            lblTaxableIncome.TabIndex = 1;
            lblTaxableIncome.Text = "Taxable income:";
            // 
            // lblTaxOwed
            // 
            lblTaxOwed.AutoSize = true;
            lblTaxOwed.Location = new Point(29, 84);
            lblTaxOwed.Name = "lblTaxOwed";
            lblTaxOwed.Size = new Size(101, 15);
            lblTaxOwed.TabIndex = 2;
            lblTaxOwed.Text = "Income tax owed:";
            // 
            // txbTaxableIncome
            // 
            txbTaxableIncome.Location = new Point(142, 46);
            txbTaxableIncome.Name = "txbTaxableIncome";
            txbTaxableIncome.Size = new Size(100, 23);
            txbTaxableIncome.TabIndex = 3;
            // 
            // txbTaxOwed
            // 
            txbTaxOwed.Location = new Point(142, 81);
            txbTaxOwed.Name = "txbTaxOwed";
            txbTaxOwed.ReadOnly = true;
            txbTaxOwed.Size = new Size(100, 23);
            txbTaxOwed.TabIndex = 4;
            // 
            // btnCalc
            // 
            btnCalc.Location = new Point(12, 164);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(75, 23);
            btnCalc.TabIndex = 5;
            btnCalc.Text = "Calculate";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(207, 164);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click_1;
            // 
            // menuStrip2
            // 
            menuStrip2.Anchor = AnchorStyles.Bottom;
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.Location = new Point(0, 177);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(128, 24);
            menuStrip2.TabIndex = 7;
            menuStrip2.Text = "menuStrip2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 199);
            Controls.Add(btnExit);
            Controls.Add(btnCalc);
            Controls.Add(txbTaxOwed);
            Controls.Add(txbTaxableIncome);
            Controls.Add(lblTaxOwed);
            Controls.Add(lblTaxableIncome);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Tax Calculator";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem taxScheduleToolStripMenuItem;
        private ToolStripMenuItem employeeIncomeToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem currentTaxScheduleToolStripMenuItem;
        private ToolStripMenuItem employeeTaxesToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveEmployeeTaxesToFileToolStripMenuItem;
        private Label lblTaxableIncome;
        private Label lblTaxOwed;
        private TextBox txbTaxableIncome;
        private TextBox txbTaxOwed;
        private Button btnCalc;
        private Button btnExit;
        private MenuStrip menuStrip2;
    }
}
