export function OnLoad() {
    LoadForm();
}

function LoadForm() {
    const form = $('#form').dxForm({
        colCount: 2,
        formData: null,
        items: [{
            dataField: 'FirstName',
            editorOptions: {
                disabled: true,
            },
        }, {
            dataField: 'LastName',
            editorOptions: {
                disabled: true,
            },
        }, {
            dataField: 'HireDate',
            editorType: 'dxDateBox',
            editorOptions: {
                value: null,
                width: '100%',
            },
            validationRules: [{
                type: 'required',
                message: 'Hire date is required',
            }],
        }, {
            dataField: 'BirthDate',
            editorType: 'dxDateBox',
            editorOptions: {
                disabled: true,
                width: '100%',
            },
        }, 'Address', {
            colSpan: 2,
            dataField: 'Notes',
            editorType: 'dxTextArea',
            editorOptions: {
                height: 90,
            },
        }, {
            dataField: 'Phone',
            editorOptions: {
                mask: '+1 (X00) 000-0000',
                maskRules: { X: /[02-9]/ },
            },
        }
            , 'Email'
            , {
            itemType: 'button',
            horizontalAlignment: 'left',
            buttonOptions: {
                text: 'Register',
                type: 'success',
                useSubmitBehavior: true,
            },
        }
        ],
    }).dxForm('instance');
}
