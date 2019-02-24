using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace QQMusic
{
    class Song
    {
        public string Name { set; get; }//歌名属性
        public string NameUrl { set; get; }//网址属性
        public string SingerName { set; get; }//歌手名属性，在数据库直接作为表名使用


        /// <summary>
        /// 输入网址，返回当前网址的源码
        /// </summary>
        /// <param name="NameUrl">当前网址</param>
        /// <returns></returns>
        public string CreatDriver()//输入网址，返回的是当前网址的源码
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl(NameUrl);//登陆网址
            Thread.Sleep(5000);//等待网页加载完全
            var i = 0;
            while (true)
            {
                try
                {
                    var element = chromeDriver.FindElementByXPath("//*[@id=\"comment_box\"]/div[3]/div/div[2]/a");
                    element.Click();
                    Thread.Sleep(3000);//等待网页加载完全
                    Console.WriteLine("第{0}次点击", i.ToString());
                    i++;
                }
                catch
                {
                    Console.WriteLine("加载完毕");
                    break;
                }
            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)chromeDriver;//页面滑倒最低端
            string title = (string)js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            var page = chromeDriver.PageSource;
            return page;
        }


        /// <summary>
        /// 将html字符串写入txt
        /// 输出txt的地址
        /// </summary>
        /// <returns></returns>
        public string GetHtmlFold(string page)//输出html的本地地址
        {
            string TxtPath =string.Format( Environment.CurrentDirectory + "\\{0}.txt",Name);
            Console.WriteLine(TxtPath);
            File.WriteAllText(TxtPath, page);//网页写入txt文件
            Console.WriteLine("网页写入完毕");
            return TxtPath;
        }
    }
}
