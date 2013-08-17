﻿//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion
// Add Member Success Function
function AddMemberSuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addMemberDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Member saved successfully.", "dialogSuccess");

        memberObjData.fnDraw();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit Member Success Function
function EditMemberSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editMemberDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Member updated successfully.", "dialogSuccess");

        memberObjData.fnDraw();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete Member Success Function
function DeleteMemberSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteMemberDailog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Member deleted successfully.", "dialogSuccess");

        memberObjData.fnDraw();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();

    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

var memberObjData;

$(function () {
    //start DataTable Script

    memberObjData = $('#memberDataTable').dataTable({
        "bJQueryUI": false,
        "bAutoWidth": false,
        "sPaginationType": "bootstrap",
        "bSort": false,
        "oLanguage": {
            "sLengthMenu": "_MENU_ items per page",
            "sZeroRecords": "Data not found",
            "sProcessing": "Loading...",
            "sInfo": "_START_ - _END_ of _TOTAL_ items",
            "sInfoEmpty": "0 - 0 of 0 items",
            "sInfoFiltered": "(filtered from _MAX_ total items)"
        },
        "bProcessing": true,
        "bServerSide": true,
        "sAjaxSource": "/Admin/Member/GetMembers",
        "aoColumns": [
            { "sName": "FullName" },
            { "sName": "Address" },
            { "sName": "DateOfBirth" },
            { "sName": "PhoneNumber" },
            { "sName": "MobileNumber" },
            { "sName": "Actions",
                "bSearchable": false,
                "bSortable": false,
                "fnRender": function (oObj) {
                    return '<a class="lnkDetailsMember btn btn-primary btn-mini" style="margin-right: 5px;" href=\"/Admin/Member/Details/' +
                                oObj.aData[4] + '\" ><icon class="icon-search icon-white"></icon></a>' +
                                '<a class="lnkEditMember  btn btn-success btn-mini" style="margin-right: 5px;" href=\"/Admin/Member/Edit/' +
                                oObj.aData[4] + '\" ><icon class="icon-pencil icon-white"></icon></a>' +
                                '<a class="lnkDeleteMember btn btn-danger btn-mini" href=\"/Admin/Member/Delete/' +
                                oObj.aData[4] + '\" ><icon class="icon-trash icon-white"></icon></a>';

                }

            }
            ]
    });

    //end DataTable Script

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addMemberDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Add": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addMemberForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add Member
    $('#lnkAddMember').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addMemberDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addMemberForm");
            // Unbind existing validation
            $form.unbind();
            $form.data("validator", null);
            // Check document for changes
            $.validator.unobtrusive.parse(document);
            // Re add validation with changes
            $form.validate($form.data("unobtrusiveValidation").options);
            //open dialog
            dialogDiv.dialog('open');
        });
        return false;

    });

    //edit Member
    $("#editMemberDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        closeOnEscape: false,
        modal: true,
        close: function (event, ui) {
            $(".popover").hide();
        },
        buttons: {
            "Edit": function () {
                //make sure there is nothing on the message before we continue   
                $("#updateTargetId").html('');
                $("#editMemberForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#memberDataTable tbody td a.lnkEditMember').live('click', function () {
        //$('#memberDataTable tbody td .lnkEditMember').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editMemberDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editMemberForm");
            // Unbind existing validation
            $form.unbind();
            $form.data("validator", null);
            // Check document for changes
            $.validator.unobtrusive.parse(document);
            // Re add validation with changes
            $form.validate($form.data("unobtrusiveValidation").options);
            //open dialog
            dialogDiv.dialog('open');
        });
        return false;

    });

    //delete Member
    $("#deleteMemberDailog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteMemberForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#memberDataTable tbody td a.lnkDeleteMember').live('click', function () {
        //$('#memberDataTable tbody td .lnkDeleteMember').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteMemberDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteMemberForm");
            // Unbind existing validation
            $form.unbind();
            $form.data("validator", null);
            // Check document for changes
            $.validator.unobtrusive.parse(document);
            // Re add validation with changes
            $form.validate($form.data("unobtrusiveValidation").options);
            //open dialog
            dialogDiv.dialog('open');
        });
        return false;

    });

    //For details Member
    $("#detailsMemberDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#memberDataTable tbody td a.lnkDetailsMember').live('click', function () {
        //$('#memberDataTable tbody td .lnkDetailsMember').on('click', 'a', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsMemberDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            dialogDiv.dialog('open');
        });
        return false;

    });

    //end Add, Edit, Delete - Dialog, Click Event
    //-------------------------------------------------------

});