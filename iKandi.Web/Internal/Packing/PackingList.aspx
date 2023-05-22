<%@ Page Language="C#" MasterPageFile="~/layout/SimpleSecure.Master" AutoEventWireup="true"
    CodeBehind="PackingList.aspx.cs" Inherits="iKandi.Web.PackingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <style type="text/css">
        .singles-quantity, .ratio-quantity
        {
            padding: 2px 2px 2px 0px;
            width: 33px !important;
        }
        .main_summary_td
        {
            border: 1px solid #000000;
        }
    </style>

    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var packingId = (window.location.querystring['pid'] == undefined) ? -1 : window.location.querystring['pid']
        var assignedColorsArray;
        var totaltime = 0;

        function BindPackingListControls() {
          
            $('.packing-delete-row').click(function() {

                var row = $(this).parents('tr');
                var color = row.attr('class').split(' ')[0];

                if ($('.' + color).length == 1)
                    assignedColorsArray.pop(color);

                row.remove();

                ShowNumberOfBoxes();

                //$('.order-selection').hide();
            });



            $('.pkg-no-from').change(function() {
            
                var objThis = $(this);
                var row = objThis.parents('tr');
                var pkgNoTo = row.find('.pkg-no-to');
                var quantityAssignedValue = row.find('.packing-quantity-assigned-value');

                if ($(this).val() == '0')
                    $(this).val(pkgNoTo.val());
                else if (pkgNoTo != undefined && (pkgNoTo.val() == '' || +pkgNoTo.val() < +objThis.val()))
                    pkgNoTo.val(objThis.val());

                if (quantityAssignedValue.length > 0)
                    CalculateQuantity(pkgNoTo.val(), objThis.val(), quantityAssignedValue, objThis.parents('tr'));
            });



            $('.pkg-no-to').change(function() {
            
                var objThis = $(this);
                var row = objThis.parents('tr');
                var pkgNoFrom = row.find('.pkg-no-from');
                var quantityAssignedValue = row.find('.packing-quantity-assigned-value');

                if (objThis.val() == '0')
                    objThis.val(pkgNoFrom.val());
                else if (pkgNoFrom != undefined && (pkgNoFrom.val() == '' || +pkgNoFrom.val() > +objThis.val()))
                    pkgNoFrom.val(objThis.val());

                if (quantityAssignedValue.length > 0)
                    CalculateQuantity(objThis.val(), pkgNoFrom.val(), quantityAssignedValue, objThis.parents('tr'));
            });

            $('.pkg-no-to').blur(function() {

                if ($('.pkg-no-to:last').get(0) == $(this).get(0)) {
                    ShowNumberOfBoxes();
                }
            });

            $('.packing-quantity-assigned').keyup(function(e) {

                if (e.keyCode >= 48 && e.keyCode <= 57)
                    $(this).attr('class', 'packing-quantity-assigned numeric-field-without-decimal-places');
            });

            $('.packing-quantity-assigned').change(function() {

                //TODO:         
                //if($(this).attr('class') == 'packing-quantity-assigned numeric-field-without-decimal-places packing-quantity-assigned-value')
                //    return false;

                var objThis = $(this);
                var row = objThis.parents('tr');

                var pkgNoFrom = row.find('.pkg-no-from');
                var pkgNoTo = row.find('.pkg-no-to');

                var chkIsRatio = row.find('input.chk-is-ratio');

                if (!chkIsRatio.attr('checked')) {
                    var quantityAssigned = row.find('.packing-quantity-assigned');

                    //                for (var i = 0; i < quantityAssigned.length; i++) {
                    //                    if (quantityAssigned[i].id != objThis.attr('id')) {
                    //                        quantityAssigned[i].value = '';
                    //                        quantityAssigned[i].className = 'packing-quantity-assigned numeric-field-without-decimal-places';
                    //                    }
                    //                }
                }

                objThis.attr('class', 'packing-quantity-assigned numeric-field-without-decimal-places packing-quantity-assigned-value');
                var quantityAssignedValue = row.find('.packing-quantity-assigned-value');

                CalculateQuantity(pkgNoTo.val(), pkgNoFrom.val(), quantityAssignedValue, row);
            });


            $(".chk-is-ratio").click(function() {

   

                var quantityAssigned = $(this).parents('tr').find('.packing-quantity-assigned');
                quantityAssigned.val('');
                quantityAssigned.attr('class', 'packing-quantity-assigned numeric-field-without-decimal-places');
                quantityAssigned.change();

                var txtIsRatio = $(this).parents('tr').find('input.txt-is-ratio');
                txtIsRatio.val('');

                if ($(this).attr('checked')) {
                    txtIsRatio.show();
                    $(this).parents('tr').find('div.packing-total-quantity').hide();
                }
                else {
                    txtIsRatio.hide();
                    $(this).parents('tr').find('div.packing-total-quantity').show();
                }
            });

            $('.txt-is-ratio').change(function() {

               

                var objTxtIsRatio = $(this).parents('tr');
                var pkgNoFrom = objTxtIsRatio.find('.pkg-no-from');
                var pkgNoto = objTxtIsRatio.find('.pkg-no-to');
                var quantityAssignedValue = objTxtIsRatio.find('.packing-quantity-assigned-value');

                if (quantityAssignedValue.length == 0)
                    return false;

                CalculateQuantity(pkgNoto.val(), pkgNoFrom.val(), quantityAssignedValue, objTxtIsRatio);
            });


            BindControls();

        }



        function LoadDistributionRows(imgAdd, htmlString) {
          
            if (assignedColorsArray == undefined)
                assignedColorsArray = new Array();

            var objImgAdd = $(imgAdd);
            var mainRow = objImgAdd.parents('tr');
            var mainRowChildRows = $('.' + color);
            var ppid = mainRow.children('td')[9].innerText.split('#');
            var color = 'class' + $.trim(ppid[0]);

            mainRow.attr('className', 'main-row-' + color);

            if (mainRowChildRows.length == 0)
                $(htmlString).insertAfter(mainRow);

            var totalRows = mainRow.parents("table").find("tr").length - 1;

            for (var i = 0; i < totalRows; i++) {
                if (assignedColorsArray.join('~~').search(color) == -1)
                    assignedColorsArray.push(color);
            }

            BindPackingListControls();
        }

        function AddPackingRow(imgAdd, isServerSide) {
            
            var curdate = new Date();
            var currentTime = curdate.getTime();

            if (assignedColorsArray == undefined)
                assignedColorsArray = new Array();

            var objImgAdd = $(imgAdd);
            var mainRow = objImgAdd.parents('tr');
            var ppid = mainRow.children('td')[9].innerText.split('#');
            var color = 'class' + $.trim(ppid[0]);
            var mainRowChildRows = $('.' + color);

            var newRow;

            var cloneRow = mainRow.clone(true);

            cloneRow.find('.packing-singles').remove();

            if (mainRowChildRows.length == 0)
                newRow = cloneRow.insertAfter(objImgAdd.parents('tr'));
            else
                newRow = cloneRow.insertAfter(mainRowChildRows[mainRowChildRows.length - 1]);

            var returnValue = color + mainRowChildRows.length;

            newRow.attr('class', color + ' ' + returnValue);

            var newRowCells = newRow.children('td');
            var objnewParentRow = $(this).parents('tr');


            for (var i = 0; i < newRowCells.length; i++) {

                var newRowCell = newRowCells[i];
                var objNewRowCell = $(newRowCells[i]);

                newRowCell.style.verticalAlign = 'middle';

                switch (i) {

                    case 0:
                        newRowCell.innerHTML = '';

                        var txtPkgNo = document.createElement('input');
                        txtPkgNo.name = 'txtPkgNoFrom';
                        txtPkgNo.id = 'txtPkgNoFrom';
                        txtPkgNo.style.width = '20px';
                        txtPkgNo.className = 'pkg-no-from numeric-field-without-decimal-places';
                        newRowCell.appendChild(txtPkgNo);

                        var spanTo = document.createElement('span');
                        spanTo.innerText = ' To ';
                        newRowCell.appendChild(spanTo);

                        txtPkgNo = document.createElement('input');
                        txtPkgNo.name = 'txtPkgNoTo';
                        txtPkgNo.id = 'txtPkgNoTo';
                        txtPkgNo.style.width = '20px';
                        txtPkgNo.className = 'pkg-no-to numeric-field-without-decimal-places';
                        newRowCell.appendChild(txtPkgNo);
                        newRowCell.style.width = '9%';
                        break;

                    case 1:
                        newRowCell.className = 'packing-line-number';
                        break;

                    case 6:
                        newRowCell.innerHTML = '';
                        newRowCell.className = 'packing-quantity';
                        break;

                    case 7:
                        var txt = objNewRowCell.find('input');

                        for (var j = 0; j < txt.length; j++)
                            txt[j].value = '';

                        objNewRowCell.find('.packing-ratio').hide();
                        objNewRowCell.find('.packing-singles').hide();
                        objNewRowCell.find('.div-singles').remove();
                        objNewRowCell.find('.div-ratio').remove();
                        break;

                    case 8:
                        newRowCell.innerHTML = '';

                        var deleteRowLink = document.createElement('img');
                        deleteRowLink.src = '../../App_Themes/ikandi/images/minus.gif';
                        deleteRowLink.style.cursor = 'hand';
                        deleteRowLink.className = 'packing-delete-row';
                        newRowCell.appendChild(deleteRowLink);

                        if (newRow.find('span.ratio-quantity').length == 0) break;

                        var divRatio1 = document.createElement('div');
                        divRatio1.id = 'divRatio1';

                        var chkIsRatio = document.createElement('input');
                        chkIsRatio.type = 'checkbox';
                        chkIsRatio.className = 'chk-is-ratio';

                        chkIsRatio.onclick = function() {
                            var quantityAssigned = $(this).parents('tr').find('.packing-quantity-assigned');
                            quantityAssigned.val('');
                            quantityAssigned.attr('class', 'packing-quantity-assigned numeric-field-without-decimal-places');
                            quantityAssigned.change();

                            var txtIsRatio = $(this).parents('tr').find('input.txt-is-ratio');
                            txtIsRatio.val('');

                            if ($(this).attr('checked')) {
                                txtIsRatio.show();
                                $(this).parents('tr').find('div.packing-total-quantity').hide();
                            }
                            else {
                                txtIsRatio.hide();
                                $(this).parents('tr').find('div.packing-total-quantity').show();
                            }
                        }

                        var spanIsRatio = document.createElement('span');
                        spanIsRatio.innerText = "Ratio: ";

                        divRatio1.appendChild(spanIsRatio);
                        divRatio1.appendChild(chkIsRatio);
                        newRowCell.appendChild(divRatio1);

                        $('.txt-is-ratio').change(function() {
                            var objTxtIsRatio = $(this).parents('tr');
                            var pkgNoFrom = objTxtIsRatio.find('.pkg-no-from');
                            var pkgNoto = objTxtIsRatio.find('.pkg-no-to');
                            var quantityAssignedValue = objTxtIsRatio.find('.packing-quantity-assigned-value');

                            if (quantityAssignedValue.length == 0)
                                return false;

                            CalculateQuantity(pkgNoto.val(), pkgNoFrom.val(), quantityAssignedValue, objTxtIsRatio);
                        });

                        break;

                    case 9:
                        objNewRowCell.find('.order-selection').hide();
                        break;

                    default:
                        newRowCell.innerHTML = '-do-';
                        break;
                }

                mainRow.attr('className', 'main-row-' + color);

            }

            var curdate1 = new Date();
            var currentTime1 = curdate1.getTime();
            var diff = currentTime1 - currentTime;

            totaltime += diff;

            $('.packing-delete-row').click(function() {

                var row = $(this).parents('tr');
                var color = row.attr('class').split(' ')[0];

                if ($('.' + color).length == 1)
                    assignedColorsArray.pop(color);

                row.remove();

                ShowNumberOfBoxes();

                //$('.order-selection').hide();
            });



            $('.pkg-no-from').change(function() {

                var objThis = $(this);
                var row = objThis.parents('tr');
                var pkgNoTo = row.find('.pkg-no-to');
                var quantityAssignedValue = row.find('.packing-quantity-assigned-value');

                if ($(this).val() == '0')
                    $(this).val(pkgNoTo.val());
                else if (pkgNoTo != undefined && (pkgNoTo.val() == '' || +pkgNoTo.val() < +objThis.val()))
                    pkgNoTo.val(objThis.val());

                if (quantityAssignedValue.length > 0)
                    CalculateQuantity(pkgNoTo.val(), objThis.val(), quantityAssignedValue, objThis.parents('tr'));
            });



            $('.pkg-no-to').change(function() {

                var objThis = $(this);
                var row = objThis.parents('tr');
                var pkgNoFrom = row.find('.pkg-no-from');
                var quantityAssignedValue = row.find('.packing-quantity-assigned-value');

                if (objThis.val() == '0')
                    objThis.val(pkgNoFrom.val());
                else if (pkgNoFrom != undefined && (pkgNoFrom.val() == '' || +pkgNoFrom.val() > +objThis.val()))
                    pkgNoFrom.val(objThis.val());

                if (quantityAssignedValue.length > 0)
                    CalculateQuantity(objThis.val(), pkgNoFrom.val(), quantityAssignedValue, objThis.parents('tr'));
            });

            $('.pkg-no-to').blur(function() {

                if ($('.pkg-no-to:last').get(0) == $(this).get(0)) {
                    ShowNumberOfBoxes();
                }
            });

            $('.packing-quantity-assigned').keyup(function(e) {

                if (e.keyCode >= 48 && e.keyCode <= 57)
                    $(this).attr('class', 'packing-quantity-assigned numeric-field-without-decimal-places');
            });

            $('.packing-quantity-assigned').change(function() {

                //TODO:         
                //if($(this).attr('class') == 'packing-quantity-assigned numeric-field-without-decimal-places packing-quantity-assigned-value')
                //    return false;

                var objThis = $(this);
                var row = objThis.parents('tr');

                var pkgNoFrom = row.find('.pkg-no-from');
                var pkgNoTo = row.find('.pkg-no-to');

                var chkIsRatio = row.find('input.chk-is-ratio');

                if (!chkIsRatio.attr('checked')) {
                    var quantityAssigned = row.find('.packing-quantity-assigned');

                    //                for (var i = 0; i < quantityAssigned.length; i++) {
                    //                    if (quantityAssigned[i].id != objThis.attr('id')) {
                    //                        quantityAssigned[i].value = '';
                    //                        quantityAssigned[i].className = 'packing-quantity-assigned numeric-field-without-decimal-places';
                    //                    }
                    //                }
                }

                objThis.attr('class', 'packing-quantity-assigned numeric-field-without-decimal-places packing-quantity-assigned-value');
                var quantityAssignedValue = row.find('.packing-quantity-assigned-value');

                CalculateQuantity(pkgNoTo.val(), pkgNoFrom.val(), quantityAssignedValue, row);
            });

            if (assignedColorsArray.join('~~').search(color) == -1)
                assignedColorsArray.push(color);

            if (!isServerSide)
                BindControls();

            return returnValue;
        }

        function ShowNumberOfBoxes() {

            var pkgNumberToLast = $('.pkg-no-to:last');
            var numberOfBoxes = $('.number-of-boxes');

            if (numberOfBoxes.length == 1 && pkgNumberToLast.length == 1 && pkgNumberToLast.val() != '') {
                numberOfBoxes.val(pkgNumberToLast.val());
            }
        }

        function BindPackingValues(rowClass, PkgNoFrom, PkgNoTo, sizeValues, isRatioPack, ratioPackQtyPerPkg) {
          
            var date = new Date();
            var time = date.getTime();
            var row = $('.' + rowClass);

            var objPkgTo = row.find('.pkg-no-from');
            var objPkgFrom = row.find('.pkg-no-to');

            objPkgTo.val(PkgNoFrom);
            objPkgFrom.val(PkgNoTo);

            var sizeValueArray = sizeValues.split('~~');
            var txtSizes = row.find('.packing-quantity-assigned');

            for (var i = 0; i < txtSizes.length; i++) {
                if (sizeValueArray[i] != 0) {
                    txtSizes[i].value = sizeValueArray[i];
                    txtSizes[i].className = 'packing-quantity-assigned numeric-field-without-decimal-places packing-quantity-assigned-value';
                }
            }

            isRatioPack = (isRatioPack == 'True') ? true : false;

            if (isRatioPack) {
                var chkIsRatio = row.find('input.chk-is-ratio');
                chkIsRatio.click();

                var txtIsRatio = row.find('input.txt-is-ratio');
                txtIsRatio.val(ratioPackQtyPerPkg);
                txtIsRatio.show();

                row.find('div.packing-total-quantity').hide();
            }

            row.find('.pkg-no-to').change();

           // UpdateBindingRow(objPkgTo, row, objPkgFrom);

            var date1 = new Date();
            var time1 = date1.getTime();
            var diff = time1 - time;
            totaltime += diff;
            
        }

        // This method is same as the $('.pkg-no-to').change() event handler
        function UpdateBindingRow(pkgToNo, row, pkgNoFrom) {
            var objThis = pkgToNo;

            var quantityAssignedValue = row.find('.packing-quantity-assigned-value');

            if (objThis.val() == '0')
                objThis.val(pkgNoFrom.val());

            else if (pkgNoFrom != undefined && (pkgNoFrom.val() == '' || +pkgNoFrom.val() > +objThis.val()))
                pkgNoFrom.val(objThis.val());

            if (quantityAssignedValue.length > 0)
                CalculateQuantity(objThis.val(), pkgNoFrom.val(), quantityAssignedValue, objThis.parents('tr'), false);
        }


        function BindDimensionValues(dimensions, quantity, isFirstRow) {
            var date = new Date();
            var time = date.getTime();

            if (!isFirstRow)
                AddDimensionRow();

            var dims = dimensions.split('X');
            var txtDimensions = $('.dimension-row:last input');

            for (var i = 0; i < txtDimensions.length; i++) {
                if (i == 3) {
                    txtDimensions[i].value = quantity;
                    break;
                }

                txtDimensions[i].value = dims[i];
            }

            var date1 = new Date();
            var time1 = date1.getTime();
            var diff = (time1 - time);
           
        }

        $(function() {

            if (assignedColorsArray == undefined)
                assignedColorsArray = new Array();

            $('.packing-add-row').click(function() {
                AddPackingRow(this);
            });

            $('.dimension-add-row').click(function() {
                AddDimensionRow();
            });

            $('.order-selection').click(function() {
                var chkbox = $(this).find("input");
                var addButton = $(this).parents("tr").find('.packing-add-row');

                if (chkbox.is(':checked')) {
                    addButton.show();

                    AddPackingRow(this);

                    /*
                    var color = 'class' + $(this).parents("tr").children('td')[9].innerText.replace(' ', '');
              
                    if(assignedColorsArray.join('~~').search(color) == -1)
                    assignedColorsArray.push(color);
                    */
                }
                else {
                    addButton.hide();
                }

            });

            //$('input.date-style-invoice','#main_content').datepicker( {changeYear: true, yearRange: '1900:2020', dateFormat: 'dd-mm-yy', buttonImage: 'App_Themes/ikandi/images/calendar.gif'}).focus(function(){this.blur(); return false;});

        });

        function ApplyPermissionsOnPackingListColumns(isWritePermitted) {
            var date = new Date();
            var time = date.getTime();

            $('table.packing-upper input[type=text]').keydown(function() { return false; });
            $('table.packing-upper textarea').keydown(function() { return false; });

            var date1 = new Date();
            var time1 = date1.getTime();
            var diff = time1 - time;
            
        }

        function AddDimensionRow() {

            var mainRow = $('.dimension-add-row').parents('tr');
            var newRow = mainRow.clone(true).insertAfter($('.dimension-add-row').parents('tr:last'));
            newRow.find('input').val('');
            newRow.find('img').remove();

            var deleteRowLink = document.createElement('img');
            deleteRowLink.src = '../../App_Themes/ikandi/images/minus.gif';
            deleteRowLink.style.cursor = 'hand';
            deleteRowLink.className = 'dimension-delete-row';
            newRow.children('td')[2].appendChild(deleteRowLink);
            newRow.children('td')[2].style.verticalAlign = 'middle';

            $('.dimension-delete-row').click(function() {
                $(this).parents('tr').remove();
            });
        }

        function CalculateQuantity(pkgNoToValue, pkgNoFromValue, quantityAssignedValue, currentRow, calcTotal) {
            
            var totalPkgs = +pkgNoToValue - +pkgNoFromValue + 1;
            var quantityAssigned = 0;

            for (var i = 0; i < quantityAssignedValue.length; i++) {
                quantityAssigned = +quantityAssigned + +quantityAssignedValue[i].value;
            }

            var quantity = '';
            var chkIsRatio = currentRow.find('input.chk-is-ratio');

            if (chkIsRatio.attr('checked')) {
                quantityAssigned = 0;
                quantityAssignedValue = currentRow.find('div.packing-ratio span');

                for (var i = 0; i < quantityAssignedValue.length; i++) {
                    quantityAssigned = +quantityAssigned + +quantityAssignedValue[i].innerText;
                }

                var txtIsRatio = currentRow.find('input.txt-is-ratio');
                var ratioQuantity = +quantityAssigned * +txtIsRatio.val();

                quantity = quantityAssigned + ' X ' + txtIsRatio.val() + ' = ' + ratioQuantity + ' X ' + totalPkgs + ' = ' + +ratioQuantity * +totalPkgs + ' PCS';
            }
            else {
                quantity = quantityAssigned + ' X ' + totalPkgs + ' = ' + +quantityAssigned * +totalPkgs + ' PCS';
            }

            currentRow.find('.packing-quantity').html(quantity);

            if (calcTotal == null)
                CalculateAndShowTotal();
        }

        function CalculateAndShowTotal() {
          
            var totalRow = $('.packing-total');

            if (totalRow.length == 0) {
                totalRow = $('.packing_table tr:last').clone(true).insertAfter($('.packing_table tr:last'));
                totalRow.attr('class', 'packing-total');

                var totalRowCells = totalRow.children('td');

                for (var i = 0; i < totalRowCells.length; i++) {
                    totalRowCells[i].style.verticalAlign = 'middle';

                    switch (i) {
                        case 5:
                            totalRowCells[i].innerHTML = 'Total:';
                            break;

                        case 6:
                            totalRowCells[i].className = 'quantity-total';
                            totalRowCells[i].innerHTML = '';
                            break;

                        default:
                            totalRowCells[i].innerHTML = '';
                            break;
                    }
                }
            }

            var total = 0;
            var packingQuantityValues = $('.packing-quantity');

            for (var i = 0; i < packingQuantityValues.length; i++) {
                var quantity = 0;
                if (packingQuantityValues[i].innerHTML != null) {
                    var quantity = packingQuantityValues[i].innerHTML;
                }

                quantity = quantity.substring(quantity.lastIndexOf('=') + 1, quantity.search('PCS') - 1);
                total = total + +quantity;
            }

            $('.quantity-total').html(total + ' PCS');
        }

        function CalculateAndShowSummary(isSave) {
            //debugger;
          
            var date = new Date();
            var time = date.getTime();

            if (isSave == true) {
                var invNumber = $('#<%= txtInvoiceNumber.ClientID %>').val();
                var hdnInvoiceNumber = $('#<%= hdnInvoiceNumber.ClientID %>').val();
               


                if (invNumber != '') {

                    if (hdnInvoiceNumber != hdnInvoiceNumber) {
                        proxy.invoke("GetIsValidInvoiceNumber", { InvoiceNumber: invNumber }, function(result) {
                            if (result == true) {
                                jQuery.facebox("INVOICENUMBER" + invNumber + " IS ALREADY EXIST. PLEASE INSERT A NEW INVOICENUMBER");
                                $('#<%= txtInvoiceNumber.ClientID %>').focus();
                                isSave = false;
                            }
                            else {
                                isSave = true;
                            }

                        }, onPageError, false, true);
                    }
                }
            }

            //if(!isSave) return;

            var objPacking =
        {
            OrderID: (window.location.querystring['oid'] == undefined) ? -1 : window.location.querystring['oid'],
            PackingID: (window.location.querystring['pid'] == undefined) ? -1 : window.location.querystring['pid'],
            TotalGrossWeight: parseFloat(($.trim($('#<%= txtGrossWeight.ClientID %>').val()) == '') ? 0 : $('#<%= txtGrossWeight.ClientID %>').val()),
            TotalNetWeight: parseFloat(($.trim($('#<%= txtNetWeight.ClientID %>').val()) == '') ? 0 : $('#<%= txtNetWeight.ClientID %>').val()),
            TotalPackages: ($('.packing_table input.pkg-no-to:last').val() == undefined || $('.packing_table input.pkg-no-to:last').val() == '') ? 0 : parseInt($('.packing_table input.pkg-no-to:last').val()),
            PackageNumbers: ($('.packing_table input.pkg-no-from:first').val() == undefined || $('.packing_table input.pkg-no-from:first').val() == '') ? '0-0' : $('.packing_table input.pkg-no-from:first').val() + '-' + $('.packing_table input.pkg-no-to:last').val(),

            Exporter: $('#<%= txtExporter.ClientID %>').val(),
            InvoiceNumber: $('#<%= txtInvoiceNumber.ClientID %>').val(),
            InvoiceDate: ConvertDateFromJavascriptToCSharpUsable($('#<%= txtInvoiceDate.ClientID %>').val()),
            BuyerOrderNumber: $('#<%= txtBuyerOrderNumber.ClientID %>').val(),
            BuyerOrderDate: ConvertDateFromJavascriptToCSharpUsable($('#<%= txtBuyerOrderDate.ClientID %>').val()),
            OtherReferences: $('#<%= txtOtherReferences.ClientID %>').val(),
            Consignee: $('#<%= txtConsignee.ClientID %>').val(),
            BuyerOtherThanConsignee: $('#<%= txtBuyerOtherThanConsignee.ClientID %>').val(),
            CountryOfOriginOfGoods: $('#<%= txtCountryOfOriginOfGoods.ClientID %>').val(),
            CountryOfFinalDestination: $('#<%= txtCountryOfFinalDestination.ClientID %>').val(),
            PreCarriageBy: $('#<%= txtPreCarriageBy.ClientID %>').val(),
            PlaceOfReceiptByPreCarrier: $('#<%= txtPlaceOfReceiptByPreCarrier.ClientID %>').val(),
            FlightNumber: $('#<%= txtFlightNumber.ClientID %>').val(),
            PortOfLoading: $('#<%= txtPortOfLoading.ClientID %>').val(),
            PortOfDischarge: $('#<%= txtPortOfDischarge.ClientID %>').val(),
            FinalDestination: $('#<%= txtFinalDestination.ClientID %>').val(),
            MarksAndContainerNumber: $('#<%= txtMarksAndContainerNumber.ClientID %>').val(),
            NumberAndKindOfPackages: '',
            DescriptionOfGoods: $('#<%= txtDescriptionOfGoods.ClientID %>').val(),
            Remarks: $('#<%= txtRemarks.ClientID %>').val(),
            TermsOfDeliveryAndPayment: $('#<%= txtTermsOfDeliveryAndPayment.ClientID %>').val(),
            PackingOrdersCollection: new Array(),
            Distributions: new Array(),
            Dimensions: new Array()
        };

            $('.summary-sizes-header').html('<div>Sizes</div>');
            $('.summary-cloned-row').remove();

            var sizeHtml = GetHtmlForSizes('summary-header-cell', $('.packing-sizes-header input'));
            $('.summary-sizes-header').html($('.summary-sizes-header').html() + sizeHtml);

            var counterDistributions = 0;
            var counterPackingOrders = 0;

            if (assignedColorsArray == undefined) return;



            for (var i = assignedColorsArray.length - 1; i >= 0; i--) {
                var orderDetailId = $('.' + assignedColorsArray[i] + ' span.order-detail-id').html();
                
                var prdPlanningID = $('.' + assignedColorsArray[i] + ' span.production_planning_id').html();
               

                var isSelected = $('.' + assignedColorsArray[i] + ' .order-selection input:checkbox').is(':checked');


                var summaryRow = $('.packing-summary tr.row-to-clone').clone(true).insertAfter($('.packing-summary tr.row-to-clone'));

                summaryRow.attr('class', 'summary-cloned-row');
                summaryRow.css('display', 'block');

                var lineNumber = $('.' + assignedColorsArray[i] + ' td.packing-line-number');
                var pkgNumberFrom = $('.' + assignedColorsArray[i] + ' input.pkg-no-from:first');
                var pkgNumberTo = $('.' + assignedColorsArray[i] + ' input.pkg-no-to:last');
                // var fabric

                if (lineNumber.length > 0 && lineNumber[0].innerHTML != null) {
                    summaryRow.find('.summary-line-number').html(lineNumber[0].innerHTML);
                }

                var colorName = $('.main-row-' + assignedColorsArray[i]).children('td')[3].innerText;
                summaryRow.find('.summary-color').html(colorName);

                summaryRow.find('.summary-pkg-number').html(pkgNumberFrom.val() + ' To ' + pkgNumberTo.val() + ' Pkgs');

                var sizeHtml = GetHtmlForSizes('summary-quantity-cell', $('.' + assignedColorsArray[i] + ' input.packing-quantity-assigned-value'));
                summaryRow.find('.summary-sizes td.sizes').html(sizeHtml);

                var txtRatio = $('.' + assignedColorsArray[i] + ' input.txt-is-ratio');

                for (var j = 0; j < txtRatio.length; j++) {
                    if (txtRatio[j].value != '' && txtRatio[j].value != 0) {  // 
                        var spanRatio = $(txtRatio[j]).parents('tr.' + assignedColorsArray[i]).find('div.packing-ratio span');
                        var ratioHtml = summaryRow.find('.summary-sizes td.ratio').html();

                        var ratioPreviousValues;

                        if (ratioHtml != '')
                            ratioPreviousValues = $(ratioHtml).find('td');

                        sizeHtml = GetHtmlForSizes('summary-ratio-cell', spanRatio, txtRatio[j].value, ratioPreviousValues);
                        summaryRow.find('.summary-sizes td.ratio').html(sizeHtml);
                    }
                }

                var quantityCell = $('.summary-quantity-cell');
                var ratioCell = $('.summary-ratio-cell');

                if (i == 0) {
                    var grandTotal = 0;
                    var cellWidth;
                    var cellCount = quantityCell.length;

                    if (cellCount > 0)
                        cellWidth = 100 / (cellCount + 1);

                    sizeHtml = '<table style="width:100%"><tr>';


                    var numberOfVerticalTotalColumns = quantityCell.length / assignedColorsArray.length;

                    for (var j = 0; j < numberOfVerticalTotalColumns; j++) {

                        var quantityCellText = '0';
                        var ratioCellText = '0';

                        for (var k = 0; k < assignedColorsArray.length; k++) {
                            //var quantityCellText = (quantityCell[j] == undefined) ? '0' : quantityCell[j].innerText;
                            quantityCellText = (quantityCell[j + k * numberOfVerticalTotalColumns] == undefined) ? quantityCellText : +quantityCellText + +quantityCell[j + k * numberOfVerticalTotalColumns].innerText;
                            //var ratioCellText = (ratioCell[j] == undefined) ? '0' : ratioCell[j].innerText;
                            ratioCellText = (ratioCell[j + k * numberOfVerticalTotalColumns] == undefined) ? ratioCellText : +ratioCellText + +ratioCell[j + k * numberOfVerticalTotalColumns].innerText;
                        }
                        var verticalTotal = +quantityCellText + +ratioCellText
                        sizeHtml = sizeHtml + '<td style="width:' + cellWidth + '%"> ' + verticalTotal + '</td>';

                        grandTotal = grandTotal + verticalTotal;
                    }

                    sizeHtml = sizeHtml + '<td class="summary-total" style="width:' + cellWidth + '%"> ' + grandTotal + '</td>';
                    sizeHtml = sizeHtml + '</tr></table>';

                    $('.summary-vertical-total').html(sizeHtml);
                }

                var po =
            {
                PackingID: -1,
                OrderDetailID: 0,
                TotalPackages: 0,
                PackageNumbers: '',
                ProductionPlanningId: -1,
                IsSelected: false
            };
                
                po.PackingID = (window.location.querystring['pid'] == undefined) ? -1 : +window.location.querystring['pid'];
                po.OrderDetailID = +orderDetailId;
                po.TotalPackages = +pkgNumberTo.val() - +pkgNumberFrom.val() + 1;
                po.PackageNumbers = pkgNumberFrom.val() + '-' + pkgNumberTo.val();
                po.ProductionPlanningId = +prdPlanningID; //(window.location.querystring['ppid'] == undefined) ? -1 : +window.location.querystring['ppid'];
                po.IsSelected = isSelected;

                objPacking.PackingOrdersCollection[counterPackingOrders] = po;
                counterPackingOrders++;

                if (isSave) {
                    var colorRow = $('.' + assignedColorsArray[i]);
                    var sizes = $('.summary-sizes-header td');

                    for (var j = colorRow.length - 1; j >= 0; j--) {
                        isContinue = false;

                        for (var k = 0; k < objPacking.PackingOrdersCollection.length; k++) {
                            if (objPacking.PackingOrdersCollection[k].OrderDetailID == +orderDetailId && objPacking.PackingOrdersCollection[k].IsSelected == false) {
                                isContinue = true;
                                break;
                            }
                        }

                        if (isContinue)
                            continue;

                        var pkgNoFrom = $('.' + assignedColorsArray[i] + j).find('input.pkg-no-from').val();
                        var pkgNoTo = $('.' + assignedColorsArray[i] + j).find('input.pkg-no-to').val();
                        var quantity = $('.' + assignedColorsArray[i] + j).find('input.packing-quantity-assigned-value').val();
                        var sizesQuantity = $('.' + assignedColorsArray[i] + j).find('input.packing-quantity-assigned');
                        var isRatio = $('.' + assignedColorsArray[i] + j).find('input.chk-is-ratio').attr('checked');
                        var ratioPackQuantity = $('.' + assignedColorsArray[i] + j).find('input.txt-is-ratio').val();
                        //var

                        pkgNoFrom = (pkgNoFrom == null) ? 0 : pkgNoFrom;
                        pkgNoTo = (pkgNoTo == null) ? 0 : pkgNoTo;
                        quantity = (quantity == null) ? 0 : quantity;
                        isRatio = (isRatio == null) ? false : isRatio;
                        ratioPackQuantity = (ratioPackQuantity == null) ? 0 : ratioPackQuantity;
                        var fabricID = "Fabric" + orderDetailId;

                        var dn =
                    {
                        PackingID: -1,
                        ProductionPlanningID: -1,
                        OrderDetailID: 0,
                        PkgNoFrom: 0,
                        PkgNoTo: 0,
                        Fabric: '',
                        Quantity: 0,
                        IsRatioPack: false,
                        RatioPackQtyPerPkg: 0,
                        PackingSizes: new Array()
                    };

                        dn.PackingID = (window.location.querystring['pid'] == undefined) ? -1 : window.location.querystring['pid'];
                        dn.ProductionPlanningID = +prdPlanningID;
                        dn.OrderDetailID = +orderDetailId;
                        dn.PkgNoFrom = pkgNoFrom;
                        dn.PkgNoTo = pkgNoTo;

                        dn.Fabric = $("." + fabricID).val();
                        dn.Quantity = +quantity * (+pkgNoTo - +pkgNoFrom + 1);
                        dn.IsRatioPack = isRatio;
                        dn.RatioPackQtyPerPkg = +ratioPackQuantity;

                        for (var k = 0; k < sizesQuantity.length; k++) {
                            var ps =
                        {
                            OrderDetailID: 0,
                            OrderDetailSizeID: 0,
                            Size: '',
                            Quantity: 0,
                            RatioPack: 0,
                            Ratio: 0,
                            Singles: 0
                        };

                            ps.OrderDetailID = +orderDetailId;

                            if (sizes.length > 0) {
                                if (sizes[k].innerHTML != null) {
                                    ps.Size = sizes[k].innerHTML;
                                }
                            }

                            if (sizesQuantity.length > 0)
                                ps.Quantity = +sizesQuantity[k].value;

                            dn.PackingSizes[k] = ps;
                        }

                        objPacking.Distributions[counterDistributions] = dn;
                        counterDistributions++;
                    }
                }
            }



            if (!isSave) return false;

            var dimensions = $('.dimension-row');

            for (var i = 0; i < dimensions.length; i++) {
                var dm =
            {
                PackingDimensionID: 0,
                PackingID: 0,
                Dimension: '',
                Quantity: 0
            };

                if ($.trim($(dimensions[i]).find('input.dim1').val()) == '' || $.trim($(dimensions[i]).find('input.dim2').val()) == '' || $.trim($(dimensions[i]).find('input.dim3').val()) == '' || $.trim($(dimensions[i]).find('input.number-of-boxes').val()) == '')
                    continue;

                dm.Dimension = $(dimensions[i]).find('input.dim1').val() + 'X' + $(dimensions[i]).find('input.dim2').val() + 'X' + $(dimensions[i]).find('input.dim3').val();
                dm.Quantity = +$(dimensions[i]).find('input.number-of-boxes').val();

                objPacking.Dimensions[i] = dm;
            }
            var date1 = new Date();
            var time1 = date1.getTime();
            var diff = time1 - time;

            //debugger;
            proxy.invoke("SavePacking", { objPacking: objPacking },
    function(success) {
        if (success) {
            var allPkgFrom = $('.pkg-no-from:first').val();
            var allPkgTo = $('.pkg-no-to:last').val();
            var totalPackages = (+allPkgTo - +allPkgFrom) + 1;

            var packageValues = totalPackages + '~~' + allPkgFrom + '-' + allPkgTo;

            ShowHideMessageBox(true, 'Packing List saved successfully.', 'Packing List', GetTotalPackagesAndPackageFromToAndUpdateParentWindow, packageValues);
        }
        else {
            ShowHideValidationBox(true, 'Some error occured in saving Packing List.', 'Packing List');
        }
    },
     onPageError, false, true);
        }

        function ConvertDateFromJavascriptToCSharpUsable(sourceDate) {
            //debugger;
            sourceDate = ParseDateToSimpleDate(sourceDate);

            return (sourceDate.getMonth() + 1 + '/' + sourceDate.getDate() + '/' + sourceDate.getFullYear());
        }

