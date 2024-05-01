# Danheng Server
**__此項目正在開發中!__**  
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
- 場景（行走模擬器、交互、正確加載實體）
- 朋友（開發中）
- 戰鬥（場景技能中有一些錯誤）
- 編隊
- 模擬宇宙 (開發中)
- **Mission** （現在很多任務都可以執行了）（到第一個臨時任務場景）（如果選擇女主，可能會在某些任務中卡住 - 需要修復）
- 抽卡 (自定義概率)
- 商店
- 基本的角色培養(有一些bug)

## 如何使用？
- 在[Action](https://github.com/StopWuyu/DanhengServer/actions) 下載可執行文件 或 自行編譯
- 解壓到一個文件夾
- 將certificate.p12放入文件夾(在源碼的WebServer文件夾內)
- 從此倉庫下載Resources[DanhengServer_Resources](https://github.com/hell13579/DanHeng-RES)
- 在服務端目錄下創建Resources文件夾 將下載的Resources解壓進去
- 運行GameServer.exe

## 幫助
- 支持安卓系統
- 100040119（無法自動完成）（使用 /mission finish 100040119 進行修復）

## 鳴謝
- Weedwacker - 提供 kcp 實現
- [SqlSugar](https://github.com/donet5/SqlSugar) - 提供 ORM
- [LunarCore](https://github.com/Melledy/LunarCore) - 一些數據結構和算法
