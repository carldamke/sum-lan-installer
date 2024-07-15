using System;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace sum_lan_installer
{
    public partial class Form1 : Form
    {
        private string NetworkPath = @"\\LAN-SHARE\shared\SuM\Files";
        private const string RegistryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Patch 2.22 Launcher_is1";
        private const string RegistryValueName = "InstallLocation";
        private string gameSelection;

        public Form1()
        {
            InitializeComponent();

            ShowGameSelectionDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string localFolderPath = GetLocalFolderPathFromRegistry();
            if (string.IsNullOrEmpty(localFolderPath))
            {
                if (SelectLocalFolder(out localFolderPath))
                {
                    // Manuelle Auswahl
                }
                else
                {
                    MessageBox.Show("Kein Zielordner ausgewählt. Programm wird beendet.");
                    Application.Exit();
                }
            }
            else
            {
                if (!Directory.Exists(Path.Combine(localFolderPath, "Downloads")))
                {
                    Directory.CreateDirectory(Path.Combine(localFolderPath, "Downloads"));
                }

                localFolderPath = Path.Combine(localFolderPath, "Downloads", gameSelection);
            }

            DownloadFiles(Path.Combine(NetworkPath, gameSelection), localFolderPath);
        }

        private void ShowGameSelectionDialog()
        {
            using (Form2 gameSelectionForm = new Form2())
            {
                if (gameSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    gameSelection = gameSelectionForm.SelectedGame;
                }
                else
                {
                    MessageBox.Show("Keine Auswahl getroffen. Programm wird beendet.");
                    Application.Exit();
                }
            }
        }

        private string GetLocalFolderPathFromRegistry()
        {
            string installLocation = GetRegistryValue(RegistryView.Registry64);
            if (string.IsNullOrEmpty(installLocation))
            {
                installLocation = GetRegistryValue(RegistryView.Registry32);
            }

            if (!string.IsNullOrEmpty(installLocation))
            {
                return installLocation;
            }

            MessageBox.Show("Keine lokale 2.22-Launcher Installation gefunden!");
            return null;
        }

        private string GetRegistryValue(RegistryView view)
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
                using (RegistryKey key = baseKey.OpenSubKey(RegistryKeyPath))
                {
                    if (key != null)
                    {
                        string value = key.GetValue(RegistryValueName) as string;
                        if (!string.IsNullOrEmpty(value))
                        {
                            MessageBox.Show($"Gefundene Installation in Registry {view}: {value}");
                            return value;
                        }
                        else
                        {
                            MessageBox.Show($"InstallLocation-Eintrag nicht gefunden oder leer in: {RegistryKeyPath}, {view}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Registry-Schlüssel nicht gefunden: {RegistryKeyPath} in {view}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Zugriff auf die Registry ({view}): {ex.Message}");
            }
            return null;
        }

        private bool SelectLocalFolder(out string path)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Wählen Sie den lokalen Zielordner aus";
                dialog.ShowNewFolderButton = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    return true;
                }
            }
            path = null;
            return false;
        }

        private async void DownloadFiles(string networkPath, string localFolderPath)
        {
            try
            {
                Directory.CreateDirectory(localFolderPath);
                var files = Directory.GetFiles(networkPath);
                progressBar.Maximum = files.Length;
                progressBar.Value = 0;

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);
                    string destFilePath = Path.Combine(localFolderPath, fileName);
                    File.Copy(filePath, destFilePath, true);
                    progressBar.Value += 1;
                    statusLabel.Text = $"Status: {fileName} heruntergeladen.";
                    await Task.Delay(100);
                }

                MessageBox.Show("Alle Dateien wurden erfolgreich heruntergeladen.");
                statusLabel.Text = "Status: Alle Dateien wurden erfolgreich heruntergeladen.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Herunterladen der Dateien: {ex.Message}");
                statusLabel.Text = "Status: Fehler beim Herunterladen.";
            }
        }
    }
}
