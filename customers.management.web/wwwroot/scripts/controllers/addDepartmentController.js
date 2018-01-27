Application.controller("addDepartmentController", function ($scope, $http, $location, customerStorage) {
	$scope.currentDepartmentUsers = [];
	$scope.customerId = customerStorage.getId();


	$scope.added = {
		Name: null, Address: null, ManagerId: null, Manager: null, CustomerId: $scope.customerId
	};

	$scope.cancel = function () {
		$location.path("/departments");
	};

	$scope.apply = function () {
		var url = "department/adddepartment";
		var newdepartment = $scope.added;
		$http.post(url, newdepartment).then(function successCallback(response) {
			$scope.cancel();
		}, function errorCallback() {
			alert("An error occured during loading departments!");
		});
		$scope.cancel();
	};

	$scope.getCustomerAvailableUsers = function () {
		var url = "user/getbycustomerid/" + $scope.customerId;

		$http.get(url).then(function successCallback(response) {
			$scope.currentDepartmentUsers = response.data;
		}, function errorCallback() {
			alert("An error occured during loading users!");
		});
	};
});