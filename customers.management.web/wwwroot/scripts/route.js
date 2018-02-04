Application.config([
	"$routeProvider", function ($routeProvider) {
		$routeProvider
			.when("/login",
			{
				templateUrl: "views/login.html",
				controller: "loginController"
			})
			.when("/",
			{
				templateUrl: "views/login.html",
				controller: "loginController"
			})
			.when("/userPage",
			{
				templateUrl: "views/userPage.html",
				controller: "userPageController"
			})
			.when("/adminPage",
			{
				templateUrl: "views/adminPage.html",
				controller: "adminPageController"
			})
			.when("/addCustomer",
			{
				templateUrl: "views/addCustomerDetails.html",
				controller: "addCustomerDetailsController"
			});
	}
]);