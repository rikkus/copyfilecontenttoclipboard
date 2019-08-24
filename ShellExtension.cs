using System;
using System.Windows.Forms;

using Microsoft.Win32;

namespace CopyFileContentToClipboard
{
    public class ShellExtension
    {
        public static void Register
            (
            string fileType,
            string shellKeyName,
            string menuText,
            string menuCommand
            )
        {
            try
            {
                string regPath = string.Format(@"{0}\shell\{1}", fileType, shellKeyName);

                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(regPath))
                {
                    key.SetValue(null, menuText);
                }

                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(string.Format(@"{0}\command", regPath)))
                {
                    key.SetValue(null, menuCommand);
                }

                MessageBox.Show(string.Format("Registered extension handling '{0}'.", fileType), "Registered OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                    string.Format("Unable to register shell extension: {0}", ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        public static void Unregister(string fileType, string shellKeyName)
        {
            try
            {
                string regPath = string.Format(@"{0}\shell\{1}", fileType, shellKeyName);

                Registry.ClassesRoot.DeleteSubKeyTree(regPath);

                MessageBox.Show(string.Format("Unregistered extension handling '{0}'.", fileType), "Unregistered OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                    string.Format("Unable to unregister shell extension: {0}", ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
    }
}