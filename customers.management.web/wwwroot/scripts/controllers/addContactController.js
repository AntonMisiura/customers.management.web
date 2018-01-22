Application.controller("addContactController", function ($scope, $http, $location) {

	$scope.added = {
		Name: null, Role: null, Email: null, Phone: null
	};

	$scope.cancel = function () {
		$location.path("/general");
	};

	$scope.apply = function () {
		console.log($scope.added);
		$scope.cancel();
	};
});