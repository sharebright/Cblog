angular.module('posts', ['postdb'])
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

function PostsEditCtrl($scope, $location, $routeParams, PostDb) {
    var self = this;

    PostDb.get({ id: $routeParams.postId }, function (post) {
        self.original = post;
        $scope.post = new PostDb(self.original);
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
}

function PostsCreateCtrl($scope, $location, PostDb) {
    $scope.save = function () {
        PostDb.save($scope.post, function (post) {
            $location.path('/');
        });
    };
}
