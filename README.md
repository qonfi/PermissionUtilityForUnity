# PermissionUtilityForUnity
Android Permission Utility for Unity


1. aar ファイルを Unity の Assets/Plugins/Android フォルダに置く。
2. AndroidManifest.xml に、使用するパーミッションを宣言しておき、同じく Android フォルダに置く。
3. PermissionUtility.cs に書いてあるユーティリティクラスを使う。

AndroidUtility.PermissionUtility クラスの
Request や IsPermitted を呼ぶことでパーミッションをリクエストしたり確認したりする。

パーミッションの種類は AndroidUtility.Permission に列挙しておいた。

.java は参考に置いただけ。
