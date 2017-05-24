$.get("api/values/defaultvalues", function (data) {
    createForm(data);
});

function createForm(data) {
    var formElements = [
        {
            id: "numberOfPasswords",
            type: "number",
            label: "Number of passwords :",
            value: data.numberOfPasswords
        },
        {
            id: "passwordLength",
            type: "number",
            label: "Password length :",
            value: data.passwordLength
        },
        {
            id: "upperCase",
            type: "number",
            label: "Number of upper case letters :",
            value: data.upperCase
        },
        {
            id: "digits",
            type: "number",
            label: "Number of digits : ",
            value: data.digits
        },
        {
            id: "symbols",
            type: "number",
            label: "Number of symbols :",
            value: data.symbols
        },
        {
            id: "excludeSimilar",
            type: "checkbox",
            label: "Exclude similar characters",
            checked: data.excludeSimilar
        },
        {
            id: "excludeAmbigous",
            type: "checkbox",
            label: "Exclude ambigious characters",
            oninput: "validate()",
            checked: data.excludeAmbigous
        },
        {
            id: "generateBtn",
            type: "button",
            label: "",
            value: "Generate Password/s"
        }
    ];
    $("#formField").append(
        $("<form/>", {
            id: "myForm",
            className: "form"
        }).append(
            $("<div/>").append(
                $.map(formElements, function (element) {
                    return $("<div/>").append(
                        $("<label/>", {
                            for: element.id
                        }).text(element.label),
                        $("<input/>", element),
                        $("<label/>", {
                            id: element.id + "Warning",
                            style: "display:none;color:red"
                        }).text(
                            element.label + " must be greater than " + "(" + element.value + ")"
                            )
                    );
                })
            )
            )
    );
    $("#generateBtn").click(function () {
        if (validateForm()) {
            postRequest();
            $("#formField").empty();
            $("#formField").append(
                $("<div/>", {
                    class: "loader"
                })
            );
        }
    });
}
function validateForm(data) {
    var ok = true;
    if ($("#numberOfPasswords").val() < 1) {
        $("#numberOfPasswordsWarning").show();
        ok = false;
    }
    if ($("#passwordLength").val() < 8) {
        $("#passwordLengthWarning").show();
        ok = false;
    }
    if ($("#upperCase").val() < 0) {
        $("#numberOfPasswords").attr("value", 0);
    }
    if ($("#digits").val() < 0) {
        $("#numberOfPasswords").attr("value", 0);
    }
    if ($("#symbols").val() < 0) {
        $("#numberOfPasswords").attr("value", 0);
    } else {
        return ok;
    }
}

function postRequest() {
    var storedData = JSON.stringify({
        numberOfPasswords: $("#numberOfPasswords").val(),
        passwordLength: $("#passwordLength").val(),
        upperCase: $("#upperCase").val(),
        digits: $("#digits").val(),
        symbols: $("#symbols").val(),
        excludeSimilar: $("#excludeSimilar").is(":checked"),
        excludeAmbigous: $("#excludeAmbigous").is(":checked")
    });
    $.ajax({
        url: "api/values",
        type: "POST",
        dataType: "json",
        data: storedData,
        contentType: "application/json",
        success: function (result) {
            $("#formField").empty();
            $("#formField").append(
                $.map(result, function (element) {
                    return $("<p/>").text(element);
                }),
                $("<input/>", {
                    id: "backBtn",
                    type: "Button",
                    value: "Back"
                })
            );
            $("#backBtn").click(function () {
                $("#formField").empty();
                createForm(JSON.parse(storedData));
            });
        }
    });
}
