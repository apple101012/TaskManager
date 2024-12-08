using System.Diagnostics;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Dark mode settings
            this.BackColor = System.Drawing.Color.Black;

            // Configure DataGridView for dark mode
            dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            dataGridView1.ForeColor = System.Drawing.Color.White;
            dataGridView1.GridColor = System.Drawing.Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

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

            LoadRunningApplications();
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
    }
}
