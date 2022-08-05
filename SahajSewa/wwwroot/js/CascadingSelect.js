$(document).ready(function () {
    PermanentAddress();
    TemporaryAddress();
    OfficeAddress();
    Category();
    IssueDistrict();
    
    $('#Pdistrict').attr('disabled', true);
    $('#Pvillage').attr('disabled', true);
    $('#Tdistrict').attr('disabled', true);
    $('#Tvillage').attr('disabled', true);
    $('#Oname').attr('disabled', true);

    $('#Pprovince').change(function () {
        var id = $(this).val();
        $('#Pvillage').attr('disabled', true);
        $('#Pdistrict').attr('disabled', false);
        $('#Pdistrict').empty();
        $('#Pdistrict').append('<option disabled selected>-- Select District --</option>');
        $('#Pvillage').empty();
        $('#Pvillage').append('<option disabled selected>-- Select Village --</option>');
        $.ajax({
            url: '/Users/LicenseRegistration/Pdistrict?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Pdistrict').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
        });
    });

    $('#Pdistrict').change(function () {
        $('#Pvillage').attr('disabled', false);
        var id = $(this).val();
        $('#Pvillage').empty();
        $('#Pvillage').append('<option disabled selected>-- Select Village --</option>');
        $.ajax({
            url: '/Users/LicenseRegistration/Pvillage?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Pvillage').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
        });
    });

    $('#Tprovince').change(function () {
        var id = $(this).val();
        $('#Tvillage').attr('disabled', true);
        $('#Tdistrict').attr('disabled', false);
        $('#Tdistrict').empty();
        $('#Tdistrict').append('<option disabled selected>-- Select District --</option>');
        $('#Tvillage').empty();
        $('#Tvillage').append('<option disabled selected>-- Select Village --</option>');
        $.ajax({
            url: '/Users/LicenseRegistration/Pdistrict?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Tdistrict').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
        });
    });

    $('#Tdistrict').change(function () {
        $('#Tvillage').attr('disabled', false);
        var id = $(this).val();
        $('#Tvillage').empty();
        $('#Tvillage').append('<option disabled selected>-- Select Village --</option>');
        $.ajax({
            url: '/Users/LicenseRegistration/Pvillage?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Tvillage').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
        });
    });

    $('#Oprovince').change(function () {
        var id = $(this).val();
        $('#Oname').attr('disabled', false);
        $('#Oname').empty();
        $('#Oname').append('<option disabled selected>-- Select Office --</option>');
        $.ajax({
            url: '/Users/LicenseRegistration/Oname?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Oname').append('<option value=' + data.id + '> Transport Management Office - ' + data.name + '</option>');
                });
            }
        });
    });

});

function PermanentAddress() {
    $.ajax({
        url: '/Users/LicenseRegistration/Pprovince',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Pprovince').append('<Option value=' + data.id + '> ' + data.name + ' </Option>');
            });
        }
    });
}

function TemporaryAddress() {
    $.ajax({
        url: '/Users/LicenseRegistration/Pprovince',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Tprovince').append('<Option value=' + data.id + '> ' + data.name + ' </Option>');
            });
        }
    });
}

function OfficeAddress() {
    $.ajax({
        url: '/Users/LicenseRegistration/Pprovince',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Oprovince').append('<Option value=' + data.id + '> ' + data.name + ' </Option>');
            });
        }
    });
}


function Category() {
    $.ajax({
        url: '/Users/LicenseRegistration/Category',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Category').append('<Option value=' + data.id + '> ' +data.symbol+'-('+data.name+')'+ '</Option>');
            });
        }
    });
}


function IssueDistrict() {
    $.ajax({
        url: '/Users/LicenseRegistration/Idistrict',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Idistrict').append('<Option value=' + data.id + '> ' + data.name + ' </Option>');
            });
        }
    });
}