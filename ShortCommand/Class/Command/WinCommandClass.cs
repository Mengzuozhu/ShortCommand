using System;
using System.Diagnostics;

namespace ShortCommand.Class.Command
{
    /// <summary>
    /// 系统命令行
    /// </summary>
    public class WinCommandClass
    {
        private static string errorInfo;

        /// <summary>
        /// 在cmd中执行指定命令行，执行完后关闭cmd
        /// </summary>
        /// <param name="commandLine"></param>
        public static string RunCommandLineInCmdAndExitCmd(string commandLine)
        {
            errorInfo = null;
            var process = GetCmdProcess();
            try
            {
                process.Start(); //启动程序

                //写入命令，并退出
                process.StandardInput.WriteLine(commandLine + "&Exit");
                process.StandardInput.AutoFlush = true;
                process.ErrorDataReceived += ProcessOnErrorDataReceived;
                process.BeginErrorReadLine();
                process.WaitForExit(50); //在50毫秒内退出
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                process.Dispose();
            }

            return errorInfo;
        }

        /// <summary>
        /// 异步读取错误信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                errorInfo = e.Data;
            }
        }

        /// <summary>
        /// 获取cmd.exe进程
        /// </summary>
        /// <returns></returns>
        private static Process GetCmdProcess()
        {
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false, //不使用shell启动
                    RedirectStandardInput = true, //接受调用程序的输入信息
                    RedirectStandardOutput = true, //调用程序获取输出信息
                    RedirectStandardError = true, //重定向标准错误输出
                    CreateNoWindow = true //不显示程序窗口
                }
            };
            return process;
        }
    }
}
