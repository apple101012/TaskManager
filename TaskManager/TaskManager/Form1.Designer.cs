namespace TaskManager
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
            dataGridView1 = new DataGridView();
            btnRefresh = new Button();
            endBtn = new Button();
            btnRestartExplorer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.CadetBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(796, 333);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(12, 398);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // endBtn
            // 
            endBtn.Location = new Point(118, 398);
            endBtn.Name = "endBtn";
            endBtn.Size = new Size(116, 23);
            endBtn.TabIndex = 2;
            endBtn.Text = "End Process";
            endBtn.UseVisualStyleBackColor = true;
            endBtn.Click += endBtn_Click;
            // 
            // btnRestartExplorer
            // 
            btnRestartExplorer.AccessibleName = "";
            btnRestartExplorer.Location = new Point(261, 398);
            btnRestartExplorer.Name = "btnRestartExplorer";
            btnRestartExplorer.Size = new Size(139, 23);
            btnRestartExplorer.TabIndex = 3;
            btnRestartExplorer.Text = "Restart Explorer";
            btnRestartExplorer.UseVisualStyleBackColor = true;
            btnRestartExplorer.Click += btnRestartExplorer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRestartExplorer);
            Controls.Add(endBtn);
            Controls.Add(btnRefresh);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Simple Task Manager";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnRefresh;
        private Button endBtn;
        private Button btnRestartExplorer;
    }
}
