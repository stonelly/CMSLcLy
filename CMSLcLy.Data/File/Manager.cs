using CMSLcLy.Data.DbModels;
using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.File
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<DocumentItemViewModel> List(string UserID)
        {
            var q = (from model in Context.documentmasters
                     join t2 in Context.userdetails on model.ClientID equals t2.AspNetUserId into gj2
                     from t21 in gj2.DefaultIfEmpty()
                     where model.ClientID == UserID
                     select new DocumentItemViewModel
                     {
                         ID = model.ID,
                         ClientID = model.ClientID,
                         ClientName = t21.FullName,
                         FileNo = model.FileNo,
                         FileOpenDate = model.FileOpenDate,
                         Status = model.Status,
                         Address = t21.Address + "," + t21.Address2 + "," + t21.Address3 + "," + t21.PostCode + "," + t21.City,
                         ProgressStatus = "35.5"
                     });

            return q;
        }

        public IQueryable<DocumentItemViewModel> ListByUser(string userName)
        {
            var q = (from model in Context.documentmasters
                     join t2 in Context.userdetails on model.ClientID equals t2.AspNetUserId into gj2
                     from t21 in gj2.DefaultIfEmpty()
                     where model.CreatedBy == userName
                     select new DocumentItemViewModel
                     {
                         ID = model.ID,
                         ClientID = model.ClientID,
                         ClientName = t21.FullName,
                         FileNo = model.FileNo,
                         FileOpenDate = model.FileOpenDate,
                         Status = model.Status,
                         Address = t21.Address + "," + t21.Address2 + "," + t21.Address3 + "," + t21.PostCode + "," + t21.City,
                         ProgressStatus = "35.5"
                     });

            return q;
        }


        public List<FileListingMasterViewModel> GetList()
        {
            var q = (from model in Context.documentmasters
                     select model).ToList();

            var clientList = (from client in Context.userdetails
                              select client).ToList();


            var fileList = new List<FileListingMasterViewModel>();

            foreach (var file in q)
            {
                var client = clientList.ToList().Where(x => x.AspNetUserId == file.ClientID).FirstOrDefault();
                var partner = clientList.ToList().Where(x => x.AspNetUserId == file.PartnerID).FirstOrDefault();
                var f = new FileListingMasterViewModel()
                {
                    ID = file.ID,
                    FileNo = file.FileNo,
                    FileName = file.FileType,
                    FileReference = file.FileReference,
                    ClientName = client != null ? client.FullName : "",
                    ClientIdentityNo = client != null ? client.IdentityNo : "",
                    ClientAddress = client != null ? client.Address + "," + client.Address2 + "," + client.Address3 + "," + client.PostCode + "," + client.City : "",
                    PartnerName = partner != null ? partner.FullName : "",
                    Status = file.Status,
                    CreatedDate = file.CreatedDate
                };

                fileList.Add(f);
            }


            return fileList;
        }

        public IQueryable<WFMasterItemViewModel> ListByFileNo(string FileNo)
        {
            var q = (from model in Context.documentmasters
                     join t2 in Context.documentworkflows on model.ID equals t2.DocumentID into gj2
                     from t21 in gj2.DefaultIfEmpty()
                     join t3 in Context.workflowdetails on t21.WorkflowDetailID equals t3.ID into gj3
                     from t31 in gj3.DefaultIfEmpty()
                     join t4 in Context.workflowmasters on t31.WorkflowMasterID equals t4.ID into gj4
                     from t41 in gj4.DefaultIfEmpty()
                     join t5 in Context.workflows on t41.WorkflowID equals t5.ID into gj5
                     from t51 in gj5.DefaultIfEmpty()
                     where model.FileNo == FileNo
                     orderby t41.Sequence ascending
                     select new WFMasterItemViewModel
                     {
                         Id = model.ID,
                         DocumentWorkFlowId = t21.ID,
                         AspNetUserID = model.ClientID,
                         Status = model.Status,
                         isCompleted = t21.isCompleted,
                         WorkflowDescrption = t51.WorkflowDescrption,
                         WorkflowDescrption_BM = t51.WorkflowDescrption_BM,
                         WorkflowDescrption_CN = t51.WorkflowDescrption_CN,
                         WorkFlowSeq = t21.Sequence,
                         WorkFlowMasterDesc = t41.WorkFlowMasterDesc,
                         WorkFlowMasterDesc_BM = t41.WorkFlowMasterDesc_BM,
                         WorkFlowMasterDesc_CN = t41.WorkFlowMasterDesc_CN,
                         WorkflowMasterSeq = t41.Sequence,
                         Description = t31.Description,
                         Description_BM = t31.Description_BM,
                         Description_CN = t31.Description_CN,
                         WorkFlowDetailSeq = t31.Sequence
                     });

            return q;
        }

        public IQueryable<WFMasterItemViewModel> ListByFileId(int id)
        {
            var q = (from model in Context.documentmasters
                     join t2 in Context.documentworkflows on model.ID equals t2.DocumentID into gj2
                     from t21 in gj2.DefaultIfEmpty()
                     join t3 in Context.workflowdetails on t21.WorkflowDetailID equals t3.ID into gj3
                     from t31 in gj3.DefaultIfEmpty()
                     join t4 in Context.workflowmasters on t31.WorkflowMasterID equals t4.ID into gj4
                     from t41 in gj4.DefaultIfEmpty()
                     join t5 in Context.workflows on t41.WorkflowID equals t5.ID into gj5
                     from t51 in gj5.DefaultIfEmpty()
                     where model.ID == id
                     orderby t41.Sequence ascending
                     select new WFMasterItemViewModel
                     {
                         Id = model.ID,
                         FileNo = model.FileNo,
                         DocumentWorkFlowId = t21.ID != null ? t21.ID : 0,
                         AspNetUserID = model.ClientID,
                         Status = model.Status,
                         isCompleted = t21.isCompleted,
                         WorkflowDescrption = t51.WorkflowDescrption,
                         WorkflowDescrption_BM = t51.WorkflowDescrption_BM,
                         WorkflowDescrption_CN = t51.WorkflowDescrption_CN,
                         WorkFlowSeq = t21.Sequence,
                         WorkFlowMasterDesc = t41.WorkFlowMasterDesc,
                         WorkFlowMasterDesc_BM = t41.WorkFlowMasterDesc_BM,
                         WorkFlowMasterDesc_CN = t41.WorkFlowMasterDesc_CN,
                         WorkflowMasterSeq = t41.Sequence,
                         Description = t31.Description,
                         Description_BM = t31.Description_BM,
                         Description_CN = t31.Description_CN,
                         WorkFlowDetailSeq = t31.Sequence
                     });

            return q;
        }

        public IQueryable<WFMasterItemViewModel> ListFileNo(string FileNo)
        {
            var q = (from model in Context.documentmasters
                     join t2 in Context.documentworkflows on model.ID equals t2.DocumentID into gj2
                     from t21 in gj2.DefaultIfEmpty()
                     where model.FileNo == FileNo
                     select new WFMasterItemViewModel
                     {
                         Id = model.ID,
                         AspNetUserID = model.ClientID,
                         Status = model.Status,
                         isCompleted = t21.isCompleted,
                     });

            return q;
        }

        public string UpdateTodo(int docWorkflowId)
        {
            var q = (from model in Context.documentworkflows
                     where model.ID == docWorkflowId
                     select model).FirstOrDefault();

            if (q == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            q.isCompleted = 1;
            SaveChanges();

            return "OK";

        }

        public DocumentMasterViewModel Details(string FileNo)
        {
            //var q = (from model in Context.documentmasters
            //         join t2 in Context.userdetails on model.ClientID equals t2.AspNetUserId into gj2
            //         from t21 in gj2.DefaultIfEmpty()
            //         join t3 in Context.documentworkflows on model.ID equals t3.DocumentID into gj3
            //         from t31 in gj3.DefaultIfEmpty()
            //         join t4 in Context.spa_loan_purchase_price on model.ID equals t4.Document_ID into gj4
            //         from t41 in gj4.DefaultIfEmpty()
            //         join t5 in Context.spa_loan_individual on model.ID equals t5.Document_ID into gj5
            //         from t51 in gj5.DefaultIfEmpty()
            //         join t6 in Context.spa_loan_strata on model.ID equals t6.DocumentId into gj6
            //         from t61 in gj6.DefaultIfEmpty()
            //         join t7 in Context.spa_loan_without_transfer_direct_transfer on model.ID equals t7.DocumentId into gj7
            //         from t71 in gj7.DefaultIfEmpty()
            //         join t8 in Context.spa_loan_chain_of_ownership on model.ID equals t8.DocumentId into gj8
            //         from t81 in gj8.DefaultIfEmpty()
            //         join t9 in Context.spa_loan_for_loan on model.ID equals t9.DocumentId into gj9
            //         from t91 in gj9.DefaultIfEmpty()
            //         join t10 in Context.bankmasters on t91.Bank_Branch_ID equals t10.Id into gj10
            //         from t101 in gj10.DefaultIfEmpty()
            //         where model.FileNo == FileNo
            //         select model).FirstOrDefault();

            var document = (from model in Context.documentmasters
                            where model.FileNo == FileNo
                            select model).FirstOrDefault();

            var userDetails = (from user in Context.userdetails
                               select user).ToList();

            var bankMaster = (from bank in Context.bankmasters
                              select bank).ToList();

            var workFlow = (from wf in Context.documentworkflows
                            where wf.DocumentID == document.ID
                            select wf).FirstOrDefault();


            var loanIndividual = (from model in Context.spa_loan_individual
                                  where model.Document_ID == document.ID
                                  select model).FirstOrDefault();
            var loanStrata = (from model in Context.spa_loan_strata
                              where model.DocumentId == document.ID
                              select model).FirstOrDefault();
            var loanPurchasePrice = (from model in Context.spa_loan_purchase_price
                                     where model.Document_ID == document.ID
                                     select model).FirstOrDefault();
            var loanWithoutTransfer = (from model in Context.spa_loan_without_transfer_direct_transfer
                                       where model.DocumentId == document.ID
                                       select model).FirstOrDefault();
            var loanCOO = (from model in Context.spa_loan_chain_of_ownership
                           where model.DocumentId == document.ID
                           select model).FirstOrDefault();
            var loanForLoan = (from model in Context.spa_loan_for_loan
                               where model.DocumentId == document.ID
                               select model).FirstOrDefault();

            var documentModel = new DocumentMasterViewModel()
            {
                ID = document.ID,
                FileNo = document.FileNo != null ? document.FileNo : "",
                FileType = document.FileType != null ? document.FileType : "",
                FileReference = document.FileReference != null ? document.FileReference : "",
                FileOpenDate = document.FileOpenDate.Value.ToString("dd/MM/yyyy"),
                ClientID = document.ClientID != null ? document.ClientID : "",
                PartnerID = document.PartnerID != null ? document.PartnerID : "",
                FirmID = document.FirmID != null ? document.FirmID : "",
                ChecklistID = workFlow != null ? workFlow.ID.ToString() : "",
                Status = document.Status,
                RelatedFileNo = document.RelatedFileNo != null ? document.RelatedFileNo : "",
                Remark = document.Remark != null ? document.Remark : "",
                VendorID = document.VendorID != null ? document.VendorID : "",
                VendorFirmID = document.VendorFirmID != null ? document.VendorFirmID : "",
                VendorFirmTel = document.VendorFirmTel != null ? document.VendorFirmTel : "",
                VendorFirmEmail = document.VendorFirmEmail != null ? document.VendorFirmEmail : "",
                VendorFirmAddress1 = document.VendorFirmAddress1 != null ? document.VendorFirmAddress1 : "",
                VendorFirmAddress2 = document.VendorFirmAddress2 != null ? document.VendorFirmAddress2 : "",
                VendorFirmPostcode = document.VendorFirmZipCode != null ? document.VendorFirmZipCode : "",
                VendorFirmTown = document.VendorFirmCity != null ? document.VendorFirmCity : "",
                VendorFirmState = document.VendorFirmState != null ? document.VendorFirmState : "",
                VendorFirmFileRefNo = document.VendorFirmFileRefNo != null ? document.VendorFirmFileRefNo : "",
                PurchaserID = document.PurchaserID != null ? document.PurchaserID : "",
                PurchaserFirmID = document.PurchaserFirmID != null ? document.PurchaserFirmID : "",
                PurchaserFirmTel = document.PurchaserFirmTel != null ? document.PurchaserFirmTel : "",
                PurchaserFirmEmail = document.PurchaserFirmEmail != null ? document.PurchaserFirmEmail : "",
                PurchaserFirmAddress1 = document.PurchaserFirmAddress1 != null ? document.PurchaserFirmAddress1 : "",
                PurchaserFirmAddress2 = document.PurchaserFirmAddress2 != null ? document.PurchaserFirmAddress2 : "",
                PurchaserFirmPostcode = document.PurchaserFirmZipCode != null ? document.PurchaserFirmZipCode : "",
                PurchaserFirmTown = document.PurchaserFirmCity != null ? document.PurchaserFirmCity : "",
                PurchaserFirmState = document.PurchaserFirmState != null ? document.PurchaserFirmState : "",
                PurchaserFirmFileRefNo = document.PurchaserFirmFileRefNo != null ? document.PurchaserFirmFileRefNo : "",
            };

            if (loanPurchasePrice != null)
            {
                documentModel.PurchasePrice = loanPurchasePrice.Purchase_Price;
                documentModel.EarnestDeposit = loanPurchasePrice.Earnest_Deposit;
                documentModel.RetentionSum = loanPurchasePrice.RPGT_Retention_Sum;
                documentModel.BalanceDeposit = loanPurchasePrice.Balance_Deposit;
                documentModel.TotalDeposit = loanPurchasePrice.Total_Deposit;
                documentModel.BalancePurchasePrice = loanPurchasePrice.Balance_Purchase_Price;
                documentModel.ConsumptionTax = loanPurchasePrice.Consuption_Tax;
                documentModel.PurchasePriceAfterTax = loanPurchasePrice.Purchase_Price_After_Tax;
                documentModel.AdjustmentRate = loanPurchasePrice.Adjustment_Rate;
                documentModel.BankBranchID = loanPurchasePrice.Bank_Branch_ID != null ? loanPurchasePrice.Bank_Branch_ID : 0;
                documentModel.ChargePresentationNo = loanPurchasePrice.Charge_Presentation_No != null ? loanPurchasePrice.Charge_Presentation_No : "";
                documentModel.ExistingChargeeCaveatNo = "";
                documentModel.ExistingBorrowerID = loanPurchasePrice.Existing_Borrower1_User_ID != null && loanPurchasePrice.Existing_Borrower1_User_ID > 0 ? loanPurchasePrice.Existing_Borrower1_User_ID.ToString() : "";
                documentModel.ExistingBorrowerID += loanPurchasePrice.Existing_Borrower2_User_ID != null && loanPurchasePrice.Existing_Borrower2_User_ID > 0 ? "," + loanPurchasePrice.Existing_Borrower2_User_ID.ToString() : "";
                documentModel.ExistingBorrowerID += loanPurchasePrice.Existing_Borrower3_User_ID != null && loanPurchasePrice.Existing_Borrower3_User_ID > 0 ? "," + loanPurchasePrice.Existing_Borrower3_User_ID.ToString() : "";
                documentModel.ExistingBorrowerID += loanPurchasePrice.Existing_Borrower4_User_ID != null && loanPurchasePrice.Existing_Borrower4_User_ID > 0 ? "," + loanPurchasePrice.Existing_Borrower4_User_ID.ToString() : "";
                documentModel.ExistingBorrowerID += loanPurchasePrice.Existing_Borrower5_User_ID != null && loanPurchasePrice.Existing_Borrower5_User_ID > 0 ? "," + loanPurchasePrice.Existing_Borrower5_User_ID.ToString() : "";
            }

            if (loanIndividual != null)
            {
                documentModel.Individual_GeranTypeID = loanIndividual.Geran_Type_ID != null ? loanIndividual.Geran_Type_ID : 0;
                documentModel.Individual_AreaID = loanIndividual.Area_Id != null ? loanIndividual.Area_Id : 0;
                documentModel.Individual_StateID = loanIndividual.State_Id != null ? loanIndividual.State_Id : 0;
                documentModel.Individual_AreaTypeID = loanIndividual.Area_Id != null ? loanIndividual.Area_Id : 0;
                documentModel.Individual_TenureTypeID = loanIndividual.Tenure_Type_Id != null ? loanIndividual.Tenure_Type_Id : 0;
                documentModel.Individual_DateOpenFile = loanIndividual.Date_Open_File != null ? loanIndividual.Date_Open_File : DateTime.MinValue;
                documentModel.Individual_LandUsageTypeID = loanIndividual.Land_Usage_Type_Id != null ? loanIndividual.Land_Usage_Type_Id : 0;
                documentModel.Individual_ConditionTypeID = loanIndividual.Condition_Type_ID != null ? loanIndividual.Condition_Type_ID : 0;
                documentModel.Individual_RestrictionTypeID = loanIndividual.Restriction_Type_ID != null ? loanIndividual.Restriction_Type_ID : 0;
                documentModel.Individual_BuildingTypeID = loanIndividual.Building_Type_ID != null ? loanIndividual.Building_Type_ID : 0;
                documentModel.Individual_PostalAddress = loanIndividual.Postal_Address != null ? loanIndividual.Postal_Address : "";
            }

            if (loanStrata != null)
            {
                documentModel.Strata_GeranTypeID = loanStrata.Geran_Type_Id != null ? loanStrata.Geran_Type_Id : 0;
                documentModel.Strata_LotTypeID = loanStrata.Lot_Type_Id != null ? loanStrata.Lot_Type_Id : 0;
                documentModel.Strata_AreaID = loanStrata.Area_Id != null ? loanStrata.Area_Id : 0;
                documentModel.Strata_StateID = loanStrata.State_Id != null ? loanStrata.State_Id : 0;
                documentModel.Strata_AreaTypeID = loanStrata.Area_Id != null ? loanStrata.Area_Id : 0;
                documentModel.Strata_TenureTypeID = loanStrata.Tenure_Type_Id != null ? loanStrata.Tenure_Type_Id : 0;
                documentModel.Strata_DateOpenFile = loanStrata.Date_Open_File ?? DateTime.MinValue;
                documentModel.Strata_LandUsageTypeID = loanStrata.Land_Usage_Type_Id != null ? loanStrata.Land_Usage_Type_Id : 0;
                documentModel.Strata_ConditionTypeID = loanStrata.Condition_Type_Id != null ? loanStrata.Condition_Type_Id : 0;
                documentModel.Strata_RestrictionTypeID = loanStrata.Restriction_Type_Id != null ? loanStrata.Restriction_Type_Id : 0;
                documentModel.Strata_BuildingTypeID = loanStrata.Building_Type_Id != null ? loanStrata.Building_Type_Id : 0;
                documentModel.Strata_PostalAddress = loanStrata.Postal_Address != null ? loanStrata.Postal_Address : "";
                documentModel.Strata_ParcelNo = loanStrata.Parcel_No != null ? loanStrata.Parcel_No : "";
                documentModel.Strata_StoryNo = loanStrata.Story_No != null ? loanStrata.Story_No : "";
                documentModel.Strata_BuildingNo = loanStrata.Building_No != null ? loanStrata.Building_No : "";
                documentModel.Strata_ParcelNoDescription = loanStrata.Parcel_No_Description != null ? loanStrata.Parcel_No_Description : "";
                documentModel.Strata_UnitAreaTypeID = loanStrata.Unit_Area != null ? loanStrata.Unit_Area : 0;
            }

            if (loanWithoutTransfer != null)
            {
                documentModel.LoanWithoutTitle_DeveloperID = loanWithoutTransfer.Developer_Id != null ? loanWithoutTransfer.Developer_Id : 0;
                documentModel.LoanWithoutTitle_ProprietorID = loanWithoutTransfer.Proprietor_Id != null ? loanWithoutTransfer.Proprietor_Id : 0;
                documentModel.LoanWithoutTitle_ProjectName = loanWithoutTransfer.Project_Name != null ? loanWithoutTransfer.Project_Name : "";
                documentModel.LoanWithoutTitle_ScheduleID = loanWithoutTransfer.Schedule_Id != null ? loanWithoutTransfer.Schedule_Id : 0;
                documentModel.LoanWithoutTitle_ParcelNo = loanWithoutTransfer.Parcel_No != null ? loanWithoutTransfer.Parcel_No : "";
                documentModel.LoanWithoutTitle_UnitArea = loanWithoutTransfer.Unit_Area != null ? loanWithoutTransfer.Unit_Area : 0;
                documentModel.LoanWithoutTitle_StoreyNo = loanWithoutTransfer.Story_No != null ? loanWithoutTransfer.Story_No : "";
                documentModel.LoanWithoutTitle_BuildingNo = loanWithoutTransfer.Building_No != null ? loanWithoutTransfer.Building_No : "";
                documentModel.LoanWithoutTitle_AccessoryParcelNo = loanWithoutTransfer.Accessory_Parcel_No != null ? loanWithoutTransfer.Master_Title_No : "";
                documentModel.LoanWithoutTitle_MasterTitleNo = loanWithoutTransfer.Master_Title_No != null ? loanWithoutTransfer.Master_Title_No : "";
            }

            if (loanCOO != null)
            {
                documentModel.COO_Purchaser1DOADate = loanCOO.Purchaser1_DOA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser1ID = loanCOO.Purchaser1_User_ID != null ? loanCOO.Purchaser1_User_ID : 0;
                documentModel.COO_Purchaser1FADate = loanCOO.Purchaser1_FA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser1LoanDOA = loanCOO.Purchaser1_Loan_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser1DRRDate = loanCOO.Purchaser1_DRR_Date ?? DateTime.MinValue;

                documentModel.COO_Purchaser2DOADate = loanCOO.Purchaser2_DOA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser2ID = loanCOO.Purchaser2_User_ID != null ? loanCOO.Purchaser2_User_ID : 0;
                documentModel.COO_Purchaser2FADate = loanCOO.Purchaser2_FA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser2LoanDOA = loanCOO.Purchaser2_Loan_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser2DRRDate = loanCOO.Purchaser2_DRR_Date ?? DateTime.MinValue;

                documentModel.COO_Purchaser3DOADate = loanCOO.Purchaser3_DOA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser3ID = loanCOO.Purchaser3_User_ID != null ? loanCOO.Purchaser3_User_ID : 0;
                documentModel.COO_Purchaser3FADate = loanCOO.Purchaser3_FA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser3LoanDOA = loanCOO.Purchaser3_Loan_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser3DRRDate = loanCOO.Purchaser3_DRR_Date ?? DateTime.MinValue;

                documentModel.COO_Purchaser4DOADate = loanCOO.Purchaser4_DOA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser4ID = loanCOO.Purchaser4_User_ID != null ? loanCOO.Purchaser4_User_ID : 0;
                documentModel.COO_Purchaser4FADate = loanCOO.Purchaser4_FA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser4LoanDOA = loanCOO.Purchaser4_Loan_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser4DRRDate = loanCOO.Purchaser4_DRR_Date ?? DateTime.MinValue;

                documentModel.COO_Purchaser5DOADate = loanCOO.Purchaser5_DOA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser5ID = loanCOO.Purchaser5_User_ID != null ? loanCOO.Purchaser5_User_ID : 0;
                documentModel.COO_Purchaser5FADate = loanCOO.Purchaser5_FA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser5LoanDOA = loanCOO.Purchaser5_Loan_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser5DRRDate = loanCOO.Purchaser5_DRR_Date ?? DateTime.MinValue;

                documentModel.COO_Purchaser6DOADate = loanCOO.Purchaser6_DOA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser6ID = loanCOO.Purchaser6_User_ID != null ? loanCOO.Purchaser6_User_ID : 0;
                documentModel.COO_Purchaser6FADate = loanCOO.Purchaser6_FA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser6LoanDOA = loanCOO.Purchaser6_Loan_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser6DRRDate = loanCOO.Purchaser6_DRR_Date ?? DateTime.MinValue;

                documentModel.COO_Purchaser7DOADate = loanCOO.Purchaser7_DOA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser7ID = loanCOO.Purchaser7_User_ID != null ? loanCOO.Purchaser7_User_ID : 0;
                documentModel.COO_Purchaser7FADate = loanCOO.Purchaser7_FA_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser7LoanDOA = loanCOO.Purchaser7_Loan_Date ?? DateTime.MinValue;
                documentModel.COO_Purchaser7DRRDate = loanCOO.Purchaser7_DRR_Date ?? DateTime.MinValue;
            }

            if (loanCOO != null)
            {
                var bankAddress = bankMaster.Where(x => x.Id == loanForLoan.Bank_Branch_ID).FirstOrDefault();

                documentModel.Loan_Borrower1ID = loanForLoan.Borrower1_User_ID != null ? loanForLoan.Borrower1_User_ID : 0;
                documentModel.Loan_Borrower2ID = loanForLoan.Borrower2_User_ID != null ? loanForLoan.Borrower2_User_ID : 0;
                documentModel.Loan_Borrower3ID = loanForLoan.Borrower3_User_ID != null ? loanForLoan.Borrower3_User_ID : 0;
                documentModel.Loan_Borrower4ID = loanForLoan.Borrower4_User_ID != null ? loanForLoan.Borrower4_User_ID : 0;
                documentModel.Loan_Borrower5ID = loanForLoan.Borrower5_User_ID != null ? loanForLoan.Borrower5_User_ID : 0;

                documentModel.Loan_Guarantor1ID = loanForLoan.Guarantor1_User_ID != null ? loanForLoan.Guarantor1_User_ID : 0;
                documentModel.Loan_Guarantor2ID = loanForLoan.Guarantor2_User_ID != null ? loanForLoan.Guarantor2_User_ID : 0;
                documentModel.Loan_Guarantor3ID = loanForLoan.Guarantor3_User_ID != null ? loanForLoan.Guarantor3_User_ID : 0;
                documentModel.Loan_Guarantor4ID = loanForLoan.Guarantor4_User_ID != null ? loanForLoan.Guarantor4_User_ID : 0;
                documentModel.Loan_Guarantor5ID = loanForLoan.Guarantor5_User_ID != null ? loanForLoan.Guarantor5_User_ID : 0;

                documentModel.Loan_BranchID = loanForLoan.Bank_Branch_ID != null ? loanForLoan.Bank_Branch_ID : 0;
                documentModel.Loan_Address = bankAddress.Address + " " + bankAddress.Address2 + bankAddress.Address3 + "," + bankAddress.PostCode + "," + bankAddress.State;
                documentModel.Loan_CACName = bankAddress.BranchName;
                documentModel.Loan_BankReference = loanForLoan.Bank_Reference;
                documentModel.Loan_LetterOfOfferDate = loanForLoan.Offer_Letter_Date ?? DateTime.MinValue;
                documentModel.Loan_LetterOfInstructionDate = loanForLoan.Letter_of_Instruction_Date ?? DateTime.MinValue;
                documentModel.Loan_Officer1ID = loanForLoan.Officer1_Id;
                documentModel.Loan_Officer1Username = loanForLoan.Officer1_Username;
                documentModel.Loan_Officer1Password = loanForLoan.Officer1_Password;
                documentModel.Loan_Officer2ID = loanForLoan.Officer2_Id;
                documentModel.Loan_Officer2Username = loanForLoan.Officer2_Username;
                documentModel.Loan_Officer2Password = loanForLoan.Officer2_Password;

                documentModel.Loan_IslamicLoanTypeID = loanForLoan.Islamic_Loan_Type != null ? loanForLoan.Islamic_Loan_Type : 0;
                documentModel.Loan_IslamicFinancingTypeID = loanForLoan.Islamic_Financing_Type != null ? loanForLoan.Islamic_Financing_Type : 0;
                documentModel.Loan_IslamicAmount = loanForLoan.Islamic_Financing_Amount;
                documentModel.Loan_IslamicOtherFinancingItem1 = loanForLoan.Other_Financing1_Type != null ? loanForLoan.Other_Financing1_Type : 0;
                documentModel.Loan_IslamicOtherFinancingAmount1 = loanForLoan.Other_Financing1_Amount;
                documentModel.Loan_IslamicOtherFinancingItem2 = loanForLoan.Other_Financing2_Type != null ? loanForLoan.Other_Financing2_Type : 0;
                documentModel.Loan_IslamicOtherFinancingAmount2 = loanForLoan.Other_Financing2_Amount;
                documentModel.Loan_IslamicOtherFinancingItem3 = loanForLoan.Other_Financing3_Type != null ? loanForLoan.Other_Financing3_Type : 0;
                documentModel.Loan_IslamicOtherFinancingAmount3 = loanForLoan.Other_Financing3_Amount;
                documentModel.Loan_IslamicOtherFinancingItem4 = loanForLoan.Other_Financing4_Type != null ? loanForLoan.Other_Financing4_Type : 0;
                documentModel.Loan_IslamicOtherFinancingAmount4 = loanForLoan.Other_Financing4_Amount;
                documentModel.Loan_IslamicOtherFinancingItem5 = loanForLoan.Other_Financing5_Type != null ? loanForLoan.Other_Financing5_Type : 0;
                documentModel.Loan_IslamicOtherFinancingAmount5 = loanForLoan.Other_Financing5_Amount;
                documentModel.Loan_IslamicTotalFinancingSum = loanForLoan.Islamic_Loan_Total_Financing_Sum;
                documentModel.Loan_IslamicBankSellingPrice = loanForLoan.Bank_Selling_Price;
                documentModel.Loan_IslamicBankPurchasePrice = loanForLoan.Bank_Purchase_Price;

                documentModel.Loan_ConventionalLoanTypeID = loanForLoan.Conventional_Loan_Type != null ? loanForLoan.Conventional_Loan_Type : 0;
                documentModel.Loan_ConventionalFinancingTypeID = loanForLoan.Conventional_Financing_Type != null ? loanForLoan.Conventional_Financing_Type : 0;
                documentModel.Loan_ConventionalLoanAmount = loanForLoan.Conventional_Loan_Amount;
                documentModel.Loan_ConventionalOtherLoanItem1 = loanForLoan.Other_Loan1_Type != null ? loanForLoan.Other_Loan1_Type : 0;
                documentModel.Loan_ConventionalOtherLoanAmount1 = loanForLoan.Other_Loan1_Amount;
                documentModel.Loan_ConventionalOtherLoanItem2 = loanForLoan.Other_Loan2_Type != null ? loanForLoan.Other_Loan2_Type : 0;
                documentModel.Loan_ConventionalOtherLoanAmount2 = loanForLoan.Other_Loan2_Amount;
                documentModel.Loan_ConventionalOtherLoanItem3 = loanForLoan.Other_Loan3_Type != null ? loanForLoan.Other_Loan3_Type : 0;
                documentModel.Loan_ConventionalOtherLoanAmount3 = loanForLoan.Other_Loan3_Amount;
                documentModel.Loan_ConventionalOtherLoanItem4 = loanForLoan.Other_Loan4_Type != null ? loanForLoan.Other_Loan4_Type : 0;
                documentModel.Loan_ConventionalOtherLoanAmount4 = loanForLoan.Other_Loan4_Amount;
                documentModel.Loan_ConventionalOtherLoanItem5 = loanForLoan.Other_Loan5_Type != null ? loanForLoan.Other_Loan5_Type : 0;
                documentModel.Loan_ConventionalOtherLoanAmount5 = loanForLoan.Other_Loan5_Amount;
                documentModel.Loan_ConventionalTotalFinancingSum = loanForLoan.Conventional_Loan_Total_Financing_Sum;

                documentModel.Loan_OtherIslamicLoan1BankName = loanForLoan.Other_Islamic_Loan1_Bank_Name;
                documentModel.Loan_OtherIslamicLoan1ProductType = loanForLoan.Other_Islamic_Loan1_Product_Type != null ? loanForLoan.Other_Islamic_Loan1_Product_Type : 0;
                documentModel.Loan_OtherIslamicLoan1Specification = loanForLoan.Other_Islamic_Loan1_Specification;
                documentModel.Loan_OtherIslamicLoan1Amount = loanForLoan.Other_Islamic_Loan1_Amount;
                documentModel.Loan_OtherIslamicLoan1Unit = loanForLoan.Other_Islamic_Loan1_Unit_Percentage;
                documentModel.Loan_OtherIslamicLoan1Reference = loanForLoan.Other_Islamic_Loan1_Ref;

                documentModel.Loan_OtherIslamicLoan2BankName = loanForLoan.Other_Islamic_Loan2_Bank_Name;
                documentModel.Loan_OtherIslamicLoan2ProductType = loanForLoan.Other_Islamic_Loan2_Product_Type != null ? loanForLoan.Other_Islamic_Loan2_Product_Type : 0;
                documentModel.Loan_OtherIslamicLoan2Specification = loanForLoan.Other_Islamic_Loan2_Specification;
                documentModel.Loan_OtherIslamicLoan2Amount = loanForLoan.Other_Islamic_Loan2_Amount;
                documentModel.Loan_OtherIslamicLoan2Unit = loanForLoan.Other_Islamic_Loan2_Unit_Percentage;
                documentModel.Loan_OtherIslamicLoan2Reference = loanForLoan.Other_Islamic_Loan2_Ref;

                documentModel.Loan_OtherIslamicLoan3BankName = loanForLoan.Other_Islamic_Loan3_Bank_Name;
                documentModel.Loan_OtherIslamicLoan3ProductType = loanForLoan.Other_Islamic_Loan3_Product_Type != null ? loanForLoan.Other_Islamic_Loan3_Product_Type : 0;
                documentModel.Loan_OtherIslamicLoan3Specification = loanForLoan.Other_Islamic_Loan3_Specification;
                documentModel.Loan_OtherIslamicLoan3Amount = loanForLoan.Other_Islamic_Loan3_Amount;
                documentModel.Loan_OtherIslamicLoan3Unit = loanForLoan.Other_Islamic_Loan3_Unit_Percentage;
                documentModel.Loan_OtherIslamicLoan3Reference = loanForLoan.Other_Islamic_Loan3_Ref;

                documentModel.Loan_OtherIslamicLoan4BankName = loanForLoan.Other_Islamic_Loan4_Bank_Name;
                documentModel.Loan_OtherIslamicLoan4ProductType = loanForLoan.Other_Islamic_Loan4_Product_Type != null ? loanForLoan.Other_Islamic_Loan4_Product_Type : 0;
                documentModel.Loan_OtherIslamicLoan4Specification = loanForLoan.Other_Islamic_Loan4_Specification;
                documentModel.Loan_OtherIslamicLoan4Amount = loanForLoan.Other_Islamic_Loan4_Amount;
                documentModel.Loan_OtherIslamicLoan4Unit = loanForLoan.Other_Islamic_Loan4_Unit_Percentage;
                documentModel.Loan_OtherIslamicLoan4Reference = loanForLoan.Other_Islamic_Loan4_Ref;

                documentModel.Loan_OtherIslamicLoan5BankName = loanForLoan.Other_Islamic_Loan5_Bank_Name;
                documentModel.Loan_OtherIslamicLoan5ProductType = loanForLoan.Other_Islamic_Loan5_Product_Type != null ? loanForLoan.Other_Islamic_Loan5_Product_Type : 0;
                documentModel.Loan_OtherIslamicLoan5Specification = loanForLoan.Other_Islamic_Loan5_Specification;
                documentModel.Loan_OtherIslamicLoan5Amount = loanForLoan.Other_Islamic_Loan5_Amount;
                documentModel.Loan_OtherIslamicLoan5Unit = loanForLoan.Other_Islamic_Loan5_Unit_Percentage;
                documentModel.Loan_OtherIslamicLoan5Reference = loanForLoan.Other_Islamic_Loan5_Ref;

                documentModel.Loan_OtherIslamicLoan6BankName = loanForLoan.Other_Islamic_Loan6_Bank_Name;
                documentModel.Loan_OtherIslamicLoan6ProductType = loanForLoan.Other_Islamic_Loan6_Product_Type != null ? loanForLoan.Other_Islamic_Loan6_Product_Type : 0;
                documentModel.Loan_OtherIslamicLoan6Specification = loanForLoan.Other_Islamic_Loan6_Specification;
                documentModel.Loan_OtherIslamicLoan6Amount = loanForLoan.Other_Islamic_Loan6_Amount;
                documentModel.Loan_OtherIslamicLoan6Unit = loanForLoan.Other_Islamic_Loan6_Unit_Percentage;
                documentModel.Loan_OtherIslamicLoan6Reference = loanForLoan.Other_Islamic_Loan6_Ref;

                documentModel.Loan_OtherIslamicLoan7BankName = loanForLoan.Other_Islamic_Loan7_Bank_Name;
                documentModel.Loan_OtherIslamicLoan7ProductType = loanForLoan.Other_Islamic_Loan7_Product_Type != null ? loanForLoan.Other_Islamic_Loan7_Product_Type : 0;
                documentModel.Loan_OtherIslamicLoan7Specification = loanForLoan.Other_Islamic_Loan7_Specification;
                documentModel.Loan_OtherIslamicLoan7Amount = loanForLoan.Other_Islamic_Loan7_Amount;
                documentModel.Loan_OtherIslamicLoan7Unit = loanForLoan.Other_Islamic_Loan7_Unit_Percentage;
                documentModel.Loan_OtherIslamicLoan7Reference = loanForLoan.Other_Islamic_Loan7_Ref;

                documentModel.Loan_FinancingBankSolicitorID = loanForLoan.Bank_Solicitor_ID != null ? loanForLoan.Bank_Solicitor_ID : 0;
                documentModel.Loan_FinancingFirmPhone = loanForLoan.Bank_Solicitor_Firm_Phone_No;
                documentModel.Loan_FinancingFirmAddress1 = loanForLoan.Bank_Solicitor_Firm_Address1;
                documentModel.Loan_FinancingFirmAddress2 = loanForLoan.Bank_Solicitor_Firm_Address2;
                documentModel.Loan_FinancingFirmPostcode = loanForLoan.Bank_Solicitor_Firm_Postcode;
                documentModel.Loan_FinancingFirmTown = loanForLoan.Bank_Solicitor_Firm_City;
                documentModel.Loan_FinancingFirmState = loanForLoan.Bank_Solicitor_Firm_State;
                documentModel.Loan_FinancingSolicitorRef = loanForLoan.Bank_Solicitor_Ref;
                documentModel.Loan_FinancingEmail = loanForLoan.Bank_Solicitor_Email;
            }

            return documentModel;
        }

        public string GetFileTypeByFileNo(string FileNo)
        {
            var q = Context.documentmasters.Where(x => x.FileNo == FileNo).Select(x => x.FileType).FirstOrDefault();

            return q;
        }

        public string Save(DocumentMasterViewModel model, string documentTypeName)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.ID > 0)
            {
                var documentMasterModel = Context.documentmasters.Find(model.ID);
                documentMasterModel.ClientID = model.ClientID;
                documentMasterModel.FileReference = model.FileReference;
                documentMasterModel.FileOpenDate = DateTime.ParseExact(model.FileOpenDate, "dd/MM/yyyy", null);
                documentMasterModel.PartnerID = model.PartnerID;
                documentMasterModel.FirmID = model.FirmID;
                documentMasterModel.Remark = model.Remark;
                documentMasterModel.Status = model.Status;
                documentMasterModel.RelatedFileNo = model.RelatedFileNo;
                documentMasterModel.VendorID = model.VendorID;
                documentMasterModel.VendorFirmID = model.VendorFirmID;
                documentMasterModel.VendorFirmTel = model.VendorFirmTel;
                documentMasterModel.VendorFirmEmail = model.VendorFirmEmail;
                documentMasterModel.VendorFirmAddress1 = model.VendorFirmAddress1;
                documentMasterModel.VendorFirmAddress2 = model.VendorFirmAddress2;
                documentMasterModel.VendorFirmZipCode = model.VendorFirmPostcode;
                documentMasterModel.VendorFirmCity = model.VendorFirmTown;
                documentMasterModel.VendorFirmState = model.VendorFirmState;
                documentMasterModel.VendorFirmFileRefNo = model.VendorFirmFileRefNo;
                documentMasterModel.PurchaserID = model.PurchaserID;
                documentMasterModel.PurchaserFirmID = model.PurchaserFirmID;
                documentMasterModel.PurchaserFirmTel = model.PurchaserFirmTel;
                documentMasterModel.PurchaserFirmEmail = model.PurchaserFirmEmail;
                documentMasterModel.PurchaserFirmAddress1 = model.PurchaserFirmAddress1;
                documentMasterModel.PurchaserFirmAddress2 = model.PurchaserFirmAddress2;
                documentMasterModel.PurchaserFirmZipCode = model.PurchaserFirmPostcode;
                documentMasterModel.PurchaserFirmCity = model.PurchaserFirmTown;
                documentMasterModel.PurchaserFirmState = model.PurchaserFirmState;
                documentMasterModel.PurchaserFirmFileRefNo = model.PurchaserFirmFileRefNo;
                documentMasterModel.ModifyBy = model.ModifyBy;
                documentMasterModel.ModifyDate = DateTime.Now;

                var COOModel = Context.spa_loan_chain_of_ownership.Where(x => x.DocumentId == model.ID).FirstOrDefault();

                if (COOModel != null)
                {
                    COOModel.Purchaser1_User_ID = model.COO_Purchaser1ID;
                    COOModel.Purchaser1_DOA_Date = model.COO_Purchaser1DOADate;
                    COOModel.Purchaser1_FA_Date = model.COO_Purchaser1FADate;
                    COOModel.Purchaser1_Loan_Date = model.COO_Purchaser1LoanDOA;
                    COOModel.Purchaser1_DRR_Date = model.COO_Purchaser1DRRDate;
                    COOModel.Purchaser2_User_ID = model.COO_Purchaser2ID;
                    COOModel.Purchaser2_DOA_Date = model.COO_Purchaser2DOADate;
                    COOModel.Purchaser2_FA_Date = model.COO_Purchaser2FADate;
                    COOModel.Purchaser2_Loan_Date = model.COO_Purchaser2LoanDOA;
                    COOModel.Purchaser2_DRR_Date = model.COO_Purchaser2DRRDate;
                    COOModel.Purchaser3_User_ID = model.COO_Purchaser3ID;
                    COOModel.Purchaser3_DOA_Date = model.COO_Purchaser3DOADate;
                    COOModel.Purchaser3_FA_Date = model.COO_Purchaser3FADate;
                    COOModel.Purchaser3_Loan_Date = model.COO_Purchaser3LoanDOA;
                    COOModel.Purchaser3_DRR_Date = model.COO_Purchaser3DRRDate;
                    COOModel.Purchaser4_User_ID = model.COO_Purchaser4ID;
                    COOModel.Purchaser4_DOA_Date = model.COO_Purchaser4DOADate;
                    COOModel.Purchaser4_FA_Date = model.COO_Purchaser4FADate;
                    COOModel.Purchaser4_Loan_Date = model.COO_Purchaser4LoanDOA;
                    COOModel.Purchaser4_DRR_Date = model.COO_Purchaser4DRRDate;
                    COOModel.Purchaser5_User_ID = model.COO_Purchaser5ID;
                    COOModel.Purchaser5_DOA_Date = model.COO_Purchaser5DOADate;
                    COOModel.Purchaser5_FA_Date = model.COO_Purchaser5FADate;
                    COOModel.Purchaser5_Loan_Date = model.COO_Purchaser5LoanDOA;
                    COOModel.Purchaser5_DRR_Date = model.COO_Purchaser5DRRDate;

                    COOModel.Purchaser6_User_ID = model.COO_Purchaser6ID;
                    COOModel.Purchaser6_DOA_Date = model.COO_Purchaser6DOADate;
                    COOModel.Purchaser6_FA_Date = model.COO_Purchaser6FADate;
                    COOModel.Purchaser6_Loan_Date = model.COO_Purchaser6LoanDOA;
                    COOModel.Purchaser6_DRR_Date = model.COO_Purchaser6DRRDate;
                    COOModel.Purchaser7_User_ID = model.COO_Purchaser7ID;
                    COOModel.Purchaser7_DOA_Date = model.COO_Purchaser7DOADate;
                    COOModel.Purchaser7_FA_Date = model.COO_Purchaser7FADate;
                    COOModel.Purchaser7_Loan_Date = model.COO_Purchaser7LoanDOA;
                    COOModel.Purchaser7_DRR_Date = model.COO_Purchaser7DRRDate;
                }
                else if (model.COO_Purchaser1ID > 0)
                {
                    // add other forms 
                    var item1 = new DbModels.spa_loan_chain_of_ownership()
                    {
                        DocumentId = model.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Chain of Ownership",
                        Purchaser1_User_ID = model.COO_Purchaser1ID,
                        Purchaser1_DOA_Date = model.COO_Purchaser1DOADate,
                        Purchaser1_FA_Date = model.COO_Purchaser1FADate,
                        Purchaser1_Loan_Date = model.COO_Purchaser1LoanDOA,
                        Purchaser1_DRR_Date = model.COO_Purchaser1DRRDate,

                        Purchaser2_User_ID = model.COO_Purchaser2ID,
                        Purchaser2_DOA_Date = model.COO_Purchaser2DOADate,
                        Purchaser2_FA_Date = model.COO_Purchaser2FADate,
                        Purchaser2_Loan_Date = model.COO_Purchaser2LoanDOA,
                        Purchaser2_DRR_Date = model.COO_Purchaser2DRRDate,

                        Purchaser3_User_ID = model.COO_Purchaser3ID,
                        Purchaser3_DOA_Date = model.COO_Purchaser3DOADate,
                        Purchaser3_FA_Date = model.COO_Purchaser3FADate,
                        Purchaser3_Loan_Date = model.COO_Purchaser3LoanDOA,
                        Purchaser3_DRR_Date = model.COO_Purchaser3DRRDate,

                        Purchaser4_User_ID = model.COO_Purchaser4ID,
                        Purchaser4_DOA_Date = model.COO_Purchaser4DOADate,
                        Purchaser4_FA_Date = model.COO_Purchaser4FADate,
                        Purchaser4_Loan_Date = model.COO_Purchaser4LoanDOA,
                        Purchaser4_DRR_Date = model.COO_Purchaser4DRRDate,

                        Purchaser5_User_ID = model.COO_Purchaser5ID,
                        Purchaser5_DOA_Date = model.COO_Purchaser5DOADate,
                        Purchaser5_FA_Date = model.COO_Purchaser5FADate,
                        Purchaser5_Loan_Date = model.COO_Purchaser5LoanDOA,
                        Purchaser5_DRR_Date = model.COO_Purchaser5DRRDate,

                        Purchaser6_User_ID = model.COO_Purchaser6ID,
                        Purchaser6_DOA_Date = model.COO_Purchaser6DOADate,
                        Purchaser6_FA_Date = model.COO_Purchaser6FADate,
                        Purchaser6_Loan_Date = model.COO_Purchaser6LoanDOA,
                        Purchaser6_DRR_Date = model.COO_Purchaser6DRRDate,

                        Purchaser7_User_ID = model.COO_Purchaser7ID,
                        Purchaser7_DOA_Date = model.COO_Purchaser7DOADate,
                        Purchaser7_FA_Date = model.COO_Purchaser7FADate,
                        Purchaser7_Loan_Date = model.COO_Purchaser7LoanDOA,
                        Purchaser7_DRR_Date = model.COO_Purchaser7DRRDate,

                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_chain_of_ownership.Add(item1);
                }

                var LoanModel = Context.spa_loan_for_loan.Where(x => x.DocumentId == model.ID).FirstOrDefault();

                if (LoanModel != null)
                {
                    LoanModel.Borrower1_User_ID = model.Loan_Borrower1ID;
                    LoanModel.Borrower2_User_ID = model.Loan_Borrower2ID;
                    LoanModel.Borrower3_User_ID = model.Loan_Borrower3ID;
                    LoanModel.Borrower4_User_ID = model.Loan_Borrower4ID;
                    LoanModel.Borrower5_User_ID = model.Loan_Borrower5ID;

                    LoanModel.Guarantor1_User_ID = model.Loan_Guarantor1ID;
                    LoanModel.Guarantor2_User_ID = model.Loan_Guarantor2ID;
                    LoanModel.Guarantor3_User_ID = model.Loan_Guarantor3ID;
                    LoanModel.Guarantor4_User_ID = model.Loan_Guarantor4ID;
                    LoanModel.Guarantor5_User_ID = model.Loan_Guarantor5ID;

                    LoanModel.Bank_Branch_ID = model.Loan_BranchID;
                    LoanModel.Bank_Reference = model.Loan_BankReference;
                    LoanModel.Offer_Letter_Date = model.Loan_LetterOfOfferDate;
                    LoanModel.Letter_of_Instruction_Date = model.Loan_LetterOfInstructionDate;

                    LoanModel.Officer1_Id = model.Loan_Officer1ID;
                    LoanModel.Officer1_Username = model.Loan_Officer1Username;
                    LoanModel.Officer1_Password = model.Loan_Officer1Password;
                    LoanModel.Officer2_Id = model.Loan_Officer2ID;
                    LoanModel.Officer2_Username = model.Loan_Officer2Username;
                    LoanModel.Officer2_Password = model.Loan_Officer2Password;

                    LoanModel.Conventional_Loan_Type = model.Loan_ConventionalLoanTypeID;
                    LoanModel.Conventional_Financing_Type = model.Loan_ConventionalFinancingTypeID;
                    LoanModel.Conventional_Loan_Amount = model.Loan_ConventionalLoanAmount;
                    LoanModel.Other_Loan1_Type = model.Loan_ConventionalOtherLoanItem1;
                    LoanModel.Other_Loan1_Amount = model.Loan_ConventionalOtherLoanAmount1;
                    LoanModel.Other_Loan2_Type = model.Loan_ConventionalOtherLoanItem2;
                    LoanModel.Other_Loan2_Amount = model.Loan_ConventionalOtherLoanAmount2;
                    LoanModel.Other_Loan3_Type = model.Loan_ConventionalOtherLoanItem3;
                    LoanModel.Other_Loan3_Amount = model.Loan_ConventionalOtherLoanAmount3;
                    LoanModel.Other_Loan4_Type = model.Loan_ConventionalOtherLoanItem4;
                    LoanModel.Other_Loan4_Amount = model.Loan_ConventionalOtherLoanAmount4;
                    LoanModel.Other_Loan5_Type = model.Loan_ConventionalOtherLoanItem5;
                    LoanModel.Other_Loan5_Amount = model.Loan_ConventionalOtherLoanAmount5;
                    LoanModel.Conventional_Loan_Total_Financing_Sum = model.Loan_ConventionalTotalFinancingSum;

                    LoanModel.Islamic_Loan_Type = model.Loan_IslamicLoanTypeID;
                    LoanModel.Islamic_Financing_Type = model.Loan_IslamicFinancingTypeID;
                    LoanModel.Islamic_Financing_Amount = model.Loan_IslamicAmount;
                    LoanModel.Other_Financing1_Type = model.Loan_IslamicOtherFinancingItem1;
                    LoanModel.Other_Financing1_Amount = model.Loan_IslamicOtherFinancingAmount1;
                    LoanModel.Other_Financing2_Type = model.Loan_IslamicOtherFinancingItem2;
                    LoanModel.Other_Financing2_Amount = model.Loan_IslamicOtherFinancingAmount2;
                    LoanModel.Other_Financing3_Type = model.Loan_IslamicOtherFinancingItem3;
                    LoanModel.Other_Financing3_Amount = model.Loan_IslamicOtherFinancingAmount3;
                    LoanModel.Other_Financing4_Type = model.Loan_IslamicOtherFinancingItem4;
                    LoanModel.Other_Financing4_Amount = model.Loan_IslamicOtherFinancingAmount4;
                    LoanModel.Other_Financing5_Type = model.Loan_IslamicOtherFinancingItem5;
                    LoanModel.Other_Financing5_Amount = model.Loan_IslamicOtherFinancingAmount5;
                    LoanModel.Islamic_Loan_Total_Financing_Sum = model.Loan_IslamicTotalFinancingSum;
                    LoanModel.Bank_Selling_Price = model.Loan_IslamicBankSellingPrice;
                    LoanModel.Bank_Purchase_Price = model.Loan_IslamicBankPurchasePrice;

                    LoanModel.Other_Islamic_Loan1_Bank_Name = model.Loan_OtherIslamicLoan1BankName;
                    LoanModel.Other_Islamic_Loan1_Product_Type = model.Loan_OtherIslamicLoan1ProductType;
                    LoanModel.Other_Islamic_Loan1_Specification = model.Loan_OtherIslamicLoan1Specification;
                    LoanModel.Other_Islamic_Loan1_Amount = model.Loan_OtherIslamicLoan1Amount;
                    LoanModel.Other_Islamic_Loan1_Unit_Percentage = model.Loan_OtherIslamicLoan1Unit;
                    LoanModel.Other_Islamic_Loan1_Ref = model.Loan_OtherIslamicLoan1Reference;

                    LoanModel.Other_Islamic_Loan2_Bank_Name = model.Loan_OtherIslamicLoan2BankName;
                    LoanModel.Other_Islamic_Loan2_Product_Type = model.Loan_OtherIslamicLoan2ProductType;
                    LoanModel.Other_Islamic_Loan2_Specification = model.Loan_OtherIslamicLoan2Specification;
                    LoanModel.Other_Islamic_Loan2_Amount = model.Loan_OtherIslamicLoan2Amount;
                    LoanModel.Other_Islamic_Loan2_Unit_Percentage = model.Loan_OtherIslamicLoan2Unit;
                    LoanModel.Other_Islamic_Loan2_Ref = model.Loan_OtherIslamicLoan2Reference;

                    LoanModel.Other_Islamic_Loan3_Bank_Name = model.Loan_OtherIslamicLoan3BankName;
                    LoanModel.Other_Islamic_Loan3_Product_Type = model.Loan_OtherIslamicLoan3ProductType;
                    LoanModel.Other_Islamic_Loan3_Specification = model.Loan_OtherIslamicLoan3Specification;
                    LoanModel.Other_Islamic_Loan3_Amount = model.Loan_OtherIslamicLoan3Amount;
                    LoanModel.Other_Islamic_Loan3_Unit_Percentage = model.Loan_OtherIslamicLoan3Unit;
                    LoanModel.Other_Islamic_Loan3_Ref = model.Loan_OtherIslamicLoan3Reference;

                    LoanModel.Other_Islamic_Loan4_Bank_Name = model.Loan_OtherIslamicLoan4BankName;
                    LoanModel.Other_Islamic_Loan4_Product_Type = model.Loan_OtherIslamicLoan4ProductType;
                    LoanModel.Other_Islamic_Loan4_Specification = model.Loan_OtherIslamicLoan4Specification;
                    LoanModel.Other_Islamic_Loan4_Amount = model.Loan_OtherIslamicLoan4Amount;
                    LoanModel.Other_Islamic_Loan4_Unit_Percentage = model.Loan_OtherIslamicLoan4Unit;
                    LoanModel.Other_Islamic_Loan4_Ref = model.Loan_OtherIslamicLoan4Reference;

                    LoanModel.Other_Islamic_Loan5_Bank_Name = model.Loan_OtherIslamicLoan5BankName;
                    LoanModel.Other_Islamic_Loan5_Product_Type = model.Loan_OtherIslamicLoan5ProductType;
                    LoanModel.Other_Islamic_Loan5_Specification = model.Loan_OtherIslamicLoan5Specification;
                    LoanModel.Other_Islamic_Loan5_Amount = model.Loan_OtherIslamicLoan5Amount;
                    LoanModel.Other_Islamic_Loan5_Unit_Percentage = model.Loan_OtherIslamicLoan5Unit;
                    LoanModel.Other_Islamic_Loan5_Ref = model.Loan_OtherIslamicLoan5Reference;

                    LoanModel.Other_Islamic_Loan6_Bank_Name = model.Loan_OtherIslamicLoan6BankName;
                    LoanModel.Other_Islamic_Loan6_Product_Type = model.Loan_OtherIslamicLoan6ProductType;
                    LoanModel.Other_Islamic_Loan6_Specification = model.Loan_OtherIslamicLoan6Specification;
                    LoanModel.Other_Islamic_Loan6_Amount = model.Loan_OtherIslamicLoan6Amount;
                    LoanModel.Other_Islamic_Loan6_Unit_Percentage = model.Loan_OtherIslamicLoan6Unit;
                    LoanModel.Other_Islamic_Loan6_Ref = model.Loan_OtherIslamicLoan6Reference;

                    LoanModel.Other_Islamic_Loan7_Bank_Name = model.Loan_OtherIslamicLoan7BankName;
                    LoanModel.Other_Islamic_Loan7_Product_Type = model.Loan_OtherIslamicLoan7ProductType;
                    LoanModel.Other_Islamic_Loan7_Specification = model.Loan_OtherIslamicLoan7Specification;
                    LoanModel.Other_Islamic_Loan7_Amount = model.Loan_OtherIslamicLoan7Amount;
                    LoanModel.Other_Islamic_Loan7_Unit_Percentage = model.Loan_OtherIslamicLoan7Unit;
                    LoanModel.Other_Islamic_Loan7_Ref = model.Loan_OtherIslamicLoan7Reference;

                    LoanModel.Bank_Solicitor_ID = model.Loan_FinancingBankSolicitorID;
                    LoanModel.Bank_Solicitor_Firm_Phone_No = model.Loan_FinancingFirmPhone;
                    LoanModel.Bank_Solicitor_Email = model.Loan_FinancingEmail;
                    LoanModel.Bank_Solicitor_Firm_Address1 = model.Loan_FinancingFirmAddress1;
                    LoanModel.Bank_Solicitor_Firm_Address2 = model.Loan_FinancingFirmAddress2;
                    LoanModel.Bank_Solicitor_Firm_Postcode = model.Loan_FinancingFirmPostcode;
                    LoanModel.Bank_Solicitor_Firm_City = model.Loan_FinancingFirmTown;
                    LoanModel.Bank_Solicitor_Firm_State = model.Loan_FinancingFirmState;
                    LoanModel.Bank_Solicitor_Ref = model.Loan_FinancingSolicitorRef;

                }
                else if (model.Loan_Borrower1ID > 0)
                {
                    var item2 = new DbModels.spa_loan_for_loan()
                    {
                        DocumentId = model.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "For Loan",
                        Borrower1_User_ID = model.Loan_Borrower1ID,
                        Borrower2_User_ID = model.Loan_Borrower2ID,
                        Borrower3_User_ID = model.Loan_Borrower3ID,
                        Borrower4_User_ID = model.Loan_Borrower4ID,
                        Borrower5_User_ID = model.Loan_Borrower5ID,
                        Guarantor1_User_ID = model.Loan_Guarantor1ID,
                        Guarantor2_User_ID = model.Loan_Guarantor2ID,
                        Guarantor3_User_ID = model.Loan_Guarantor3ID,
                        Guarantor4_User_ID = model.Loan_Guarantor4ID,
                        Guarantor5_User_ID = model.Loan_Guarantor5ID,
                        Bank_Branch_ID = model.Loan_BranchID,
                        Bank_Reference = model.Loan_BankReference,
                        Offer_Letter_Date = model.Loan_LetterOfOfferDate,
                        Letter_of_Instruction_Date = model.Loan_LetterOfInstructionDate,
                        Officer1_Id = model.Loan_Officer1ID,
                        Officer1_Username = model.Loan_Officer1Username,
                        Officer1_Password = model.Loan_Officer1Password,
                        Officer2_Id = model.Loan_Officer2ID,
                        Officer2_Username = model.Loan_Officer2Username,
                        Officer2_Password = model.Loan_Officer2Password,
                        Conventional_Loan_Type = model.Loan_ConventionalLoanTypeID,
                        Conventional_Financing_Type = model.Loan_ConventionalFinancingTypeID,
                        Conventional_Loan_Amount = model.Loan_ConventionalLoanAmount,
                        Other_Loan1_Type = model.Loan_ConventionalOtherLoanItem1,
                        Other_Loan1_Amount = model.Loan_ConventionalOtherLoanAmount1,
                        Other_Loan2_Type = model.Loan_ConventionalOtherLoanItem2,
                        Other_Loan2_Amount = model.Loan_ConventionalOtherLoanAmount2,
                        Other_Loan3_Type = model.Loan_ConventionalOtherLoanItem3,
                        Other_Loan3_Amount = model.Loan_ConventionalOtherLoanAmount3,
                        Other_Loan4_Type = model.Loan_ConventionalOtherLoanItem4,
                        Other_Loan4_Amount = model.Loan_ConventionalOtherLoanAmount4,
                        Other_Loan5_Type = model.Loan_ConventionalOtherLoanItem5,
                        Other_Loan5_Amount = model.Loan_ConventionalOtherLoanAmount5,
                        Conventional_Loan_Total_Financing_Sum = model.Loan_ConventionalTotalFinancingSum,
                        Islamic_Loan_Type = model.Loan_IslamicLoanTypeID,
                        Islamic_Financing_Type = model.Loan_IslamicFinancingTypeID,
                        Islamic_Financing_Amount = model.Loan_IslamicAmount,
                        Other_Financing1_Type = model.Loan_IslamicOtherFinancingItem1,
                        Other_Financing1_Amount = model.Loan_IslamicOtherFinancingAmount1,
                        Other_Financing2_Type = model.Loan_IslamicOtherFinancingItem2,
                        Other_Financing2_Amount = model.Loan_IslamicOtherFinancingAmount2,
                        Other_Financing3_Type = model.Loan_IslamicOtherFinancingItem3,
                        Other_Financing3_Amount = model.Loan_IslamicOtherFinancingAmount3,
                        Other_Financing4_Type = model.Loan_IslamicOtherFinancingItem4,
                        Other_Financing4_Amount = model.Loan_IslamicOtherFinancingAmount4,
                        Other_Financing5_Type = model.Loan_IslamicOtherFinancingItem5,
                        Other_Financing5_Amount = model.Loan_IslamicOtherFinancingAmount5,
                        Islamic_Loan_Total_Financing_Sum = model.Loan_IslamicTotalFinancingSum,
                        Bank_Selling_Price = model.Loan_IslamicBankSellingPrice,
                        Bank_Purchase_Price = model.Loan_IslamicBankPurchasePrice,

                        Other_Islamic_Loan1_Bank_Name = model.Loan_OtherIslamicLoan1BankName,
                        Other_Islamic_Loan1_Product_Type = model.Loan_OtherIslamicLoan1ProductType,
                        Other_Islamic_Loan1_Specification = model.Loan_OtherIslamicLoan1Specification,
                        Other_Islamic_Loan1_Amount = model.Loan_OtherIslamicLoan1Amount,
                        Other_Islamic_Loan1_Unit_Percentage = model.Loan_OtherIslamicLoan1Unit,
                        Other_Islamic_Loan1_Ref = model.Loan_OtherIslamicLoan1Reference,

                        Other_Islamic_Loan2_Bank_Name = model.Loan_OtherIslamicLoan2BankName,
                        Other_Islamic_Loan2_Product_Type = model.Loan_OtherIslamicLoan2ProductType,
                        Other_Islamic_Loan2_Specification = model.Loan_OtherIslamicLoan2Specification,
                        Other_Islamic_Loan2_Amount = model.Loan_OtherIslamicLoan2Amount,
                        Other_Islamic_Loan2_Unit_Percentage = model.Loan_OtherIslamicLoan2Unit,
                        Other_Islamic_Loan2_Ref = model.Loan_OtherIslamicLoan2Reference,

                        Other_Islamic_Loan3_Bank_Name = model.Loan_OtherIslamicLoan3BankName,
                        Other_Islamic_Loan3_Product_Type = model.Loan_OtherIslamicLoan3ProductType,
                        Other_Islamic_Loan3_Specification = model.Loan_OtherIslamicLoan3Specification,
                        Other_Islamic_Loan3_Amount = model.Loan_OtherIslamicLoan3Amount,
                        Other_Islamic_Loan3_Unit_Percentage = model.Loan_OtherIslamicLoan3Unit,
                        Other_Islamic_Loan3_Ref = model.Loan_OtherIslamicLoan3Reference,

                        Other_Islamic_Loan4_Bank_Name = model.Loan_OtherIslamicLoan4BankName,
                        Other_Islamic_Loan4_Product_Type = model.Loan_OtherIslamicLoan4ProductType,
                        Other_Islamic_Loan4_Specification = model.Loan_OtherIslamicLoan4Specification,
                        Other_Islamic_Loan4_Amount = model.Loan_OtherIslamicLoan4Amount,
                        Other_Islamic_Loan4_Unit_Percentage = model.Loan_OtherIslamicLoan4Unit,
                        Other_Islamic_Loan4_Ref = model.Loan_OtherIslamicLoan4Reference,

                        Other_Islamic_Loan5_Bank_Name = model.Loan_OtherIslamicLoan5BankName,
                        Other_Islamic_Loan5_Product_Type = model.Loan_OtherIslamicLoan5ProductType,
                        Other_Islamic_Loan5_Specification = model.Loan_OtherIslamicLoan5Specification,
                        Other_Islamic_Loan5_Amount = model.Loan_OtherIslamicLoan5Amount,
                        Other_Islamic_Loan5_Unit_Percentage = model.Loan_OtherIslamicLoan5Unit,
                        Other_Islamic_Loan5_Ref = model.Loan_OtherIslamicLoan5Reference,

                        Other_Islamic_Loan6_Bank_Name = model.Loan_OtherIslamicLoan6BankName,
                        Other_Islamic_Loan6_Product_Type = model.Loan_OtherIslamicLoan6ProductType,
                        Other_Islamic_Loan6_Specification = model.Loan_OtherIslamicLoan6Specification,
                        Other_Islamic_Loan6_Amount = model.Loan_OtherIslamicLoan6Amount,
                        Other_Islamic_Loan6_Unit_Percentage = model.Loan_OtherIslamicLoan6Unit,
                        Other_Islamic_Loan6_Ref = model.Loan_OtherIslamicLoan6Reference,

                        Other_Islamic_Loan7_Bank_Name = model.Loan_OtherIslamicLoan7BankName,
                        Other_Islamic_Loan7_Product_Type = model.Loan_OtherIslamicLoan7ProductType,
                        Other_Islamic_Loan7_Specification = model.Loan_OtherIslamicLoan7Specification,
                        Other_Islamic_Loan7_Amount = model.Loan_OtherIslamicLoan7Amount,
                        Other_Islamic_Loan7_Unit_Percentage = model.Loan_OtherIslamicLoan7Unit,
                        Other_Islamic_Loan7_Ref = model.Loan_OtherIslamicLoan7Reference,

                        Bank_Solicitor_ID = model.Loan_FinancingBankSolicitorID,
                        Bank_Solicitor_Firm_Phone_No = model.Loan_FinancingFirmPhone,
                        Bank_Solicitor_Email = model.Loan_FinancingEmail,
                        Bank_Solicitor_Firm_Address1 = model.Loan_FinancingFirmAddress1,
                        Bank_Solicitor_Firm_Address2 = model.Loan_FinancingFirmAddress2,
                        Bank_Solicitor_Firm_Postcode = model.Loan_FinancingFirmPostcode,
                        Bank_Solicitor_Firm_City = model.Loan_FinancingFirmTown,
                        Bank_Solicitor_Firm_State = model.Loan_FinancingFirmState,
                        Bank_Solicitor_Ref = model.Loan_FinancingSolicitorRef,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_for_loan.Add(item2);
                }

                var IndividualModel = Context.spa_loan_individual.Where(x => x.Document_ID == model.ID).FirstOrDefault();

                if (IndividualModel != null)
                {
                    IndividualModel.State_Id = model.Individual_StateID;
                    IndividualModel.Area_Id = model.Individual_AreaID;
                    IndividualModel.Condition_Type_ID = model.Individual_ConditionTypeID;
                    IndividualModel.Restriction_Type_ID = model.Individual_RestrictionTypeID;
                    IndividualModel.Building_Type_ID = model.Individual_BuildingTypeID;
                    IndividualModel.Postal_Address = model.Individual_PostalAddress;
                    IndividualModel.Tenure_Type_Id = model.Individual_TenureTypeID;
                    IndividualModel.Land_Usage_Type_Id = model.Individual_LandUsageTypeID;
                    IndividualModel.Area_Type_Id = model.Individual_AreaTypeID;
                    IndividualModel.Geran_Type_ID = model.Individual_GeranTypeID;
                    IndividualModel.Date_Open_File = model.Individual_DateOpenFile;
                }
                else if (model.Individual_StateID > 0)
                {
                    var item3 = new DbModels.spa_loan_individual()
                    {
                        Document_ID = model.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Individual",
                        State_Id = model.Individual_StateID,
                        Area_Id = model.Individual_AreaID,
                        Condition_Type_ID = model.Individual_ConditionTypeID,
                        Restriction_Type_ID = model.Individual_RestrictionTypeID,
                        Building_Type_ID = model.Individual_BuildingTypeID,
                        Postal_Address = model.Individual_PostalAddress,
                        Tenure_Type_Id = model.Individual_TenureTypeID,
                        Land_Usage_Type_Id = model.Individual_LandUsageTypeID,
                        Area_Type_Id = model.Individual_AreaTypeID,
                        Geran_Type_ID = model.Individual_GeranTypeID,
                        Date_Open_File = model.Individual_DateOpenFile,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_individual.Add(item3);
                }

                var PurchasePriceModel = Context.spa_loan_purchase_price.Where(x => x.Document_ID == model.ID).FirstOrDefault();

                if (PurchasePriceModel != null)
                {
                    if (model.ExistingBorrowerID != null)
                    {
                        var borrowerIds = model.ExistingBorrowerID.Split(',');
                        PurchasePriceModel.Existing_Borrower1_User_ID = borrowerIds[0] != null ? Convert.ToInt32(borrowerIds[0]) : 0;
                        PurchasePriceModel.Existing_Borrower2_User_ID = borrowerIds[1] != null ? Convert.ToInt32(borrowerIds[1]) : 0;
                        PurchasePriceModel.Existing_Borrower3_User_ID = borrowerIds[2] != null ? Convert.ToInt32(borrowerIds[2]) : 0;
                        PurchasePriceModel.Existing_Borrower4_User_ID = borrowerIds[3] != null ? Convert.ToInt32(borrowerIds[3]) : 0;
                        PurchasePriceModel.Existing_Borrower5_User_ID = borrowerIds[4] != null ? Convert.ToInt32(borrowerIds[4]) : 0;
                    }

                    PurchasePriceModel.Purchase_Price = model.PurchasePrice;
                    PurchasePriceModel.Earnest_Deposit = model.EarnestDeposit;
                    PurchasePriceModel.RPGT_Retention_Sum = model.RetentionSum;
                    PurchasePriceModel.Balance_Deposit = model.BalanceDeposit;
                    PurchasePriceModel.Total_Deposit = model.TotalDeposit;
                    PurchasePriceModel.Balance_Purchase_Price = model.BalancePurchasePrice;
                    PurchasePriceModel.Consuption_Tax = model.ConsumptionTax;
                    PurchasePriceModel.Purchase_Price_After_Tax = model.PurchasePriceAfterTax;
                    PurchasePriceModel.Adjustment_Rate = model.AdjustmentRate;
                    PurchasePriceModel.Bank_Branch_ID = model.BankBranchID;
                    PurchasePriceModel.Charge_Presentation_No = model.ChargePresentationNo;

                }
                else if (model.PurchasePrice > 0)
                {
                    var borrowerIds = new string[10];

                    if (!string.IsNullOrEmpty(model.ExistingBorrowerID))
                    {
                        borrowerIds = model.ExistingBorrowerID.Split(',');
                    }

                    var item4 = new DbModels.spa_loan_purchase_price()
                    {
                        Document_ID = model.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Purchase Price",
                        Purchase_Price = model.PurchasePrice,
                        Earnest_Deposit = model.EarnestDeposit,
                        RPGT_Retention_Sum = model.RetentionSum,
                        Balance_Deposit = model.BalanceDeposit,
                        Total_Deposit = model.TotalDeposit,
                        Balance_Purchase_Price = model.BalancePurchasePrice,
                        Consuption_Tax = model.ConsumptionTax,
                        Purchase_Price_After_Tax = model.PurchasePriceAfterTax,
                        Adjustment_Rate = model.AdjustmentRate,
                        Bank_Branch_ID = model.BankBranchID,
                        Charge_Presentation_No = model.ChargePresentationNo,
                        Existing_Borrower1_User_ID = borrowerIds[0] != null ? Convert.ToInt32(borrowerIds[0]) : 0,
                        Existing_Borrower2_User_ID = borrowerIds[1] != null ? Convert.ToInt32(borrowerIds[1]) : 0,
                        Existing_Borrower3_User_ID = borrowerIds[2] != null ? Convert.ToInt32(borrowerIds[2]) : 0,
                        Existing_Borrower4_User_ID = borrowerIds[3] != null ? Convert.ToInt32(borrowerIds[3]) : 0,
                        Existing_Borrower5_User_ID = borrowerIds[4] != null ? Convert.ToInt32(borrowerIds[4]) : 0,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_purchase_price.Add(item4);

                }

                var StrataModel = Context.spa_loan_strata.Where(x => x.DocumentId == model.ID).FirstOrDefault();

                if (StrataModel != null)
                {
                    StrataModel.State_Id = model.Strata_StateID;
                    StrataModel.Area_Id = model.Strata_AreaID;
                    StrataModel.Condition_Type_Id = model.Strata_ConditionTypeID;
                    StrataModel.Restriction_Type_Id = model.Strata_RestrictionTypeID;
                    StrataModel.Building_Type_Id = model.Strata_BuildingTypeID;
                    StrataModel.Postal_Address = model.Strata_PostalAddress;
                    StrataModel.Parcel_No = model.Strata_ParcelNo;
                    StrataModel.Story_No = model.Strata_StoryNo;
                    StrataModel.Building_No = model.Strata_BuildingNo;
                    StrataModel.Unit_Area = model.Strata_UnitAreaTypeID;
                    StrataModel.Tenure_Type_Id = model.Strata_TenureTypeID;
                    StrataModel.Land_Usage_Type_Id = model.Strata_LandUsageTypeID;
                    StrataModel.Area_Type_Id = model.Strata_AreaTypeID;
                    StrataModel.Geran_Type_Id = model.Strata_GeranTypeID;
                    StrataModel.Date_Open_File = model.Strata_DateOpenFile;
                    StrataModel.Parcel_No_Description = model.Strata_ParcelNoDescription;
                    StrataModel.Lot_Type_Id = model.Strata_LotTypeID;
                }
                else if (model.Strata_GeranTypeID > 0)
                {
                    var item5 = new DbModels.spa_loan_strata()
                    {
                        DocumentId = model.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Strata",
                        State_Id = model.Strata_StateID,
                        Area_Id = model.Strata_AreaID,
                        Condition_Type_Id = model.Strata_ConditionTypeID,
                        Restriction_Type_Id = model.Strata_RestrictionTypeID,
                        Building_Type_Id = model.Strata_BuildingTypeID,
                        Postal_Address = model.Strata_PostalAddress,
                        Parcel_No = model.Strata_ParcelNo,
                        Story_No = model.Strata_StoryNo,
                        Building_No = model.Strata_BuildingNo,
                        Unit_Area = model.Strata_UnitAreaTypeID,
                        Tenure_Type_Id = model.Strata_TenureTypeID,
                        Land_Usage_Type_Id = model.Strata_LandUsageTypeID,
                        Area_Type_Id = model.Strata_AreaTypeID,
                        Geran_Type_Id = model.Strata_GeranTypeID,
                        Date_Open_File = model.Strata_DateOpenFile,
                        Parcel_No_Description = model.Strata_ParcelNoDescription,
                        Lot_Type_Id = model.Strata_LotTypeID,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_strata.Add(item5);
                }

                var LoanWithoutTitleModel = Context.spa_loan_without_transfer_direct_transfer.Where(x => x.DocumentId == model.ID).FirstOrDefault();

                if (LoanWithoutTitleModel != null)
                {
                    LoanWithoutTitleModel.Story_No = model.LoanWithoutTitle_StoreyNo;
                    LoanWithoutTitleModel.Building_No = model.LoanWithoutTitle_BuildingNo;
                    LoanWithoutTitleModel.Accessory_Parcel_No = model.LoanWithoutTitle_AccessoryParcelNo;
                    LoanWithoutTitleModel.Unit_Area = model.LoanWithoutTitle_UnitArea;
                    LoanWithoutTitleModel.Developer_Id = model.LoanWithoutTitle_DeveloperID;
                    LoanWithoutTitleModel.Proprietor_Id = model.LoanWithoutTitle_ProprietorID;
                    LoanWithoutTitleModel.Project_Name = model.LoanWithoutTitle_ProjectName;
                    LoanWithoutTitleModel.Schedule_Id = model.LoanWithoutTitle_ScheduleID;
                    LoanWithoutTitleModel.Master_Title_No = model.LoanWithoutTitle_MasterTitleNo;
                    LoanWithoutTitleModel.Parcel_No = model.LoanWithoutTitle_ParcelNo;
                }
                else if (!string.IsNullOrEmpty(model.LoanWithoutTitle_ProjectName))
                {
                    var item6 = new DbModels.spa_loan_without_transfer_direct_transfer()
                    {
                        DocumentId = model.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Without Direct Transfer",
                        Story_No = model.LoanWithoutTitle_StoreyNo,
                        Building_No = model.LoanWithoutTitle_BuildingNo,
                        Accessory_Parcel_No = model.LoanWithoutTitle_AccessoryParcelNo,
                        Unit_Area = model.LoanWithoutTitle_UnitArea,
                        Developer_Id = model.LoanWithoutTitle_DeveloperID,
                        Proprietor_Id = model.LoanWithoutTitle_ProprietorID,
                        Project_Name = model.LoanWithoutTitle_ProjectName,
                        Schedule_Id = model.LoanWithoutTitle_ScheduleID,
                        Master_Title_No = model.LoanWithoutTitle_MasterTitleNo,
                        Parcel_No = model.LoanWithoutTitle_ParcelNo,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_without_transfer_direct_transfer.Add(item6);
                }
                SaveChanges();
            }
            else
            {
                // add document master
                var item = new DbModels.documentmaster()
                {
                    FileNo = model.FileNo,
                    FileType = documentTypeName,
                    FileReference = model.FileReference,
                    ClientID = model.ClientID,
                    FileOpenDate = model.FileOpenDate != "" ? DateTime.ParseExact(model.FileOpenDate, "d/MM/yyyy", null) : DateTime.MinValue,
                    PartnerID = model.PartnerID,
                    FirmID = model.FirmID,
                    Remark = model.Remark,
                    Status = model.Status,
                    RelatedFileNo = model.RelatedFileNo,
                    VendorID = model.VendorID,
                    VendorFirmID = model.VendorFirmID,
                    VendorFirmTel = model.VendorFirmTel,
                    VendorFirmEmail = model.VendorFirmEmail,
                    VendorFirmAddress1 = model.VendorFirmAddress1,
                    VendorFirmAddress2 = model.VendorFirmAddress2,
                    VendorFirmZipCode = model.VendorFirmPostcode,
                    VendorFirmCity = model.VendorFirmTown,
                    VendorFirmState = model.VendorFirmState,
                    VendorFirmFileRefNo = model.VendorFirmFileRefNo,
                    PurchaserID = model.PurchaserID,
                    PurchaserFirmID = model.PurchaserFirmID,
                    PurchaserFirmTel = model.PurchaserFirmTel,
                    PurchaserFirmEmail = model.PurchaserFirmEmail,
                    PurchaserFirmAddress1 = model.PurchaserFirmAddress1,
                    PurchaserFirmAddress2 = model.PurchaserFirmAddress2,
                    PurchaserFirmZipCode = model.PurchaserFirmPostcode,
                    PurchaserFirmCity = model.PurchaserFirmTown,
                    PurchaserFirmState = model.PurchaserFirmState,
                    PurchaserFirmFileRefNo = model.PurchaserFirmFileRefNo,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = DateTime.Now
                };

                Context.documentmasters.Add(item);

                SaveChanges();

                if (model.COO_Purchaser1ID > 0)
                {
                    // add other forms 
                    var item1 = new DbModels.spa_loan_chain_of_ownership()
                    {
                        DocumentId = item.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Chain of Ownership",
                        Purchaser1_User_ID = model.COO_Purchaser1ID,
                        Purchaser1_DOA_Date = model.COO_Purchaser1DOADate,
                        Purchaser1_FA_Date = model.COO_Purchaser1FADate,
                        Purchaser1_Loan_Date = model.COO_Purchaser1LoanDOA,
                        Purchaser1_DRR_Date = model.COO_Purchaser1DRRDate,

                        Purchaser2_User_ID = model.COO_Purchaser2ID,
                        Purchaser2_DOA_Date = model.COO_Purchaser2DOADate,
                        Purchaser2_FA_Date = model.COO_Purchaser2FADate,
                        Purchaser2_Loan_Date = model.COO_Purchaser2LoanDOA,
                        Purchaser2_DRR_Date = model.COO_Purchaser2DRRDate,

                        Purchaser3_User_ID = model.COO_Purchaser3ID,
                        Purchaser3_DOA_Date = model.COO_Purchaser3DOADate,
                        Purchaser3_FA_Date = model.COO_Purchaser3FADate,
                        Purchaser3_Loan_Date = model.COO_Purchaser3LoanDOA,
                        Purchaser3_DRR_Date = model.COO_Purchaser3DRRDate,

                        Purchaser4_User_ID = model.COO_Purchaser4ID,
                        Purchaser4_DOA_Date = model.COO_Purchaser4DOADate,
                        Purchaser4_FA_Date = model.COO_Purchaser4FADate,
                        Purchaser4_Loan_Date = model.COO_Purchaser4LoanDOA,
                        Purchaser4_DRR_Date = model.COO_Purchaser4DRRDate,

                        Purchaser5_User_ID = model.COO_Purchaser5ID,
                        Purchaser5_DOA_Date = model.COO_Purchaser5DOADate,
                        Purchaser5_FA_Date = model.COO_Purchaser5FADate,
                        Purchaser5_Loan_Date = model.COO_Purchaser5LoanDOA,
                        Purchaser5_DRR_Date = model.COO_Purchaser5DRRDate,

                        Purchaser6_User_ID = model.COO_Purchaser6ID,
                        Purchaser6_DOA_Date = model.COO_Purchaser6DOADate,
                        Purchaser6_FA_Date = model.COO_Purchaser6FADate,
                        Purchaser6_Loan_Date = model.COO_Purchaser6LoanDOA,
                        Purchaser6_DRR_Date = model.COO_Purchaser6DRRDate,

                        Purchaser7_User_ID = model.COO_Purchaser7ID,
                        Purchaser7_DOA_Date = model.COO_Purchaser7DOADate,
                        Purchaser7_FA_Date = model.COO_Purchaser7FADate,
                        Purchaser7_Loan_Date = model.COO_Purchaser7LoanDOA,
                        Purchaser7_DRR_Date = model.COO_Purchaser7DRRDate,

                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_chain_of_ownership.Add(item1);
                }

                if (model.Loan_Borrower1ID > 0)
                {
                    var item2 = new DbModels.spa_loan_for_loan()
                    {
                        DocumentId = item.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "For Loan",
                        Borrower1_User_ID = model.Loan_Borrower1ID,
                        Borrower2_User_ID = model.Loan_Borrower2ID,
                        Borrower3_User_ID = model.Loan_Borrower3ID,
                        Borrower4_User_ID = model.Loan_Borrower4ID,
                        Borrower5_User_ID = model.Loan_Borrower5ID,
                        Guarantor1_User_ID = model.Loan_Guarantor1ID,
                        Guarantor2_User_ID = model.Loan_Guarantor2ID,
                        Guarantor3_User_ID = model.Loan_Guarantor3ID,
                        Guarantor4_User_ID = model.Loan_Guarantor4ID,
                        Guarantor5_User_ID = model.Loan_Guarantor5ID,
                        Bank_Branch_ID = model.Loan_BranchID,
                        Bank_Reference = model.Loan_BankReference,
                        Offer_Letter_Date = model.Loan_LetterOfOfferDate,
                        Letter_of_Instruction_Date = model.Loan_LetterOfInstructionDate,
                        Officer1_Id = model.Loan_Officer1ID,
                        Officer1_Username = model.Loan_Officer1Username,
                        Officer1_Password = model.Loan_Officer1Password,
                        Officer2_Id = model.Loan_Officer2ID,
                        Officer2_Username = model.Loan_Officer2Username,
                        Officer2_Password = model.Loan_Officer2Password,
                        Conventional_Loan_Type = model.Loan_ConventionalLoanTypeID,
                        Conventional_Financing_Type = model.Loan_ConventionalFinancingTypeID,
                        Conventional_Loan_Amount = model.Loan_ConventionalLoanAmount,
                        Other_Loan1_Type = model.Loan_ConventionalOtherLoanItem1,
                        Other_Loan1_Amount = model.Loan_ConventionalOtherLoanAmount1,
                        Other_Loan2_Type = model.Loan_ConventionalOtherLoanItem2,
                        Other_Loan2_Amount = model.Loan_ConventionalOtherLoanAmount2,
                        Other_Loan3_Type = model.Loan_ConventionalOtherLoanItem3,
                        Other_Loan3_Amount = model.Loan_ConventionalOtherLoanAmount3,
                        Other_Loan4_Type = model.Loan_ConventionalOtherLoanItem4,
                        Other_Loan4_Amount = model.Loan_ConventionalOtherLoanAmount4,
                        Other_Loan5_Type = model.Loan_ConventionalOtherLoanItem5,
                        Other_Loan5_Amount = model.Loan_ConventionalOtherLoanAmount5,
                        Conventional_Loan_Total_Financing_Sum = model.Loan_ConventionalTotalFinancingSum,
                        Islamic_Loan_Type = model.Loan_IslamicLoanTypeID,
                        Islamic_Financing_Type = model.Loan_IslamicFinancingTypeID,
                        Islamic_Financing_Amount = model.Loan_IslamicAmount,
                        Other_Financing1_Type = model.Loan_IslamicOtherFinancingItem1,
                        Other_Financing1_Amount = model.Loan_IslamicOtherFinancingAmount1,
                        Other_Financing2_Type = model.Loan_IslamicOtherFinancingItem2,
                        Other_Financing2_Amount = model.Loan_IslamicOtherFinancingAmount2,
                        Other_Financing3_Type = model.Loan_IslamicOtherFinancingItem3,
                        Other_Financing3_Amount = model.Loan_IslamicOtherFinancingAmount3,
                        Other_Financing4_Type = model.Loan_IslamicOtherFinancingItem4,
                        Other_Financing4_Amount = model.Loan_IslamicOtherFinancingAmount4,
                        Other_Financing5_Type = model.Loan_IslamicOtherFinancingItem5,
                        Other_Financing5_Amount = model.Loan_IslamicOtherFinancingAmount5,
                        Islamic_Loan_Total_Financing_Sum = model.Loan_IslamicTotalFinancingSum,
                        Bank_Selling_Price = model.Loan_IslamicBankSellingPrice,
                        Bank_Purchase_Price = model.Loan_IslamicBankPurchasePrice,

                        Other_Islamic_Loan1_Bank_Name = model.Loan_OtherIslamicLoan1BankName,
                        Other_Islamic_Loan1_Product_Type = model.Loan_OtherIslamicLoan1ProductType,
                        Other_Islamic_Loan1_Specification = model.Loan_OtherIslamicLoan1Specification,
                        Other_Islamic_Loan1_Amount = model.Loan_OtherIslamicLoan1Amount,
                        Other_Islamic_Loan1_Unit_Percentage = model.Loan_OtherIslamicLoan1Unit,
                        Other_Islamic_Loan1_Ref = model.Loan_OtherIslamicLoan1Reference,

                        Other_Islamic_Loan2_Bank_Name = model.Loan_OtherIslamicLoan2BankName,
                        Other_Islamic_Loan2_Product_Type = model.Loan_OtherIslamicLoan2ProductType,
                        Other_Islamic_Loan2_Specification = model.Loan_OtherIslamicLoan2Specification,
                        Other_Islamic_Loan2_Amount = model.Loan_OtherIslamicLoan2Amount,
                        Other_Islamic_Loan2_Unit_Percentage = model.Loan_OtherIslamicLoan2Unit,
                        Other_Islamic_Loan2_Ref = model.Loan_OtherIslamicLoan2Reference,

                        Other_Islamic_Loan3_Bank_Name = model.Loan_OtherIslamicLoan3BankName,
                        Other_Islamic_Loan3_Product_Type = model.Loan_OtherIslamicLoan3ProductType,
                        Other_Islamic_Loan3_Specification = model.Loan_OtherIslamicLoan3Specification,
                        Other_Islamic_Loan3_Amount = model.Loan_OtherIslamicLoan3Amount,
                        Other_Islamic_Loan3_Unit_Percentage = model.Loan_OtherIslamicLoan3Unit,
                        Other_Islamic_Loan3_Ref = model.Loan_OtherIslamicLoan3Reference,

                        Other_Islamic_Loan4_Bank_Name = model.Loan_OtherIslamicLoan4BankName,
                        Other_Islamic_Loan4_Product_Type = model.Loan_OtherIslamicLoan4ProductType,
                        Other_Islamic_Loan4_Specification = model.Loan_OtherIslamicLoan4Specification,
                        Other_Islamic_Loan4_Amount = model.Loan_OtherIslamicLoan4Amount,
                        Other_Islamic_Loan4_Unit_Percentage = model.Loan_OtherIslamicLoan4Unit,
                        Other_Islamic_Loan4_Ref = model.Loan_OtherIslamicLoan4Reference,

                        Other_Islamic_Loan5_Bank_Name = model.Loan_OtherIslamicLoan5BankName,
                        Other_Islamic_Loan5_Product_Type = model.Loan_OtherIslamicLoan5ProductType,
                        Other_Islamic_Loan5_Specification = model.Loan_OtherIslamicLoan5Specification,
                        Other_Islamic_Loan5_Amount = model.Loan_OtherIslamicLoan5Amount,
                        Other_Islamic_Loan5_Unit_Percentage = model.Loan_OtherIslamicLoan5Unit,
                        Other_Islamic_Loan5_Ref = model.Loan_OtherIslamicLoan5Reference,

                        Other_Islamic_Loan6_Bank_Name = model.Loan_OtherIslamicLoan6BankName,
                        Other_Islamic_Loan6_Product_Type = model.Loan_OtherIslamicLoan6ProductType,
                        Other_Islamic_Loan6_Specification = model.Loan_OtherIslamicLoan6Specification,
                        Other_Islamic_Loan6_Amount = model.Loan_OtherIslamicLoan6Amount,
                        Other_Islamic_Loan6_Unit_Percentage = model.Loan_OtherIslamicLoan6Unit,
                        Other_Islamic_Loan6_Ref = model.Loan_OtherIslamicLoan6Reference,

                        Other_Islamic_Loan7_Bank_Name = model.Loan_OtherIslamicLoan7BankName,
                        Other_Islamic_Loan7_Product_Type = model.Loan_OtherIslamicLoan7ProductType,
                        Other_Islamic_Loan7_Specification = model.Loan_OtherIslamicLoan7Specification,
                        Other_Islamic_Loan7_Amount = model.Loan_OtherIslamicLoan7Amount,
                        Other_Islamic_Loan7_Unit_Percentage = model.Loan_OtherIslamicLoan7Unit,
                        Other_Islamic_Loan7_Ref = model.Loan_OtherIslamicLoan7Reference,

                        Bank_Solicitor_ID = model.Loan_FinancingBankSolicitorID,
                        Bank_Solicitor_Firm_Phone_No = model.Loan_FinancingFirmPhone,
                        Bank_Solicitor_Email = model.Loan_FinancingEmail,
                        Bank_Solicitor_Firm_Address1 = model.Loan_FinancingFirmAddress1,
                        Bank_Solicitor_Firm_Address2 = model.Loan_FinancingFirmAddress2,
                        Bank_Solicitor_Firm_Postcode = model.Loan_FinancingFirmPostcode,
                        Bank_Solicitor_Firm_City = model.Loan_FinancingFirmTown,
                        Bank_Solicitor_Firm_State = model.Loan_FinancingFirmState,
                        Bank_Solicitor_Ref = model.Loan_FinancingSolicitorRef,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_for_loan.Add(item2);
                }

                if (model.Individual_StateID > 0)
                {
                    var item3 = new DbModels.spa_loan_individual()
                    {
                        Document_ID = item.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Individual",
                        State_Id = model.Individual_StateID,
                        Area_Id = model.Individual_AreaID,
                        Condition_Type_ID = model.Individual_ConditionTypeID,
                        Restriction_Type_ID = model.Individual_RestrictionTypeID,
                        Building_Type_ID = model.Individual_BuildingTypeID,
                        Postal_Address = model.Individual_PostalAddress,
                        Tenure_Type_Id = model.Individual_TenureTypeID,
                        Land_Usage_Type_Id = model.Individual_LandUsageTypeID,
                        Area_Type_Id = model.Individual_AreaTypeID,
                        Geran_Type_ID = model.Individual_GeranTypeID,
                        Date_Open_File = model.Individual_DateOpenFile,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_individual.Add(item3);
                }

                if (model.PurchasePrice > 0)
                {
                    var borrowerIds = new string[10];

                    if (!string.IsNullOrEmpty(model.ExistingBorrowerID))
                    {
                        borrowerIds = model.ExistingBorrowerID.Split(',');
                    }

                    var item4 = new DbModels.spa_loan_purchase_price()
                    {
                        Document_ID = item.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Purchase Price",
                        Purchase_Price = model.PurchasePrice,
                        Earnest_Deposit = model.EarnestDeposit,
                        RPGT_Retention_Sum = model.RetentionSum,
                        Balance_Deposit = model.BalanceDeposit,
                        Total_Deposit = model.TotalDeposit,
                        Balance_Purchase_Price = model.BalancePurchasePrice,
                        Consuption_Tax = model.ConsumptionTax,
                        Purchase_Price_After_Tax = model.PurchasePriceAfterTax,
                        Adjustment_Rate = model.AdjustmentRate,
                        Bank_Branch_ID = model.BankBranchID,
                        Charge_Presentation_No = model.ChargePresentationNo,
                        Existing_Borrower1_User_ID = borrowerIds[0] != null ? Convert.ToInt32(borrowerIds[0]) : 0,
                        Existing_Borrower2_User_ID = borrowerIds[1] != null ? Convert.ToInt32(borrowerIds[1]) : 0,
                        Existing_Borrower3_User_ID = borrowerIds[2] != null ? Convert.ToInt32(borrowerIds[2]) : 0,
                        Existing_Borrower4_User_ID = borrowerIds[3] != null ? Convert.ToInt32(borrowerIds[3]) : 0,
                        Existing_Borrower5_User_ID = borrowerIds[4] != null ? Convert.ToInt32(borrowerIds[4]) : 0,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_purchase_price.Add(item4);
                }

                if (model.Strata_GeranTypeID > 0)
                {
                    var item5 = new DbModels.spa_loan_strata()
                    {
                        DocumentId = item.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Strata",
                        State_Id = model.Strata_StateID,
                        Area_Id = model.Strata_AreaID,
                        Condition_Type_Id = model.Strata_ConditionTypeID,
                        Restriction_Type_Id = model.Strata_RestrictionTypeID,
                        Building_Type_Id = model.Strata_BuildingTypeID,
                        Postal_Address = model.Strata_PostalAddress,
                        Parcel_No = model.Strata_ParcelNo,
                        Story_No = model.Strata_StoryNo,
                        Building_No = model.Strata_BuildingNo,
                        Unit_Area = model.Strata_UnitAreaTypeID,
                        Tenure_Type_Id = model.Strata_TenureTypeID,
                        Land_Usage_Type_Id = model.Strata_LandUsageTypeID,
                        Area_Type_Id = model.Strata_AreaTypeID,
                        Geran_Type_Id = model.Strata_GeranTypeID,
                        Date_Open_File = model.Strata_DateOpenFile,
                        Parcel_No_Description = model.Strata_ParcelNoDescription,
                        Lot_Type_Id = model.Strata_LotTypeID,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_strata.Add(item5);
                }

                if (!string.IsNullOrEmpty(model.LoanWithoutTitle_ProjectName))
                {
                    var item6 = new DbModels.spa_loan_without_transfer_direct_transfer()
                    {
                        DocumentId = item.ID,
                        Document_Type_Name = documentTypeName,
                        Document_Agreement_Name = "Loan Without Direct Transfer",
                        Story_No = model.LoanWithoutTitle_StoreyNo,
                        Building_No = model.LoanWithoutTitle_BuildingNo,
                        Accessory_Parcel_No = model.LoanWithoutTitle_AccessoryParcelNo,
                        Unit_Area = model.LoanWithoutTitle_UnitArea,
                        Developer_Id = model.LoanWithoutTitle_DeveloperID,
                        Proprietor_Id = model.LoanWithoutTitle_ProprietorID,
                        Project_Name = model.LoanWithoutTitle_ProjectName,
                        Schedule_Id = model.LoanWithoutTitle_ScheduleID,
                        Master_Title_No = model.LoanWithoutTitle_MasterTitleNo,
                        Parcel_No = model.LoanWithoutTitle_ParcelNo,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                    };

                    Context.spa_loan_without_transfer_direct_transfer.Add(item6);
                }

                //add workflow 
                if (model.ChecklistID != "")
                {
                    var checklistId = Convert.ToInt32(model.ChecklistID);

                    var wfmasters = Context.workflowmasters.Where(x => x.ID == checklistId).ToList();
                    if (wfmasters.Count > 0)
                    {
                        foreach (var wfmaster in wfmasters)
                        {
                            var wfdetails = Context.workflowdetails.Where(x => x.WorkflowMasterID == wfmaster.ID).ToList();
                            var dueDate = 0;
                            if (wfdetails.Count > 0)
                            {
                                foreach (var wfdetail in wfdetails)
                                {
                                    dueDate += wfdetail.Duration;
                                    // add workflow 
                                    var wfitem = new DbModels.documentworkflow()
                                    {
                                        DocumentID = item.ID,
                                        WorkflowDetailID = wfdetail.ID,
                                        Sequence = wfdetail.Sequence.Value,
                                        UserID = model.ClientID,
                                        DueDate = DateTime.Now.AddDays(dueDate),
                                        isCompleted = 0,
                                        isRPA = 0,
                                        CreatedBy = model.CreatedBy,
                                        CreatedDate = DateTime.Now
                                    };

                                    Context.documentworkflows.Add(wfitem);
                                }
                            }
                        }
                    }
                }

                SaveChanges();
            }

            return "OK";
        }

        public string GetLatestBatchNo()
        {
            var q = Context.documentmasters.ToList().LastOrDefault().FileNo;

            return q;
        }

    }
}