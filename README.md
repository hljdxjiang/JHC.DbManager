# JHC.DbManager

Net Core 中使用 Dapper 封装数据操作库 ##初始版本说明。
初始版本完全参考博客的内容，[Net Core 中使用 Dapper 封装数据操作库](https://blog.csdn.net/qq_34532187/article/details/85317926?utm_medium=distribute.pc_relevant.none-task-blog-BlogCommendFromMachineLearnPai2-3.nonecase&depth_1-utm_source=distribute.pc_relevant.none-task-blog-BlogCommendFromMachineLearnPai2-3.nonecase)
本内容位于原作者取得联系，如有侵权，请联系，我会尽快删除源代码。

##对初版的感悟及代码计划。
1、本人初学.net core。对 IOC 和 DI 感悟不是很深。本段代码计划作为后续项目中数据库框架使用。
2、查看源代码。感觉作者每次读取数据库都会 new 一个数据库连接(不知道这个感悟对不对，请指正)。dapper 对数据库连接池的优化已经很到位。本人计划小幅修改，让其每次直接获取数据库。
3、本人计划修改为支持多库连接，支持读写分离。让代码编写者根据需求选择数据库。
4、未来长远打算。支持数据库热切换，主机连接超时直接查询备机。

##项目进展及声明
1、目前项目只测试了 mysql 数据库，oracle 及 sqlite mssql(原作者好像测试过了)没有进行测试
2、本项目为开源项目，生产使用请慎重，如对贵项目造成不可逆转的损失，本人概不负责。
3、本项目版权:版权没有，翻版不究！！！！
