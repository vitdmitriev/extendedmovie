/* Services */

angular.module('Qemy.services', [
    'Qemy.i18n'
])
    .provider('Storage', function () {

        this.setPrefix = function (newPrefix) {
            ConfigStorage.prefix(newPrefix);
        };

        this.$get = ['$q', function ($q) {
            var methods = {};
            angular.forEach(['get', 'set', 'remove'], function (methodName) {
                methods[methodName] = function () {
                    var deferred = $q.defer(),
                        args = Array.prototype.slice.call(arguments);

                    args.push(function (result) {
                        deferred.resolve(result);
                    });
                    ConfigStorage[methodName].apply(ConfigStorage, args);

                    return deferred.promise;
                };
            });
            return methods;
        }];
    })

    .service('StorageObserver', ['Storage', function(Storage) {
        var Observer = function Observer(storageKey, callback, params) {
            params = params || {};
            var prevVal,
                looper,
                destroyFlag = params.destroy || false,
                lazyTimeout = params.timeout || 50,
                deleteAfter = params.deleteAfter || false;
            Storage.get(storageKey).then(function(value) {
                prevVal = value;
            });
            looper = setInterval(function() {
                Storage.get(storageKey).then(function(value) {
                    if (prevVal != value) {
                        callback(value, prevVal);
                        if (destroyFlag || deleteAfter) {
                            clearInterval(looper);
                            if (deleteAfter) {
                                Storage.remove(storageKey);
                            }
                        }
                        prevVal = value;
                    }
                });
            }, lazyTimeout);

            function stop(lastInvoke) {
                clearInterval(looper);
                if (lastInvoke) {
                    callback(prevVal);
                }
            }

            return {
                stopWatching: stop
            }
        };

        function startObserver() {
            var args = Array.prototype.slice.call(arguments);
            return Observer.apply(this, args);
        }

        return {
            watch: startObserver
        }
    }])

    .service('Company', ['Storage', '$q', '$http', function (Storage, $q, $http) {
        var company = null;
        var url = '/api/companies';

        function isAuth() {
            var deferred = $q.defer();
            Storage.get('company_guid').then(function (company_giud) {
                deferred.resolve(!!company_giud);
            });
            return deferred.promise;
        }

        function getCompany() {
            var deferred = $q.defer();
            Storage.get('company_guid').then(function (company_guid) {
                if (company) {
                    return deferred.resolve(company);
                } else if (!company_guid) {
                    return deferred.reject();
                }
                var apiUrl = url + '/' + company_guid;
                $http.get(apiUrl).success(function (data, status, headers, config) {
                    company = data;
                    deferred.resolve(company);
                })
            });

            return deferred.promise;
        }

        function createCompany(params) {
            var deferred = $q.defer();
            $http.post(url, params).success(function (data, status, headers, config) {
                if (data.Message) {
                    return deferred.reject();
                }
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        function getCinemas(company_guid) {
            var deferred = $q.defer();
            if (company_guid) {
                var apiUrl = url + '/' + company_guid + '/cinemas';
                $http.get(apiUrl).success(function (data, status, headers, config) {
                    deferred.resolve(data);
                });
            } else {
                Storage.get('company_guid').then(function (guid) {
                    var apiUrl = url + '/' + guid + '/cinemas';
                    $http.get(apiUrl).success(function (data, status, headers, config) {
                        deferred.resolve(data);
                    });
                });
            }

            return deferred.promise;
        }

        function dataEncode(data) {
            var resultString = "";
            if (data) {
                for (var el in data) {
                    data.hasOwnProperty(el) && (resultString += "/" + el.toString() + "/" + encodeURIComponent(data[el]));
                }
                if ('/' == resultString.charAt(0)) {
                    return resultString.slice(0, -1);
                }
            }
            return resultString;
        }

        return {
            getCompany: getCompany,
            isAuth: isAuth,
            createCompany: createCompany,
            getCinemas: getCinemas
        }
    }])

    .service('Cinemas', ['Storage', '$q', '$http', function (Storage, $q, $http) {
        var url = '/api/cinemas';

        function getCinema(company_guid, cinema_guid) {
            var deferred = $q.defer(),
                apiUrl = '/api/companies/' + company_guid + '/cinemas/' + cinema_guid;
            $http.get(apiUrl).success(function (data, status, headers, config) {
                deferred.resolve(data);
            });

            return deferred.promise;
        }

        function createCinema(params) {
            var deferred = $q.defer();
            Storage.get('company_guid').then(function (guid) {
                var apiUrl = '/api/companies/' + guid + '/cinemas';
                params.CompanyId = guid;
                $http.post(apiUrl, params).success(function (data, status, headers, config) {
                    if (data.Message) {
                        return deferred.reject();
                    }
                    deferred.resolve(data);
                });
            });
            return deferred.promise;
        }

        return {
            getCinema: getCinema,
            createCinema: createCinema
        }
    }])

    .service('Movies', ['Storage', '$q', '$http', function (Storage, $q, $http) {
        var url = '/api/cinemas';

        function getMovies(cinema_guid) {
            var deferred = $q.defer(),
                apiUrl = url + '/' + cinema_guid + '/movies';
            $http.get(apiUrl).success(function (data, status, headers, config) {
                deferred.resolve(data);
            });

            return deferred.promise;
        }

        function createMovie(cinema_guid, params) {
            var deferred = $q.defer(),
                apiUrl = '/api/cinemas/' + cinema_guid + '/movies';
            params.CinemaId = cinema_guid;
            $http.post(apiUrl, params).success(function (data, status, headers, config) {
                if (data.Message) {
                    return deferred.reject();
                }
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        function getMovie(cinema_guid, movie_guid) {
            var deferred = $q.defer(),
                apiUrl = '/api/cinemas/' + cinema_guid + '/movies/' + movie_guid;
            $http.get(apiUrl).success(function (data, status, headers, config) {
                deferred.resolve(data);
            });

            return deferred.promise;
        }

        return {
            getMovies: getMovies,
            createMovie: createMovie,
            getMovie: getMovie
        }
    }])

    .service('TrackLanguages', ['Storage', '$q', '$http', function (Storage, $q, $http) {

        function getLanguages(movieId) {
            var deferred = $q.defer(),
                apiUrl = '/api/movies/' + movieId + '/tracklanguages';
            $http.get(apiUrl).success(function (data, status, headers, config) {
                deferred.resolve(data);
            });

            return deferred.promise;
        }

        function createLanguage(movieId, params) {
            var deferred = $q.defer(),
                apiUrl = '/api/movies/' + movieId.trim() + '/tracklanguages';
            params.MovieId = movieId;
            $http.post(apiUrl, params).success(function (data, status, headers, config) {
                if (data.Message) {
                    return deferred.reject();
                }
                deferred.resolve(data);
            });
            return deferred.promise;
        }

        function getLanguage(movieId, languageId) {
            var deferred = $q.defer(),
                apiUrl = '/api/movies/' + movieId.trim() + '/tracklanguages/' + languageId;
            $http.get(apiUrl).success(function (data, status, headers, config) {
                deferred.resolve(data);
            });

            return deferred.promise;
        }

        return {
            getLanguages: getLanguages,
            createLanguage: createLanguage,
            getLanguage: getLanguage
        }
    }])
;