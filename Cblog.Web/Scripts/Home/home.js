angular.module('home', ['postdb'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', { controller: PostsListCtrl, templateUrl: '/Home/List' })
            .when('/blog/:postId', { controller: PostsReadCtrl, templateUrl: '/Home/Read' })
            .otherwise({ redirectTo: '/' });
    });

function PostsListCtrl($scope, PostDb) {
    $scope.posts = PostDb.query();
}

function PostsReadCtrl($scope, $routeParams, $location, PostDb) {
    $scope.post = PostDb.get({ id: $routeParams.postId });
}
