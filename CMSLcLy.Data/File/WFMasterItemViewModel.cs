using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.File
{
    public class WFMasterItemViewModel
    {
        [Key]
        public int Id { get; set; }

        public int DocumentWorkFlowId { get; set; }

        [Display(Name = "FileNo")]
        public string FileNo { get; set; }
        [Display(Name = "User ID")]
        public string AspNetUserID { get; set; }
        [Display(Name = "WorkflowDescription")]
        public string WorkflowDescrption { get; set; }
        [Display(Name = "WorkflowDescription_BM")]
        public string WorkflowDescrption_BM { get; set; }
        [Display(Name = "WorkflowDescription_CN")]
        public string WorkflowDescrption_CN { get; set; }
        [Display(Name = "WorkFlowMasterDesc")]
        public string WorkFlowMasterDesc { get; set; }
        [Display(Name = "WorkFlowMasterDesc_BM")]
        public string WorkFlowMasterDesc_BM { get; set; }
        [Display(Name = "WorkFlowMasterDesc_CN")]
        public string WorkFlowMasterDesc_CN { get; set; }
        [Display(Name = "WorkflowMasterSeq")]
        public int? WorkflowMasterSeq { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Description_BM")]
        public string Description_BM { get; set; }
        [Display(Name = "Description_CN")]
        public string Description_CN { get; set; }
        [Display(Name = "WorkFlowDetailSeq")]
        public int? WorkFlowDetailSeq { get; set; }
        [Display(Name = "isCompleted")]
        public int? isCompleted { get; set; }
        [Display(Name = "Status")]
        public int? Status { get; set; }
        [Display(Name = "WorkFlowSeq")]
        public int? WorkFlowSeq { get; set; }
    }


    public class DocumentItemViewModel
    {
        public int ID { get; set; }
        public string FileNo { get; set; }
        public Nullable<System.DateTime> FileOpenDate { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }

        public string Address { get; set; }
        //public string PartnerID { get; set; }
        //public string FirmID { get; set; }
        public Nullable<int> Status { get; set; }

        public string ProgressStatus { get; set; }
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

    public class DocumentMasterViewModel
    {
        public int ID { get; set; }
        public string FileNo { get; set; }
        public string FileType { get; set; }
        public string FileReference { get; set; }
        public string FileOpenDate { get; set; }
        public string ClientID { get; set; }
        public string PartnerID { get; set; }
        public string FirmID { get; set; }
        public string ChecklistID { get; set; }
        public int? Status { get; set; }
        public string RelatedFileNo { get; set; }
        public string Remark { get; set; }

        public string VendorID { get; set; }
        public string VendorFirmID { get; set; }
        public string VendorFirmTel { get; set; }
        public string VendorFirmEmail { get; set; }
        public string VendorFirmAddress1 { get; set; }
        public string VendorFirmAddress2 { get; set; }
        public string VendorFirmPostcode { get; set; }
        public string VendorFirmTown { get; set; }
        public string VendorFirmState { get; set; }
        public string VendorFirmFileRefNo { get; set; }

        public string PurchaserID { get; set; }
        public string PurchaserFirmID { get; set; }
        public string PurchaserFirmTel { get; set; }
        public string PurchaserFirmEmail { get; set; }
        public string PurchaserFirmAddress1 { get; set; }
        public string PurchaserFirmAddress2 { get; set; }
        public string PurchaserFirmPostcode { get; set; }
        public string PurchaserFirmTown { get; set; }
        public string PurchaserFirmState { get; set; }
        public string PurchaserFirmFileRefNo { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }

        //FOR SPA LOAN (PURCHASE PRICE & Existing Chargee)

        public decimal PurchasePrice { get; set; }
        public decimal EarnestDeposit { get; set; }
        public decimal RetentionSum { get; set; }
        public decimal BalanceDeposit { get; set; }
        public decimal TotalDeposit { get; set; }
        public decimal BalancePurchasePrice { get; set; }
        public decimal ConsumptionTax { get; set; }
        public decimal PurchasePriceAfterTax { get; set; }
        public decimal AdjustmentRate { get; set; }
        public int? BankBranchID { get; set; }
        public string ChargePresentationNo { get; set; }
        public string ExistingChargeeCaveatNo { get; set; }
        public string ExistingBorrowerID { get; set; }

        //FOR SPA & LOAN (PROPERTY WITH INDIVIDUAL TITLE)

        public int? Individual_GeranTypeID { get; set; }
        public int? Individual_LotTypeID { get; set; }
        public int? Individual_AreaID { get; set; }
        public int? Individual_StateID { get; set; }
        public int? Individual_AreaTypeID { get; set; }
        public int? Individual_TenureTypeID { get; set; }
        public DateTime? Individual_DateOpenFile { get; set; }
        public int? Individual_LandUsageTypeID { get; set; }
        public int? Individual_ConditionTypeID { get; set; }
        public int? Individual_RestrictionTypeID { get; set; }
        public int? Individual_BuildingTypeID { get; set; }
        public string Individual_PostalAddress { get; set; }

        //FOR SPA & LOAN (PROPERTY WITH STRATA TITLE)

        public int? Strata_GeranTypeID { get; set; }
        public int? Strata_LotTypeID { get; set; }
        public int? Strata_AreaID { get; set; }
        public int? Strata_StateID { get; set; }
        public int? Strata_AreaTypeID { get; set; }
        public int? Strata_TenureTypeID { get; set; }
        public DateTime Strata_DateOpenFile { get; set; }
        public int? Strata_LandUsageTypeID { get; set; }
        public int? Strata_ConditionTypeID { get; set; }
        public int? Strata_RestrictionTypeID { get; set; }
        public int? Strata_BuildingTypeID { get; set; }
        public string Strata_PostalAddress { get; set; }
        public string Strata_ParcelNo { get; set; }
        public string Strata_StoryNo { get; set; }
        public string Strata_BuildingNo { get; set; }
        public string Strata_ParcelNoDescription { get; set; }
        public int? Strata_UnitAreaTypeID { get; set; }

        //FOR SPA & LOAN (PROPERTY WITHOUT TITLE & DIRECT TRANFER & PROJECT)

        public int? LoanWithoutTitle_DeveloperID { get; set; }
        public int? LoanWithoutTitle_ProprietorID { get; set; }
        public string LoanWithoutTitle_ProjectName { get; set; }
        public int? LoanWithoutTitle_ScheduleID { get; set; }
        public string LoanWithoutTitle_ParcelNo { get; set; }
        public int? LoanWithoutTitle_UnitArea { get; set; }
        public string LoanWithoutTitle_StoreyNo { get; set; }
        public string LoanWithoutTitle_BuildingNo { get; set; }
        public string LoanWithoutTitle_AccessoryParcelNo { get; set; }
        public string LoanWithoutTitle_MasterTitleNo { get; set; }

        // CHAIN OF OWNERSHIP
        public DateTime COO_Purchaser1DOADate { get; set; }
        public int? COO_Purchaser1ID { get; set; }
        public DateTime COO_Purchaser1FADate { get; set; }
        public DateTime COO_Purchaser1LoanDOA { get; set; }
        public DateTime COO_Purchaser1DRRDate { get; set; }

        public DateTime COO_Purchaser2DOADate { get; set; }
        public int? COO_Purchaser2ID { get; set; }
        public DateTime COO_Purchaser2FADate { get; set; }
        public DateTime COO_Purchaser2LoanDOA { get; set; }
        public DateTime COO_Purchaser2DRRDate { get; set; }

        public DateTime COO_Purchaser3DOADate { get; set; }
        public int? COO_Purchaser3ID { get; set; }
        public DateTime COO_Purchaser3FADate { get; set; }
        public DateTime COO_Purchaser3LoanDOA { get; set; }
        public DateTime COO_Purchaser3DRRDate { get; set; }

        public DateTime COO_Purchaser4DOADate { get; set; }
        public int? COO_Purchaser4ID { get; set; }
        public DateTime COO_Purchaser4FADate { get; set; }
        public DateTime COO_Purchaser4LoanDOA { get; set; }
        public DateTime COO_Purchaser4DRRDate { get; set; }

        public DateTime COO_Purchaser5DOADate { get; set; }
        public int? COO_Purchaser5ID { get; set; }
        public DateTime COO_Purchaser5FADate { get; set; }
        public DateTime COO_Purchaser5LoanDOA { get; set; }
        public DateTime COO_Purchaser5DRRDate { get; set; }

        public DateTime COO_Purchaser6DOADate { get; set; }
        public int? COO_Purchaser6ID { get; set; }
        public DateTime COO_Purchaser6FADate { get; set; }
        public DateTime COO_Purchaser6LoanDOA { get; set; }
        public DateTime COO_Purchaser6DRRDate { get; set; }

        public DateTime COO_Purchaser7DOADate { get; set; }
        public int? COO_Purchaser7ID { get; set; }
        public DateTime COO_Purchaser7FADate { get; set; }
        public DateTime COO_Purchaser7LoanDOA { get; set; }
        public DateTime COO_Purchaser7DRRDate { get; set; }

        //FOR LOAN 

        public int? Loan_Borrower1ID { get; set; }
        public int? Loan_Borrower2ID { get; set; }
        public int? Loan_Borrower3ID { get; set; }
        public int? Loan_Borrower4ID { get; set; }
        public int? Loan_Borrower5ID { get; set; }

        public int? Loan_Guarantor1ID { get; set; }
        public int? Loan_Guarantor2ID { get; set; }
        public int? Loan_Guarantor3ID { get; set; }
        public int? Loan_Guarantor4ID { get; set; }
        public int? Loan_Guarantor5ID { get; set; }

        public int? Loan_BranchID { get; set; }
        public string Loan_Address { get; set; }
        public string Loan_CACName { get; set; }
        public string Loan_BankReference { get; set; }
        public DateTime Loan_LetterOfOfferDate { get; set; }
        public DateTime Loan_LetterOfInstructionDate { get; set; }
        public int Loan_Officer1ID { get; set; }
        public string Loan_Officer1Username { get; set; }
        public string Loan_Officer1Password { get; set; }
        public int Loan_Officer2ID { get; set; }
        public string Loan_Officer2Username { get; set; }
        public string Loan_Officer2Password { get; set; }

        public int? Loan_IslamicLoanTypeID { get; set; }
        public int? Loan_IslamicFinancingTypeID { get; set; }
        public decimal Loan_IslamicAmount { get; set; }
        public int? Loan_IslamicOtherFinancingItem1 { get; set; }
        public decimal Loan_IslamicOtherFinancingAmount1 { get; set; }
        public int? Loan_IslamicOtherFinancingItem2 { get; set; }
        public decimal Loan_IslamicOtherFinancingAmount2 { get; set; }
        public int? Loan_IslamicOtherFinancingItem3 { get; set; }
        public decimal Loan_IslamicOtherFinancingAmount3 { get; set; }
        public int? Loan_IslamicOtherFinancingItem4 { get; set; }
        public decimal Loan_IslamicOtherFinancingAmount4 { get; set; }
        public int? Loan_IslamicOtherFinancingItem5 { get; set; }
        public decimal Loan_IslamicOtherFinancingAmount5 { get; set; }
        public decimal Loan_IslamicTotalFinancingSum { get; set; }
        public decimal Loan_IslamicBankSellingPrice { get; set; }
        public decimal Loan_IslamicBankPurchasePrice { get; set; }

        public int? Loan_ConventionalLoanTypeID { get; set; }
        public int? Loan_ConventionalFinancingTypeID { get; set; }
        public decimal Loan_ConventionalLoanAmount { get; set; }
        public int? Loan_ConventionalOtherLoanItem1 { get; set; }
        public decimal Loan_ConventionalOtherLoanAmount1 { get; set; }
        public int? Loan_ConventionalOtherLoanItem2 { get; set; }
        public decimal Loan_ConventionalOtherLoanAmount2 { get; set; }
        public int? Loan_ConventionalOtherLoanItem3 { get; set; }
        public decimal Loan_ConventionalOtherLoanAmount3 { get; set; }
        public int? Loan_ConventionalOtherLoanItem4 { get; set; }
        public decimal Loan_ConventionalOtherLoanAmount4 { get; set; }
        public int? Loan_ConventionalOtherLoanItem5 { get; set; }
        public decimal Loan_ConventionalOtherLoanAmount5 { get; set; }
        public decimal Loan_ConventionalTotalFinancingSum { get; set; }

        public int? Loan_OtherIslamicLoan1BankID { get; set; }
        public string Loan_OtherIslamicLoan1BankName { get; set; }
        public int? Loan_OtherIslamicLoan1ProductType { get; set; }
        public string Loan_OtherIslamicLoan1Specification { get; set; }
        public decimal Loan_OtherIslamicLoan1Amount { get; set; }
        public decimal Loan_OtherIslamicLoan1Unit { get; set; }
        public string Loan_OtherIslamicLoan1Reference { get; set; }

        public int? Loan_OtherIslamicLoan2BankID { get; set; }
        public string Loan_OtherIslamicLoan2BankName { get; set; }
        public int? Loan_OtherIslamicLoan2ProductType { get; set; }
        public string Loan_OtherIslamicLoan2Specification { get; set; }
        public decimal Loan_OtherIslamicLoan2Amount { get; set; }
        public decimal Loan_OtherIslamicLoan2Unit { get; set; }
        public string Loan_OtherIslamicLoan2Reference { get; set; }

        public int? Loan_OtherIslamicLoan3BankID { get; set; }
        public string Loan_OtherIslamicLoan3BankName { get; set; }
        public int? Loan_OtherIslamicLoan3ProductType { get; set; }
        public string Loan_OtherIslamicLoan3Specification { get; set; }
        public decimal Loan_OtherIslamicLoan3Amount { get; set; }
        public decimal Loan_OtherIslamicLoan3Unit { get; set; }
        public string Loan_OtherIslamicLoan3Reference { get; set; }

        public int? Loan_OtherIslamicLoan4BankID { get; set; }
        public string Loan_OtherIslamicLoan4BankName { get; set; }
        public int? Loan_OtherIslamicLoan4ProductType { get; set; }
        public string Loan_OtherIslamicLoan4Specification { get; set; }
        public decimal Loan_OtherIslamicLoan4Amount { get; set; }
        public decimal Loan_OtherIslamicLoan4Unit { get; set; }
        public string Loan_OtherIslamicLoan4Reference { get; set; }

        public int? Loan_OtherIslamicLoan5BankID { get; set; }
        public string Loan_OtherIslamicLoan5BankName { get; set; }
        public int? Loan_OtherIslamicLoan5ProductType { get; set; }
        public string Loan_OtherIslamicLoan5Specification { get; set; }
        public decimal Loan_OtherIslamicLoan5Amount { get; set; }
        public decimal Loan_OtherIslamicLoan5Unit { get; set; }
        public string Loan_OtherIslamicLoan5Reference { get; set; }

        public int? Loan_OtherIslamicLoan6BankID { get; set; }
        public string Loan_OtherIslamicLoan6BankName { get; set; }
        public int? Loan_OtherIslamicLoan6ProductType { get; set; }
        public string Loan_OtherIslamicLoan6Specification { get; set; }
        public decimal Loan_OtherIslamicLoan6Amount { get; set; }
        public decimal Loan_OtherIslamicLoan6Unit { get; set; }
        public string Loan_OtherIslamicLoan6Reference { get; set; }

        public int? Loan_OtherIslamicLoan7BankID { get; set; }
        public string Loan_OtherIslamicLoan7BankName { get; set; }
        public int? Loan_OtherIslamicLoan7ProductType { get; set; }
        public string Loan_OtherIslamicLoan7Specification { get; set; }
        public decimal Loan_OtherIslamicLoan7Amount { get; set; }
        public decimal Loan_OtherIslamicLoan7Unit { get; set; }
        public string Loan_OtherIslamicLoan7Reference { get; set; }

        public int? Loan_FinancingBankSolicitorID { get; set; }
        public string Loan_FinancingFirmPhone { get; set; }
        public string Loan_FinancingFirmAddress1 { get; set; }
        public string Loan_FinancingFirmAddress2 { get; set; }
        public string Loan_FinancingFirmPostcode { get; set; }
        public string Loan_FinancingFirmTown { get; set; }
        public string Loan_FinancingFirmState { get; set; }
        public string Loan_FinancingSolicitorRef { get; set; }
        public string Loan_FinancingEmail { get; set; }
    }

}