Application.controller("addCustomerController", function ($scope, $http, $location) {

	$scope.added = {
		Name: null, Address: null, Email: null, Phone: null, Comments: null
	};

	$scope.cancel = function () {
		$location.path("/general");
	};

	$scope.apply = function () {
		console.log($scope.added);
		$scope.cancel();
	};
});