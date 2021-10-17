window.toastrFunctions = {
	showToastrInfo: function (message) {
		//toastr.options = options;
		toastr.info(message);
	},

	warning: function (message, options) {
		toastr.options = options;
		toastr.warning(message);
	},

	error: function (message, options) {
		toastr.options = options;
		toastr.error(message);
	},

	success: function (message, options) {
		toastr.options = options;
		toastr.success(message);
	}
}
