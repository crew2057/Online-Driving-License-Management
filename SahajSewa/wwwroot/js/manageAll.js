
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
    //window.location.href = '/Admin/ManageAll/Approval/' + d.applicantId;
    return (
        '<div>' +
        '<a href="/Users/Home/Userdetails/' + d.applicantId+'" class="btn btn-dark col-2 mx-5">Details</a>' +
        '<a href="/Admin/ManageAll/Approval/' + d.applicantId +'" class="btn btn-dark col-2">Approve</button>' +
        '</div>'
    );
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
            { data:'approved'},
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
        if (row.data().id == 1) {
            tr.removeClass('dt-control');
        }
    });

    $('#myTable tbody').on('click', 'td.dt-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);
        if(row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        } else {
            // Open this row
            row.child(format(row.data())).show();
            tr.addClass('shown');
        }
    });
}

