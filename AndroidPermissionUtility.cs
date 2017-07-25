using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using System;


namespace AndroidUtility
{
    public class AndroidPermissionUtility
    {
        /// <summary>
        /// java 側に問い合わせてパーミッション許可のリクエストを出す。
        /// AndroidManifest.xml にパーミッション使用の宣言も必要。宣言されていないものをリクエストすると例外が出る。
        /// </summary>
        /// <param name="permission"></param>
        public static void Request(PermissionKey permission)
        {
            if (Application.platform != RuntimePlatform.Android) { return; }
            //if (IsPermitted(permission)) { return; }

            string className = AndroidPermission.UtilityClassName;
            string methodName = AndroidPermission.RequestMethodName;
            string permissionName = AndroidPermission.Permissions[permission];

            AndroidJavaObject javaObject = new AndroidJavaObject(className);
            string result = javaObject.CallStatic<string>(methodName, permissionName);
            Debug.Log(result);
            
        }


        /// <summary>
        /// java 側に問い合わせて、パーミッションの許可が降りているかどうか確認する。
        /// Android OS のバージョンが Marshmallow 以前か、実行環境がAndroid 以外の場合にも true を返す。
        /// </summary>
        /// <param name="permission"></param>
        /// <returns> </returns>
        public static bool IsPermitted(PermissionKey permission)
        {
            if (Application.platform != RuntimePlatform.Android) { return true; }

            string className = AndroidPermission.UtilityClassName;
            string methodName = AndroidPermission.IsPermittedMethodName;
            string permissionName = AndroidPermission.Permissions[permission];

            AndroidJavaObject javaObject = new AndroidJavaObject(className);
            bool result = javaObject.CallStatic<bool>(methodName, permissionName);
            Debug.Log(permission + " IsPermitted : " + result + Environment.NewLine);

            return result;
        }
    }
}