'use strict';

/* Controllers */

angular.module('Qemy.controllers', [
    'Qemy.i18n'
])
    .controller('PageCtrl', ['$scope', '_', function($scope, _) {
        var defaultTitle = _('app_name');
        $scope.$on('change_title', function(e, args) {
            $scope.title = args.title !== undefined && args.title.length ? args.title : defaultTitle;
        });

        document.addEventListener('scroll', onScrollHandler);

        function onScrollHandler(e) {
            var scrollTop = document.body.scrollTop,
                headerMenuWrapper = document.querySelector('.header');
            if (scrollTop > 50) {
                angular.element(headerMenuWrapper).addClass('header_state_scrolled');
            } else {
                angular.element(headerMenuWrapper).removeClass('header_state_scrolled');
            }
        }
    }])

    .controller('AppCtrl', ['$scope', function($scope) {
        $scope.company = null;
    }])

    .controller('RegisterCtrl', ['$scope', '_', 'Company', '$location', 'Storage', function($scope, _, Company, $location, Storage) {
        $scope.$emit('change_title', {
            title: _('app_name')
        });

        $scope.register = {
            Id: '00000000-0000-0000-0000-000000000000',
            PhotoUri: 'http://static.tumblr.com/wvuzcz9/LlKncfhmp/slack_logo_240.png'
        };

        $scope.submitted = false;
        $scope.submitForm = function () {
            $scope.submitted = true;
            Company.createCompany($scope.register).then(function (result) {
                $scope.submitted = false;
                if (typeof result !== 'string') {
                    return;
                }
                Storage.set({'company_guid': result}).then(function () {
                    $location.path('/company');
                });
            }, function () {
                $scope.submitted = false;
            });
        };
    }])

    .controller('CompanyCtrl', ['$scope', 'Company', 'Cinemas', function($scope, Company, Cinemas) {
        $scope.company = {};
        $scope.cinemas = [];
        $scope.cinemaLoading = true;

        Company.getCompany().then(function (company) {
            console.log(company);
            $scope.company = company;
            if (!$scope.company) {
                $scope.cinemaLoading = false;
                return;
            }
            $scope.$emit('change_title', {
                title: company.Name || 'Компания'
            });
            Company.getCinemas(company.Id).then(function (cinemas) {
                $scope.cinemaLoading = false;
                if (!Array.isArray(cinemas)) {
                    return;
                }
                $scope.cinemas = cinemas;
            });
        });
    }])

    .controller('CompanyCreateCtrl', ['$scope', 'Company', 'Cinemas', '$location', function($scope, Company, Cinemas, $location) {
        $scope.company = {};

        $scope.cinema = {};

        $scope.submitted = false;

        Company.getCompany().then(function (company) {
            $scope.company = company;
        });

        $scope.submitForm = function () {
            $scope.submitted = true;
            if (!$scope.cinema.Address) {
                return;
            }
            Cinemas.createCinema($scope.cinema).then(function (result) {
                $scope.submitted = false;
                if (typeof result !== 'string') {
                    return;
                }
                $location.path('/company');
            }, function () {
                $scope.submitted = false;
            });
        };
    }])

    .controller('CinemaCtrl', ['$scope', '$route', 'Cinemas', 'Company', 'Movies', function($scope, $route, Cinemas, Company, Movies) {
        $scope.company = {};
        $scope.cinema = {};
        $scope.movies = [];
        $scope.dataLoading1 = true;
        $scope.dataLoading2 = true;

        $scope.selectQr = function (qr) {
            $scope.curQR = qr;
        };

        $scope.closePopup = function () {
            $scope.curQR = '';
        };

        $scope.curQR = null;

        $scope.cinemaGuid = $route.current.params.cinemaId;

        Company.getCompany().then(function (company) {
            $scope.company = company;
            Cinemas.getCinema(company.Id, $scope.cinemaGuid).then(function (cinema) {
                $scope.cinema = cinema;
                $scope.dataLoading1 = false;
            });
            Movies.getMovies($scope.cinemaGuid).then(function (movies) {
                $scope.movies = movies;
                $scope.dataLoading2 = false;
            });
        });
    }])

    .controller('CinemaCreateCtrl', ['$scope', '$route', 'Cinemas', 'Company', 'Movies', '$location', function($scope, $route, Cinemas, Company, Movies, $location) {
        $scope.company = {};
        $scope.cinemaId = $route.current.params.cinemaId;

        $scope.movie = {};

        $scope.submitted = false;

        Company.getCompany().then(function (company) {
            $scope.company = company;
        });

        $scope.submitForm = function () {
            $scope.submitted = true;
            Movies.createMovie($scope.cinemaId, $scope.movie).then(function (result) {
                $scope.submitted = false;
                if (typeof result !== 'string') {
                    return;
                }
                $location.path('/cinemas/' + $scope.cinemaId);
            }, function () {
                $scope.submitted = false;
            });
        };
    }])

    .controller('MovieCtrl', ['$scope', '$route', 'Cinemas', 'Company', 'Movies', 'TrackLanguages', function($scope, $route, Cinemas, Company, Movies, TrackLanguages) {
        $scope.cinemaId = $route.current.params.cinemaId;
        $scope.movieId = $route.current.params.movieId;

        $scope.cinema = {};
        $scope.movie = {};
        $scope.languages = [];

        $scope.dataLoading = true;
        $scope.company = {};


        Company.getCompany().then(function (company) {
            $scope.company = company;
            Cinemas.getCinema(company.Id, $scope.cinemaId).then(function (cinema) {
                $scope.cinema = cinema;
                Movies.getMovie($scope.cinemaId, $scope.movieId).then(function (movie) {
                    $scope.movie = movie;

                    TrackLanguages.getLanguages(movie.Id).then(function (languages) {
                        $scope.languages = languages;
                        $scope.dataLoading = false;
                    });
                });
            });
        });
    }])

    .controller('MovieCreateCtrl', ['$scope', '$route', '$location', 'Cinemas', 'Company', 'Movies', 'TrackLanguages', function($scope, $route, $location, Cinemas, Company, Movies, TrackLanguages) {
        $scope.cinemaId = $route.current.params.cinemaId;
        $scope.movieId = $route.current.params.movieId;

        $scope.company = {};

        $scope.movie = {};
        $scope.dataLoading = true;

        $scope.submitted = false;
        $scope.uploading = false;
        $scope.progress = 0;

        $scope.language = {};

        $scope.$on('beforeSend', function () {
            $scope.uploading = true;
            $scope.$apply();
        });

        $scope.$on('progress', function (e, arg) {
            $scope.progress = arg.progress_value;
            $scope.$apply();
        });

        $scope.$on('success', function (e, arg) {
            $scope.uploading = false;
            $scope.language.TrackFileId = arg.data;
            $scope.$apply();
        });

        Company.getCompany().then(function (company) {
            $scope.company = company;
        });

        $scope.submitForm = function () {
            $scope.submitted = true;
            if (!$scope.language.TrackFileId) {
                return;
            }
            TrackLanguages.createLanguage($scope.movieId, $scope.language).then(function (result) {
                $scope.submitted = false;
                if (typeof result !== 'string') {
                    return;
                }
                $location.path('/cinemas/' + $scope.cinemaId + '/movies/' + $scope.movieId);
            }, function () {
                $scope.submitted = false;
            });
        };
    }])
;