//        function ParseDateToPackingDate(dateObject) {
//            debugger;

//            var index = dateObject.indexOf('(');
//            if (index > -1) {
//                dateObject = $.trim(dateObject.substring(0, index));
//            }

//           // var thisDate = Date.parseDate(dateObject, 'd/M/yyyy')

//            var thisDate = dateObject.format("m/dd/yy");

//           return thisDate;
//        }

        function GetTotalPackagesAndPackageFromToAndUpdateParentWindow(packageValues) {
            window.returnValue = packageValues;
            window.close();
            return false;
        }

        function GetHtmlForSizes(className, sizeObject, ratioQuantity, ratioPreviousValues) {
            //
            var horizontalTotal = 0;

            var cellCount = $('.packing-sizes-header input').length;
            var cellWidth;

            if (cellCount > 0)
                cellWidth = 100 / (cellCount + 1);

            var sizeHtml = '<table style="width:100%"><tr>';

            for (var i = 0; i < cellCount; i++) {
                var sizeValue = 0;

                for (var j = 0; j < sizeObject.length; j++) {
                    //if(i == sizeObject[j].id.substr(sizeObject[j].id.length - 1, 1))
                    if (i == sizeObject[j].id.substr(sizeObject[j].id.indexOf('txtSize') + 7) || i == sizeObject[j].id.substr(sizeObject[j].id.indexOf('lblRatio') + 8)) {
                        var row = $(sizeObject[j]).parents('tr');
                        var pkgNoFrom = row.find('input.pkg-no-from');
                        var pkgNoTo = row.find('input.pkg-no-to');
                        var totalPkgs = 1;

                        if (pkgNoFrom.length == 1 && pkgNoTo.length == 1)
                            totalPkgs = pkgNoTo.val() - pkgNoFrom.val() + 1;

                        if (sizeObject[j].value == undefined) {
                            if (sizeValue == 0) {
                                if (ratioPreviousValues == undefined)
                                    sizeValue = +sizeObject[j].innerText * +totalPkgs * +ratioQuantity;
                                else
                                    sizeValue = (+sizeObject[j].innerText * +totalPkgs * +ratioQuantity) + +ratioPreviousValues[j].innerText;
                            }
                        }
                        else {
                            if (className == 'summary-header-cell')
                                sizeValue = sizeObject[j].value;
                            else
                                sizeValue = sizeValue + +sizeObject[j].value * totalPkgs;
                        }
                    }
                }

                horizontalTotal = horizontalTotal + sizeValue;
                sizeHtml = sizeHtml + '<td class="' + className + '" style="width:' + cellWidth + '%"> ' + sizeValue + '</td>';
            }

            switch (className) {
                case 'summary-header-cell':
                    sizeHtml = sizeHtml + '<td style="width:' + cellWidth + '%">Total</td>';
                    break;

                case 'summary-quantity-cell':
                case 'summary-ratio-cell':
                    sizeHtml = sizeHtml + '<td class="summary-horizontal-total" style="width:' + cellWidth + '%"> ' + horizontalTotal + '</td>';
                    break;
            }

            sizeHtml = sizeHtml + '</tr></table>';
            return sizeHtml;
        }  
        
        function PrintExcelForPrintForm() {
            var objPackingId = '<%= hdnPackingId.ClientID %>';
            var objOrderId  = '<%= hdnOrderId.ClientID %>';
            var packingId = $("#" + objPackingId).val();            
            var OrderId = $("#" + objOrderId).val();

            proxy.invoke("GeneratePackingList", { PackingId: packingId, OrderID: OrderId }, function(result) {
                
                if ($.trim(result) == '')
                    jQuery.facebox("Some error occured on the server, please try again later.");
                else
                    window.open("/uploads/temp/" + result);
            });
            return false;
        }
              

    </script>

    <div class="print-box" style="width: 97%; margin-left: 10px">
        <div class="form_box">
            <asp:HiddenField ID="hdnPackingId" runat="server" Value="0" />
            <asp:HiddenField ID="hdnOrderId" runat="server" Value="0" />
            <div class="form_heading">
                Packing List
            </div>
            <table class="packing-upper" style="width: 100%; border-collapse: collapse; border-bottom: 0px !important;
                border-right: 0px !important; border-top: 0px !important">
                <tr>
                    <td style="width: 54%; padding-bottom: 0px !important; padding-top: 0px !important;
                        border-bottom: solid 1px black">
                        <div class="form_small_heading_10px_with_default_padding">
                            Exporter</div>
                        <asp:TextBox ID="txtExporter" runat="server" TextMode="MultiLine" BorderWidth="0px"
                            Rows="4" CssClass="input_overflow" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 46%; padding: 0px">
                        <table class="form_box_border" style="border-bottom: 0px !important; border-right: 0px !important;
                            border-top: 0px !important">
                            <tr>
                                <td colspan="2" style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Invoice No &amp; Date</div>
                                    <asp:TextBox ID="txtInvoiceNumber" runat="server" BorderWidth="0px" Width="60%"></asp:TextBox>
                                    <asp:TextBox ID="txtInvoiceDate" runat="server" BorderWidth="0px" Width="30%" CssClass="date-style-invoice"></asp:TextBox>
                                    <asp:HiddenField ID="hdnInvoiceNumber" runat="server" Value="" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Buyer&#39;s Order No. &amp; Date</div>
                                    <nobr><asp:TextBox ID="txtBuyerOrderNumber" runat="server" BorderWidth="0px" Width="25%"></asp:TextBox>
                                    &nbsp;
                    <asp:TextBox ID="txtBuyerOrderDate" runat="server" BorderWidth="0px" Width="20%" CssClass="do-not-allow-typing"></asp:TextBox>&nbsp;Serial Number
                    <asp:TextBox ID="txtSerialNumber" runat="server" BorderWidth="0px" Width="25%" CssClass="do-not-allow-typing "></asp:TextBox></nobr>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Other Reference(s)</div>
                                    <asp:TextBox ID="txtOtherReferences" runat="server" BorderWidth="0px" Width="60%"></asp:TextBox>
                                    <asp:Label ID="lblPackingMode" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                        <div class="form_small_heading_10px_with_default_padding">
                            Consignee</div>
                        <asp:TextBox ID="txtConsignee" runat="server" TextMode="MultiLine" BorderWidth="0px"
                            Rows="6" Width="100%" CssClass="input_overflow"></asp:TextBox>
                    </td>
                    <td style="padding: 0px">
                        <table class="form_box_border" style="border-bottom: 0px !important; border-right: 0px !important;
                            border-top: 0px !important">
                            <tr>
                                <td colspan="2" style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Buyer (if other than Consignee)</div>
                                    <asp:TextBox ID="txtBuyerOtherThanConsignee" runat="server" TextMode="MultiLine"
                                        BorderWidth="0px" Width="100%" Height="74px" CssClass="input_overflow"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Country of origin of goods</div>
                                    <asp:TextBox ID="txtCountryOfOriginOfGoods" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox>
                                </td>
                                <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Country of final destination</div>
                                    <asp:TextBox ID="txtCountryOfFinalDestination" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 0px">
                        <table class="form_box_border" style="border-bottom: 0px !important; border-top: 0px !important">
                            <tr>
                                <td style="width: 50%; padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Pre-carriage By</div>
                                    <asp:TextBox ID="txtPreCarriageBy" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox>
                                </td>
                                <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Place of receipt by pre-carrier</div>
                                    <asp:TextBox ID="txtPlaceOfReceiptByPreCarrier" runat="server" BorderWidth="0px"
                                        Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Flight Number</div>
                                    <asp:TextBox ID="txtFlightNumber" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox>
                                </td>
                                <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Port of Loading</div>
                                    <asp:TextBox ID="txtPortOfLoading" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Port of Discharge</div>
                                    <asp:TextBox ID="txtPortOfDischarge" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox>
                                </td>
                                <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Final Destination</div>
                                    <asp:TextBox ID="txtFinalDestination" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="padding-bottom: 0px !important; padding-top: 0px !important">
                        <div class="form_small_heading_10px_with_default_padding">
                            Terms of Delivery and Payment</div>
                        <asp:TextBox ID="txtTermsOfDeliveryAndPayment" runat="server" TextMode="MultiLine"
                            CssClass="input_overflow" BorderWidth="0px" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 0px">
                        <table style="width: 100%; border-collapse: collapse; border-bottom: 0px !important;
                            border-right: 0px !important; border-top: 0px !important">
                            <tr>
                                <td style="width: 30%; padding-bottom: 0px !important; padding-top: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Marks &amp; No. / Container No.</div>
                                    <asp:TextBox ID="txtMarksAndContainerNumber" runat="server" BorderWidth="0px" Width="100%"
                                        Height="61" TextMode="MultiLine" CssClass="input_overflow"></asp:TextBox>
                                </td>
                                <td style="width: 70%; padding-bottom: 0px !important; padding-top: 0px !important"
                                    colspan="2">
                                    <nobr><div style="width:50%" class="form_small_heading_10px_with_default_padding">
                                        Number &amp; Kind of Pkgs. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Description of Goods</div></nobr>
                                    <asp:TextBox ID="txtDescriptionOfGoods" runat="server" BorderWidth="1px" Height="61"
                                        TextMode="MultiLine" CssClass="input_overflow" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="padding: 0px">
                        <table class="form_box_border" style="border-bottom: 0px !important; border-right: 0px !important;
                            border-top: 0px !important">
                            <tr>
                                <td style="width: 30%; text-align: center; vertical-align: top; padding-bottom: 0px !important;
                                    padding-top: 0px !important; border-bottom: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Quantity</div>
                                </td>
                                <td style="width: 70%; text-align: center; vertical-align: top; padding-bottom: 0px !important;
                                    padding-top: 0px !important; border-bottom: 0px !important">
                                    <div class="form_small_heading_10px_with_default_padding">
                                        Remarks</div>
                                    <asp:TextBox ID="txtRemarks" runat="server" BorderWidth="0px" Width="100%" Height="61"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvPackingList" runat="server" CssClass="packing_table "
                AutoGenerateColumns="False" OnRowDataBound="gvPackingList_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Pkg No" HeaderStyle-Width="9%">
                        <HeaderStyle Width="9%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Line No">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ContractNumber") %>'></asp:Label></div>
                            <div>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LineItemNumber") %>'></asp:Label></div>
                        </ItemTemplate>
                        <HeaderStyle Width="9%" />
                        <ItemStyle CssClass="abc" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Style No" DataField="StyleNumber" HeaderStyle-Width="9%" />
                    <asp:BoundField HeaderText="Color" DataField="FabricColor" HeaderStyle-Width="8%">
                        <HeaderStyle Width="8%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Item" DataField="Item" HeaderStyle-Width="8%">
                        <HeaderStyle Width="8%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Fabric" HeaderStyle-Width="7%">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFabric" CssClass='<%# "Fabric" + Eval("OrderDetailID") %>' runat="server"
                                Text='<%# Eval("Fabric")%>' BorderWidth="0px" Width="100%" Style="text-align: center;
                                font-size: 8px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="7%"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QTY (PCS)" ItemStyle-Width="15%" HeaderStyle-CssClass="no_border_top"
                        ItemStyle-CssClass="numeric_text no_border_top">
                        <ItemTemplate>
                            Singles:
                            <asp:Label ID="lblSinglesQuantity" runat="server"></asp:Label><br />
                            Ratio Pack:
                            <asp:Label ID="lblRatioPackQuantity" runat="server"></asp:Label><br />
                            Total:
                            <asp:Label ID="lblTotalQuantity" runat="server" Text='<%# Eval("ShippingQuantity") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="no_border_top"></HeaderStyle>
                        <ItemStyle CssClass="numeric_text no_border_top" Width="15%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Font-Bold="true" HeaderStyle-CssClass="packing-sizes-header no_border_top"
                        ItemStyle-CssClass="numeric_text">
                        <HeaderTemplate>
                            <div>
                                Sizes
                            </div>
                            <asp:TextBox ID="txtSize0" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize1" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize2" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize3" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize4" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize5" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize6" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize7" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize8" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize9" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize10" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSize11" runat="server" Width="30px" Visible="false"></asp:TextBox>
                            
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div id="divSingles" runat="server" visible="false" style="width: 10px; float: left"
                                class="div-singles">
                                S</div>
                            <div class="packing-singles">
                                <asp:Label ID="lblSingles0" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles1" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles2" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles3" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles4" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles5" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles6" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles7" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles8" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles9" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles10" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblSingles11" runat="server" Width="30px" Visible="false"></asp:Label>
                            </div>
                            <div id="divRatio" runat="server" visible="false" style="width: 10px; float: left"
                                class="div-ratio">
                                R</div>
                            <div class="packing-ratio">
                                <asp:Label ID="lblRatio0" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio1" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio2" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio3" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio4" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio5" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio6" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio7" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio8" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio9" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio10" runat="server" Width="30px" Visible="false"></asp:Label>
                                <asp:Label ID="lblRatio11" runat="server" Width="30px" Visible="false"></asp:Label>
                            </div>
                            <div style="width: 10px; float: left">
                            </div>
                            <div class="packing-total-quantity">
                                <asp:TextBox ID="txtSize0" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize1" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize2" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize3" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize4" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize5" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize6" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize7" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize8" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize9" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize10" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                                <asp:TextBox ID="txtSize11" runat="server" Width="30px" Visible="false" CssClass="packing-quantity-assigned numeric-field-without-decimal-places"></asp:TextBox>
                            </div>
                            <asp:TextBox ID="txtIsRatio" runat="server" CssClass="hide_me txt-is-ratio" Width="20px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle CssClass="packing-sizes-header no_border_top"></HeaderStyle>
                        <ItemStyle CssClass="numeric_text" Font-Bold="True"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <img src="../../App_Themes/ikandi/images/plus.gif" class='<%# Convert.ToInt32(Eval("PackingID")) == -1 ? "packing-add-row hide_me" : "packing-add-row"  %>'
                                style="cursor: hand" id="imgAddRow" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="" ItemStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="lblProductionPlanningID" runat="server" Text='<%# Eval("ProductionPlanningID")%>'
                                CssClass="hide_me production_planning_id"></asp:Label>
                            <asp:Label ID="lblSeparator" runat="server" Text="#" CssClass="hide_me "></asp:Label>
                            <asp:Label ID="lblOrderDetailId" CssClass="order-detail-id hide_me" runat="server"
                                Text='<%# Eval("OrderDetailID")%>'></asp:Label>
                            <asp:CheckBox ID="chkIsSelected" Checked='<%# Convert.ToInt32(Eval("PackingID")) > 0 %>'
                                CssClass='<%# Convert.ToInt32(Eval("PackingID")) == -1 ? "order-selection" : "order-selection hide_me"  %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table class="packing-summary " style="text-align: center; width: 100%; border-collapse: collapse"
                cellpadding="0px" cellspacing="0px">
                <tr>
                    <th class="main_summary_td">
                        Line No
                    </th>
                    <th class="main_summary_td">
                        Color
                    </th>
                    <th class="main_summary_td">
                        Pkg No
                    </th>
                    <th class="summary-sizes-header main_summary_td">
                        <div>
                            Sizes</div>
                    </th>
                </tr>
                <tr class="row-to-clone" style="display: none">
                    <td class="summary-line-number main_summary_td">
                    </td>
                    <td class="summary-color main_summary_td">
                    </td>
                    <td class="summary-pkg-number main_summary_td">
                    </td>
                    <td class="summary-sizes main_summary_td">
                        <table style="width: 100%">
                            <tr>
                                <td class="ratio">
                                </td>
                            </tr>
                            <tr>
                                <td class="sizes">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="summary-order-detail-id" style="display: none">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="main_summary_td">
                    </td>
                    <td class="summary-vertical-total main_summary_td">
                    </td>
                    <td style="display: none">
                    </td>
                </tr>
            </table>
            <table class="form_table" bordercolor="#000000" border="1">
                <tr>
                    <td style="width: 25%">
                        Total Gross Weight
                    </td>
                    <td style="width: 25%">
                        <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="numeric-field-with-three-decimal-places"></asp:TextBox>
                    </td>
                    <td style="width: 50%" rowspan="2">
                        <div class="form_small_heading_10px_with_default_padding">
                            Signature &amp; Date</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Total Net Weight
                    </td>
                    <td>
                        <asp:TextBox ID="txtNetWeight" runat="server" CssClass="numeric-field-with-three-decimal-places"></asp:TextBox>
                    </td>
                </tr>
                <tr class="dimension-row">
                    <td>
                        Dims
                    </td>
                    <td>
                        <asp:TextBox ID="txtDim1" runat="server" Width="20px" BorderWidth="1px" CssClass="numeric-field-without-decimal-places dim1"></asp:TextBox>
                        X
                        <asp:TextBox ID="txtDim2" runat="server" Width="20px" BorderWidth="1px" CssClass="numeric-field-without-decimal-places dim2"></asp:TextBox>
                        X
                        <asp:TextBox ID="txtDim3" runat="server" Width="20px" BorderWidth="1px" CssClass="numeric-field-without-decimal-places dim3"></asp:TextBox>
                        /
                        <asp:TextBox ID="txtNumberOfBoxes" runat="server" Width="20px" BorderWidth="1px"
                            CssClass="numeric-field-without-decimal-places number-of-boxes"></asp:TextBox>
                        Boxes
                    </td>
                    <td>
                        <img src="../../App_Themes/ikandi/images/plus.gif" class="dimension-add-row" style="cursor: hand" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnShowSummary" runat="server" CssClass="summary da_submit_button" Text="Summary"  OnClientClick="CalculateAndShowSummary(false); return false;" />
                        <asp:Button ID="btnSave" runat="server" CssClass="save da_submit_button" Text="Save" OnClientClick="ValidateForm(); if($('FORM').valid()) { CalculateAndShowSummary(true); return false; }" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hiddenScript" runat="server" />
    </div>
    <asp:Button runat="server" ID="btnPrintList" class="print da_submit_button" Text="Print" onclick="btnPrintList_Click" />
   <%-- <input type="button" id="btnPrint" class="print" onclick="return PrintExcelForPrintForm();" />--%>
   <%-- <input type="button" id="btnPrint" class="print" onclick="return PrintPDF('',-1,1100);" />--%>
   
</asp:Content>
