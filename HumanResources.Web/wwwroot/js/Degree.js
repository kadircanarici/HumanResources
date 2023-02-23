
var dataTableDegree = $("#dtDegree").DataTable(
    {
        lengthChange: !1,
        buttons: ["copy", "excel", "pdf", "colvis"],
        ajax: "/Degree/GetAll",
        columns: [
            { data: 'name' },

            {
                data: 'id', render: function (data, type) {
                    return `<a onClick="deleteDegree('${data}')" class="btn btn-danger"> Sil </a> <a onClick="editDegree('${data}')" class="btn btn-info">Düzenle</a>`;
                }
            }

        ]
    }
);


$("#btnDegree").click(createDegree);
$("#btnDegree").text("Ekle");


//});
function createDegree() {

    var veri = {
        name: $("#txtDegree").val()
    }
    $.ajax({
        type: "POST",
        data: veri,
        url: "/Degree/Add",
        success: function (res) {

            toastr.success('Yeni Degree başarıyla eklenmiştir.', 'Başarılı !');
            dataTableDegree.ajax.reload();
            $("#txtDegree").val('');
        }
    });

};

function deleteDegree(id) {

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
                url: "/Degree/Delete",
                data: veri,
                success: function (res) {
                    dataTableDegree.ajax.reload();

                }
            });

            Swal.fire('Silindi!', '', 'success')
        }
    });
}

function editDegree(id) {


    var veri = { id: id }

    $.ajax({
        type: "POST",
        url: "/Degree/GetByID",
        data: veri,
        success: function (res) {
            $("#txtDegree").val(res.name);
            $("#btnDegree").text("Güncelle");
            $("#btnDegree").unbind();
            $("#btnDegree").click(function () {

                if ($("#txtDegree").val != res.name) {
                    veri =
                    {
                        id: id,
                        name: $("#txtDegree").val(),
                    }

                    $.ajax({
                        type: "POST",
                        url: "/Degree/Edit",
                        data: veri,
                        success: function (res) {
                            dataTableDegree.ajax.reload();
                            $("#txtDegree").val(""),
                                $("#btnDegree").text("Ekle");
                            toastr.success(' Degree başarıyla düzenlenmiştir.', 'Düzenlendi !');

                        }
                    })
                }
            })

        }
    })
}
