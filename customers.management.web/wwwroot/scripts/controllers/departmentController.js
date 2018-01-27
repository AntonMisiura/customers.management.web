Application.controller("departmentController", function ($scope, $http, $location, customerService, customerStorage) {
	$scope.customerId = customerStorage.getId();

	$scope.showDepartments = false;
	$scope.departments = [];

	$scope.initDepartments = function() {
		var url = "department/getbycustomerid/" + $scope.customerId;

		$http.get(url).then(function successCallback(response) {
			$scope.departments = response.data;
			$scope.showDepartments = true;
		}, function errorCallback() {
			alert("An error occured during loading departments!");
		});
	};

	$scope.go = function(path) {
		$location.path(path);
	};

	$scope.editDepartment = function(dep) {
		$scope.go("/department/edit");
		customerService.setData(dep);
	};

	$scope.deleteDepartment = function(id) {
		for (var i = 0; i < $scope.departments.length; i++) {
			if ($scope.departments[i].Id === id) {
				$scope.departments.splice(i, 1);
			}
		}
	};

	$scope.addDepartment = function () {
		$scope.go("/department/add");
	};
});