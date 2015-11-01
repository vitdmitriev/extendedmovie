'use strict';

angular.module('Qemy', [
    'ng',
    'ngRoute',
    'ngSanitize',
    'Qemy.controllers',
    'Qemy.services',
    'Qemy.directives'
])
    .config(['$locationProvider', '$routeProvider', 'StorageProvider', function($locationProvider, $routeProvider, StorageProvider) {
        if (Config.Modes.test) {
            StorageProvider.setPrefix('t_');
        }
        $locationProvider.hashPrefix('!');

        $routeProvider
            .when('/', {
                templateUrl: templateUrl('index', 'main'),
                controller: 'RegisterCtrl'
            })
            .when('/company', {
                templateUrl: templateUrl('company', 'index'),
                controller: 'CompanyCtrl'
            })
            .when('/company/create', {
                templateUrl: templateUrl('company', 'create'),
                controller: 'CompanyCreateCtrl'
            })

            .when('/cinemas/:cinemaId', {
                templateUrl: templateUrl('cinema', 'index'),
                controller: 'CinemaCtrl'
            })
            .when('/cinemas/:cinemaId/create', {
                templateUrl: templateUrl('cinema', 'create'),
                controller: 'CinemaCreateCtrl'
            })

            .when('/cinemas/:cinemaId/movies/:movieId', {
                templateUrl: templateUrl('movies', 'index'),
                controller: 'MovieCtrl'
            })


            .when('/cinemas/:cinemaId/movies/:movieId/create', {
                templateUrl: templateUrl('movies', 'create'),
                controller: 'MovieCreateCtrl'
            })

            .otherwise({redirectTo: '/'});
    }]);