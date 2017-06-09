let passwordOptions = {};
let passwords = [];

let generate = () =>
    fetch("api/values", {
        method: "post",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(passwordOptions)
    }).then(response =>
        response.json().then(data => {
            let response = [];
            response = data.map(d => d);
            passwords = response;
            render();
        })
        );

let Form = props => {
    return React.createElement("div", null, [
        React.createElement("label", { key: "numberOfPassLabel" }, [
            "Number of passwords : ",
            React.createElement("input", {
                key: "numberOfPassInput",
                type: "number",
                value: props.options.numberOfPasswords,
                onChange: event => {
                    props.options.numberOfPasswords = event.target.value;
                    render();
                    generate();
                }
            })
        ]),
        React.createElement("label", { key: "passLengthLabel" }, [
            "Password length :",
            React.createElement("input", {
                key: "passLengthInput",
                type: "number",
                value: props.options.passwordLength,
                onChange: event => {
                    props.options.passwordLength = event.target.value;
                    render();
                    generate();
                }
            })
        ]),
        React.createElement("label", { key: "upperCaseLabel" }, [
            "Number of upper case characters : ",
            React.createElement("input", {
                key: "upperCaseInput",
                type: "number",
                value: props.options.upperCase,
                onChange: event => {
                    props.options.upperCase = event.target.value;
                    render();
                    generate();
                }
            })
        ]),
        React.createElement("label", { key: "digitsLabel" }, [
            "Number of digits :",
            React.createElement("input", {
                key: "digitsInput",
                type: "number",
                value: props.options.digits,
                onChange: event => {
                    props.options.digits = event.target.value;
                    render();
                    generate();
                }
            })
        ]),
        React.createElement("label", { key: "symbolsLabel" }, [
            "Number of symbols : ",
            React.createElement("input", {
                key: "symbolsInput",
                type: "number",
                value: props.options.symbols,
                onChange: event => {
                    props.options.symbols = event.target.value;
                    render();
                    generate();
                }
            })
        ]),
        React.createElement("label", { key: "excludeSimilarLabel" }, [
            "Exclude similar characters :",
            React.createElement("input", {
                key: "excludeSimilarInput",
                type: "checkbox",
                defaultChecked: props.options.excludeSimilar,
                onChange: event => {
                    props.options.excludeSimilar = event.target.checked;
                    render();
                    generate();
                }
            })
        ]),
        React.createElement("label", { key: "excludeAmbigousLabel" }, [
            "Exclude ambigous characters :",
            React.createElement("input", {
                key: "excludeAmbigousInput",
                type: "checkbox",
                defaultChecked: props.options.excludeAmbigous,
                onChange: event => {
                    props.options.excludeAmbigous = event.target.checked;
                    render();
                    generate();
                }
            })
        ]),
        React.createElement("input", {
            key: "buttonInput",
            type: "button",
            value: "Generate password/s",
            onClick: event => {
                generate();
            }
        }),
        React.createElement(
            "div",
            { key: "passwords" },
            passwords.map(p => React.createElement("p", { key: p }, p))
        )
    ]);
};

let render = () =>
    ReactDOM.render(
        React.createElement(Form, { options: passwordOptions }, null),
        document.getElementById("root")
    );

fetch("api/values/defaultvalues").then(response =>
    response.json().then(data => {
        passwordOptions = data;
        render();
    })
);
