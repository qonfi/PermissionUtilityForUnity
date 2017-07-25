using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using System;


namespace AndroidUtility
{
    public class AndroidPermission
    {
        /// <summary>
        /// java で定義したパーミッションに関するユーティリティクラスの完全修飾名。
        /// </summary>
        public static readonly string UtilityClassName = "com.example.permissionutility.Utility";

        /// <summary>
        /// java で定義したメソッドの名前。パーミッションの種類を表す文字列を引数に取って、権限許可のリクエストを行う。
        /// ただし AndroidManifest.xml への記述も必要。
        /// </summary>
        public static readonly string RequestMethodName = "request";

        /// <summary>
        /// java で定義したメソッドの名前。パーミッションの種類を表す文字列を引数にとって、パーミッションの許可が降りているかどうか確認する。
        /// </summary>
        public static readonly string IsPermittedMethodName = "isPermitted";



        #region Dictionary
        /// <summary>
        /// java で用意されている定数名をキーとして、パーミッションの種類を示す文字列を値に持つ。
        /// </summary>
        public static readonly Dictionary<PermissionKey, string> Permissions =
            new Dictionary<PermissionKey, string>
        {
              // しょっちゅう使うわけでもなく、速度が必要な場面で必要とされるわけでもない。
              // 必要になるたびインスタンス生成というのでもいいかもしれない。
              // 作ってから気づいたが、数個を除いて全部 android.permission.定数名 となっている...
             {PermissionKey.ACCESS_CHECKIN_PROPERTIES , "android.permission.ACCESS_CHECKIN_PROPERTIES"},
             {PermissionKey.ACCESS_COARSE_LOCATION , "android.permission.ACCESS_COARSE_LOCATION"},
             {PermissionKey.ACCESS_FINE_LOCATION , "android.permission.ACCESS_FINE_LOCATION"},
             {PermissionKey.ACCESS_LOCATION_EXTRA_COMMANDS , "android.permission.ACCESS_LOCATION_EXTRA_COMMANDS"},
             {PermissionKey.ACCESS_NETWORK_STATE , "android.permission.ACCESS_NETWORK_STATE"},
             {PermissionKey.ACCESS_NOTIFICATION_POLICY , "android.permission.ACCESS_NOTIFICATION_POLICY"},
             {PermissionKey.ACCESS_WIFI_STATE , "android.permission.ACCESS_WIFI_STATE"},
             {PermissionKey.ACCOUNT_MANAGER , "android.permission.ACCOUNT_MANAGER"},
             {PermissionKey.ADD_VOICEMAIL , "com.android.voicemail.permission.ADD_VOICEMAIL"},
             {PermissionKey.BATTERY_STATS , "android.permission.BATTERY_STATS"},
             {PermissionKey.BIND_ACCESSIBILITY_SERVICE , "android.permission.BIND_ACCESSIBILITY_SERVICE"},
             {PermissionKey.BIND_APPWIDGET , "android.permission.BIND_APPWIDGET"},

             {PermissionKey.BIND_CARRIER_SERVICES , "android.permission.BIND_CARRIER_SERVICES"},
             {PermissionKey.BIND_CHOOSER_TARGET_SERVICE , "android.permission.BIND_CHOOSER_TARGET_SERVICE"},
             {PermissionKey.BIND_CONDITION_PROVIDER_SERVICE , "android.permission.BIND_CONDITION_PROVIDER_SERVICE"},
             {PermissionKey.BIND_DEVICE_ADMIN , "android.permission.BIND_DEVICE_ADMIN"},
             {PermissionKey.BIND_DREAM_SERVICE , "android.permission.BIND_DREAM_SERVICE"},
             {PermissionKey.BIND_INCALL_SERVICE , "android.permission.BIND_INCALL_SERVICE"},
             {PermissionKey.BIND_INPUT_METHOD , "android.permission.BIND_INPUT_METHOD"},
             {PermissionKey.BIND_MIDI_DEVICE_SERVICE , "android.permission.BIND_MIDI_DEVICE_SERVICE"},
             {PermissionKey.BIND_NFC_SERVICE , "android.permission.BIND_NFC_SERVICE"},
             {PermissionKey.BIND_NOTIFICATION_LISTENER_SERVICE , "android.permission.BIND_NOTIFICATION_LISTENER_SERVICE"},
             {PermissionKey.BIND_PRINT_SERVICE , "android.permission.BIND_PRINT_SERVICE"},
             {PermissionKey.BIND_QUICK_SETTINGS_TILE , "android.permission.BIND_QUICK_SETTINGS_TILE"},
             {PermissionKey.BIND_REMOTEVIEWS , "android.permission.BIND_REMOTEVIEWS"},
             {PermissionKey.BIND_SCREENING_SERVICE , "android.permission.BIND_SCREENING_SERVICE"},
             {PermissionKey.BIND_TELECOM_CONNECTION_SERVICE , "android.permission.BIND_TELECOM_CONNECTION_SERVICE"},
             {PermissionKey.BIND_TEXT_SERVICE , "android.permission.BIND_TEXT_SERVICE"},
             {PermissionKey.BIND_TV_INPUT , "android.permission.BIND_TV_INPUT"},
             {PermissionKey.BIND_VOICE_INTERACTION , "android.permission.BIND_VOICE_INTERACTION"},
             {PermissionKey.BIND_VPN_SERVICE , "android.permission.BIND_VPN_SERVICE"},
             {PermissionKey.BIND_VR_LISTENER_SERVICE , "android.permission.BIND_VR_LISTENER_SERVICE"},
             {PermissionKey.BIND_WALLPAPER , "android.permission.BIND_WALLPAPER"},
             {PermissionKey.BLUETOOTH , "android.permission.BLUETOOTH"},
             {PermissionKey.BLUETOOTH_ADMIN , "android.permission.BLUETOOTH_ADMIN"},
             {PermissionKey.BLUETOOTH_PRIVILEGED , "android.permission.BLUETOOTH_PRIVILEGED"},
             {PermissionKey.BODY_SENSORS , "android.permission.BODY_SENSORS"},
             {PermissionKey.BROADCAST_PACKAGE_REMOVED , "android.permission.BROADCAST_PACKAGE_REMOVED"},
             {PermissionKey.BROADCAST_SMS , "android.permission.BROADCAST_SMS"},
             {PermissionKey.BROADCAST_STICKY , "android.permission.BROADCAST_STICKY"},
             {PermissionKey.BROADCAST_WAP_PUSH , "android.permission.BROADCAST_WAP_PUSH"},
             {PermissionKey.CALL_PHONE , "android.permission.CALL_PHONE"},
             {PermissionKey.CALL_PRIVILEGED , "android.permission.CALL_PRIVILEGED"},
             {PermissionKey.CAMERA , "android.permission.CAMERA"},
             {PermissionKey.CAPTURE_AUDIO_OUTPUT , "android.permission.CAPTURE_AUDIO_OUTPUT"},
             {PermissionKey.CAPTURE_SECURE_VIDEO_OUTPUT , "android.permission.CAPTURE_SECURE_VIDEO_OUTPUT"},
             {PermissionKey.CAPTURE_VIDEO_OUTPUT , "android.permission.CAPTURE_VIDEO_OUTPUT"},
             {PermissionKey.CHANGE_COMPONENT_ENABLED_STATE , "android.permission.CHANGE_COMPONENT_ENABLED_STATE"},
             {PermissionKey.CHANGE_CONFIGURATION , "android.permission.CHANGE_CONFIGURATION"},
             {PermissionKey.CHANGE_NETWORK_STATE , "android.permission.CHANGE_NETWORK_STATE"},
             {PermissionKey.CHANGE_WIFI_MULTICAST_STATE , "android.permission.CHANGE_WIFI_MULTICAST_STATE"},
             {PermissionKey.CHANGE_WIFI_STATE , "android.permission.CHANGE_WIFI_STATE"},
             {PermissionKey.CLEAR_APP_CACHE , "android.permission.CLEAR_APP_CACHE"},
             {PermissionKey.CONTROL_LOCATION_UPDATES , "android.permission.CONTROL_LOCATION_UPDATES"},
             {PermissionKey.DELETE_CACHE_FILES , "android.permission.DELETE_CACHE_FILES"},
             {PermissionKey.DELETE_PACKAGES , "android.permission.DELETE_PACKAGES"},
             {PermissionKey.DIAGNOSTIC , "android.permission.DIAGNOSTIC"},
             {PermissionKey.DISABLE_KEYGUARD , "android.permission.DISABLE_KEYGUARD"},
             {PermissionKey.DUMP , "android.permission.DUMP"},
             {PermissionKey.EXPAND_STATUS_BAR , "android.permission.EXPAND_STATUS_BAR"},
             {PermissionKey.FACTORY_TEST , "android.permission.FACTORY_TEST"},
             {PermissionKey.GET_ACCOUNTS , "android.permission.GET_ACCOUNTS"},
             {PermissionKey.GET_ACCOUNTS_PRIVILEGED , "android.permission.GET_ACCOUNTS_PRIVILEGED"},
             {PermissionKey.GET_PACKAGE_SIZE , "android.permission.GET_PACKAGE_SIZE"},

             {PermissionKey.GLOBAL_SEARCH , "android.permission.GLOBAL_SEARCH"},
             {PermissionKey.INSTALL_LOCATION_PROVIDER , "android.permission.INSTALL_LOCATION_PROVIDER"},
             {PermissionKey.INSTALL_PACKAGES , "android.permission.INSTALL_PACKAGES"},
             {PermissionKey.INSTALL_SHORTCUT , "com.android.launcher.permission.INSTALL_SHORTCUT"},
             {PermissionKey.INTERNET , "android.permission.INTERNET"},
             {PermissionKey.KILL_BACKGROUND_PROCESSES , "android.permission.KILL_BACKGROUND_PROCESSES"},
             {PermissionKey.LOCATION_HARDWARE , "android.permission.LOCATION_HARDWARE"},
             {PermissionKey.MANAGE_DOCUMENTS , "android.permission.MANAGE_DOCUMENTS"},
             {PermissionKey.MASTER_CLEAR , "android.permission.MASTER_CLEAR"},
             {PermissionKey.MEDIA_CONTENT_CONTROL , "android.permission.MEDIA_CONTENT_CONTROL"},
             {PermissionKey.MODIFY_AUDIO_SETTINGS , "android.permission.MODIFY_AUDIO_SETTINGS"},
             {PermissionKey.MODIFY_PHONE_STATE , "android.permission.MODIFY_PHONE_STATE"},
             {PermissionKey.MOUNT_FORMAT_FILESYSTEMS , "android.permission.MOUNT_FORMAT_FILESYSTEMS"},
             {PermissionKey.MOUNT_UNMOUNT_FILESYSTEMS , "android.permission.MOUNT_UNMOUNT_FILESYSTEMS"},
             {PermissionKey.NFC , "android.permission.NFC"},
             {PermissionKey.PACKAGE_USAGE_STATS , "android.permission.PACKAGE_USAGE_STATS"},

             {PermissionKey.PROCESS_OUTGOING_CALLS , "android.permission.PROCESS_OUTGOING_CALLS"},
             {PermissionKey.READ_CALENDAR , "android.permission.READ_CALENDAR"},
             {PermissionKey.READ_CALL_LOG , "android.permission.READ_CALL_LOG"},
             {PermissionKey.READ_CONTACTS , "android.permission.READ_CONTACTS"},
             {PermissionKey.READ_EXTERNAL_STORAGE , "android.permission.READ_EXTERNAL_STORAGE"},
             {PermissionKey.READ_FRAME_BUFFER , "android.permission.READ_FRAME_BUFFER"},

             {PermissionKey.READ_LOGS , "android.permission.READ_LOGS"},
             {PermissionKey.READ_PHONE_STATE , "android.permission.READ_PHONE_STATE"},
             {PermissionKey.READ_SMS , "android.permission.READ_SMS"},
             {PermissionKey.READ_SYNC_SETTINGS , "android.permission.READ_SYNC_SETTINGS"},
             {PermissionKey.READ_SYNC_STATS , "android.permission.READ_SYNC_STATS"},
             {PermissionKey.READ_VOICEMAIL , "com.android.voicemail.permission.READ_VOICEMAIL"},
             {PermissionKey.REBOOT , "android.permission.REBOOT"},
             {PermissionKey.RECEIVE_BOOT_COMPLETED , "android.permission.RECEIVE_BOOT_COMPLETED"},
             {PermissionKey.RECEIVE_MMS , "android.permission.RECEIVE_MMS"},
             {PermissionKey.RECEIVE_SMS , "android.permission.RECEIVE_SMS"},
             {PermissionKey.RECEIVE_WAP_PUSH , "android.permission.RECEIVE_WAP_PUSH"},
             {PermissionKey.RECORD_AUDIO , "android.permission.RECORD_AUDIO"},
             {PermissionKey.REORDER_TASKS , "android.permission.REORDER_TASKS"},
             {PermissionKey.REQUEST_IGNORE_BATTERY_OPTIMIZATIONS , "android.permission.REQUEST_IGNORE_BATTERY_OPTIMIZATIONS"},
             {PermissionKey.REQUEST_INSTALL_PACKAGES , "android.permission.REQUEST_INSTALL_PACKAGES"},

             {PermissionKey.SEND_RESPOND_VIA_MESSAGE , "android.permission.SEND_RESPOND_VIA_MESSAGE"},
             {PermissionKey.SEND_SMS , "android.permission.SEND_SMS"},
             {PermissionKey.SET_ALARM , "com.android.alarm.permission.SET_ALARM"},
             {PermissionKey.SET_ALWAYS_FINISH , "android.permission.SET_ALWAYS_FINISH"},
             {PermissionKey.SET_ANIMATION_SCALE , "android.permission.SET_ANIMATION_SCALE"},
             {PermissionKey.SET_DEBUG_APP , "android.permission.SET_DEBUG_APP"},

             {PermissionKey.SET_PROCESS_LIMIT , "android.permission.SET_PROCESS_LIMIT"},
             {PermissionKey.SET_TIME , "android.permission.SET_TIME"},
             {PermissionKey.SET_TIME_ZONE , "android.permission.SET_TIME_ZONE"},
             {PermissionKey.SET_WALLPAPER , "android.permission.SET_WALLPAPER"},
             {PermissionKey.SET_WALLPAPER_HINTS , "android.permission.SET_WALLPAPER_HINTS"},
             {PermissionKey.SIGNAL_PERSISTENT_PROCESSES , "android.permission.SIGNAL_PERSISTENT_PROCESSES"},
             {PermissionKey.STATUS_BAR , "android.permission.STATUS_BAR"},
             {PermissionKey.SYSTEM_ALERT_WINDOW , "android.permission.SYSTEM_ALERT_WINDOW"},
             {PermissionKey.TRANSMIT_IR , "android.permission.TRANSMIT_IR"},
             {PermissionKey.UNINSTALL_SHORTCUT , "com.android.launcher.permission.UNINSTALL_SHORTCUT"},
             {PermissionKey.UPDATE_DEVICE_STATS , "android.permission.UPDATE_DEVICE_STATS"},
             {PermissionKey.USE_FINGERPRINT , "android.permission.USE_FINGERPRINT"},
             {PermissionKey.USE_SIP , "android.permission.USE_SIP"},
             {PermissionKey.VIBRATE , "android.permission.VIBRATE"},
             {PermissionKey.WAKE_LOCK , "android.permission.WAKE_LOCK"},
             {PermissionKey.WRITE_APN_SETTINGS , "android.permission.WRITE_APN_SETTINGS"},
             {PermissionKey.WRITE_CALENDAR , "android.permission.WRITE_CALENDAR"},
             {PermissionKey.WRITE_CALL_LOG , "android.permission.WRITE_CALL_LOG"},
             {PermissionKey.WRITE_CONTACTS , "android.permission.WRITE_CONTACTS"},
             {PermissionKey.WRITE_EXTERNAL_STORAGE , "android.permission.WRITE_EXTERNAL_STORAGE"},
             {PermissionKey.WRITE_GSERVICES , "android.permission.WRITE_GSERVICES"},
             {PermissionKey.WRITE_SECURE_SETTINGS , "android.permission.WRITE_SECURE_SETTINGS"},
             {PermissionKey.WRITE_SETTINGS , "android.permission.WRITE_SETTINGS"},
             {PermissionKey.WRITE_SYNC_SETTINGS , "android.permission.WRITE_SYNC_SETTINGS"},
             {PermissionKey.WRITE_VOICEMAIL , "com.android.voicemail.permission.WRITE_VOICEMAIL"},
            };
        #endregion
    }


