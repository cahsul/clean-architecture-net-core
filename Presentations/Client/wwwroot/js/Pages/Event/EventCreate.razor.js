function showMessage(message) {
  // Single picker
  var aaa = $('.daterange-single').daterangepicker({
    parentEl: '.content-inner',
    singleDatePicker: true
  });
  console.log(aaa);
}

export { showMessage };
