using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.File
{
    public class FileListingMasterViewModel
    {
        public int ID { get; set; }
        public string FileNo { get; set; }
        public string FileName { get; set; }

        public string FileReference { get; set; }
        //public Nullable<System.DateTime> FileOpenDate { get; set; }
        //public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientIdentityNo { get; set; }

        //public string PartnerID { get; set; }
        public string PartnerName { get; set; }
        public Nullable<int> Status { get; set; }
        public DateTime? CreatedDate { get; set; }


        //public string ProgressStatus { get; set; }
        //public string FirmID { get; set; }

        //public string RelatedFileNo { get; set; }
        //public string Remark { get; set; }
        //public string VendorID { get; set; }
        //public string VendorFirmID { get; set; }
        //public string VendorFirmTel { get; set; }
        //public string VendorFirmEmail { get; set; }
        //public string VendorFirmLocation { get; set; }
        //public string VendorFirmFileRefNo { get; set; }
        //public string PurchaserID { get; set; }
        //public string PurchaserFirmID { get; set; }
        //public string PurchaserFirmTel { get; set; }
        //public string PurchaserFirmEmail { get; set; }
        //public string PurchaserFirmLocation { get; set; }
        //public string PurchaserFirmFileRefNo { get; set; }
        //public string CreatedBy { get; set; }
        //public Nullable<System.DateTime> CreatedDate { get; set; }
        //public string ModifyBy { get; set; }
        //public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}
