$(document).ready(function () {
    var t = $('#myTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            { extend: 'excel', text: 'Download List' },
            {
                extend: 'searchBuilder', config: {
                    columns: [5],
                    preDefined: {
                        criteria: [
                            {
                                condition: '=',
                                data: 'Categories',
                            },
                            {
                                condition: '=',
                                data: 'Categories',
                            },
                            {
                                condition: '=',
                                data: 'Categories',
                            }
                        ],
                        logic:'OR'
                    }

                },
                targets: [5]
            }
        ],
        language: {
            searchBuilder: {
                button: 'Filter',
                delete: 'Delete',
            }
        },

        columnDefs: [
            {
                searchable: false,
                orderable: false,
                targets: 0,
            },
        ],
        order: [[1, 'asc']],
    });

    t.on('order.dt search.dt', function () {
        let i = 1;

        t.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();
});