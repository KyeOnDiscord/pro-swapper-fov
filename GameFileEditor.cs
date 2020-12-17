using System;
using System.IO;
using System.Windows.Forms;
using ProSwapperFOV.Properties;
namespace ProSwapperFOV
{
    public static class GameFileEditor
    {
        public static string fndir
        {
            get
            {
                string defaultpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\FortniteGame\Saved\Config\WindowsClient\GameUserSettings.ini";
                if (File.Exists(defaultpath))
                {
                    return defaultpath;
                }
                else
                {
                    using (OpenFileDialog o = new OpenFileDialog())
                    {
                        o.Title = "Select your Fortnite GameUserSettings.ini";
                        o.Filter = "GameUserSettings.ini (*.ini*)|*.ini";
                        o.ShowDialog();

                        if (o.ShowDialog() == DialogResult.OK)
                        {
                            return o.FileName;
                        }
                        return "null";
                    }
                }
            }
        }
        private static string GameFile { get; set; }
        public static void SetRes(string YRes, string XRes)
        {
            try
            {
                GameFile = string.Empty;
                string line;
                using (StreamReader file = new StreamReader(Settings.Default.GameDir))
                {
                    while ((line = file.ReadLine()) != null)//Reads line one by one
                    {
                        if (line.StartsWith("LastConfirmedFullscreenMode="))
                        {
                            GameFile += "LastConfirmedFullscreenMode=2" + Environment.NewLine;
                            continue;
                        }
                        if (line.StartsWith("PreferredFullscreenMode="))
                        {
                            GameFile += "PreferredFullscreenMode=2" + Environment.NewLine;
                            continue;
                        }
                        if (line.StartsWith("LastConfirmedFullscreenMode="))
                        {
                            GameFile += "FullscreenMode=2" + Environment.NewLine;
                            continue;
                        }
                        //X Res
                        if (line.StartsWith("ResolutionSizeX="))
                        {
                            GameFile += "ResolutionSizeX=" + XRes + Environment.NewLine;
                            continue;
                        }
                        if (line.StartsWith("LastUserConfirmedResolutionSizeX="))
                        {
                            GameFile += "LastUserConfirmedResolutionSizeX=" + XRes + Environment.NewLine;
                            continue;
                        }

                        //Y Res
                        if (line.StartsWith("ResolutionSizeY="))
                        {
                            GameFile += "ResolutionSizeY=" + YRes + Environment.NewLine;
                            continue;
                        }
                        if (line.StartsWith("LastUserConfirmedResolutionSizeY="))
                        {
                            GameFile += "LastUserConfirmedResolutionSizeY=" + YRes + Environment.NewLine;
                            continue;
                        }
                        GameFile += line + Environment.NewLine;
                    }
                }
                    File.WriteAllText(Settings.Default.GameDir, GameFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pro Swapper FOV Changer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
