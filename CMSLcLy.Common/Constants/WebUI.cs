using System;
using DevExpress.Xpo;

namespace CMSLcLy.Common.Constants
{
    /// <summary>
    /// Constants for General Web UI
    /// </summary>
	public static class WebUI
    {
        public readonly static string ErrorMessage = "ErrorMessage"; // used for TempData["ErrorMessage"]
        public readonly static string Message = "Message";
    }

    public static class VehicleStatus
    {
        public readonly static string Moving = "Moving";
        public readonly static string Idle = "Idle";
        public readonly static string Stop = "Stop";
    }

    /// <summary>
    /// Constants for Top UI Message
    /// </summary>
    public static class TopMessageUI
    {
        public readonly static string TopMessage = "TopMessage";

        public readonly static string CssSuccessClass = "alert-success";
        public readonly static string CssErrorClass = "alert-danger";
        public readonly static string CssInfoClass = "alert-info";
        public readonly static string CssWarningClass = "alert-warning";

        public readonly static string iCssSuccessClass = "fa-check";
        public readonly static string iCssErrorClass = "fa-times";
        public readonly static string iCssInfoClass = "fa-info";
        public readonly static string iCssWarningClass = "fa-warning";

        public readonly static string SuccessTitle = "Success!";
        public readonly static string ErrorTitle = "Error!";
        public readonly static string InfoTitle = "Info!";
        public readonly static string WarningTitle = "Error!";
    }


    public static class UISettingKey
    {
        public readonly static string WebUILayout = "WebUILayout";
        public readonly static string WebUITheme = "WebUITheme";
        public readonly static string WebUIMapStyle = "WebUIMapStyle";
        public readonly static string WebUIRealTimeMapPlateNo = "WebUIRealTimeMapPlateNo";
        public readonly static string WebUIRealTimeColVisibility = "WebUIRealTimeColVisibility";
        public readonly static string WebUIRealTimeMapGeofenceNotification = "WebUIRealTimeMapGeofenceNotification";
        public readonly static string WebUIDashboardIdlingRefreshInterval = "WebUIDashboardIdlingRefreshInterval";
        public readonly static string WebUIMinIdlingTimeDashboardDisplay = "WebUIMinIdlingTimeDashboardDisplay";
        public readonly static string WebUIPopupAlertNotification = "WebUIPopupAlertNotification";
    }

    public static class WebUITheme
    {
        public readonly static string DefaultOrange = "smart-style-3";
        public readonly static string BrightBlue = "smart-style-6";
        public readonly static string DarkElegance = "smart-style-1";
        public readonly static string UltraLight = "smart-style-2";
        public readonly static string GreenNavy = "smart-style-4";
    }

    public static class WebUILayout
    {
        public readonly static string Standard = "";
        public readonly static string Minified = "minified";
        public readonly static string TopNavigation = "top-navigation menu-on-top";
    }

    public static class WebUIMapStyle
    {
        public readonly static string DefaultStyle = "DefaultStyle";
        public readonly static string RetroStyle = "RetroStyle";
        public readonly static string DarkStyle = "DarkStyle";
        public readonly static string SilverStyle = "SilverStyle";
        public readonly static string DarkBlueStyle = "DarkBlueStyle";
    }

    public static class WebUIRealTimeColVisibility
    {
        public readonly static string DefaultColVisibility = "{\"chkCompany\": false, \"chkUnitID\": false, " +
            "\"chkCondition\": false, \"chkGroupName\": false, \"chkBearing\": false, \"chkOdometer\": true, " +
            "\"chkTemperature01\": true, \"chkLock\": false, \"chkSensorFuelHeight\": false," +
            "\"chkFuel1\": true, \"chkFuel2\": false, \"chkImmobilize\": true, \"chkNearestPOI\": true, " +
            "\"chkMap\": true, \"chkLocation\": true }";
    }

}