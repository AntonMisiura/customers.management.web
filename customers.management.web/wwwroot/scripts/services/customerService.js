Application.factory("customerService", function () {
	var data = {};

	var service = {
		setData: setData,
		getData: getData
	};

	return service;

	function setData(income) {
		data = income;
	}

	function getData() {
		return data;
	}
});