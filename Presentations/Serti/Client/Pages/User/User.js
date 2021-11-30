
export function OnAfterRender(url) {


    //DotNet.invokeMethodAsync('Serti.Client', 'JStoCSCall');
    LoadData(url);

}



function LoadData(url) {
    $('#userTable').dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: 'id',
            loadUrl: url,
            insertUrl: `${url}/InsertOrder`,
            updateUrl: `${url}/UpdateOrder`,
            deleteUrl: `${url}/DeleteOrder`,
            onBeforeSend(method, ajaxOptions) {
                ajaxOptions.xhrFields = { withCredentials: true };
            },
        }),
        editing: {
            refreshMode: 'reshape',
            mode: 'cell',
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
        },
        keyExpr: 'id',
        columns: ['email'],
    });
}

