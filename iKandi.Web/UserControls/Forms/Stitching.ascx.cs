using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using System.Configuration;

namespace iKandi.Web.UserControls.Forms
{
    public partial class Stitching : System.Web.UI.UserControl
    {
        DataSet dsMachine = new DataSet();
        DataTable dtBindGrid = new DataTable();
        DataTable dtGarmentType = new DataTable();
        DataTable dtmerge = new DataTable();
        //Finishing
        DataSet dsMachineFinishing = new DataSet();
        DataTable dtBindGridFinishing = new DataTable();
        DataTable dtGarmentTypeFinishing = new DataTable();
        DataTable dtmergeFinishing = new DataTable();
        DataSet dtMachine = new DataSet();

        //added by abhishek on 24/10/2015
        int OprationCountfront = 0;
        int OprationCountBack = 0;
        int OprationCountcoller = 0;
        int OprationCountsleep = 0;
        int OprationCountneck = 0;
        int OprationCountLining = 0;
        int OprationCountlower = 0;
        int OprationCountbottom = 0;
        int OprationCountassembly = 0;
        int OprationCountPiping = 0;
        int OprationCountUppershell = 0;
        int OprationCountUppersection = 0;
        int OprationCountLowershell = 0;
        int OprationCountShellsection = 0;
        int OprationCountWaistSection = 0;
        int OprationCountBandsection = 0;
        int finishingOb = 0;
        int OprationCountNeckSection = 0;
        int OprationCountNecFaching = 0;
        int OprationCountf_back = 0;

        string serachtxt = string.Empty;

        AdminController obj_AdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {





            if (!IsPostBack)
            {





                if (rbtnlistsection.SelectedValue == "1")
                {
                    ddlStitchSection.Visible = true;
                }

                AddStitchColumn();

                //BindStichedGrd("");
                StitchGridShowHide(2);

                //OprationCountfront = 0;
                //BindGrid("");


                ////lblStitching.Text = "Front" + " " + "(Total number of opration:" + OprationCountfront + ")";
                ////btnAdd.Visible = true;
                // btnadd_font.Visible = true;
                ////grdStitchingFont.Visible = true;
                //divfront.Visible = true;
                //trFront.Visible = true;



                trFinishing.Visible = false;
                divFinishing.Visible = false;

                //Single Add gridview for all section boundfiled creation
                BindAddSleep_Add();
                BindAddBack_add();
                BindAddColler_Add();
                BindAddNeck_Add();
                BindAddlining_Add();
                BindAddAssembly();
                BindAddlower_Add();
                BindAddbottom_add();
                BindAddPiping_Add();
                BindAddUpper_Add();
                BindAddUppershell_Add();
                BindAddLowershell_Add();
                BindAddShellsection_Add();
                BindAddWaistSection_Add();
                BindAddBandsection_Add();
                BindAddnecksection_Add();
                BindAddneckfaching_Add();
                BindAddf_back_Add();
                BindAddFront_Add();



                /*for first time load front Add opration gridview*/
                lblStitching.Text = "Front";
                BindFrontAdd();
                StitchGridShowHide(2);
                trFront.Visible = true;
                DivFront_Add.Visible = true;
                DivFrontlist_Add.Visible = true;
                //end

            }

        }

        protected void AddStitchColumn()
        {
            /*modifie here GetFactoryWork emthod get one more newly secton
              only this will automatically
             
             */
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];
            hdnStitchingFontOB.Value = dtGarmentType.Rows.Count.ToString();

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingFont.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingBack.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingcoller.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingsleep.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingneck.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingLining.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchinglower.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingbottom.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdStitchingassembly.Columns.Add(boundField);
                }

