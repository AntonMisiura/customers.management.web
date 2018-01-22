Application.controller("customerEditController", function ($scope, $http, $location, customerService) {

	$scope.editable = customerService.getData();

	$scope.cancel = function () {
		$location.path("/general");
	};

	$scope.apply = function () {

	};
});