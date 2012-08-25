/*global window*/
/*global angular*/

function PostsListCtrl($scope, PostDb) {
    "use strict";
    $scope.posts = PostDb.query();
}

function PostsEditCtrl($scope, $location, $routeParams, $http, PostDb) {
    "use strict";
    var self = this;

    PostDb.get({ id: $routeParams.postId }, function (post) {
        self.original = post;
        $scope.post = new PostDb(self.original);
        $scope.updatePreview();
    });

    $scope.isClean = function () {
        return angular.equals(self.original, $scope.post);
    };

    $scope.destroy = function () {
        self.original.destroy(function () {
            $location.path('/');
        });
    };

    $scope.save = function () {
        $scope.post.update(function () {
            $location.path('/');
        });
    };

    $scope.updatePreview = function () {
        $http.get('/api/Markdown?md=' + window.escape($scope.post.Content)).success(function (data) {
            $scope.content = data.substring(1, data.length - 1).replace(/\\n/g, '');
        });
    };
}

function PostsCreateCtrl($scope, $location, $http, PostDb) {
    "use strict";
    $scope.save = function () {
        PostDb.save($scope.post, function () {
            $location.path('/');
        });
    };
    $scope.updatePreview = function () {
        $http.get('/api/Markdown?md=' + window.escape($scope.post.Content)).success(function (data) {
            $scope.content = data.substring(1, data.length - 1).replace(/\\n/g, '');
        });
    };
}

angular.module('posts', ['ngSanitize', 'postdb'])
    .config(function ($routeProvider) {
        "use strict";
        $routeProvider
            .when('/', { controller: PostsListCtrl, templateUrl: '/PostAdmin/List' })
            .when('/edit/:postId', { controller: PostsEditCtrl, templateUrl: '/PostAdmin/Edit' })
            .when('/new', { controller: PostsCreateCtrl, templateUrl: '/PostAdmin/Create' })
            .otherwise({ redirectTo: '/' });
    });