Application.controller("userPageController", function ($scope, $http, accountService) {

	$scope.cust = {};

	$scope.initGeneralInfo = function () {
		var login = accountService.getLogin();
		var url = "customerdetails/getcustomerbyusername/" + login;
		$http.get(url).then(function successCallback(response) {
			$scope.cust = response.data.customer;
		}, function errorCallback() {
		});
	};
});