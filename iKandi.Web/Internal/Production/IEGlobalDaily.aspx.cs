using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;

namespace iKandi.Web.Internal.Production
{
    public partial class IEGlobalDaily : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }


        protected void Bind()
        {
            DataSet ds = objProductionController.GetBIPLGlobalDailyIE();
            DataTable dt = ds.Tables[0];

            //new code start

            txtCutQty_C45_46.Text = float.Parse(dt.Rows[0]["CutQty_C45"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutQty_C45"].ToString();
            txtFinishedQty_C45_46.Text = float.Parse(dt.Rows[0]["FinishedQty_C45"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedQty_C45"].ToString();
            txtStitchedQty_C45_46.Text = float.Parse(dt.Rows[0]["StitchedQty_C45"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchedQty_C45"].ToString();

            txtCutQty_C47.Text = float.Parse(dt.Rows[0]["CutQty_C47"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutQty_C47"].ToString();
            txtFinishedQty_C47.Text = float.Parse(dt.Rows[0]["FinishedQty_C47"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedQty_C47"].ToString();
            txtStitchedQty_C47.Text = float.Parse(dt.Rows[0]["StitchedQty_C47"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchedQty_C47"].ToString();

            txtCutQty_D169.Text = float.Parse(dt.Rows[0]["CutQty_D169"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutQty_D169"].ToString();
            txtFinishedQty_D169.Text = float.Parse(dt.Rows[0]["FinishedQty_D169"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedQty_D169"].ToString();
            txtStitchedQty_D169.Text = float.Parse(dt.Rows[0]["StitchedQty_D169"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchedQty_D169"].ToString();

            //txtCutQty_C52.Text = float.Parse(dt.Rows[0]["CutQty_C52"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutQty_C52"].ToString();
            //txtFinishedQty_C52.Text = float.Parse(dt.Rows[0]["FinishedQty_C52"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedQty_C52"].ToString();
            //txtStitchedQty_C52.Text = float.Parse(dt.Rows[0]["StitchedQty_C52"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchedQty_C52"].ToString();

            txtCutQty.Text = float.Parse(dt.Rows[0]["CutQty"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutQty"].ToString();
            txtFinishedQty.Text = float.Parse(dt.Rows[0]["FinishedQty"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedQty"].ToString();
            txtStitchedQty.Text = float.Parse(dt.Rows[0]["StitchedQty"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchedQty"].ToString();

            //new code end

            txtCutRate_C45_46.Text = float.Parse(dt.Rows[0]["CutRate_C45_46"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutRate_C45_46"].ToString();
            txtFinishingRate_C45_46.Text = float.Parse(dt.Rows[0]["FinishedRate_C45_46"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedRate_C45_46"].ToString();
            txtStitching_C45_46.Text = float.Parse(dt.Rows[0]["StitchingEfficiency_C45_46"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchingEfficiency_C45_46"].ToString();
            txtAchievement_C45_46.Text = float.Parse(dt.Rows[0]["achievement_C45_46"].ToString()) == 0 ? string.Empty : dt.Rows[0]["achievement_C45_46"].ToString();

            txtCutRate_C47.Text = float.Parse(dt.Rows[0]["CutRate_C47"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutRate_C47"].ToString();
            txtFinishingRate_C47.Text = float.Parse(dt.Rows[0]["FinishedRate_C47"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedRate_C47"].ToString();
            txtStitching_C47.Text = float.Parse(dt.Rows[0]["StitchingEfficiency_C47"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchingEfficiency_C47"].ToString();
            txtAchievement_C47.Text = float.Parse(dt.Rows[0]["achievement_C47"].ToString()) == 0 ? string.Empty : dt.Rows[0]["achievement_C47"].ToString();

            txtCutRate_D169.Text = float.Parse(dt.Rows[0]["CutRate_D169"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutRate_D169"].ToString();
            txtFinishingRate_D169.Text = float.Parse(dt.Rows[0]["FinishedRate_D169"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedRate_D169"].ToString();
            txtStitching_D169.Text = float.Parse(dt.Rows[0]["StitchingEfficiency_D169"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchingEfficiency_D169"].ToString();
            txtAchievement_D169.Text = float.Parse(dt.Rows[0]["achievement_D169"].ToString()) == 0 ? string.Empty : dt.Rows[0]["achievement_D169"].ToString();

            //txtCutRate_C52.Text = float.Parse(dt.Rows[0]["CutRate_C52"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutRate_C52"].ToString();
            //txtFinishingRate_C52.Text = float.Parse(dt.Rows[0]["FinishedRate_C52"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedRate_C52"].ToString();
            //txtStitching_C52.Text = float.Parse(dt.Rows[0]["StitchingEfficiency_C52"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchingEfficiency_C52"].ToString();
            //txtAchievement_C52.Text = float.Parse(dt.Rows[0]["achievement_C52"].ToString()) == 0 ? string.Empty : dt.Rows[0]["achievement_C52"].ToString();

            txtCutRate_BIPL.Text = float.Parse(dt.Rows[0]["CutRate"].ToString()) == 0 ? string.Empty : dt.Rows[0]["CutRate"].ToString();
            txtFinishingRate_BIPL.Text = float.Parse(dt.Rows[0]["FinishedRate"].ToString()) == 0 ? string.Empty : dt.Rows[0]["FinishedRate"].ToString();
            txtStitching_BIPL.Text = float.Parse(dt.Rows[0]["StitchingEfficiency"].ToString()) == 0 ? string.Empty : dt.Rows[0]["StitchingEfficiency"].ToString();
            txtAchievement_BIPL.Text = float.Parse(dt.Rows[0]["achievement"].ToString()) == 0 ? string.Empty : dt.Rows[0]["achievement"].ToString();
            chkTaskClose.Checked  = Convert.ToBoolean(dt.Rows[0]["TaskClosed"]);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (txtCutRate_BIPL.Text != string.Empty)
            //    CutRate_BIPL = float.Parse(txtCutRate_BIPL.Text);
            //if (txtFinishingRate_BIPL.Text != string.Empty)
            //    FinishedRate_BIPL = float.Parse(txtFinishingRate_BIPL.Text);
            //if (txtStitching_BIPL.Text != string.Empty)
            //    StitchingEfficiency_BIPL = float.Parse(txtStitching_BIPL.Text);

            int BIPLGlobalIEEntryId = objProductionController.SaveBIPLGlobalDailyIE(
                float.Parse(txtCutQty_C45_46.Text != string.Empty ? txtCutQty_C45_46.Text : "0"), float.Parse(txtFinishedQty_C45_46.Text != string.Empty ? txtFinishedQty_C45_46.Text : "0"), float.Parse(txtStitchedQty_C45_46.Text != string.Empty ? txtStitchedQty_C45_46.Text : "0"),
                float.Parse(txtCutQty_C47.Text != string.Empty ? txtCutQty_C47.Text : "0"), float.Parse(txtFinishedQty_C47.Text != string.Empty ? txtFinishedQty_C47.Text : "0"), float.Parse(txtStitchedQty_C47.Text != string.Empty ? txtStitchedQty_C47.Text : "0"),
                float.Parse(txtCutQty_D169.Text != string.Empty ? txtCutQty_D169.Text : "0"), float.Parse(txtFinishedQty_D169.Text != string.Empty ? txtFinishedQty_D169.Text : "0"), float.Parse(txtStitchedQty_D169.Text != string.Empty ? txtStitchedQty_D169.Text : "0"),
                float.Parse(txtCutQty.Text != string.Empty ? txtCutQty.Text : "0"), float.Parse(txtFinishedQty.Text != string.Empty ? txtFinishedQty.Text : "0"), float.Parse(txtStitchedQty.Text != string.Empty ? txtStitchedQty.Text : "0"),
                float.Parse(txtCutRate_C45_46.Text != string.Empty ? txtCutRate_C45_46.Text : "0"), float.Parse(txtFinishingRate_C45_46.Text != string.Empty ? txtFinishingRate_C45_46.Text : "0"), float.Parse(txtStitching_C45_46.Text != string.Empty ? txtStitching_C45_46.Text : "0"), float.Parse(txtAchievement_C45_46.Text != string.Empty ? txtAchievement_C45_46.Text : "0"),
                float.Parse(txtCutRate_C47.Text != string.Empty ? txtCutRate_C47.Text : "0"), float.Parse(txtFinishingRate_C47.Text != string.Empty ? txtFinishingRate_C47.Text : "0"), float.Parse(txtStitching_C47.Text != string.Empty ? txtStitching_C47.Text : "0"), float.Parse(txtAchievement_C47.Text != string.Empty ? txtAchievement_C47.Text : "0"),
                float.Parse(txtCutRate_D169.Text != string.Empty ? txtCutRate_D169.Text : "0"), float.Parse(txtFinishingRate_D169.Text != string.Empty ? txtFinishingRate_D169.Text : "0"), float.Parse(txtStitching_D169.Text != string.Empty ? txtStitching_D169.Text : "0"), float.Parse(txtAchievement_D169.Text != string.Empty ? txtAchievement_D169.Text : "0"),
                float.Parse(txtCutRate_BIPL.Text != string.Empty ? txtCutRate_BIPL.Text : "0"), float.Parse(txtFinishingRate_BIPL.Text != string.Empty ? txtFinishingRate_BIPL.Text : "0"), float.Parse(txtStitching_BIPL.Text != string.Empty ? txtStitching_BIPL.Text : "0"), float.Parse(txtAchievement_BIPL.Text != string.Empty ? txtAchievement_BIPL.Text : "0"), chkTaskClose.Checked
                );
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);

            Bind();
        }


    }
}