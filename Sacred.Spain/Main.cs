using System.Text;
using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Sacred.Spain
{
    public partial class Main : Form
    {
        private static string SACRED_FOLDER_PATH;

        public Main()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// Asegura que tenemos los ficheros de recursos necesarios e intenta obtener la ruta por defecto a la carpeta de instalación de Sacred
        /// Debería ser algo como \Program Files (x86)\Steam\steamapps\common\Sacred Gold
        /// </summary>
        public void Start()
        {
            SACRED_FOLDER_PATH = GetSteamInstallPath();
            this.tbFolderPath.Text = SACRED_FOLDER_PATH;
        }

        /// <summary>
        /// Intenta obtener la ruta de instalación de Steam por defecto
        /// </summary>
        /// <returns></returns>
        public static string? GetSteamInstallPath()
        {
            string steamPath = string.Empty;
            string sacredPath = "steamapps\\common\\Sacred Gold";
            try
            {
                // Intenta obtener la ruta desde el Registro de Windows
                steamPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", null) as string;
                if (string.IsNullOrEmpty(steamPath))
                {
                    steamPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", null) as string;
                }
                steamPath = Path.Combine(steamPath, sacredPath);
                return steamPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return steamPath;
        }

        private bool ValidateFolder()
        {
            //Ficheros que validan que estemos en la carpeta correcta
            string[] configFiles = { "Sacred.exe", "settings.cfg", /*No estoy seguro de si este es necesario siempre o solo con instalaciones de steam-> "steam_settings.cfg" */};

            foreach (string file in configFiles)
            {
                if (!Directory.Exists(SACRED_FOLDER_PATH) || !File.Exists(Path.Combine(SACRED_FOLDER_PATH, file)))
                {
                    MessageBox.Show("La carpeta seleccionada no contiene Sacred. Comprueba que tu carpeta contiene los ficheros: Sacred.exe,settings.cfg y las carpetas pak y scripts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            LogMessage("La carpeta de Sacred Gold es válida.");
            return true;
        }

        private void btSearchPath_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Selecciona una carpeta";
                    folderDialog.ShowNewFolderButton = false;

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        SACRED_FOLDER_PATH = folderDialog.SelectedPath;
                        ValidateFolder();
                        LogMessage($"Carpeta seleccionada: {SACRED_FOLDER_PATH}");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPatch_Click(object sender, EventArgs e)
        {
            if (!ValidateFolder())
            {
                return;
            }
            Patch();

        }
        /// <summary>
        /// Aplicamos los pasos descritos en 
        /// Traducción al Español - Sacred Gold por Raskaipika  y Wartinald     https://steamcommunity.com/sharedfiles/filedetails/?id=149413837
        /// </summary>
        private void Patch()
        {
            string[] configFiles = { "steam_settings.cfg", "settings.cfg" };

            //En primer lugar vamos a la carpeta de instalación de Sacred Gold
            foreach (var file in configFiles)
            {
                string filePath = Path.Combine(SACRED_FOLDER_PATH, file);

                LogMessage($"Aplicando parche a : {filePath}");
                //buscamos estos dos archivos, steam_settings.cfg y settings.cfg.

                if (File.Exists(filePath))
                {
                    //Ahora abrimos los dos archivos con el bloc de notas y buscamos esta línea en ambos:
                    //Language "US"
                    //y la sustituimos por
                    //Language "SP"
                    ReplaceLanguage(filePath);

                    LogMessage($"Fichero parcheado: {filePath}");
                }

            }


            // Una vez hecho esto, copiamos las carpetas pak y scripts además de Sacred.exe en el directorio principal de Sacred Gold
            string resourcePath = Path.Combine(Application.StartupPath, "Recursos");

            LogMessage($"Copiando recursos..");
            CopyResources(resourcePath, SACRED_FOLDER_PATH);
            MessageBox.Show("Traducción aplicada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Busca y reemplaza US por SP
        /// </summary>
        /// <param name="filePath"></param>
        private static void ReplaceLanguage(string filePath)
        {
            string content = File.ReadAllText(filePath);
            content = content.Replace("LANGUAGE : US", "LANGUAGE : SP");
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }
        /// <summary>
        /// Copia el directorio pak y script de los recursos de la aplicacion al directorio.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        private static void CopyResources(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("No se encontró la carpeta de Recursos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] itemsToCopy = { "pak", "scripts", "Sacred.exe" };

            foreach (var item in itemsToCopy)
            {

                string sourceItem = Path.Combine(sourcePath, item);
                string destinationItem = Path.Combine(destinationPath, item);

                if (Directory.Exists(sourceItem))
                {
                    CopyDirectory(sourceItem, destinationItem);
                }
                else if (File.Exists(sourceItem))
                {
                    File.Copy(sourceItem, destinationItem, true);
                }
            }
        }

        /// <summary>
        /// Metodo auxiliar para clonar directorios
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destinationDir"></param>
        private static void CopyDirectory(string sourceDir, string destinationDir)
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                string destDir = Path.Combine(destinationDir, Path.GetFileName(dir));
                CopyDirectory(dir, destDir);
            }
        }

        /// <summary>
        /// Loguea los mensajes
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        private void LogMessage(string message)
        {
            tbLogs.Invoke((MethodInvoker)delegate
            {
                tbLogs.SelectionStart = tbLogs.TextLength;
                tbLogs.SelectionLength = 0;
                tbLogs.AppendText($"{DateTime.Now:HH:mm:ss} - {message}\n");
                tbLogs.SelectionColor = tbLogs.ForeColor;
                tbLogs.ScrollToCaret();
            });
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

    }
}
