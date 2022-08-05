var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        //dom: 'Bfrtip',
        //buttons: [
        //    'copyHtml5',
        //    'excelHtml5',
        //    'csvHtml5',
        //    'pdfHtml5'
        //],
    });
}