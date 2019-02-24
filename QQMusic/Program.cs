using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace QQMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化歌名类
            Song daoXiang = new Song();
            daoXiang.SingerName = "林俊杰";
            daoXiang.Name = "她说";
            daoXiang.NameUrl = "https://y.qq.com/n/yqq/song/0009n8YD3Nh2rR.html";
            var page=daoXiang.CreatDriver();//输出当前网址的源码
            var path=daoXiang.GetHtmlFold(page);//输出网页源码的txt地址
   
            //解析地址。数据储存
            HtmlParse htmlParse = new HtmlParse(daoXiang.Name,daoXiang.SingerName);
            htmlParse.GetContent(path);
        }
    } 
}
