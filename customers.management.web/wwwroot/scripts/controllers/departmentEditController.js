Application.controller("departmentEditController", function ($scope, $http, $location, customerService) {
	$scope.currentDepartmentUsers = [];
	
	$scope.editable = customerService.getData();

	$scope.cancel = function () {
		$location.path("/departments");
	};

	$scope.apply = function () {

	};

	$scope.getCustomerAvailableUsers = function (customerId) {
		var url = "user/getbycustomerid/" + $scope.customerId;

		$http.get(url).then(function successCallback(response) {
			$scope.currentDepartmentUsers = response.data;
		}, function errorCallback() {
			alert("An error occured during loading users!");
		});
	};
});