    /// <summary>
    /// 定数名として java で定義されているもの。しかし中身は
    /// </summary>
    public enum PermissionKey
    {
        // Ctrl F から正規表現で置換した。.".*".
        // これを Dictionary の Key にしようかと思っている。
        ACCESS_CHECKIN_PROPERTIES,
        ACCESS_COARSE_LOCATION,
        ACCESS_FINE_LOCATION,
        ACCESS_LOCATION_EXTRA_COMMANDS,
        ACCESS_NETWORK_STATE,
        ACCESS_NOTIFICATION_POLICY,
        ACCESS_WIFI_STATE,
        ACCOUNT_MANAGER,
        ADD_VOICEMAIL,
        BATTERY_STATS,
        BIND_ACCESSIBILITY_SERVICE,
        BIND_APPWIDGET,

        BIND_CARRIER_SERVICES,
        BIND_CHOOSER_TARGET_SERVICE,
        BIND_CONDITION_PROVIDER_SERVICE,
        BIND_DEVICE_ADMIN,
        BIND_DREAM_SERVICE,
        BIND_INCALL_SERVICE,
        BIND_INPUT_METHOD,
        BIND_MIDI_DEVICE_SERVICE,
        BIND_NFC_SERVICE,
        BIND_NOTIFICATION_LISTENER_SERVICE,
        BIND_PRINT_SERVICE,
        BIND_QUICK_SETTINGS_TILE,
        BIND_REMOTEVIEWS,
        BIND_SCREENING_SERVICE,
        BIND_TELECOM_CONNECTION_SERVICE,
        BIND_TEXT_SERVICE,
        BIND_TV_INPUT,
        BIND_VOICE_INTERACTION,
        BIND_VPN_SERVICE,
        BIND_VR_LISTENER_SERVICE,
        BIND_WALLPAPER,
        BLUETOOTH,
        BLUETOOTH_ADMIN,
        BLUETOOTH_PRIVILEGED,
        BODY_SENSORS,
        BROADCAST_PACKAGE_REMOVED,
        BROADCAST_SMS,
        BROADCAST_STICKY,
        BROADCAST_WAP_PUSH,
        CALL_PHONE,
        CALL_PRIVILEGED,
        CAMERA,
        CAPTURE_AUDIO_OUTPUT,
        CAPTURE_SECURE_VIDEO_OUTPUT,
        CAPTURE_VIDEO_OUTPUT,
        CHANGE_COMPONENT_ENABLED_STATE,
        CHANGE_CONFIGURATION,
        CHANGE_NETWORK_STATE,
        CHANGE_WIFI_MULTICAST_STATE,
        CHANGE_WIFI_STATE,
        CLEAR_APP_CACHE,
        CONTROL_LOCATION_UPDATES,
        DELETE_CACHE_FILES,
        DELETE_PACKAGES,
        DIAGNOSTIC,
        DISABLE_KEYGUARD,
        DUMP,
        EXPAND_STATUS_BAR,
        FACTORY_TEST,
        GET_ACCOUNTS,
        GET_ACCOUNTS_PRIVILEGED,
        GET_PACKAGE_SIZE,

