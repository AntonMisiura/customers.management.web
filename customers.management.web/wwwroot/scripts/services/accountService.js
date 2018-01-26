Application.factory("accountService", function () {
	var isAdmin = false;

	var service = {
		setStatus: setStatus,
		getStatus: getStatus
	};

	return service;

	function setStatus(status) {
		isAdmin = status;
	}

	function getStatus() {
		return isAdmin;
	}
});