using MAT;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.SystemSetting
{
    public class Manager : DbModels.BaseManager
    {
        public ActionResult Update(CompanyProfileViewModel model)
        {
            var cp = Context.firmprofiles.Find(model.ID);
            cp.firm_name = model.firm_name;
            cp.add1 = model.add1;
            cp.add2 = model.add2;
            cp.add3 = model.add3;
            cp.add4 = model.add4;
            cp.postcode = model.postcode;
            cp.Town = model.Town;
            cp.state = model.state;
            cp.Country = model.Country;
            cp.phone1 = model.phone1;
            cp.phone2 = model.phone2;
            cp.phone3 = model.phone3;
            cp.fax1 = model.fax1;
            cp.fax2 = model.fax2;
            cp.email = model.fax2;
            cp.irb_no = model.irb_no;
            cp.irb_branch = model.irb_branch;
            cp.socso_no = model.socso_no;
            cp.socso_branch = model.socso_branch;
            cp.epf_no = model.epf_no;
            cp.epf_branch = model.epf_branch;
            cp.gst_sst_no = model.gst_sst_no;
            cp.freefield1 = model.freefield1;
            cp.freefield2 = model.freefield2;
            cp.freefield3 = model.freefield3;
            cp.freefield4 = model.freefield4;
            cp.freefield5 = model.freefield5;

            return ActionResult.SucceededResult;
        }

        public virtual CompanyProfileViewModel Get(int Id = 1)
        {
            try
            {

                var q = (from model in Context.firmprofiles
                         where model.ID == Id
                         select new CompanyProfileViewModel
                         {
                             ID = model.ID,
                             firm_name = model.firm_name,
                             add1 = model.add1,
                             add2 = model.add2,
                             add3 = model.add3,
                             add4 = model.add4,
                             postcode = model.postcode,
                             Town = model.Town,
                             state = model.state,
                             Country = model.Country,
                             phone1 = model.phone1,
                             phone2 = model.phone2,
                             phone3 = model.phone3,
                             fax1 = model.fax1,
                             fax2 = model.fax2,
                             email = model.fax2,
                             irb_no = model.irb_no,
                             irb_branch = model.irb_branch,
                             socso_no = model.socso_no,
                             socso_branch = model.socso_branch,
                             epf_no = model.epf_no,
                             epf_branch = model.epf_branch,
                             gst_sst_no = model.gst_sst_no,
                             freefield1 = model.freefield1,
                             freefield2 = model.freefield2,
                             freefield3 = model.freefield3,
                             freefield4 = model.freefield4,
                             freefield5 = model.freefield5,
                         }).FirstOrDefault();
                return q;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IQueryable<CompanyProfileViewModel> List()
        {
            var q = (from model in Context.firmprofiles
                     select new CompanyProfileViewModel
                     {
                         ID = model.ID,
                         add1 = model.add1,
                         add2 = model.add2,
                         add3 = model.add3,
                         add4 = model.add4,
                         postcode = model.postcode,
                         Town = model.Town,
                         state = model.state,
                         Country = model.Country,
                         phone1 = model.phone1,
                         phone2 = model.phone2,
                         phone3 = model.phone3,
                         fax1 = model.fax1,
                         fax2 = model.fax2,
                         email = model.fax2,
                         irb_no = model.irb_no,
                         irb_branch = model.irb_branch,
                         socso_no = model.socso_no,
                         socso_branch = model.socso_branch,
                         epf_no = model.epf_no,
                         epf_branch = model.epf_branch,
                         gst_sst_no = model.gst_sst_no,
                         freefield1 = model.freefield1,
                         freefield2 = model.freefield2,
                         freefield3 = model.freefield3,
                         freefield4 = model.freefield4,
                         freefield5 = model.freefield5,
                     });


            return q;
        }

        public String Save(CompanyProfileViewModel model)
        {

            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.ID > 0)
            {
                var firmModel = Context.firmprofiles.Find(model.ID);
                firmModel.firm_name = model.firm_name;
                firmModel.add1 = model.add1;
                firmModel.add2 = model.add2;
                firmModel.add3 = model.add3;
                firmModel.add4 = model.add4;
                firmModel.postcode = model.postcode;
                firmModel.Town = model.Town;
                firmModel.state = model.state;
                firmModel.Country = model.Country;
                firmModel.phone1 = model.phone1;
                firmModel.phone2 = model.phone2;
                firmModel.phone3 = model.phone3;
                firmModel.fax1 = model.fax1;
                firmModel.fax2 = model.fax2;
                firmModel.email = model.fax2;
                firmModel.irb_no = model.irb_no;
                firmModel.irb_branch = model.irb_branch;
                firmModel.socso_no = model.socso_no;
                firmModel.socso_branch = model.socso_branch;
                firmModel.epf_no = model.epf_no;
                firmModel.epf_branch = model.epf_branch;
                firmModel.gst_sst_no = model.gst_sst_no;
                firmModel.freefield1 = model.freefield1;
                firmModel.freefield2 = model.freefield2;
                firmModel.freefield3 = model.freefield3;
                firmModel.freefield4 = model.freefield4;
                firmModel.freefield5 = model.freefield5;
                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.firmprofile
                {
                    firm_name = model.firm_name,
                    add1 = model.add1,
                    add2 = model.add2,
                    add3 = model.add3,
                    add4 = model.add4,
                    postcode = model.postcode,
                    Town = model.Town,
                    state = model.state,
                    Country = model.Country,
                    phone1 = model.phone1,
                    phone2 = model.phone2,
                    phone3 = model.phone3,
                    fax1 = model.fax1,
                    fax2 = model.fax2,
                    email = model.fax2,
                    irb_no = model.irb_no,
                    irb_branch = model.irb_branch,
                    socso_no = model.socso_no,
                    socso_branch = model.socso_branch,
                    epf_no = model.epf_no,
                    epf_branch = model.epf_branch,
                    gst_sst_no = model.gst_sst_no,
                    freefield1 = model.freefield1,
                    freefield2 = model.freefield2,
                    freefield3 = model.freefield3,
                    freefield4 = model.freefield4,
                    freefield5 = model.freefield5
            };
                Context.firmprofiles.Add(item);
                SaveChanges();
            }

            return "OK";
        }
    }

}
