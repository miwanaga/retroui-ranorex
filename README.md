# RetroUID7 Ranorex UI tests

対象: C:\work\RetroUI\RetroUID7.exe。各ケースで新規プロセスを起動し、finallyでそのプロセスのみ終了します。既存のRetroUID7を終了してから実行してください。

## ビルドと実行
Ranorex 12.8.2（スナップショットの版）、.NET Framework 4.8 Developer Pack、MSBuildが必要です。

    msbuild RetroUID7Ranorex.csproj /p:RanorexBin="実際のRanorex StudioのBinフォルダー"
    bin\Debug\RetroUID7Ranorex.exe

終了コード0は全ケース成功、1は失敗です。標準出力に検証結果を記録します。これはRanorex APIを用いるコンソールプロジェクトであり、Studioの.rxtstスイートはまだありません。

## 機能と実装状況
- Initial: 初期表示、実行/中止状態、ポート、速度、オプション
- Methods: Serial/Modem/LAN切替、ポート、速度/パリティ有効状態
- Communication: 各方式で開始、中止キャンセル、中止確定、再開始、経過時間
- Options: ログ表示オプション、警告音設定、最大化/復元
- Dialogs: ヘルプ、待機中/通信中の終了キャンセル、通信中終了確定
- Common/UI.cs: セレクター、待機、検証、起動/後始末、開始/中止、確認応答

## 制約と残作業
この成果物は未ビルド・未実行の初期版です。完成した全機能テストとして扱わないでください。
D7版のRetroUIUnit.dfmはKaiで確認しましたが、RetroUIUnit.pasは全体/行単位とも文字コード変換エラーで取得できませんでした。Win10版の処理コードは参照できましたが、D7の期待値の確証にはなりません。
Ranorex/MSBuildの利用可能なインストールを確認できていません。
D7スナップショットには「Delphi version not supported」の制限が記録されています。controlname属性は取得されていますが、ライブ検索とダイアログのボタン文字列は実機検証が必要です。
未実装: 全速度選択、自由入力、方式固有の送受信ログと6行循環、進捗値、乱数による回線切断/再接続、途中の再接続設定変更、ログファイル内容/保存停止/外部ビューア起動/書込失敗、音声出力、ヘルプ本文、待機中終了確定、キーボード操作、全画面復元サイズ。ログテストを拡張する場合は既存ログの保護と復元が必要です。
Initial内のToggleは操作後状態の検証で、オプション初期値の厳密な検証ではありません。
スナップショットはC:\work\RetroUIRanorex\D7からコピーしました。元ファイルは変更していません。

## 2026-11-20 ソース再解析
D7版RetroUIUnit.pasを直接CP932で参照できました。上記の「取得できない」は解消しました。
D7固有の仕様はログがretroui_d7.log（CP932）、表示ログ最大4行、タイマー800ms、復元ClientWidth=400/ClientHeight=406です。通信方式の設定値は既存テストと一致します。
Initialを操作なしの初期チェック検証へ修正しました。Loggingテストを追加し、初期履歴、開始、中止、受信、保存停止、再有効化での履歴保存を検証します。既存ログはバイト単位で退避・復元します。
指定のranorex12-build-serverはこのセッションの公開ツール一覧に存在しません。コンパイルは未実行であり、ビルド成功とは扱いません。Studioスイート、再接続など上記の残作業は引き続き未完了です。
