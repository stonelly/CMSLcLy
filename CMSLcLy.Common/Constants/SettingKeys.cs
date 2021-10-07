using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Common.Constants
{
    /// <summary>
    /// Define System Setting Keys
    /// </summary>
    public class SettingKeys
    {
        /**** Database connection ********/
        public static readonly string DatabaseServer = "DatabaseServer";
        public static readonly string DecoderDatabaseServer = "DecoderDatabaseServer";
        public static readonly string UseIntegratedSecurity = "UseIntegratedSecurity";
        public static readonly string DatabaseName = "DatabaseName";
        public static readonly string DatabaseLogin = "DatabaseLogin";
        public static readonly string DatabaseLoginRealTime = "DatabaseLoginRealTime";
        public static readonly string DatabasePassword = "DatabasePassword";
        public static readonly string MaxPoolSize = "MaxPoolSize";
        public static readonly string EdmxName = "EdmxName";

        /*-----Web/App config *****/
        public static readonly string FakeDateTime = "FakeDateTime";
        public static readonly string CurrentTimeZoneID = "CurrentTimeZoneID";
        public static readonly string TCPIPAddress = "TCPIPAddress";
        public static readonly string TCPPort = "TCPPort";
        public static readonly string SocketBackLogLimit = "SocketBackLogLimit";
        public static readonly string BufferPoolSize = "BufferPoolSize";
        public static readonly string DataReceiverWebApiUrl = "DataReceiverWebApiUrl";
        public static readonly string VLSProtocolType = "VLSProtocolType";
        public static readonly string MaxItemCountInListView = "MaxItemCountInListView";

        /*-----Window Service App Setting *****/
        public static readonly string TimerWorkerInterval = "TimerWorkerInterval";
        public static readonly string AlertNotificationInterval = "AlertNotificationInterval";

        /*--- coSetting - Setting Name-----*/
        public static readonly string ShowImageInVehicleManagement = "ShowImageInVehicleManagement";
        public static readonly string MaxWidthVehicleImage = "MaxWidthVehicleImage";
        public static readonly string ThumbnailVehicleSize = "ThumbnailVehicleSize";
        public static readonly string VLSRealTimeSignalRBroadcastInterval = "VLSRealTimeSignalRBroadcastInterval";
        public static readonly string VLSAlertSignalRBroadcastInterval = "VLSAlertSignalRBroadcastInterval";
        public static readonly string SetDecoderGetGeocodingLocation = "SetDecoderGetGeocodingLocation";
        public static readonly string AutoTripInsertInterval = "AutoTripInsertInterval";
        public static readonly string VLSIdlingSummaryBroadcastInterval = "VLSIdlingSummaryBroadcastInterval";
        public static readonly string TemperatureAlertTrigger = "TemperatureAlertTrigger";
        public static readonly string AutoTripMinAcceptanceODOMeter = "AutoTripMinAcceptanceODOMeter";
    }
}
