var storedData;

function updateData() {
    storedData = {
        number: document.getElementById("numberOfPasswords").value,
        passwordLength: document.getElementById("passwordLength").value,
        upperCase: document.getElementById("upperCase").value,
        digits: document.getElementById("digits").value,
        symbols: document.getElementById("symbols").value,
        excludeSimilar: document.getElementById("excludeSimilar").checked,
        excludeAmbigious: document.getElementById("excludeAmbigious").checked
    };
}

function loadDefaultForm() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            var form = createForm(JSON.parse(this.responseText));
            document.getElementById("fieldset1").appendChild(form);
        }
    };
    xhttp.open("GET", "api/values/defaultvalues", true);
    xhttp.send();
}

function createForm(data) {
    var elements = [
        {
            id: "numberOfPasswords",
            label: "Number of passwords :",
            value: data.number
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
            isChecked: data.excludeSimilar
        },
        {
            id: "excludeAmbigious",
            type: "checkbox",
            label: "Exclude ambigious characters",
            isChecked: data.excludeAmbigious
        },
        {
            id: "generateBtn",
            type: "button",
            label: "",
            value: "Generate Password/s",
            onclick: "updateData();deleteChildren(form);loading();generatePassword(storedData)"
        }
    ];
    var form = e("form", { id: "myForm", className: "form" }, [
        e("div", null, elements.map(formElement))
    ]);
    return form;
}

function e(element, attrs, childArray) {
    var result = document.createElement(element);
    for (var key in attrs) {
        if (attrs[key] === undefined) {
            continue;
        }
        if (key === "isChecked") {
            result.checked = attrs[key];
        } else {
            result.setAttribute(key, attrs[key]);
        }
    }
    for (var child in childArray) {
        if (typeof childArray[child] === "string") {
            result.innerHTML = childArray[child];
        } else {
            result.appendChild(childArray[child]);
        }
    }
    return result;
}

function formElement(argument) {
    return e("div", null, [
        e("label", { for: argument.id }, [argument.label]),
        e("input", {
            id: argument.id,
            type: argument.type,
            value: argument.value,
            isChecked: argument.isChecked,
            onclick: argument.onclick
        })
    ]);
}

function generatePassword(data) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            var passwords = JSON.parse(this.responseText);
            var passwordsNodes = passwords.map(password => {
                return e("p", { class: "passwords" }, [password]);
            });
            var form = document.getElementById("myForm");
            showResults(form, passwordsNodes);
        }
    };
    xhttp.open("Post", "api/values", true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(data));
}

function deleteChildren(element) {
    while (element.hasChildNodes()) {
        element.removeChild(element.firstChild);
    }
}

function showResults(form, nodes) {
    deleteChildren(form);
    form.appendChild(
        e(
            "div",
            {
                className: "passwords",
                onload: "document.getElementByClassName('loader).display.style = none"
            },
            nodes
        )
    );
    form.appendChild(
        e("input", {
            type: "button",
            id: "btn",
            value: "Back",
            onclick: "deleteChildren(document.getElementById('fieldset1'));document.getElementById('fieldset1').appendChild(createForm(storedData))"
        })
    );
}

function loading() {
    var loader = e("div", { class: "loader" }, []);
    document.getElementById("myForm").appendChild(loader);
}
