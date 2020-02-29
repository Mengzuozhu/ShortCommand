using System.IO;
using System.Windows.Forms;

namespace ShortCommand.Class.Helper
{
    /// <summary>
    /// 文件和目录帮助类
    /// </summary>
    public class FileAndDirectoryHelper
    {
        /// <summary>
        /// 文件不存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool FileIsNotExists(string filePath)
        {
            return !File.Exists(filePath);
        }

        /// <summary>
        /// 是目录或文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsDirectoryOrFilePath(string path)
        {
            try
            {
                //不是绝对路径，则返回false
                if (!Path.IsPathRooted(path)) return false;

                string fullPath = Path.GetFullPath(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 目录或文件路径不存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool PathIsNotExists(string path)
        {
            return !PathIsExists(path);
        }

        /// <summary>
        /// 目录或文件路径存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool PathIsExists(string path)
        {
            return File.Exists(path) || Directory.Exists(path);
        }

        /// <summary>
        /// 是无效路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsInvalidPath(string path)
        {
            bool isDirectoryOrFilePath = IsDirectoryOrFilePath(path);
            //是文件或文件夹路径，但路径不存在
            return isDirectoryOrFilePath && PathIsNotExists(path);
        }

        /// <summary>
        /// 获取打开文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetFileDialogPath(string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = filter,
                Multiselect = false //不允许多个文件同时选择
            };
            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : string.Empty;
        }

        /// <summary>
        /// 打开.exe文件路径
        /// </summary>
        /// <returns></returns>
        public static string OpenExeFileDialog()
        {
            return GetFileDialogPath(@"(*.exe)|*.exe");
        }
    }
}
