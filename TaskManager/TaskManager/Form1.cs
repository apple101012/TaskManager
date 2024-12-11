using System.Diagnostics;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.BackgroundColor = System.Drawing.Color.CadetBlue; // Main background
            dataGridView1.GridColor = System.Drawing.Color.LightGray;       // Grid lines
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue; // Header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;     // Header text
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;              // Cell background
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;                  // Cell text
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MidnightBlue;  // Selected cell
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;         // Selected text

            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkOrange; // Background color for selected row
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;     // Text color for selected row
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue; // Background of row headers
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;    // Text color of row headers
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkOrange; // Highlight when selected
            dataGridView1.RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;     // Text color when selected
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave += DataGridView1_CellMouseLeave;
            dataGridView1.GridColor = System.Drawing.Color.Gray; // Subtle grid lines
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Single horizontal lines only
            dataGridView1.RowHeadersVisible = false;


            this.MinimumSize = new System.Drawing.Size(800, 600);
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            endBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRestartExplorer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.Resize += Form1_Resize;



            // Configure columns
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Process Name";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[1].Name = "Window Title";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[2].Name = "Process ID";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Load running applications on startup
            LoadRunningApplications();

            // Configure buttons
            btnRefresh.BackColor = System.Drawing.Color.DarkSlateGray;
            btnRefresh.ForeColor = System.Drawing.Color.White;

            endBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            endBtn.ForeColor = System.Drawing.Color.White;

            btnRestartExplorer.BackColor = System.Drawing.Color.DarkSlateGray;
            btnRestartExplorer.ForeColor = System.Drawing.Color.White;

            LoadRunningApplications();
        }

        private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ignore header cells
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        private void DataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ignore header cells
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Example: Adjust DataGridView size dynamically
            dataGridView1.Width = this.ClientSize.Width - 20; // Adjust for padding
            dataGridView1.Height = this.ClientSize.Height - 100; // Adjust for button space

            // Example: Reposition buttons
            btnRefresh.Location = new Point(this.ClientSize.Width - btnRefresh.Width - 20, this.ClientSize.Height - btnRefresh.Height - 20);
            btnRestartExplorer.Location = new Point(endBtn.Location.X - 120, endBtn.Location.Y);
            btnRestartExplorer.Size = new Size(100, 30); // Adjust as needed
            endBtn.Location = new Point(this.ClientSize.Width - endBtn.Width - 120, this.ClientSize.Height - endBtn.Height - 20);
        }



        private void LoadRunningApplications()
        {
            // Clear the DataGridView
            dataGridView1.Rows.Clear();

            // Get all running processes
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    // Only include processes with a window title (visible apps)
                    if (!string.IsNullOrEmpty(process.MainWindowTitle))
                    {
                        // Add process info to the DataGridView
                        dataGridView1.Rows.Add(process.ProcessName, process.MainWindowTitle, process.Id);
                    }
                }
                catch
                {
                    // Skip processes that can't be accessed
                }
            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRunningApplications();
        }

        private void endBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the selected process ID
                    int processId = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());

                    // Get the process and terminate it
                    Process process = Process.GetProcessById(processId);
                    process.Kill();

                    // Refresh the application list
                    LoadRunningApplications();
                }
                catch
                {
                    MessageBox.Show("Unable to terminate the process. It may require elevated permissions.");
                }
            }
            else
            {
                MessageBox.Show("Please select a process to terminate.");
            }
        }

        private void btnRestartExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                // Find all explorer.exe processes and kill them
                foreach (var process in Process.GetProcessesByName("explorer"))
                {
                    process.Kill();
                    process.WaitForExit(); // Wait for the process to exit
                }

                // Restart explorer.exe
                Process.Start("explorer.exe");

                MessageBox.Show("Explorer.exe has been restarted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while restarting explorer.exe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
