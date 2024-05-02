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

[EN](../README.md) | [簡中](README_zh-CN.md) | [繁中](README_zh-CN.md) | [JP](README_ja-JP.md)

## 💡功能

- [√] **商店**
- [√] **編隊**
- [√] **抽卡** - 自定義概率: )
- [√] **戰鬥** - 場景技能中有一些錯誤
- [√] **場景** - 行走模擬器、交互、正確加載實體
- [√] **基本的角色培養** - 一些小bug，影響體驗不大
- [√] **任務** - 已完成男主的許多任務，若你選擇女主則可能會在某些任務中卡住，需要修復
- [-] **好友系統** - 開發中...
- [-] **模擬宇宙** - 開發中...

- [ ] **更多**  - Comming soon...

## 🍗使用&安裝

### 快速啟動

1. 在[Action](https://github.com/StopWuyu/DanhengServer/actions) 下載可執行文件
2. 打開下載完成的 `DanhengServer.zip` 解壓至任意文件夾 __*最好是英文路徑*__

> (可選) 在源代碼的WebServer文件夾中下載 `certificate.p12` 使得以HTTPS模式啟動 讓你的傳輸更安全: )

3. 運行GameServer.exe
4. 運行代理 啟動遊戲 鏈接，享受！

### 構建

Danhengserver使用Dotnet構建

**前置：**

- [.NET](https://dotnet.microsoft.com/)
- [Git](https://git-scm.com/downloads)

##### Windows

```shell
git clone --recurse-submodules https://github.com/StopWuyu/DanhengServer.git
cd DanhengServer
.\dotnet build # 編譯
```

## ❓幫助

- 支持安卓系統
- 100040119（無法自動完成）（使用 /mission finish 100040119 進行修復）

## ❕️故障排除

獲取常見問題的解決方案或尋求幫助，請加入[我們的Discord服務器](https://discord.gg/xRtZsmHBVj)

## 🙌鳴謝

- Weedwacker - 提供 kcp 實現
- [SqlSugar](https://github.com/donet5/SqlSugar) - 提供 ORM
- [LunarCore](https://github.com/Melledy/LunarCore) - 一些數據結構和算法
