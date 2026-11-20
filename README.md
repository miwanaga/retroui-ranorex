# RetroUID7 Ranorex Test Suite

このtestsuiteブランチはRanorex Test Suite形式です。masterのコンソール形式から変更しています。

## 開く・ビルド・実行

Ranorex Studio 12.8.2でRetroUID7Ranorex.csprojを開き、RetroUID7Ranorex.rxtstを開いてください。既存のRanorex生成プロジェクト（C:\work\delphi-retro-app-test\RetroUITest）のスイート構造とビルド設定を参照しています。12.8.2の新規作成ウィザードを直接実行した成果物ではありません。

スイートのAllTests構成にInitial、Methods、Communication、Options、Logging、Dialogsの6ケースがあります。Studioで対象ケースを選択して実行できます。各ケースはModules以下のITestModuleを通して既存テストを呼び、共通のUI.Runで新規プロセスの起動とfinallyでの終了処理を行います。

Program.MainはTestSuiteRunner.Runを呼びます。Ranorex.MSBuild.Targetsによるブートストラップ用エントリーポイント生成を有効化しています。RootNamespaceはRetroTestsです。

対象アプリはC:\work\RetroUI\RetroUID7.exeです。既存の同名アプリを終了し、対話デスクトップで実行してください。

    msbuild RetroUID7Ranorex.csproj /p:Configuration=Debug
    bin\Debug\RetroUID7Ranorex.exe

Ranorexの場所が異なる場合は/p:RanorexBin="実際のStudioのBinフォルダー"を指定します。ビルドにはRanorex、MSBuild、.NET Framework 4.8 Developer Packが必要です。スイート定義は出力フォルダーにもコピーされます。

## スクリーンショット

プロジェクトルートのScreenshots/<実行日時_PID>/<テスト名>/に連番付きPNGを保存します。csprojのある親フォルダーを実行ファイルの場所から探すため、プロジェクト配下のbinから実行してください。共有フォルダーへコピーした実行ファイルだけではこのルート検索は成立しません。
初期画面、クリック後、オプション変更後、確認応答前、完了、失敗時に全モニターを撮影します。対象アプリを前面に置いてください。目視確認用でありレイアウトを自動判定しません。PNGはGit対象外です。

## 検証範囲と残作業

Ranorex12ビルドサーバーでRanorex固有のエントリーポイント生成を含むビルド成功を確認しました。Studioの画面でのロード、モジュール認識、選択実行、実際のUIテスト実行は未確認です。

D7ソースはCP932で解析済みです。ログ保存先はretroui_d7.log、表示は最大4行、タイマーは800msです。Loggingは既存ログをバイト単位で退避・復元します。
スナップショットにはDelphi version not supportedの制限が記録されています。controlnameによるライブ検索やダイアログ文字列は実機検証が必要です。
未実装の主な検証は全速度選択、自由入力、方式固有ログと4行循環、進捗範囲、自動再接続、途中設定変更、ログ外部ビューアと書込失敗、音声出力、ヘルプ本文、待機中終了確定、キーボード操作、復元クライアントサイズです。テストスイート化はこれらの網羅性を追加するものではありません。

ビルド成果物のコピー先:
\\laptop-an963npk\data\work\services\Ranorex\build\RetrroUID7
