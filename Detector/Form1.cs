using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Timers;

namespace Detector
{
    public partial class MainForm : Form
    {
        private List<FileSystemWatcher> watchers;
        private List<string> relaxedDirectories;
        private List<string> moderateDirectories;
        private List<string> directories;
        private System.Timers.Timer processTimer;
        private List<int> previousProcessIds;
        private HashSet<int> alertedProcessIds; // New set to keep track of alerted processes
        private string tempDirectoryPath;
        private string appDataPath;
        private string userProfilePath;
        private string localAppDataPath;


        public MainForm()
        {

            InitializeComponent();
            strictLabel.Hide();
            moderateLabel.Hide();
            tempDirectoryPath = Path.GetTempPath();
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            watchers = new List<FileSystemWatcher>();

            int value = strictnessModifier.Value;

            if (value == 0) // Relaxed
            {
                processTimer = new System.Timers.Timer(10000);
            }
            else if (value == 1) // Moderate
            {
                processTimer = new System.Timers.Timer(5000);
            }
            else if (value == 2) // Strict
            {
                processTimer = new System.Timers.Timer(1000);
            }
            else
            {
                this.Close();
            }

            relaxedDirectories = new List<string>
            {

                tempDirectoryPath,

            };

            moderateDirectories = new List<string>
            {

                localAppDataPath,
                tempDirectoryPath,
                appDataPath,

            };

            directories = new List<string>
            {
                // Default / Hardcoded Directories:

                localAppDataPath,
                appDataPath,
                tempDirectoryPath,
                Environment.SystemDirectory,
                Path.Combine(Environment.SystemDirectory, "Tasks"),
            };

            // Initialize watchers for hardcoded directories but do not enable them
            foreach (var dir in directories)
            {
                AddWatcher(dir, false);
                AddDirectoryToListView(dir); // Add to ListView
            }

            previousProcessIds = Process.GetProcesses().Select(p => p.Id).ToList();
            alertedProcessIds = new HashSet<int>(); // Initialize the set
            StartProcessTimer();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            stopDetectingButton.Visible = true;

            // Enable all watchers
            foreach (var watcher in watchers)
            {
                watcher.EnableRaisingEvents = true;
            }

            // Start process timer
            processTimer.Start();
        }

        private void stopDetectingButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = true;
            stopDetectingButton.Visible = false;

            StopWatching();
        }

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    directories.Add(selectedPath);
                    AddWatcher(selectedPath, !startButton.Visible); // Enable watcher only if detection is already started
                    AddDirectoryToListView(selectedPath); // Add to ListView
                }
            }
        }

        private void removeDirectoryButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    RemoveWatcher(selectedPath);
                    directories.Remove(selectedPath);
                    RemoveDirectoryFromListView(selectedPath); // Remove from ListView
                }
            }
        }

        private void AddWatcher(string path, bool enableImmediately)
        {
            if (!watchers.Any(w => w.Path == path))
            {
                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = path,
                    Filter = "*.*",
                    NotifyFilter = NotifyFilters.FileName,
                    EnableRaisingEvents = enableImmediately // Enable based on parameter
                };

                watcher.Created += OnChanged;
                watchers.Add(watcher);
            }
        }

        private void RemoveWatcher(string path)
        {
            var watcher = watchers.FirstOrDefault(w => w.Path == path);
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Created -= OnChanged;
                watcher.Dispose();
                watchers.Remove(watcher);
            }
        }

        private void StopWatching()
        {
            foreach (var watcher in watchers)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Created -= OnChanged;
            }

            // Stop process timer
            processTimer.Stop();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string extension = Path.GetExtension(e.FullPath).ToLower();
            if (extension == ".exe" || extension == ".scr" || extension == ".bat" || extension == ".ps1" || extension == ".dll" || extension == ".vbs")
            {
                // Add your logic here to handle the file creation event
                string message = $"File created: {e.FullPath}";
                string warningLevel = extension switch
                {
                    ".exe" => "Warning : High",
                    ".bat" => "Warning : High",
                    ".scr" => "Warning : Severe",
                    ".ps1" => "Warning : Severe",
                    ".dll" => "Warning : Moderate",
                    ".vbs" => "Warning : High",
                    _ => "Warning : Unknown"
                };

                MessageBox.Show(message, warningLevel, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddDirectoryToListView(string path)
        {
            ListViewItem item = new ListViewItem(path);
            directoryListView.Items.Add(item);
        }

        private void RemoveDirectoryFromListView(string path)
        {
            var item = directoryListView.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Text == path);
            if (item != null)
            {
                directoryListView.Items.Remove(item);
            }
        }

        private void StartProcessTimer()
        {
            int value = strictnessModifier.Value;

            if (value == 0) // Relaxed
            {
                processTimer = new System.Timers.Timer(10000);
            }
            else if (value == 1) // Moderate
            {
                processTimer = new System.Timers.Timer(5000);
            }
            else if (value == 2) // Strict
            {
                processTimer = new System.Timers.Timer(1000);
            }
            else
            {
                MessageBox.Show("How u get here?");
            }
            processTimer.Elapsed += OnProcessTimerElapsed;
            processTimer.AutoReset = true;
        }

        private void OnProcessTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var currentProcesses = Process.GetProcesses().ToList();
            var currentProcessIds = currentProcesses.Select(p => p.Id).ToList();

            // Find new processes
            var newProcesses = currentProcesses.Where(p => !previousProcessIds.Contains(p.Id)).ToList();

            foreach (var process in newProcesses)
            {
                try
                {
                    string executablePath = process.MainModule.FileName;
                    if (executablePath.StartsWith(tempDirectoryPath, StringComparison.OrdinalIgnoreCase) && !alertedProcessIds.Contains(process.Id))
                    {
                        string message = $"Process started from temp directory: {executablePath}";
                        MessageBox.Show(message, "Warning: High", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        alertedProcessIds.Add(process.Id); // Mark process as alerted
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, which can occur if accessing the MainModule property fails
                    Console.WriteLine($"Error accessing process {process.ProcessName}: {ex.Message}");
                }
            }

            // Update previous process IDs
            previousProcessIds = currentProcessIds;

            // Remove from alertedProcessIds those that are no longer running
            alertedProcessIds.RemoveWhere(pid => !currentProcessIds.Contains(pid));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void strictnessModifier_Scroll(object sender, EventArgs e)
        {
            int value = strictnessModifier.Value;

            if (value == 0) // Relaxed
            {
                relaxedLabel.Show();
                moderateLabel.Hide();
                strictLabel.Hide();
            }
            else if (value == 1) // Moderate
            {
                relaxedLabel.Hide();
                moderateLabel.Show();
                strictLabel.Hide();
            }
            else if (value == 2) // Strict
            {
                relaxedLabel.Hide();
                moderateLabel.Hide();
                strictLabel.Show();

            }
            else
            {
                MessageBox.Show("How u get here?");
            }
        }
    }
}
