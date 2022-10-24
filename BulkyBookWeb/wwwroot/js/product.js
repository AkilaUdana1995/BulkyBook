var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        ajax: {
            url:"/Admin/Product/GetAll"
        },
        ajax: 'data/objects.txt',

        "columns": [
            { data: "title"},
            { data: "isbn"},
            { data: "price"},
            { data: "author"},

        ]

    });

    alert('Data source: ' + dataTable.ajax.url());


    //var table = $('#myTable').DataTable({
    //    ajax: 'data.json',
    //    ajax: "url": "/Admin/Product/GetAll"
    //});

    //alert('Data source: ' + table.ajax.url());
    //alert('Data source: ' + dataTable.ajax.url());
}