                //For All Section

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdPiping.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdUppersection.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdUppershell.Columns.Add(boundField);
                }


                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdLowershell.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdShellsection.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdWaistSection.Columns.Add(boundField);
                }

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdBandsection.Columns.Add(boundField);
                }

                // added by abhishek on 3/9/2015-----------------------------------------------------------------//
                //for new neck section

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdnecksection.Columns.Add(boundField);
                }


                //end neck section


                //for new neck faching section

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdneckfaching.Columns.Add(boundField);
                }


                //end neck faching section


                //for front and back section

                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdf_back.Columns.Add(boundField);
                }


                //end front and back


                //end by abhishek 3/9/2015------------------------------------------------------------------------//




            }


            dsMachineFinishing = obj_AdminController.GetFactoryWork("Finishing");

            dtGarmentTypeFinishing = dsMachineFinishing.Tables[1];
            hdnCuttingOB.Value = dtGarmentTypeFinishing.Rows.Count.ToString();

            if (dtGarmentTypeFinishing.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentTypeFinishing.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdFinishingOB.Columns.Add(boundField);
                }
            }
        }
        //added by abhishek on 24/10/2015
        protected void BindFinishingGrid(string Serachtxt)
        {
            if (ViewState["dtnewFinishing"] == null)
            {
                dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, Serachtxt);
                grdFinishingOB.DataSource = dtBindGrid;
                grdFinishingOB.DataBind();

                lblfinshing.Text = "(Total number of operation:" + finishingOb + ")";
                finishingOb = 0;

            }
            else
            {
                if (ViewState["Finish"] != null)
                {
                    dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, Serachtxt);
                    grdFinishingOB.DataSource = dtBindGrid;
                    grdFinishingOB.DataBind();
                    ViewState["Finish"] = "";

                    lblfinshing.Text = "(Total number of operation:" + finishingOb + ")";
                    finishingOb = 0;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewFinishing"]);
                    dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, Serachtxt);
                    grdFinishingOB.DataSource = dtnew;
                    grdFinishingOB.DataBind();
                    lblfinshing.Text = "(Total number of operation:" + finishingOb + ")";
                    finishingOb = 0;
                }
            }

        }
        //end by abhishek on 24/10/2015
        //added by abhishek on 24/10/2015
        protected void BindStichedGrd(string searchtext)
        {
            DataTable dtsection = new DataTable();
            dtsection = obj_AdminController.GetStichedSection();

            int Sectioncount = dtsection.Rows.Count;


            for (int iSection = 0; iSection < Sectioncount; iSection++)
            {
                string strSection = dtsection.Rows[iSection]["Section"].ToString();
                int SectionId = Convert.ToInt32(dtsection.Rows[iSection]["OBSectionID"]);
                switch (SectionId)
                {
                    case 1:
                        BindGrid(searchtext);

                        //btnAdd.Visible = true;
                        //btnadd_font.Visible = true;
                        break;
                    case 2:
                        BindStitchingBackGrid(searchtext);

                        //btnAddStichingBack.Visible = true;
                        //  btnadd_back.Visible = true;	
                        break;

                    case 3:
                        BindStitchingcollerGrid(searchtext);

                        // btnAddStichingcoller.Visible = true;
                        //btnadd_coller.Visible = true;	
                        break;

                    case 4:
                        BindStitchingsleepGrid(searchtext);

                        //btnAddStichingsleep.Visible = true;
                        //  btnadd_sleep.Visible = true;	

                        break;

                    case 5:

                        BindStitchingneckGrid(searchtext);

                        // btnAddStichingNeck.Visible = true;
                        //  btnadd_neck.Visible = true;
                        break;

                    case 6:

                        BindStitchingLiningGrid(searchtext);

                        //  btnAddStichingLining.Visible = true;

                        // btnadd_lining.Visible = true;	

                        break;

                    case 7:
                        BindStitchinglowerGrid(searchtext);


                        //btnAddStichinglower.Visible = true;
                        // btnaddlower.Visible = true;	

                        break;


                    case 8:
                        BindStitchingbottomGrid(searchtext);

                        // btnAddStichingbottom.Visible = true;
                        // btnadd_bottom.Visible = true;

                        //BindUpperShellsectionGrid();
                        //lblUppershell.Text = "Dept :" + strSection;
                        //btnAddStichingUppershell.Visible = true;
                        break;

                    case 9:
                        BindStitchingassemblyGrid(searchtext);

                        // btnAddStichingassembly.Visible = true;
                        // btnadd_assembly.Visible = Visible = true;
                        break;
                    //

                    //
                    case 11:
                        BindStitchingPipingGrid(searchtext);

                        //  btnAddStichingPiping.Visible = true;
                        // btnadd_piping.Visible = true;
                        break;

                    case 12:
                        BindUppersectionGrid(searchtext);

                        //  btnAddStichingUpper.Visible = true;
                        //   btnadd_upper.Visible = true;

                        break;

                    case 13:
                        BindUpperShellsectionGrid(searchtext);

                        // btnAddStichingUppershell.Visible = true;
                        //  btnadd_uppershell.Visible = true;
                        break;

                    case 14:
                        BindlowerShellsectionGrid(searchtext);

                        //btnAddStichingLowershell.Visible = true;
                        // btnadd_lowershell.Visible = true;
                        break;

                    case 15:
                        BindShellsectionsectionGrid(searchtext);

                        // btnAddStichingShellsection.Visible = true;
                        //  btnadd_shellsection.Visible = true;

                        //BindlowerShellsectionGrid();
                        //lblbLowershell.Text = "Dept :" + strSection;
                        //btnAddStichingLowershell.Visible = true;
                        break;


                    case 16:
                        BindWaistSectionGrid(searchtext);

                        // btnAddStichingWaistSection.Visible = true;
                        // btnadd_waistsection.Visible = true;

                        break;

                    case 17:
                        BindBandSectionGrid(searchtext);

                        //btnAddStichingBandsection.Visible = true;
                        // btnadd_bandsection.Visible = true;

                        //BindStitchingbottomGrid();
                        //lblbottom.Text = "Dept :" + strSection;
                        //btnAddStichingbottom.Visible = true;
                        break;


                    // added by abhishek on 3/9/2015-----------------------------------------------------------------//


                    case 18://for new neck section
                        BindBandSectionGrid_neckSection(searchtext);

                        //btnAddStichingNeckSection.Visible = true;
                        //  btnadd_necknewsection.Visible = true;


                        break;

                    case 19://for new neck faching section
                        //BindBandSectionGrid_neckSection();
                        BindBandSectionGrid_neckfaching(searchtext);

                        //btnAddStichingNecFaching.Visible = true;
                        // btnadd_neckfacing.Visible = true;

                        break;

                    case 20://for front and back section
                        BindBandSectionGrid_neckSection_frontback(searchtext);//here 

                        // btnaddf_back.Visible = true;
                        // btnaddfrontback.Visible = true;

                        break;

                    //end by abhishek 3/9/2015------------------------------------------------------------------------//






                }
            }
        }
        //end by abhishek on 24/10/2015



        protected void BindGrid(string searchtxt)
        {

            if (ViewState["dtnew"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontOB", "tblOperationstitching_Front", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", searchtxt);
                grdStitchingFont.DataSource = dtBindGrid;
                grdStitchingFont.DataBind();
                OprationCountfront = dtBindGrid.Rows.Count;

            }
            else
            {
                if (ViewState["Front"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontOB", "tblOperationstitching_Front", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", searchtxt);
                    grdStitchingFont.DataSource = dtBindGrid;
                    grdStitchingFont.DataBind();
                    ViewState["Front"] = null;
                    OprationCountfront = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnew"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontOB", "tblOperationstitching_Front", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", searchtxt);
                    grdStitchingFont.DataSource = dtnew;
                    grdStitchingFont.DataBind();
                    OprationCountfront = dtBindGrid.Rows.Count;
                }
            }

            lblStitching.Text = "front" + " " + "(Total number of operation:" + OprationCountfront + ")";
        }

        protected void grdStitchingFont_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OprationCountfront = OprationCountfront + 1;

                ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
                HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
                ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
                DataSet dtMachine = new DataSet();

                dsMachine = obj_AdminController.GetFactoryWork("Stitching");
                chkMachine.DataSource = dsMachine.Tables[0];
                chkMachine.DataValueField = "FactoryWorkSpace";
                chkMachine.DataTextField = "WorkerType";
                chkMachine.DataBind();

                if (hdnOperationId.Value != "")
                {
                    dtMachine = obj_AdminController.GetMachineStichingOB(Convert.ToInt32(hdnOperationId.Value));

                    if (dtMachine.Tables[0].Rows.Count > 0)
                    {
                        string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                        string[] words = opration.Split(',');

                        //

                        lstMachine.DataSource = dtMachine.Tables[1];
                        lstMachine.DataTextField = "FactoryWorkSpace";
                        lstMachine.DataBind();

                        //

                        foreach (var oprval in words)
                        {
                            if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                                chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                        }
                    }
                }

                dtGarmentType = dsMachine.Tables[1];

                if (dtGarmentType.Rows.Count > 0)
                {
                    for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                    {
                        string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                        int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                        grdStitchingFont.HeaderRow.Cells[i + 3].Text = colName;

                        Label lblName = new Label();
                        lblName.EnableViewState = true;
                        lblName.Enabled = true;
                        lblName.ID = "lal" + i;
                        lblName.Text = colName + " (SAM) ";
                        lblName.Width = 70;
                        grdStitchingFont.HeaderRow.Style.Add("width", "250px");
                        grdStitchingFont.HeaderRow.Style.Add("class", "topMenu2");
                        grdStitchingFont.HeaderRow.Style.Add("text-align", "center");
                        grdStitchingFont.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                        DataTable dtBOSam = new DataTable();
                        if (hdnOperationId.Value != "")
                            dtBOSam = obj_AdminController.GetStichingOBSam(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                        Decimal OBSam = 0;
                        if (dtBOSam.Rows.Count > 0)
                        {
                            OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["CuttingSam"]);
                        }
                        TextBox txtGarmentType = new TextBox();
                        txtGarmentType.EnableViewState = true;
                        txtGarmentType.Enabled = true;
                        txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                        if (OBSam == 0)
                        {
                            txtGarmentType.Text = "";
                        }
                        else
                        {
                            txtGarmentType.Text = OBSam.ToString();
                        }
                        txtGarmentType.Width = 50;
                        txtGarmentType.CssClass = "number";
                        txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStitchingOBSamFront(this)");
                        e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                    }

                }
            }

        }



        protected void btnFornt_Click(object sender, EventArgs e)
        {

            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontOB", "tblOperationstitching_Front", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
            grdStitchingFont.DataSource = dtBindGrid;
            grdStitchingFont.DataBind();

            lblStitching.Text = "Front" + " " + "(Total number of operation:" + OprationCountfront + ")";
            OprationCountfront = 0;


        }

        //added by abhishek on 24/10/2015
        protected void BindStitchingBackGrid(string searchtxt)
        {

            if (ViewState["dtnewBack"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbackOB", "tblOperationstitching_back", "Operationstitching_back", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", searchtxt);
                grdStitchingBack.DataSource = dtBindGrid;
                grdStitchingBack.DataBind();
                OprationCountBack = dtBindGrid.Rows.Count;


            }
            else
            {
                if (ViewState["Back"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbackOB", "tblOperationstitching_back", "Operationstitching_back", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", searchtxt);
                    grdStitchingBack.DataSource = dtBindGrid;
                    grdStitchingBack.DataBind();
                    ViewState["Back"] = null;
                    OprationCountBack = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewBack"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbackOB", "tblOperationstitching_back", "Operationstitching_back", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", searchtxt);
                    grdStitchingBack.DataSource = dtnew;
                    grdStitchingBack.DataBind();
                    OprationCountBack = dtBindGrid.Rows.Count;
                }
            }
            lblStitchingBack.Text = "Back" + " " + "(Total number of operation:" + OprationCountBack + ")";
        }
        //end by abhishek on 24/10/2015
        protected void grdStitchingBack_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountBack = OprationCountBack + 1;
            //end by abhishek on 24/10/2015

            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();

            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingBackOB(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchingBack.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)"; ;
                    lblName.Width = 70;
                    grdStitchingBack.HeaderRow.Style.Add("width", "250px");
                    grdStitchingBack.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchingBack.HeaderRow.Style.Add("text-align", "center");
                    grdStitchingBack.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamBack(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Width = 50;
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamBack(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {

            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbackOB", "tblOperationstitching_back", "Operationstitching_back", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdStitchingBack.DataSource = dtBindGrid;
            grdStitchingBack.DataBind();
        }

        //For Stiching coller
        protected void BindStitchingcollerGrid(string serachtxt)
        {
            if (ViewState["dtnewcoller"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingcollerOB", "tblOperationstitching_coller", "Operationstitching_coller", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", serachtxt);
                grdStitchingcoller.DataSource = dtBindGrid;
                grdStitchingcoller.DataBind();

                OprationCountcoller = dtBindGrid.Rows.Count;

            }
            else
            {
                if (ViewState["coller"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingcollerOB", "tblOperationstitching_coller", "Operationstitching_coller", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", serachtxt);
                    grdStitchingcoller.DataSource = dtBindGrid;
                    grdStitchingcoller.DataBind();
                    ViewState["coller"] = null;
                    OprationCountcoller = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewcoller"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingcollerOB", "tblOperationstitching_coller", "Operationstitching_coller", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", serachtxt);
                    grdStitchingcoller.DataSource = dtnew;
                    grdStitchingcoller.DataBind();
                    OprationCountcoller = dtBindGrid.Rows.Count;
                }
            }
            lblcoller.Text = "Collar" + " " + "(Total number of operation:" + OprationCountcoller + ")";
        }
        protected void grdStitchingcoller_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountcoller = OprationCountcoller + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingcollerOB(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //

                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //
                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchingcoller.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)"; ;
                    lblName.Width = 70;
                    grdStitchingcoller.HeaderRow.Style.Add("width", "250px");
                    grdStitchingcoller.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchingcoller.HeaderRow.Style.Add("text-align", "center");
                    grdStitchingcoller.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamcoller(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamcoller(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        //For Stiching sleep
        protected void BindStitchingsleepGrid(string serachtxt)
        {
            if (ViewState["dtnewsleep"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingsleepOB", "tblOperationstitching_sleep", "Operationstitching_sleep", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", serachtxt);
                grdStitchingsleep.DataSource = dtBindGrid;
                grdStitchingsleep.DataBind();
                OprationCountsleep = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["sleep"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingsleepOB", "tblOperationstitching_sleep", "Operationstitching_sleep", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", serachtxt);
                    grdStitchingsleep.DataSource = dtBindGrid;
                    grdStitchingsleep.DataBind();
                    ViewState["sleep"] = null;
                    OprationCountsleep = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewsleep"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingsleepOB", "tblOperationstitching_sleep", "Operationstitching_sleep", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", serachtxt);
                    grdStitchingsleep.DataSource = dtnew;
                    grdStitchingsleep.DataBind();
                    OprationCountsleep = dtBindGrid.Rows.Count;
                }
            }

            lblsleep.Text = "Sleeve" + " " + "(Total number of operation:" + OprationCountsleep + ")";
        }
        protected void grdStitchingsleep_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //added by abhishek on 24/10/2015
            OprationCountsleep = OprationCountsleep + 1;
            //end by abhishek on 24/10/2015

            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingsleepOB(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchingsleep.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)"; ;
                    lblName.Width = 70;
                    grdStitchingsleep.HeaderRow.Style.Add("width", "250px");
                    grdStitchingsleep.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchingsleep.HeaderRow.Style.Add("text-align", "center");
                    grdStitchingsleep.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamsleep(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamsleep(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        //For Stiching neck 
        protected void BindStitchingneckGrid(string serachtxt)
        {

            if (ViewState["dtnewneck"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingneckOB", "tblOperationstitching_neck", "Operationstitching_neck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                grdStitchingneck.DataSource = dtBindGrid;
                grdStitchingneck.DataBind();
                OprationCountneck = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["neck"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingneckOB", "tblOperationstitching_neck", "Operationstitching_neck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingneck.DataSource = dtBindGrid;
                    grdStitchingneck.DataBind();
                    ViewState["neck"] = null;
                    OprationCountneck = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewneck"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingneckOB", "tblOperationstitching_neck", "Operationstitching_neck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingneck.DataSource = dtnew;
                    grdStitchingneck.DataBind();
                    OprationCountneck = dtBindGrid.Rows.Count;
                }
            }
            lblneck.Text = "Frill" + " " + "(Total number of operation:" + OprationCountneck + ")";
        }
        protected void grdStitchingneck_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountneck = OprationCountneck + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOBNeck(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //
                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchingneck.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdStitchingneck.HeaderRow.Style.Add("width", "250px");
                    grdStitchingneck.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchingneck.HeaderRow.Style.Add("text-align", "center");
                    grdStitchingneck.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamNeck(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamneck(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnneck_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingneckOB", "tblOperationstitching_neck", "Operationstitching_neck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "");
            grdStitchingneck.DataSource = dtBindGrid;
            grdStitchingneck.DataBind();
        }


        //For Stiching Lining
        protected void BindStitchingLiningGrid(string serachtxt)
        {

            if (ViewState["dtnewLining"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLiningOB", "tblOperationstitching_Lining", "Operationstitching_Lining", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                grdStitchingLining.DataSource = dtBindGrid;
                grdStitchingLining.DataBind();
                OprationCountLining = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Lining"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLiningOB", "tblOperationstitching_Lining", "Operationstitching_Lining", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingLining.DataSource = dtBindGrid;
                    grdStitchingLining.DataBind();
                    ViewState["Lining"] = null;
                    OprationCountLining = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewLining"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLiningOB", "tblOperationstitching_Lining", "Operationstitching_Lining", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingLining.DataSource = dtnew;
                    grdStitchingLining.DataBind();
                    OprationCountLining = dtBindGrid.Rows.Count;
                }
            }
            lblLining.Text = "lining" + " " + "(Total number of operation:" + OprationCountLining + ")";
        }
        protected void grdStitchingLining_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountLining = OprationCountLining + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOBLining(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchingLining.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdStitchingLining.HeaderRow.Style.Add("width", "250px");
                    grdStitchingLining.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchingLining.HeaderRow.Style.Add("text-align", "center");
                    grdStitchingLining.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamLining(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";

                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveLining(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnLining_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLiningOB", "tblOperationstitching_Lining", "Operationstitching_Lining", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "");
            grdStitchingLining.DataSource = dtBindGrid;
            grdStitchingLining.DataBind();
        }

        //For Stiching lower
        protected void BindStitchinglowerGrid(string serachtxt)
        {

            if (ViewState["dtnewLower"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchinglowerOB", "tblOperationstitching_lower", "Operationstitching_lower", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                grdStitchinglower.DataSource = dtBindGrid;
                grdStitchinglower.DataBind();
                OprationCountlower = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["lower"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchinglowerOB", "tblOperationstitching_lower", "Operationstitching_lower", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchinglower.DataSource = dtBindGrid;
                    grdStitchinglower.DataBind();
                    ViewState["lower"] = null;
                    OprationCountlower = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewLower"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchinglowerOB", "tblOperationstitching_lower", "Operationstitching_lower", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchinglower.DataSource = dtnew;
                    grdStitchinglower.DataBind();
                    OprationCountlower = dtBindGrid.Rows.Count;
                }
            }
            lbllower.Text = "Lower" + " " + "(Total number of operation:" + OprationCountlower + ")";
        }
        protected void grdStitchinglower_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountlower = OprationCountlower + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOBLower(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchinglower.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdStitchinglower.HeaderRow.Style.Add("width", "250px");
                    grdStitchinglower.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchinglower.HeaderRow.Style.Add("text-align", "center");
                    grdStitchinglower.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamLower(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamlower(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        //For Stiching bottom
        protected void BindStitchingbottomGrid(string serachtxt)
        {

            if (ViewState["dtnewbottom"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbottomOB", "tblOperationstitching_bottom", "Operationstitching_bottom", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                grdStitchingbottom.DataSource = dtBindGrid;
                grdStitchingbottom.DataBind();
                OprationCountbottom = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["bottom"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbottomOB", "tblOperationstitching_bottom", "Operationstitching_bottom", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingbottom.DataSource = dtBindGrid;
                    grdStitchingbottom.DataBind();
                    ViewState["bottom"] = null;
                    OprationCountbottom = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewbottom"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbottomOB", "tblOperationstitching_bottom", "Operationstitching_bottom", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingbottom.DataSource = dtnew;
                    grdStitchingbottom.DataBind();
                    OprationCountbottom = dtBindGrid.Rows.Count;
                }
            }
            lblbottom.Text = "Bottom" + " " + "(Total number of operation:" + OprationCountbottom + ")";
        }
        protected void grdStitchingbottom_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountbottom = OprationCountbottom + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOBbottom(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');

                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchingbottom.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdStitchingbottom.HeaderRow.Style.Add("width", "250px");
                    grdStitchingbottom.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchingbottom.HeaderRow.Style.Add("text-align", "center");
                    grdStitchingbottom.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSambottom(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Width = 50;
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSambottom(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        //For Stiching assembly
        protected void BindStitchingassemblyGrid(string serachtxt)
        {

            if (ViewState["dtnewassembly"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingassemblyOB", "tblOperationstitching_assembly", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                grdStitchingassembly.DataSource = dtBindGrid;
                grdStitchingassembly.DataBind();
                OprationCountassembly = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["assembly"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingassemblyOB", "tblOperationstitching_assembly", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingassembly.DataSource = dtBindGrid;
                    grdStitchingassembly.DataBind();
                    ViewState["assembly"] = null;
                    OprationCountassembly = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewassembly"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingassemblyOB", "tblOperationstitching_assembly", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", serachtxt);
                    grdStitchingassembly.DataSource = dtnew;
                    grdStitchingassembly.DataBind();
                    OprationCountassembly = dtBindGrid.Rows.Count;
                }
            }
            lblassembly.Text = "assembly" + " " + "(Total number of operation:" + OprationCountassembly + ")";
        }
        protected void grdStitchingassembly_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountassembly = OprationCountassembly + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOBassembly(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');

                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //


                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdStitchingassembly.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdStitchingassembly.HeaderRow.Style.Add("width", "250px");
                    grdStitchingassembly.HeaderRow.Style.Add("class", "topMenu2");
                    grdStitchingassembly.HeaderRow.Style.Add("text-align", "center");
                    grdStitchingassembly.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamassembly(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamassembly(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        //protected void btnassembly_Click(object sender, EventArgs e)
        //{
        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingassemblyOB", "tblOperationstitching_assembly", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "");
        //    grdStitchingassembly.DataSource = dtBindGrid;
        //    grdStitchingassembly.DataBind();
        //}


        //For Stiching All
        //For piping
        protected void BindStitchingPipingGrid(string serachtxt)
        {

            if (ViewState["dtnewPiping"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingPipingOB", "tblOperationstitching_Piping", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                grdPiping.DataSource = dtBindGrid;
                grdPiping.DataBind();
                OprationCountPiping = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Piping"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingPipingOB", "tblOperationstitching_Piping", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdPiping.DataSource = dtBindGrid;
                    grdPiping.DataBind();
                    ViewState["Piping"] = null;
                    OprationCountPiping = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewPiping"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingPipingOB", "tblOperationstitching_Piping", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdPiping.DataSource = dtnew;
                    grdPiping.DataBind();
                    OprationCountPiping = dtBindGrid.Rows.Count;
                }
            }
            lblPiping.Text = "Piping" + " " + "(Total number of operation:" + OprationCountPiping + ")";
        }
        protected void grdPiping_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //added by abhishek on 24/10/2015
            OprationCountPiping = OprationCountPiping + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataTable dtSam = new DataTable();
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingAll(Convert.ToInt32(hdnOperationId.Value), "Piping");

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');

                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdPiping.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdPiping.HeaderRow.Style.Add("width", "250px");
                    grdPiping.HeaderRow.Style.Add("class", "topMenu2");
                    grdPiping.HeaderRow.Style.Add("text-align", "center");
                    grdPiping.HeaderRow.Cells[i + 3].Controls.Add(lblName);

                    if (hdnOperationId.Value != "")
                        dtSam = obj_AdminController.GetStichingOBSamAll(Convert.ToInt32(hdnOperationId.Value), GarmentId, "Piping");

                    Decimal OBSam = 0;
                    if (dtSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamPiping(this,'Piping')");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }

        //protected void btnPiping_Click(object sender, EventArgs e)
        //{
        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingPipingOB", "tblOperationstitching_Piping", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
        //    grdPiping.DataSource = dtBindGrid;
        //    grdPiping.DataBind();
        //}
        //END

        //For Upper
        protected void BindUppersectionGrid(string serachtxt)
        {

            if (ViewState["dtnewUpper"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUpperOB", "tblOperationstitching_Upper", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                grdUppersection.DataSource = dtBindGrid;
                grdUppersection.DataBind();
                OprationCountUppersection = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Upper"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUpperOB", "tblOperationstitching_Upper", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdUppersection.DataSource = dtBindGrid;
                    grdUppersection.DataBind();
                    ViewState["Upper"] = null;
                    OprationCountUppersection = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewUpper"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUpperOB", "tblOperationstitching_Upper", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdUppersection.DataSource = dtnew;
                    grdUppersection.DataBind();
                    OprationCountUppersection = dtBindGrid.Rows.Count;
                }
            }
            lblUpper.Text = "Upper" + " " + "(Total number of operation:" + OprationCountUppersection + ")";
        }
        protected void grdUppersection_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //added by abhishek on 24/10/2015
            OprationCountUppersection = OprationCountUppersection + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataTable dtSam = new DataTable();
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingAll(Convert.ToInt32(hdnOperationId.Value), "Upper");

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdUppersection.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdUppersection.HeaderRow.Style.Add("width", "250px");
                    grdUppersection.HeaderRow.Style.Add("class", "topMenu2");
                    grdUppersection.HeaderRow.Style.Add("text-align", "center");
                    grdUppersection.HeaderRow.Cells[i + 3].Controls.Add(lblName);

                    if (hdnOperationId.Value != "")
                        dtSam = obj_AdminController.GetStichingOBSamAll(Convert.ToInt32(hdnOperationId.Value), GarmentId, "Upper");

                    Decimal OBSam = 0;
                    if (dtSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamUpper(this,'Upper')");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }

        protected void btnUppersection_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUpperOB", "tblOperationstitching_Upper", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
            grdUppersection.DataSource = dtBindGrid;
            grdUppersection.DataBind();
        }
        //END


        //For Upper Shell 
        protected void BindUpperShellsectionGrid(string serachtxt)
        {

            if (ViewState["dtnewUppershell"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUppershellOB", "tblOperationstitching_Uppershell", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                grdUppershell.DataSource = dtBindGrid;
                grdUppershell.DataBind();
                OprationCountShellsection = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Uppershell"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUppershellOB", "tblOperationstitching_Uppershell", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdUppershell.DataSource = dtBindGrid;
                    grdUppershell.DataBind();
                    ViewState["Uppershell"] = null;
                    OprationCountShellsection = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewUppershell"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUppershellOB", "tblOperationstitching_Uppershell", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdUppershell.DataSource = dtnew;
                    grdUppershell.DataBind();
                    OprationCountShellsection = dtBindGrid.Rows.Count;
                }
            }
            lblUppershell.Text = "Uppershell" + " " + "(Total number of operation:" + OprationCountUppershell + ")";
        }
        protected void grdUppershell_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //added by abhishek on 24/10/2015
            OprationCountUppershell = OprationCountUppershell + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataTable dtSam = new DataTable();
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingAll(Convert.ToInt32(hdnOperationId.Value), "Uppershell");

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');

                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //
                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdUppershell.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdUppershell.HeaderRow.Style.Add("width", "250px");
                    grdUppershell.HeaderRow.Style.Add("class", "topMenu2");
                    grdUppershell.HeaderRow.Style.Add("text-align", "center");
                    grdUppershell.HeaderRow.Cells[i + 3].Controls.Add(lblName);

                    if (hdnOperationId.Value != "")
                        dtSam = obj_AdminController.GetStichingOBSamAll(Convert.ToInt32(hdnOperationId.Value), GarmentId, "Uppershell");

                    Decimal OBSam = 0;
                    if (dtSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamUppershell(this,'Uppershell')");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        //protected void btnUppershell_Click(object sender, EventArgs e)
        //{
        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUppershellOB", "tblOperationstitching_Uppershell", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
        //    grdUppershell.DataSource = dtBindGrid;
        //    grdUppershell.DataBind();
        //}

        //END 


        //For lower Shell
        protected void BindlowerShellsectionGrid(string serachtxt)
        {

            if (ViewState["dtnewlowershell"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLowershellOB", "tblOperationstitching_Lowershell", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                grdLowershell.DataSource = dtBindGrid;
                grdLowershell.DataBind();
                OprationCountShellsection = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Lowershell"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLowershellOB", "tblOperationstitching_Lowershell", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdLowershell.DataSource = dtBindGrid;
                    grdLowershell.DataBind();
                    ViewState["Lowershell"] = null;
                    OprationCountShellsection = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewlowershell"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLowershellOB", "tblOperationstitching_Lowershell", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdLowershell.DataSource = dtnew;
                    grdLowershell.DataBind();
                    OprationCountShellsection = dtBindGrid.Rows.Count;
                }
            }
            lblbLowershell.Text = "LowerShell" + " " + "(Total number of operation:" + OprationCountLowershell + ")";
        }
        protected void grdLowershell_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountLowershell = OprationCountLowershell + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataTable dtSam = new DataTable();
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingAll(Convert.ToInt32(hdnOperationId.Value), "Lowershell");

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //
                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdLowershell.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdLowershell.HeaderRow.Style.Add("width", "250px");
                    grdLowershell.HeaderRow.Style.Add("class", "topMenu2");
                    grdLowershell.HeaderRow.Style.Add("text-align", "center");
                    grdLowershell.HeaderRow.Cells[i + 3].Controls.Add(lblName);

                    if (hdnOperationId.Value != "")
                        dtSam = obj_AdminController.GetStichingOBSamAll(Convert.ToInt32(hdnOperationId.Value), GarmentId, "Lowershell");

                    Decimal OBSam = 0;
                    if (dtSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamLowershell(this,'Lowershell')");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }

        //protected void btnLowershell_Click(object sender, EventArgs e)
        //{
        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLowershellOB", "tblOperationstitching_Lowershell", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
        //    grdLowershell.DataSource = dtBindGrid;
        //    grdLowershell.DataBind();
        //}
        //END


        //For Shellsection
        protected void BindShellsectionsectionGrid(string serachtxt)
        {

            if (ViewState["dtnewShell"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingShellsectionOB", "tblOperationstitching_Shellsection", "Operationstitching_ShellSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                grdShellsection.DataSource = dtBindGrid;
                grdShellsection.DataBind();
                OprationCountShellsection = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Shellsection"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingShellsectionOB", "tblOperationstitching_Shellsection", "Operationstitching_ShellSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdShellsection.DataSource = dtBindGrid;
                    grdShellsection.DataBind();
                    ViewState["Shellsection"] = null;
                    OprationCountShellsection = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewShell"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingShellsectionOB", "tblOperationstitching_Shellsection", "Operationstitching_ShellSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdShellsection.DataSource = dtnew;
                    grdShellsection.DataBind();
                    OprationCountShellsection = dtBindGrid.Rows.Count;
                }
            }

            lblShellsection.Text = "shell" + " " + "(Total number of operation:" + OprationCountShellsection + ")";
        }
        protected void grdShellsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //added by abhishek on 24/10/2015
            OprationCountShellsection = OprationCountShellsection + 1;
            //end by abhishek on 24/10/2015

            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataTable dtSam = new DataTable();
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingAll(Convert.ToInt32(hdnOperationId.Value), "Shellsection");

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();

                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdShellsection.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdShellsection.HeaderRow.Style.Add("width", "250px");
                    grdShellsection.HeaderRow.Style.Add("class", "topMenu2");
                    grdShellsection.HeaderRow.Style.Add("text-align", "center");
                    grdShellsection.HeaderRow.Cells[i + 3].Controls.Add(lblName);

                    if (hdnOperationId.Value != "")
                        dtSam = obj_AdminController.GetStichingOBSamAll(Convert.ToInt32(hdnOperationId.Value), GarmentId, "Shellsection");

                    Decimal OBSam = 0;
                    if (dtSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamShellsection(this,'Shellsection')");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }

        //protected void btnShellsection_Click(object sender, EventArgs e)
        //{
        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingShellsectionOB", "tblOperationstitching_Shellsection", "Operationstitching_ShellSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
        //    grdShellsection.DataSource = dtBindGrid;
        //    grdShellsection.DataBind();
        //}
        //END

        //For Waist section
        protected void BindWaistSectionGrid(string serachtxt)
        {

            if (ViewState["dtnewWaistSection"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingWaistSectionOB", "tblOperationstitching_WaistSection", "Operationstitching_WaistSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                grdWaistSection.DataSource = dtBindGrid;
                grdWaistSection.DataBind();
                OprationCountWaistSection = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Waist"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingWaistSectionOB", "tblOperationstitching_WaistSection", "Operationstitching_WaistSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdWaistSection.DataSource = dtBindGrid;
                    grdWaistSection.DataBind();
                    ViewState["Waist"] = null;
                    OprationCountWaistSection = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewWaistSection"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingWaistSectionOB", "tblOperationstitching_WaistSection", "Operationstitching_WaistSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdWaistSection.DataSource = dtnew;
                    grdWaistSection.DataBind();
                    OprationCountWaistSection = dtBindGrid.Rows.Count;
                }
            }

            lblWaistSection.Text = "Waist" + " " + "(Total number of operation:" + OprationCountWaistSection + ")";

        }
        protected void grdWaistSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountWaistSection = OprationCountWaistSection + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataTable dtSam = new DataTable();
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingAll(Convert.ToInt32(hdnOperationId.Value), "WaistSection");

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //
                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdWaistSection.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdWaistSection.HeaderRow.Style.Add("width", "250px");
                    grdWaistSection.HeaderRow.Style.Add("class", "topMenu2");
                    grdWaistSection.HeaderRow.Style.Add("text-align", "center");
                    grdWaistSection.HeaderRow.Cells[i + 3].Controls.Add(lblName);

                    if (hdnOperationId.Value != "")
                        dtSam = obj_AdminController.GetStichingOBSamAll(Convert.ToInt32(hdnOperationId.Value), GarmentId, "WaistSection");

                    Decimal OBSam = 0;
                    if (dtSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamWaistSection(this,'WaistSection')");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }

        //protected void btnWaistSection_Click(object sender, EventArgs e)
        //{
        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingWaistSectionOB", "tblOperationstitching_WaistSection", "Operationstitching_WaistSection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
        //    grdWaistSection.DataSource = dtBindGrid;
        //    grdWaistSection.DataBind();
        //}
        //END


        //For Band section
        protected void BindBandSectionGrid(string serachtxt)
        {

            if (ViewState["dtnewBandsection"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingBandsectionOB", "tblOperationstitching_Bandsection", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                grdBandsection.DataSource = dtBindGrid;
                grdBandsection.DataBind();
                OprationCountBandsection = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["Band"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingBandsectionOB", "tblOperationstitching_Bandsection", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdBandsection.DataSource = dtBindGrid;
                    grdBandsection.DataBind();
                    ViewState["Band"] = null;
                    OprationCountBandsection = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewBandsection"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingBandsectionOB", "tblOperationstitching_Bandsection", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", serachtxt);
                    grdBandsection.DataSource = dtnew;
                    grdBandsection.DataBind();
                    OprationCountBandsection = dtBindGrid.Rows.Count;
                }
            }
            lblBandsection.Text = "Band" + " " + "(Total number of operation:" + OprationCountBandsection + ")";
        }

        protected void grdBandsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountBandsection = OprationCountBandsection + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataTable dtSam = new DataTable();
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingAll(Convert.ToInt32(hdnOperationId.Value), "Bandsection");

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdBandsection.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdBandsection.HeaderRow.Style.Add("width", "250px");
                    grdBandsection.HeaderRow.Style.Add("class", "topMenu2");
                    grdBandsection.HeaderRow.Style.Add("text-align", "center");
                    grdBandsection.HeaderRow.Cells[i + 3].Controls.Add(lblName);

                    if (hdnOperationId.Value != "")
                        dtSam = obj_AdminController.GetStichingOBSamAll(Convert.ToInt32(hdnOperationId.Value), GarmentId, "Bandsection");

                    Decimal OBSam = 0;
                    if (dtSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamBandsection(this,'Bandsection')");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        //protected void btnBandsection_Click(object sender, EventArgs e)
        //{
        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingBandsectionOB", "tblOperationstitching_Bandsection", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
        //    grdBandsection.DataSource = dtBindGrid;
        //    grdBandsection.DataBind();
        //}

        //END
        //END

        //Finishing

        protected void grdFinishingOB_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            finishingOb = finishingOb + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("chkMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");

            dsMachineFinishing = obj_AdminController.GetFactoryWork("Finishing");

            chkMachine.DataSource = dsMachineFinishing.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineFinishingOB(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //
                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentTypeFinishing = dsMachineFinishing.Tables[1];

            if (dtGarmentTypeFinishing.Rows.Count > 0)
            {

                for (int i = 0; i < dtGarmentTypeFinishing.Rows.Count; i++)
                {
                    string colName = dtGarmentTypeFinishing.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentTypeFinishing.Rows[i]["GarmentTypeID"]);
                    grdFinishingOB.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdFinishingOB.HeaderRow.Style.Add("width", "250px");
                    grdFinishingOB.HeaderRow.Style.Add("class", "topMenu2");
                    grdFinishingOB.HeaderRow.Style.Add("text-align", "center");
                    grdFinishingOB.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetFinishingOBSam(Convert.ToInt32(hdnOperationId.Value), GarmentId);


                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveFinishingOBSam(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }

            }
        }
        //added by abhishek 24//10/2015
        protected void btnFinishing_Click(object sender, EventArgs e)
        {
            dtBindGridFinishing = obj_AdminController.GetFinishingOB(0, 0, "");
            grdFinishingOB.DataSource = dtBindGridFinishing;
            grdFinishingOB.DataBind();

            lblfinshing.Text = "(Total number of operation:" + finishingOb + ")";
            finishingOb = 0;
        }

        protected void btnAddFinishing_Click(object sender, EventArgs e)
        {

            if (ViewState["dtnewFinishing"] != null)
            {
                DataTable dtnew = new DataTable();
                //dtnew = (DataTable)(ViewState["dtnew"]);
                dtnew = obj_AdminController.GetFinishingOB(0, 0, "");
                DataRow newrow = dtnew.NewRow();
                dtnew.Rows.Add(newrow);
                dtmergeFinishing = dtnew;
                grdFinishingOB.DataSource = dtmergeFinishing;
                grdFinishingOB.DataBind();
                ViewState["dtnewFinishing"] = dtmergeFinishing;

                lblfinshing.Text = "(Total number of operation:" + finishingOb + ")";
                finishingOb = 0;
            }
            else
            {
                dtBindGridFinishing = obj_AdminController.GetFinishingOB(0, 0, "");
                DataRow newrow = dtBindGridFinishing.NewRow();
                dtBindGridFinishing.Rows.Add(newrow);
                dtmergeFinishing = dtBindGridFinishing;
                grdFinishingOB.DataSource = dtmergeFinishing;
                grdFinishingOB.DataBind();
                ViewState["dtnewFinishing"] = dtmergeFinishing;

                lblfinshing.Text = "(Total number of operation:" + finishingOb + ")";
                finishingOb = 0;
            }
            //end by abhishek on 24/10/2015
        }

        //protected void txtOperation_TextChanged(object sender, EventArgs e)
        //{
        //    string strtxt = ((TextBox)(sender)).Text.Trim();
        //    GridViewRow gvr = ((TextBox)sender).Parent.Parent as GridViewRow;

        //    HiddenField hdnOperationId = (HiddenField)gvr.FindControl("hdnOperationId");

        //    if (hdnOperationId.Value == "")
        //    {
        //        int result = obj_AdminController.InsertFinishing(strtxt);
        //        ViewState["txtval"] = "First";
        //        BindGrid();

        //    }
        //    else
        //    {
        //        int result = obj_AdminController.InsertUpdateFinishingOB(Convert.ToInt32(hdnOperationId.Value), strtxt, "1");
        //        BindGrid();

        //    }


        //}

        public void HideAllButton()
        {
            btnFront_up_Add.Visible = false;
            // btnAdd.Visible = false;
            DivFront_Add.Visible = false;
            btnbacknew_Add.Visible = false;
            // btnAddStichingBack.Visible = false;
            DivBack_Add.Visible = false;

            btnColler_up_Add.Visible = false;

            DivColler_Add.Visible = false;

            btnsleep_up_Add.Visible = false;
            DivSleep_Add.Visible = false;
            btnNeck_up_Add.Visible = false;
            DivNeck_Add.Visible = false;
            btnlining_up_Add.Visible = false;
            Divlining_Add.Visible = false;

            btnlower_up_Add.Visible = false;

            Divlower_Add.Visible = false;

            btnbottom_addnew.Visible = false;
            divbottom_add.Visible = false;
            btnAssemblyAddnew.Visible = false;
            divStitchingAssemblyAdd.Visible = false;
            btnPiping_up_Add.Visible = false;
            DivPiping_Add.Visible = false;
            btnUpper_up_Add.Visible = false;
            DivUpper_Add.Visible = false;
            btnUppershell_up_Add.Visible = false;
            DivUppershell_Add.Visible = false;
            btnLowershell_up_Add.Visible = false;
            DivLowershell_Add.Visible = false;
            btnShellsection_up_Add.Visible = false;
            DivShellsection_Add.Visible = false;

            btnWaistSection_up_Add.Visible = false;
            DivWaistSection_Add.Visible = false;

            btnBandsection_up_Add.Visible = false;
            DivBandsection_Add.Visible = false;

            btnnecksection_up_Add.Visible = false;
            Divnecksection_Add.Visible = false;

            btnneckfaching_up_Add.Visible = false;
            Divneckfaching_Add.Visible = false;

            btnf_back_up_Add.Visible = false;
            Divf_back_Add.Visible = false;














        }

        //added by abhishek on 24/10/2015
        protected void rbtnlistsection_SelectedIndexChanged(object sender, EventArgs e)
        {

            int OBSection = Convert.ToInt32(rbtnlistsection.SelectedValue);
            string Searchtext = txtsearch.Text.Trim();
            if (OBSection == 1)
            {
                StitchGridShowHide(3);
                ddlStitchSection.Visible = true;
                grdFinishingOB.Visible = false;
                trFinishing.Visible = false;
                divFinishing.Visible = false;

                /*for first time load front Add opration gridview*/
                ddlStitchSection.SelectedValue = "1";
                lblStitching.Text = "Front";
                BindFrontAdd();
                StitchGridShowHide(2);
                trFront.Visible = true;
                DivFront_Add.Visible = true;
                DivFrontlist_Add.Visible = true;
                //end


                //BindStichedGrd(Searchtext);//load only font Add grd thats why commented
                //StitchGridShowHide(2);
                //grdStitchingFont.Visible = true;
                //divfront.Visible = true;
                //trFront.Visible = true;

            }
            if (OBSection == 2)
            {
                ddlStitchSection.Visible = false;
                StitchGridShowHide(2);
                BindFinishingGrid("");
                grdFinishingOB.Visible = true;
                trFinishing.Visible = true;
                divFinishing.Visible = true;
                btnAddFinishing.Visible = true;
                // btnadd_finishing.Visible = true;

                ViewState["Finish"] = "17";
            }
            if (OBSection == 3)
            {


                ddlStitchSection.Visible = false;

                grdFinishingOB.Visible = true;
                trFinishing.Visible = true;
                divFinishing.Visible = true;

                StitchGridShowHide(3);
                BindStichedGrd("");
                BindFinishingGrid("");
                HideAllButton();

            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "hidebtnfun()", true);
        }

        protected void ddlStitchSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StitchingSection = Convert.ToInt32(ddlStitchSection.SelectedValue);
            string Searchtext = txtsearch.Text.Trim().Trim();

            if (StitchingSection == -1)
            {
                BindStichedGrd(Searchtext);//empty param for get all record
                StitchGridShowHide(3);
            }
            if (StitchingSection == 1)
            {

                lblStitching.Text = "Front";
                BindFrontAdd();
                StitchGridShowHide(2);
                trFront.Visible = true;
                DivFront_Add.Visible = true;
                DivFrontlist_Add.Visible = true;


                //BindGrid(Searchtext);
                //StitchGridShowHide(2);
                //grdStitchingFont.Visible = true;
                //divfront.Visible = true;
                //trFront.Visible = true;
                //ViewState["Front"] = "1";

                //btnAdd.Visible = true;
                ////  btnadd_font.Visible = true;

                //lblStitching.Text = "Front" + " " + "(Total number of opration:" + OprationCountfront + ")";
                //OprationCountfront = 0;


            }
            if (StitchingSection == 2)
            {
                lblStitchingBack.Text = "Back";
                OprationCountBack = 0;

                // BindAddBack_add();
                BindBackAdd();
                StitchGridShowHide(2);
                trBack.Visible = true;
                DivBack_Add.Visible = true;
                DivBacklist_Add.Visible = true;


            }
            if (StitchingSection == 3)
            {
                lblcoller.Text = "Collar";
                OprationCountBack = 0;
                //BindAddColler_Add();
                BindCollerAdd();
                StitchGridShowHide(2);
                trcoller.Visible = true;
                DivColler_Add.Visible = true;
                DivCollerlist_Add.Visible = true;

            }
            if (StitchingSection == 4)
            {



                lblsleep.Text = "Sleeve";
                OprationCountsleep = 0;
                //BindAddSleep_Add();
                BindSleepAdd();
                StitchGridShowHide(2);
                trsleep.Visible = true;
                DivSleep_Add.Visible = true;
                DivSleeplist_Add.Visible = true;

                //  BindStitchingsleepGrid(Searchtext);

                //  StitchGridShowHide(2);
                //  grdStitchingsleep.Visible = true;
                //  divsleep.Visible = true;
                //  trsleep.Visible = true;
                //  ViewState["sleep"] = "4";
                //  btnAddStichingsleep.Visible = true;
                ////  btnadd_sleep.Visible = true;	

                //  lblsleep.Text = "SLEEVE" + "(Total number of opration:" + OprationCountsleep + ")";
                //  OprationCountsleep = 0;
            }
            if (StitchingSection == 5)
            {


                lblneck.Text = "Frill";
                OprationCountneck = 0;
                // BindAddNeck_Add();
                BindNeckAdd();
                StitchGridShowHide(2);
                trneck.Visible = true;
                DivNeck_Add.Visible = true;
                DivNecklist_Add.Visible = true;
            }
            if (StitchingSection == 6)
            {

                lblLining.Text = "lining";
                OprationCountLining = 0;
                //BindAddlining_Add();
                BindliningAdd();
                StitchGridShowHide(2);
                trLining.Visible = true;
                Divlining_Add.Visible = true;
                Divlininglist_Add.Visible = true;


            }
            if (StitchingSection == 7)
            {

                lbllower.Text = "lower";
                OprationCountlower = 0;
                //BindAddlower_Add();
                BindlowerAdd();
                StitchGridShowHide(2);
                trlower.Visible = true;
                Divlower_Add.Visible = true;
                Divlowerlist_Add.Visible = true;


            }
            if (StitchingSection == 8)
            {

                lblbottom.Text = "CAMI"; // + " " + "(Total number of opration:" + OprationCountbottom + ")";
                // OprationCountbottom = 0;
                //BindAddbottom_add();
                BindbottomAdd();
                StitchGridShowHide(2);
                trbottom.Visible = true;
                divbottom_add.Visible = true;
                divbottombtn.Visible = true;





            }
            if (StitchingSection == 9)
            {

                lblassembly.Text = "Assembly";// + " " + "(Total number of opration:" + OprationCountassembly + ")";


                //BindAddAssembly();
                BindAssemblyAdd();

                StitchGridShowHide(2);

                trassembly.Visible = true;
                divStitchingAssemblyAdd.Visible = true;
                divAddassemblybtn.Visible = true;

            }
            if (StitchingSection == 10)
            {




                lblPiping.Text = "Piping";
                OprationCountPiping = 0;
                //BindAddPiping_Add();
                BindPipingAdd();
                StitchGridShowHide(2);
                trPiping.Visible = true;
                DivPiping_Add.Visible = true;
                DivPipinglist_Add.Visible = true;


            }
            if (StitchingSection == 11)
            {
                lblUpper.Text = "Upper";
                OprationCountUppersection = 0;
                //BindAddUpper_Add();
                BindUpperAdd();
                StitchGridShowHide(2);
                trUpper.Visible = true;
                DivUpper_Add.Visible = true;
                DivUpperlist_Add.Visible = true;

            }
            if (StitchingSection == 12)
            {
                lblUppershell.Text = "Upper shell";
                OprationCountUppershell = 0;
                //BindAddUppershell_Add();
                BindUppershellAdd();
                StitchGridShowHide(2);
                trUppershell.Visible = true;
                DivUppershell_Add.Visible = true;
                DivUppershelllist_Add.Visible = true;


            }
            if (StitchingSection == 13)
            {

                lblbLowershell.Text = "Lower shell";
                OprationCountLowershell = 0;
                //BindAddLowershell_Add();
                BindLowershellAdd();
                StitchGridShowHide(2);
                trLowershell.Visible = true;
                DivLowershell_Add.Visible = true;
                DivLowershelllist_Add.Visible = true;


            }
            if (StitchingSection == 14)
            {
                lblShellsection.Text = "Shell Section";
                OprationCountShellsection = 0;
                //BindAddShellsection_Add();
                BindShellsectionAdd();

                StitchGridShowHide(2);
                trShellsection.Visible = true;
                DivShellsection_Add.Visible = true;
                DivShellsectionlist_Add.Visible = true;



            }
            if (StitchingSection == 15)
            {
                lblWaistSection.Text = "Waist Section";
                OprationCountWaistSection = 0;
                //BindAddWaistSection_Add();
                BindWaistSectionAdd();

                StitchGridShowHide(2);
                trWaistSection.Visible = true;
                DivWaistSection_Add.Visible = true;
                DivWaistSectionlist_Add.Visible = true;



            }
            if (StitchingSection == 16)
            {

                lblBandsection.Text = "Band Section";
                OprationCountBandsection = 0;
                //BindAddBandsection_Add();
                BindBandsectionAdd();

                StitchGridShowHide(2);
                trBandsection.Visible = true;
                DivBandsection_Add.Visible = true;
                DivBandsectionlist_Add.Visible = true;



            }
            // added by abhishek on 3/9/2015
            if (StitchingSection == 17)
            {


                lblnecksection.Text = "neck Section";
                OprationCountNeckSection = 0;
                //BindAddnecksection_Add();
                BindnecksectionAdd();
                StitchGridShowHide(2);
                trNecksection.Visible = true;
                Divnecksection_Add.Visible = true;
                Divnecksectionlist_Add.Visible = true;
            }
            if (StitchingSection == 18)
            {


                lblneckfaching.Text = "Neck Facing";
                OprationCountNecFaching = 0;
                //BindAddneckfaching_Add();
                BindneckfachingAdd();
                StitchGridShowHide(2);
                trneckfacing.Visible = true;
                Divneckfaching_Add.Visible = true;
                Divneckfachinglist_Add.Visible = true;

            }
            if (StitchingSection == 19)
            {

                lblf_back.Text = "front & Back";
                OprationCountf_back = 0;
                //BindAddf_back_Add();
                Bindf_backAdd();
                StitchGridShowHide(2);
                trf_back.Visible = true;
                Divf_back_Add.Visible = true;
                Divf_backlist_Add.Visible = true;


            }
            //end by abhishek 3/9/2015
        }
        //end by abhishek on 24/10/2015

        protected void StitchGridShowHide(int Flag)
        {
            if (Flag == 2)
            {
                trFront.Visible = false;
                trBack.Visible = false;
                trcoller.Visible = false;
                trsleep.Visible = false;
                trneck.Visible = false;
                trLining.Visible = false;
                trlower.Visible = false;
                trbottom.Visible = false;
                trassembly.Visible = false;
                trPiping.Visible = false;
                trUpper.Visible = false;
                trUppershell.Visible = false;
                trLowershell.Visible = false;
                trShellsection.Visible = false;
                trWaistSection.Visible = false;
                trBandsection.Visible = false;
                // added by abhishek on 3/9/2015
                trNecksection.Visible = false;
                trneckfacing.Visible = false;
                trf_back.Visible = false;
                //end by abhishek 3/9/2015


                divfront.Visible = false;
                divBack.Visible = false;
                divcoller.Visible = false;
                divsleep.Visible = false;
                divneck.Visible = false;
                divLining.Visible = false;
                divlower.Visible = false;
                divbottom.Visible = false;
                divassembly.Visible = false;
                divPiping.Visible = false;
                divUpper.Visible = false;
                divUppershell.Visible = false;
                divLowershell.Visible = false;
                divShellsection.Visible = false;
                divWaistSection.Visible = false;
                divBandsection.Visible = false;

                // added by abhishek on 3/9/2015
                divNnecksection.Visible = false;
                Divneckfaching.Visible = false;
                divf_back.Visible = false;

                //end by abhishek 3/9/2015


                grdStitchingFont.Visible = false;
                grdStitchingBack.Visible = false;
                grdStitchingcoller.Visible = false;
                grdStitchingsleep.Visible = false;
                grdStitchingneck.Visible = false;
                grdStitchingLining.Visible = false;
                grdStitchinglower.Visible = false;


                grdStitchingbottom.Visible = false;
                divbottom.Visible = false;
                divbottombtn.Visible = false;
                divbottom_add.Visible = false;

                //back
                grdStitchingBack.Visible = false;
                divBack.Visible = false;
                DivBacklist_Add.Visible = false;
                DivBack_Add.Visible = false;
                //back end


                //Coller
                grdStitchingcoller.Visible = false;
                divcoller.Visible = false;
                DivCollerlist_Add.Visible = false;
                DivColler_Add.Visible = false;
                //Coller end


                //Sleep
                grdStitchingsleep.Visible = false;
                divsleep.Visible = false;
                DivSleeplist_Add.Visible = false;
                DivSleep_Add.Visible = false;
                //Sleep end


                //neck
                grdStitchingneck.Visible = false;
                divneck.Visible = false;
                DivNecklist_Add.Visible = false;
                DivNeck_Add.Visible = false;
                //neck end


                //lining
                grdStitchingLining.Visible = false;
                divLining.Visible = false;
                Divlininglist_Add.Visible = false;
                Divlining_Add.Visible = false;
                //lining end


                //lower
                grdStitchinglower.Visible = false;
                divlower.Visible = false;
                Divlowerlist_Add.Visible = false;
                Divlower_Add.Visible = false;
                //lower end

                //Piping
                grdPiping.Visible = false;
                divPiping.Visible = false;
                DivPipinglist_Add.Visible = false;
                DivPiping_Add.Visible = false;
                //Piping end


                //Upper
                grdUppersection.Visible = false;
                divUpper.Visible = false;
                DivUpperlist_Add.Visible = false;
                DivUpper_Add.Visible = false;
                //Upper end


                //Uppershell
                grdUppershell.Visible = false;
                divUppershell.Visible = false;
                DivUppershelllist_Add.Visible = false;
                DivUppershell_Add.Visible = false;
                //Uppershell end


                //Lowershell
                grdLowershell.Visible = false;
                divLowershell.Visible = false;
                DivLowershelllist_Add.Visible = false;
                DivLowershell_Add.Visible = false;
                //Lowershell end


                //Shellsection
                grdShellsection.Visible = false;
                divShellsection.Visible = false;
                DivShellsectionlist_Add.Visible = false;
                DivShellsection_Add.Visible = false;
                //Shellsection end


                //WaistSectionsection
                grdWaistSection.Visible = false;
                divWaistSection.Visible = false;
                DivWaistSection_Add.Visible = false;
                DivWaistSectionlist_Add.Visible = false;
                //WaistSectionsection end


                //Bandsectionsection
                grdBandsection.Visible = false;
                divBandsection.Visible = false;
                DivBandsection_Add.Visible = false;
                DivBandsectionlist_Add.Visible = false;
                //Bandsectionsection end

                //necksectionsection
                grdnecksection.Visible = false;
                divNnecksection.Visible = false;
                Divnecksection_Add.Visible = false;
                Divnecksectionlist_Add.Visible = false;
                //necksectionsection end

                //neckfachingsection
                grdneckfaching.Visible = false;
                Divneckfaching.Visible = false;
                Divneckfaching_Add.Visible = false;
                Divneckfachinglist_Add.Visible = false;
                //neckfachingsection end


                //f_backsection
                grdf_back.Visible = false;
                divf_back.Visible = false;
                Divf_back_Add.Visible = false;
                Divf_backlist_Add.Visible = false;
                //f_backsection end


                //Front section

                grdStitchingFont.Visible = false;
                divf_back.Visible = false;
                divfront.Visible = false;
                DivFront_Add.Visible = false;
                DivFrontlist_Add.Visible = false;
                //Front section end

                grdStitchingassembly.Visible = false;
                btnAssemblyAddnew.Visible = false;
                divAddassemblybtn.Visible = false;
                divStitchingAssemblyAdd.Visible = false;


                grdPiping.Visible = false;
                //grdUppersection.Visible = false;
                grdUppershell.Visible = false;
                grdLowershell.Visible = false;
                grdShellsection.Visible = false;
                grdWaistSection.Visible = false;
                grdBandsection.Visible = false;



                ////// added by abhishek on 3/9/2015
                //grdnecksection.Visible = false;
                //grdneckfaching.Visible = true;
                //grdneckfaching.Visible = true;
                //////end by abhishek 3/9/2015
            }
            if (Flag == 3)
            {
                grdStitchingFont.Visible = true;
                grdStitchingBack.Visible = true;
                grdStitchingcoller.Visible = true;
                grdStitchingsleep.Visible = true;
                grdStitchingneck.Visible = true;
                grdStitchingLining.Visible = true;
                grdStitchinglower.Visible = true;
                grdStitchingbottom.Visible = true;
                grdStitchingassembly.Visible = true;
                grdPiping.Visible = true;
                grdUppersection.Visible = true;
                grdUppershell.Visible = true;
                grdLowershell.Visible = true;
                grdShellsection.Visible = true;
                grdWaistSection.Visible = true;
                grdBandsection.Visible = true;

                // added by abhishek on 3/9/2015
                grdnecksection.Visible = true;
                grdneckfaching.Visible = true;
                grdf_back.Visible = true;

                //end by abhishek 3/9/2015


                divfront.Visible = true;
                divBack.Visible = true;
                divcoller.Visible = true;
                divsleep.Visible = true;
                divneck.Visible = true;
                divLining.Visible = true;
                divlower.Visible = true;
                divbottom.Visible = true;
                divassembly.Visible = true;
                divPiping.Visible = true;
                divUpper.Visible = true;
                divUppershell.Visible = true;
                divLowershell.Visible = true;
                divShellsection.Visible = true;
                divWaistSection.Visible = true;
                divBandsection.Visible = true;

                // added by abhishek on 3/9/2015
                divNnecksection.Visible = true;
                Divneckfaching.Visible = true;
                divf_back.Visible = true;
                //end by abhishek 3/9/2015


                trFront.Visible = true;
                trBack.Visible = true;
                trcoller.Visible = true;
                trsleep.Visible = true;
                trneck.Visible = true;
                trLining.Visible = true;
                trlower.Visible = true;
                trbottom.Visible = true;
                trassembly.Visible = true;
                trPiping.Visible = true;
                trUpper.Visible = true;
                trUppershell.Visible = true;
                trLowershell.Visible = true;
                trShellsection.Visible = true;
                trWaistSection.Visible = true;
                trBandsection.Visible = true;

                divbottombtn.Visible = true;
                divbottom_add.Visible = true;

                divAddassemblybtn.Visible = true;
                divStitchingAssemblyAdd.Visible = true;

                // added by abhishek on 3/9/2015
                trNecksection.Visible = true;
                trneckfacing.Visible = true;
                trf_back.Visible = true;

                //end by abhishek 3/9/2015

            }
        }

        protected void btnAssemblyAdd_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingassemblyOB", "tblOperationstitching_assembly", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "");
            grdStitchingassembly.DataSource = dtBindGrid;
            grdStitchingassembly.DataBind();
        }

        protected void btnAddassemblyList_Click(object sender, EventArgs e)
        {
            divStitchingAssemblyAdd.Visible = false;
            //btnAddStichingassembly.Visible = false;
            //btnadd_assembly.Visible = false;

            BindStitchingassemblyGrid("");
            StitchGridShowHide(2);
            btnAssemblyAddnew.Visible = true;
            grdStitchingassembly.Visible = true;
            divassembly.Visible = true;
            trassembly.Visible = true;
            ViewState["assembly"] = "9";
            lblassembly.Text = "ASSEMBLY" + " " + "(Total number of operation:" + OprationCountassembly + ")";
            OprationCountassembly = 0;
            btnAssemblyAddnew.Visible = true;


        }

        protected void BindAddAssembly()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    GrdStitchingAssemblyAdd.Columns.Add(boundField);
                }
            }
        }

        protected void BindAssemblyAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingassemblyOB", "tblOperationstitching_assembly", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "First");
            GrdStitchingAssemblyAdd.DataSource = dtBindGrid;
            GrdStitchingAssemblyAdd.DataBind();
        }

        public static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("FactoryWorkSpace", typeof(string));
            // Here we add five DataRows.
            table.Rows.Add("");
            return table;
        }



        protected void GrdStitchingAssemblyAdd_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountassembly = OprationCountassembly + 1;
            //end by abhishek on 24/10/2015

            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    GrdStitchingAssemblyAdd.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    GrdStitchingAssemblyAdd.HeaderRow.Style.Add("width", "250px");
                    GrdStitchingAssemblyAdd.HeaderRow.Style.Add("class", "topMenu2");
                    GrdStitchingAssemblyAdd.HeaderRow.Style.Add("text-align", "center");
                    GrdStitchingAssemblyAdd.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtblanck";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtblanck";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamassemblyAdd(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }

        protected void grdStitchingassembly_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingassembly.PageIndex = e.NewPageIndex;
            grdStitchingassembly.EditIndex = -1;
            BindStitchingassemblyGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchingFont_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingFont.PageIndex = e.NewPageIndex;
            grdStitchingFont.EditIndex = -1;
            BindGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchingBack_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingBack.PageIndex = e.NewPageIndex;
            grdStitchingBack.EditIndex = -1;
            BindStitchingBackGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchingcoller_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingcoller.PageIndex = e.NewPageIndex;
            grdStitchingcoller.EditIndex = -1;
            BindStitchingcollerGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchingsleep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingsleep.PageIndex = e.NewPageIndex;
            grdStitchingsleep.EditIndex = -1;
            BindStitchingsleepGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchingneck_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingneck.PageIndex = e.NewPageIndex;
            grdStitchingneck.EditIndex = -1;
            BindStitchingneckGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchingLining_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingLining.PageIndex = e.NewPageIndex;
            grdStitchingLining.EditIndex = -1;
            BindStitchingLiningGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchinglower_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchinglower.PageIndex = e.NewPageIndex;
            grdStitchinglower.EditIndex = -1;
            BindStitchinglowerGrid(txtsearch.Text.Trim());
        }
        protected void grdStitchingbottom_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStitchingbottom.PageIndex = e.NewPageIndex;
            grdStitchingbottom.EditIndex = -1;
            BindStitchingbottomGrid(txtsearch.Text.Trim());
        }
        protected void grdPiping_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPiping.PageIndex = e.NewPageIndex;
            grdPiping.EditIndex = -1;
            BindStitchingPipingGrid(txtsearch.Text.Trim());
        }
        protected void grdUppersection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUppersection.PageIndex = e.NewPageIndex;
            grdUppersection.EditIndex = -1;
            BindUppersectionGrid(txtsearch.Text.Trim());
        }
        protected void grdUppershell_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUppershell.PageIndex = e.NewPageIndex;
            grdUppershell.EditIndex = -1;
            BindUpperShellsectionGrid(txtsearch.Text.Trim());
        }
        protected void grdLowershell_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLowershell.PageIndex = e.NewPageIndex;
            grdLowershell.EditIndex = -1;
            BindlowerShellsectionGrid(txtsearch.Text.Trim());
        }
        protected void grdWaistSection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdWaistSection.PageIndex = e.NewPageIndex;
            grdWaistSection.EditIndex = -1;
            BindWaistSectionGrid(txtsearch.Text.Trim());
        }
        protected void grdShellsection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdShellsection.PageIndex = e.NewPageIndex;
            grdShellsection.EditIndex = -1;
            BindShellsectionsectionGrid(txtsearch.Text.Trim());
        }

        protected void grdBandsection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBandsection.PageIndex = e.NewPageIndex;
            grdBandsection.EditIndex = -1;
            BindBandSectionGrid(txtsearch.Text.Trim());
        }
        protected void grdnecksection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdnecksection.PageIndex = e.NewPageIndex;
            grdnecksection.EditIndex = -1;
            BindBandSectionGrid_neckSection(txtsearch.Text.Trim());
        }
        protected void grdneckfaching_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdneckfaching.PageIndex = e.NewPageIndex;
            grdneckfaching.EditIndex = -1;
            BindBandSectionGrid_neckfaching(txtsearch.Text.Trim());
        }
        protected void grdf_back_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdf_back.PageIndex = e.NewPageIndex;
            grdf_back.EditIndex = -1;
            BindBandSectionGrid_neckSection_frontback(txtsearch.Text.Trim());
        }
        protected void btnassemblyAdd_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingassemblyOB", "tblOperationstitching_assembly", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "");
            GrdStitchingAssemblyAdd.DataSource = dtBindGrid;
            GrdStitchingAssemblyAdd.DataBind();
        }

        protected void btnAssemblyAddnew_Click(object sender, EventArgs e)
        {
            //BindAddAssembly();
            BindAssemblyAdd();
            StitchGridShowHide(2);
            trassembly.Visible = true;
            divStitchingAssemblyAdd.Visible = true;
            trassembly.Visible = true;
            divAddassemblybtn.Visible = true;
        }
        // added by abhishek on 3/9/2015-----------------------------------------------------------------//


        protected void BindBandSectionGrid_neckSection(string Searchtext) //for new neck section
        {

            if (ViewState["dtnewNeck_new_section"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNewNeckOB", "tblOperationstitching_NewNeck", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", Searchtext);
                grdnecksection.DataSource = dtBindGrid;
                grdnecksection.DataBind();
                OprationCountNeckSection = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["NeckNewsection"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNewNeckOB", "tblOperationstitching_NewNeck", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", Searchtext);
                    grdnecksection.DataSource = dtBindGrid;
                    grdnecksection.DataBind();
                    ViewState["NeckNewsection"] = null;
                    OprationCountNeckSection = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewNeck_new_section"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNewNeckOB", "tblOperationstitching_NewNeck", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", Searchtext);
                    grdnecksection.DataSource = dtnew;
                    grdnecksection.DataBind();
                    OprationCountNeckSection = dtBindGrid.Rows.Count;
                }
            }

            lblnecksection.Text = "New Neck" + " " + "(Total number of operation:" + OprationCountNeckSection + ")";
        }

        protected void grdnecksection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //added by abhishek on 24/10/2015
            OprationCountNeckSection = OprationCountNeckSection + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();

            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOB_necksection(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdnecksection.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)"; ;
                    lblName.Width = 70;
                    grdnecksection.HeaderRow.Style.Add("width", "250px");
                    grdnecksection.HeaderRow.Style.Add("class", "topMenu2");
                    grdnecksection.HeaderRow.Style.Add("text-align", "center");
                    grdnecksection.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamNeck_Nec_Section(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Width = 50;
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamNeck_Section(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }
        //protected void btnnecksection_Click(object sender, EventArgs e)
        //{

        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNewNeckOB", "tblOperationstitching_NewNeck", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
        //    //9/9/2015
        //    grdnecksection.DataSource = dtBindGrid;
        //    grdnecksection.DataBind();
        //    //end 9/9/2015
        //}

        //end neck section



        protected void grdneckfaching_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountNecFaching = OprationCountNecFaching + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();

            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOB_necksection_faching(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdneckfaching.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)"; ;
                    lblName.Width = 70;
                    grdneckfaching.HeaderRow.Style.Add("width", "250px");
                    grdneckfaching.HeaderRow.Style.Add("class", "topMenu2");
                    grdneckfaching.HeaderRow.Style.Add("text-align", "center");
                    grdneckfaching.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamNeck_Nec_Section_faching(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["StitchingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.CssClass = "number";
                    txtGarmentType.Width = 50;
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamNeck_faching(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }

        }
        //protected void btnneckfaching_Click(object sender, EventArgs e)
        //{

        //    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNeckfacingOB", "tblOperationstitching_Neckfacing", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
        //    grdneckfaching.DataSource = dtBindGrid;
        //    grdneckfaching.DataBind();
        //}


        protected void BindBandSectionGrid_neckfaching(string Searchtext) //for new neck section
        {

            if (ViewState["dtnewNeck_new_faching"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNeckfacingOB", "tblOperationstitching_Neckfacing", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", Searchtext);
                grdneckfaching.DataSource = dtBindGrid;
                grdneckfaching.DataBind();
                OprationCountNecFaching = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["NeckNewfaching"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNeckfacingOB", "tblOperationstitching_Neckfacing", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", Searchtext);
                    grdneckfaching.DataSource = dtBindGrid;
                    grdneckfaching.DataBind();
                    ViewState["NeckNewfaching"] = null;
                    OprationCountNecFaching = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewNeck_new_faching"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNeckfacingOB", "tblOperationstitching_Neckfacing", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", Searchtext);
                    grdneckfaching.DataSource = dtnew;
                    grdneckfaching.DataBind();
                    OprationCountNecFaching = dtBindGrid.Rows.Count;
                }
            }
            lblneckfaching.Text = "Neck facing" + " " + "(Total number of operation:" + OprationCountNecFaching + ")";
        }
        //end neck section--------------------------------------------------------------------------------//

        //for front and back section------------------------------------------------------------------------//
        protected void BindBandSectionGrid_neckSection_frontback(string Searchtext) //for front and back section
        {

            if (ViewState["dtnewNeck_new_faching_frontback"] == null)
            {
                dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontbackOB", "tblOperationstitching_Frontback", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", Searchtext);
                grdf_back.DataSource = dtBindGrid;
                grdf_back.DataBind();
                OprationCountf_back = dtBindGrid.Rows.Count;
            }
            else
            {
                if (ViewState["NeckNewfaching_frontback"] != null)
                {
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontbackOB", "tblOperationstitching_Frontback", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", Searchtext);
                    grdf_back.DataSource = dtBindGrid;
                    grdf_back.DataBind();
                    ViewState["NeckNewfaching_frontback"] = null;
                    OprationCountf_back = dtBindGrid.Rows.Count;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnewNeck_new_faching_frontback"]);
                    dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontbackOB", "tblOperationstitching_Frontback", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", Searchtext);
                    grdf_back.DataSource = dtnew;
                    grdf_back.DataBind();
                    OprationCountf_back = dtBindGrid.Rows.Count;
                }
            }
            lblf_back.Text = "front & back" + " " + "(Total number of Operation:" + OprationCountf_back + ")";
        }



        protected void grdf_back_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            OprationCountf_back = OprationCountf_back + 1;
            //end by abhishek on 24/10/2015
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();

            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineStichingOB_necksection_frontback(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //

                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdf_back.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)"; ;
                    lblName.Width = 70;
                    grdf_back.HeaderRow.Style.Add("width", "250px");
                    grdf_back.HeaderRow.Style.Add("class", "topMenu2");
                    grdf_back.HeaderRow.Style.Add("text-align", "center");
                    grdf_back.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetStichingOBSamNeck_Nec_Section_frontback(Convert.ToInt32(hdnOperationId.Value), GarmentId);

                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.CssClass = "myInputField";
                    txtGarmentType.Width = 50;

                    //txtGarmentType.Attributes.Add("onkeyup", "javascript:return doneTyping(this)");
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSamNeck_fachingfrontback(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }

        }
        protected void brnf_back_Click(object sender, EventArgs e)
        {

            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontbackOB", "tblOperationstitching_Frontback", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
            grdf_back.DataSource = dtBindGrid;
            grdf_back.DataBind();
        }
        //added by abhishek on 24/10/2015

        protected void btngo_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            //if (rbtnlistsection.SelectedValue == "2" || rbtnlistsection.SelectedValue == "3")
            //{
            //    rbtnlistsection_SelectedIndexChanged(this, e);
            //}
            //else if (rbtnlistsection.SelectedValue == "1")
            //{

            //    ddlStitchSection_SelectedIndexChanged(this, e);
            //}


            int rdo_selected = Convert.ToInt32(rbtnlistsection.SelectedValue);
            int ddl_selected = Convert.ToInt32(ddlStitchSection.SelectedValue);
            String Searchtxt = txtsearch.Text.Trim();

            switch (rdo_selected)
            {
                case 1:
                    switch (ddl_selected)
                    {
                        case -1:
                            //all list
                            break;
                        case 1:
                            //front 
                            DivFront_Add.Visible = false;
                            btnFornt.Visible = false;
                            BindGrid(Searchtxt);
                            //lblStitching.Text = "Front" + " " + "(Total number of opration:" + OprationCountfront + ")";
                            OprationCountfront = 0;
                            StitchGridShowHide(2);
                            btnFront_add.Visible = true;
                            grdStitchingFont.Visible = true;

                            divfront.Visible = true;
                            trFront.Visible = true;
                            ViewState["Front"] = "1";
                            btnFront_up_Add.Visible = true;
                            break;
                        case 2:
                            //back 

                            DivBack_Add.Visible = false;
                            //btnAddStichingBack.Visible = false;
                            BindStitchingBackGrid(Searchtxt);
                            // lblStitchingBack.Text = "Back" + " " + "(Total number of opration:" + OprationCountBack + ")";
                            OprationCountBack = 0;
                            StitchGridShowHide(2);
                            btnbank_add.Visible = true;
                            grdStitchingBack.Visible = true;

                            divBack.Visible = true;
                            trBack.Visible = true;

                            ViewState["Back"] = "2";
                            btnbacknew_Add.Visible = true;
                            break;

                        case 3:
                            //coller 

                            DivColler_Add.Visible = false;
                            btncoller.Visible = false;
                            //btnAddStichingcoller.Visible = false;
                            BindStitchingcollerGrid(Searchtxt);
                            //   lblcoller.Text = "Coller" + " " + "(Total number of opration:" + OprationCountcoller + ")";
                            OprationCountcoller = 0;
                            StitchGridShowHide(2);
                            btnColler_add.Visible = true;
                            grdStitchingcoller.Visible = true;
                            divcoller.Visible = true;
                            trcoller.Visible = true;
                            ViewState["coller"] = "3";
                            //btnlower_up_Add.Visible = true;
                            btnColler_up_Add.Visible = true;
                            break;

                        case 4:
                            //sleev 

                            DivSleep_Add.Visible = false;
                            btnsleep.Visible = false;
                            //btnAddStichingsleep.Visible = false;
                            BindStitchingsleepGrid(Searchtxt);
                            //  lblsleep.Text = "Sleep" + " " + "(Total number of opration:" + OprationCountsleep + ")";
                            OprationCountsleep = 0;
                            StitchGridShowHide(2);
                            btnSleep_add.Visible = true;
                            grdStitchingsleep.Visible = true;

                            divsleep.Visible = true;
                            trsleep.Visible = true;
                            ViewState["sleep"] = "4";
                            btnsleep_up_Add.Visible = true;
                            break;
                        case 5:
                            //Frill 

                            DivNeck_Add.Visible = false;
                            btnneck.Visible = false;
                            // btnAddStichingNeck.Visible = false;
                            BindStitchingneckGrid(Searchtxt);
                            // lblneck.Text = "Frill" + " " + "(Total number of opration:" + OprationCountneck + ")";
                            OprationCountneck = 0;
                            StitchGridShowHide(2);
                            btnNeck_add.Visible = true;
                            grdStitchingneck.Visible = true;

                            divneck.Visible = true;
                            trneck.Visible = true;
                            ViewState["Neck"] = "5";
                            btnNeck_up_Add.Visible = true;
                            break;


                        case 6:
                            //lining 

                            Divlining_Add.Visible = false;
                            btnLining.Visible = false;
                            //btnAddStichingLining.Visible = false;
                            BindStitchingLiningGrid(Searchtxt);
                            // lblLining.Text = "lining" + " " + "(Total number of opration:" + OprationCountLining + ")";
                            OprationCountLining = 0;
                            StitchGridShowHide(2);
                            btnlining_add.Visible = true;
                            grdStitchingLining.Visible = true;

                            divLining.Visible = true;
                            trLining.Visible = true;
                            ViewState["lining"] = "6";
                            btnlining_up_Add.Visible = true;
                            break;

                        case 7:
                            //lower 
                            Divlower_Add.Visible = false;
                            btnlower.Visible = false;
                            //btnAddStichinglower.Visible = false;
                            BindStitchinglowerGrid(Searchtxt);
                            //  lbllower.Text = "lower" + " " + "(Total number of opration:" + OprationCountlower + ")";
                            OprationCountlower = 0;
                            StitchGridShowHide(2);
                            btnlower_add.Visible = true;
                            grdStitchinglower.Visible = true;

                            divlower.Visible = true;
                            trlower.Visible = true;
                            ViewState["lower"] = "7";
                            btnlower_up_Add.Visible = true;
                            break;




                        case 8:
                            //CAMI 
                            divbottom_add.Visible = false;
                            // btnAddStichingbottom.Visible = false;
                            BindStitchingbottomGrid(Searchtxt);
                            // lblbottom.Text = "CAMI" + " " + "(Total number of opration:" + OprationCountbottom + ")";
                            OprationCountbottom = 0;
                            StitchGridShowHide(2);
                            btnbottom_add.Visible = true;
                            grdStitchingbottom.Visible = true;

                            divbottom.Visible = true;
                            trbottom.Visible = true;

                            ViewState["bottom"] = "8";
                            btnbottom_addnew.Visible = true;
                            break;
                        case 9:
                            divStitchingAssemblyAdd.Visible = false;


                            BindStitchingassemblyGrid(Searchtxt);
                            StitchGridShowHide(2);
                            btnAssemblyAddnew.Visible = true;
                            grdStitchingassembly.Visible = true;
                            divassembly.Visible = true;
                            trassembly.Visible = true;
                            ViewState["assembly"] = "9";
                            //  lblassembly.Text = "ASSEMBLY" + " " + "(Total number of opration:" + OprationCountassembly + ")";
                            OprationCountassembly = 0;
                            btnAssemblyAddnew.Visible = true;
                            break;
                        case 10:
                            DivPiping_Add.Visible = false;
                            btnPiping.Visible = false;
                            //btnAddStichingPiping.Visible = false;
                            BindStitchingPipingGrid(Searchtxt);
                            //  lblPiping.Text = "Piping" + " " + "(Total number of opration:" + OprationCountPiping + ")";
                            OprationCountPiping = 0;
                            StitchGridShowHide(2);
                            btnPiping_add.Visible = true;
                            grdPiping.Visible = true;

                            divPiping.Visible = true;
                            trPiping.Visible = true;
                            ViewState["Piping"] = "10";
                            btnPiping_up_Add.Visible = true;
                            break;

                        case 11:

                            DivUpper_Add.Visible = false;
                            btnUppersection.Visible = false;
                            //btnAddStichingUpper.Visible = false;
                            BindUppersectionGrid(Searchtxt);
                            // lblUpper.Text = "Upper" + " " + "(Total number of opration:" + OprationCountUppersection + ")";
                            OprationCountUppersection = 0;
                            StitchGridShowHide(2);
                            btnUpper_add.Visible = true;
                            grdUppersection.Visible = true;

                            divUpper.Visible = true;
                            trUpper.Visible = true;
                            ViewState["Upper"] = "8";
                            btnUpper_up_Add.Visible = true;
                            break;


                        case 12:

                            DivUppershell_Add.Visible = false;
                            btnUppershell.Visible = false;
                            // btnAddStichingUppershell.Visible = false;
                            BindUpperShellsectionGrid(Searchtxt);
                            // lblUppershell.Text = "Uppershell" + " " + "(Total number of opration:" + OprationCountUppershell + ")";
                            OprationCountUppershell = 0;
                            StitchGridShowHide(2);
                            btnUppershell_add.Visible = true;
                            grdUppershell.Visible = true;

                            divUppershell.Visible = true;
                            trUppershell.Visible = true;
                            ViewState["Uppershell"] = "12";
                            btnUppershell_up_Add.Visible = true;
                            break;

                        case 13:

                            DivLowershell_Add.Visible = false;
                            btnLowershell.Visible = false;
                            //btnAddStichingLowershell.Visible = false;
                            BindlowerShellsectionGrid(Searchtxt);
                            //lblbLowershell.Text = "Lowershell" + " " + "(Total number of opration:" + OprationCountLowershell + ")";
                            OprationCountLowershell = 0;
                            StitchGridShowHide(2);
                            btnLowershell_add.Visible = true;
                            grdLowershell.Visible = true;
                            divLowershell.Visible = true;
                            trLowershell.Visible = true;
                            ViewState["Lowershell"] = "13";
                            btnLowershell_up_Add.Visible = true;
                            break;


                        case 14:

                            DivShellsection_Add.Visible = false;
                            btnShellsection.Visible = false;
                            //btnAddStichingShellsection.Visible = false;
                            BindShellsectionsectionGrid(Searchtxt);
                            // lblShellsection.Text = "Shellsection" + " " + "(Total number of opration:" + OprationCountShellsection + ")";
                            OprationCountShellsection = 0;
                            StitchGridShowHide(2);
                            btnShellsection_add.Visible = true;
                            grdShellsection.Visible = true;

                            divShellsection.Visible = true;
                            trShellsection.Visible = true;
                            ViewState["Shellsection"] = "8";
                            btnShellsection_up_Add.Visible = true;
                            break;

                        case 15:


                            DivWaistSection_Add.Visible = false;
                            btnWaistSection.Visible = false;
                            //btnAddStichingWaistSection.Visible = false;

                            BindWaistSectionGrid(Searchtxt);
                            // lblWaistSection.Text = "WaistSection" + " " + "(Total number of opration:" + OprationCountWaistSection + ")";
                            OprationCountWaistSection = 0;
                            StitchGridShowHide(2);
                            btnWaistSection_add.Visible = true;

                            grdWaistSection.Visible = true;

                            divWaistSection.Visible = true;
                            trWaistSection.Visible = true;
                            ViewState["WaistSection"] = "15";
                            btnWaistSection_up_Add.Visible = true;
                            break;

                        case 16:


                            DivBandsection_Add.Visible = false;
                            btnBandsection.Visible = false;
                            //btnAddStichingBandsection.Visible = false;

                            BindBandSectionGrid(Searchtxt);
                            //  lblBandsection.Text = "Bandsection" + " " + "(Total number of opration:" + OprationCountBandsection + ")";
                            OprationCountBandsection = 0;
                            StitchGridShowHide(2);
                            btnBandsection_add.Visible = true;
                            grdBandsection.Visible = true;



                            divBandsection.Visible = true;
                            trBandsection.Visible = true;
                            ViewState["Bandsection"] = "16";
                            btnBandsection_up_Add.Visible = true;
                            break;

                        case 17:

                            Divnecksection_Add.Visible = false;
                            btnnecksection.Visible = false;
                            //btnAddStichingNeckSection.Visible = false;
                            BindBandSectionGrid_neckSection(Searchtxt);

                            //
                            //lblnecksection.Text = "necksection" + " " + "(Total number of opration:" + OprationCountNeckSection + ")";
                            OprationCountNeckSection = 0;
                            StitchGridShowHide(2);
                            btnnecksection_add.Visible = true;
                            grdnecksection.Visible = true;

                            divNnecksection.Visible = true;
                            trNecksection.Visible = true;
                            ViewState["necksection"] = "17";
                            btnnecksection_up_Add.Visible = true;
                            break;

                        case 18:

                            Divneckfaching_Add.Visible = false;
                            btnneckfaching.Visible = false;
                            //btnAddStichingNecFaching.Visible = false;
                            BindBandSectionGrid_neckfaching(Searchtxt);

                            //  lblneckfaching.Text = "neckfaching" + " " + "(Total number of opration:" + OprationCountNecFaching + ")";
                            OprationCountNecFaching = 0;
                            StitchGridShowHide(2);
                            btnneckfaching_add.Visible = true;
                            grdneckfaching.Visible = true;

                            Divneckfaching.Visible = true;
                            trneckfacing.Visible = true;
                            ViewState["neckfaching"] = "18";
                            btnneckfaching_up_Add.Visible = true;
                            break;

                        case 19:
                            Divf_back_Add.Visible = false;
                            brnf_back.Visible = false;
                            //btnaddf_back.Visible = false;

                            BindBandSectionGrid_neckSection_frontback(Searchtxt);

                            // lblf_back.Text = "front & back" + " " + "(Total number of opration:" + OprationCountf_back + ")";
                            OprationCountf_back = 0;
                            StitchGridShowHide(2);
                            btnf_back_add.Visible = true;
                            grdf_back.Visible = true;

                            divf_back.Visible = true;
                            trf_back.Visible = true;
                            ViewState["f_back"] = "20";
                            btnf_back_up_Add.Visible = true;
                            break;



                    }
                    break;
                case 2:
                    dtBindGridFinishing = obj_AdminController.GetFinishingOB(0, 0, Searchtxt);
                    grdFinishingOB.DataSource = dtBindGridFinishing;
                    grdFinishingOB.DataBind();

                    lblfinshing.Text = "(Total number of operation:" + finishingOb + ")";
                    finishingOb = 0;
                    break;
                case 3:
                    BindStichedGrd(Searchtxt);
                    BindFinishingGrid(Searchtxt);
                    break;

            }


        }


        /*this method for make all opration just like to Assembly opration @bhishek*/

        //bottom start------------------------------------------------------------------------//
        protected void btnbottom_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingbottomOB", "tblOperationstitching_bottom", "Operationstitching_bottom", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "");
            grdbottom_add.DataSource = dtBindGrid;
            grdbottom_add.DataBind();
        }
        protected void btnbottom_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingbottomOB", "tblOperationstitching_bottom", "Operationstitching_bottom", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "");
            grdStitchingbottom.DataSource = dtBindGrid;
            grdStitchingbottom.DataBind();
        }
        protected void BindbottomAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingbottomOB", "tblOperationstitching_bottom", "Operationstitching_bottom", "FactoryWorkSpace", "GarmentTypeID", "StitchingSAM", "First");
            grdbottom_add.DataSource = dtBindGrid;
            grdbottom_add.DataBind();
        }
        protected void grdbottom_add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //added by abhishek on 24/10/2015
            // OprationCountbottom = OprationCountbottom + 1;
            //end by abhishek on 24/10/2015

            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdbottom_add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdbottom_add.HeaderRow.Style.Add("width", "250px");
                    grdbottom_add.HeaderRow.Style.Add("class", "topMenu2");
                    grdbottom_add.HeaderRow.Style.Add("text-align", "center");
                    grdbottom_add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtbottom_add_blanck";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtbottom_add_blanck";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBbottom_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }
        protected void btnbottom_list_Click(object sender, EventArgs e)
        {

            divbottom_add.Visible = false;
            // btnAddStichingbottom.Visible = false;
            BindStitchingbottomGrid("");
            // lblbottom.Text = "CAMI" + " " + "(Total number of opration:" + OprationCountbottom + ")";
            OprationCountbottom = 0;
            StitchGridShowHide(2);
            btnbottom_add.Visible = true;
            grdStitchingbottom.Visible = true;

            divbottom.Visible = true;
            trbottom.Visible = true;

            ViewState["bottom"] = "8";
            btnbottom_addnew.Visible = true;




        }
        protected void BindAddbottom_add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdbottom_add.Columns.Add(boundField);
                }
            }
        }
        protected void btnbottom_addnew_Click(object sender, EventArgs e)
        {

            BindbottomAdd();
            StitchGridShowHide(2);
            trbottom.Visible = true;
            divbottom_add.Visible = true;
            divbottombtn.Visible = true;
            lblbottom.Text = "CAMI";



        }
        //bottom end------------------------------------------------------------------------------//

        //Back start------------------------------------------------------------------------//

        protected void btnbank_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingbackOB", "tblOperationstitching_back", "Operationstitching_back", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdBack_Add.DataSource = dtBindGrid;
            grdBack_Add.DataBind();
        }
        protected void BindBackAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingbackOB", "tblOperationstitching_back", "Operationstitching_back", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdBack_Add.DataSource = dtBindGrid;
            grdBack_Add.DataBind();
        }
        protected void grdBack_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdBack_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdBack_Add.HeaderRow.Style.Add("width", "250px");
                    grdBack_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdBack_Add.HeaderRow.Style.Add("text-align", "center");
                    grdBack_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationback_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtbottom_add_blanck";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBBack_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }
        protected void btnAddBack_add_List_Click(object sender, EventArgs e)
        {

            DivBack_Add.Visible = false;
            //btnAddStichingBack.Visible = false;
            BindStitchingBackGrid("");
            // lblStitchingBack.Text = "Back" + " " + "(Total number of opration:" + OprationCountBack + ")";
            OprationCountBack = 0;
            StitchGridShowHide(2);
            btnbank_add.Visible = true;
            grdStitchingBack.Visible = true;

            divBack.Visible = true;
            trBack.Visible = true;

            ViewState["Back"] = "2";
            btnbacknew_Add.Visible = true;




        }
        protected void BindAddBack_add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdBack_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnbacknew_Add_Click(object sender, EventArgs e)
        {

            BindBackAdd();
            StitchGridShowHide(2);
            trBack.Visible = true;
            divbottom_add.Visible = true;
            DivBack_Add.Visible = true;
            DivBacklist_Add.Visible = true;
            lblStitchingBack.Text = "Back";

        }
        //Back end------------------------------------------------------------------------------//

        //Coller start------------------------------------------------------------------------//


        protected void btnColler_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingcollerOB", "tblOperationstitching_coller", "Operationstitching_coller", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdColler_Add.DataSource = dtBindGrid;
            grdColler_Add.DataBind();
        }
        protected void BindCollerAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingcollerOB", "tblOperationstitching_coller", "Operationstitching_coller", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdColler_Add.DataSource = dtBindGrid;
            grdColler_Add.DataBind();
        }
        protected void btncoller_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingcollerOB", "tblOperationstitching_coller", "Operationstitching_coller", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdStitchingcoller.DataSource = dtBindGrid;
            grdStitchingcoller.DataBind();
        }
        protected void grdColler_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdColler_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdColler_Add.HeaderRow.Style.Add("width", "250px");
                    grdColler_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdColler_Add.HeaderRow.Style.Add("text-align", "center");
                    grdColler_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationColler_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationColler_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBColler_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }
        protected void btnAddColler_add_Lists_Click(object sender, EventArgs e)
        {
            DivColler_Add.Visible = false;
            btncoller.Visible = false;
            //btnAddStichingcoller.Visible = false;
            BindStitchingcollerGrid("");
            // lblcoller.Text = "Coller" + " " + "(Total number of opration:" + OprationCountcoller + ")";
            OprationCountcoller = 0;
            StitchGridShowHide(2);
            btnColler_add.Visible = true;
            grdStitchingcoller.Visible = true;
            divcoller.Visible = true;
            trcoller.Visible = true;
            ViewState["coller"] = "3";
            //btnlower_up_Add.Visible = true;
            btnColler_up_Add.Visible = true;
        }
        protected void BindAddColler_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdColler_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnColler_up_Add_Click(object sender, EventArgs e)
        {

            BindCollerAdd();
            StitchGridShowHide(2);
            trcoller.Visible = true;

            DivColler_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivCollerlist_Add.Visible = true;
            lblcoller.Text = "Collar";

        }
        //Back end------------------------------------------------------------------------------//

        //Sleep start------------------------------------------------------------------------//


        protected void btnSleep_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingsleepOB", "tblOperationstitching_sleep", "Operationstitching_sleep", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdSleep_Add.DataSource = dtBindGrid;
            grdSleep_Add.DataBind();
        }
        protected void BindSleepAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingsleepOB", "tblOperationstitching_sleep", "Operationstitching_sleep", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdSleep_Add.DataSource = dtBindGrid;
            grdSleep_Add.DataBind();
        }
        protected void btnsleep_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingsleepOB", "tblOperationstitching_sleep", "Operationstitching_sleep", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdStitchingsleep.DataSource = dtBindGrid;
            grdStitchingsleep.DataBind();
        }
        protected void grdSleep_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdSleep_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdSleep_Add.HeaderRow.Style.Add("width", "250px");
                    grdSleep_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdSleep_Add.HeaderRow.Style.Add("text-align", "center");
                    grdSleep_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationSleep_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationSleep_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBSleep_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddSleep_add_Lists_Click(object sender, EventArgs e)
        {


            DivSleep_Add.Visible = false;
            btnsleep.Visible = false;
            //btnAddStichingsleep.Visible = false;
            BindStitchingsleepGrid("");
            // lblsleep.Text = "Sleep" + " " + "(Total number of opration:" + OprationCountsleep + ")";
            OprationCountsleep = 0;
            StitchGridShowHide(2);
            btnSleep_add.Visible = true;
            grdStitchingsleep.Visible = true;

            divsleep.Visible = true;
            trsleep.Visible = true;
            ViewState["sleep"] = "4";
            btnsleep_up_Add.Visible = true;
        }
        protected void BindAddSleep_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdSleep_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnsleep_up_Add_Click(object sender, EventArgs e)
        {

            BindSleepAdd();
            StitchGridShowHide(2);
            trsleep.Visible = true;
            DivSleep_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivSleeplist_Add.Visible = true;
            lblsleep.Text = "Sleeve";

        }

        //Sleep end------------------------------------------------------------------------------//


        //Neck start------------------------------------------------------------------------//
        protected void btnNeck_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingNeckOB", "tblOperationstitching_Neck", "Operationstitching_Neck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdNeck_Add.DataSource = dtBindGrid;
            grdNeck_Add.DataBind();
        }
        protected void BindNeckAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingNeckOB", "tblOperationstitching_Neck", "Operationstitching_Neck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdNeck_Add.DataSource = dtBindGrid;
            grdNeck_Add.DataBind();
        }
        protected void btnNeck_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNeckOB", "tblOperationstitching_Neck", "Operationstitching_Neck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdStitchingneck.DataSource = dtBindGrid;
            grdStitchingneck.DataBind();
        }
        protected void grdNeck_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdNeck_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdNeck_Add.HeaderRow.Style.Add("width", "250px");
                    grdNeck_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdNeck_Add.HeaderRow.Style.Add("text-align", "center");
                    grdNeck_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationNeck_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationNeck_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBNeck_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddNeck_add_Lists_Click(object sender, EventArgs e)
        {


            DivNeck_Add.Visible = false;
            btnneck.Visible = false;
            // btnAddStichingNeck.Visible = false;
            BindStitchingneckGrid("");
            // lblneck.Text = "Frill" + " " + "(Total number of opration:" + OprationCountneck + ")";
            OprationCountneck = 0;
            StitchGridShowHide(2);
            btnNeck_add.Visible = true;
            grdStitchingneck.Visible = true;

            divneck.Visible = true;
            trneck.Visible = true;
            ViewState["Neck"] = "5";
            btnNeck_up_Add.Visible = true;
        }
        protected void BindAddNeck_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdNeck_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnNeck_up_Add_Click(object sender, EventArgs e)
        {

            BindNeckAdd();
            StitchGridShowHide(2);
            trneck.Visible = true;
            DivNeck_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivNecklist_Add.Visible = true;
            lblneck.Text = "Frill";

        }

        //Neck end------------------------------------------------------------------------------//


        //lining start------------------------------------------------------------------------//
        protected void btnlining_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingliningOB", "tblOperationstitching_lining", "Operationstitching_lining", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdlining_Add.DataSource = dtBindGrid;
            grdlining_Add.DataBind();
        }
        protected void BindliningAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingliningOB", "tblOperationstitching_lining", "Operationstitching_lining", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdlining_Add.DataSource = dtBindGrid;
            grdlining_Add.DataBind();
        }
        protected void btnlining_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingliningOB", "tblOperationstitching_lining", "Operationstitching_lining", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdStitchingLining.DataSource = dtBindGrid;
            grdStitchingLining.DataBind();
        }
        protected void grdlining_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdlining_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdlining_Add.HeaderRow.Style.Add("width", "250px");
                    grdlining_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdlining_Add.HeaderRow.Style.Add("text-align", "center");
                    grdlining_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationlining_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationlining_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBlining_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddlining_add_Lists_Click(object sender, EventArgs e)
        {


            Divlining_Add.Visible = false;
            btnLining.Visible = false;
            //btnAddStichingLining.Visible = false;
            BindStitchingLiningGrid("");
            //  lblLining.Text = "lining" + " " + "(Total number of opration:" + OprationCountLining + ")";
            OprationCountLining = 0;
            StitchGridShowHide(2);
            btnlining_add.Visible = true;
            grdStitchingLining.Visible = true;

            divLining.Visible = true;
            trLining.Visible = true;
            ViewState["lining"] = "6";
            btnlining_up_Add.Visible = true;
        }
        protected void BindAddlining_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdlining_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnlining_up_Add_Click(object sender, EventArgs e)
        {

            BindliningAdd();
            StitchGridShowHide(2);
            trLining.Visible = true;
            Divlining_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            Divlininglist_Add.Visible = true;
            lblLining.Text = "lining";

        }

        //lining end------------------------------------------------------------------------------//


        //lower start------------------------------------------------------------------------//
        protected void btnlower_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchinglowerOB", "tblOperationstitching_lower", "Operationstitching_lower", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdlower_Add.DataSource = dtBindGrid;
            grdlower_Add.DataBind();
        }
        protected void BindlowerAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchinglowerOB", "tblOperationstitching_lower", "Operationstitching_lower", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdlower_Add.DataSource = dtBindGrid;
            grdlower_Add.DataBind();
        }
        protected void btnlower_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchinglowerOB", "tblOperationstitching_lower", "Operationstitching_lower", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdStitchinglower.DataSource = dtBindGrid;
            grdStitchinglower.DataBind();
        }
        protected void grdlower_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdlower_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdlower_Add.HeaderRow.Style.Add("width", "250px");
                    grdlower_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdlower_Add.HeaderRow.Style.Add("text-align", "center");
                    grdlower_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationlower_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationlower_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBlower_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddlower_add_Lists_Click(object sender, EventArgs e)
        {


            Divlower_Add.Visible = false;
            btnlower.Visible = false;
            //btnAddStichinglower.Visible = false;
            BindStitchinglowerGrid("");
            // lbllower.Text = "lower" + " " + "(Total number of opration:" + OprationCountlower + ")";
            OprationCountlower = 0;
            StitchGridShowHide(2);
            btnlower_add.Visible = true;
            grdStitchinglower.Visible = true;

            divlower.Visible = true;
            trlower.Visible = true;
            ViewState["lower"] = "7";
            btnlower_up_Add.Visible = true;

        }
        protected void BindAddlower_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdlower_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnlower_up_Add_Click(object sender, EventArgs e)
        {

            BindlowerAdd();
            StitchGridShowHide(2);
            trlower.Visible = true;
            Divlower_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            Divlowerlist_Add.Visible = true;
            lbllower.Text = "lower";

        }

        //lower end------------------------------------------------------------------------------//



        //Piping start------------------------------------------------------------------------//
        protected void btnPiping_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingPipingOB", "tblOperationstitching_Piping", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdPiping_Add.DataSource = dtBindGrid;
            grdPiping_Add.DataBind();
        }
        protected void BindPipingAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingPipingOB", "tblOperationstitching_Piping", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdPiping_Add.DataSource = dtBindGrid;
            grdPiping_Add.DataBind();
        }
        protected void btnPiping_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingPipingOB", "tblOperationstitching_Piping", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdPiping.DataSource = dtBindGrid;
            grdPiping.DataBind();
        }
        protected void grdPiping_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdPiping_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdPiping_Add.HeaderRow.Style.Add("width", "250px");
                    grdPiping_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdPiping_Add.HeaderRow.Style.Add("text-align", "center");
                    grdPiping_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationPiping_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationPiping_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBPiping_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddPiping_add_Lists_Click(object sender, EventArgs e)
        {


            DivPiping_Add.Visible = false;
            btnPiping.Visible = false;
            //btnAddStichingPiping.Visible = false;
            BindStitchingPipingGrid("");
            //  lblPiping.Text = "Piping" + " " + "(Total number of opration:" + OprationCountPiping + ")";
            OprationCountPiping = 0;
            StitchGridShowHide(2);
            btnPiping_add.Visible = true;
            grdPiping.Visible = true;

            divPiping.Visible = true;
            trPiping.Visible = true;
            ViewState["Piping"] = "10";
            btnPiping_up_Add.Visible = true;
        }
        protected void BindAddPiping_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdPiping_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnPiping_up_Add_Click(object sender, EventArgs e)
        {

            BindPipingAdd();
            StitchGridShowHide(2);
            trPiping.Visible = true;
            DivPiping_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivPipinglist_Add.Visible = true;
            lblPiping.Text = "Piping";

        }

        //Piping end------------------------------------------------------------------------------//


        //Upper start------------------------------------------------------------------------//
        protected void btnUpper_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingUpperOB", "tblOperationstitching_Upper", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdUpper_Add.DataSource = dtBindGrid;
            grdUpper_Add.DataBind();
        }
        protected void BindUpperAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingUpperOB", "tblOperationstitching_Upper", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdUpper_Add.DataSource = dtBindGrid;
            grdUpper_Add.DataBind();
        }
        protected void btnUpper_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUpperOB", "tblOperationstitching_Upper", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdUppersection.DataSource = dtBindGrid;
            grdUppersection.DataBind();
        }
        protected void grdUpper_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdUpper_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdUpper_Add.HeaderRow.Style.Add("width", "250px");
                    grdUpper_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdUpper_Add.HeaderRow.Style.Add("text-align", "center");
                    grdUpper_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationUpper_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationUpper_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBUpper_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddUpper_add_Lists_Click(object sender, EventArgs e)
        {


            DivUpper_Add.Visible = false;
            btnUppersection.Visible = false;
            //btnAddStichingUpper.Visible = false;
            BindUppersectionGrid("");
            // lblUpper.Text = "Upper" + " " + "(Total number of opration:" + OprationCountUppersection + ")";
            OprationCountUppersection = 0;
            StitchGridShowHide(2);
            btnUpper_add.Visible = true;
            grdUppersection.Visible = true;

            divUpper.Visible = true;
            trUpper.Visible = true;
            ViewState["Upper"] = "8";
            btnUpper_up_Add.Visible = true;
        }
        protected void BindAddUpper_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdUpper_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnUpper_up_Add_Click(object sender, EventArgs e)
        {

            BindUpperAdd();
            StitchGridShowHide(2);
            trUpper.Visible = true;
            DivUpper_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivUpperlist_Add.Visible = true;
            lblUpper.Text = "Upper";

        }

        //Upper end------------------------------------------------------------------------------//


        //Uppershell start------------------------------------------------------------------------//
        protected void btnUppershell_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingUppershellOB", "tblOperationstitching_Uppershell", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdUppershell_Add.DataSource = dtBindGrid;
            grdUppershell_Add.DataBind();
        }
        protected void BindUppershellAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingUppershellOB", "tblOperationstitching_Uppershell", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdUppershell_Add.DataSource = dtBindGrid;
            grdUppershell_Add.DataBind();
        }
        protected void btnUppershell_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingUppershellOB", "tblOperationstitching_Uppershell", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdUppershell.DataSource = dtBindGrid;
            grdUppershell.DataBind();
        }
        protected void grdUppershell_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdUppershell_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdUppershell_Add.HeaderRow.Style.Add("width", "250px");
                    grdUppershell_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdUppershell_Add.HeaderRow.Style.Add("text-align", "center");
                    grdUppershell_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationUppershell_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationUppershell_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBUppershell_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddUppershell_add_Lists_Click(object sender, EventArgs e)
        {


            DivUppershell_Add.Visible = false;
            btnUppershell.Visible = false;
            // btnAddStichingUppershell.Visible = false;
            BindUpperShellsectionGrid("");
            //lblUppershell.Text = "Uppershell" + " " + "(Total number of opration:" + OprationCountUppershell + ")";
            OprationCountUppershell = 0;
            StitchGridShowHide(2);
            btnUppershell_add.Visible = true;
            grdUppershell.Visible = true;

            divUppershell.Visible = true;
            trUppershell.Visible = true;
            ViewState["Uppershell"] = "12";
            btnUppershell_up_Add.Visible = true;
        }
        protected void BindAddUppershell_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdUppershell_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnUppershell_up_Add_Click(object sender, EventArgs e)
        {

            BindUppershellAdd();
            StitchGridShowHide(2);
            trUppershell.Visible = true;
            DivUppershell_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivUppershelllist_Add.Visible = true;
            lblUppershell.Text = "Uppershell";

        }

        //Uppershell end------------------------------------------------------------------------------//


        //Lowershell start------------------------------------------------------------------------//
        protected void btnLowershell_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingLowershellOB", "tblOperationstitching_Lowershell", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdLowershell_Add.DataSource = dtBindGrid;
            grdLowershell_Add.DataBind();
        }
        protected void BindLowershellAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingLowershellOB", "tblOperationstitching_Lowershell", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdLowershell_Add.DataSource = dtBindGrid;
            grdLowershell_Add.DataBind();
        }
        protected void btnLowershell_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingLowershellOB", "tblOperationstitching_Lowershell", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdLowershell.DataSource = dtBindGrid;
            grdLowershell.DataBind();

        }
        protected void grdLowershell_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdLowershell_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdLowershell_Add.HeaderRow.Style.Add("width", "250px");
                    grdLowershell_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdLowershell_Add.HeaderRow.Style.Add("text-align", "center");
                    grdLowershell_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationLowershell_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationLowershell_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBLowershell_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddLowershell_add_Lists_Click(object sender, EventArgs e)
        {


            DivLowershell_Add.Visible = false;
            btnLowershell.Visible = false;
            //btnAddStichingLowershell.Visible = false;
            BindlowerShellsectionGrid("");
            //lblbLowershell.Text = "Lowershell" + " " + "(Total number of opration:" + OprationCountLowershell + ")";
            OprationCountLowershell = 0;
            StitchGridShowHide(2);
            btnLowershell_add.Visible = true;
            grdLowershell.Visible = true;
            divLowershell.Visible = true;
            trLowershell.Visible = true;
            ViewState["Lowershell"] = "13";
            btnLowershell_up_Add.Visible = true;
        }
        protected void BindAddLowershell_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdLowershell_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnLowershell_up_Add_Click(object sender, EventArgs e)
        {

            BindLowershellAdd();
            StitchGridShowHide(2);
            trLowershell.Visible = true;
            DivLowershell_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivLowershelllist_Add.Visible = true;
            lblbLowershell.Text = "Lowershell";

        }

        //Lowershell end------------------------------------------------------------------------------//






        //Shellsection start------------------------------------------------------------------------//
        protected void btnShellsection_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingShellsectionOB", "tblOperationstitching_Shellsection", "Operationstitching_Shellsection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdShellsection_Add.DataSource = dtBindGrid;
            grdShellsection_Add.DataBind();
        }
        protected void BindShellsectionAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingShellsectionOB", "tblOperationstitching_Shellsection", "Operationstitching_Shellsection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdShellsection_Add.DataSource = dtBindGrid;
            grdShellsection_Add.DataBind();
        }
        protected void btnShellsection_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingShellsectionOB", "tblOperationstitching_Shellsection", "Operationstitching_Shellsection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdShellsection.DataSource = dtBindGrid;
            grdShellsection.DataBind();
        }
        protected void grdShellsection_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdShellsection_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdShellsection_Add.HeaderRow.Style.Add("width", "250px");
                    grdShellsection_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdShellsection_Add.HeaderRow.Style.Add("text-align", "center");
                    grdShellsection_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationShellsection_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationShellsection_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBShellsection_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddShellsection_add_Lists_Click(object sender, EventArgs e)
        {


            DivShellsection_Add.Visible = false;
            btnShellsection.Visible = false;
            //btnAddStichingShellsection.Visible = false;
            BindShellsectionsectionGrid("");
            //lblShellsection.Text = "Shellsection" + " " + "(Total number of opration:" + OprationCountShellsection + ")";
            OprationCountShellsection = 0;
            StitchGridShowHide(2);
            btnShellsection_add.Visible = true;
            grdShellsection.Visible = true;

            divShellsection.Visible = true;
            trShellsection.Visible = true;
            ViewState["Shellsection"] = "8";
            btnShellsection_up_Add.Visible = true;
        }
        protected void BindAddShellsection_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdShellsection_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnShellsection_up_Add_Click(object sender, EventArgs e)
        {

            BindShellsectionAdd();
            StitchGridShowHide(2);
            trShellsection.Visible = true;
            DivShellsection_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivShellsectionlist_Add.Visible = true;
            lblShellsection.Text = "Shellsection";

        }

        //Shellsection end------------------------------------------------------------------------------//






        //WaistSection start------------------------------------------------------------------------//
        protected void btnWaistSection_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingWaistSectionOB", "tblOperationstitching_WaistSection", "Operationstitching_WaistSection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdWaistSection_Add.DataSource = dtBindGrid;
            grdWaistSection_Add.DataBind();
        }
        protected void BindWaistSectionAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingWaistSectionOB", "tblOperationstitching_WaistSection", "Operationstitching_WaistSection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdWaistSection_Add.DataSource = dtBindGrid;
            grdWaistSection_Add.DataBind();
        }
        protected void btnWaistSection_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingWaistSectionOB", "tblOperationstitching_WaistSection", "Operationstitching_WaistSection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdWaistSection.DataSource = dtBindGrid;
            grdWaistSection.DataBind();
        }
        protected void grdWaistSection_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdWaistSection_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdWaistSection_Add.HeaderRow.Style.Add("width", "250px");
                    grdWaistSection_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdWaistSection_Add.HeaderRow.Style.Add("text-align", "center");
                    grdWaistSection_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationWaistSection_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationWaistSection_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBWaistSection_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddWaistSection_add_Lists_Click(object sender, EventArgs e)
        {


            DivWaistSection_Add.Visible = false;
            btnWaistSection.Visible = false;
            //btnAddStichingWaistSection.Visible = false;

            BindWaistSectionGrid("");
            //lblWaistSection.Text = "WaistSection" + " " + "(Total number of opration:" + OprationCountWaistSection + ")";
            OprationCountWaistSection = 0;
            StitchGridShowHide(2);
            btnWaistSection_add.Visible = true;

            grdWaistSection.Visible = true;

            divWaistSection.Visible = true;
            trWaistSection.Visible = true;
            ViewState["WaistSection"] = "15";
            btnWaistSection_up_Add.Visible = true;

        }
        protected void BindAddWaistSection_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdWaistSection_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnWaistSection_up_Add_Click(object sender, EventArgs e)
        {

            BindWaistSectionAdd();
            StitchGridShowHide(2);
            trWaistSection.Visible = true;
            DivWaistSection_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivWaistSectionlist_Add.Visible = true;
            lblWaistSection.Text = "WaistSection";

        }

        //WaistSection end------------------------------------------------------------------------------//







        //Bandsection start------------------------------------------------------------------------//
        protected void btnBandsection_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingBandsectionOB", "tblOperationstitching_Bandsection", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdBandsection_Add.DataSource = dtBindGrid;
            grdBandsection_Add.DataBind();
        }
        protected void BindBandsectionAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingBandsectionOB", "tblOperationstitching_Bandsection", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdBandsection_Add.DataSource = dtBindGrid;
            grdBandsection_Add.DataBind();
        }
        protected void btnBandsection_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingBandsectionOB", "tblOperationstitching_Bandsection", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdBandsection.DataSource = dtBindGrid;
            grdBandsection.DataBind();
        }
        protected void grdBandsection_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdBandsection_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdBandsection_Add.HeaderRow.Style.Add("width", "250px");
                    grdBandsection_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdBandsection_Add.HeaderRow.Style.Add("text-align", "center");
                    grdBandsection_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationBandsection_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationBandsection_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBBandsection_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddBandsection_add_Lists_Click(object sender, EventArgs e)
        {


            DivBandsection_Add.Visible = false;
            btnBandsection.Visible = false;
            //btnAddStichingBandsection.Visible = false;

            BindBandSectionGrid("");
            //  lblBandsection.Text = "Bandsection" + " " + "(Total number of opration:" + OprationCountBandsection + ")";
            OprationCountBandsection = 0;
            StitchGridShowHide(2);
            btnBandsection_add.Visible = true;
            grdBandsection.Visible = true;



            divBandsection.Visible = true;
            trBandsection.Visible = true;
            ViewState["Bandsection"] = "16";
            btnBandsection_up_Add.Visible = true;

        }
        protected void BindAddBandsection_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdBandsection_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnBandsection_up_Add_Click(object sender, EventArgs e)
        {

            BindBandsectionAdd();
            StitchGridShowHide(2);
            trBandsection.Visible = true;
            DivBandsection_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivBandsectionlist_Add.Visible = true;
            lblBandsection.Text = "Bandsection";

        }

        //Bandsection end------------------------------------------------------------------------------//






        //necksection start------------------------------------------------------------------------//
        protected void btnnecksection_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingNewNeckOB", "tblOperationstitching_NewNeck", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdnecksection_Add.DataSource = dtBindGrid;
            grdnecksection_Add.DataBind();
        }
        protected void BindnecksectionAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingNewNeckOB", "tblOperationstitching_NewNeck", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdnecksection_Add.DataSource = dtBindGrid;
            grdnecksection_Add.DataBind();
        }
        protected void btnnecksection_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNewNeckOB", "tblOperationstitching_NewNeck", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdnecksection.DataSource = dtBindGrid;
            grdnecksection.DataBind();
        }
        protected void grdnecksection_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdnecksection_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdnecksection_Add.HeaderRow.Style.Add("width", "250px");
                    grdnecksection_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdnecksection_Add.HeaderRow.Style.Add("text-align", "center");
                    grdnecksection_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationnecksection_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationnecksection_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBnecksection_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddnecksection_add_Lists_Click(object sender, EventArgs e)
        {


            Divnecksection_Add.Visible = false;
            btnnecksection.Visible = false;
            //btnAddStichingNeckSection.Visible = false;
            BindBandSectionGrid_neckSection("");



            //lblnecksection.Text = "necksection" + " " + "(Total number of opration:" + OprationCountNeckSection + ")";
            OprationCountNeckSection = 0;
            StitchGridShowHide(2);
            btnnecksection_add.Visible = true;
            grdnecksection.Visible = true;

            divNnecksection.Visible = true;
            trNecksection.Visible = true;
            ViewState["necksection"] = "17";
            btnnecksection_up_Add.Visible = true;
        }
        protected void BindAddnecksection_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdnecksection_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnnecksection_up_Add_Click(object sender, EventArgs e)
        {

            BindnecksectionAdd();
            StitchGridShowHide(2);
            trNecksection.Visible = true;
            Divnecksection_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            Divnecksectionlist_Add.Visible = true;
            lblnecksection.Text = "necksection";

        }

        //necksection end------------------------------------------------------------------------------//






        //neckfaching start------------------------------------------------------------------------//
        protected void btnneckfaching_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingNeckfacingOB", "tblOperationstitching_Neckfacing", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdneckfaching_Add.DataSource = dtBindGrid;
            grdneckfaching_Add.DataBind();
        }
        protected void BindneckfachingAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingNeckfacingOB", "tblOperationstitching_Neckfacing", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdneckfaching_Add.DataSource = dtBindGrid;
            grdneckfaching_Add.DataBind();
        }
        protected void btnneckfaching_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingNeckfacingOB", "tblOperationstitching_Neckfacing", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdneckfaching.DataSource = dtBindGrid;
            grdneckfaching.DataBind();
        }
        protected void grdneckfaching_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdneckfaching_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdneckfaching_Add.HeaderRow.Style.Add("width", "250px");
                    grdneckfaching_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdneckfaching_Add.HeaderRow.Style.Add("text-align", "center");
                    grdneckfaching_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationneckfaching_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationneckfaching_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBneckfaching_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddneckfaching_add_Lists_Click(object sender, EventArgs e)
        {


            Divneckfaching_Add.Visible = false;
            btnneckfaching.Visible = false;
            //btnAddStichingNecFaching.Visible = false;
            BindBandSectionGrid_neckfaching("");

            //  lblneckfaching.Text = "neckfaching" + " " + "(Total number of opration:" + OprationCountNecFaching + ")";
            OprationCountNecFaching = 0;
            StitchGridShowHide(2);
            btnneckfaching_add.Visible = true;
            grdneckfaching.Visible = true;

            Divneckfaching.Visible = true;
            trneckfacing.Visible = true;
            ViewState["neckfaching"] = "18";
            btnneckfaching_up_Add.Visible = true;
        }
        protected void BindAddneckfaching_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdneckfaching_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnneckfaching_up_Add_Click(object sender, EventArgs e)
        {

            BindneckfachingAdd();
            StitchGridShowHide(2);
            trneckfacing.Visible = true;
            Divneckfaching_Add.Visible = true;
            DivBacklist_Add.Visible = true;
            Divneckfachinglist_Add.Visible = true;
            lblneckfaching.Text = "neckfaching";

        }

        //neckfaching end------------------------------------------------------------------------------//


        //f_back start------------------------------------------------------------------------//
        protected void btnf_back_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingFrontbackOB", "tblOperationstitching_Frontback", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
            grdf_back_Add.DataSource = dtBindGrid;
            grdf_back_Add.DataBind();
        }
        protected void Bindf_backAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingFrontbackOB", "tblOperationstitching_Frontback", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "First");
            grdf_back_Add.DataSource = dtBindGrid;
            grdf_back_Add.DataBind();
        }
        protected void btnf_back_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontbackOB", "tblOperationstitching_Frontback", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", "CuttingSam", "");
            grdf_back.DataSource = dtBindGrid;
            grdf_back.DataBind();
        }
        protected void grdf_back_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdf_back_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdf_back_Add.HeaderRow.Style.Add("width", "250px");
                    grdf_back_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdf_back_Add.HeaderRow.Style.Add("text-align", "center");
                    grdf_back_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationf_back_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationf_back_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBf_back_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddf_back_add_Lists_Click(object sender, EventArgs e)
        {
            Divf_back_Add.Visible = false;
            brnf_back.Visible = false;
            //btnaddf_back.Visible = false;

            BindBandSectionGrid_neckSection_frontback("");

            // lblf_back.Text = "front & back" + " " + "(Total number of opration:" + OprationCountf_back + ")";
            OprationCountf_back = 0;
            StitchGridShowHide(2);
            btnf_back_add.Visible = true;
            grdf_back.Visible = true;

            divf_back.Visible = true;
            trf_back.Visible = true;
            ViewState["f_back"] = "20";
            btnf_back_up_Add.Visible = true;
        }
        protected void BindAddf_back_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdf_back_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnf_back_up_Add_Click(object sender, EventArgs e)
        {

            Bindf_backAdd();
            StitchGridShowHide(2);
            trf_back.Visible = true;
            Divf_back_Add.Visible = true;
            DivBacklist_Add.Visible = true;
            Divf_backlist_Add.Visible = true;
            lblf_back.Text = "front & back";

        }

        //f_back end------------------------------------------------------------------------------//







        //Front start------------------------------------------------------------------------//
        protected void btnFront_add_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingFrontOB", "tblOperationstitching_Front", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdFront_Add.DataSource = dtBindGrid;
            grdFront_Add.DataBind();
        }
        protected void BindFrontAdd()
        {
            dtBindGrid = obj_AdminController.GetStichingAddMachine(0, 0, "tblStitchingFrontOB", "tblOperationstitching_Front", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "First");
            grdFront_Add.DataSource = dtBindGrid;
            grdFront_Add.DataBind();
        }
        protected void btnFront_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetStichingOB(0, 0, "tblStitchingFrontOB", "tblOperationstitching_Front", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", "StitchingSam", "");
            grdStitchingFont.DataSource = dtBindGrid;
            grdStitchingFont.DataBind();
        }
        protected void grdFront_Add_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ListBox chkMachine = (ListBox)e.Row.FindControl("ListMachine");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");
            DataSet dtMachine = new DataSet();
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdFront_Add.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdFront_Add.HeaderRow.Style.Add("width", "250px");
                    grdFront_Add.HeaderRow.Style.Add("class", "topMenu2");
                    grdFront_Add.HeaderRow.Style.Add("text-align", "center");
                    grdFront_Add.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    //}
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.CssClass = "txtOperationFront_Add";
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    //}
                    txtGarmentType.Width = 50;
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places txtOperationFront_Add";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveStichingOBFront_Add(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }
            }
        }


        protected void btnAddFront_add_Lists_Click(object sender, EventArgs e)
        {


            DivFront_Add.Visible = false;
            btnFornt.Visible = false;
            //btnAdd.Visible = false;
            BindGrid("");
            //lblStitching.Text = "Front" + " " + "(Total number of opration:" + OprationCountfront + ")";
            OprationCountfront = 0;
            StitchGridShowHide(2);
            btnFront_add.Visible = true;
            grdStitchingFont.Visible = true;

            divfront.Visible = true;
            trFront.Visible = true;
            ViewState["Front"] = "1";
            btnFront_up_Add.Visible = true;
        }
        protected void BindAddFront_Add()
        {
            dsMachine = obj_AdminController.GetFactoryWork("Stitching");
            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {
                for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.HeaderText = "";
                    boundField.ItemStyle.CssClass = "tdgrid";
                    grdFront_Add.Columns.Add(boundField);
                }
            }
        }
        protected void btnFront_up_Add_Click(object sender, EventArgs e)
        {

            BindFrontAdd();
            StitchGridShowHide(2);
            trFront.Visible = true;
            DivFront_Add.Visible = true;

            DivBacklist_Add.Visible = true;
            DivFrontlist_Add.Visible = true;
            lblStitching.Text = "Front";

        }

        //Front end------------------------------------------------------------------------------//









    }
}