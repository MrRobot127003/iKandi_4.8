<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientsAql.ascx.cs"
    Inherits="iKandi.Web.ClientsAql" %>
    
    
    <script type="text/javascript" >
        function SelectAllCol(id, rowNo) {
            //get reference of GridView control
            var grid = document.getElementById("<%= grdClientsAQL.ClientID %>");
            //variable to contain the cell of the grid
            var cell;
            var Firstcell;
            try {
                //debugger;
                if (grid.rows[rowNo].cells.length > 0) {
                    //loop starts from 1. rows[0] points to the header.
                    for (i = 2; i < grid.rows[rowNo].cells.length; i++) {
                        //get the reference of first column
                        cell = grid.rows[rowNo].cells[i]
                        Firstcell = grid.rows[rowNo].cells[1];

                        //loop according to the number of childNodes in the cell
                        for (j = 0; j < cell.childNodes.length; j++) {
                            //if childNode type is CheckBox
                            if (cell.childNodes[j].type == "select-one") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell.childNodes[j].value = Firstcell.childNodes[j].value

                            }
                        }
                    }
                }
            } catch (e) {
                alert(e);
            }
            document.getElementById(id).checked = false;
        }
        function ChildClick(CheckBox, HCheckBox) {
            //get target control.

            var j = 0;
            // debugger;
            //   var HeaderCheckBox = document.getElementById(HCheckBox);
            var id = HCheckBox.split('id');
            var temp = parseInt(id[1]);
            var objGridView = document.getElementById('<%=grdClientsAQL.ClientID %>');
            var rowcount = objGridView.rows;
            var cellValue = objGridView.rows[1].cells[temp].childNodes[2].value;
            // alert(cellValue);
            // debugger;
            for (j = 1; j <= parseInt(rowcount.length) - 1; j++) {


                objGridView.rows[j].cells[temp].children[2].value = cellValue
            }
            //document.getElementById(ss).checked = false;
            CheckBox.checked = false;
        }
        //                    //alert("J value " + j + " => " + GridView.rows[rowIdx].cells[j].children[0].value);


        //                    rowtotal = rowtotal + parseInt(cellValue);

        //                }

        // }


        //Modifiy Counter; 
        //            if (CheckBox.checked && Counter < TotalChkBx)
        //                Counter++;
        //            else if (Counter > 0)
        //                Counter--;

        //            //Change state of the header CheckBox.
        //            if (Counter < TotalChkBx)
        //                HeaderCheckBox.checked = false;
        //            else if (Counter == TotalChkBx)
        //                HeaderCheckBox.checked = true;
        //   }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    </script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
        <h2  class="header-text-back">Client's AQL</h2>
    

<div class="form_box">
    <asp:GridView ID="grdClientsAQL" runat="server" AutoGenerateColumns="true" CssClass="da_header_heading_Master item_list" OnRowDataBound="grdClientsAQL_RowDataBound" Width="100%">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <label>No records Found </label>
        </EmptyDataTemplate>
    </asp:GridView>
</div>

<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="da_submit_button submit" OnClick="btnSubmit_Click" />

