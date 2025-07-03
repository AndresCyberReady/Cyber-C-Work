using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;


namespace Cyber_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Designer initializes statusStrip1
            InitializeStatusLabels(); // Initialize labels after InitializeComponent
        }



        private BackgroundWorker worker;

        //private ToolStripStatusLabel timeScanLabel;
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                try
                {
                    Stopwatch stopwatch = Stopwatch.StartNew(); // Start timer
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);
                    long totalSize = 0;

                    // Clear UI elements
                    if (richTextBox1 != null)
                        richTextBox1.Clear();

                    if (fileCountLabel != null)
                        fileCountLabel.Text = $"File Count: {files.Length}";

                    if (scanStatusLabel != null)
                        scanStatusLabel.Text = $"Last Scan: {DateTime.Now:yyyy-MM-dd}";

                    if (fileSizeLabel != null)
                        fileSizeLabel.Text = "Total Size: Calculating...";

                    // Process files
                    foreach (string file in files)
                    {
                        try
                        {
                            totalSize += new FileInfo(file).Length;

                            using (var sha256 = SHA256.Create())
                            using (var stream = File.OpenRead(file))
                            {
                                byte[] hashBytes = sha256.ComputeHash(stream);
                                string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                                if (richTextBox1 != null)
                                    richTextBox1.AppendText($"{file}: {hash}{Environment.NewLine}");
                            }
                        }
                        catch (Exception ex)
                        {
                            if (richTextBox1 != null)
                                richTextBox1.AppendText($"Error processing {file}: {ex.Message}{Environment.NewLine}");
                        }
                    }

                    // Stop timer and update time label
                    stopwatch.Stop();
                    if (timeScanLabel != null)
                        timeScanLabel.Text = $"Time: {stopwatch.Elapsed.TotalSeconds:F2} seconds";

                    // Update file size label
                    if (fileSizeLabel != null)
                        fileSizeLabel.Text = $"Total Size: {FormatSize(totalSize)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Directory processing error: " + ex.Message);
                }
            }
        }



        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string folderPath = "C:\\Your\\Folder\\Path"; // Replace with your actual path
            string[] files = Directory.GetFiles(folderPath);

            for (int i = 0; i < files.Length; i++)
            {
                if ((sender as BackgroundWorker).CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                string file = files[i];
                try
                {
                    long fileSize = new FileInfo(file).Length;
                    using (var sha256 = SHA256.Create())
                    using (var stream = File.OpenRead(file))
                    {
                        byte[] hashBytes = sha256.ComputeHash(stream);
                        string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                        (sender as BackgroundWorker).ReportProgress(
                            (int)((i + 1) / (double)files.Length * 100),
                            new { File = file, Hash = hash, Size = fileSize });
                    }
                }
                catch (Exception ex)
                {
                    (sender as BackgroundWorker).ReportProgress(-1, new { Error = $"{file}: {ex.Message}" });
                }
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                richTextBox1.Invoke(new Action(() =>
                    richTextBox1.AppendText($"{e.UserState}\n")));
                return;
            }

            progressBar1.Invoke(new Action(() =>
                progressBar1.Value = e.ProgressPercentage));

            richTextBox1.Invoke(new Action(() =>
                richTextBox1.AppendText($"{e.UserState}\n")));

            if (e.ProgressPercentage == 100)
            {
                richTextBox1.Invoke(new Action(() =>
                    richTextBox1.AppendText("Scan complete.\n")));
            }
        }

        private void InitializeStatusLabels()
        {
            fileCountLabel = statusStrip1.Items["fileCountLabel"] as ToolStripStatusLabel;
            scanStatusLabel = statusStrip1.Items["scanStatusLabel"] as ToolStripStatusLabel;
            fileSizeLabel = statusStrip1.Items["fileSizeLabel"] as ToolStripStatusLabel;
            timeScanLabel = statusStrip1.Items["timeScanLabel"] as ToolStripStatusLabel;

            if (fileCountLabel == null || scanStatusLabel == null || fileSizeLabel == null || timeScanLabel == null)
            {
                MessageBox.Show("Status labels not found in statusStrip1. Add them in the designer.");
            }
        }

        // Helper method to format file size (e.g., 1.2 MB)
        private string FormatSize(long bytes)
        {
            const long KB = 1024;
            const long MB = KB * 1024;
            const long GB = MB * 1024;
            const long TB = GB * 1024;

            if (bytes >= TB) return $"{bytes / (double)TB:F2} TB";
            if (bytes >= GB) return $"{bytes / (double)GB:F2} GB";
            if (bytes >= MB) return $"{bytes / (double)MB:F2} MB";
            if (bytes >= KB) return $"{bytes / (1.0 * KB):F2} KB";

            return $"{bytes} B";
        }

        // Placeholder events
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        //private ToolStripStatusLabel timeScanLabel;

        private void button2_Click(object sender, EventArgs e)

        {
            richTextBox1.Clear();

            {
                if (progressBar1.InvokeRequired)
                {
                    progressBar1.Invoke(new Action(() => progressBar1.Value = 0));

                }
                else
                {
                    progressBar1.Value = 0;
                }

                if (worker != null && worker.IsBusy)
                {
                    worker.CancelAsync();
                }
            }
        }

        public void progressBar1_Click(object sender, EventArgs e)
        {
            if (fileCountLabel != null && scanStatusLabel != null && fileSizeLabel != null && timeScanLabel != null)
            {
                string fileCountText = fileCountLabel.Text;
                string lastScanText = scanStatusLabel.Text;
                string fileSizeText = fileSizeLabel.Text;
                string timeSizeText = timeScanLabel.Text;

                if (fileCountText.StartsWith("File Count:"))
                {
                    MessageBox.Show($"Total files processed: {fileCountText.Replace("File Count: ", "")}");
                }
                else if (lastScanText.StartsWith("Last Scan:"))
                {
                    MessageBox.Show($"Last scan: {lastScanText.Replace("Last Scan: ", "")}");
                }
                else if (fileSizeText.StartsWith("Total Size:"))
                {
                    MessageBox.Show($"Directory size: {fileSizeText.Replace("Total Size: ", "")}");
                }
                else if (timeSizeText.StartsWith("Time:"))
                {
                    MessageBox.Show($"Scan time: {timeSizeText.Replace("Time: ", "")}");
                }
                else
                {
                    MessageBox.Show("Unknown item clicked.");
                }
            }
            else
            {
                MessageBox.Show("Status labels not initialized. Check Designer.cs.");
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e) { }
    }
}