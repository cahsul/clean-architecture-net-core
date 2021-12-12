function OnAfterRender(url) {
  //DotNet.invokeMethodAsync('Serti.Client', 'JStoCSCall');
  LoadData(url); //alert("asdasdas");
}

function LoadData(url) {
  let treeView;

  const syncTreeViewSelection = function (treeViewInstance, value) {
    if (!value) {
      treeViewInstance.unselectAll();
    } else {
      treeViewInstance.selectItem(value);
    }
  };

  var form = {
    items: [{
      itemType: 'group',
      colCount: 2,
      colSpan: 2,
      items: [{
        dataField: 'label',
        editorType: 'dxTextBox',
        validationRules: [{
          type: 'required'
        }]
      }, {
        dataField: 'menuKey',
        editorType: 'dxTextBox',
        validationRules: [{
          type: 'required'
        }]
      }, {
        dataField: 'url',
        editorType: 'dxTextBox',
        validationRules: [{
          type: 'required'
        }]
      }, {
        dataField: 'parentId',
        editorType: 'dxDropDownBox',
        editorOptions: {
          value: '1_1',
          valueExpr: 'id',
          displayExpr: 'label',
          placeholder: 'Select a value...',
          showClearButton: true,
          dataSource: DX_CustomStore_Raw(url, 'id'),

          contentTemplate(e) {
            const value = e.component.option('value');
            const $treeView = $('<div>').dxTreeView({
              dataSource: e.component.getDataSource(),
              dataStructure: 'plain',
              keyExpr: 'id',
              parentIdExpr: 'parentId',
              selectionMode: 'single',
              displayExpr: 'label',
              selectByClick: true,

              onContentReady(args) {
                syncTreeViewSelection(args.component, value);
              },

              selectNodesRecursive: false,

              onItemSelectionChanged(args) {
                const selectedKeys = args.component.getSelectedNodeKeys();
                e.component.option('value', selectedKeys);
              }

            });
            treeView = $treeView.dxTreeView('instance');
            e.component.on('valueChanged', args => {
              syncTreeViewSelection(treeView, args.value);
              e.component.close();
            });
            return $treeView;
          }

        }
      }, {
        dataField: 'menuAction',
        editorType: 'dxTagBox',
        editorOptions: {
          items: ['List', 'Create', 'Update', 'Delete'],
          searchEnabled: true,
          showSelectionControls: true,
          applyValueMode: 'useButtons'
        }
      }]
    }]
  };
  var columns = [{
    type: 'buttons',
    buttons: ['edit', 'delete']
  }, {
    dataField: 'menuKey' //caption: "menuKey",
    //width: 170,

  }, {
    dataField: 'label' //caption: "MenuName",
    //width: 170,

  }, {
    dataField: 'url' //caption: "MenuName",
    //width: 170,

  }, {
    dataField: 'menuAction' //caption: "MenuName",
    //width: 170,

  }, {
    dataField: 'parentId',
    visible: false
  }];
  DX_TreeList_Buider(url, '#listMenu', form, columns);
}

export { OnAfterRender };
