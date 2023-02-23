
var dataTableCompany = $("#datatable-buttons").DataTable(
    {
        lengthChange: !1,
        ajax: "/Company/GetAll",
        columns: [
            { data: 'name' },

            {
                data: 'id', render: function (data, type) {
                    return `<a onClick="deleteCompany('${data}')" class="btn btn-danger"> Sil </a> <a onClick="editCompany('${data}')" class="btn btn-info">Düzenle</a>`;
                }
            }

        ]
    }
);

new $.fn.dataTable.Buttons(dataTableCompany, {
    buttons: ["copy", "excel", "pdf", "colvis"],

});

dataTableCompany.buttons().container()
    .appendTo($('.col-sm-6:eq(0)', dataTableCompany.table().container()));


$("#btnCompany").click(createCompany);
$("#btnCompany").text("Ekle");


//});
function createCompany() {

    var veri = {
        name: $("#txtCompany").val()
    }
    $.ajax({
        type: "POST",
        data: veri,
        url: "/Company/Add",
        success: function (res) {

            toastr.success('Yeni Company başarıyla eklenmiştir.', 'Başarılı !');
            dataTableCompany.ajax.reload();
            $("#txtCompany").val('');
        }
    });

};

function deleteCompany(id) {

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
                url: "/Company/Delete",
                data: veri,
                success: function (res) {
                    dataTableCompany.ajax.reload();

                }
            });

            Swal.fire('Silindi!', '', 'success')
        }
    });
}

function editCompany(id) {


    var veri = { id: id }

    $.ajax({
        type: "POST",
        url: "/Company/GetByID",
        data: veri,
        success: function (res) {
            $("#txtCompany").val(res.name);
            $("#btnCompany").text("Güncelle");
            $("#btnCompany").unbind();
            $("#btnCompany").click(function () {

                if ($("#txtCompany").val != res.name) {
                    veri =
                    {
                        id: id,
                        name: $("#txtCompany").val(),
                    }

                    $.ajax({
                        type: "POST",
                        url: "/Company/Edit",
                        data: veri,
                        success: function (res) {
                            dataTableCompany.ajax.reload();
                            $("#txtCompany").val(""),
                                $("#btnCompany").unbind();

                                $("#btnCompany").click(createCompany);
                            $("#btnCompany").text("Ekle");
                            toastr.success(' Company başarıyla düzenlenmiştir.', 'Düzenlendi !');

                        }
                    })
                }
            })

        }
    })
}
