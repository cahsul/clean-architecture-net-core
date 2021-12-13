DevExpress.ui.dxDataGrid.defaultOptions({
    device: { deviceType: "desktop" },
    options: {
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        sorting: {
            mode: 'multiple',
        },
        editing: {
            mode: 'popup',
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
        },

        filterRow: { visible: true },
        filterPanel: { visible: true },
        headerFilter: { visible: true },

    }
});

DevExpress.ui.dxTreeList.defaultOptions({
    device: { deviceType: "desktop" },
    options: {
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        sorting: {
            mode: 'multiple',
        },
        editing: {
            mode: 'popup',
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
        },


        filterRow: { visible: true },
        filterPanel: { visible: true },
        headerFilter: { visible: true },


        onDataErrorOccurred: (e) => {
            let message = e.error.message;
            setTimeout(() => {
                let errorRow = document.querySelector(".dx-error-message");
                errorRow.innerHTML = message;
            });
        }

    }
})


function DX_CustomStore(url, key) {
    const ordersStore = new DevExpress.data.CustomStore({
        key: key,
        load() {
            return DX_SendRequest(url);
        },
        insert(values) {
            return DX_SendRequest(url, 'POST', values);
        },
        //update(key, values) {
        //    return sendRequest(`${URL}/UpdateOrder`, 'PUT', {
        //        key,
        //        values: JSON.stringify(values),
        //    });
        //},
        remove(key) {
            return DX_SendRequest(url, 'DELETE', {
                id: key,
            });
        },
    });

    return ordersStore;
}

function DX_CustomStore_Raw(url, key) {
    const ordersStore = new DevExpress.data.CustomStore({
        loadMode: 'raw',
        key: key,
        load() {
            return DX_SendRequest(url);
        },
    });

    return ordersStore;
}

function DX_SendRequest(url, method = 'GET', data) {
    const d = $.Deferred();


    $.ajax(url, {
        method,
        data: data,
        cache: false,
        headers: {
            'Accept-Language': (localStorage.getItem("culture")).replace("\"", "").replace("\"", ""), // es-ES
        },
        xhrFields: { withCredentials: true },
    }).done((result) => {
        d.resolve(method === 'GET' ? result.data : result);
    }).fail((xhr) => {

        if (!xhr.hasOwnProperty('responseJSON')) {
            d.reject(xhr.statusText);
            return d.promise();
        }

        if (xhr.responseJSON.errorType == "Unauthenticated") {
            window.location.href = "/login";
        }

        // build error agar bisa per baris
        var errorBuilder = xhr.responseJSON.errorsMessage.map(function (val) {
            return " <li>" + val + "</li>";
        }).join('');

        errorBuilder = "<ul>" + errorBuilder + "</ul>";

        d.reject(xhr.responseJSON ? errorBuilder : xhr.statusText);
    });

    return d.promise();
}

function getFormData(object) {
    const formData = new FormData();
    Object.keys(object).forEach(key => formData.append(key, object[key]));
    return formData;
}



//function DX_DataGrid_Buider(_url, _target, _form, _columns) {
function DX_DataGrid_Buider({ _url = null, _target = null, _form = null, _columns = null, _toolbar = null }) {

    const dataGrid = $(_target).dxDataGrid({
        dataSource: DX_CustomStore(_url, 'id'),
        autoExpandAll: true,

        toolbar: _toolbar,

        editing: {
            form: _form,
        },
        keyExpr: 'id',
        parentIdExpr: 'parentId',
        columns: _columns,
        onInitialized: function (e) {
            $treeList = e.component;
        },


    });

}

function DX_TreeList_Buider(url, target, form, columns) {
    var $treeList = undefined;

    $(target).dxTreeList({
        dataSource: DX_CustomStore(url, 'id'),
        autoExpandAll: true,
        editing: {
            form: form,
        },
        keyExpr: 'id',
        parentIdExpr: 'parentId',
        columns: columns,
        onInitialized: function (e) {
            $treeList = e.component;
        },


    });

    return $treeList;
}



// form
function DX_Form_Input(target) {
    $(target).dxTextBox({
        value: 'San Diego',
    });
}