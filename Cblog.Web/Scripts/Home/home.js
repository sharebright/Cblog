angular.module('home', ['ngSanitize', 'blogdb'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', { controller: PostsListCtrl, templateUrl: '/Home/List' })
            .when('/blog/:postId', { controller: PostsReadCtrl, templateUrl: '/Home/Read' })
            .otherwise({ redirectTo: '/' });
    });

function PostsListCtrl($scope, BlogDb) {
    $scope.posts = BlogDb.query();
}

function PostsReadCtrl($scope, $routeParams, $location, BlogDb) {
    $scope.post = BlogDb.get({ id: $routeParams.postId });
}
