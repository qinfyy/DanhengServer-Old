# Danheng Server
**__此项目正在开发中!__**  
<p align="center">
<a href="https://visualstudio.com"><img src="https://img.shields.io/badge/Visual%20Studio-000000.svg?style=for-the-badge&logo=visual-studio&logoColor=white" /></a>
<a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/.NET-000000.svg?style=for-the-badge&logo=.NET&logoColor=white" /></a>
<a href="https://www.gnu.org/"><img src="https://img.shields.io/badge/GNU-000000.svg?style=for-the-badge&logo=GNU&logoColor=white" /></a>
</p>
<p align="center">
  <a href="https://discord.gg/xRtZsmHBVj"><img src="https://img.shields.io/badge/Discord%20Server-000000.svg?style=for-the-badge&logo=Discord&logoColor=white" /></a>
</p>

[EN](../README.md) | [簡中](README_zh-CN.md) [繁中](README_zh-CN.md)

## 功能
- 场景（行走模拟器、交互、正确加载实体）
- 朋友（开发中）
- 战斗（场景技能中有一些错误）
- 编队
- 模拟宇宙 (开发中)
- **Mission** （现在很多任务都可以执行了）（到第一个临时任务场景）（如果选择女主，可能会在某些任务中卡住 - 需要修复）
- 抽卡 (自定义概率)
- 商店
- 基本的角色培养(有一些bug)

## 如何使用？
- 在[Action](https://github.com/StopWuyu/DanhengServer/actions) 下载可执行文件 或 自行编译
- 解压到一个文件夹
- 将certificate.p12放入文件夹(在源码的WebServer文件夹内)
- 从此仓库下载Resources[DanhengServer_Resources](https://github.com/hell13579/DanHeng-RES)
- 在服务端目录下创建Resources文件夹 将下载的Resources解压进去
- 运行GameServer.exe

## 帮助
- 支持安卓系统
- 100040119（无法自动完成）（使用 /mission finish 100040119 进行修复）

## 鸣谢
- Weedwacker - 提供 kcp 实现
- [SqlSugar](https://github.com/donet5/SqlSugar) - 提供 ORM
- [LunarCore](https://github.com/Melledy/LunarCore) - 一些数据结构和算法
