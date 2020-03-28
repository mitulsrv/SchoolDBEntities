$(document).ready(function () {
    
    loadStandardData();

    $('#btnSave').on('click', function (event) {
        event.preventDefault();
        console.log($('#txtStandardName').val() + "   " + $('#txtDescription').val());
            $.ajax({
                url: 'http://localhost:54346/api/Standard',
                method: 'POST',
                data: {"StandardName": "" + $('#txtStandardName').val() + "", "Description": "" + $('#txtDescription').val() + ""},
                success: function (response) {
                    console.log(response);
                    if (response.Status) {
                        alert(response.Message);
                        loadStandardData();
                        document.getElementById("txtStandardName").value = "";
                        document.getElementById("txtDescription").value = "";
                    }
                }
            });
    });

    


    function loadStandardData() {
        
        $('#status').innerHTML = "Loading";
        $.ajax({
            url: "http://localhost:54346/api/Standard",
            method: "GET",
            success: function (response) {
                //console.log(response);
                if (response.Status) {
                    $('#jsonTable > tbody').empty();
                    var tr;
                    for (var i = 0; i < response.Standard.length; i++) {
                        tr = $('<tr/>');
                        tr.append('<td>' + response.Standard[i].StandardName + '</td>');
                        tr.append('<td>' + response.Standard[i].Description + '</td>');
                        tr.append('<td><input class="delete btn btn-danger" id="del_' + response.Standard[i].StandardId + '" type="button" value="Delete"></td>');
                        $('#jsonTable').append(tr);
                    }
                    $('#status').innerHTML = "Standards";
                } else {
                    alert(response.Message);
                }
            }
        });
    }
});