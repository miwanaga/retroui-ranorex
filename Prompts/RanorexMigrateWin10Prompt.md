https://github.com/miwanaga/retroui-ranorex.git の d13-modern ブランチに RetroUID13Modern アプリをテストするための Ranorex のテスト プロジェクトがあります。
Ranorexのバージョンは、Ranorex Studio 12.8.2です。
このテスト プロジェクトを、RetroUID13ModernからWin10コントロールを使用するように変更したアプリケーションである RetroUID13Win10 に対して実行できるように RetroUID13Win10 に対して行われた変更を Ranorexテスト プロジェクトに反映してください。
Ranorexテストコードは、GitHub 上のd13-modernブランチをもとに、d13-win10作成して作業してください。 チェックアウト先は、C:\work\RetroUID13Win10Ranorex とします。
ソースコードのフォーマットは適切に改行し、整形した状態にしてください。
改行コードはWindowsのCRLFを使用してください。
Ranorexのスナップショットはテストコードフォルダーの /Snapshots/D13Modern フォルダー以下にあります。形式はZIPです。
RetroUID13Win10.exe は C:\work\RetroUI 以下のものを実行するように指定してください。
Delphiプロジェクト外のファイルへのアクセスには、Kaiツールを使用しないでください。
上で記述したすべてのフォルダーへの読み書きを許可します。
また、GitHubへのプッシュも許可します。
Ranorexプロジェクトのビルドには、ranorex12-build-serverツールを使用してください。
ビルド結果は、ビルドサーバーのC:\work\RetroUID13Win10Ranorexにコピーしてください。
