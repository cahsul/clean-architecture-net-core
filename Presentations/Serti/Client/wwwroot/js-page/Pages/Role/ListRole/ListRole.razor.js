function OnLoad(url) {
  LoadData(url);
}

function LoadData(url) {
  var columns = [{
    type: 'buttons',
    buttons: ['edit', 'delete']
  }, {
    dataField: 'roleName'
  }];
  var toolbar = {
    items: [{
      name: "addRowButton",
      location: 'after',
      widget: 'dxButton',
      options: {
        //icon: 'refresh',
        onClick() {
          window.location.href = "/role/create";
        }

      }
    }]
  };
  DX_DataGrid_Buider({
    _url: url,
    _columns: columns,
    _target: '#grid-role',
    _toolbar: toolbar
  });
}

export { OnLoad };
