using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Data.SqlClient;
namespace QQMusic
{
    /// <summary>
    /// html解析和数据库的连接
    /// </summary>
    class HtmlParse
    {
        public HtmlParse(string songName,string singerName)
        {
            _Song = songName;
            _SingerName = singerName;
        }
        string _Song;
        string _SingerName;
        public void GetContent(string path)//解析文本内容
        {
            var users= GetContents(path, "//h4[@class='comment__title']");
            var dates = GetContents(path, "//span[@class='comment__date c_tx_thin']");
            var comments = GetContents(path, "//p[@class='c_tx_normal comment__text js_hot_text']");
            var agree = GetContents(path, "//span[@class='js_praise_num']");

            for (int i = 0; i < users.Count; i++)
            {
                try
                {
                    string sql = string.Format("INSERT INTO dbo.{0}(歌名,用户名,评论,评论时间,赞)VALUES('{1}','{2}','{3}','{4}','{5}')",
                        _SingerName,
                        _Song,
                        users[i], 
                        comments[i], 
                        dates[i], 
                        agree[i]);
                    ConnectAccess(sql);
                }
                catch
                {continue;}
            }
            Console.ReadKey();
            }
        public List<string> GetContents(string path,string Xpath)//文本内容存入集合
        {
                List<string> Contents = new List<string> { };
                var htmlNodes = GetNodes(path, Xpath);
                if (htmlNodes != null)
                {
                    foreach (var item1 in htmlNodes)
                    {
                        var Content = item1.InnerText;
                        Contents.Add(Content);
                    }
                }
            return Contents;
        }
        public HtmlNodeCollection GetNodes(string path,string Xpath)//html节点集合
        {
            HtmlDocument html = new HtmlDocument();
            html.Load(path, Encoding.UTF8);//加载html文件
            HtmlNodeCollection htmlNodes = html.DocumentNode.SelectNodes(Xpath);
            return htmlNodes;
        }
        public void ConnectAccess(string Sql)//数据库连接和sql执行
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
