function getquestions(val) {
    var ques = null;
    if (val == "next") {
        ques = parseInt($("#questionnumber").val())+1;
    }
    else{
        ques = parseInt($("#questionnumber").val()) - 1;
    }
    $.ajax({
        type: "GET",
        url: "/Home/Questions",
        data: { question: ques },
        success: function (data) {
            var obj = jQuery.parseJSON(data);
            if (obj.length>0) {
                $.each(obj, function (index, val) {

                    $("#area").val(val.area);
                    $("#sec").val(val.section);
                    $("#subsec").val(val.subsection);
                    $("#point").html(val.question);
                    $("#questionnumber").val(val.id);
                    if (val.id > 1) {
                        $("#pre").show();
                        $("#next").show();
                    } else {
                        $("#pre").hide();
                    }
                    
                });
                
            }
            else {
                alert("No data found")
                $("#next").hide();
            }
        },
    });

}