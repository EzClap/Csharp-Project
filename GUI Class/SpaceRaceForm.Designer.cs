namespace GUI_Class
{
    partial class SpaceRaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.stepNo = new System.Windows.Forms.RadioButton();
            this.stepYes = new System.Windows.Forms.RadioButton();
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.playerTokenImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rocketFuelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playerLabel = new System.Windows.Forms.Label();
            this.numOfPlayerLabel = new System.Windows.Forms.Label();
            this.playerNumDrop = new System.Windows.Forms.ComboBox();
            this.rollButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.SpaceRaceLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox);
            this.splitContainer1.Panel2.Controls.Add(this.playersDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.playerLabel);
            this.splitContainer1.Panel2.Controls.Add(this.numOfPlayerLabel);
            this.splitContainer1.Panel2.Controls.Add(this.playerNumDrop);
            this.splitContainer1.Panel2.Controls.Add(this.rollButton);
            this.splitContainer1.Panel2.Controls.Add(this.resetButton);
            this.splitContainer1.Panel2.Controls.Add(this.SpaceRaceLabel);
            this.splitContainer1.Panel2.Controls.Add(this.exitButton);
            this.splitContainer1.Size = new System.Drawing.Size(1179, 814);
            this.splitContainer1.SplitterDistance = 884;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 8;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(884, 814);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox.Controls.Add(this.stepNo);
            this.groupBox.Controls.Add(this.stepYes);
            this.groupBox.Enabled = false;
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(84, 517);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(140, 55);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Single Step?";
            this.groupBox.Enter += new System.EventHandler(this.groupBox_Enter);
            // 
            // stepNo
            // 
            this.stepNo.AutoSize = true;
            this.stepNo.Location = new System.Drawing.Point(85, 28);
            this.stepNo.Name = "stepNo";
            this.stepNo.Size = new System.Drawing.Size(49, 21);
            this.stepNo.TabIndex = 1;
            this.stepNo.TabStop = true;
            this.stepNo.Text = "No";
            this.stepNo.UseVisualStyleBackColor = true;
            this.stepNo.Click += new System.EventHandler(this.stepNo_Click);
            // 
            // stepYes
            // 
            this.stepYes.AutoSize = true;
            this.stepYes.Location = new System.Drawing.Point(9, 28);
            this.stepYes.Name = "stepYes";
            this.stepYes.Size = new System.Drawing.Size(56, 21);
            this.stepYes.TabIndex = 0;
            this.stepYes.TabStop = true;
            this.stepYes.Text = "Yes";
            this.stepYes.UseVisualStyleBackColor = true;
            this.stepYes.Click += new System.EventHandler(this.stepYes_Click);
            // 
            // playersDataGridView
            // 
            this.playersDataGridView.AllowUserToAddRows = false;
            this.playersDataGridView.AllowUserToDeleteRows = false;
            this.playersDataGridView.AutoGenerateColumns = false;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerTokenImageDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.rocketFuelDataGridViewTextBoxColumn});
            this.playersDataGridView.DataSource = this.playerBindingSource;
            this.playersDataGridView.Location = new System.Drawing.Point(14, 197);
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.RowHeadersVisible = false;
            this.playersDataGridView.RowTemplate.Height = 24;
            this.playersDataGridView.Size = new System.Drawing.Size(263, 228);
            this.playersDataGridView.TabIndex = 7;
            // 
            // playerTokenImageDataGridViewImageColumn
            // 
            this.playerTokenImageDataGridViewImageColumn.DataPropertyName = "PlayerTokenImage";
            this.playerTokenImageDataGridViewImageColumn.HeaderText = "";
            this.playerTokenImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.playerTokenImageDataGridViewImageColumn.Name = "playerTokenImageDataGridViewImageColumn";
            this.playerTokenImageDataGridViewImageColumn.ReadOnly = true;
            this.playerTokenImageDataGridViewImageColumn.Width = 20;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 80;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Square";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.ReadOnly = true;
            this.positionDataGridViewTextBoxColumn.Width = 50;
            // 
            // rocketFuelDataGridViewTextBoxColumn
            // 
            this.rocketFuelDataGridViewTextBoxColumn.DataPropertyName = "RocketFuel";
            this.rocketFuelDataGridViewTextBoxColumn.HeaderText = "Fuel";
            this.rocketFuelDataGridViewTextBoxColumn.Name = "rocketFuelDataGridViewTextBoxColumn";
            this.rocketFuelDataGridViewTextBoxColumn.ReadOnly = true;
            this.rocketFuelDataGridViewTextBoxColumn.Width = 50;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(Object_Classes.Player);
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.Location = new System.Drawing.Point(89, 162);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(117, 32);
            this.playerLabel.TabIndex = 6;
            this.playerLabel.Text = "Players";
            // 
            // numOfPlayerLabel
            // 
            this.numOfPlayerLabel.AutoSize = true;
            this.numOfPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfPlayerLabel.Location = new System.Drawing.Point(40, 98);
            this.numOfPlayerLabel.Name = "numOfPlayerLabel";
            this.numOfPlayerLabel.Size = new System.Drawing.Size(148, 18);
            this.numOfPlayerLabel.TabIndex = 5;
            this.numOfPlayerLabel.Text = "Number of Players";
            // 
            // playerNumDrop
            // 
            this.playerNumDrop.FormattingEnabled = true;
            this.playerNumDrop.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.playerNumDrop.Location = new System.Drawing.Point(208, 97);
            this.playerNumDrop.Name = "playerNumDrop";
            this.playerNumDrop.Size = new System.Drawing.Size(40, 24);
            this.playerNumDrop.TabIndex = 4;
            this.playerNumDrop.Text = "6";
            this.playerNumDrop.SelectedIndexChanged += new System.EventHandler(this.playerNumDrop_SelectedIndexChanged);
            // 
            // rollButton
            // 
            this.rollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollButton.Location = new System.Drawing.Point(106, 734);
            this.rollButton.Margin = new System.Windows.Forms.Padding(4);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(100, 28);
            this.rollButton.TabIndex = 3;
            this.rollButton.Text = "Roll Dice";
            this.rollButton.UseCompatibleTextRendering = true;
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(37, 771);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(108, 27);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Game Reset";
            this.resetButton.UseCompatibleTextRendering = true;
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // SpaceRaceLabel
            // 
            this.SpaceRaceLabel.AutoSize = true;
            this.SpaceRaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpaceRaceLabel.Location = new System.Drawing.Point(56, 32);
            this.SpaceRaceLabel.Name = "SpaceRaceLabel";
            this.SpaceRaceLabel.Size = new System.Drawing.Size(179, 32);
            this.SpaceRaceLabel.TabIndex = 1;
            this.SpaceRaceLabel.Text = "Space Race";
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(159, 770);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 28);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(113, 691);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SpaceRaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 814);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpaceRaceForm";
            this.Text = "Space Race";
            this.Load += new System.EventHandler(this.SpaceRaceForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton stepNo;
        private System.Windows.Forms.RadioButton stepYes;
        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label numOfPlayerLabel;
        private System.Windows.Forms.ComboBox playerNumDrop;
        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label SpaceRaceLabel;
        private System.Windows.Forms.DataGridViewImageColumn playerTokenImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rocketFuelDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}

