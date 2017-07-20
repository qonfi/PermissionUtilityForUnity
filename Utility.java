package com.example.permissionutility;

/**
 * Created by Baker on 2017/07/15.
 */

import android.Manifest;
import android.annotation.TargetApi;
import android.app.Activity;
import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;

import com.unity3d.player.UnityPlayer;


public class Utility {


    /**
     * パーミッションの許可を求める。Unity から呼ぶことを想定している。
     * // @param permission android.Manifest.Permission から定数文字列を。直接 String を書く場合は "android.permission.ACCESS_FINE_LOCATION" などというように書く。
     * @return 関数がどんな風に終了したか、ログのようなものを返す。受け取らなくてもOK.
     */
    @TargetApi(23)                                      // コンパイルエラーが抑えられるだけで、実行回避はされない。
    public static String request(String permission){

        // 実行環境が Marshmallow 以前のバージョンの場合return
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.M) {
            return "The Request is only needed for Marshmallow or later";
        }

        // パーミッションを要求する。
        String[] s = new String[]{permission};
        Activity activity = UnityPlayer.currentActivity;
        activity.requestPermissions(s, 1);

        return "Finished";
    }



    /**
     * パーミッションの許可が降りているか確認する。 Unity から呼ぶことを想定している。
     * @param permission android.Manifest.Permission から定数文字列を。直接 String を書く場合は "android.permission.ACCESS_FINE_LOCATION" などというように書く。
     * @return
     */
    public static boolean isPermitted(String permission){

        // 実行環境が Marshmallow 以前のバージョンの場合はインストール後すでに権限が許可されている?
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.M) {
            return true;
        }

        // Activity と Context を取得。Unity のライブラリ? class.jar を使用している。
        Activity activity = UnityPlayer.currentActivity;
        Context context = activity.getApplicationContext();

        // テスト用
        permission = Manifest.permission.ACCESS_FINE_LOCATION;

        // サポートライブラリを使用しないパーミッション確認
        int result = context.checkCallingOrSelfPermission(permission);

        if (result == PackageManager.PERMISSION_GRANTED) {return true;}

        return false;
    }




    public static String test(){
        return "Test 13:12";
    }
}
