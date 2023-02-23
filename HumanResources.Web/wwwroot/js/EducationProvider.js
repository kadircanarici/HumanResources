var dataTableEducationProvider = $("#dtEducationProvider").DataTable(
    {
        lengthChange: !1,
        buttons: ["copy", "excel", "pdf", "colvis"],
        ajax: "/EducationProvider/GetAll",
        columns: [
            { data: 'name' },
       
            {
                data: 'id', render: function (data, type) {
                    return `<a onClick="deleteEducationProvider('${data}')" class="btn btn-danger"> Sil </a> <a onClick="editEducationProvider('${data}')" class="btn btn-info">Düzenle</a>`;
                }
            }

        ]
    }
);


    $("#btnEducationProvider").click(createEducationProvider);
    $("#btnEducationProvider").text("Ekle");


//});
function createEducationProvider() {

    var veri = {
        name: $("#txtEducationProvider").val()
    }
    $.ajax({
        type: "POST",
        data: veri,
        url: "/EducationProvider/Add",
        success: function (res) {
            dataTableEducationProvider.ajax.reload();

            toastr.success('Yeni EducationProvider başarıyla eklenmiştir.', 'Başarılı !');
            $("#txtEducationProvider").val('');
        }
    });

};

function deleteEducationProvider(id) {

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
                url: "/EducationProvider/Delete",
                data: veri,
                success: function (res) {
                    dataTableEducationProvider.ajax.reload();

                }
            });

            Swal.fire('Silindi!', '', 'success')
        }
    });
}

function editEducationProvider(id) {

  
    var veri = { id: id }

    $.ajax({
        type: "POST",
        url: "/EducationProvider/GetByID",
        data: veri,
        success: function (res) {
            $("#txtEducationProvider").val(res.name);
            $("#btnEducationProvider").text("Güncelle");
            $("#btnEducationProvider").unbind();
            $("#btnEducationProvider").click(function () {

                if ($("#txtEducationProvider").val != res.name) {
                    veri =
                    {
                        id: id,
                        name: $("#txtEducationProvider").val(),
                    }

                    $.ajax({
                        type: "POST",
                        url: "/EducationProvider/Edit",
                        data: veri,
                        success: function (res) {
                            dataTableEducationProvider.ajax.reload();
                            $("#txtEducationProvider").val(""),
                                $("#btnEducationProvider").text("Ekle");
                            toastr.success(' EducationProvider başarıyla düzenlenmiştir.', 'Düzenlendi !');

                        }
                    })
                }
            })

        }
    })
}
