Application.controller("addDepartmentController", function ($scope, $http, $location) {
	$scope.currentDepartmentUsers = [];

	$scope.added = {
		Name: null, Address: null, Manager: null
	};

	$scope.cancel = function () {
		$location.path("/departments");
	};

	$scope.apply = function () {
		console.log($scope.added);
		$scope.cancel();
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