Application.controller("departmentEditController", function ($scope, $http, $location, customerService) {
	$scope.currentDepartmentUsers = [];
	
	$scope.editable = customerService.getData();

	$scope.cancel = function () {
		$location.path("/departments");
	};

	$scope.apply = function () {

	};

	$scope.getCustomerAvailableUsers = function (customerId) {
		$scope.currentDepartmentUsers = [
			{
				Id: 1, Name: "user1"
			},
			{
				Id: 2, Name: "user2"
			}
		];
	};
});