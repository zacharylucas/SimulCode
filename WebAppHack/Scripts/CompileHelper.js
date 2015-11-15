$(function (){
    $("#comp_button").click(function () {
        var docData = $("#text_area_1").val();
        alert(docData);
        $.ajax({
            url: "Compile",
            type: 'POST',
            data: { docDataIn: docData },
            success: function (result) {
                $("#text_area_2").val(result.compiled); 
            },
 
            error: function () {
                alert("Something didn't quite work :(");
            }
        });
    });
});

