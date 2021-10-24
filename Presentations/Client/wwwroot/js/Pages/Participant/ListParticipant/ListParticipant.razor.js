function DatatableLoad(element) {
  if (!$().DataTable) {
    console.warn('Warning - datatables.min.js is not loaded.');
    return;
  } // Setting datatable defaults


  $.extend($.fn.dataTable.defaults, {
    autoWidth: false,
    columnDefs: [{
      orderable: false,
      width: 100,
      targets: [5]
    }],
    dom: '<"datatable-header"fl><"datatable-scroll"t><"datatable-footer"ip>',
    language: {
      search: '<span>Filter:</span> _INPUT_',
      searchPlaceholder: 'Type to filter...',
      lengthMenu: '<span>Show:</span> _MENU_',
      paginate: {
        'first': 'First',
        'last': 'Last',
        'next': $('html').attr('dir') == 'rtl' ? '&larr;' : '&rarr;',
        'previous': $('html').attr('dir') == 'rtl' ? '&rarr;' : '&larr;'
      }
    }
  }); // Apply custom style to select

  $.extend($.fn.dataTableExt.oStdClasses, {
    "sLengthSelect": "custom-select"
  });
  $(element).dataTable();
}

export { DatatableLoad };
