angular.module('posts', ['ngSanitize', 'postdb'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/',              { controller: PostsListCtrl, templateUrl: '/PostAdmin/List' })
            .when('/edit/:postId',  { controller: PostsEditCtrl, templateUrl: '/PostAdmin/Edit' })
            .when('/new',           { controller: PostsCreateCtrl, templateUrl: '/PostAdmin/Create' })
            .otherwise(             { redirectTo: '/' });
    });

function PostsListCtrl($scope, PostDb) {
    $scope.posts = PostDb.query();
}

function PostsEditCtrl($scope, $location, $routeParams, $http, PostDb) {
    var self = this;

    PostDb.get({ id: $routeParams.postId }, function (post) {
        self.original = post;
        $scope.post = new PostDb(self.original);
        $scope.updatePreview();
    });

    $scope.isClean = function() {
        return angular.equals(self.original, $scope.post);
    };

    $scope.destroy = function() {
        self.original.destroy(function() {
            $location.path('/');
        });
    };

    $scope.save = function () {
        $scope.post.update(function () {
            $location.path('/');
        });
    };

    $scope.updatePreview = function () {
        $http.get('/api/Markdown?md=' + escape($scope.post.Content)).success(function (data) {
            $scope.content = data.substring(1, data.length - 1).replace(/\\n/g, '');
        });
    }
}

function PostsCreateCtrl($scope, $location, $http, PostDb) {
    $scope.save = function () {
        PostDb.save($scope.post, function (post) {
            $location.path('/');
        });
    };
    $scope.updatePreview = function () {
        $http.get('/api/Markdown?md=' + escape($scope.post.Content)).success(function (data) {
            $scope.content = data.substring(1, data.length - 1).replace(/\\n/g, '');
        });
    }
}
