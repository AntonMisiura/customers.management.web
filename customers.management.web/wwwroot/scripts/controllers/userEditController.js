Application.controller("userEditController", function ($scope, $http, $location, customerService) {
	$scope.currentUserDepartments = [];

	$scope.editable = customerService.getData();

	$scope.cancel = function () {
		$location.path("/users");
	};

	$scope.apply = function () {
		
	};

	$scope.getCustomerAvailableDepartments = function(customerId) {
		$scope.currentUserDepartments = [
			{
				Id: 1, Name: "dep1"
			},
			{
				Id: 2, Name: "dep2"
			}
		];
	};
});