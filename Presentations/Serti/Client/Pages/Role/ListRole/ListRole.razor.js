export function OnLoad(url) {
    LoadData(url);
}



function LoadData(url) {

    var form = {
        items: [
            {
                itemType: 'group',
                colCount: 2,
                colSpan: 2,
                items: [
                    {
                        dataField: 'roleName',
                        editorType: 'dxTextBox',
                        validationRules: [{ type: 'required' }],
                    }
                ],
            },

            {
                itemType: 'group',
                caption: 'Menu',
                colCount: 2,
                colSpan: 2,
                items: [
                    {
                        dataField: 'roleName',
                        editorType: 'dxTextBox',
                        validationRules: [{ type: 'required' }],
                    }
                ],
            }
        ],
    };


    var columns = [
        {
            type: 'buttons',
            buttons: ['edit', 'delete'],
        }
        , {
            dataField: 'roleName',
        }
    ];

    var toolbar = {
        items: [
            {
                name: "addRowButton",
                location: 'after',
                widget: 'dxButton',
                options: {
                    //icon: 'refresh',
                    onClick() {
                        window.location.href = "/role/create";
                    },
                },
            },
        ],
    };

    var gridRole = DX_DataGrid_Buider({ _url: url, _columns: columns, _target: '#grid-role', _toolbar: toolbar});
}
