Application.controller("generalController", function ($scope, $http, $location, customerService, accountService, customerStorage) {
	$scope.isAdmin = accountService.getStatus();

	$scope.customers = [];
	$scope.showCustTable = false;
	$scope.showConctactTable = false;
	$scope.selectedCustomerId = "";

	$scope.contacts = [];

	$scope.initCustomers = function () {
		var url = "customer/getall";

		$http.get(url).then(function successCallback(response) {
			$scope.customers = response.data;
		}, function errorCallback() {
			
		});
	};

	$scope.selectCustomer = function() {
		$scope.initContacts();
		$scope.showCustTable = true;
		$scope.showConctactTable = true;
		customerStorage.setId($scope.selectedCustomerId);
		window.localStorage.setItem("customerId", $scope.selectedCustomerId);
	};

	$scope.initContacts = function () {
		var url = "customer/GetCustomerContacts/" + $scope.selectedCustomerId;

		$http.get(url).then(function successCallback(response) {
			$scope.contacts = response.data.contacts;
		}, function errorCallback() {
			alert("An error occured during loading contacts!");
		});
	};

	$scope.go = function (path) {
		$location.path(path);
	};

	$scope.editCustomer = function (cust) {
		$scope.go("/customer/edit");
		customerService.setData(cust);
	};

	$scope.deleteCustomer = function (id) {
		for (var i = 0; i < $scope.customers.length; i++) {
			if ($scope.customers[i].Id === id) {
				$scope.customers.splice(i, 1);
			}
		}
	};

	$scope.editContact = function (cont) {
		$scope.go("/contact/edit");
		customerService.setData(cont);
	};

	$scope.deleteContact = function (id) {
		for (var i = 0; i < $scope.contacts.length; i++) {
			if ($scope.contacts[i].Id === id) {
				$scope.contacts.splice(i, 1);
			}
		}
	};

	$scope.addCustomer = function () {
		$scope.go("/customer/add");
	};

	$scope.addContact = function () {
		$scope.go("/contact/add");
	};
});