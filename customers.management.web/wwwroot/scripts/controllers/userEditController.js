Application.controller("userEditController", function ($scope, $http, $location, customerService, customerStorage) {
	$scope.currentUserDepartments = [];
	$scope.customerId = customerStorage.getId();
	$scope.editable = customerService.getData();

	$scope.cancel = function () {
		$location.path("/users");
	};

	$scope.apply = function () {
		var url = "user/edituser";
		$http.post(url, $scope.editable).then(function successCallback(response) {
			$scope.cancel();
		}, function errorCallback() {
			alert("An error occured during loading departments!");
		});
	};

	$scope.getDepartmentsForEditing = function () {
		var url = "department/getbycustomerid/" + $scope.customerId;

		$http.get(url).then(function successCallback(response) {
			$scope.currentUserDepartments = response.data;
		}, function errorCallback() {
			alert("An error occured during loading departments!");
		});
	};
});