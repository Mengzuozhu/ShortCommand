using System.Windows.Forms;

namespace ShortCommand.ViewForm
{
    /// <summary>
    /// 容器窗口
    /// </summary>
    public class PanelForm : Form
    {
        protected bool IsLoaded;

        public PanelForm()
        {
            TopLevel = false;
        }

        /// <summary>
        /// 读取配置到窗口
        /// </summary>
        public virtual void ReadFormConfig()
        {
        }

        /// <summary>
        /// 更新窗口的配置
        /// </summary>
        public virtual void UpdateFormConfig()
        {
        }
    }
}