Application.factory("customerStorage", function () {
	var customerId = window.localStorage.getItem("customerId");

	var service = {
		setId: setId,
		getId: getId
	};

	return service;

	function setId(id) {
		customerId = id;
	}

	function getId() {
		return customerId;
	}
});