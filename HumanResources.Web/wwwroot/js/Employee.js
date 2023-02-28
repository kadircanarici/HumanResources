
var _dataTable;
$(document).ready(function () {



    $("#txtEmail,#txtPhone").inputmask();

    loadTable();
});
function loadTable() {
    var dataTable = $("#dataTable").DataTable(
        {
            ajax: "/Employee/GetAll",
            columns: [
                { data: 'tc' },
                { data: 'firstName' },
                { data: 'lastName' },
                { data: 'email' },
                { data: 'phone' },


                {
                    data: 'isActive',
                    render: function (data, type) {
                        if (data) {
                            return `<p>Aktif Kullanıcı</p>`;
                        } else {
                            return `<p>İnaktif Kullanıcı</p>`;
                        }
                    }
                },
                {
                    data: 'id',
                    render: function (data, type) {
                        return `<a id="btnDelete-${data}" onClick="deleteEmployee('${data}')" class="btn btn-danger"> Sil </a> <a onClick="editEmployee('${data}')" class="btn btn-info">Düzenle</a> `;
                    }
                }

            ]
        }
    );
    _dataTable = dataTable;
}
function editEmployee(id) {
    window.location.href = "/Employee/Personal/?employeeId=" + id;
}

function deleteEmployee() {
    return;
}



function addEmployee() {
    $("#btnConfirm").off('click');

    $("#btnCancel").one('click', function (event) {
        $("#txtTC,#txtFirstName,#txtLastName,#txtEmail,#txtPhone").val('');

        $("#modal").modal('hide');
    });

    $("#btnConfirm").on('click', function (event) {

        var veri = {
            tc: $("#txtTC").val(),
            firstName: $("#txtFirstName").val(),
            lastName: $("#txtLastName").val(),
            email: $("#txtEmail").val(),
            phone: $("#txtPhone").val(),
            isActive: $("#selectIsActiveAdd option:selected").val()

            //XXXXX Datas gonna be send.
        };
        Swal.fire({
            title: 'Eklemek istediğinize emin misiniz?',
            icon: 'info',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Ekle',
            cancelButtonText: 'Iptal'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    data: veri,
                    url: "/Employee/Add",
                    success: function (res) {
                        $("#modal").modal('hide');
                        _dataTable.ajax.reload();
                        $("#txtTC").val('');
                        $("#txtFirstName").val('');
                        $("#txtLastName").val('');
                        $("#txtEmail").val('');
                        $("#txtPhone").val('');


                        toastr.success('Kullanıcı başarıyla eklendi.', 'EKLENDİ!');
                    }
                });
            } else {
                $("#txtTC").val('');
                $("#txtFirstName").val('');
                $("#txtLastName").val('');
                $("#txtEmail").val('');
                $("#txtPhone").val('');

                $("#modal").modal('hide');
            }
        });
    });
}


//function deleteEmployee(userId) {
//    Swal.fire({
//        title: 'Silmek istediğinizden emin misiniz?',
//        text: "Silinen verilerinizi kaybedeceksiniz!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'SİL',
//        cancelButtonText: 'İptal'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            var veri = {
//                id: userId
//            };
//            $.ajax({
//                type: "POST",
//                url: "@Url.Action("Delete","Employee")",
//                data: veri,
//                success: function (res) {
//                    // $("#btnDelete-" + res.id).parent().parent().remove();
//                    toastr.success('Kullanıcı başarıyla silindi.', 'SİLİNDİ!');
//                    _dataTable.ajax.reload();
//                }
//            });
//        }
//    });
//}
//function editEmployee(userId) {
//    $("#modalEdit").modal('show');

//    getEmployeeRoleNames("selectEmployeeRoleName");
//    var veri = {
//        id: userId
//        // DATAS GONNA BE SEND
//    };
//    $.ajax({
//        type: "POST",
//        url: "@Url.Action("FindById","Employee")",
//        data: veri,
//        success: function (res) {
//            console.log(res.phone);
//            $("#optEmployeeRoleName-" + res.appEmployeeRoleId).attr("selected", true);
//            $("#txtName").val(res.name);
//            $("#txtEmail").val(res.email);
//            $("#telPhone").val(res.phone);
//            $("#txtAppEmployeeName").val(res.userName);
//            if (res.isActive) {
//                $("#optActive").attr("selected", true);
//            } else { $("optInactive").attr("selected", true); }
//            $("btnConfirmEdit").off("click");
//            $("#btnCancelEdit").one('click', function (event) {
//                $("#modalEdit").modal('hide');

//                getEmployeeRoleNames("selectEmployeeRoleName");
//                $("#txtName").val();
//                $("#txtEmail").val();
//                $("#telPhone").val();
//                $("#txtAppEmployeeName").val();
//            });
//            $("#btnConfirmEdit").on('click', function (event) {
//                Swal.fire({
//                    title: 'Düzenlemek istediğinize emin misiniz?',
//                    text: "Düzenledikten sonra değişiklikleri geri alamazsınız!",
//                    icon: 'warning',
//                    showCancelButton: true,
//                    confirmButtonColor: '#3085d6',
//                    cancelButtonColor: '#d33',
//                    confirmButtonText: 'Düzenle',
//                    cancelButtonText: 'Iptal'
//                }).then((result) => {
//                    if (result.isConfirmed) {

//                        var veri = {
//                            id: res.id,
//                            name: $("#txtName").val(),
//                            email: $("#txtEmail").val(),
//                            phone: $("#telPhone").val(),
//                            userName: $("#txtAppEmployeeName").val(),
//                            appEmployeeRoleId: $("#selectEmployeeRoleName option:selected").val(),
//                            isActive: $("#selectIsActive option:selected").val()
//                            //DATAS GONNA BE SEND
//                        };
//                        $.ajax({
//                            type: "POST",
//                            url: "@Url.Action("Edit","Employee")",
//                            data: veri,
//                            success: function (resEdit) {
//                                toastr.success("Başarıyla Düzenlendi.", "DÜZENLENDİ!");
//                                _dataTable.ajax.reload();

//                                $("#modalEdit").modal('hide');
//                            }
//                        });
//                    }
//                    else {
//                        $("#txtName").val('');
//                        $("#txtEmail").val('');
//                        $("#telPhone").val('');
//                        $("#txtAppEmployeeName").val('');
//                        $("#modalEdit").modal('hide');

//                    }
//                });
//            });
//        }
//    });
//}
