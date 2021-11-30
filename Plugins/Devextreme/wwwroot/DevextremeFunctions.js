window.DevextremeFunctions = {
	DataGrid: function (target, url, key, columns) {
        $(target).dxDataGrid({
            dataSource: DevExpress.data.AspNet.createStore({
                key: key,
                loadUrl: url,
                onBeforeSend(method, ajaxOptions) {
                    ajaxOptions.xhrFields = { withCredentials: true };
                },
            }),
            keyExpr: key,
            columns: columns,
        });
	},

	
}
