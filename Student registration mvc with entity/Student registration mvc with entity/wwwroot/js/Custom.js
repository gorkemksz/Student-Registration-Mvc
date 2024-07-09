$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '/Students/ListAjax',
        dataType: 'json',
        success: function (data) {
            var tableContent = '';
            $.each(data, function (index, item) {
                var row =
                    '<tr>' +
                    '<td>' + item.Id + '</td>' +
                    '<td>' + item.Name + '</td>' +
                    '<td>' + item.Surname + '</td>' +
                    '<td>' + item.Email + '</td>' +
                    '<td>' + item.PhoneNumber + '</td>' +
                    '<td>' + item.StudentId + '</td>' +
                    '<td>' + item.DateOfBirth + '</td>' +
                    '</tr>';

                    tableContent += row          
            });
             $('#tabledata').html(tableContent);
        },
        error: function (error) {
            alert("Hata oluştu. Veriler yüklenemedi.");
        }
    });
});


