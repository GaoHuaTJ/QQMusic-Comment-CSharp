using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Data.SqlClient;
namespace QQMusic
{
    class HtmlParse
    {


        public void GetContent(string path)
        {
            var users= GetContents(path, "//h4[@class='comment__title']");
            var dates = GetContents(path, "//span[@class='comment__date c_tx_thin']");
            var comments = GetContents(path, "//p[@class='c_tx_normal comment__text js_hot_text']");
            var agree = GetContents(path, "//span[@class='js_praise_num']");

            for (int i = 0; i < users.Count; i++)
            {
                try
                {
                    string sql = string.Format("INSERT INTO dbo.不能说的秘密(ID, 用户名,评论,评论时间,赞)VALUES({0},'{1}','{2}','{3}','{4}')", i, users[i], comments[i], dates[i], agree[i]);
                    ConnectAccess(sql);
                }
                catch
                {break;}
            }
            Console.ReadKey();
    
            }
        public List<string> GetContents(string path,string Xpath)
        {
                List<string> Contents = new List<string> { };
                var htmlNodes = GetNodes(path, Xpath);
                if (htmlNodes != null)
                {
                    foreach (var item1 in htmlNodes)//检索评论
                    {
                        var Content = item1.InnerText;
                        Contents.Add(Content);
                    }
                }
            return Contents;
        }
        public HtmlNodeCollection GetNodes(string path,string Xpath)
        {
            HtmlDocument html = new HtmlDocument();
            html.Load(path, Encoding.UTF8);//加载html文件
            HtmlNodeCollection htmlNodes = html.DocumentNode.SelectNodes(Xpath);
            return htmlNodes;
        }
        public void ConnectAccess(string Sql)
        {
            string Conn = string.Format("Data Source=DESKTOP-49O35N0;Initial Catalog=C#练习使用;Integrated Security=True");
            SqlConnection sqlConnection = new SqlConnection(Conn);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(Sql, sqlConnection);
            sqlCommand.ExecuteReader();
            Console.WriteLine("数据存储成功");
        }
    }
}
