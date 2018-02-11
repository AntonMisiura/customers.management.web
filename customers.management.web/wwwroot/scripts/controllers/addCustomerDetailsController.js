Application.controller("addCustomerDetailsController", function ($scope, $http, $location) {
	$scope.addedUsers = [];
	$scope.addedContacts = [];
	$scope.addedDepartments = [];

	$scope.custName = "";
	$scope.custAddress = "";
	$scope.custEmail = "";
	$scope.custPhone = "";
	$scope.custComments = "";
	$scope.selectedTypeId = "2";
	$scope.custSchoolNumber = "";
	$scope.ifMunicipality = false;

	$scope.types = [
		{
			id: 1,
			name: "Municipality"
		},
		{
			id: 2,
			name: "Business"
		}];

	$scope.showSchoolNumbers = function () {
		if ($scope.selectedTypeId === "1") {
			$scope.ifMunicipality = true;
		}
		else
			if ($scope.selectedTypeId === "2") {
				$scope.ifMunicipality = false;
			}
	};

	$scope.addContact = function () {
		$scope.addedContacts.unshift({
			name: null, role: null,
			phone: null
		});
		console.log($scope.addedContacts);
	};

	$scope.addDepartment = function () {
		$scope.addedDepartments.unshift({
			name: null, address: null,
			manager: null
		});
		console.log($scope.addedDepartments);
	};

	$scope.addUser = function () {
		$scope.addedUsers.unshift({
			name: null, email: null,
			mobile: null, userName: null,
			password: null, department: null
		});
		console.log($scope.addedUsers);
	};

	$scope.deleteUser = function (index) {
		for (var i = 0; i < $scope.addedUsers.length; i++) {
			if (index === i) {
				$scope.addedUsers.splice(index, 1);
			}
		}
		console.log("user deleted");
	};

	$scope.deleteContact = function (index) {
		for (var i = 0; i < $scope.addedContacts.length; i++) {
			if (index === i) {
				$scope.addedContacts.splice(index, 1);
			}
		}
		console.log("contact deleted");
	};

	$scope.deleteDepartment = function (index) {
		for (var i = 0; i < $scope.addedDepartments.length; i++) {
			if (index === i) {
				$scope.departments.splice(index, 1);
			}
		}
		console.log("department deleted");
	};

	$scope.cancel = function () {
		$scope.addedUsers = [];
		$scope.addedContacts = [];
		$scope.addedDepartments = [];
		$scope.custName = "";
		$scope.custAddress = "";
		$scope.custEmail = "";
		$scope.custPhone = "";
		$scope.custComments = "";
		$scope.selectedTypeId = "2";
		$scope.custSchoolNumber = "";
		$scope.ifMunicipality = false;

		$location.path("/adminPage");
	};


	$scope.customerDetailsToAdd = {};

	$scope.apply = function () {
		var customer = {};

		if ($scope.selectedTypeId === "1") {
			customer = {
				name: $scope.custName,
				address: $scope.custAddress,
				email: $scope.custEmail,
				phone: $scope.custPhone,
				comments: $scope.custComments,
				typeId: $scope.selectedTypeId
			};
		}
		else if ($scope.selectedTypeId === "2") {
			customer = {
				name: $scope.custName,
				address: $scope.custAddress,
				email: $scope.custEmail,
				phone: $scope.custPhone,
				comments: $scope.custComments,
				typeId: $scope.selectedTypeId
			};
		}

		$scope.customerDetailsToAdd = {
			Customer: customer,
			Departments: $scope.addedDepartments,
			Users: $scope.addedUsers,
			Contacts: $scope.addedContacts
		};


		var addurl = "customerdetails/addcustomerdetails";
		$http.post(addurl, $scope.customerDetailsToAdd).then(function () {
			$scope.cancel();
		}, function () {
		});
	};
});