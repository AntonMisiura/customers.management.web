Application.controller("departmentController", function ($scope, $http, $location, customerService) {

	$scope.departments = [{
		Id: 1, Name: "dep1", Address: "adr1", Manager: "user1"
	},
	{
		Id: 2, Name: "dep2", Address: "adr2", Manager: "user2"
	},
	{
		Id: 3, Name: "dep3", Address: "adr3", Manager: "user3"
	}];

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