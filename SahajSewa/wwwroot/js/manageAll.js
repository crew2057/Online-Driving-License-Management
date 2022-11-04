
$.fn.dataTable.ext.search.push(function (settings, data, dataIndex) {
    var selectedDate = document.getElementById('dateChange').value;
    var item = new Date(data[4]);
    var month = (item.getMonth()+1).toString();
    var day = item.getDate().toString();
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

function format(d) {    
    // `d` is the original data object for the row
    window.location.href = '/Admin/ManageAll/Approval/' + d.applicantId;
    //return (
    //    '<button onclick="ApproveDetail(' + d.applicantId + ')" >Approve</button>'
    //);
}

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    var table = $('#myTable').DataTable({
        columns: [
            {
                className: 'dt-control',
                orderable: false,
                data: null,
                defaultContent: '',
            },
            { data: 'id' },
            { data: 'applicantId' },
            { data: 'email' },
            { data: 'username' },
            { data: 'registrationDate' },
            { data: 'writtenResult' },
            { data: 'trailCount' },
            { data: 'trailResult' },
        ],
        order: [[1, 'asc']],
    });
    $('#dateChange').on('change', function () {
        table.draw();
    });

    $('#myTable tbody').on('click', 'td.dt-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            row.child.hide();
            tr.removeClass('shown');
        } else {
            row.child(format(row.data())).show();
            tr.addClass('shown');
        }
    });
}

