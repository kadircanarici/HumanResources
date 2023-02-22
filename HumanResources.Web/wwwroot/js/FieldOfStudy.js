var dataTable = $("#dtFieldOfStudy").DataTable(
    {
        lengthChange: !1,
        buttons: ["copy", "excel", "pdf", "colvis"],
        ajax: "/FieldOfStudy/GetAll",
        columns: [
            { data: 'name' },

            {
                data: 'id', render: function (data, type) {
                    return `<a onClick="deleteFieldOfStudy('${data}')" class="btn btn-danger"> Sil </a> <a onClick="editFieldOfStudy('${data}')" class="btn btn-info">Düzenle</a>`;
                }
            }

        ]
    }
);


$("#btnFieldOfStudy").click(createFieldOfStudy);
$("#btnFieldOfStudy").text("Ekle");


//});
function createFieldOfStudy() {

    var veri = {
        name: $("#txtFieldOfStudy").val()
    }
    $.ajax({
        type: "POST",
        data: veri,
        url: "/FieldOfStudy/Add",
        success: function (res) {

            toastr.success('Yeni FieldOfStudy başarıyla eklenmiştir.', 'Başarılı !');
            dataTable.ajax.reload();
            $("#txtFieldOfStudy").val('');
        }
    });

};

function deleteFieldOfStudy(id) {

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
                url: "/FieldOfStudy/Delete",
                data: veri,
                success: function (res) {
                    dataTable.ajax.reload();

                }
            });

            Swal.fire('Silindi!', '', 'success')
        }
    });
}

function editFieldOfStudy(id) {


    var veri = { id: id }

    $.ajax({
        type: "POST",
        url: "/FieldOfStudy/GetByID",
        data: veri,
        success: function (res) {
            $("#txtFieldOfStudy").val(res.name);
            $("#btnFieldOfStudy").text("Güncelle");
            $("#btnFieldOfStudy").unbind();
            $("#btnFieldOfStudy").click(function () {

                if ($("#txtFieldOfStudy").val != res.name) {
                    veri =
                    {
                        id: id,
                        name: $("#txtFieldOfStudy").val(),
                    }

                    $.ajax({
                        type: "POST",
                        url: "/FieldOfStudy/Edit",
                        data: veri,
                        success: function (res) {
                            dataTable.ajax.reload();
                            $("#txtFieldOfStudy").val(""),
                                $("#btnFieldOfStudy").text("Ekle");
                            toastr.success(' FieldOfStudy başarıyla düzenlenmiştir.', 'Düzenlendi !');

                        }
                    })
                }
            })

        }
    })
}
