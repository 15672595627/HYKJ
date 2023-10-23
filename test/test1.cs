using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.test
{
    public partial class test1 : Form
    {
        public test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "HaHa");
            dic.Add(5, "HoHo");
            dic.Add(3, "HeHe");
            dic.Add(2, "HiHi");
            dic.Add(4, "HuHu1");
            dic[4] = "HuHu"; // 保存数据，key有就覆盖 没有就新增
            //dic.Add(4, "HuHu"); // 如果存在会异常
            var value = dic[4]; //获取数据 没有会异常的
            var result = dic.ContainsKey(4); // 检查是否存在
            foreach (var item in dic)
            {
                Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
            }
            Dictionary<string, string> dictExecutes = new Dictionary<string, string>();

            // 添加元素
            dictExecutes.Add("bmp", "paint.exe");
            dictExecutes.Add("dib", "paint.exe");
            dictExecutes.Add("rtf", "wordpad.exe");
            dictExecutes.Add("txt", "notepad.exe");
            Console.WriteLine("For key = 'rtf', value = {0}.", dictExecutes["rtf"]);

            dictExecutes["rtf"] = "winword.exe";
            Console.WriteLine("For key = 'rtf', value = {0}.", dictExecutes["rtf"]);

            foreach (string key in dictExecutes.Keys) Console.WriteLine("Key = {0}", key);

            var dictionary = new ConcurrentDictionary<string, int>();

            // 向字典中添加一些元素
            dictionary.TryAdd("One", 1);
            dictionary.TryAdd("Two", 2);
            dictionary.TryAdd("Three", 3);

            // 尝试获取一个元素
            if (dictionary.ContainsKey("Two"))
            {
                Console.WriteLine($"Value for 'Two': {dictionary["Two"]}");
            }
            else
            {
                Console.WriteLine("Key 'Two' not found.");
            }
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
        }
    }
}
