Application.controller("addUserController", function ($scope, $http, $location) {
	$scope.currentUserDepartments = [];

	$scope.added = {
		Name: null, Email: null, Mobile: null, UserName: null, Password: null, Department: null
	};

	$scope.cancel = function () {
		$location.path("/users");
	};

	$scope.apply = function () {
		console.log($scope.added);
		$scope.cancel();
	};

	$scope.getCustomerAvailableDepartments = function (customerId) {
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