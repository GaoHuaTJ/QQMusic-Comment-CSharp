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
            if (IsExistTable(_SingerName))
            {
                Console.WriteLine("该数据表存在");
            }
            else
            {
                Console.WriteLine("数据库中没有表{0},已经新建表",_SingerName);
            }

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
                    ConnectAccess(sql,out SqlConnection sqlConnection);
                    Console.WriteLine("数据存储成功");
                }
                catch
                { continue; }
            }

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
        public SqlCommand ConnectAccess(string Sql,out  SqlConnection sqlConnection)//数据库连接和sql执行
        {
            string Conn = string.Format("Data Source=DESKTOP-49O35N0;Initial Catalog=C#练习使用;Integrated Security=True");
            sqlConnection = new SqlConnection(Conn);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(Sql, sqlConnection);
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
            return sqlCommand;//返回sql执行的数据库对象
        }
        public bool IsExistTable(string tableName)//判断C#练习数据库是否存在表名
        {
            var IsExistTableSql = string.Format("SELECT * FROM sys.tables WHERE name = '{0}'",tableName);
           var sqlCommand= ConnectAccess(IsExistTableSql,out SqlConnection  sqlConnection);
            sqlConnection.Open();
            if (Convert.ToInt16(sqlCommand.ExecuteScalar()) == 0)//如果不存在表的话
            {
                var sql = string.Format("CREATE TABLE {0}(歌名 VARCHAR(max) NULL,用户名 VARCHAR(max) NULL,评论 VARCHAR(max) NULL,评论时间 VARCHAR(max) NULL,赞 INT NULL)", _SingerName);//创建一个新的数据表
                ConnectAccess(sql,out SqlConnection sqlConnection1);
                Console.WriteLine("{0}数据表创建成功",_SingerName);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
