function OnValueChanged(s, fieldName, keyValue, url) {
    $.ajax({
        type: "POST",
        url: url,
        data: { key: keyValue, field: fieldName, value: s.GetValue() },
        beforeSend: function () {
            $(".status").text("Request has been sent");
        },
        success: function (msg) {
            $(".status").html(msg);
        }
    });
}