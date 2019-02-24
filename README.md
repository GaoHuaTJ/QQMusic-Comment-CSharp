# QQMusic-Comment-CSharp
QQ音乐评论爬虫C#版(安装chrome浏览器)
本项目主要是是利用selenium和chrome来爬取qq音乐的精彩评论
## 使用方法
主要使用到了：

![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4%E7%9A%84%E5%BC%95%E7%94%A8.jpg)

和

![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E8%A7%A3%E6%9E%90%E5%99%A8%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4.jpg)

分别在Nuget中添加如下的引用：

![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/nuget.jpg)



## 确保sqlserver的数据库设计如下：


![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E6%95%B0%E6%8D%AE%E5%BA%93%E7%BB%93%E6%9E%84.jpg)

### 为了方便项目的使用，将数据库上传（csv，excel，access版本）
1、 采用sql server首先新建一个数据库，叫做QQMusicComment
2、导入数据库（access版本）
![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E5%AF%BC%E5%85%A5%E6%95%B0%E6%8D%AE%E8%BF%87%E7%A8%8B.png)

![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E9%80%89%E6%8B%A9%E5%AF%BC%E5%85%A5%E5%BC%95%E6%93%8E.png)

![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E7%A1%AE%E8%AE%A4%E9%AA%8C%E8%AF%81%E6%96%B9%E5%BC%8F.png)

![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E5%AF%BC%E5%85%A5%E6%88%90%E5%8A%9F.png)

### 修改代码的数据库连接字符串
![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E4%BF%AE%E6%94%B9%E4%BB%A3%E7%A0%81%E7%9A%84%E6%95%B0%E6%8D%AE%E5%BA%93%E8%BF%9E%E6%8E%A5%E5%AD%97%E7%AC%A6%E4%B8%B2.png)

#### 数据库连接字符串的查看方法

 Visual Studio 工具=》数据库连接=》填入自己的服务器名=》
 
![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E8%BF%9E%E6%8E%A5%E5%AD%97%E7%AC%A6%E4%B8%B2%E6%9F%A5%E7%9C%8B.png)

![Image text](https://github.com/GaoHuaTJ/QQMusic-Comment-CSharp/blob/master/%E5%9B%BE%E7%89%87/%E5%A4%8D%E5%88%B6%E8%BF%9E%E6%8E%A5%E5%AD%97%E7%AC%A6%E4%B8%B2.png)

将上述的字符串对应修改即可


## 有问题可以联系作者（vx:15301768939 email:qidaxiang66@163.com）
