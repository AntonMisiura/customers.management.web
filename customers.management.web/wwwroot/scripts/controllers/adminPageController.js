Application.controller("adminPageController", function ($scope, $http) {
	$scope.selectedCustomerId = "";
	$scope.show = false;
	$scope.customers = [];
	$scope.contacts = [];
	$scope.departments = [];
	$scope.users = [];


	$scope.initCustomers = function () {
		var url = "customerdetails/getallcustomers/";
		$http.get(url).then(function successCallback(response) {
			$scope.customers = response.data;
		}, function errorCallback() {
		});
	};

	$scope.selectCustomer = function () {
		$scope.getCustomerById();
		$scope.show = true;
	};

	$scope.getCustomerById = function () {
		var url = "customerdetails/getcustomerdetailsbyid/" + $scope.selectedCustomerId;
		$http.get(url).then(function successCallback(response) {
			$scope.contacts = response.data.contacts;
			$scope.users = response.data.customer.users;
			$scope.departments = response.data.departments;
		}, function errorCallback() {
		});
	};

});