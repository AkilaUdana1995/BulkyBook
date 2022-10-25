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