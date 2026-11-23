https://github.com/miwanaga/retroui-ranorex.git に RetroUID7 アプリをテストするための Ranorex のテスト プロジェクトがあります。
Ranorexのバージョンは、Ranorex Studio 12.8.2です。
このテスト プロジェクトを、RetroUID7からマイグレートしたアプリケーションである RetroUID13Modern に対して実行できるようにRetroUID13Modernに対して行われた変更を Ranorexテスト プロジェクトに反映してください。
Ranorexテストコードは、GitHub 上にd13-modernブランチを作成して作業してください。 チェックアウト先は、C:\work\RetroUID13ModernRanorex とします。
ソースコードのフォーマットは適切に改行し、整形した状態にしてください。
改行コードはWindowsのCRLFを使用してください。
Ranorexのスナップショットはテストコードフォルダーの /Snapshots/D13Modern フォルダー以下にあります。形式はZIPです。
RetroUID13Modern.exe は C:\work\RetroUI 以下のものを実行するように指定してください。
Delphiプロジェクト外のファイルへのアクセスには、Kaiツールを使用しないでください。
上で記述したすべてのフォルダーへの読み書きを許可します。
また、GitHubへのプッシュも許可します。
Ranorexプロジェクトのビルドには、ranorex12-build-serverツールを使用してください。