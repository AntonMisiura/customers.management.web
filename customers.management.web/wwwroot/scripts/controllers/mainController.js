Application.controller("headerController", function ($scope, $http, $location, $rootScope, loginService) {
	$scope.isLogined = loginService.getStatus();

	$scope.findIfLogined = function() {
		$scope.isLogined = loginService.getStatus();
	};

	$rootScope.$on("callHeaderCtrl", function () {
		$scope.findIfLogined();
	});

	$scope.logout = function () {
		var url = "login/logout";
		$http.get(url).then(function successCallback() {
			$scope.isLogined = false;
			loginService.setStatus($scope.isLogined);
			$location.path("/");
		}, function errorCallback() {
			alert("Error occurs during logout...");
		});
	};

	$scope.login = function () {
		$location.path("/login");
	};
});