function Delete(id) {
    //here i want to take delete the row with it specifc id ,

    $.ajax({
        type: "POST",
        url: '@Url.Action("Delete")',
        data: JSON.stringify({ Id: Id }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            // alert("Data has been deleted.");
           // LoadData();
        },
        error: function () {
            alert("Error while deleting data");
        }
    });
}

    function LoadData() {
        $("#tblStudent tbody tr").remove();
        $.ajax({
            type: 'POST',
            url: '@Url.Action("getStudent")',
            dataType: 'json',
            data: { id: '' },
            success: function (data) {
                var items = '';
                $.each(data, function (i, item) {
                    var rows = "<tr>"
                        + "<td class='prtoducttd' id='MovieID'>" + item.ID + "</td>"
                        + "<td class='prtoducttd'>" + item.Name + "</td>"
                        + "<td class='prtoducttd'>" + item.Type + "</td>"
                        + "<td class='prtoducttd'>" + item.date + "</td>"
                        + "<td class='prtoducttd'>" + "<input class='btn btn- primary'  name='submitButton' id='btnEdit' value='Edit'  onclick='delete' type='button'>" + "<input class='btn btn- primary' name='submitButton' id='btnDel' value='Delete' type='button'>" + "</td>"
                        + "</tr>";
                    $('#tblStudent tbody').append(rows);
                });
            }
        })
    };