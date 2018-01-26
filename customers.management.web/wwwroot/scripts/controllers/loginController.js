Application.controller("loginController", function ($scope, $http, $location, loginService, accountService, $rootScope) {
	$scope.logined = loginService.getStatus();

	$scope.returnUrl = "";

	$scope.user = {
		UserName: "",
		Password: ""
	};

	$scope.callHeaderCtrl = function() {
		$rootScope.$emit("callHeaderCtrl", {});
	};
	

	$scope.signIn = function () {
		var url = "user/login";
		if ($scope.user !== null) {
			$http.post(url, $scope.user).then(function successCallback(response) {
				$scope.customerId = response.data;
				$scope.logined = true;
				loginService.setStatus($scope.logined);

				if (response.data === "Admin") {
					accountService.setStatus(true);
				} else {
					accountService.setStatus(false);
				}

				$location.path("/general");
				$scope.callHeaderCtrl();
			}, function errorCallback() {
				alert("User not found!");
			});
		}
	};
});