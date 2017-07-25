# PermissionUtilityForUnity
Android Permission Utility for Unity


1. aar ファイルを Unity の Assets/Plugins/Android フォルダに置く。
2. AndroidManifest.xml に、使用するパーミッションを宣言しておき、同じく Android フォルダに置く。
3. unitypackage をプロジェクトにインポートする。
4. AndroidPermissionUtility.cs に書いてあるユーティリティクラスを使う。


unitypackage の中身は、AndroidPermissionUtility と AndroidPermission というふたつのクラス。

AndroidUtility.AndroidPermissionUtility クラスの
Request や IsPermitted を呼ぶことでパーミッションをリクエストしたり確認したりする。


  AndroidManifest.xml
    一度Android向けにプロジェクトをビルドすると、
    プロジェクトフォルダ/Temp/StagingArea に AndroidManifest.xml が作られるのでそれをコピーして使うと良い。
    Assets/Plugins/Android フォルダに置くことで Unity が使うものとマージされるらしい。


パーミッションの種類は AndroidUtility.AndroidPermission に列挙しておいた。


.xml は参考に置いただけ。
.java も参考に置いただけ( aar の中身)。

