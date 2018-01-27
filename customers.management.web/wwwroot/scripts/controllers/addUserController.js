Application.controller("addUserController", function ($scope, $http, $location, customerStorage) {
	$scope.currentUserDepartments = [];
	$scope.customerId = customerStorage.getId();
	$scope.selectedDepartment = {};

	$scope.added = {
		Name: null, Email: null, Mobile: null, UserName: null, Password: null, CustomerId: $scope.customerId, Department: null
	};

	$scope.cancel = function () {
		$location.path("/users");
	};

	$scope.apply = function () {
		var url = "user/adduser";
		var newuser = $scope.added;
		$http.post(url, newuser).then(function successCallback(response) {
			$scope.cancel();
		}, function errorCallback() {
			alert("An error occured during loading departments!");
		});
	};

	$scope.getCustomerAvailableDepartments = function () {
		var url = "department/getbycustomerid/" + $scope.customerId;

		$http.get(url).then(function successCallback(response) {
			$scope.currentUserDepartments = response.data;
		}, function errorCallback() {
			alert("An error occured during loading departments!");
		});
	};
});