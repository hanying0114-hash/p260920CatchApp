using System.Runtime.InteropServices;   //[DllImport]
using System.Text;  //StringBuilder
namespace p260920CatchApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]   //Dll = Dynamic Link Library 動態連結程式庫
        private static extern IntPtr GetForegroundWindow(); 
        //IntPtr = pointer to an integer (指向整數的指標) 抓桌面身分證進來
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder appName, int size);
        string NewappName;
        private void button1_Click(object sender, EventArgs e)
        {
            catchAPP.Enabled = true;
        }
        private void catchAPP_Tick_1(object sender, EventArgs e)
        {
            IntPtr hWnd = GetForegroundWindow();    
            //hWnd = 前景視窗
            StringBuilder appName = new StringBuilder(256); 
            //appName = 新的字串建構器，容量256
            GetWindowText(hWnd, appName, appName.Capacity); 
            //根據hWnd抓取前景視窗的標題文字，放入appName
            if(NewappName != appName.ToString())    //防止洗版
            {
                NewappName = appName.ToString();
                label1.Text += $"{appName.ToString()}\n";
            }
        }
    }
}