        GLOBAL_SEARCH,
        INSTALL_LOCATION_PROVIDER,
        INSTALL_PACKAGES,
        INSTALL_SHORTCUT,
        INTERNET,
        KILL_BACKGROUND_PROCESSES,
        LOCATION_HARDWARE,
        MANAGE_DOCUMENTS,
        MASTER_CLEAR,
        MEDIA_CONTENT_CONTROL,
        MODIFY_AUDIO_SETTINGS,
        MODIFY_PHONE_STATE,
        MOUNT_FORMAT_FILESYSTEMS,
        MOUNT_UNMOUNT_FILESYSTEMS,
        NFC,
        PACKAGE_USAGE_STATS,

        PROCESS_OUTGOING_CALLS,
        READ_CALENDAR,
        READ_CALL_LOG,
        READ_CONTACTS,
        READ_EXTERNAL_STORAGE,
        READ_FRAME_BUFFER,

        READ_LOGS,
        READ_PHONE_STATE,
        READ_SMS,
        READ_SYNC_SETTINGS,
        READ_SYNC_STATS,
        READ_VOICEMAIL,
        REBOOT,
        RECEIVE_BOOT_COMPLETED,
        RECEIVE_MMS,
        RECEIVE_SMS,
        RECEIVE_WAP_PUSH,
        RECORD_AUDIO,
        REORDER_TASKS,
        REQUEST_IGNORE_BATTERY_OPTIMIZATIONS,
        REQUEST_INSTALL_PACKAGES,

        SEND_RESPOND_VIA_MESSAGE,
        SEND_SMS,
        SET_ALARM,
        SET_ALWAYS_FINISH,
        SET_ANIMATION_SCALE,
        SET_DEBUG_APP,

        SET_PROCESS_LIMIT,
        SET_TIME,
        SET_TIME_ZONE,
        SET_WALLPAPER,
        SET_WALLPAPER_HINTS,
        SIGNAL_PERSISTENT_PROCESSES,
        STATUS_BAR,
        SYSTEM_ALERT_WINDOW,
        TRANSMIT_IR,
        UNINSTALL_SHORTCUT,
        UPDATE_DEVICE_STATS,
        USE_FINGERPRINT,
        USE_SIP,
        VIBRATE,
        WAKE_LOCK,
        WRITE_APN_SETTINGS,
        WRITE_CALENDAR,
        WRITE_CALL_LOG,
        WRITE_CONTACTS,
        WRITE_EXTERNAL_STORAGE,
        WRITE_GSERVICES,
        WRITE_SECURE_SETTINGS,
        WRITE_SETTINGS,
        WRITE_SYNC_SETTINGS,
        WRITE_VOICEMAIL,
    }

}