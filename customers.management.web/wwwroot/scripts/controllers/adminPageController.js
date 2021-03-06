﻿Application.controller("adminPageController", function ($scope, $http, $location) {
	$scope.selectedCustomerId = "";
	$scope.show = false;
	$scope.customers = [];
	$scope.contacts = [];
	$scope.departments = [];
	$scope.users = [];

	$scope.deletedUsers = [];
	$scope.deletedContacts = [];
	$scope.deletedDepartments = [];
	$scope.addedCustomer = {};
	$scope.customer = {};

	$scope.types = [
		{
			id: 1,
			name: "Municipality"
		},
		{
			id: 2,
			name: "Business"
		}];

	$scope.showCustomerTypes = function (id) {
		if (id === 1) {
			return $scope.types[0].name;
		} else {
			return $scope.types[1].name;
		}
	};


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
			$scope.customer = response.data.customer;
			$scope.contacts = response.data.contacts;
			$scope.users = response.data.customer.users;
			$scope.departments = response.data.departments;
		}, function errorCallback() {
		});
	};

	$scope.getManagers = function () {
		for (var i = 0; i < $scope.departments.length; i++) {
			for (var j = 0; j < $scope.users.length; j++) {
				if ($scope.departments[i].userId === $scope.users[j].id) {
					$scope.departments[i].manager = $scope.users[j];
				}
			}
		}
	};

	$scope.showManager = function (userId) {
		for (var i = 0; i < $scope.users.length; i++) {
			if ($scope.users[i].id === userId) {
				return $scope.users[i].name;
			}
		}
	};

	$scope.showUserDepartment = function (depId) {
		for (var i = 0; i < $scope.departments.length; i++) {
			if ($scope.departments[i].id === depId) {
				return $scope.departments[i].name;
			}
		}
	};

	$scope.addCustomer = function () {
		$location.path("/addCustomer");
	};

	$scope.addContact = function () {
		$scope.contacts.unshift({
			name: null, role: null,
			phone: null, customerId: $scope.selectedCustomerId
		});
	};

	$scope.addDepartment = function () {
		$scope.departments.unshift({
			name: null, address: null,
			manager: null
		});
	};

	$scope.addUser = function () {
		$scope.users.unshift({
			name: null, email: null,
			mobile: null, userName: null,
			password: null, department: null,
			customerId: $scope.selectedCustomerId
		});
	};


	$scope.deleteUser = function (index, id) {
		for (var i = 0; i < $scope.users.length; i++) {
			if (id === $scope.users[i].id) {
				$scope.deletedUsers.push($scope.users[i]);
				$scope.users.splice(i, 1);
			}
			else if (id === null && index === i) {
				$scope.users.splice(index, i);
			}
		}
	};

	$scope.deleteContact = function (index, id) {
		for (var i = 0; i < $scope.contacts.length; i++) {
			if (id === $scope.contacts[i].id) {
				$scope.deletedContacts.push($scope.contacts[i]);
				$scope.contacts.splice(i, 1);
			}
			else if (id === null && index === i) {
				$scope.contacts.splice(index, i);
			}
		}
	};

	$scope.deleteDepartment = function (index, id) {
		for (var i = 0; i < $scope.departments.length; i++) {
			if (id === $scope.departments[i].id) {
				$scope.deletedDepartments.push($scope.departments[i]);
				$scope.departments.splice(i, 1);
			}
			else if (id === null && index === i) {
				$scope.departments.splice(index, i);
			}
		}
	};

	$scope.deleteCustomer = function (id) {
		
	};

	$scope.cancel = function () {
		$scope.findAndRemoveAdded($scope.users);
		$scope.findAndRemoveAdded($scope.contacts);
		$scope.findAndRemoveAdded($scope.customers);
		$scope.findAndRemoveAdded($scope.departments);
		$scope.getCustomerById();
	};

	$scope.findAndRemoveAdded = function (list) {
		for (var i = 0; i < list.length; i++) {
			if (list[i].id === null) {
				list.splice(i, 1);
			}
		}
	};

	$scope.customerDetailsToSave = {};

	$scope.apply = function () {
		var customer = {};
		for (var i = 0; i < $scope.customers.length; i++) {
			if ($scope.selectedCustomerId === $scope.customers[i].id) {
				customer = $scope.customers[i];
				
				$scope.modifiedcustomer = {
					id: $scope.selectedCustomerId,
					name: $scope.customers[i].name,
					address: $scope.customers[i].address,
					email: $scope.customers[i].email,
					phone: $scope.customers[i].phone,
					comments: $scope.customers[i].comments,
					typeId: 2
				};
			}
		}

		$scope.customerDetailsToSave = {
			Customer: customer,
			Departments: $scope.departments,
			Users: $scope.users,
			Contacts: $scope.contacts
		};

		$scope.customerDetailsToDel = {
			Сustomer: customer,
			Departments: $scope.deletedDepartments,
			Users: $scope.deletedUsers,
			Contacts: $scope.deletedContacts
		};

		var saveurl = "customerdetails/savecustomerdetails";
		$http.post(saveurl, $scope.customerDetailsToSave).then(function () {
			$scope.initCustomers();
		}, function () {
		});



		var delurl = "customerdetails/deletecustomerdetails";
		$http.post(delurl, $scope.customerDetailsToDel).then(function () {
			$scope.initCustomers();
		}, function () {
		});

		$scope.initCustomers();
	};
});