
$.fn.dataTable.ext.search.push(function (settings, data, dataIndex) {
    var selectedDate = document.getElementById('dateChange').value;
    var item = new Date(data[4]);
    var month = (item.getMonth()+1).toString();
    var day = item.getDay().toString();
    if (month < 10) {
        month = "0" + month;
    }
    if (day < 10) {
        day = "0" + day;
    }
    var listDate = item.getFullYear() + "-" + month + "-" + day;
    if (selectedDate === "" || selectedDate === listDate)
        return true;
    else
        return false;
});





$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    var table = $('#myTable').DataTable({
        //dom: 'Bfrtip',
        //buttons: [
        //    'copyHtml5',
        //    'excelHtml5',
        //    'csvHtml5',
        //    'pdfHtml5'
        //],
    });
    $('#dateChange').on('change', function () {
        table.draw();
    });
}

