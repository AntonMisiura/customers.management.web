Application.factory("loginService", function () {
	var isLogined = false;

	var service = {
		setStatus: setStatus,
		getStatus: getStatus
	};

	return service;

	function setStatus(status) {
		isLogined = status;
	}

	function getStatus() {
		return isLogined;
	}
});