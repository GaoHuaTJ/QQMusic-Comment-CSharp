using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;
using OpenQA.Selenium;

namespace QQMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            var url = "https://y.qq.com/n/yqq/song/002MXZNu1GToOk.html#comment_box";//网址
            chromeDriver.Navigate().GoToUrl(url);//登陆网址
            Thread.Sleep(5000);//等待网页加载完全


            var i = 0;
            while (true)
            {
                try
                {
                    var element = chromeDriver.FindElementByXPath("//*[@id=\"comment_box\"]/div[3]/div/div[2]/a");
                    element.Click();
                    Thread.Sleep(3000);//等待网页加载完全
                    Console.WriteLine("第{0}次点击",i.ToString());
                    i++;
                }
                catch
                {
                    break;
                }
             }
            IJavaScriptExecutor js = (IJavaScriptExecutor)chromeDriver;//页面滑倒最低端
            string title = (string)js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            var page = chromeDriver.PageSource;
            File.WriteAllText(Environment.CurrentDirectory + "\\周杰伦.txt", page);//网页写入txt文件
            HtmlParse htmlParse = new HtmlParse();
            htmlParse.GetContent(Environment.CurrentDirectory + "\\周杰伦.txt");
        }
    } 
}
