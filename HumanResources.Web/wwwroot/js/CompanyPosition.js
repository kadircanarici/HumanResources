var dataTable = $("#datatable-buttons").DataTable(
    {
        lengthChange: !1,
        buttons: ["copy", "excel", "pdf", "colvis"],
        ajax: "/CompanyPosition/GetAll",
        columns: [

            { data: 'company.name' },
            { data: 'name' },


            {
                data: 'id', render: function (data, type) {
                    return `<a onClick="deleteCompanyPosition('${data}')" class="btn btn-danger"> Sil </a> <a id"editCompanyPosition" onClick="editCompanyPosition('${data}')" class="btn btn-info">Düzenle</a>`;
                }
            }

        ]
    }
);

//$("#datatable-buttons").dataTable().fnDestroy();

//new $.fn.dataTable.Buttons(dataTableCompany, {
//    buttons: ["copy", "excel", "pdf", "colvis"],

//});

//dataTableCompany.buttons().container()
//    .appendTo($('.col-sm-6:eq(0)', dataTableCompany.table().container()));


$("#yeniKayit").click(function () {
    $("#txtCompanyPosition").val(""),
        $(".form-select option:selected").val(0),
        $('#ddlCompany option[value="0"]').attr('selected', 'selected');

    $("#btnEkle").off();
    $("#btnEkle").click(createCompanyPosition);
    $("#btnEkle").text("Ekle");
    ddlDoldur();



});
function ddlDoldur() {
    $.ajax({
        type: "GET",
        url: "/Company/GetAll",
        success: function (res) {
            console.log(res);
            $("#ddlCompany").empty();
            $("#ddlCompany").append(`< option value = "0" > Select</option > `)
            for (item of res.data) {

                $("#ddlCompany").append(new Option(item.name, item.id))
            }
        }
    });
}
function createCompanyPosition() {


    var veri = {
        name: $("#txtCompanyPosition").val(),

        companyId: $(".form-select option:selected").val()

    }

    $.ajax({
        type: "POST",
        data: veri,
        url: "/CompanyPosition/Add",
        success: function (res) {
            $("#modal").modal('hide');
            toastr.success('Yeni CompanyPosition başarıyla eklenmiştir.', 'Başarılı !');
            dataTable.ajax.reload();
            $(".form-select option:selected").val(0);
            $("#txtCompanyPosition").val('');

        }
    });

};

function deleteCompanyPosition(id) {

    Swal.fire({
        title: 'Silmek istediginizden emin misiniz ?',
        showCancelButton: true,
        confirmButtonText: 'Evet'

    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {

            var veri = { id: id }

            $.ajax({
                type: "POST",
                url: "/CompanyPosition/Delete",
                data: veri,
                success: function (res) {
                    dataTable.ajax.reload();

                }
            });

            Swal.fire('Silindi!', '', 'success')
        }
    });
}
function editCompanyPosition(id) {
    $("#editCompanyPosition").off();
    $("#modal").modal('show');
    ddlDoldur();


    var veri = { id: id }

    $.ajax({
        type: "POST",
        url: "/CompanyPosition/GetByID",
        data: veri,
        success: function (res) {
            console.log(res.id);
            $("#txtCompanyPosition").val(res.name);


            $("#ddlCompany option[value='" + res.companyId + "']").attr('selected', 'selected');

            // console.log($("#ddlCompany option[value='" + res.id + "']"));

            $("#btnEkle").text("Güncelle");
            $("#btnEkle").off();
            $("#btnEkle").click(function () {
                veri =
                {
                    id: id,
                    name: $("#txtCompanyPosition").val(),


                    companyId: $(".form-select option:selected").val(),

                }

                $.ajax({
                    type: "POST",
                    url: "/CompanyPosition/Edit",
                    data: veri,
                    success: function (res) {
                        dataTable.ajax.reload();
                        $("#modal").modal('hide');
                        toastr.success(' CompanyPosition başarıyla düzenlenmiştir.', 'Düzenlendi !');

                    }
                })


            })

        }
    })
}



