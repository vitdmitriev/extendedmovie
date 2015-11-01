'use strict';

/* Directives */

angular.module('Qemy.directives', [])

    .directive('emailFilter', function() {
        return {
            require : 'ngModel',
            link : function(scope, element, attrs, ngModel) {
                var except = attrs.emailFilter,
                    emptyKey = 'empty';
                ngModel.$parsers.push(function(value) {
                    function setValidity(message, bool) {
                        ngModel.$setValidity(message, bool);
                    }
                    var emailRegex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                        isValid = emailRegex.test(value.toString());
                    setValidity('email', value.length ? isValid : except == emptyKey);

                    return value;
                })
            }
        }
    })

    .directive('mySubmitOnEnter', function () {
        return {
            link: link
        };
        function link($scope, element, attrs) {
            element.on('keydown', function (event) {
                if (event.keyCode == 13) {
                    element.trigger('submit');
                }
            });
        }
    })

    .directive('ownHeader', function () {
        return {
            restrict: 'E',
            templateUrl: templateUrl('header', 'header'),
            replace: true
        }
    })

    .directive('headerProfile', function () {
        return {
            restrict: 'E',
            templateUrl: templateUrl('header', 'header-profile'),
            replace: true
        }
    })

    .directive('registerForm', function () {
        return {
            restrict: 'E',
            templateUrl: templateUrl('register', 'form'),
            replace: true
        }
    })

    .directive('uploadFile', ['$rootScope', function($rootScope) {
        return {
            link: link
        };

        function link($scope, element, attrs) {
            $.ajaxUploadSettings.name = 'file';
            $(element[0]).ajaxUploadPrompt({
                url : '/api/files',
                beforeSend : function () {
                    $rootScope.$broadcast('beforeSend');
                    console.log('before send');
                },
                onprogress: function (e) {
                    if (e.lengthComputable) {
                        var percentComplete = e.loaded / e.total;
                        $rootScope.$broadcast('progress', {
                            progress_value: percentComplete * 100
                        });
                    }
                },
                error: function () {
                    $rootScope.$broadcast('error');
                },
                success: function (data) {
                    $rootScope.$broadcast('success', {
                        data: data
                    });
                }
            });
        }
    }])
;