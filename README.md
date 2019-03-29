# ShortCommand
封装Windows命令行，可使用自定义命令，打开文件、文件夹、网页，以及当轻量版搜索引擎使用  
# 主要功能
运行自定义的快捷命令可以直接：  
*  	调用Windows系统的cmd命令行  
*  	打开指定文件或文件夹  
*  	打开指定网页  
*  	当做轻量版搜索引擎使用，若输入的快捷命令不存在，则会使用百度（或谷歌）搜索该命令
*   当做网页地址栏使用，可直接输入网址，打开对应网页
 
# 配置说明
*  	命令/路径/网址：指定cmd命令行、文件路径、文件夹路径或网址。  
*  	快捷命令：用户自定义该命令，支持数字、字母、中文或特殊符号等等；在主界面输入并运行快捷命令，即可调用（打开）对应的命令/路径/网址。注：快捷命令忽略大小写，且保证唯一。  

# 使用示例  
*  	调用cmd命令行——在主界面输入框输入：task，按下回车键，即可打开任务管理器（命令行“taskmgr”）；  
*  	打开文件或者文件夹——输入：c，按下回车键，即可打开电脑C盘（文件夹路径“C:\”）；  
*  	打开指定网页——输入：百度，按下回车键，即可打开网页“http://www.baidu.com”  ；或直接在输入框输入网址，可直接打开网页。注：使用默认浏览器打开网页；   
 
# 其他说明
*  **使用快捷键Ctrl+E，即可显示或隐藏主界面；**   
*  	主界面的输入框支持自动补全、记录最近执行的5个快捷命令；  
*  	支持传参并打开指定程序，比如：  
  命令为："C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" "http://www.baidu.com"   
  自定义快捷命令为：用谷歌打开百度  
  则在主界面输入：用谷歌打开百度，就可以用谷歌浏览器打开百度主页；  
*  	支持拖拽文件或文件夹到表格中，添加对应路径到配置中；  
*  	显示重复的命令/路径/网址，方便查看或删除对应行；  
*  	清除无效路径，清除当前配置中无效的文件或文件夹路径；  
*  	查找功能（或快捷键Ctrl+F），查找文本在配置表格中的位置；  
*  	右键点击某行的行头，弹出右键菜单，可删除当前点击的行、修改当前行的文件或文件夹路径；  
*  	支持配置搜索引擎（百度或谷歌）、是否开机启动、程序是否置顶；  
*  	拷贝配置文件（config.xml）到其他电脑对应程序目录下，即可使用相同的快捷命令，注：有些路径可能会无效；  
*  	若需要退出程序，则需通过右下角的托盘右键菜单退出（或通过任务管理器）  


# 参考文档
Windows cmd命令行文档：https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/windows-commands
