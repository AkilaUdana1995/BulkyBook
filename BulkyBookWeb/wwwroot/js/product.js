var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({

        "ajax": {
            "url": "/Admin/Product/GetAll"

        },

        "columns": [
            { data: "title", "width": "25%" },
            { data: "isbn", "width": "15%" },
            { data: "price", "width": "15%" },
            { data: "author", "width": "15%" },
            { data: "category.name", "width": "15%" },


          /* <button type="button">Can you click me?</button>*/
            {
                data: "id",
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary mx-1">
                                <i class="bi bi-pencil-square"></i>&nbsp;Edit me
                            </a>

                            <a onClick=Delete('/Admin/Product/Delete?id=${data}') class="btn btn-danger mx-1">

                                <i onClick=Delete('/Admin/Product/Delete?id=${data}') class="bi bi-trash"></i>&nbsp;Delete
                            </a>

                        </div>
                   `
                },
                "width": "20%"
            }
           
        ]

    });




    //var table = $('#myTable').DataTable({
    //    ajax: 'data.json',
    //    ajax: "url": "/Admin/Product/GetAll"
    //});

    //alert('Data source: ' + table.ajax.url());
    //alert('Data source: ' + dataTable.ajax.url());



    //$('#example').dataTable({
    //    "ajax": {
    //        "url": "data.json",
    //        "type": "POST"
    //    }
    //});
}


function Delete(url) {
    Swal.fire({
        title: 'Do you want to save the changes?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Save',
        denyButtonText: `Don't save`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toaster.success(data.message);
                    }

                    else {
                        toaster.error(data.message);
                    }
                }
            })
        } 
    })
}