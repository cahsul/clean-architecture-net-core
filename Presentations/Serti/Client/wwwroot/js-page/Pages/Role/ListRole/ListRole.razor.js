function OnLoad(url) {
  LoadData(url);
  LoadForm();
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
} // load popup form


function LoadForm() {
  // popup 
  $('#popup-form').dxPopup({
    width: '90%',
    height: '90%',
    showCloseButton: true,
    visible: true,
    showTitle: false,
    closeOnOutsideClick: false,
    toolbarItems: [{
      widget: 'dxButton',
      toolbar: 'bottom',
      location: 'before',
      options: {
        icon: 'email',
        text: 'Send',

        onClick() {
          const message = `Email is sent to aaaaaaaaaaaaaaaa`;
          DevExpress.ui.notify({
            message,
            position: {
              my: 'center top',
              at: 'center top'
            }
          }, 'success', 3000);
        }

      }
    }, {
      widget: 'dxButton',
      toolbar: 'bottom',
      location: 'after',
      options: {
        text: 'Register',
        type: 'success',
        useSubmitBehavior: true,

        onClick() {
          //popup.hide();
          //form.submit();
          $("#form-container").submit();
        }

      }
    }]
  }).dxPopup('instance'); // form design
  //const form = $('#form').dxForm({
  //    labelMode: 'floating',
  //    colCount: 1,
  //    formData: null,
  //    items: [
  //        {
  //            itemType: 'group',
  //            caption: '',
  //            items: ['roleName'],
  //        },
  //        {
  //            colCount: 2,
  //            itemType: 'group',
  //            caption: 'Menu',
  //            items: ['menuName'],
  //        }
  //    ],
  //}).dxForm('instance');
  //$('#form-container').on('submit', (e) => {
  //    //var validate = form.validate();
  //    //if (validate.isValid) {
  //    //    alert("berhasil");
  //    //}
  //    e.preventDefault();
  //    console.log($(this).serializeArray());
  //});

  $('#form-container').submit(function (e) {
    e.preventDefault(); // $(this).serialize(); will be the serialized form

    console.log($(this).serializeArray()); //$(this).append($(this).serialize() + '<br />');
  });
  $('.confirm_appointment').submit(function (e) {
    e.preventDefault(); // $(this).serialize(); will be the serialized form

    console.log($(this).serializeArray()); //$(this).append($(this).serialize() + '<br />');
  });
}

export { OnLoad };
