function Speaker(element) {
  // Basic datatable
  $(element).dataTable({
    searching: false,
    paging: false,
    info: false,
    "ordering": false
  });
}

export { Speaker };
